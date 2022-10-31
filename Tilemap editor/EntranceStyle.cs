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
    public partial class EntranceStyle : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        int style;
        public EntranceStyle(ROM rom, DKCLevel thisLevel)
        {
            InitializeComponent();
            this.rom = rom;
            this.thisLevel = thisLevel;
            style = rom.Read16(rom.ENTRANCESTYLE + thisLevel.levelCode * 2);
            var arr = rom.ENTRANCESTYLEBYCODE.Keys.ToList();
            int index = arr.IndexOf(style);
            listBox_entranceStyle.SelectedIndex = index;
            numericUpDown_code.Value = thisLevel.levelCode;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            style = rom.ENTRANCESTYLESBYSTRING[listBox_entranceStyle.SelectedItem.ToString()];
            int code = (int)numericUpDown_code.Value;
            int offset = rom.ENTRANCESTYLE + code * 2;
            rom.Write16(offset, style);
            button_apply.Text += "!";

        }

        private void button_loadCode_Click(object sender, EventArgs e)
        {
            style = rom.Read16(rom.ENTRANCESTYLE + (int)numericUpDown_code.Value * 2);
            var arr = rom.ENTRANCESTYLEBYCODE.Keys.ToList();
            int index = arr.IndexOf(style);
            listBox_entranceStyle.SelectedIndex = index;
            button_apply.Text = "Apply";

        }

        private void button_applySanity_Click(object sender, EventArgs e)
        {
            if  (numericUpDown_code.Value == thisLevel.levelCode)
            {
                button_apply_Click(0, new EventArgs());
                foreach (var related in thisLevel.relatedLevels)
                {
                    numericUpDown_code.Value = related.code;
                    button_apply_Click(0, new EventArgs());

                }
                numericUpDown_code.Value = thisLevel.levelCode;
                MessageBox.Show("Applied sanity!");
            }
            else
            {
                MessageBox.Show("Can't apply sanity on this code!");
            }

        }
    }
}
