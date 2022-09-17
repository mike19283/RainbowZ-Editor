using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class CopyrightEdit : Form
    {
        ROM rom;
        Bitmap img;
        int[] copyright;
        int[][] rowStarts;

        public CopyrightEdit(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            Global.WriteToArr(rom);
            copyright = rom.ReadSubIntArray(0xe40450, 0x240, rom.rom.ToArray());

            Bitmap bmp = DisplayImage(0x01F3E8, 0xc00, 0xe40450, 0x240, 0xb9c203, 0x200);
            pictureBox_preview.Image = bmp;

            var og = File.ReadAllBytes("bins\\og copyright Offset - E40450.bin");
            if (Global.IntSequenceEqualsSNES(copyright,og))
            {
                copyright = new int[0x120];
                ApplyTilemap();
            }
            else
            {
                textBox_custom1.Lines = ParseCopyright();
            }

            // Up to 8 rows
            rowStarts = new int[][]
            {
                new int[] { 4, 6 },
                new int[] { 3, 5, 7 },
                new int[] { 2, 4, 6, 8 },
                new int[] { 1, 3, 5, 7, 8 },
                new int[] { 1, 3, 5, 6, 7, 8 },
                new int[] { 1, 3, 4, 5, 6, 7, 8 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            };
            var temp = new int[0x120];
            if (copyright.SequenceEqual(temp))
            {
                // 3 is copyright
                string nintendo = "1994 " + textBox_nintendo.Text;
                WriteWordToCopyright(nintendo, 4);
                ApplyTilemap();

            }
        }
        #region Preview
        public struct HighPrority
        {
            public int x;
            public int y;
            public Bitmap bmp;
            public HighPrority(int x, int y, Bitmap bmp)
            {
                this.x = x;
                this.y = y;
                this.bmp = bmp;
            }
        }
        List<HighPrority> highpriority = new List<HighPrority>();

        private int Read16(int address, byte[] file)
        {
            int @return = 0;
            @return = (file[address++] << 0) |
                      (file[address++] << 8);
            return @return;
        }
        // function to reverse bits of a number 
        public int reverseBits(int n)
        {
            int rev = 0;

            // traversing bits of 'n'  
            // from the right 
            while (n > 0)
            {
                // bitwise left shift  
                // 'rev' by 1 
                rev <<= 1;

                // if current bit is '1' 
                if ((int)(n & 1) == 1)
                    rev ^= 1;

                // bitwise right shift  
                //'n' by 1 
                n >>= 1;
            }
            // required number 
            return rev;
        }

        private byte[] Flip4000(byte[] @char)
        {
            List<byte> temp = new List<byte>();
            temp.AddRange(@char);

            for (int i = 0; i < @char.Length; i++)
            {
                temp[i] = (byte)reverseBits((int)temp[i]);
            }

            //return temp.ToArray();
            return @char;
        }
        private byte[] Flip8000_4bpp(byte[] toFlip)
        {
            List<byte> @return = new List<byte>();
            var start = toFlip.Skip(0).Take(0x10).ToArray();
            var end = toFlip.Skip(0x10).Take(0x10).ToArray();


            @return.AddRange(Flip8000_2bpp(start));
            @return.AddRange(Flip8000_2bpp(end));

            return @return.ToArray();

        }
        private byte[] Flip8000_2bpp(byte[] toFlip)
        {
            for (int i = 0; i < toFlip.Length / 2; i += 2)
            {
                // Swap pairs with the last in the list
                var start1 = toFlip[i];
                var start2 = toFlip[i + 1];
                var end1 = toFlip[toFlip.Length - 2 - i];
                var end2 = toFlip[toFlip.Length - 1 - i];

                toFlip[i] = end1;
                toFlip[i + 1] = end2;
                toFlip[toFlip.Length - 2 - i] = start1;
                toFlip[toFlip.Length - 1 - i] = start2;
            }

            return toFlip;

        }
        public Bitmap DrawChar4bpp(List<Color> palette, byte[] @char)
        {

            // Create image to return
            //Bitmap bmp = new Bitmap(8, 8);
            DirectBitmap bmp = new DirectBitmap(8, 8);

            // Rows of resulting image
            for (int i = 0, index = 0; i < 8; i++)
            {
                // Columns of resulting image
                for (int j = 0; j < 8; j++)
                {
                    int colorIndex = 0;

                    // Loop for bpp
                    for (int k = 0; k < 4 /* bpp */ / 2; k++)
                    {
                        // >> To get the right bit, << to get the right bpp
                        var x = (((@char[index + k * 16] >> (7 - j)) & 1) << (k * 2));
                        var y = (((@char[index + 1 + k * 16] >> (7 - j)) & 1) << (k * 2 + 1));
                        colorIndex |= x | y;
                    }

                    bmp.SetPixel(j, i, palette[colorIndex]);
                }
                index += 2;

            }


            return bmp.Bitmap;
        }

        private Bitmap DisplayImage(int tilesOffset, int tilesSize, int tmOffset, int tmSize, int palOffset, int palSize)
        {
            List<List<Color>> pal = rom.ReadPalette(palOffset, 8, 16);
            byte[] tm = rom.ReadSubArray(tmOffset, tmSize, rom.rom.ToArray());
            byte[] tiles = rom.ReadSubArray(tilesOffset, tilesSize, rom.rom.ToArray());


            int height = 224;
            Bitmap bmp = new Bitmap(256, height != 0 ? height : 8);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // What is our transparent color?

                Color transparent = pal[0][0];

                g.Clear(transparent);
                int width = 0;
                height = 0;
                // Loop through tilemap, 2 bytes for each index
                for (int i = 0; i < tm.Length; i += 2)
                {
                    try
                    {
                        int value = Read16(i, tm);
                        bool vFlip = (value & 0x8000) == 0x8000;
                        bool hFlip = (value & 0x4000) == 0x4000;
                        bool priority = (value & 0x2000) == 0x2000;
                        int tileIndex = value & 0x3ff;
                        List<byte> temp = new List<byte>();
                        //temp.AddRange(tilesBreakdown[tabControl_main.SelectedIndex][tileIndex]);
                        temp.AddRange(tiles.Skip(tileIndex << 5).Take(0x20));
                        byte[] tile = temp.ToArray();
                        int palIndex = (value & 0x1c00) >> 10;

                        var palf = pal[palIndex];
                        if (vFlip)
                        {
                            tile = Flip8000_4bpp(tile);
                        }
                        if (hFlip)
                        {
                            tile = Flip4000(tile);
                        }
                        if (width == 256)
                        {
                            width = 0;
                            height += 8;
                        }
                        Bitmap @char;
                        @char = DrawChar4bpp(palf, tile);
                        if (priority)
                        {
                            highpriority.Add(new HighPrority(width, height, @char));
                        }
                        else
                        {
                            g.DrawImage(@char, width, height);
                        }
                    }
                    catch (Exception ex)
                    {
                        //return;
                    }
                    width += 8;

                }
                foreach (var @char in highpriority)
                {
                    g.DrawImage(@char.bmp, @char.x, @char.y);
                }
                //g.Clear(transparent);
            }
            img = (Bitmap)bmp.Clone();
            return bmp;
        }

        #endregion

        private void button_apply_Click(object sender, EventArgs e)
        {
            copyright = new int[0x120];
            string[] arr = textBox_custom1.Lines;
            int arrSize = arr.Length;
            if (arrSize < 8)
            {
                // 3 is copyright
                string nintendo = "1994 " + textBox_nintendo.Text;
                WriteWordToCopyright(nintendo, rowStarts[arrSize][0]);

                for (int i = 0; i < arrSize; i++)
                {
                    if (arr[i].Length == 0)
                        continue;
                    WriteWordToCopyright(DateTime.Now.Year + " " + arr[i], rowStarts[arrSize][i + 1]);

                }
                ApplyTilemap();
                MessageBox.Show("Done");
            }
            else
            {
                ApplyTilemap();
                MessageBox.Show("Too many cooks!");
            }

        }
        private void WriteWordToCopyright(string str, int row)
        {
            int totalLength = str.Length;
            int start = CountStartingBlanks(totalLength);
            int rows = row * 0x20;
            copyright[rows + start++] = 3;
            for (int i = 0; i < totalLength; i++)
            {
                int local = (byte)str[i] - 0x20;
                copyright[rows + start++] = local;
            }
        }
        private int CountStartingBlanks(int w)
        {
            int @return = 0;
            for (int i = 0, j = 0x20; true; i++, j--)
            {
                @return = i;
                if (i + w > j)
                {
                    break;
                }
            }
            return @return;
        }

        private void ApplyTilemap()
        {

            rom.WriteArrOfIntsToROM(copyright, 0xe40450);
            Bitmap bmp = DisplayImage(0x01F3E8, 0xc00, 0xe40450, 0x240, 0xb9c203, 0x200);
            pictureBox_preview.Image = bmp;
        }
        private string[] ParseCopyright ()
        {
            List<string> @return = new List<string>();
            int rowStartIndex = 0;
            for (int i = 0; i < 0x120 / 0x20; i++)
            {
                string lineString = "";
                for (int j = 0; j < 0x20; j++)
                {
                    var val = copyright[i * 0x20 + j];
                    lineString += (char)(val + 0x20);
                }
                lineString = lineString.Trim();
                if (lineString.Length > 4)
                    lineString = lineString.Substring(6);
                if (lineString != "NINTENDO")
                {
                    @return.Add(lineString);
                }
            }
            while (@return[0] == "")
            {
                @return.RemoveAt(0);
                if (@return.Count == 0)
                    return @return.ToArray();
            }
            int returnSize = @return.Count - 1;
            while (@return[returnSize] == "")
            {
                @return.RemoveAt(returnSize);
                returnSize = @return.Count - 1;
            }

            return @return.ToArray();
        }

        private void CopyrightEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            var temp = new int[0x120];
            if (copyright.SequenceEqual(temp))
            {
                // 3 is copyright
                string nintendo = "1994 " + textBox_nintendo.Text;
                WriteWordToCopyright(nintendo, 4);
                ApplyTilemap();

            }

        }
    }
}
