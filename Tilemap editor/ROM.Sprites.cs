using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        int x = 0;
        public struct CharsToRender
        {
            public int x, y, r, c;
            public CharsToRender(int x, int y, int r, int c)
            {
                this.x = x;
                this.y = y;
                this.r = r;
                this.c = c;
            }
        }

        public Bitmap ReadFromSpriteHeader(Int32 index, List<Color> palette)
        {
            int address = AddressFromIndex(index);
            //int address = index;

            /*            Sprite Header
                        byte 0 is number of 2x2 chars
                        byte 1 is number of 1x1 chars in group 1
                        byte 2 is relative position of first 8x8 char of group 1
                        byte 3 is number of 1x1 chars in group 2
                        byte 4 is position of group 2
                        byte 5 is size to send to vram shifted 5 times (dma group 1)
                        byte 6 is where to place dma group 2 (0 if none)
                        byte 7 is number of chars in group dma group 2*/
            int byte0 = Read8(address++);
            int byte1 = Read8(address++);
            int byte2 = Read8(address++);
            int byte3 = Read8(address++);
            int byte4 = Read8(address++);
            int byte5 = Read8(address++);
            int byte6 = Read8(address++);
            int byte7 = Read8(address++);

            // Chars to render
            var cTR = new List<CharsToRender>();
            cTR.AddRange(Read2x2(ref address, byte0));
            cTR.AddRange(Read1x1(ref address, byte1, byte2));
            cTR.AddRange(Read1x1(ref address, byte3, byte4));

            // Emulate vram (with addresses)
            List<List<int>> vram = SetupVRAM(address, byte5, byte6, byte7);
            
            Bitmap bmp = new Bitmap(256, 256);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.Transparent);

                //gr.DrawImage(DecodeChar(address, 4, palette), index.x, index.y);
                foreach (var i in cTR)
                {
                    var addr = vram[i.r][i.c];
                    int x = i.x, y = i.y;
                    gr.DrawImage(DecodeChar(addr, 4, palette), x, y);

                }


            }
            return bmp;
        }
        private CharsToRender[] Read2x2(ref int address, int size)
        {
            var cTR = new List<CharsToRender>();
            int r = 0, c = 0;

            // Are there more to place?
            while (--size >= 0)
            {
                var x = Read8(ref address);
                var y = Read8(ref address);
                // Add each to our 'sprites to render'
                var temp = new CharsToRender(x + 0, y + 0, r + 0, c + 0);
                cTR.Add(temp);
                temp = new CharsToRender(x + 8, y + 0, r + 0, c + 1);
                cTR.Add(temp);
                temp = new CharsToRender(x + 0, y + 8, r + 1, c + 0);
                cTR.Add(temp);
                temp = new CharsToRender(x + 8, y + 8, r + 1, c + 1);
                cTR.Add(temp);
                // Increment column
                c += 2;
                // Did we reach boundary?
                if (c == 16)
                {
                    r += 2;
                    c = 0;
                }
            }
            return cTR.ToArray();
        }
        private CharsToRender[] Read1x1(ref int address, int size, int start)
        {
            var cTR = new List<CharsToRender>();
            int r = start >> 4, c = start & 0xf;

            // Are there more to place?
            while (--size >= 0)
            {
                var x = Read8(ref address);
                var y = Read8(ref address);
                // Add each to our 'sprites to render'
                var temp = new CharsToRender(x, y, r + 0, c + 0);
                cTR.Add(temp);
                // Increment column
                c++;
                // Did we reach boundary?
                if (c == 16)
                {
                    r += 1;
                    c = 0;
                }
            }
            return cTR.ToArray();
        }
        public Bitmap DecodeChar(Int32 address, int bpp, List<Color> palette)
        {
            // Get array of bytes
            int[] @char = GetArrayOfBytes(address, bpp);

            // Create image to return
            DirectBitmap bmp = new DirectBitmap(8, 8);

            // Rows of resulting image
            for (int i = 0, index = 0; i < 8; i++)
            {
                // Columns of resulting image
                for (int j = 0; j < 8; j++)
                {
                    if (j == 2)
                    {

                    }

                    int colorIndex = 0;

                    // Loop for bpp
                    for (int k = 0; k < bpp / 2; k++)
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
        private Int32[] GetArrayOfBytes(Int32 address, int bpp)
        {
            List<int> temp = new List<int>();

            for (int i = 0; i < bpp / 2 * 16; i++)
            {
                temp.Add(Read8(address++));
            }

            return temp.ToArray();
        }
        public void PositionChars (int _16Num, int _8Num, int _8start, Graphics gr, int[] _16X, int[] _16Y, int[] _8X, int[] _8Y, List<List<int>> vram)
        {


        }
        private List<List<int>> SetupVRAM(int address, int endGroup1, int startGroup2, int countGroup2)
        {
            List<List<int>> @return = new List<List<int>> ();
            int currentIndex = 0;
            // Fill group 1
            for (int i = 0; currentIndex < endGroup1; i++)
            {
                // Add new row to vram
                @return.Add(new List<int>());
                // Loop through chars
                for (int j = 0; j < 16 && currentIndex++ < endGroup1; j++)
                {
                    @return[i].Add(address);
                    address += 0x20;
                }
            }
            
            // Fill group 2
            while (@return.Count <= startGroup2 >> 4)
            {
                @return.Add(new List<int>());
                @return.Add(new List<int>());
            }
            for (int i = 0; i < countGroup2; i++)
            {
                @return[startGroup2 >> 4].Add(address);
                address += 0x20;
            }


            return @return;

        }
        private int AddressFromIndex(int current)
        {
            int address = 0;

            // Each index is 32 bits wide. 1 index is 8
            // Already 32
            //current = current << 2;


            // Which index are we looking at?
            int index = 0xbbcc9c + current;

            // Address of index
            address = (Read8(index + 2) << 16) | Read16(index);

            return address;
        }


    }
}
