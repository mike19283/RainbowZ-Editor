using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class ROM
    {
        public Bitmap img;
        #region Draw Map
        public struct HighProrityImage
        {
            public int x;
            public int y;
            public Bitmap bmp;
            public HighProrityImage(int x, int y, Bitmap bmp)
            {
                this.x = x;
                this.y = y;
                this.bmp = bmp;
            }
        }
        List<HighProrityImage> highpriority = new List<HighProrityImage>();

        public Bitmap DrawChar4bpp(List<Color> palette, byte[] @char)
        {

            // Create image to return
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
        private int Read16(int address, byte[] file)
        {
            int @return = 0;
            @return = (file[address++] << 0) |
                      (file[address++] << 8);
            return @return;
        }
        // function to reverse bits of a number 
        public int reverseBitsI(int n)
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

        private byte[] Flip4000I(byte[] @char)
        {
            List<byte> temp = new List<byte>();
            temp.AddRange(@char);

            for (int i = 0; i < @char.Length; i++)
            {
                temp[i] = (byte)reverseBitsI((int)temp[i]);
            }

            //return temp.ToArray();
            return @char;
        }
        private byte[] Flip8000_4bppI(byte[] toFlip)
        {
            List<byte> @return = new List<byte>();
            var start = toFlip.Skip(0).Take(0x10).ToArray();
            var end = toFlip.Skip(0x10).Take(0x10).ToArray();


            @return.AddRange(Flip8000_2bppI(start));
            @return.AddRange(Flip8000_2bppI(end));

            return @return.ToArray();

        }
        private byte[] Flip8000_2bppI(byte[] toFlip)
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


        public Bitmap DisplayImage(int tilesOffset, int tilesSize, int tmOffset, int tmSize, int palOffset, int palSize)
        {
            List<List<Color>> pal = ReadPalette(palOffset, 8, 16);
            byte[] tm = ReadSubArray(tmOffset, tmSize, rom.ToArray());
            byte[] tiles = ReadSubArray(tilesOffset, tilesSize, rom.ToArray());


            int height = 224;
            Bitmap bmp = new Bitmap(256, height != 0 ? height : 8);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // What is our transparent color?

                //Color transparent = pal[0][0];
                Color transparent = Global.transparentClr;

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
                            tile = Flip8000_4bppI(tile);
                        }
                        if (hFlip)
                        {
                            tile = Flip4000I(tile);
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
                            highpriority.Add(new HighProrityImage(width, height, @char));
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

    }
}
