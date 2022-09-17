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
    public partial class KongAttributes : Form
    {
        private ROM rom;
        private string applied = "Applied";
        private int[] ATTRIBUTEADDRESSESLDA = new int[]
        {
            0xbfb5a2, // Kong base walk speed
            0xbfb567, // Kong base run speed
            0xbfbd58, // Kong base stationary roll
            0xbfbd65, // Kong base running roll
            0xbfb6ea, // Kong base swimming x right
            0xbfb5d3, // Kong base swimming x left
            0xbea7d6, // Donkey takeoff speed
            0xbea7c1, // Diddy takeoff speed

            0xbfbdfa, // Roll speed increase
            0xbfbdfd, // Max roll speed

            0xbfb586, // Rambi walk speed
            0xbfb54b, // Rambi run speed
            0xbea7eb, // Rambi takeoff speed

            0xbfb6cf, // Enguarde swimming x right
            0xbfb5b8, // Enguarde swimming x left
            0xbebc18, // Enguarde lunge speed (both)
            0xbfb3a2, // Enguarde up speed
            0xbfb415, // Enguarde down speed

            0xbfb58c, // Winky walk speed
            0xbfb551, // Winky run speed
            0xbea807, // Winky takeoff speed
            0xbfb592, // Expresso walk speed
            0xbfb557, // Expresso run speed
            0xbea7f9, // Expresso takeoff speed



        };

        public KongAttributes(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            listBox_attribute.SelectedIndex = 0;


        }

        private void listBox_attribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_attribute.SelectedIndex == -1)
            {
                return;
            }
            int addr = ATTRIBUTEADDRESSESLDA[listBox_attribute.SelectedIndex];
            int val = rom.Read16LDA(addr);
            numericUpDown_attrValue.Value = val;
            button_apply.Text = "Apply";
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            int address = ATTRIBUTEADDRESSESLDA[listBox_attribute.SelectedIndex];
            int value = (int)numericUpDown_attrValue.Value;
            rom.Write16LDA(address, value);
            if (listBox_attribute.SelectedItem.ToString() == "Max roll speed")
            {
                rom.Write16LDA(0xbfbe02, value);
            }
            button_apply.Text = applied;
            applied += '!';

        }
    }
}
