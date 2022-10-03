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
    public partial class ObjectFunctions : Form
    {
        ROM rom;

        public ObjectFunctions(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            Init();
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void Init()
        {
            numericUpDown_d45.Maximum = 0x3fffff;
            panel_main.Visible = true;
            this.Text = rom.fileName;
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            if (listBox_functions.Items.Count == 0)
            {
                listBox_functions.Items.Add("Functions:");
            }
            if (listBox_functions.Items.Count >= 0x78)
            {
                listBox_functions.Items.Clear();
            }
            int startOfArray = 0xbf8177;
            int d45 = (int)numericUpDown_d45.Value;
            int indexToRead = startOfArray + d45 * 4;
            var index = rom.Read16(indexToRead);
            var offset = 0xbf0000 + index;

            string str = $"\n{offset.ToString("X")} - {((int)numericUpDown_d45.Value).ToString("X")}";

            listBox_functions.Items.Add(str);

            numericUpDown_d45.ResetText();
        }

        private void numericUpDown_d45_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown_d45_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_get_Click(sender, e);
            }
        }

        private void button_getAll_Click(object sender, EventArgs e)
        {
            listBox_functions.Items.Clear();
            string str = "Functions";
            listBox_functions.Items.Add(str);

            for (int i = 0; i < 0x79; i++)
            {
                int startOfArray = 0xbf8177;
                int d45 = i;
                int indexToRead = startOfArray + d45 * 4;
                var index = rom.Read16(indexToRead);
                var offset = 0xbf0000 + index;

                var s = $"\n{offset.ToString("X")} - {i.ToString("X")}";
                listBox_functions.Items.Add(s);
            }
            //richTextBox_functions.Text = str;
        }

        private void listBox_functions_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox_functions_MouseClick(object sender, EventArgs e)
        {

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
            }

        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            if (listBox_functions.SelectedIndex == -1)
                return;
            string str = listBox_functions.SelectedItem.ToString();
            str = str.Split('-')[0].Trim();
            Clipboard.Clear();
            Clipboard.SetText(str);
            button_copy.Text += "!";
        }

        private void listBox_functions_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_copy.Text = "Copy";
        }
    }
}
