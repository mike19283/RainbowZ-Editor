using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public static List<int> tilemap = new List<int>();
        // Loop through every char
        // Extract Palette number from each
        // 2 bytes for every char
        // cccccccc ccpppPhv
        // Every char is written in order
        public static int tmIndex = 0;

        // function to reverse bits of a number 
        public static int reverseBits(int n)
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
        public static byte[] Flip4000(byte[] @char)
        {
            List<byte> temp = new List<byte>(@char);

            for (int i = 0; i < @char.Length; i++)
            {
                temp[i] = (byte)reverseBits((int)temp[i]);
            }

            return temp.ToArray();
            //return @char;
        }
        public static byte[] Flip8000_4bpp(byte[] toFlip)
        {
            List<byte> @return = new List<byte>();
            var start = toFlip.Skip(0).Take(0x10).ToArray();
            var end = toFlip.Skip(0x10).Take(0x10).ToArray();


            @return.AddRange(Flip8000_2bpp(start));
            @return.AddRange(Flip8000_2bpp(end));

            return @return.ToArray();

        }
        private static byte[] Flip8000_2bpp(byte[] toFlip)
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

    }
}
