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
    public partial class EntityEdit_ScriptEdi : Form
    {
        ROM rom;
        int address;
        DKCLevel thisLevel;
        List<Entity> scriptE = new List<Entity>();
        Form1 form;

        public EntityEdit_ScriptEdi(ROM rom, int address, DKCLevel thisLevel, Form1 form)
        {
            InitializeComponent();
            this.rom = rom;
            this.thisLevel = thisLevel;
            this.address = address;
            this.form = form;

            for (int i = address; rom.Read16(i) != 0; i += 8)
            {
                Entity entity = new Entity(i, rom, thisLevel);
                scriptE.Add(entity);
            }
            listBox_entities.Items.AddRange(scriptE.ToArray());

            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_entities.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                var entity = (Entity)listBox_entities.SelectedItem;
                numericUpDown_entityX.Value = Math.Abs(entity.x);
                numericUpDown_entityY.Value = Math.Abs(entity.y);
                numericUpDown_entityPointer.Value = Math.Abs(entity.pointer);
                label_address.Text = entity.address.ToString("X6");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button_selectEntity_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, (int)numericUpDown_entityPointer.Value);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_entityPointer.Value = value;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }


        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            if (numericUpDown_entityPointer.Value < 0x8000)
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    form.LoadSch1eyBins();
                }
                else
                {
                    return;
                }
            }
            var entity = (Entity)listBox_entities.SelectedItem;
            entity.x = (int)numericUpDown_entityX.Value;
            entity.y = (int)numericUpDown_entityY.Value;
            entity.pointer = (int)numericUpDown_entityPointer.Value;
            var address = entity.address;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            string str = (address).ToString("x");
            //Clipboard.SetText(str);
            Global.entityEdit = true;
            entity.WriteToROM();

            int pointer = (int)numericUpDown_entityPointer.Value;

            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(scriptE.ToArray());
            listBox_entities.SelectedIndex = index;


        }
    }
}
