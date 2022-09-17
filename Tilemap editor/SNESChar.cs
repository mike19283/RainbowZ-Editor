using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public class SNESChar
    {
        public byte[] bitplanes;
        int attr;
        public int paletteIndex;
        Color[] palette;
        Bitmap regTile;

        public SNESChar(byte[] bitplanes, List<List<Color>> masterPalette, int attr)
        {

            // Seperate tile/attributes
            this.bitplanes = bitplanes;
            this.attr = attr;
            ///*
            if ((attr & 0x4000) > 0)
            {
                this.bitplanes = Flip4000(this.bitplanes);

            }
            //*/
            ///*
            if ((attr & 0x8000) > 0)
            {
                this.bitplanes = Flip8000_4bpp(this.bitplanes);
            }
            //*/
            paletteIndex = (attr & 0x1c00) >> 10;
            palette = masterPalette[paletteIndex].ToArray();
        }

        // function to reverse bits of a number 
        public int reverseBits(int n)
        {
            int rev = 0;
            // Surround with set bits
            n |= 0x100;
            n <<= 1;
            n |= 1;
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
            // Remove extra bits
            rev >>= 1;
            rev &= 0xff;
            // required number 
            return rev;
        }
        public byte[] Flip4000(byte[] @char)
        {
            List<byte> temp = new List<byte>();
            temp.AddRange(@char);

            for (int i = 0; i < @char.Length; i++)
            {
                temp[i] = (byte)reverseBits((int)temp[i]);
            }

            return temp.ToArray();
            //return @char;
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

        public Bitmap DrawChar(byte[] @char)
        {
            //Console.WriteLine($"{debug} - {a}");

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
        public byte[] TempFlip(int flip)
        {
            byte[] @return = bitplanes;

            if ((flip & 0x4000) > 0)
                @return = Flip4000(@return);
            if ((flip & 0x8000) > 0)
                @return = Flip8000_4bpp(@return);
            
            return @return.ToArray();
        }


    }
}
