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
    public partial class Color_Math_Control : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        public Color_Math_Control(ROM rom, DKCLevel thisLevel)
        {
            InitializeComponent();
            this.rom = rom;
            this.thisLevel = thisLevel;
            numericUpDown_levelCode.Value = thisLevel.levelCode;
            button_load_Click(0, new EventArgs());
        }

        private void numericUpDown_IntensityValueChanged(object sender, EventArgs e)
        {
            int r = (int)numericUpDown_r.Value,
                g = (int)numericUpDown_g.Value,
                b = (int)numericUpDown_b.Value;
            int val = (r << 0) | (g << 5) | (b << 10);
            numericUpDown_2132.Value = val;
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            int offset = rom.COLORMATHBYLEVEL + (int)numericUpDown_levelCode.Value * 4;
            numericUpDown_2131.Value = rom.Read8(offset + 0);
            int val = rom.Read16(offset + 1);
            numericUpDown_2132.Value = val;
            int r = (val >> 0) & 0x1f;
            int g = (val >> 5) & 0x1f;
            int b = (val >> 10) & 0x1f;
            numericUpDown_r.Value = r;
            numericUpDown_g.Value = g;
            numericUpDown_b.Value = b;

            button_apply.Text = "Apply";
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            int offset = rom.COLORMATHBYLEVEL + (int)numericUpDown_levelCode.Value * 4;
            rom.Write8(offset + 0, (int)numericUpDown_2131.Value);
            rom.Write16(offset + 1, (int)numericUpDown_2132.Value);
            button_apply.Text += "!";


        }

        private void button_applySanity_Click(object sender, EventArgs e)
        {
            if (numericUpDown_levelCode.Value == thisLevel.levelCode)
            {
                button_apply_Click(0, new EventArgs());
                foreach (var related in thisLevel.relatedLevels)
                {
                    numericUpDown_levelCode.Value = related.code;
                    button_apply_Click(0, new EventArgs());

                }
                numericUpDown_levelCode.Value = thisLevel.levelCode;
                MessageBox.Show("Applied sanity!");
            }
            else
            {
                MessageBox.Show("Can't apply sanity on this code!");
            }


        }
    }
}
