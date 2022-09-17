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
    public partial class HexEditor : Form
    {
        ROM rom;
        int textSize = 24;
        int linesToDisplay = 11;
        int bytesPerLine = 8;
        int currentOffset = 0;
        public HexEditor(ROM rom)
        {
            this.rom = rom;
            InitializeComponent();
            Init();
            vScrollBar_hexedit.Value = 0;
        }
        private void DisplayRange()
        {
            DisplayAddresses();
            DisplayBytes();
        }
        private void DisplayBytes()
        {
            var addressToWrite = vScrollBar_hexedit.Value * bytesPerLine;
            string str = "";
            // Loop through lines to display
            for (int i = 0; i < linesToDisplay; i++)
            {
                string line = "";
                // On each line, print number of bytes
                for (int j = 0; j < bytesPerLine; j++)
                {
                    line += rom.Read8(addressToWrite++).ToString("X2") + " ";
                }
                line = line.Trim();
                
                str += line + Environment.NewLine;
            }
            str = str.Substring(0, str.Length - 1);
            textBox_bytes.Text = str;
        }
        private void DisplayAddresses()
        {
            var addressToWrite = vScrollBar_hexedit.Value * bytesPerLine;
            string str = addressToWrite.ToString("x6") + '\n';
            for (int i = 0; i < linesToDisplay - 1; i++)
            {
                addressToWrite += bytesPerLine;
                str += addressToWrite.ToString("x6") + '\n';
            }
            textBox_address.Text = str;
        }
        private void Init()
        {
            vScrollBar_hexedit.Maximum = rom.rom.Count / bytesPerLine - linesToDisplay;
            //vScrollBar_hexedit.Maximum = rom.rom.Count / bytesPerLine;
            textBox_bytes.Text = "";
            textBox_address.Text = "";
        }

        private void vScrollBar_hexedit_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ans = Prompt.ShowDialog("Enter offset (in hex)", "Goto");
            int offset = Convert.ToInt32(ans, 16);
            offset &= (offset > 0x7fffff ? 0x3fffff : 0xffffff);

            int line = offset / bytesPerLine;
            vScrollBar_hexedit.Value = line;

        }

        private void vScrollBar_hexedit_ValueChanged(object sender, EventArgs e)
        {
            DisplayRange();

        }

        private void textBox_bytes_KeyDown(object sender, KeyEventArgs e)
        {
            SkipSpace(e);
        }
        private void SkipSpace(KeyEventArgs e)
        {
            int start = textBox_bytes.SelectionStart;
            string str = textBox_bytes.Text;
            int dir = e.KeyCode == Keys.Left ? -1 : 1;
            if (start == 0 || start >= str.Length - 1)
            {
                return;
            }
            if (str[start + dir] == ' ' && (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left))
            {
                textBox_bytes.SelectionStart = start + dir;
            }
        }
    }
}
