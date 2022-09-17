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
    public partial class PerilsRandomTerrain : Form
    {
        ROM rom;
        string[] perils = new string[0x18];
        public PerilsRandomTerrain(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            GetArray(rom);

        }

        private void GetArray(ROM rom)
        {
            for (int i = 0; i < 0x18; i++)
            {
                int offset = i * 8 + 0x10ee96;
                var arr = rom.rom.Skip(offset).Take(8).ToArray();
                var byteStr = arr.Select(e => e.ToString("X2")).ToArray();
                string str = string.Join(" ", byteStr);
                perils[i] = str;

                listBox_perilsRandomTerrain.Items.Add(i.ToString("X2"));

            }
            listBox_perilsRandomTerrain.Items.Clear();
            listBox_perilsRandomTerrain.Items.AddRange(perils);
        }

        private void button_perilsRandomTerrain_Click(object sender, EventArgs e)
        {
            var txt = textBox_perilsRandomTerrain.Text;

            var arr = txt.Split(' ');
            var byteArr = arr.Select(el => Convert.ToByte(el, 16)).ToArray();
            string str = "0x" + string.Join(",0x", arr);
            Clipboard.Clear();
            Clipboard.SetText(str);
            int offset = listBox_perilsRandomTerrain.SelectedIndex * 8 + 0x10ee96;
            rom.WriteArrToROM(byteArr, offset);

            GetArray(rom);
        }

        private void listBox_perilsRandomTerrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_perilsRandomTerrain.Text = perils[listBox_perilsRandomTerrain.SelectedIndex];
            label_index.Text = listBox_perilsRandomTerrain.SelectedIndex.ToString("X2");
        }
    }
}
