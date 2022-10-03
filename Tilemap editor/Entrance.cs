using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public class Entrance
    {
        public int x;
        public int y;
        public int address;
        ROM rom;
        public static int counter = 0;
        public int local;
        public int lvlCode;
        DKCLevel level;
        int xLvlStart;
        public int entranceCode;
        public string name;
        public static Bitmap bmp;
        private int x_displacement;
        private int y_displacement;

        public Entrance(Int32 address, ROM rom, DKCLevel level, int entranceCode)
        {
            this.level = level;
            this.rom = rom;
            lvlCode = level.levelCode;
            x = rom.Read16(address + 0);
            y = rom.Read16(address + 2);
            this.address = address;
            local = counter++;
            xLvlStart = level.lvlXBoundStart & 0xffff;
            this.entranceCode = entranceCode;
            name = rom.nameByLevelCode[entranceCode];
        }
        public Bitmap DrawEntity(Bitmap bmp, Form form)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                x_displacement = x - xLvlStart;
                
                if (rom.IsVertical(lvlCode))
                {
                    y_displacement = GetVerticalDisplacement(y);

                }
                else
                {
                    y_displacement = y ^ 0x1ff;
                    y_displacement++;
                }
                x_displacement -= 10;
                y_displacement -= Entrance.bmp.Height;
                g.DrawImage(Entrance.bmp, x_displacement, y_displacement);
                //g.FillRectangle(new SolidBrush(Color.Black), x_displacement, y_displacement, 50, 50);
                //g.DrawRectangle(new Pen(Color.Blue, 3), x_displacement, y_displacement, 50, 50);
                g.DrawString(local.ToString("X") + " " + entranceCode.ToString("X"), form.Font, Brushes.White, x_displacement, y_displacement);                
                //g.DrawString("x - " + x.ToString("X"), form.Font, Brushes.Blue, x_displacement + 5, y_displacement + 10);
                //g.DrawString("y - " + y.ToString("X"), form.Font, Brushes.Blue, x_displacement + 5, y_displacement + 20);

            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{entranceCode.ToString("X")} - {rom.nameByLevelCode[entranceCode]} - ({x.ToString("X")}, {y.ToString("X")})";
        }
        public int GetVerticalDisplacement(int y)
        {
            int displacement = 0;
            // Top of image
            var topOG = level.theme & 0xffff;
            var topOfLevel = level.tilemapOffset & 0xffff;
            var dif = (topOfLevel / 4 - topOG / 4);
            var posInWhole = 0x7000 - y;
            displacement = posInWhole - dif;

            return displacement;
        }

        public static void GetGraphic()
        {
            Bitmap bmp = new Bitmap("" +
                "" +
                "" +
                "" +
                "Sprites/1.bmp");
            Entrance.bmp = bmp;
        }

        public byte[] GetEntranceAsBytes ()
        {
            List<byte> @return = new List<byte>();
            @return.Add((byte)(x >> 0));
            @return.Add((byte)(x >> 8));
            @return.Add((byte)(y >> 0));
            @return.Add((byte)(y >> 8));
            return @return.ToArray();
        }
        public Entrance IsMouseInBounds(int x, int y)
        {
            if (x < x_displacement + 25 &&
                x > x_displacement - 25 &&
                y < y_displacement + 25 &&
                y > y_displacement - 25 &&
                (!(name.Contains("ave") || name.Contains("Kong") || name.Contains("tree"))) &&
                entranceCode != 0x16
                )
                
            {
                return this;
            }

            return null;
        }
    }
}
