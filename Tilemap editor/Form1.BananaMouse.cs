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
        Banana bananaMouse;
        Point startBanana;
        int bananaEditNum = 0;

        public void BananaMouseDown(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.bananas != null && radioButton_editBananas.Checked)
            {
                bananaMouse = null;
                if (e.Button == MouseButtons.Right)
                    return;
                bananaEditNum = 0;
                foreach (var banana in thisLevel.bananas)
                {
                    bananaMouse = banana.IsMouseInBounds(e.X, e.Y);
                    if (bananaMouse != null)
                    {
                        break;
                    }
                }
                if (bananaMouse == null)
                    return;

                startBanana = new Point(bananaMouse.x, bananaMouse.y);
                bananaEdit.SelectBanana(bananaMouse.local);
                startX = e.X;
                //startY = pictureBox_tilemap.Size.Height - e.Y;
                startY = e.Y;
                mouseDown = true;
                screenCopy = (Bitmap)pictureBox_tilemap.Image.Clone();
                Cursor.Current = Cursors.Hand;
                Cursor.Current = new Cursor("grab-cursor2.cur");
            }

        }
        public void BananaMouseLeave(object sender, EventArgs e)
        {
            if (thisLevel != null && thisLevel.bananas.Count > 0 && radioButton_editBananas.Checked)
            {
                bananaMouse = null;
                mouseDown = false;
            }

        }
        public void BananaMouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.bananas.Count > 0 && radioButton_editBananas.Checked)
            {
                if (!mouseDown)
                {
                    if (OverlappingHoverCheckBanana(e.X, e.Y))
                        Cursor.Current = Cursors.Hand;
                    else
                        Cursor.Current = Cursors.Default;


                }
                if (!CursorInBounds(e.X, e.Y))
                {
                    mouseDown = false;
                    return;
                }
                if (bananaMouse != null)
                {
                    if (mouseDown && e.Button != MouseButtons.Right)
                    {
                        int x = e.X, y = e.Y;
                        //int x = e.X, y = e.Y + 0x80;
                        int deltaX = x - startX;
                        int deltaY = y - startY;

                        int proposedX = startBanana.X + deltaX;
                        int proposedY = startBanana.Y + deltaY;
                        //bananaMouse.x = proposedX > 0 ? proposedX : 0;
                        //bananaMouse.y = proposedY > 0 ? proposedY : 0;
                        var dest = Global.MoveSnapPoint(startBanana.X, startBanana.Y, proposedX, proposedY, snapPrecision);
                        bananaMouse.x = dest.X;
                        bananaMouse.y = dest.Y;

                        label_end.Text = $"({bananaMouse.x.ToString("X")},{bananaMouse.y.ToString("X")})";

                        Bitmap tempCopy = (Bitmap)screenCopy.Clone();
                        Bitmap tempBmp = bananaMouse.DrawEntity(tempCopy, this);
                        SetImage(tempBmp);
                    }
                }
            }

        }
        public void BananaMouseUp(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.bananas.Count > 0 && radioButton_editBananas.Checked)
            {
                if (e.Button == MouseButtons.Right)
                    return;
                if (bananaMouse != null)
                {
                    bananaEdit.MoveEntity(bananaMouse.x, bananaMouse.y, snapToolStripMenuItem.Checked);
                    Cursor.Current = Cursors.Default;
                    bananaMouse = null;

                    mouseDown = false;
                    DrawScreen();

                }
            }

        }
        public bool OverlappingHoverCheckBanana(int x, int y)
        {
            bool overlapping = false;
            foreach (var banana in thisLevel.bananas)
            {
                if (banana.IsMouseInBounds(x, y) != null)
                {
                    overlapping = true;
                    break;
                }
            }
            return overlapping;
        }
    }
}
