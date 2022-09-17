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
        int autotileIndex = 1000;
        int lastX, lastY;

        public void AF_MouseClick (object sender, MouseEventArgs e)
        {
            if (thisLevel == null || pictureBox_tilemap.Image == null || thisLevel.te.autofill != "autofill")
                return;
            //if (!thisLevel.te.scanned)
            //{
            //    return;
            //}
            if (thisLevel.linkDict == null)
            {
                return;
            }
            int x = e.X / 32;
            int y = e.Y / 32;

            if (x != lastX && y != lastY)
            {
                lastX = x;
                lastY = y;
                autotileIndex = thisLevel.linkDict.Count * 1000;
            }

            // Get current tile to see if it is even valid
            int current = thisLevel.tilemap[x, y];

            undoTilemap[stage].Push((int[,])thisLevel.tilemap.Clone());


            int xMod = 0, yMod = 0;
            int direction = thisLevel.te.autoUDLR;
            switch (direction)
            {
                case 0:
                    yMod = -1;
                    break;
                case 1:
                    yMod = 1;
                    break;
                case 2:
                    xMod = -1;
                    break;
                case 3:
                    xMod = 1;
                    break;
                default:
                    break;
            }

            var possibleTiles = thisLevel.linkDict[current][direction];

            try
            {
                var index = autotileIndex % possibleTiles.Count;
                int placedTile = possibleTiles[index];

                if (e.Button == MouseButtons.Right)
                    autotileIndex--;
                else
                    autotileIndex++;
                index = autotileIndex % possibleTiles.Count;
                label_autoCurrentIndex.Text = $"{Global.HexToString(index + 1)} / {Global.HexToString(possibleTiles.Count)}";
                thisLevel.tilemap[x + xMod, y + yMod] = placedTile;

                Bitmap bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
                PictureboxSetter(bmp);
            }
            catch
            {
                MessageBox.Show("Error");
            }

            //pictureBox_tilemap.Image = bmp;


        }
        public Bitmap DrawLinks(Bitmap bmp)
        {
            //Graphics g = Graphics.FromImage(bmp);
            //var tm = thisLevel.tilemap;
            //int width = tm.GetLength(0);
            //int height = tm.GetLength(1);
            //var allLinks = thisLevel.linksRead;
            //for (int y = 0; y < height; y++)
            //{
            //    for (int x = 0; x < width; x++)
            //    {
            //        var tile = tm[x, y];
            //        // Save/Take out flips
            //        int flips = tile & 0xc000;
            //        tile &= 0x3fff;
            //        bool linkU;
            //        bool linkD;
            //        if (y == 0)
            //        {
            //            linkU = true;
            //            linkD = true;
            //        }
            //        else if (y == tm.GetLength(1) - 1)
            //        {
            //            linkU = true;
            //            linkD = true;

            //        }
            //        else
            //        {
            //            linkU = allLinks[0, tile, tm[x, y - 1] & 0x3fff];
            //            linkD = allLinks[1, tile, tm[x, y + 1] & 0x3fff];
            //        }
            //        bool linkL;
            //        bool linkR;
            //        if (x == 0)
            //        {
            //            linkL = true;
            //            linkR = true;
            //        }
            //        else if (x == tm.GetLength(0) - 1)
            //        {
            //            linkL = true;
            //            linkR = true;

            //        }
            //        else
            //        {
            //            linkL = allLinks[2, tile, tm[x - 1, y] & 0x3fff];
            //            linkR = allLinks[3, tile, tm[x + 1, y] & 0x3fff];
            //        }
            //        Point coords = new Point(x * 0x20, y * 0x20);
                    
            //        if (!linkU)
            //        {
            //            g.DrawLine(new Pen(Color.Red, 2), coords.X, coords.Y, coords.X + 0x20, coords.Y);                        
            //        }
            //        if (!linkD)
            //        {
            //            g.DrawLine(new Pen(Color.Red, 2), coords.X, coords.Y + 0x20, coords.X + 0x20, coords.Y + 0x20);                        
            //        }
            //        if (!linkL)
            //        {
            //            g.DrawLine(new Pen(Color.Red, 2), coords.X, coords.Y, coords.X, coords.Y + 0x20);                        
            //        }
            //        if (!linkR)
            //        {
            //            g.DrawLine(new Pen(Color.Red, 2), coords.X + 0x20, coords.Y, coords.X + 0x20, coords.Y + 0x20);                        
            //        }
            //    }
            //}

            //g.Dispose();
            return bmp;
        }
        public void PictureboxSetter(Bitmap bmp)
        {
            if (pictureBox_tilemap.Image != null)
                pictureBox_tilemap.Image.Dispose();

            pictureBox_tilemap.Size = bmp.Size;
            pictureBox_tilemap.Image = bmp;

        }
    }
}
