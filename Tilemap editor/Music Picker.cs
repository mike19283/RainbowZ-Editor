﻿using System;
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
        DKCLevel thisLevel;
        public Music_Picker(ROM rom, int levelCode, DKCLevel thisLevel)
        {
            InitializeComponent();
            this.rom = rom;
            this.levelCode = levelCode;
            this.thisLevel = thisLevel;

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

            radioButton_sanity.Checked = CheckSanity();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            levelCode = (int)numericUpDown_levelCode.Value;

            rom.Write16(rom.MUSICTRACK + levelCode * 2, (int)numericUpDown_musicPointer.Value);
            applied += '!';
            button1.Text = applied;
            int address = 0xb90000 + (int)numericUpDown_musicPointer.Value;
            switch (numericUpDown_musicPointer.Value)
            {
                case 0xff65:
                    rom.Write16LDAConstant(address + 0, 0x16);
                    rom.WriteJmp(address + 3, rom.LOADTRACKINA);
                    break;
                case 0xff6c:
                    rom.Write16LDAConstant(address + 0, 0x14);
                    rom.WriteJmp(address + 3, rom.LOADTRACKINA);
                    break;
                case 0xff73:
                    rom.Write16LDAConstant(address + 0, 0xf);
                    rom.WriteJmp(address + 3, rom.LOADTRACKINA);
                    break;

                default:
                    break;
            } 
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
            button1_Click(0, new EventArgs());

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
            foreach (var rel in thisLevel.relatedLevels)
            {
                int key = rel.code;
                rom.Write16(rom.MUSICTRACK + key * 2, (int)numericUpDown_musicPointer.Value);
            }
            radioButton_sanity.Checked = true;
            MessageBox.Show("Done.");
        }
        private int GetMusicPointer (int code)
        {
            return rom.Read16(rom.MUSICTRACK + code * 2);
        }
        private bool CheckSanity ()
        {
            int search = GetMusicPointer(levelCode);
            foreach (var lvl in thisLevel.relatedLevels)
            {
                if (search != GetMusicPointer(lvl.code))
                {
                    return false;
                }
            }
            return true;
        }

        private void radioButton_sanity_Click(object sender, EventArgs e)
        {

        }
    }
}
