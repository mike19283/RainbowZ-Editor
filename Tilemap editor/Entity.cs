using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Entity
    {
        public int type;
        public int x;
        public int y;
        public int pointer;
        public int address;
        public ROM rom;
        public static int counter = 0;
        public int local;
        int xLvlStart;
        int lvlCode;
        DKCLevel level;
        byte[] paramCountLut = new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 1, 2, 0, 3, 1, 1, 1 };
        public int palettePointer = 0;
        public int defaultAnim = 0;
        public int orientation = 0;
        List<Color> palette;
        public Bitmap sprite;
        bool vertical;
        public int layer = 0;
        public int x_displacement;
        public int y_displacement;
        public int numInLevel = 0;
        public int numInROM = 0;
        public int numInLevelType = 0;
        public int numInROMType = 0;
        int idCode;
        int _145d;
        int _14c5;
        int _ff5;
        int _fc1;
        int _1375;
        int _13e9;
        public int[] wram = new int[0x2000];

        public int width = 0;

        Dictionary<int, double> slope = new Dictionary<int, double>()
        {
            [0x0] = 270.0,
            [0x1] = 247.5,
            [0x2] = 225,
            [0x3] = 202.5,
            [0x4] = 180,
            [0x5] = 157.5,
            [0x6] = 135,
            [0x7] = 112.5,
            [0x8] = 90,
            [0x9] = 67.5,
            [0xa] = 45,
            [0xb] = 22.5,
            [0xc] = 0,
            [0xd] = 337.5,
            [0xe] = 315,
            [0xf] = 292.5,
        };
        Dictionary<int, int> xPositions = new Dictionary<int, int>()
        {
            [0x0] = 0,
            [0x1] = -4,
            [0x2] = -8,
            [0x3] = -12,
            [0x4] = -16,
            [0x5] = -12,
            [0x6] = -8,
            [0x7] = -4,
            [0x8] = 0,
            [0x9] = 4,
            [0xa] = 8,
            [0xb] = 12,
            [0xc] = 16,
            [0xd] = 12,
            [0xe] = 8,
            [0xf] = 4,
        };
        Dictionary<int, int> yPositions = new Dictionary<int, int>()
        {
            [0x0] = -16,
            [0x1] = -12,
            [0x2] = -8,
            [0x3] = -4,
            [0x4] = 0,
            [0x5] = 4,
            [0x6] = 8,
            [0x7] = 12,
            [0x8] = 16,
            [0x9] = 12,
            [0xa] = 8,
            [0xb] = 4,
            [0xc] = 0,
            [0xd] = -4,
            [0xe] = -8,
            [0xf] = -12,
        };


        public Entity(Int32 address, ROM rom, DKCLevel level)
        {
            this.level = level;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            lvlCode = level.levelCode;
            type = rom.Read16(address + 0);
            x = rom.Read16(address + 2);
            y = rom.Read16(address + 4);
            pointer = rom.Read16(address + 6);
            this.address = address;
            local = counter++;
            if (type == 1 || type == 0xf || type == 0xd || type == 0x11 || type == 0x12 || type == 0x2)
                ReadScript(pointer);
            if (palettePointer != 0 && defaultAnim != 0 && level.form.displayGFX)
                SetupGraphic();
            if (width == 0)
                width = FindWidth();


            //CountVariety();
        }
        public Entity(Int32 address, ROM rom, DKCLevel level, bool vertical, int layer)
        {
            this.vertical = vertical;
            this.layer = layer;
            this.level = level;
            xLvlStart = 0;
            this.rom = rom;
            lvlCode = level.levelCode;
            type = rom.Read16(address + 0);
            x = rom.Read16(address + 2);
            y = rom.Read16(address + 4);
            pointer = rom.Read16(address + 6);
            this.address = address;
            local = 1 + counter++;
            if (type == 1 || type == 0xf || type == 0xd || type == 0x11 || type == 0x12)
                ReadScript(pointer);
            if (palettePointer != 0 && defaultAnim != 0 && level.form.displayGFX)
                SetupGraphic();
            if (width == 0)
                width = FindWidth();

            var b = rom.objectIndexByCode;


        }
        public Entity ()
        {

        }
        public Bitmap DrawEntity (Bitmap bmp, Form form)
        {
            if (type == 1 || type == 0xf || type == 0xd || type == 0x11 || type == 0x12)
                ReadScript(pointer);
            if (palettePointer != 0 && defaultAnim != 0 && level.form.displayGFX)
                SetupGraphic();
            x_displacement = x - xLvlStart;
            var dispIndex = local;
            if (vertical)
            {
                y_displacement = GetVerticalDisplacement(y);
                dispIndex--;
            }
            else
            {
                y_displacement = y ^ 0x1ff;
                y_displacement++;
            }
            if (idCode == 0x38)
            {
                bmp = DrawCannonDirections(bmp);
                int d = _14c5 & 0xf0;
                d >>= 3;
                int directionGFX = rom.Read16((_145d & 4) > 0 ? 0xbed9ae + d : 0xbed9ce + d);
                if (palette != null)
                    sprite = rom.ReadFromSpriteHeader(directionGFX, palette);

            }


            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (sprite == null || !level.form.displayGFX)
                {
                    g.FillRectangle(new SolidBrush(Color.Black), x_displacement, y_displacement, 50, 50);
                    g.DrawRectangle(new Pen(Color.Red, 3), x_displacement, y_displacement, 50, 50);
                    g.DrawString(dispIndex.ToString("X"), form.Font, Brushes.White, x_displacement, y_displacement);
                    g.DrawString(pointer.ToString("X"), form.Font, Brushes.Red, x_displacement + 10, y_displacement + 10);
                }
                else
                {
                    g.DrawString(dispIndex.ToString("X"), form.Font, Brushes.White, x_displacement, y_displacement);

                    g.DrawImage(sprite, x_displacement - 0x80, y_displacement - 0x80);
                }

            }
            return bmp;
        }
        private Bitmap DrawCannonDirections(Bitmap bmp)
        {

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int inDirection = (_14c5 & 0xf0) >> 4;
                int outDirection = (_14c5 & 0xf000) >> 12;
                double inX = 5*xPositions[inDirection] + x_displacement;
                double inY = -5*yPositions[inDirection] + y_displacement;
                double outX = 5*xPositions[outDirection] + x_displacement;
                double outY = -5*yPositions[outDirection] + y_displacement;
                var inPen = new Pen(Color.Red, 4.0f);
                var outPen = new Pen(Color.Green, 2.0f);
                var slopePen = new Pen(Color.Gold, 1.0f);
                var inPoint = new Point((int)inX, (int)inY);
                var outPoint = new Point((int)outX, (int)outY);
                var origin = new Point(x_displacement, y_displacement);
                //g.DrawLine(inPen, origin, inPoint);
                g.DrawLine(outPen, origin, outPoint);
                double slope;
                try
                {
                    slope = (origin.Y - outY) / (origin.X - outX);
                }
                catch (Exception ex)
                {
                    slope = 0;
                }
                var distanceX = _ff5 * ((_fc1 & 0xff00) >> 8);
                var distanceY = slope * distanceX;
                Point distance = new Point(distanceX, (int)distanceY);
                try
                {
                    //g.DrawLine(slopePen, origin, distance);
                }
                catch { }
                // In line
                // Y intercept = 0

            }
            return bmp;
        }
        public override string ToString()
        {
            try
            {
                int index = rom.objectIndexByCode[pointer];
                if (!vertical)
                {
                    return $"{local.ToString("X")} - {rom.objectStringByIndex[index]}";
                }
                else
                {
                    return $"Layer - {layer}: {(local - 1).ToString("X")} - {rom.objectStringByIndex[index]}";
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return $"{local.ToString("X")} - {pointer.ToString("X")}. Unknown Object";
            }
        }
        private int GetNextHighestPower (int num)
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

        List<string> ReadScript(Int32 address)
        {
            try
            {
                address &= 0xffff;

                if (address > 0x8000)
                {
                    address |= 0x350000;
                }
                else
                {
                    //0xbbb154 - scripts start
                    int tempPointer = pointer * 4 + 8;
                    address = (int)rom.Read24(tempPointer + 0xbae09f);
                    //return new List<string>();
                }

                List<string> rtn = new List<string>();
                Stack<int> calls = new Stack<int>();


                string spaces = "";

                while (true)
                {
                    // Read command value
                    Int32 command = rom.Read16(ref address);

                    // What category is command?
                    if (command < 0x8000)
                    {
                        // Set array value
                        Int32 value = rom.Read16(ref address);
                        wram[command] = value;
                        if (command == 0xd45)
                        {
                            idCode = value;
                        }
                        if (command == 0x145d)
                        {
                            _145d = value;
                        }
                        if (command == 0x14c5)
                        {
                            _14c5 = value;
                        }
                        switch (command)
                        {
                            case 0xff5:
                                _ff5 = value;
                                break;
                            case 0xfc1:
                                _fc1 = value;
                                break;
                            case 0x1375:
                                _1375 = value;
                                break;
                            case 0x13e9:
                                _13e9 = value;
                                break;
                            default:
                                break;
                        }
                        rtn.Add(spaces + string.Format("[{0:x}] = {1:x}", command, value));
                    }
                    else
                    {
                        // Hard-coded call
                        command >>= 8;
                        UInt16[] values = new UInt16[paramCountLut[command - 0x80]];
                        for (int i = 0; i < values.Length; i++)
                        {
                            var v = rom.Read16(address);
                            values[i] = v;
                            switch (command)
                            {
                                case 0x81:
                                    defaultAnim = v;
                                    break;
                                case 0x88:
                                    palettePointer = v;
                                    break;
                                case 0x97:
                                    orientation = v;
                                    break;
                                default:
                                    break;
                            }
                        }

                        // Build a string
                        string txt = string.Format("{0:x} -> ", command);
                        for (int i = 0; i < values.Length; i++)
                        {
                            var value = rom.Read16(ref address);
                            txt += string.Format("{0:x} ", value);
                        }
                        // Command specific actions
                        switch (command)
                        {
                            case 0x80:
                                // Return
                                if (calls.Count <= 0)
                                {
                                    rtn.Add("==========");
                                    return rtn;
                                }

                                rtn.Add(Environment.NewLine);
                                address = calls.Pop();
                                spaces = new string(' ', calls.Count);
                                break;
                            case 0x82:
                                // Call
                                calls.Push(address);
                                address = values[0] + 0x350000;
                                spaces = new string(' ', calls.Count);
                                break;
                            default: rtn.Add(spaces + txt); break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                palettePointer = 0;
                defaultAnim = 0;
                orientation = 0;
                sprite = null;
                animation = null;
                return null;
            }
        }
        bool ReadScriptIsSameId(Int32 address, int id)
        {
            try
            {
                address &= 0xffff;

                if (address > 0x8000)
                {
                    address |= 0x350000;
                }
                else
                {
                    //0xbbb154 - scripts start
                    int tempPointer = pointer * 4;
                    address = (int)rom.Read24(tempPointer + 0xbbb154);
                    //return new List<string>();
                }

                Stack<int> calls = new Stack<int>();



                while (true)
                {
                    // Read command value
                    Int32 command = rom.Read16(ref address);

                    // What category is command?
                    if (command < 0x8000)
                    {
                        // Set array value
                        Int32 value = rom.Read16(ref address);
                        if (command == 0xd45)
                        {
                            return idCode == value;
                        }
                    }
                    else
                    {
                        // Hard-coded call
                        command >>= 8;

                        // Command specific actions
                        switch (command)
                        {
                            case 0x80:
                                // Return
                                if (calls.Count <= 0)
                                {
                                    return false;
                                }

                                address = calls.Pop();
                                break;
                            case 0x82:
                                // Call
                                calls.Push(address);
                                break;
                            default: break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void SetupGraphic ()
        {
            palette = rom.ReadPalette(0xbc0000 | palettePointer)[0];

            int index = GetSpriteIndex(1);
            try
            {
                sprite = rom.ReadFromSpriteHeader(index, palette);
                if ((orientation & 0x4000) > 0)
                {
                    sprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                if ((orientation & 0x8000) > 0)
                {
                    sprite.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }
            }
            catch
            {
                sprite = null;
                animation = null;
            }
        }
        int GetSpriteIndex (int index)
        {
            int animationArray = rom.Read16(0xbe8572 + defaultAnim * 2);
            int indexPtr = 0xbe0000 + animationArray + index;
            return rom.Read16(indexPtr);
        }
        public void WriteToROM()
        {

            if (rom.CheckSignature())
            {
                // 6f Kong entrance 
                if (wram[0xd45] == 0x6f && Global.bind1_1)
                {
                    Global.edit1_1 = false;
                    var entAddr = 0xbcbef0 + wram[0x1375] * 4;
                    rom.Write16(entAddr + 0, x);
                    rom.Write16(entAddr + 2, y);

                }
                // 4a save entrance
                if (idCode == 0x4a && Global.bindCheckpoints)
                {
                    Global.editCheckpoint = false;

                    // Entrance
                    // 3CBEF0
                    var entAddr = 0xbcbef0 + _1375 * 4;
                    rom.Write16(entAddr + 0, x);
                    rom.Write16(entAddr + 2, y);

                }
                if (wram[0xd45] == 0x58 && wram[0x100] == 0)
                {
                    int pAddress = 0xb60000 | wram[0x1375];
                    rom.Write16(pAddress + 4, x);
                    rom.Write16(pAddress + 6, y);
                }
            }
            address = (address & 0xffff) | (Global.mod ? 0x430000 : 0xbd0000);
            rom.Write16(address + 0, type);
            rom.Write16(address + 2, x);
            rom.Write16(address + 4, y);
            rom.Write16(address + 6, pointer);
            
        }
        public void SetEntity(Entity entity)
        {
            this.type = entity.type;
            this.x = entity.x;
            this.y = entity.y;
            this.pointer = entity.pointer;
        }
        public Entity IsMouseInBounds(int x, int y)
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
        public void CountVariety()
        {
            // Pointers [1, e0)
            for (int pointer = 1; pointer < 0xe5; pointer++)
            {
                string temp = rom.levelNameByCode[pointer];
                if (temp.Contains("from") || temp.Contains("warp"))
                {
                    continue;
                }

                int address = rom.Read16(0xbd8000 + pointer * 2) + 0xbd0000;
                

                while (rom.Read16(address) != 0)
                {
                    int scriptPointer = rom.Read16(address + 6);

                    if (scriptPointer == this.pointer && pointer == level.levelCode)
                    {
                        numInLevel++;
                        numInROM++;
                    }
                    else if (scriptPointer == this.pointer)
                    {
                        numInROM++;
                    }


                    address += 8;
                }

            }
        }
        public byte[] GetEntityAsBytes()
        {
            List<byte> @return = new List<byte>();
            WriteBytesToList(type, @return);
            WriteBytesToList(x, @return);
            WriteBytesToList(y, @return);
            WriteBytesToList(pointer, @return);
            return @return.ToArray();
        }
        private void WriteBytesToList(int num, List<byte> list)
        {
            list.Add((byte)(num >> 0));
            list.Add((byte)(num >> 8));
        }
        public int FindWidth()
        {
            int width = 0;
            if (sprite == null)
                return 0;

            return 0;

            // Loop through rotated image finding lefternmost
            var left = LeftEdge();
            width = left > -1 ? 0x80 - LeftEdge() : 0;
            return width;
        }
        private int LeftEdge()
        {
            for (int x = 0; x < sprite.Width; x++)
            {
                for (int y = 0; y < sprite.Height; y++)
                {
                    if (sprite.GetPixel(x,y) != Color.FromArgb(0,0,0,0))
                    {
                        return x;
                    }
                }
            }
            return -1;
        }
        public byte[] GetEntityBytes ()
        {
            List<byte> @return = new List<byte>();

            @return.Add((byte)(type >> 0));
            @return.Add((byte)(type >> 8));

            @return.Add((byte)(x >> 0));
            @return.Add((byte)(x >> 8));

            @return.Add((byte)(y >> 0));
            @return.Add((byte)(y >> 8));

            @return.Add((byte)(pointer >> 0));
            @return.Add((byte)(pointer >> 8));

            return @return.ToArray();
        }
    }
}
