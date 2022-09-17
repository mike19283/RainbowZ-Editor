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
    public partial class Palette_Bookmarks : Form
    {
        public string selectedKey;
        public Palette_Bookmarks(Dictionary<string, string> bookmarks)
        {
            InitializeComponent();
            // Foreach key in dict
            foreach (var key in bookmarks.Keys)
            {
                listBox_bookmarks.Items.Add($"{key}: {bookmarks[key]}");
            }
        }
        public void Select(string selectedFull)
        {
            // Get key from item
            selectedKey = selectedFull.Split(':')[0];


            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select(listBox_bookmarks.SelectedItem.ToString());
        }

        private void listBox_bookmarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Select(listBox_bookmarks.SelectedItem.ToString());

        }

        private void listBox_bookmarks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBox_bookmarks.SelectedIndex < 0)
                    listBox_bookmarks.SelectedIndex = listBox_bookmarks.IndexFromPoint(e.X, e.Y);
                Select(listBox_bookmarks.SelectedItem.ToString());
            }
        }
    }
}
