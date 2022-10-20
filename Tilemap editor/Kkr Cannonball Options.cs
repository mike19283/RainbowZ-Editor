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
    public partial class Kkr_Cannonball_Options : Form
    {
        //16b-16e animals
        //dead random animals
        //abcd random enemies
        public int option = 0x16b;
        int[] optionsArray = new int[] 
        {
            0x16b, 0x16c, 0x16d, 0x16e,
            0xdead,
            0xabcd,
        };
        public Kkr_Cannonball_Options()
        {
            InitializeComponent();
            comboBox_cannonballSelect.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            option = optionsArray[comboBox_cannonballSelect.SelectedIndex];
            this.DialogResult = DialogResult.OK;
        }

    }
}
