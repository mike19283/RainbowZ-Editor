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
    public partial class Music_Picker : Form
    {
        string applied = "Applied";
        ROM rom;
        int levelCode;
        public Music_Picker(ROM rom, int levelCode)
        {
            InitializeComponent();
            this.rom = rom;
            this.levelCode = levelCode;

            listBox_musicTracks.Items.AddRange(rom.musicPointersByString.Keys.ToArray());
            numericUpDown_levelCode.Value = levelCode;

            int val = rom.Read16(rom.MUSICTRACK + levelCode * 2);
            numericUpDown_musicPointer.Value = val;

            // Search and highlight
            for (int i = 0; i < listBox_musicTracks.Items.Count; i++)
            {
                string str = listBox_musicTracks.Items[i].ToString();
                if (rom.musicPointersByString[str] == val)
                {
                    listBox_musicTracks.SelectedIndex = i;
                    break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            levelCode = (int)numericUpDown_levelCode.Value;

            rom.Write16(rom.MUSICTRACK + levelCode * 2, (int)numericUpDown_musicPointer.Value);
            applied += '!';
            button1.Text = applied;
        }

        private void listBox_musicTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown_musicPointer.Value = rom.musicPointersByString[listBox_musicTracks.SelectedItem.ToString()];
        }

        private void numericUpDown_levelCode_ValueChanged(object sender, EventArgs e)
        {
            

            int val = rom.Read16(rom.MUSICTRACK + (int)numericUpDown_levelCode.Value * 2);
            numericUpDown_musicPointer.Value = val;

            // Search and highlight
            for (int i = 0; i < listBox_musicTracks.Items.Count; i++)
            {
                string str = listBox_musicTracks.Items[i].ToString();
                if (rom.musicPointersByString[str] == val)
                {
                    listBox_musicTracks.SelectedIndex = i;
                    break;
                }
            }

        }

        private void button_applySanity_Click(object sender, EventArgs e)
        {
            int lvl = (int)numericUpDown_levelCode.Value;
            rom.Write16(rom.MUSICTRACK + lvl * 2, (int)numericUpDown_musicPointer.Value);

            string name = rom.levelNameByCode[lvl];
            if (!name.Contains("level start"))
            {
                return;
            }
            // Look at core name
            name = name.Split('(')[0].Trim();
            //var dict = rom.levelNameByCode.Where(kvp => kvp.Value.Contains(name) && kvp.Value.Contains("from"));
            List<int> musicSanityArr = new List<int>();
            // Loop through all stages, selecting 'sane' ones
            foreach (var kvp in rom.levelNameByCode)
            {
                int key = kvp.Key;
                string value = kvp.Value;
                if (value.Contains(name) && value.Contains("from"))
                {
                    rom.Write16(rom.MUSICTRACK + key * 2, (int)numericUpDown_musicPointer.Value);
                }
            }
            MessageBox.Show("Done.");
        }
    }
}
