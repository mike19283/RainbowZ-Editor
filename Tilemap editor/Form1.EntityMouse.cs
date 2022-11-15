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
        Point startEntity;
        int indexEntity = -1;
        int times = 0;
        Entity entityMouse;
        Bitmap screenCopy;
        int layerIndex = 0;
        Bitmap heldImage = new Bitmap(1,1);
        Bitmap ogLevelBitmap;

        public void MouseDownEntity (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            entityMouse = null;

            layerIndex = 0;
            int entityIndexVertical = 0;
            if (thisLevel == null || pictureBox_tilemap.Image == null || !radioButton_editEntities.Checked)
                return;
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                foreach (var ent in thisLevel.entities)
                {
                    entityMouse = ent.IsMouseInBounds(e.X, e.Y);
                    if (entityMouse != null)
                    {
                        heldImage = ent.sprite;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < thisLevel.verticalLayers.Count; i++) 
                {
                    entityIndexVertical = 0;
                    var layer = thisLevel.verticalLayers[i];
                    foreach (var ent in layer.entities)
                    {
                        entityMouse = ent.IsMouseInBounds(e.X, e.Y);
                        if (entityMouse != null)
                        {
                            layerIndex = i;
                            heldImage = ent.sprite;
                            goto VerticalBreak;
                        }
                        entityIndexVertical++;
                    }

                }
                entityMouse = null;
            VerticalBreak:;
            }
            if (entityMouse == null)
                return;
            //var entity = thisLevel.entities[indexEntity];
            if (edit != null)
            {
                edit.SelectEntity(entityMouse.local);
            }
            else if (editVerticalList.Count != 0)
            {
                editVerticalList[layerIndex].SelectEntity(entityIndexVertical);
            }
            mouseDown = true;
            times = 0;
            startEntity = new Point(entityMouse.x, entityMouse.y);
            startX = e.X;
            startY = pictureBox_tilemap.Size.Height - e.Y;
            Cursor.Current = Cursors.Hand;
            Cursor.Current = new Cursor("grab-cursor2.cur");

            DrawScreen();
            screenCopy = (Bitmap)pictureBox_tilemap.Image.Clone();
            label_start.Text = $"({entityMouse.x.ToString("X")},{entityMouse.y.ToString("X")})";
        }
        public bool OverlappingHoverCheckEntity(int x, int y)
        {
            bool overlapping = false;
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                foreach(var entity in thisLevel.entities)
                {
                    if (entity.IsMouseInBounds(x, y) != null)
                    {
                        overlapping = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (var layer in thisLevel.verticalLayers)
                {
                    foreach( var entity in layer.entities)
                    {
                        if (entity.IsMouseInBounds(x,y) != null)
                        {
                            overlapping = true;
                            break;
                        }
                    }
                    if (overlapping)
                        break;
                }
            }
            return overlapping;
        }
        public void MouseMoveEntity (object sender, MouseEventArgs e)
        {
            if (thisLevel == null || pictureBox_tilemap.Image == null || !radioButton_editEntities.Checked)
                return;
            if (!mouseDown)
            {
                if (OverlappingHoverCheckEntity(e.X, e.Y))
                    Cursor.Current = Cursors.Hand;
                else
                    Cursor.Current = Cursors.Default;

            }
            if (!CursorInBounds(e.X, e.Y))
            {
                mouseDown = false;
                entityMouse.x = startEntity.X;
                entityMouse.y = startEntity.Y;
                DrawScreen();

                return;
            }

            if (mouseDown && e.Button != MouseButtons.Right)
            {
                    int x = e.X, y = pictureBox_tilemap.Size.Height - e.Y;
                    //int x = e.X, y = e.Y + 0x80;
                    int deltaX = x - startX;
                    int deltaY = y - startY;


                int proposedX = startEntity.X + deltaX;
                int proposedY = startEntity.Y + deltaY;
                var dest = Global.MoveSnapPoint(startEntity.X, startEntity.Y, proposedX, proposedY, snapPrecision);
                entityMouse.x = dest.X;
                entityMouse.y = dest.Y;
                if (edit != null)
                {
                    edit.MoveEntity(entityMouse);
                }
                else
                {
                    int layer = entityMouse.layer;
                    editVerticalList[layer].MoveEntity(entityMouse, thisLevel.verticalLayers);
                }
                //entityMouse.x = proposedX > 0 ? proposedX : 0;
                //entityMouse.y = proposedY > 0 ? proposedY : 0;


                label_end.Text = $"({entityMouse.x.ToString("X")},{entityMouse.y.ToString("X")})";


                if (true || heldImage != null)
                {
                    Bitmap tempCopy = (Bitmap)screenCopy.Clone();
                    Bitmap tempBmp = entityMouse.DrawEntity(tempCopy, this);
                    SetImage(tempBmp);
                }


                //if (true || times++ == 100)
                //{
                //    Bitmap bmp = (Bitmap)screenCopy.Clone();
                //    bmp = DrawAllEntities(bmp);
                //    pictureBox_tilemap.Image = bmp;
                //    times = 0;
                //}
            }
        }

        private void SetImage(Bitmap tempBmp)
        {
            if (pictureBox_tilemap.Image != null)
                pictureBox_tilemap.Image.Dispose();
            pictureBox_tilemap.Image = tempBmp;
        }

        public void MouseUpEntity (object sender, MouseEventArgs e)
        {
            if (thisLevel == null || pictureBox_tilemap.Image == null || !radioButton_editEntities.Checked)
                return;
            if (mouseDown && false)
            {
                Cursor.Current = Cursors.Default;
                if (edit != null)
                {
                    edit.MoveEntity(entityMouse.x, entityMouse.y, snapToolStripMenuItem.Checked);
                }
                else
                {
                    //TurnOffTop();
                    editVerticalList[layerIndex].TopMost = true;
                    editVerticalList[layerIndex].TopMost = false;
                    editVerticalList[layerIndex].MoveEntity(entityMouse.x, entityMouse.y, snapToolStripMenuItem.Checked);
                    //TurnOffTop();

                }
                if (edit != null)
                {
                    edit.MoveEntity(entityMouse);
                }
                else
                {
                    int layer = entityMouse.layer;
                    editVerticalList[layer].MoveEntity(entityMouse, thisLevel.verticalLayers);
                }

            }

            mouseDown = false;

            DrawScreen();

        }

        private void TurnOffTop()
        {
            foreach (var vert in editVerticalList)
            {
                vert.TopMost = false;
            }
        }

        public void MouseLeaveEntity (object sender, EventArgs e)
        {
            if (thisLevel == null || pictureBox_tilemap.Image == null || !radioButton_editEntities.Checked || !mouseDown)
                return;
            if (mouseDown)
            {
                mouseDown = false;
                //var entity = thisLevel.entities[indexEntity];

                entityMouse.x = startEntity.X;
                entityMouse.y = startEntity.Y;
                if (edit != null)
                {
                    edit.MoveEntity(entityMouse);
                }
                else
                {
                    int layer = entityMouse.layer;
                    editVerticalList[layer].MoveEntity(entityMouse, thisLevel.verticalLayers);
                }
                DrawScreen();

            }
            mouseDown = false;
            //var entity = thisLevel.entities[indexEntity];

            entityMouse.x = startEntity.X;
            entityMouse.y = startEntity.Y;
            if (edit != null)
            {
                edit.MoveEntity(entityMouse);
            }
            else
            {
                int layer = entityMouse.layer;
                editVerticalList[layer].MoveEntity(entityMouse, thisLevel.verticalLayers);
            }
            DrawScreen();
        }
        private bool IsMouseOnAnEntity(int x, int y)
        {

            return false;
        }
        private Bitmap DrawAllEntities (Bitmap bmp)
        {
            if (checkBox_viewEntities.Checked)
            {
                foreach (var entity in thisLevel.entities)
                {
                    bmp = entity.DrawEntity(bmp, this);
                }
                for (int i = 0; i < thisLevel.verticalLayers.Count; i++)
                {
                    var layer = thisLevel.verticalLayers[i];
                    bmp = layer.DrawLayer(bmp);
                    foreach (var entity in layer.entities)
                    {
                        bmp = entity.DrawEntity(bmp, this);
                    }
                }

            }
            return bmp;

        }
    }
}
