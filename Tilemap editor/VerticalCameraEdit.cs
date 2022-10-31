using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class VerticalCameraEdit : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;
        //List<byte> clone;

        public VerticalCameraEdit(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;


            listBox_entities.Items.AddRange(thisLevel.verticalCameras.ToArray());
            listBox_entities.SelectedIndex = 0;

            int global = Global.editThisVerticalCam;
            if (global != -1 && global < thisLevel.verticalCameras.Count)
            {
                listBox_entities.SelectedIndex = global;
                checkBox_editThis.Checked = true;  
            }
            else
            {
                checkBox_editThis.Checked = false;
                Global.editThisVerticalCam = -1;
            }
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFromVerticalCamera();
            if (Global.editThisVerticalCam != -1)
            {
                Global.editThisVerticalCam = listBox_entities.SelectedIndex;
            }
        }

        private void LoadFromVerticalCamera()
        {
            var verticalCamera = (VerticalCamera)listBox_entities.SelectedItem;
            if (verticalCamera.xStart < 0)
                verticalCamera.xStart = 0;
            numericUpDown_x.Value = verticalCamera.xStart;
            if (verticalCamera.xEnd < 0)
                verticalCamera.xEnd = 0;
            numericUpDown_xSize.Value = verticalCamera.xEnd;
            if (verticalCamera.yStart < 0)
                verticalCamera.yStart = 0;
            numericUpDown_y.Value = verticalCamera.yStart;
            if (verticalCamera.yEnd < 0)
                verticalCamera.yEnd = 0;
            numericUpDown_ySize.Value = verticalCamera.yEnd;

            listBox_type.Items.Clear();
            listBox_type.Items.AddRange(verticalCamera.vConnections.ToArray());
            listBox_type.SelectedIndex = 0;

            int i = 0;
            label_address.Text = verticalCamera.address.ToString("X6");
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var verticalCamera = (VerticalCamera)listBox_entities.SelectedItem;
            verticalCamera.xStart = (int)numericUpDown_x.Value;
            verticalCamera.xEnd = (int)numericUpDown_xSize.Value;
            verticalCamera.yStart = (int)numericUpDown_y.Value;
            verticalCamera.yEnd = (int)numericUpDown_ySize.Value;

            int connectionIndex = listBox_type.SelectedIndex;


            VConnection connect = verticalCamera.vConnections[connectionIndex];
            connect.multiple = radioButton_multiple.Checked;
            connect.hidden = radioButton_hidden.Checked;
            if (radioButtonU.Checked)
                connect.direction = "U";
            else if (radioButton_D.Checked)
                connect.direction = "D";
            else if (radioButton_L.Checked)
                connect.direction = "L";
            else if (radioButton_R.Checked)
                connect.direction = "R";
            int ultimate = GetConnection();
            if ((ultimate & 0xf) == 0)
            {
                connect.relative = false;
                connect.nextIndex = (int)numericUpDown_connected.Value;

                connect.SetConnection(ultimate, (int)numericUpDown_connected.Value);
            }
            else
            {
                connect.relative = true;
                connect.connection = ultimate;
                connect.nextIndex = (int)numericUpDown_connected.Value & 0xf;

                connect.SetConnection(ultimate);
            }
            RefreshConnectionListbox();

            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.verticalCameras.ToArray());
            listBox_entities.SelectedIndex = index;

            listBox_type.SelectedIndex = connectionIndex;

        }

        private int GetConnection ()
        {
            int connection = 0;
            if (radioButtonU.Checked)
                connection += 6;
            if (radioButton_D.Checked)
                connection += 9;
            if (radioButton_L.Checked)
                connection += 0;
            if (radioButton_R.Checked)
                connection += 3;
            if (radioButton_single.Checked)
                connection += 0;
            if (radioButton_hidden.Checked)
                connection += 1;
            if (radioButton_multiple.Checked)
                connection += 2;
            connection <<= 4;

            int connectionIndex = listBox_entities.SelectedIndex;
            int pointerIndex = (int)numericUpDown_connected.Value;
            int dif = 0;

            dif = pointerIndex - connectionIndex;
            if (dif <= 7 && dif >= -8)
            {
                if (dif < 0)
                {
                    dif = 0x10 + dif;
                }
                connection |= dif;
            }
            else
            {

            }


            return connection;
        }

        private void listBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_type.SelectedIndex < 0 || listBox_type.SelectedIndex > listBox_type.Items.Count)
                return;
            VerticalCamera camera = thisLevel.verticalCameras[listBox_entities.SelectedIndex];
            int connectionIndex = listBox_type.SelectedIndex;
            var connection = (VConnection)camera.vConnections[connectionIndex];
            radioButton_L.Checked = connection.direction == "L";
            radioButton_R.Checked = connection.direction == "R";
            radioButtonU.Checked = connection.direction == "U";
            radioButton_D.Checked = connection.direction == "D";
            if (connection.multiple)
            {
                radioButton_multiple.Checked = true;
            }
            else if (connection.hidden)
                radioButton_hidden.Checked = true;
            else
                radioButton_single.Checked = true;

            int next = connection.nextIndex;
            if (connection.relative)
            {
                if (connection.nextIndex <= 7)
                {
                    next = next + listBox_entities.SelectedIndex;
                }
                else
                {
                    int neg = 0x10 - next;
                    next = listBox_entities.SelectedIndex - neg;
                }
            }
            else
            {

            }
            if (next < 0)
            {
                camera.vConnections.RemoveAt(connectionIndex);

                if (camera.vConnections.Count == 0)
                {
                    VConnection vConnection = new VConnection(0x31);
                    camera.vConnections.Add(vConnection);
                }
                RefreshConnectionListbox();
                listBox_type.SelectedIndex = 0;
            }
            else
                numericUpDown_connected.Value = next;
        }

        private void VerticalCameraEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int startingX = 0x300;
            int startingY = thisLevel.verticalCameras[0].yStart - (0x10 * thisLevel.verticalCameras.Count); ;
            VerticalCamera verticalCamera = new VerticalCamera(startingX, startingY, 0x31, rom);
            thisLevel.verticalCameras.Add(verticalCamera);
            RefreshListbox();

            form.Level_select_Click(0, new EventArgs());
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (thisLevel.verticalCameras.Count > 2)
            {
                int selectedIndex = listBox_entities.SelectedIndex;
                thisLevel.verticalCameras.RemoveAt(selectedIndex);
                selectedIndex -= selectedIndex < thisLevel.verticalCameras.Count ? 0 : 1;
                RefreshListbox();
                listBox_entities.SelectedIndex = selectedIndex;
            }
        }
        public void RefreshListbox()
        {
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.verticalCameras.ToArray());
        }
        public void RefreshConnectionListbox()
        {
            var selected = (VerticalCamera)listBox_entities.SelectedItem;
            listBox_type.Items.Clear();
            listBox_type.Items.AddRange(selected.vConnections.ToArray());
        }

        private void button_removeConnection_Click(object sender, EventArgs e)
        {
            if (listBox_type.SelectedIndex != -1)
            {
                var camera = (VerticalCamera)listBox_entities.SelectedItem;
                int removeIndex = listBox_type.SelectedIndex;
                if (camera.vConnections.Count > 1)
                {
                    camera.vConnections.RemoveAt(removeIndex);
                    RefreshConnectionListbox();
                    listBox_type.SelectedIndex = 0;
                }
            }
        }

        private void button_addConnection_Click(object sender, EventArgs e)
        {
            var camera = (VerticalCamera)listBox_entities.SelectedItem;
            camera.vConnections.Add(new VConnection(0x31));
            RefreshConnectionListbox();
            listBox_type.SelectedIndex = 0;
        }

        private void checkBox_autoconnect_CheckedChanged(object sender, EventArgs e)
        {
            thisLevel.autoconnectVertical = !thisLevel.autoconnectVertical;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            thisLevel.ConnectVerticalCameras(listBox_entities.SelectedIndex);
            MessageBox.Show("Connected");
        }

        private void button_camUp_Click(object sender, EventArgs e)
        {
            int index = listBox_entities.SelectedIndex;
            if (index > 0)
            {
                var temp = (VerticalCamera)thisLevel.verticalCameras[index];
                thisLevel.verticalCameras.RemoveAt(index);
                thisLevel.verticalCameras.Insert(index - 1, temp);
                form.Level_select_Click(0, new EventArgs());
            }
        }

        private void button_camDown_Click(object sender, EventArgs e)
        {
            int index = listBox_entities.SelectedIndex;
            if (index < listBox_entities.Items.Count - 1)
            {
                var temp = (VerticalCamera)thisLevel.verticalCameras[index];
                thisLevel.verticalCameras.RemoveAt(index);
                thisLevel.verticalCameras.Insert(index + 1, temp);
                form.Level_select_Click(0, new EventArgs());
            }

        }

        private void button_connectAll_Click(object sender, EventArgs e)
        {
            form.ConnectAllVCams();
        }
        public void RefreshAll(int index)
        {
            RefreshListbox();
            listBox_entities.SelectedIndex = index;
        }

        private void checkBox_editThis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_editThis.Checked)
            {
                Global.editThisVerticalCam = listBox_entities.SelectedIndex;
            }
            else
            {
                Global.editThisVerticalCam = -1;
            }
        }
    }
}
