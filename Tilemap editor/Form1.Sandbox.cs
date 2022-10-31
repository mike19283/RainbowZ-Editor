using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Form1
    {
        bool mouseDown;
        int[,] tempTilemap;
        public List<List<int>> highlightedTilemap;
        public List<List<int>> copiedTilemap;
        public int startX, startY;
        private int lastXH = 0, lastYH = 0;
        public Bitmap pastedImg;
        Bitmap ogImage;
        public List<CopyHistory> hist = new List<CopyHistory>();

        private void pictureBox_tilemap_MouseDown(object sender, MouseEventArgs e)
        {

            if (thisLevel == null)
                return;
            if (thisLevel.te.scanned)
            {
                return;
            }

            if (radioButton_editterrain.Checked)
            {
                undoTilemap[stage].Push((int[,])thisLevel.tilemap.Clone());
                switch (thisLevel.te.selectionMode)
                {
                    case 0:
                        Regular(e);
                        break;
                    case 1:
                        tempTilemap = thisLevel.TilemapDeepCopy();
                        mouseDown = true;
                        startX = e.X / 32;
                        startY = e.Y / 32;
                        break;
                    case 2:
                        if (e.Button == MouseButtons.Left)
                        {
                            mouseDown = true;
                            startX = e.X / 32;
                            startY = e.Y / 32;
                            DrawScreen();
                            ogImage = (Bitmap)pictureBox_tilemap.Image.Clone();
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            Stamp(e);
                        }
                        break;
                    case 3:
                        if (thisLevel.te.highlightOrPaste == "highlight")
                        {
                            tempTilemap = thisLevel.TilemapDeepCopy();

                            mouseDown = true;
                            startX = e.X / 32;
                            startY = e.Y / 32;
                            startX *= 32;
                            startY *= 32;
                            DrawScreen();
                            ogImage = (Bitmap)pictureBox_tilemap.Image.Clone();
                        }
                        else
                        {
                            if (copiedTilemap == null)
                            {
                                DrawScreen();
                                return;
                            }
                            if (e.Button == MouseButtons.Left)
                            {
                                mouseDown = true;
                                startX = e.X / 32;
                                startY = e.Y / 32;
                                startX *= 32;
                                startY *= 32;
                                DrawScreen();
                                ogImage = (Bitmap)pictureBox_tilemap.Image.Clone();
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                mouseDown = false;
                                startX = e.X / 32;
                                startY = e.Y / 32;


                                WriteCopiedTilemap();

                                DrawScreen();
                            }

                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void pictureBox_tilemap_MouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel == null)
                return;
            if (radioButton_editterrain.Checked)
            {
                switch (thisLevel.te.selectionMode)
                {
                    case 0:
                        break;
                    case 1:
                        if (thisLevel == null)
                            return;
                        if (thisLevel.te.selectionMode == 0)
                            return;
                        if (!mouseDown)
                            return;
                        tempTilemap = thisLevel.TilemapDeepCopy();
                        int currentX = e.X / 32;
                        int dif = currentX - startX;
                        if (dif > 0)
                        {
                            int pos = 0;
                            var select = thisLevel.te;
                            // Draw first tile
                            tempTilemap[startX + pos++, startY] = select.leftIndex;

                            int times = dif - 1;
                            for (int i = 0; i < times; i++)
                            {
                                // Mod to always select a valid index
                                var ind = i % select.midIndices.Count;
                                // Copy all middle
                                tempTilemap[startX + pos++, startY] = select.midIndices[ind];
                            }

                            // Draw last tile
                            tempTilemap[startX + pos++, startY] = select.rightIndex;
                        }


                        pictureBox_tilemap.Image.Dispose();
                        pictureBox_tilemap.Image = thisLevel.ReDrawGivenTilemap(checkBox_grid.Checked, tempTilemap);
                        break;
                    case 2:
                        if (!mouseDown)
                            return;
                        // Fixes scope issue
                        if (true)
                        {
                            //Bitmap bmp;
                            //bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
                            pictureBox_tilemap.Image.Dispose();
                            var bmp = (Bitmap)ogImage.Clone();
                            startX = e.X / 32;
                            startY = e.Y / 32;
                            startX *= 32;
                            startY *= 32;
                            Graphics g = Graphics.FromImage(bmp);
                            g.DrawImage(thisLevel.te.stampImg, startX, startY);
                            g.DrawRectangle(new Pen(Color.White), startX, startY, 160, 160);
                            g.Dispose();
                            pictureBox_tilemap.Image = bmp;
                        }


                        break;
                    case 3:
                        if (!mouseDown)
                            return;
                        if (thisLevel.te.highlightOrPaste == "highlight")
                        {
                            //Bitmap bmp;
                            //bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
                            int x = e.X / 32, y = e.Y / 32;
                            if (lastXH == x && lastYH == y)
                            {

                                return;
                            }
                            lastYH = y;
                            lastXH = x;

                            pictureBox_tilemap.Image.Dispose();
                            var bmp = (Bitmap)ogImage.Clone();
                            x *= 32;
                            y *= 32;
                            bmp = DrawCopy(bmp, x, y);
                            pictureBox_tilemap.Image = bmp;
                        }
                        else
                        {
                            if (pastedImg == null)
                            {
                                return;
                            }
                            //Bitmap bmp;
                            //bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
                            pictureBox_tilemap.Image.Dispose();
                            var bmp = (Bitmap)ogImage.Clone();
                            startX = e.X / 32;
                            startY = e.Y / 32;
                            startX *= 32;
                            startY *= 32;
                            Graphics g = Graphics.FromImage(bmp);
                            g.DrawImage(pastedImg, startX, startY);
                            g.Dispose();
                            pictureBox_tilemap.Image = bmp;

                        }
                        break;

                    default:
                        break;
                }
            }

        }

        private void pictureBox_tilemap_MouseUp(object sender, MouseEventArgs e)
        {

            if (thisLevel == null)
                return;
            if (thisLevel.te.scanned)
            {
                return;
            }

            if (radioButton_editterrain.Checked)
            {
                switch (thisLevel.te.selectionMode)
                {
                    case 0:
                        break;
                    case 1:
                        if (thisLevel.te.selectionMode == 0)
                            return;
                        if (mouseDown)
                        {
                            //thisLevel.tilemap = tempTilemap.Clone() as int[,];
                            thisLevel.tilemap = tempTilemap;
                            mouseDown = false;

                            DrawScreen();

                        }
                        break;
                    case 2:
                        mouseDown = false;
                        //DrawScreen();
                        return;
                    case 3:
                        if (thisLevel.te.selectionMode == 0)
                            return;
                        if (mouseDown)
                        {

                            if (thisLevel.te.highlightOrPaste == "highlight")
                            {

                                Bitmap bmp;
                                bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
                                int x = e.X / 32, y = e.Y / 32;
                                x *= 32;
                                y *= 32;
                                var maxX = thisLevel.tilemap.GetLength(0) * 32;
                                var maxY = thisLevel.tilemap.GetLength(1) * 32;
                                if (x >= maxX)
                                    x = maxX;
                                if (y >= maxY)
                                    y = maxY;
                                if (x < 0)
                                    x = 0;
                                if (y < 0)
                                    y = 0;
                                if (x < startX)
                                {
                                    startX ^= x;
                                    x ^= startX;
                                    startX ^= x;
                                }
                                if (y < startY)
                                {
                                    startY ^= y;
                                    y ^= startY;
                                    startY ^= y;
                                }


                                highlightedTilemap = GetHighlightedTilemap(x, y);

                                bmp = DrawCopy(bmp, x, y);
                                pictureBox_tilemap.Image = bmp;
                            }
                            else
                            {
                                mouseDown = false;
                                //DrawScreen();
                                return;

                            }

                            //thisLevel.tilemap = tempTilemap.Clone() as int[,];
                            mouseDown = false;


                        }
                        break;
                    default:
                        DrawScreen();
                        break;
                }
            }
        }

        private void pictureBox_tilemap_MouseLeave(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;
            if (radioButton_editterrain.Checked)
            {
                switch (thisLevel.te.selectionMode)
                {
                    case 0:
                        break;
                    case 1:

                        if (thisLevel == null)
                            return;
                        if (thisLevel.te.selectionMode == 0)
                            return;
                        mouseDown = false;
                        DrawScreen();
                        break;
                    case 3:

                        if (thisLevel == null)
                            return;
                        if (thisLevel.te.selectionMode == 0)
                            return;
                        mouseDown = false;
                        //DrawScreen();
                        break;
                    default:
                        break;
                }
            }


        }

        private void Regular (MouseEventArgs e)
        {
            int x = e.X / 32, y = e.Y / 32;
            int selection = thisLevel.te.selectedTileIndex;
            thisLevel.tilemap[x, y] = selection;

            DrawScreen();
        }
        private void Stamp (MouseEventArgs e)
        {
            startX = e.X / 32;
            startY = e.Y / 32;

            // Loop through whole stamp
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    try
                    {
                        var pointer = thisLevel.te.stamp[x][y];
                        if (pointer == 0)
                            continue;

                        thisLevel.tilemap[startX + x, startY + y] = pointer;
                        
                    }
                    catch { }
                }
            }
            DrawScreen();

        }
        private bool DrawMode ()
        {
            return checkBox_viewEntrances.Checked || checkBox_viewEntities.Checked ||
                checkBox_viewCam.Checked || checkBox_viewBananas.Checked;
        }

        private Bitmap DrawCopy(Bitmap bmp, int endX, int endY)
        {
            int lowX = startX,
                lowY = startY,
                highX = endX,
                highY = endY;
            if (lowX > highX)
            {
                lowX = endX;
                highX = startX;
            }
            if (lowY > highY)
            {
                lowY = endY;
                highY = startY;
            }
            int difX = highX - lowX, difY = highY - lowY;

            try
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(128, 128, 255, 255)), lowX, lowY, difX, difY);
                    g.DrawRectangle(new Pen(Color.Black), lowX, lowY, difX, difY);

                }
            }
            catch
            {

            }
            

            return bmp;
        }
        private Bitmap DrawCopyFast(Bitmap bmp, int endX, int endY)
        {
            int lowX = startX,
                lowY = startY,
                highX = endX,
                highY = endY;
            if (lowX > highX)
            {
                lowX = endX;
                highX = startX;
            }
            if (lowY > highY)
            {
                lowY = endY;
                highY = startY;
            }
            int difX = highX - lowX, difY = highY - lowY;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, 128, 255, 255)), lowX, lowY, difX, difY);
                g.DrawRectangle(new Pen(Color.Black), lowX, lowY, difX, difY);

            }

            return bmp;
        }

        private List<List<int>> GetHighlightedTilemap(int endX, int endY)
        {
            int i = 0;
            List<List<int>> @return = new List<List<int>>();
            for (int y = startY / 32; y < endY / 32; y++)
            {
                @return.Add(new List<int>());
                for (int x = startX / 32; x < endX / 32; x++)
                {
                    var toAdd = thisLevel.tilemap[x, y];
                    @return[i].Add(toAdd);
                }
                i++;

            }

            return @return;
        }
        private void WriteCopiedTilemap()
        {
            if (copiedTilemap.Count == 0)
                return;
            int copyX = copiedTilemap[0].Count;
            int copyY = copiedTilemap.Count;
            if (startY + copyY > thisLevel.tilemap.GetLength(1))
            {
                copyY = thisLevel.tilemap.GetLength(1) - startY;                
            }
            if (startX + copyX > thisLevel.tilemap.GetLength(0))
            {
                copyX = thisLevel.tilemap.GetLength(0) - startX;
            }
            int localStartY = startY < 0 ? startY * -1 : 0;
            int localStartX = startX < 0 ? startX * -1 : 0;

            // Loop through copied
            for (int y = localStartY; y < copyY; y++)
            {
                for (int x = localStartX; x < copyX; x++)
                {
                    var val = copiedTilemap[y][x];
                    thisLevel.tilemap[startX + x, startY + y] = val;
                }
            }
        }
        private void CursorMove (object sender, MouseEventArgs e)
        {
            if (thisLevel == null)
                return;
            if (pictureBox_tilemap.Image == null)
                return;
            //var topOG = thisLevel.theme & 0xffff;
            //var topOfLevel = thisLevel.tilemapOffset & 0xffff;
            //var dif = (topOfLevel / 4 - topOG / 4);

            string strX = Global.HexToString(e.X + (thisLevel.lvlXBoundStart & 0xffff));
            string strY = Global.HexToString(GetVerticalDisplacement(e.Y));
            label_cursor.Text = $"({strX},{strY})";
            label_camera.Text = $"({strX},{Global.HexToString(e.Y)})";
        }

        public int GetVerticalDisplacement(int y)
        {
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                return 0x200 - y;
            }
            int displacement = 0;
            // Top of image
            var topOG = thisLevel.theme & 0xffff;
            var topOfLevel = thisLevel.tilemapOffset & 0xffff;
            var dif = (topOfLevel / 4 - topOG / 4);
            var posInWhole = 0x7000 - y;
            displacement = posInWhole - dif;

            return displacement;
        }


    }
}
