using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class VerticalCamera
    {
        // Size stored natively, 
        // but it makes more sense to use endpoints
        public int xStart;
        public int yStart;
        public int xEnd;
        public int yEnd;
        public int xSize;
        public int ySize;
        public int address;
        public List<int> types = new List<int>();
        public List<VConnection> vConnections = new List<VConnection>();

        public static Dictionary<string, int> directionLUT = new Dictionary<string, int>()
        {
            ["L"] = 0x0,
            ["R"] = 0x3,
            ["U"] = 0x6,
            ["D"] = 0x9,
        };

        public int offset;
        public int prevPointer;
        public int pointer;
        public int nextPointer;
        public int prevPointerAddress;
        public int pointerAddress;
        public int nextPointerAddress;
        ROM rom;
        public int index;
        int xLvlStart;
        int lvlCode;
        DKCLevel level;

        public VerticalCamera(int xStart, int yStart, int connection, ROM rom)
        {
            this.xStart = xStart;            
            this.yStart = yStart;
            xEnd = xStart;
            yEnd = yStart;

            vConnections.Add(new VConnection(connection));
            this.rom = rom;

        }
        public VerticalCamera(Int32 offset, ROM rom, DKCLevel level, int index, int pointer, int nextPointer, int pointerAddress, int nextPointerAddress, int prevPointer, int prevPointerAddress)
        {
            //types.Add(new Func<int>(Function0));
            this.level = level;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            lvlCode = level.levelCode;

            this.index = index;
            this.pointer = pointer;
            this.nextPointer = nextPointer;
            this.pointerAddress = pointerAddress;
            this.nextPointerAddress = nextPointerAddress;
            this.prevPointer = prevPointer;
            this.prevPointerAddress = prevPointerAddress;


            int i = 0;
            this.offset = offset;
            int thisPointer = FindAddress();
            int nextP = rom.Read16(nextPointer + offset + 0xb80000);

            xStart = rom.Read16(address + 0);
            yStart = rom.Read16(address + 3);
            xEnd = rom.Read8(address + 2) * 4 + xStart;
            yEnd = rom.Read8(address + 5) * 4 + yStart;
            xSize = (xEnd - xStart) / 4;
            ySize = (yEnd - yStart) / 4;

            for (int z = thisPointer + 6; z < nextP; z++)
            {
                //types.Add(rom.Read8(0xb80000 + z + offset));
                int addr = 0xb80000 + z + offset;
                int param = rom.Read8(addr);
                int connection = param;
                string direction = "LRUD";
                bool relative = false;
                bool hidden = false;
                bool multiple = false;
                bool isRelative = (param & 0xf) != 0;
                switch ((param >> 4))
                {
                    case 0:
                        direction = "L";
                        break;
                    case 1:
                        direction = "L";
                        hidden = true;
                        break;
                    case 2:
                        direction = "L";
                        multiple = true;
                        break;
                    case 3:
                        direction = "R";
                        break;
                    case 4:
                        direction = "R";
                        hidden = true;
                        break;
                    case 5:
                        direction = "R";
                        multiple = true;
                        break;
                    case 6:
                        direction = "U";
                        break;
                    case 7:
                        direction = "U";
                        hidden = true;
                        break;
                    case 8:
                        direction = "U";
                        multiple = true;
                        break;
                    case 9:
                        direction = "D";
                        break;
                    case 0xa:
                        direction = "D";
                        hidden = true;
                        break;
                    case 0xb:
                        direction = "D";
                        multiple = true;
                        break;
                    default:
                        break;
                }
                relative = isRelative;
                VConnection vConnection = new VConnection(direction, connection, relative, hidden, multiple, level);
                vConnection.cameraIndex = index;
                if (isRelative)
                {

                    int nConnection = (connection & 0xf);
                    vConnection.nextIndex = nConnection;
                }
                else
                {
                    int abs = rom.Read8(addr + 1);
                    vConnection.nextIndex = abs;
                }
                vConnections.Add(vConnection);
                z += isRelative ? 0 : 1;
                z += hidden ? 1 : 0;
            }



            //GameSetup();
        }
        public string FindDirectionOfNextCamera (int x, int y, int xE, int yE)
        {
            int xWidth = xE - x;
            int yHeight = yE - y;
            int thisWidth = xEnd - xStart;
            int thisHeight = yEnd - yStart;
            float xAvg = xWidth / 2;
            xAvg += x;
            float yAvg = yHeight / 2;
            yAvg += y;
            float thisAvgX = thisWidth / 2 + xStart;
            float thisAvgY = thisHeight / 2 + yStart;
            
            if (thisWidth > thisHeight)
            {
                return thisAvgX > xAvg ? "R" : "L";
            }
            else
            {
                return thisAvgY > yAvg ? "D" : "U";
            }

            //int xDif = x - xStart;
            //xDif *= xDif < 0 ? -1 : 1;
            //xDif += xSize;
            //int yDif = y - yStart;
            //bool negY = yDif < 0;
            //yDif *= negY ? -1 : 1;
            //yDif += ySize;
            //if (x > xStart)
            //{
            //    if (xDif > yDif)
            //        return "R";
            //    else
            //        return negY ? "D" : "U";
            //}
            //else
            //{
            //    if (xDif > yDif)
            //        return "L";
            //    else
            //        return negY ? "D" : "U";
            //}

            return "R";
        }

        public int FindAddress()
        {
            int readAddr = pointer + offset + 0xb80000;
            var thisPointer = rom.Read16(readAddr);
            address = 0xb80000 + thisPointer + offset;
            return thisPointer;
        }

        public Bitmap DrawEntity(Bitmap bmp, Form form)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int xSize = xEnd - xStart + 0x100,
                    ySize = yEnd - yStart + 0xe0;
                int x_displacement = xStart - xLvlStart;
                //g.FillRectangle(new SolidBrush(Color.FromArgb(0x80, 40, 255, 0)), x_displacement, GetVerticalDisplacement(yStart), xSize, ySize);
                g.FillRectangle(new SolidBrush(Color.FromArgb(0x10, 40, 255, 0)), x_displacement, GetVerticalDisplacement(yStart), xSize, ySize);

                g.DrawRectangle(new Pen(Color.FromArgb(0x80, 0xf0, 0xf0,0), 3), x_displacement, GetVerticalDisplacement(yStart), xSize, ySize);

                g.DrawString(index.ToString("X"), form.Font, Brushes.White, x_displacement + 10, GetVerticalDisplacement(yStart) + 10);

            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{index.ToString("X")}: ({xStart.ToString("X")}, {yStart.ToString("X")}), ({xEnd.ToString("X")}, {yEnd.ToString("X")})";
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
        public int GetReverseVerticalDisplacement(int y)
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
        public void WriteCamToROM()
        {
            var arr = GetBytes();
            rom.WriteArrToROM(arr, address);

        }
        public void AddUniqueConnection (string direction, int nextIndex, bool relative)
        {
            bool unique = true;
            foreach (var connection in vConnections)
            {
                if (connection.direction == direction && connection.relative == relative && connection.nextIndex == nextIndex)
                {
                    unique = false;
                }
            }
            if (unique)
            {
                VConnection vConnection = new VConnection(direction, 0, relative, false, false, level);
                vConnection.nextIndex = nextIndex;
                vConnections.Add(vConnection);
            }

        }
        public void SetAllMultiples()
        {
            string directions = "UDLR";
            foreach (var direction in directions)
            {
                if (AutoCheckDirection(direction.ToString()))
                {
                    AutoSetMultiple(direction.ToString());
                }
            }
        }
        private void AutoSetMultiple(string direction) 
        {
            foreach (var connection in vConnections)
            {
                if (connection.direction == direction)
                {
                    connection.connection = 0;
                    connection.multiple = true;
                }
            }
        }
        public bool AutoCheckDirection (string direction)
        {
            int count = 0;

            foreach (var connection in vConnections)
            {
                if (connection.direction == direction)
                {
                    count++;
                }
            }

            return count <= 1 ? false : true;
        }
        public bool AutoCheckConnection (string direction, int index)
        {
            foreach (var connection in vConnections)
            {
                int num = connection.nextIndex;
                if (connection.relative)
                {
                    if (num >= 8)
                    {
                        num -= 0x10;
                    }
                    num += connection.cameraIndex;
                }

                if (direction == connection.direction && num == index)
                {
                    return true;
                }
            }
            return false;
        }
        public byte[] GetBytes()
        {
            List<byte> @return = new List<byte>();

            xSize = (xEnd - xStart) / 4;
            ySize = (yEnd - yStart) / 4;
            xSize = xSize > 0xff ? 0xff : xSize;
            ySize = ySize > 0xff ? 0xff : ySize;
            // u16 - xstart, u8 xsize/4, u16 - ystart, u8- ysize/4, params
            @return.Add((byte)(xStart >> 0));
            @return.Add((byte)(xStart >> 8));
            @return.Add((byte)(xSize >> 0));
            @return.Add((byte)(yStart >> 0));
            @return.Add((byte)(yStart >> 8));
            @return.Add((byte)(ySize >> 0));
            foreach (var param in vConnections)
            {
                if (param.connection != 0)
                    @return.Add((byte)param.connection);
                else
                {
                    int num = VerticalCamera.directionLUT[param.direction];
                    if (param.hidden)
                        num++;
                    else if (param.multiple)
                    {
                        num += 2;
                    }
                    num <<= 4;
                    if (param.relative)
                    {
                        num |= param.nextIndex;
                    }
                    @return.Add((byte)num);
                }

                if (!param.relative)
                {
                    @return.Add((byte)param.nextIndex);
                }
                if (param.hidden)
                {
                    @return.Add((byte)1);
                }
            }
            return @return.ToArray();
        }
        public Tuple<VerticalCamera,int> IsMouseInBounds (int x, int y)
        {
            // Change Y to Ycursor
            y = GetReverseVerticalDisplacement(y);
            // X left boundary first
            if (x + 10 > xStart && x - 10 < xStart &&
                y >= yStart && y <= yEnd + 0xe0)
            {
                return new Tuple<VerticalCamera, int>(this,0);
            }
            // X right boundary 
            if (x + 10 > xEnd + 0x100 && x - 10 < xEnd + 0x100 &&
                y >= yStart && y <= yEnd + 0xe0)
            {
                return new Tuple<VerticalCamera, int>(this, 1);
            }
            // Y top boundary 
            if (y + 10 > yStart && y - 10 < yStart &&
                x >= xStart && x <= xEnd + 0x100)
            {
                return new Tuple<VerticalCamera, int>(this, 2);
            }
            // Y bottom boundary 
            if (y + 10 > yEnd + 0xe0 && y - 10 < yEnd + 0xe0 &&
                x >= xStart && x <= xEnd + 0x100)
            {
                return new Tuple<VerticalCamera, int>(this, 3);
            }

            return null;
        }

        public VerticalCamera IsMouseInCenter (int x, int y)
        {
            // Change Y to Ycursor
            y = GetReverseVerticalDisplacement(y);

            if (x > xStart + 0x10 && x < xEnd + 0xf0 &&
                y > yStart + 0x10 && y < yEnd + 0xd0)
                return this;

            return null;
        }
        public void RelativeMoveEntity (int dx, int dy)
        {
            xStart += dx;
            xEnd += dx;
            yStart += dy;
            yEnd += dy;
        }


    }
    public class VConnection
    {
        public string direction;
        // Index connected to
        public int connection;
        public bool relative;
        public bool hidden;
        public bool multiple;
        public int nextIndex;
        DKCLevel thisLevel;
        public int cameraIndex;

        public VConnection(string direction, int connection, bool relative, bool hidden, bool multiple, DKCLevel thisLevel)
        {
            this.thisLevel = thisLevel;
            this.direction = direction;
            this.connection = connection;
            this.relative = relative;
            this.hidden = hidden;
            this.multiple = multiple;
            if (relative)
            {
                nextIndex = connection & 0xf;
            }

        }

        public VConnection(int connection)
        {
            this.connection = connection;
            relative = true;
            hidden = false;
            multiple = false;
            SetConnection(connection);
        }
        public int GetConnection ()
        {
            int @return = 0;
            @return += VerticalCamera.directionLUT[direction];
            if (hidden)
                @return++;
            else if (multiple)
                @return += 2;
            @return <<= 4;
            if (relative)
            {
                @return |= nextIndex;
            }
            return @return;
        }
        public int GetSize()
        {
            int @return = 1;
            if (hidden)
                @return++;
            if (!relative)
                @return++;
            return @return;
        }
        public void SetConnection (int connection, int index = 0)
        {
            int temp = connection;
            temp >>= 4;
            switch (temp)
            {
                case 0:
                    direction = "L";
                    break;
                case 1:
                    direction = "L";
                    hidden = true;
                    break;
                case 2:
                    direction = "L";
                    multiple = true;
                    break;
                case 3:
                    direction = "R";
                    break;
                case 4:
                    direction = "R";
                    hidden = true;
                    break;
                case 5:
                    direction = "R";
                    multiple = true;
                    break;
                case 6:
                    direction = "U";
                    break;
                case 7:
                    direction = "U";
                    hidden = true;
                    break;
                case 8:
                    direction = "U";
                    multiple = true;
                    break;
                case 9:
                    direction = "D";
                    break;
                case 10:
                    direction = "D";
                    hidden = true;
                    break;
                case 11:
                    direction = "D";
                    multiple = true;
                    break;
                default:
                    break;
            }
            temp = (connection & 0xf);
            if (temp == 0)
            {
                relative = false;
                nextIndex = index;             
            }
            else
            {
                relative = true;
                nextIndex = temp;
            }


            this.connection = connection;
        }
        public override string ToString()
        {
            string rtn = direction + " ";
            if (hidden)
            {
                rtn += "Hidden ";
            }
            if (multiple)
                rtn += "Multiple ";
            if (relative)
                rtn += "Rel ";
            else
                rtn += "Abs ";
            return rtn + nextIndex.ToString("X2");
        }

    }
}
