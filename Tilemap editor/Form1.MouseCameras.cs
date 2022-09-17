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
        Camera CameraMouse;
        int startCameraY;
        string cameraSection;
        int startCameraX;

        public void CameraMouseDown(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.cameraBoxes == null || !radioButton_editCameras.Checked)
            {
                return;
            }
            CameraMouse = null;
            if (e.Button == MouseButtons.Right)
                return;
            foreach (var Camera in thisLevel.cameraBoxes)
            {
                cameraSection = "";
                var tempTup = Camera.IsMouseInBounds(e.X, e.Y);
                if (tempTup != null)
                {
                    CameraMouse = tempTup.Item1;
                    cameraSection = tempTup.Item2;
                    break;
                }
            }
            if (CameraMouse == null)
                return;
            cameraEdit.SelectCamera(CameraMouse);
            switch (cameraSection)
            {
                case "x":
                    startCameraX = e.X;
                    break;
                case "yT":
                case "yB":
                    startCameraY = e.Y;
                    break;
                default:
                    break;
            }
            Cursor.Current = new Cursor("grab-cursor2.cur");
            //    startCamera = new Point(CameraMouse.x, CameraMouse.y);
            //    CameraEdit.SelectCamera(CameraMouse.local);
            //    startX = e.X;
            //    //startY = pictureBox_tilemap.Size.Height - e.Y;
            //    startY = e.Y;
            //    mouseDown = true;
            //    Cursor.Current = Cursors.Hand;
            //}

        }
        public void CameraMouseLeave(object sender, EventArgs e)
        {
            CameraMouse = null;
            Cursor.Current = Cursors.Default;
            //if (thisLevel != null && thisLevel.Cameras.Count > 0 && radioButton_editCameras.Checked)
            //{
            //    CameraMouse = null;
            //    mouseDown = false;
            //}

        }
        public void CameraMouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.cameraBoxes.Count > 0 && radioButton_editCameras.Checked)
            {
                if (CameraMouse == null)
                {
                    CameraHoverIcon(e);
                }
                if (!CursorInBounds(e.X, e.Y))
                {
                    return;
                }
            }

        }

        private void CameraHoverIcon(MouseEventArgs e)
        {
            switch (OverlappingHoverCheckCamera(e.X, e.Y))
            {
                case "x":
                    Cursor.Current = Cursors.SizeWE;
                    break;
                case "yT":
                case "yB":
                    Cursor.Current = Cursors.SizeNS;
                    break;
                default:
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        public void CameraMouseUp(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.cameraBoxes.Count > 0 && radioButton_editCameras.Checked)
            {
                if (e.Button == MouseButtons.Right)
                    return;
                if (CameraMouse != null)
                {
                    switch (cameraSection)
                    {
                        case "x":
                            int difX = e.X - startCameraX;
                            cameraEdit.MoveEntity(difX, cameraSection);
                            break;
                        case "yT":
                            int difYT = e.Y - startCameraY;
                            cameraEdit.MoveEntity(difYT, cameraSection);
                            break;
                        case "yB":
                            int difYB = e.Y - startCameraY;
                            cameraEdit.MoveEntity(difYB, cameraSection);
                            break;
                        default:
                            Cursor.Current = Cursors.Default;
                            break;
                    }


                    Cursor.Current = Cursors.Default;
                    CameraMouse = null;

                    DrawScreen();

                }
            }

        }
        public string OverlappingHoverCheckCamera(int x, int y)
        {
            string @return = "false";
            foreach (var camera in thisLevel.cameraBoxes)
            {
                var tup = camera.IsMouseInBounds(x, y);
                if (tup != null)
                {
                    return tup.Item2;
                }
            }
            return "false";
        }

    }
}
