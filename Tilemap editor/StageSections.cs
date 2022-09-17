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
    public partial class StageSections : Form
    {
        private List<Bitmap> sections;
        
        public StageSections(List<Bitmap> sections)
        {
            InitializeComponent();
            this.sections = sections;
            for (int i = 0; i < sections.Count; i++)
            {
                string index = i.ToString("X2");
                listBox_left.Items.Add(index);
                listBox_right.Items.Add(index);
            }
            listBox_left.SelectedIndex = 0;
            listBox_right.SelectedIndex = sections.Count - 1; ;
        }

        private void listBox_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bmp = sections[listBox_left.SelectedIndex];
            pictureBox_left.Size = new Size(bmp.Width / 2, bmp.Height / 2);
            pictureBox_left.Image = bmp;
        }

        private void listBox_right_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bmp = sections[listBox_right.SelectedIndex];
            pictureBox_right.Size = new Size(bmp.Width / 2, bmp.Height / 2);
            pictureBox_right.Image = bmp;

        }

        private void button_bothUp_Click(object sender, EventArgs e)
        {
            //Move(-1, listBox_left);
            Move(-1, listBox_right);
        }

        private void button_bothDown_Click(object sender, EventArgs e)
        {
            //Move(1, listBox_left);
            Move(1, listBox_right);

        }
        private void Move (int moveBy, ListBox lb)
        {
            // Move
            int lIndex = lb.SelectedIndex;
            int dif = moveBy + lIndex;
            if (dif >= 0 && dif < sections.Count)
            {
                lb.SelectedIndex = dif;
            }

        }
    }
}
