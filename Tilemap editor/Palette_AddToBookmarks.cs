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
    public partial class Palette_AddToBookmarks : Form
    {
        public string bookmarkName;

        public Palette_AddToBookmarks()
        {
            InitializeComponent();
        }

        private void button_bookmarkAdd_Click(object sender, EventArgs e)
        {
            if (textBox_bookmarkAdd.Text.Length > 0)
            {
                bookmarkName = textBox_bookmarkAdd.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBox_bookmarkAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bookmarkName = textBox_bookmarkAdd.Text;
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
