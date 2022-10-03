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
    public partial class StartingWorld : Form
    {
        ROM rom;

        public StartingWorld(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            int start = rom.Read16LDA(0xb882ce);
            numericUpDown1.Value = start;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = (int)numericUpDown1.Value;
            rom.Write16LDA(0xb882ce, code);
            button1.Text = "Applied!";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = rom.WORLDCODES[listBox1.SelectedIndex];
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Text = "Apply";
        }
    }
}
