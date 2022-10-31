using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class Form1
    {
        public int autoWaterSize = 1;
        public List<List<int>> waterPaste;
        int startWaterY;
        int startWaterX;
        bool waterMouseDown = false;
        int waterTimer = 100;

        public void WaterMouseDown(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.te.selectionMode != 5 || !radioButton_editterrain.Checked || !rom.IsWater(thisLevel.levelCode))
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
                return;
            startWaterX = e.X;
            startWaterY = e.Y;
            startX = startWaterX / 0x20;
            startY = startWaterY / 0x20;
            waterMouseDown = true;
            waterTimer = 20;

            undoTilemap[stage].Push((int[,])thisLevel.tilemap.Clone());

            Cursor.Current = Cursors.SizeAll;
        }


        public void WaterMouseLeave(object sender, EventArgs e)
        {
            waterMouseDown = false;
            Cursor.Current = Cursors.Default;
        }
        public void WaterMouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.te.selectionMode != 5 || !radioButton_editterrain.Checked || !rom.IsWater(thisLevel.levelCode))
            {
                return;
            }
            if (waterMouseDown)
            {
                if (waterTimer-- == 0)
                {
                    waterTimer = 20;
                    tempTilemap = thisLevel.TilemapDeepCopy();
                    int difX = Math.Abs(((int)(e.X / 0x20)) - ((int)(startWaterX / 0x20)));
                    int difY = Math.Abs(((int)(e.Y / 0x20)) - ((int)(startWaterY / 0x20)));
                    if (difX > difY)
                    {
                        difX /= 3;
                        // W-E
                        waterPaste = ConstructHorizontalWater(difX);
                        Cursor.Current = Cursors.SizeWE;
                    }
                    else
                    {
                        difY /= 3;
                        // N-S
                        waterPaste = ConstructVerticalWater(difY);
                        Cursor.Current = Cursors.SizeNS;
                    }
                    WriteToTemp(new Point(startX, startY), waterPaste);
                    pictureBox_tilemap.Image.Dispose();
                    pictureBox_tilemap.Image = thisLevel.ReDrawGivenTilemap(checkBox_grid.Checked, tempTilemap);
                }
            }
        }

        public void WaterMouseUp(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.te.selectionMode != 5 || !radioButton_editterrain.Checked || !rom.IsWater(thisLevel.levelCode))
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
                return;
            if (waterMouseDown)
            {
                int difX = Math.Abs(((int)(e.X / 0x20)) - ((int)(startWaterX / 0x20)));
                int difY = Math.Abs(((int)(e.Y / 0x20)) - ((int)(startWaterY / 0x20)));
                if (difX > difY)
                {
                    difX /= 3;
                    // W-E
                    waterPaste = ConstructHorizontalWater(difX);
                    copiedTilemap = waterPaste;
                    thisLevel.tilemap = tempTilemap;
                    //WriteCopiedTilemap();

                }
                else
                {
                    if (difY > 0)
                    {
                        difY /= 3;
                        // N-S
                        waterPaste = ConstructVerticalWater(difY);
                        copiedTilemap = waterPaste;
                        WriteCopiedTilemap();
                    }
                }


                Cursor.Current = Cursors.Default;
                waterMouseDown = false;
            }

            DrawScreen();
        }

        private List<List<int>> ConstructVerticalWater(int times)
        {
            List<List<int>> @return = new List<List<int>>();
            int height = times * 3;
            int width = autoWaterSize + 4;
            for (int i = 0; i < height; i++)
            {
                var arr = new int[width];
                @return.Add(arr.ToList());
            }
            for (int i = 0; i < times; i++)
            {
                int col = i * 3;
                // Row 1
                @return[col + 0][0] = 0x00cb;
                @return[col + 0][1] = 0x400a;
                @return[col + 0][2 + autoWaterSize] = 0x000a;
                @return[col + 0][3 + autoWaterSize] = 0x40cb;

                // Row 2
                @return[col + 1][0] = 0x0008;
                @return[col + 1][1] = 0x0009;
                @return[col + 1][2 + autoWaterSize] = 0x4009;
                @return[col + 1][3 + autoWaterSize] = 0x4008;

                // Row 3
                @return[col + 2][0] = 0x0001;
                @return[col + 2][1] = 0x0013;
                @return[col + 2][2 + autoWaterSize] = 0x4013;
                @return[col + 2][3 + autoWaterSize] = 0x4001;

            }
            return @return;
        }

        private List<List<int>> ConstructHorizontalWater(int times)
        {
            int height = autoWaterSize + 4;
            int width = 3 * times;
            List<List<int>> @return = new List<List<int>>();
            for (int i = 0; i < height; i++)
            {
                var arr = new int[width];
                @return.Add(arr.ToList());
            }
            for (int i = 0; i < times; i++)
            {
                int row = 0;
                int leftIndex = i * 3;
                @return[row][leftIndex + 0] = 0x802b;
                @return[row][leftIndex + 1] = 0x802c;
                @return[row][leftIndex + 2] = 0x802d;
                row++;
                @return[row][leftIndex + 0] = 0xc0f5;
                @return[row][leftIndex + 1] = 0x0000;
                @return[row][leftIndex + 2] = 0x80f1;
                row++;
                // Skip blanks
                int t = autoWaterSize;
                while (t-- > 0)
                {
                    row++;
                }

                @return[row][leftIndex + 0] = 0x40f5;
                @return[row][leftIndex + 1] = 0x0000;
                @return[row][leftIndex + 2] = 0x00f1;
                row++;
                @return[row][leftIndex + 0] = 0x002b;
                @return[row][leftIndex + 1] = 0x002c;
                @return[row][leftIndex + 2] = 0x002d;
                row++;


            }

            return @return;
        }
        private int[,] WriteToTemp (Point point, List<List<int>> toCopy)
        {
            for (int y = point.Y, yi = 0; yi < toCopy.Count && y < tempTilemap.GetLength(1); y++, yi++)
            {
                for (int x = point.X, xi = 0; xi < toCopy[0].Count && x < tempTilemap.GetLength(0); x++, xi++)
                {
                    tempTilemap[x, y] = toCopy[yi][xi];
                }
            }
            return tempTilemap;
        }
    }
}
