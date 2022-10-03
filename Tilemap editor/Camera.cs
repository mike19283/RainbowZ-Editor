
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public class Camera
    {
        public int xLeft;
        public int yBottom;
        public int xRight;
        public int yTop;
        public int address;
        ROM rom;
        public int index;
        int xLvlStart;
        int lvlCode;
        DKCLevel level;
        int xLast, yLast;
        public int startingEntity, lastInThis,
            nextEntity, lastInNext;
        private int x_displacement;
        private int y_displacement;
        private int xSize;
        private int ySize;

        public Camera(Int32 address, ROM rom, DKCLevel level, int index)
        {
            this.level = level;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            lvlCode = level.levelCode;
            this.address = address;
            this.index = index;

            xLeft = rom.Read16(address + 0);
            yTop = rom.Read16(address + 2);
            yBottom = rom.Read16(address + 4);
        }
        public Bitmap DrawEntity(Bitmap bmp, Form form)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (rom.IsVertical(level.levelCode))
                    return bmp;
                int xRight;
                if (index == level.cameraBoxes.Count - 1)
                {
                    xRight = bmp.Width + xLvlStart;
                }
                else
                {
                    xRight = level.cameraBoxes[index + 1].xLeft - 1;
                }
                xSize = xRight - xLeft;
                ySize = bmp.Height - yTop - (0x100 - yBottom);
                x_displacement = xLeft - xLvlStart;
                g.FillRectangle(new SolidBrush(Color.FromArgb(0x20,40,255,0)), x_displacement, yTop, xSize, ySize);
                g.DrawRectangle(new Pen(Color.Yellow, 3), x_displacement, yTop, xSize, ySize);
                g.DrawString(index.ToString("X"), form.Font, Brushes.White, x_displacement + 10, yTop + 10);

            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{index.ToString("X")}: LTB ({xLeft.ToString("X")}, {yTop.ToString("X")}, {yBottom.ToString("X")})";
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
            var posInWhole = 0x7000 - y;
            displacement = posInWhole - dif;

            return displacement;
        }
        public void WriteCamToROM ()
        {
            rom.Write16(address + 0, xLeft);
            rom.Write16(address + 2, yTop);
            rom.Write16(address + 4, yBottom);
        }
        public byte[] GetCaneraAsBytes()
        {
            List<byte> @return = new List<byte> ();
            @return.Add((byte)(xLeft >> 0));
            @return.Add((byte)(xLeft >> 8));
            @return.Add((byte)(yTop >> 0));
            @return.Add((byte)(yTop >> 8));
            @return.Add((byte)(yBottom >> 0));
            @return.Add((byte)(yBottom >> 8));
            @return.Add(0);
            @return.Add(0);
            return @return.ToArray();
        }
        public Tuple<Camera, string> IsMouseInBounds(int x, int y)
        {
            if (x < x_displacement + 10 &&
                x > x_displacement &&
                y > yTop + 10 &&
                y < yTop +ySize - 20
                )
            {
                return new Tuple<Camera, string>(this, "x");
            }
            else if (x < x_displacement + xSize &&
                    x > x_displacement &&
                    y > yTop - 10 &&
                    y < yTop + 10
                    )
            {
                return new Tuple<Camera, string>(this, "yT");
            }
            else if (x < x_displacement + xSize &&
                    x > x_displacement &&
                    y > yTop + ySize - 10 &&
                    y < yTop + ySize + 10
                    )
            {
                return new Tuple<Camera, string>(this, "yB");
            }


            return null;
        }

    }
}
