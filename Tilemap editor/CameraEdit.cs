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
    public partial class CameraEdit : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;

        public CameraEdit(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;

            listBox_entities.Items.AddRange(thisLevel.cameraBoxes.ToArray());
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var camera = (Camera)listBox_entities.SelectedItem;
            numericUpDown_leftCam.Value = camera.xLeft;
            numericUpDown_upperCamY.Value = camera.yTop;
            numericUpDown_lowerCamY.Value = camera.yBottom;
            label_address.Text = camera.address.ToString("X6");
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var camera = (Camera)listBox_entities.SelectedItem;
            camera.xLeft = (int)numericUpDown_leftCam.Value;
            camera.yTop = (int)numericUpDown_upperCamY.Value;
            camera.yBottom = (int)numericUpDown_lowerCamY.Value;

            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.cameraBoxes.ToArray());
            listBox_entities.SelectedIndex = index;
        }

        private void button_setMultiple_Click(object sender, EventArgs e)
        {
            int value, index;
            NumericUpDown[] arr = new NumericUpDown[]
            {
                numericUpDown_leftCam,
                numericUpDown_upperCamY,
                numericUpDown_lowerCamY,
            };
            if (radioButton_xStart.Checked)
            {
                value = (int)numericUpDown_leftCam.Value;
                index = 0;
            }
            else if (radioButton_yT.Checked)
            {
                value = (int)numericUpDown_upperCamY.Value;
                index = 1;
            }
            else
            {
                value = (int)numericUpDown_lowerCamY.Value;
                index = 2;
            }
            var start = Convert.ToInt32(Prompt.ShowDialog("Choose start", "[Start"), 16);
            var end = Convert.ToInt32(Prompt.ShowDialog("Choose end", "end)"), 16);
            for (int i = start; i < end; i++)
            {
                listBox_entities.SelectedIndex = i;
                arr[index].Value = value;
                button_apply_Click(0, new EventArgs());
            }
        }
        public void SelectCamera(Camera cam)
        {
            listBox_entities.SelectedIndex = cam.index;
        }
        public void MoveEntity(int num, string mode)
        {
            if (mode == "x")
            {
                if (numericUpDown_leftCam.Value + num < 0)
                    num = 0;
                numericUpDown_leftCam.Value += num;
            }
            else if (mode == "yT")
            {
                if (numericUpDown_upperCamY.Value + num < 0)
                    num = 0;
                numericUpDown_upperCamY.Value += num;
            }
            else if (mode == "yB")
            {
                if (numericUpDown_lowerCamY.Value + num < 0)
                    num = 0;
                numericUpDown_lowerCamY.Value += num;
            }
            button_apply_Click(0, new EventArgs());

        }

        private void button_up_Click(object sender, EventArgs e)
        {
            var copy = (Camera)listBox_entities.SelectedItem;
            int index = listBox_entities.SelectedIndex;
            if (index == 0)
                return;

            thisLevel.cameraBoxes.RemoveAt(index);
            thisLevel.cameraBoxes.Insert(index - 1, copy);

            RefreshListbox();

            listBox_entities.SelectedIndex = index - 1;



        }

        public void RefreshListbox()
        {
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.cameraBoxes.ToArray());
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            var copy = (Camera)listBox_entities.SelectedItem;
            int index = listBox_entities.SelectedIndex;
            if (index == listBox_entities.Items.Count - 1)
                return;

            thisLevel.cameraBoxes.Insert(index + 2, copy);
            thisLevel.cameraBoxes.RemoveAt(index);

            RefreshListbox();

            listBox_entities.SelectedIndex = index + 1;
        }
    }
}
