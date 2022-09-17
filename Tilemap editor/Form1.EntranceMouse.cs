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
        Entrance EntranceMouse;
        Point startEntrancePoint;

        public void EntranceMouseDown(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.entrances == null || !radioButton_editEntrances.Checked)
            {
                return;
            }
            EntranceMouse = null;
            if (e.Button == MouseButtons.Right)
                return;
            foreach (var Entrance in thisLevel.entrances)
            {
                var temp = Entrance.IsMouseInBounds(e.X, e.Y);
                if (temp != null)
                {
                    EntranceMouse = temp;
                    break;
                }
            }
            if (EntranceMouse == null)
                return;
            entranceEdit.SelectEntrance(EntranceMouse);
            startEntrancePoint = new Point(e.X, e.Y);
            Cursor.Current = new Cursor("grab-cursor2.cur");

        }
        public void EntranceMouseLeave(object sender, EventArgs e)
        {
            EntranceMouse = null;
            Cursor.Current = Cursors.Default;
        }
        public void EntranceMouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.entrances.Count > 0 && radioButton_editEntrances.Checked)
            {
                if (EntranceMouse == null)
                {
                    EntranceHoverIcon(e);
                }
                if (!CursorInBounds(e.X, e.Y))
                {
                    return;
                }
            }

        }

        private void EntranceHoverIcon(MouseEventArgs e)
        {
            if (OverlappingHoverCheckEntrance(e.X, e.Y))
            {
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void EntranceMouseUp(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.entrances.Count > 0 && radioButton_editEntrances.Checked)
            {
                if (e.Button == MouseButtons.Right)
                    return;
                if (EntranceMouse != null)
                {
                    int difX = e.X - startEntrancePoint.X,
                        difY = e.Y - startEntrancePoint.Y;
                    entranceEdit.MoveEntity(difX, difY * -1);
                    Cursor.Current = Cursors.Default;
                    EntranceMouse = null;

                    DrawScreen();

                }
            }

        }
        public bool OverlappingHoverCheckEntrance(int x, int y)
        {
            foreach (var entrance in thisLevel.entrances)
            {
                var temp = entrance.IsMouseInBounds(x, y);
                if (temp != null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
