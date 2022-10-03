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
    public partial class Entrances : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;

        public Entrances(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;

            var arr = thisLevel.entrances;//.Where(e => !($"{e}".Contains("ave") || $"{e}".Contains("Kong") || $"{e}".Contains("tree")) && e.entranceCode != 0x16);

            listBox_entities.Items.AddRange(arr.ToArray());
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var entrance = (Entrance)listBox_entities.SelectedItem;
            numericUpDown_entranceX.Value = entrance.x;
            numericUpDown_entranceY.Value = entrance.y;
            label_address.Text = entrance.address.ToString("X6");
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var entrance = (Entrance)listBox_entities.SelectedItem;
            entrance.x = (int)numericUpDown_entranceX.Value;
            entrance.y = (int)numericUpDown_entranceY.Value;
            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.entrances.ToArray());
            listBox_entities.SelectedIndex = index;
        }
        public void SelectEntrance(Entrance entrance)
        {
            listBox_entities.SelectedIndex = entrance.local;
        }
        public void MoveEntity(int x, int y)
        {
            if (numericUpDown_entranceX.Value + x < 0)
                x = 0;
            numericUpDown_entranceX.Value += x;
            if (numericUpDown_entranceY.Value + y < 0)
                y = 0;
            numericUpDown_entranceY.Value += y;

            button_apply_Click(0, new EventArgs());

        }

    }
}
