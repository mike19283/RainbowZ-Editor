using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Form1
    {
        List<EntityEditVertical> editVerticalList = new List<EntityEditVertical>();
        List<PathEdit> pathEdits = new List<PathEdit>();

        private void radioButton_editCameras_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                return;
            CloseAll();

            if (radioButton_editCameras.Checked)
            {
                if (!rom.IsVertical(thisLevel.levelCode))
                {
                    if (cameraEdit != null)
                        cameraEdit.Close();
                    cameraEdit = new CameraEdit(thisLevel, rom, this);
                    cameraEdit.Show();
                }
                else
                {
                    MessageBox.Show("WARNING! This is not fully featured yet.\nThese don't work as expected.\nEdit at your own risk...");
                    if (VerticalCameraEdit != null)
                        VerticalCameraEdit.Close();
                    VerticalCameraEdit = new VerticalCameraEdit(thisLevel, rom, this);
                    VerticalCameraEdit.Show();

                }
            }
            else
            {
                if (cameraEdit != null)
                    cameraEdit.Close();
                if (VerticalCameraEdit != null)
                    VerticalCameraEdit.Close();
            }

        }
        public void CloseAll()
        {
            if (cameraEdit != null)
                cameraEdit.Close();
            if (edit != null)
                edit.Close();
            if (entranceEdit != null)
                entranceEdit.Close();
            if (bananaEdit != null)
                bananaEdit.Close();
            if (VerticalCameraEdit != null)
                VerticalCameraEdit.Close();
            foreach (var ev in editVerticalList)
            {
                ev.Close();
            }
            foreach (var ev in pathEdits)
            {
                ev.Close();
            }
            editVerticalList = new List<EntityEditVertical>();

        }

        private void radioButton_editEntities_CheckedChanged(object sender, EventArgs e)
        {
            CloseAll();
            EntityEditVertical editVertical;
            edit = null;
            try
            {
                if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                    return;

                DrawScreen();
                if (!rom.IsVertical(thisLevel.levelCode))
                {
                    if (radioButton_editEntities.Checked)
                    {
                        if (edit != null)
                        {
                            edit.Close();

                        }

                        edit = new EntityEdit(thisLevel, rom, this);
                        edit.Show();
                    }
                    else
                    {
                        if (edit != null)
                            edit.Close();
                    }
                }
                else
                {
                    if (radioButton_editEntities.Checked)
                    {
                        var layers = thisLevel.verticalLayers;
                        for (int i = 0; i < layers.Count; i++)
                        {
                            editVertical = new EntityEditVertical(thisLevel, rom, this, i);
                            editVerticalList.Add(editVertical);
                            editVertical.Show();
                        }
                    }
                    else
                    {
                        if (edit != null)
                            edit.Close();
                    }

                }
            }
            catch { }
            this.TopMost = true;
            this.TopMost = false;

        }

        private void radioButton_editBananas_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                return;

            if (radioButton_editBananas.Checked)
            {
                CloseAll();
                if (bananaEdit != null)
                    bananaEdit.Close();
                bananaEdit = new BananaEdit(thisLevel, rom, this);
                if (bananaEdit != null)
                    bananaEdit.Show();
            }
            else
            {
                if (bananaEdit != null)
                    bananaEdit.Close();
            }

        }

        private void radioButton_editEntrances_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                return;
            CloseAll();
            if (radioButton_editEntrances.Checked)
            {
                if (entranceEdit != null)
                    entranceEdit.Close();
                entranceEdit = new Entrances(thisLevel, rom, this);
                entranceEdit.Show();
            }
            else
            {
                if (entranceEdit != null)
                    entranceEdit.Close();
            }

        }

        private void checkBox_viewPaths_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                return;
            radioButton_editPaths.Enabled = checkBox_viewPaths.Checked;
            DrawScreen();

        }

        private void radioButton_editPaths_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null || thisLevel.levelCode >= 0xf0)
                return;
            
            //CloseAll();
            for (int i = thisLevel.platformPaths.Count; i > 0 ; i--)
            {
                var path = thisLevel.platformPaths[i - 1];
                var pathEdit = new PathEdit(thisLevel, rom, this, path, i - 1);
                pathEdit.Text = $"Platform edit: {i - 1}";
                pathEdits.Add(pathEdit);
                pathEdit.Show();
            }
        }

    }
}
