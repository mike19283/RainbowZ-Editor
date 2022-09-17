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
    public partial class Restore : Form
    {
        public int @return = 0;
        public Restore(string[] keep)
        {
            InitializeComponent();
            listBox_keep.Items.AddRange(keep.ToArray());

        }

        private void button_select_Click(object sender, EventArgs e)
        {
            @return = listBox_keep.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
