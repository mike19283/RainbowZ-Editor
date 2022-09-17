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
    public partial class EntityEditVertical : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;
        int layer;

        public EntityEditVertical(DKCLevel thisLevel, ROM rom, Form1 form, int layer)
        {
            InitializeComponent();
            this.Text += $" Layer {layer}";
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;
            this.layer = layer;

            var lay = thisLevel.verticalLayers[layer];
            listBox_entities.Items.AddRange(lay.entities.ToArray());
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var entity = (Entity)listBox_entities.SelectedItem;
            numericUpDown_entityType.Value = entity.type;
            numericUpDown_entityX.Value = entity.x;
            numericUpDown_entityY.Value = entity.y;
            numericUpDown_entityPointer.Value = entity.pointer;
            button_openPalette.Enabled = entity.palettePointer != 0;
        }

        private void button_selectEntity_Click(object sender, EventArgs e)
        {
            Popup pop = new Popup(rom, (int)numericUpDown_entityPointer.Value);
            if (pop.ShowDialog() == DialogResult.OK)
            {
                string select = pop.@object;
                int index = rom.objectIndexByString[select];
                numericUpDown_entityPointer.Value = rom.objectCodeByIndex[index];

            }

        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var entity = (Entity)listBox_entities.SelectedItem;
            entity.type = (int)numericUpDown_entityType.Value;
            entity.x = (int)numericUpDown_entityX.Value;
            entity.y = (int)numericUpDown_entityY.Value;
            entity.pointer = (int)numericUpDown_entityPointer.Value;
            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.verticalLayers[layer].entities.ToArray());
            listBox_entities.SelectedIndex = index;
        }

        private void button_editor_Click(object sender, EventArgs e)
        {
            EntityEditor editor = new EntityEditor(rom, (int)numericUpDown_entityPointer.Value);

            editor.ShowDialog();
        }

        private void listBox_entities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_editor_Click(0, new EventArgs());
        }


        private void listBox_entities_MouseDown(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                button_editor_Click(0, new EventArgs());

            }

        }

        public void SelectEntity(int num)
        {
            listBox_entities.SelectedIndex = num;
        }

        public void MoveEntity(int x, int y, bool snap)
        {
            if (!snap)
            {
                numericUpDown_entityX.Value = x;
                numericUpDown_entityY.Value = y;
            }
            else
            {
                int ogX = (int)numericUpDown_entityX.Value;
                int ogY = (int)numericUpDown_entityY.Value;
                var pnt = Global.MoveSnapPoint(ogX, ogY, x, y, form.snapPrecision);
                numericUpDown_entityX.Value = pnt.X;
                numericUpDown_entityY.Value = pnt.Y;
            }
            numericUpDown_entityX.Refresh();
            numericUpDown_entityY.Refresh();
            button_apply_Click(0, new EventArgs());
        }

        private void button_getAddress_Click(object sender, EventArgs e)
        {
            var entity = (Entity)listBox_entities.SelectedItem;
            int addr = entity.address;
            addr &= (addr > 0x7fffff ? 0x3fffff : 0xffffff);
            string str = addr.ToString("X");
            Clipboard.Clear();
            Clipboard.SetText(str); 
            Clipboard.SetText(str); 
            Clipboard.SetText(str); 
        }
        public int GetListboxSize() => listBox_entities.Items.Count;
        public void MoveEntity(Entity edit, List<VerticalLayer> editVList)
        {
            int index = 0;
            int layer = edit.layer;
            var lists = editVList.Where((e, i) => e.index < layer).ToArray();
            foreach (var l in lists)
            {
                index += l.entities.Count;
            }
            index = edit.local - index - 1;

            listBox_entities.Items[index] = edit;

            numericUpDown_entityX.Value = edit.x;
            numericUpDown_entityY.Value = edit.y;
        }

        private void button_openPalette_Click(object sender, EventArgs e)
        {
            var entity = (Entity)listBox_entities.SelectedItem;
            int x = entity.palettePointer;
            Palette_Editor pEdit = new Palette_Editor(rom, rom.sd, x, false);
            pEdit.ClickGetPalette();
            pEdit.ShowDialog();

        }
    }
}
