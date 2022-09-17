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

            //clone = rom.Clone();

            listBox_entities.Items.AddRange(thisLevel.verticalCameras.ToArray());
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rom.rom = clone;

            var verticalCamera = (VerticalCamera)listBox_entities.SelectedItem;
            numericUpDown_x.Value = verticalCamera.xStart;
            numericUpDown_xSize.Value = verticalCamera.xEnd;
            numericUpDown_y.Value = verticalCamera.yStart;
            numericUpDown_ySize.Value = verticalCamera.yEnd;

            //numericUpDown_connectionType1.Value = verticalCamera.connectionType;
            listBox_type.Items.Clear();
            foreach (var type in verticalCamera.types)
            {
                string str = type.ToString("X");
                listBox_type.Items.Add(str);
            }

            listBox_type.SelectedIndex = 0;

            int i = 0;
        }

        private void button_write_Click(object sender, EventArgs e)
        {

            var verticalCamera = (VerticalCamera)listBox_entities.SelectedItem;
            verticalCamera.xStart = (int)numericUpDown_x.Value;
            verticalCamera.xEnd = (int)numericUpDown_xSize.Value;
            verticalCamera.yStart = (int)numericUpDown_y.Value;
            verticalCamera.yEnd = (int)numericUpDown_ySize.Value;
            

            for (int i = 0; i < listBox_type.Items.Count; i++)
            {
                string str = listBox_type.Items[i].ToString();
                int num = Convert.ToInt32(str, 16);
                verticalCamera.types[i] = num;

            }


            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.verticalCameras.ToArray());
            listBox_entities.SelectedIndex = index;

            MessageBox.Show("Written!");

            //clone = rom.Clone();

        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            int index = listBox_type.SelectedIndex;
            var s = ((int)numericUpDown_type.Value).ToString("X");
            listBox_type.Items[index] = s;

        }

        private void listBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_type.SelectedIndex < 0 || listBox_type.SelectedIndex > listBox_type.Items.Count)
                return;
            int index = listBox_type.SelectedIndex;
            string str = listBox_type.Items[index].ToString();
            numericUpDown_type.Value = Convert.ToInt32(str, 16);

        }

        private void VerticalCameraEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //rom.rom = clone;
        }
    }
}
