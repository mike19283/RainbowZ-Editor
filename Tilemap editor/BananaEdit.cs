using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class BananaEdit : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;
        List<Bitmap> bananas = new List<Bitmap>();

        public BananaEdit(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;


            var folder = "banana_files";
            DirectoryInfo di = new DirectoryInfo(folder);

            FileInfo[] files = di.GetFiles("*.gif");

            foreach (var file in files)
            {
                bananas.Add(new Bitmap(file.FullName));
            }

            listBox_entities.Items.AddRange(thisLevel.bananas.ToArray());

            for (int i = 0; i < bananas.Count; i++)
            {
                comboBox_variety.Items.Add(Global.HexToString(i * 2 + 2));
            }

            comboBox_variety.SelectedIndex = 0;
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {


            var b = (Banana)listBox_entities.SelectedItem;
            if (b.type == 0)
            {
                return;
            }

            label_address.Text = b.address.ToString("X6");
            numericUpDown_entityType.Value = b.type;
            numericUpDown_entityX.Value = b.x;
            numericUpDown_entityY.Value = b.y;
            var index = b.type / 2;
            try
            {
                comboBox_variety.SelectedIndex = index - 1;
                pictureBox_banana.Image = bananas[index - 1];
            }
            catch
            {
                comboBox_variety.SelectedIndex = 0;
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var b = (Banana)listBox_entities.SelectedItem;
            b.type = (int)numericUpDown_entityType.Value & 0x3fe;
            b.x = (int)numericUpDown_entityX.Value;
            b.y = (int)numericUpDown_entityY.Value;
            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.bananas.ToArray());
            listBox_entities.SelectedIndex = index;
        }

        private void comboBox_variety_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = comboBox_variety.SelectedIndex;
            //int index = Convert.ToInt32(comboBox_variety.SelectedItem.ToString(), 16);
            int index = Convert.ToInt32(comboBox_variety.SelectedItem.ToString(), 16);
            numericUpDown_entityType.Value = index;
            try
            {
                pictureBox_varieties.Image = bananas[(index - 2) / 2];
            }
            catch { }

        }
        public void SelectBanana(int num)
        {
            listBox_entities.SelectedIndex = num;
        }
        public void MoveEntity(int x, int y, bool snap)
        {
            if (!snap)
            {
                numericUpDown_entityX.Value = x;
                numericUpDown_entityY.Value = y;
            }
            else
            {
                int ogX = (int)numericUpDown_entityX.Value;
                int ogY = (int)numericUpDown_entityY.Value;
                var pnt = Global.MoveSnapPoint(ogX, ogY, x, y, form.snapPrecision);
                numericUpDown_entityX.Value = pnt.X;
                numericUpDown_entityY.Value = pnt.Y;
            }
            numericUpDown_entityX.Refresh();
            numericUpDown_entityY.Refresh();
            button_apply_Click(0, new EventArgs());

        }

    }
}
