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
    public partial class K_Rool_Throw_Options : Form
    {
        public int pointer = 0x1a8;
        public K_Rool_Throw_Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton_normalHit.Checked)
                pointer = 0x1a8;
            else if (radioButton_1flinch.Checked)
                pointer = 0x1af;
            else if (radioButton_3flinches.Checked)
                pointer = 0x1b2;
            this.DialogResult = DialogResult.OK;
        }
    }
}
