using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public class PlatformPath
    {
        public int x, y, speed, address, xLvlStart, command, loopPointer;
        public bool full;
        ROM rom;
        DKCLevel level;
        public int index;
        public int pathNum;
        bool reg = true;
        private int x_displacement;
        private int y_displacement;

        public PlatformPath(Int32 address, ROM rom, DKCLevel level, int index, int pathNum, bool full, int previousSpeed)
        {
            this.pathNum = pathNum;
            this.address = address;
            this.level = level;
            this.index = index;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            this.full = full;

            command = rom.Read16(address + 0);
            switch (command)
            {
                case 0xfffd:
                    loopPointer = rom.Read16(address + 2);
                    break;
                case 0xfffe:
                    speed = rom.Read16(address + 2);
                    x = rom.Read16(address + 4);
                    y = rom.Read16(address + 6);
                    break;
                default:
                    speed = previousSpeed;
                    x = rom.Read16(address + 0);
                    y = rom.Read16(address + 2);
                    command = 0;
                    break;
            }


        }
        public PlatformPath()
        {
            command = 0xfffe;
            x = 0;
            y = 0;
            speed = 0x100;
            address = 0;
        }
        public Bitmap DrawEntity(Bitmap bmp, Form form)
        {
            if (command == 0xfffd)
                return bmp;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                x_displacement = x - xLvlStart;
                y_displacement = y ^ 0x1ff;
                y_displacement++;


                //g.FillRectangle(new SolidBrush(Color.Black), x_displacement, y_displacement, 50, 50);
                //g.DrawRectangle(new Pen(Color.Red, 3), x_displacement, y_displacement, 50, 50);
                //g.DrawString(pointer.ToString("X"), form.Font, Brushes.Red, x_displacement + 10, y_displacement + 10);
                g.FillEllipse(new SolidBrush(Color.Purple), x_displacement - 10, y_displacement - 10, 20, 20);
                g.DrawString(index.ToString("X"), form.Font, Brushes.White, x_displacement, y_displacement);
                if (index - 1 >= 0)
                {
                    var previousPath = level.platformPaths[pathNum][index - 1];
                    int prevXDisplace = previousPath.x - xLvlStart;
                    int prevY_displacement = previousPath.y ^ 0x1ff;
                    prevY_displacement++;
                    g.DrawLine(new Pen(Color.Orange, GetWidth()), prevXDisplace, prevY_displacement, x_displacement, y_displacement);

                }
            }
            return bmp;
        }
        private int GetWidth()
        {
            if (speed < 0x80)
            {
                return 1;
            }
            else if (speed < 0x100)
            {
                return 2;
            }
            else if (speed < 0x180)
            {
                return 3;
            }
            else if (speed < 0x200)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }
        public void SetSpeed (int speed)
        {
            this.speed = speed;
        }
        public override string ToString()
        {
            if (command == 0xfffe)
            {
                return $"{index.ToString("X")} - [{command.ToString("X")}] ({x.ToString("X")},{y.ToString("X")}) - {speed.ToString("X")}";
            }
            else if (command == 0xfffd)
            {
                return $"{index.ToString("X")} - [{command.ToString("X")}] - {loopPointer.ToString("X")}";
            }
            else if (command == 0xffff)
            {
                return "[FFFF]";
            }
            else
            {
                return $"{index.ToString("X")} - ({x.ToString("X")},{y.ToString("X")})";
            }
        }
        public void WriteToROM()
        {
            return;
            rom.Write16(address + 0, command);
            rom.Write16(address + 2, speed);
            rom.Write16(address + 4, x);
            rom.Write16(address + 6, y);
        }
        public byte[] GetBytes()
        {
            List<byte> @return = new List<byte>();
            @return.Add((byte)(command >> 0));
            @return.Add((byte)(command >> 8));
            switch (command)
            {
                case 0xffff:
                    break;

                case 0xfffe:
                    @return.Add((byte)(speed >> 0));
                    @return.Add((byte)(speed >> 8));
                    @return.Add((byte)(x >> 0));
                    @return.Add((byte)(x >> 8));
                    @return.Add((byte)(y >> 0));
                    @return.Add((byte)(y >> 8));
                    break;
                case 0xfffd:
                    @return.Add((byte)(loopPointer >> 0));
                    @return.Add((byte)(loopPointer >> 8));
                    break;
                default:
                    @return = new List<byte>();
                    @return.Add((byte)(x >> 0));
                    @return.Add((byte)(x >> 8));
                    @return.Add((byte)(y >> 0));
                    @return.Add((byte)(y >> 8));
                    break;
            }


            return @return.ToArray();
        }
        public PlatformPath IsMouseInBounds(int x, int y)
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
