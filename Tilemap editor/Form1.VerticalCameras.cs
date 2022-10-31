using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class Form1
    {
        VerticalCamera verticalCamera;
        int startVCameraY;
        string cameraVSection;
        int startVCameraX;
        int vCamEditMode = -1;
        bool vCamMouseDown = false;

        public void VCameraMouseDown(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.verticalCameras == null || !radioButton_editCameras.Checked)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
                return;
            if (vCamEditMode != -1)
            {
                startVCameraX = e.X;
                startVCameraY = e.Y;
                vCamMouseDown = true;
            }
        }

        private void VCamInBounds(MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.verticalCameras.Count > 0 && radioButton_editCameras.Checked)
            {
                VCameraHoverIcon(e);
                if (!CursorInBounds(e.X, e.Y))
                {
                    return;
                }
            }
        }

        public void VCameraMouseLeave(object sender, EventArgs e)
        {
            verticalCamera = null;
            vCamEditMode = -1;
            vCamMouseDown = false;
            Cursor.Current = Cursors.Default;
        }
        public void VCameraMouseMove(object sender, MouseEventArgs e)
        {
            if (thisLevel == null || thisLevel.verticalCameras == null || !radioButton_editCameras.Checked)
            {
                return;
            }
            if (!vCamMouseDown)
            {
                VCamInBounds(e);
            }
        }

        private void VCameraHoverIcon(MouseEventArgs e)
        {
            int num = OverlappingHoverCheckVCamera(e.X, e.Y);
            switch (num)
            {
                case 0:
                case 1:
                    Cursor.Current = Cursors.SizeWE;
                    break;
                case 2:
                case 3:
                    Cursor.Current = Cursors.SizeNS;
                    break;
                case 4:
                    Cursor.Current = Cursors.Cross;
                    break;
                default:
                    Cursor.Current = Cursors.Default;
                    verticalCamera = null;
                    break;
            }
        }

        public void VCameraMouseUp(object sender, MouseEventArgs e)
        {
            if (thisLevel != null && thisLevel.verticalCameras.Count > 0 && radioButton_editCameras.Checked)
            {
                if (e.Button == MouseButtons.Right)
                    return;
                if (vCamMouseDown)
                {
                    int difX = e.X - startVCameraX;
                    int difY = e.Y - startVCameraY;
                    switch (vCamEditMode)
                    {
                        case 0:
                            verticalCamera.xStart += difX;
                            if (verticalCamera.xEnd - verticalCamera.xStart > 0x3fc)
                                verticalCamera.xStart = verticalCamera.xEnd - 0x3fc;
                            if (verticalCamera.xStart > verticalCamera.xEnd)
                                verticalCamera.xStart = verticalCamera.xEnd;
                            break;
                        case 1:
                            verticalCamera.xEnd += difX;
                            if (verticalCamera.xEnd - verticalCamera.xStart > 0x3fc)
                                verticalCamera.xEnd = verticalCamera.xStart + 0x3fc;
                            if (verticalCamera.xStart > verticalCamera.xEnd)
                                verticalCamera.xEnd = verticalCamera.xStart;
                            break;
                        case 2:
                            verticalCamera.yStart += difY;
                            if (verticalCamera.yEnd - verticalCamera.yStart > 0x3fc)
                                verticalCamera.yStart = verticalCamera.yEnd - 0x3fc;
                            if (verticalCamera.yStart > verticalCamera.yEnd)
                                verticalCamera.yStart = verticalCamera.yEnd;
                            break;
                        case 3:
                            verticalCamera.yEnd += difY;
                            if (verticalCamera.yEnd - verticalCamera.yStart > 0x3fc)
                                verticalCamera.yEnd = verticalCamera.yStart + 0x3fc;
                            if (verticalCamera.yStart > verticalCamera.yEnd)
                                verticalCamera.yEnd = verticalCamera.yStart;
                            break;
                        case 4:
                            verticalCamera.RelativeMoveEntity(difX, difY);
                            break;
                        default:
                            break;
                    }
                    VerticalCameraEdit.RefreshAll(thisLevel.verticalCameras.IndexOf(verticalCamera));
                    verticalCamera = null;
                    vCamEditMode = -1;
                    vCamMouseDown = false;
                }

                    DrawScreen();

            }

        }
        public int OverlappingHoverCheckVCamera(int x, int y)
        {
            for (int i = thisLevel.verticalCameras.Count - 1; i >= 0; i--)
            {
                int global = Global.editThisVerticalCam;
                if (global != -1 && i != global)
                {
                    continue;
                }

                var vcam = thisLevel.verticalCameras[i];
                var cam = vcam.IsMouseInBounds(x, y);
                if (cam != null)
                {
                    verticalCamera = cam.Item1;
                    vCamEditMode = cam.Item2;
                    return vCamEditMode;
                }
                var center = vcam.IsMouseInCenter(x, y);
                if (center != null)
                {
                    verticalCamera = center;
                    vCamEditMode = 4;
                    return 4;
                }


            }
            vCamEditMode = -1;
            return -1;
        }

    }
}
