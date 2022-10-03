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
    public partial class PathEdit : Form
    {
        ROM rom;
        DKCLevel thisLevel;
        Form1 form;
        List<PlatformPath> platformPaths;
        int group;

        public PathEdit(DKCLevel thisLevel, ROM rom, Form1 form, List<PlatformPath> platformPaths, int group)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.form = form;
            var temp = (new List<PlatformPath>(platformPaths));
            this.group = group;

            //temp.RemoveAt(0);
            this.platformPaths = temp;


            listBox_entities.Items.AddRange(thisLevel.platformPaths[group].ToArray());
            listBox_entities.SelectedIndex = 0;
        }

        private void listBox_entities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = listBox_entities.SelectedIndex;
            if (index == -1)
                return;
            var path = (PlatformPath)listBox_entities.SelectedItem;
            numericUpDown_command.Value = path.command;
            numericUpDown_X.Visible = true;
            numericUpDown_Y.Visible = true;
            numericUpDown_speed.Visible = true;
            label_x.Text = "X";
            switch (path.command)
            {
                case 0xffff:
                    numericUpDown_X.Visible = false;
                    numericUpDown_Y.Visible = false;
                    numericUpDown_speed.Visible = false;
                    break;
                case 0xfffe:
                    numericUpDown_X.Value = path.x;
                    numericUpDown_Y.Value = path.y;
                    numericUpDown_speed.Value = path.speed;
                    break;
                case 0xfffd:
                    numericUpDown_Y.Visible = false;
                    numericUpDown_speed.Visible = false;
                    numericUpDown_X.Value = path.loopPointer;
                    label_x.Text = "Loop pointer";
                    break;
                default:
                    numericUpDown_X.Value = path.x;
                    numericUpDown_Y.Value = path.y;
                    numericUpDown_speed.Visible = false;
                    break;
            }
            label_address.Text = path.address.ToString("X");

            //numericUpDown_start.Value = listBox_entities.SelectedIndex + 1;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var path = (PlatformPath)listBox_entities.SelectedItem;
            path.command = (int)numericUpDown_command.Value;
            switch (path.command)
            {
                case 0xfffd:
                    try
                    {
                        int pointer;
                        //path.loopPointer = (int)numericUpDown_X.Value;
                        if (numericUpDown_X.Value > 0x8000)
                        {
                            pointer = (int)numericUpDown_X.Value;
                        }
                        else
                        {
                            pointer = ((PlatformPath)listBox_entities.Items[(int)numericUpDown_X.Value]).address & 0xffff;
                        }
                        path.loopPointer = pointer;
                    }
                    catch { }
                    break;
                case 0xfffe:
                    path.x = (int)numericUpDown_X.Value;
                    path.y = (int)numericUpDown_Y.Value;
                    path.speed = (int)numericUpDown_speed.Value;
                    break;
                case 0xffff:
                    break;
                default:
                    path.x = (int)numericUpDown_X.Value;
                    path.y = (int)numericUpDown_Y.Value;
                    path.speed = (int)numericUpDown_speed.Value;
                    break;
            }

            form.DrawScreen();
            int index = listBox_entities.SelectedIndex;
            listBox_entities.Items.Clear();
            listBox_entities.Items.AddRange(platformPaths.ToArray());
            listBox_entities.SelectedIndex = index;
        }

        private void button_multiple_Click(object sender, EventArgs e)
        {
            int value, index;
            NumericUpDown[] arr = new NumericUpDown[]
            {
                numericUpDown_X,
                numericUpDown_Y,
                numericUpDown_speed,
            };
            if (radioButton_x.Checked)
            {
                value = (int)numericUpDown_X.Value;
                index = 0;
            }
            else if (radioButton_y.Checked)
            {
                value = (int)numericUpDown_Y.Value;
                index = 1;
            }
            else
            {
                value = (int)numericUpDown_speed.Value;
                index = 2;
            }
            var startStr = Prompt.ShowDialog("Choose start", "[Start");
            if (startStr == "")
                return;
            var endStr = Prompt.ShowDialog("Choose end", "end)");
            if (startStr == "" || endStr == "")
                return;
            var start = Convert.ToInt32(startStr, 16);
            var end = Convert.ToInt32(endStr, 16);
            for (int i = start; i < end; i++)
            {
                listBox_entities.SelectedIndex = i;
                var path = (PlatformPath)listBox_entities.SelectedItem;
                if (path.command == 0 || path.command == 0xfffd)
                    continue;
                arr[index].Value = value;
                button_apply_Click(0, new EventArgs());
            }
        }

        private void PathEdit_Load(object sender, EventArgs e)
        {

        }
        public void SelectPath(int num)
        {
            listBox_entities.SelectedIndex = num;
        }
        public void MoveEntity(int x, int y, bool snap)
        {
            if (!snap)
            {
                numericUpDown_X.Value = x;
                numericUpDown_Y.Value = y;
            }
            else
            {
                int ogX = (int)numericUpDown_X.Value;
                int ogY = (int)numericUpDown_Y.Value;
                var pnt = Global.MoveSnapPoint(ogX, ogY, x, y, form.snapPrecision);
                numericUpDown_X.Value = pnt.X;
                numericUpDown_Y.Value = pnt.Y;
            }
            numericUpDown_X.Refresh();
            numericUpDown_Y.Refresh();
            button_apply_Click(0, new EventArgs());

        }
        public void RefreshMouseListbox()
        {
            listBox_entities_SelectedIndexChanged(0, new EventArgs());
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var newPath = new PlatformPath();
            int index = listBox_entities.SelectedIndex;
            thisLevel.platformPaths[group].Insert(index, newPath);
            RefreshListbox();
            

            //form.Level_select_Click(0, new EventArgs());
            listBox_entities.SelectedIndex = index;

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int index = listBox_entities.SelectedIndex;
            if (index >= listBox_entities.Items.Count - 2)
                return;
            listBox_entities.Items.RemoveAt(index);
            thisLevel.platformPaths[group].RemoveAt(index);
            RefreshListbox();
            listBox_entities.SelectedIndex = index;
        }

        private void button_moveDown_Click(object sender, EventArgs e)
        {
            int index = listBox_entities.SelectedIndex;
            if (index == listBox_entities.Items.Count - 1 || index < 0)
            {
                return;
            }
            thisLevel.platformPaths[group].Insert(index + 2, thisLevel.platformPaths[group][index]);
            thisLevel.platformPaths[group].RemoveAt(index);

            RefreshListbox();

            listBox_entities.SelectedIndex = index + 1;
                
        }

        private void button_moveUp_Click(object sender, EventArgs e)
        {
            int index = listBox_entities.SelectedIndex;
            if (index <= 0)
            {
                return;
            }
            PlatformPath temp = (PlatformPath)listBox_entities.SelectedItem;
            thisLevel.platformPaths[group].RemoveAt(index);
            thisLevel.platformPaths[group].Insert(index - 1, temp);

            RefreshListbox();

            listBox_entities.SelectedIndex = index - 1;

        }
        public void RefreshListbox()
        {
            listBox_entities.Items.Clear();

            listBox_entities.Items.AddRange(thisLevel.platformPaths[group].ToArray());
            listBox_entities.SelectedIndex = 0;

        }
    }
}
