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
    public partial class EntityEdit : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;
        List<int> commonEntities;
        List<int> commonEntitiesType;
        string lvlName;

        public EntityEdit(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            try
            {
                InitializeComponent();
                commonEntities = form.commonEntities;
                commonEntitiesType = form.commonEntitiesType;
                this.thisLevel = thisLevel;
                this.rom = rom;
                this.form = form;

                label_extrasAvailable.Text = $"Extras\nAvailable:\n{thisLevel.extraEntitiesAvailable.ToString("X")}";
                lvlName = thisLevel.lvlName;
                

                listBox_entities.Items.Clear();
                listBox_entities.Items.AddRange(thisLevel.entities.ToArray());
                listBox_entities.SelectedIndex = 0;

                string commonStr = rom.sd.Read("Common", lvlName);
                string[] spl = commonStr.Split(',');
                var pointers = spl.Select(el => Convert.ToInt32(el, 16)).ToList();
                //commonEntities = pointers;
            } catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            var names = commonEntities.Select(el => rom.objectStringByPointer[el]).ToArray();
            listBox_common.Items.AddRange(names);
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                var entity = (Entity)listBox_entities.SelectedItem;
                numericUpDown_entityType.Value = Math.Abs(entity.type);
                numericUpDown_entityX.Value = Math.Abs(entity.x);
                numericUpDown_entityY.Value = Math.Abs(entity.y);
                numericUpDown_entityPointer.Value = Math.Abs(entity.pointer);
                button_openPalette.Enabled = entity.palettePointer != 0;
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
                    if (value == 0x23 || (value >= 0x25 && value <= 0x27)
                        || (value >= 0x132 && value <= 0x137)
                        || value == 0x1f || value == 0x21 || value == 0x22
                        || (index >= 0x31e && index <= 0x33b)
                        || (index >= 0x1 && index <= 0xe6))
                    {
                        numericUpDown_entityType.Value = 2;
                    }
                    if (value == 0xe0ab || value == 0xe0c1 || value == 0xe0d7 || value == 0xe07f || value == 0xe095)
                    {
                        numericUpDown_entityType.Value = 0xd;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            entity.type = (int)numericUpDown_entityType.Value;
            entity.x = (int)numericUpDown_entityX.Value;
            entity.y = (int)numericUpDown_entityY.Value;
            entity.pointer = (int)numericUpDown_entityPointer.Value;
            var address = entity.address;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            string str = (address).ToString("x");
            //Clipboard.SetText(str);
            Global.entityEdit = true;

            int pointer = (int)numericUpDown_entityPointer.Value;

            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.entities.ToArray());
            listBox_entities.SelectedIndex = index;

            int type = (int)numericUpDown_entityType.Value;
            if (commonEntities.Contains(pointer) || entity.type == 2)
            {
                return;
            }
            commonEntities.Add(pointer);
            commonEntitiesType.Add(type);
            try
            {
                listBox_common.Items.Add(rom.objectStringByPointer[pointer]);
            }
            catch { }
            var asString = commonEntities.Select(el => el.ToString("X4")).ToArray();
            var asStr = String.Join(",", asString);
            rom.sd.Write("Common", lvlName, asStr);
            rom.sd.SaveRbs();
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
                //button_editor_Click(0, new EventArgs());
                button_selectEntity_Click(0, new EventArgs());
            }

        }
        public void SelectEntity (int num)
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

        private void numericUpDown_entityPointer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_apply_Click(0, new EventArgs());
            }
        }

        private void listBox_common_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_common.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            numericUpDown_entityPointer.Value = commonEntities[index];
            numericUpDown_entityType.Value = commonEntitiesType[index];
        }

        private void listBox_common_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox_common.SelectedIndex;
                if (index == -1)
                {
                    return;
                }
                commonEntities.RemoveAt(index);
                commonEntitiesType.RemoveAt(index);
                listBox_common.Items.RemoveAt(index);

                // Write to sd and save
                var asStringArr = commonEntities.Select(el => el.ToString("X4")).ToArray();
                var asStr = String.Join(",", asStringArr);
                rom.sd.Write("Common", lvlName, asStr);
                rom.sd.SaveRbs();
            }
        }

        private void button_addLevelToCommon_Click(object sender, EventArgs e)
        {
            int current = listBox_entities.SelectedIndex;
            int size = listBox_entities.Items.Count;
            for (int i = 0; i < size; i++)
            {
                listBox_entities.SelectedIndex = i;
                numericUpDown_entityPointer.Refresh();
                button_apply_Click(0, new EventArgs());
            }
            listBox_entities.SelectedIndex = current;
            numericUpDown_entityPointer.Refresh();
            button_apply_Click(0, new EventArgs());
        }

        private void button_maxX_Click(object sender, EventArgs e)
        {
            Entity ent = (Entity)listBox_entities.Items[listBox_entities.Items.Count - 1];
            int size = ent.x + 1;
            size = (size > 0xffff) ? 0xffff : size;
            numericUpDown_entityX.Value = 0x7fff;
            numericUpDown_entityX.Value = size;
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
        }
        public void MoveEntity(Entity edit)
        {
            int index = edit.local;
            listBox_entities.Items[index] = edit;

            numericUpDown_entityX.Value = edit.x;
            numericUpDown_entityY.Value = edit.y;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (listBox_entities.Items.Count <= 1)
            {
                MessageBox.Show("There must be at least 1 entity!");
                return;
            }
            int index = listBox_entities.SelectedIndex;
            if (index == -1)
            {
                index = 0;
            }
            var obj = listBox_entities.Items[index];
            //listBox_entities.Items.Remove(obj);
            thisLevel.entities.RemoveAt(index);
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(thisLevel.entities.ToArray());

            listBox_entities.SelectedIndex = 0;
            //form.Level_select_Click(0, new EventArgs());

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string toAddStr = Prompt.ShowDialog("How many do you want to add?", "Entity");
            int count = Convert.ToInt32(toAddStr, 16);
            if (count > thisLevel.extraEntitiesAvailable)
            {
                MessageBox.Show("Too many");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Entity ent = CreateNullEntity(i);
                listBox_entities.Items.Add(ent);
                thisLevel.entities.Add(ent);

            }

            thisLevel = null;
            form.Level_select_Click(0, new EventArgs());
            //form.Level_select_Click(0, new EventArgs());
        }
        private Entity CreateNullEntity (int count)
        {
            Entity @return = new Entity();
            @return.local = Entity.counter++;
            @return.type = 1;
            @return.pointer = 0;
            @return.y = 256;

            var panel = form.GetPanel();
            int panelX = panel.HorizontalScroll.Value;
            int xPos = (panelX) + (thisLevel.lvlXBoundStart & 0xffff) + count * 0x20 + 0x100 + 8;
            @return.x = xPos;
            @return.rom = rom;

            return @return;
        }

        private void button_openPalette_Click(object sender, EventArgs e)
        {
            var entity = (Entity)listBox_entities.SelectedItem;
            int x = entity.palettePointer;
            Palette_Editor pEdit = new Palette_Editor(rom, rom.sd, x, false);
            pEdit.ClickGetPalette();
            pEdit.ShowDialog();
        }

        private void levelCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    class CommonEntities
    {
        public int type;
        public int pointer;

    }
}
