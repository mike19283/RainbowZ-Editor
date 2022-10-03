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
    public class Banana
    {
        public int type;
        public int x;
        public int y;
        public int address;
        ROM rom;
        public static int counter = 0;
        public int local;
        int xLvlStart;
        int lvlCode;
        DKCLevel level;
        string str;
        private int x_displacement;
        private int y_displacement;

        public Banana(Int32 address, ROM rom, DKCLevel level, int index)
        {
            this.level = level;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            lvlCode = level.levelCode;
            this.address = address;
            local = index;

            ReadMap();

            str = $"[{type.ToString("X")}] \n({x.ToString("X")},{y.ToString("X")})";
        }
        public Bitmap DrawEntity(Bitmap bmp, Form form)
        {
            if (type == 0)
            {
                return bmp;
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                x_displacement = x;
                if (rom.IsVertical(lvlCode))
                {
                    y_displacement = GetVerticalDisplacement(y);
                    //y_displacement = y;
                }
                else
                {
                    y_displacement = y;
                    //y_displacement++;
                }
                var index = GetTypeIndex();
                try
                {
                    g.DrawImage(Global.bananaImg[index], x_displacement, y_displacement);
                }
                catch { }
                //g.FillRectangle(new SolidBrush(Color.Black), x_displacement, y_displacement, 50, 50);
                //g.DrawRectangle(new Pen(Color.Yellow, 3), x_displacement, y_displacement, 50, 50);
                g.DrawString(local.ToString("X"), form.Font, Brushes.White, x_displacement, y_displacement);
                //g.DrawString(str, form.Font, Brushes.Yellow, x_displacement + 3, y_displacement + 10);

            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{local.ToString("X")} - [{type.ToString("X")}] ({x.ToString("X")},{y.ToString("X")})";
        }
        private int GetNextHighestPower(int num)
        {
            num--;
            num |= num >> 1;
            num |= num >> 2;
            num |= num >> 4;
            num |= num >> 8;
            num |= num >> 16;
            num++;
            return num;
        }
        public int GetVerticalDisplacement(int y)
        {
            int displacement = 0;
            // Top of image
            var topOG = level.theme & 0xffff;
            var topOfLevel = level.tilemapOffset & 0xffff;
            var dif = (topOfLevel / 4 - topOG / 4);
            var posInWhole = y;
            displacement = posInWhole - dif;

            return displacement;
        }
        private void ReadMap()
        {
            int b0, b1, b2, b3;
            b0 = rom.Read8(address + 0);
            b1 = rom.Read8(address + 1);
            b2 = rom.Read8(address + 2);
            b3 = rom.Read8(address + 3);

            // bbbbbbbb yyyyyybb xxxyyyyy xxxxxxxx (base 2)
            type = ((b0 & 0xff) << 0) | ((b1 & 0x3) << 8);
            int xLo = b2 >> 5;
            int xHi = b3 << 3;
            x = xLo | xHi;
            int yLo = b1 >> 2;
            int yHi = (b2 & 0x1f) << 6;
            y = yLo | yHi;
            x *= 8;
            y *= 8;
            //y = ((b1 & 0xfc) >> 2) | ((b2 & 0x1f) << 6);


        }
        public void WriteAllToROM ()
        {
            // bbbbbbbb yyyyyybb xxxyyyyy xxxxxxxx (base 2)
            var writeType = type & 0x3fe;
            var writeX = (x / 8) & 0x7ff;
            var writeY = (y / 8) & 0x3ffff;
            var test = writeY * 8;
            var value = (writeType << 0) | (writeY << 10) | (writeX << 21);
            rom.Write32(address, value);

        }
        public byte[] GetBananaAsBytes ()
        {
            List<byte> @return = new List<byte>();
            // bbbbbbbb yyyyyybb xxxyyyyy xxxxxxxx (base 2)
            var writeType = type & 0x3fe;
            var writeX = (x / 8) & 0x7ff;
            var writeY = (y / 8) & 0x3ffff;
            var test = writeY * 8;
            var value = (writeType << 0) | (writeY << 10) | (writeX << 21);
            @return.Add((byte)(value >> 0));
            @return.Add((byte)(value >> 8));
            @return.Add((byte)(value >> 16));
            @return.Add((byte)(value >> 24));

            return @return.ToArray();
        }
        public int GetTypeIndex()
        {
            return (type >> 1) - 1;
        }

        public int GetAntiVerticalDisplacement(int y)
        {
            int displacement = 0;
            // Top of image
            var topOG = level.theme & 0xffff;
            var topOfLevel = level.tilemapOffset & 0xffff;
            var dif = (topOfLevel / 4 - topOG / 4);
            var posInWhole = y;
            displacement = posInWhole + dif;

            return displacement;
        }
        public Banana IsMouseInBounds(int x, int y)
        {
            if (x < x_displacement + 25 &&
                x > x_displacement - 25 &&
                y < y_displacement + 25 &&
                y > y_displacement - 25
                )
            {
                return this;
            }

            return null;
        }



    }
}
