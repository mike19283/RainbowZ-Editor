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
        PlatformPath pathMouse;
        Point startPath;
        int pathEditNum = 0;

        public void PathMouseDown (object sender, MouseEventArgs e)
        {
            pathEditNum = 0;
            if (thisLevel != null && thisLevel.platformPaths.Count > 0 && radioButton_editPaths.Checked)
            {
                pathMouse = null;
                if (e.Button == MouseButtons.Right)
                    return;
                foreach (var group in thisLevel.platformPaths)
                {
                    foreach (var path in group)
                    {
                        pathMouse = path.IsMouseInBounds(e.X, e.Y);
                        if (pathMouse != null)
                        {
                            break;
                        }
                    }
                    if (pathMouse != null)
                    {
                        break;
                    }
                    pathEditNum++;
                }
                if (pathMouse == null)
                    return;

                var tempPath = pathEdits[pathEditNum];
                tempPath.TopMost = true;
                tempPath.TopMost = false;
                startPath = new Point(pathMouse.x, pathMouse.y);
                tempPath.SelectPath(pathMouse.index);
                startX = e.X;
                startY = pictureBox_tilemap.Size.Height - e.Y;
                mouseDown = true;
                Cursor.Current = Cursors.Hand;
                Cursor.Current = new Cursor("grab-cursor2.cur");
            }

        }
        public void PathMouseLeave (object sender, EventArgs e)
        {
            if (thisLevel != null && thisLevel.platformPaths.Count > 0 && radioButton_editPaths.Checked)
            {
                pathMouse = null;
                pathEditNum = 0;
                mouseDown = false;
            }

        }
        public void PathMouseMove (object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.platformPaths.Count > 0 && radioButton_editPaths.Checked)
            {
                if (!mouseDown)
                {
                    if (OverlappingHoverCheckPath(e.X,e.Y))
                        Cursor.Current = Cursors.Hand;
                    else
                        Cursor.Current = Cursors.Default;


                }
                if (!CursorInBounds(e.X, e.Y))
                {
                    mouseDown = false;
                    return;
                }

                if (pathMouse != null)
                {
                    if (mouseDown && e.Button != MouseButtons.Right)
                    {
                        int x = e.X, y = pictureBox_tilemap.Size.Height - e.Y;
                        //int x = e.X, y = e.Y + 0x80;
                        int deltaX = x - startX;
                        int deltaY = y - startY;

                        int proposedX = startPath.X + deltaX;
                        pathMouse.x = proposedX > 0 ? proposedX : 0;
                        int proposedY = startPath.Y + deltaY;
                        pathMouse.y = proposedY > 0 ? proposedY : 0;

                        label_end.Text = $"({pathMouse.x.ToString("X")},{pathMouse.y.ToString("X")})";
                    }
                }
            }

        }
        public void PathMouseUp (object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.platformPaths.Count > 0 && radioButton_editPaths.Checked)
            {
                if (e.Button == MouseButtons.Right)
                    return;
                if (pathMouse != null)
                {
                    pathEdits[pathEditNum].MoveEntity(pathMouse.x, pathMouse.y, snapToolStripMenuItem.Checked);
                    Cursor.Current = Cursors.Default;

                    mouseDown = false;
                    pathEdits[pathEditNum].RefreshMouseListbox();
                    DrawScreen();

                }
            }

        }
        public bool OverlappingHoverCheckPath(int x, int y)
        {
            bool overlapping = false;
            foreach (var group in thisLevel.platformPaths)
            {
                foreach (var path in group)
                {
                    if (path.IsMouseInBounds(x, y) != null)
                    {
                        overlapping = true;
                        break;
                    }
                }
                if (overlapping)
                    break;
            }
            return overlapping;
        }



    }
}
