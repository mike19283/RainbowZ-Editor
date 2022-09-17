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
        int waterOffset = 0xab8c;
        int slipslideOffset = 0xb35f;
        public int xStart;
        public int yStart;
        public int xEnd;
        public int yEnd;
        public int xSize;
        public int ySize;
        public int connectionType;
        public int address;
        public List<int> types = new List<int>();

        int offset;
        int pointer;
        int nextPointer;
        ROM rom;
        public int index;
        int xLvlStart;
        int lvlCode;
        DKCLevel level;

        public VerticalCamera(Int32 offset, ROM rom, DKCLevel level, int index, int pointer, int nextPointer)
        {
            //types.Add(new Func<int>(Function0));
            this.level = level;
            xLvlStart = (level.lvlXBoundStart & 0xffff);
            this.rom = rom;
            lvlCode = level.levelCode;

            this.index = index;
            this.pointer = pointer;
            this.nextPointer = nextPointer;
            int i = 0;
            var thisPointer = rom.Read16(pointer + offset + 0xb80000);
            address = 0xb80000 + thisPointer + offset;
            nextPointer = rom.Read16(nextPointer + offset + 0xb80000);
            this.offset = offset;

            xStart = rom.Read16(address + 0);
            yStart = rom.Read16(address + 3);
            xEnd = rom.Read8(address + 2) * 4 + xStart;
            yEnd = rom.Read8(address + 5) * 4 + yStart;
            xSize = (xEnd - xStart) / 4;
            ySize = (yEnd - yStart) / 4;

            for (int z = thisPointer + 6 + offset; z < nextPointer + offset; z++)
            {
                types.Add(rom.Read8(0xb80000 + z));
            }



            //GameSetup();
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

                g.DrawString(index.ToString("X"), form.Font, Brushes.Black, x_displacement + 10, GetVerticalDisplacement(yStart) + 10);

            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{index.ToString("X")}: (xStart,xEnd,yStart,yEnd) ({xStart.ToString("X")}, {xEnd.ToString("X")}, {yStart.ToString("X")}, {yEnd.ToString("X")}) - Address = {address.ToString("X")}";
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
        public void WriteCamToROM()
        {
            //return;

            //int i = 0;
            xSize = (xEnd - xStart) / 4;
            ySize = (yEnd - yStart) / 4;
            rom.Write16(address + 0, xStart);
            rom.Write8(address + 2, xSize);
            rom.Write16(address + 3, yStart);
            rom.Write8(address + 5, ySize);

            int i = 6;
            foreach (var @type in types)
            {
                rom.Write8(address + i++, type);
            }

            ////rom.Write(address + i++, x);
            ////rom.Write16(address + 6, connectionType);
        }



    }
}
