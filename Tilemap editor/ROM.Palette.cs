using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public List<List<Color>> ReadPaletteFromCustomFile()
        {
            List<List<Color>> @return = new List<List<Color>>();
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Bitmap (*.bmp;)|*.bmp;";
            d.Title = "Select a Bitmap to use";

            var byteArray = File.ReadAllBytes("E:\\OneDrive\\TASwork\\DKC Enemy Rando 2.0\\ROMs\\donkey - 0x3C849A.bmp");
            Bitmap bmp = BytesToBitmap(byteArray);

            // Scan bmp
            for (int height = 0; height < bmp.Height; height += 20)
            {
                @return.Add(new List<Color>() { Color.Transparent });
                for (int width = 0; width < bmp.Width; width += 20)
                {
                    @return[height].Add(bmp.GetPixel(width, height));
                }
            }


            return @return;
        }
        public static Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                ms.Position = 0;
                Bitmap img = (Bitmap)Image.FromStream(ms);
                return img;
            }
        }
        public Int32 ConvertColorToSNES(Color color)
        {
            // Get rgb of current color
            int r = color.R;
            int g = color.G;
            int b = color.B;

            // Make each 5 bits long
            r >>= 3;
            g >>= 3;
            b >>= 3;

            // Arrange in SNES format
            Int32 @return = (r << 0) | (g << 5) | (b << 10);
            return @return;
        }
        public void WritePaletteToROM(List<List<Color>> color, Int32 address)
        {
            // Loop Through palette
            foreach (var row in color)
            {
                foreach (var col in row)
                {
                    // Convert color to snes
                    Int32 num = ConvertColorToSNES(col);

                    // Write to ROM
                    Write16(ref address, num);
                }
            }
        }
        public List<List<Color>> ReadPalette(int offset, int rows = 1, int colSize = 15)
        {
            List<List<Color>> @return = new List<List<Color>>();
            // Loop through rows
            for (int i = 0; i < rows; i++)
            {
                if (colSize == 15) 
                    @return.Add(new List<Color>() { Color.Transparent });
                else
                    @return.Add(new List<Color>());

                // And then columns
                for (int j = 0; j < colSize; j++)
                {
                    // Now we're looking at each individual color
                    int raw = Read16(ref offset);

                    // Break into components (rgb15)
                    // xxxbbbbbgggggrrrrr
                    int r = ((raw >> 0) & 0x1f) << 3;
                    int g = ((raw >> 5) & 0x1f) << 3;
                    int b = ((raw >> 10) & 0x1f) << 3;

                    // Get new color
                    Color color = Color.FromArgb(r, g, b);

                    @return[i].Add(color);
                }

            }

            return @return;
        }
        public static Color ConvertSNEStoColor(int value)
        {
            int r = (value >> 0) & 0x1f;
            int g = (value >> 5) & 0x1f;
            int b = (value >> 10) & 0x1f;

            // rgb is 5 bits each, shift 3 for 8
            Color @return = Color.FromArgb((r << 3), (g << 3), (b << 3));
            return @return;
        }

        public List<List<Color>> ReadPaletteFromROM(int offset, int rows, int cols)
        {
            List<List<Color>> @return = new List<List<Color>>();
            // Loop through rows
            for (int i = 0; i < rows; i++)
            {
                @return.Add(new List<Color>());
                // And then columns
                for (int j = 0; j < cols; j++)
                {
                    string id = $"({i},{j})";
                    // Now we're looking at each individual color
                    int raw = Read16(ref offset);

                    // Break into components
                    // xxxbbbbbgggggrrrrr
                    int r = ((raw >> 0) & 0x1f) << 3;
                    int g = ((raw >> 5) & 0x1f) << 3;
                    int b = ((raw >> 10) & 0x1f) << 3;

                    // Get new color
                    Color color = Color.FromArgb(r, g, b);

                    @return[i].Add(color);
                }

            }

            return @return;
        }
        public List<byte> WritePaletteFile(List<List<Color>> palette, Int32 address, List<byte> file)
        {
            // Loop Through palette
            foreach (var row in palette)
            {
                foreach (var col in row)
                {
                    // Convert color to snes
                    Int32 num = ConvertColorToSNES(col);

                    // Write to file
                    file.Add((byte)num);
                    file.Add((byte)(num >> 8));
                }
            }
            return file;
        }


    }
}
