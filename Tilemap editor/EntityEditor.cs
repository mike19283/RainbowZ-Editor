using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class EntityEditor : Form
    {
        string filePath = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Level work\\Entities\\Entity Edit\\EntityEdit.txt";
        ROM rom;
        static byte[] paramCountLut = new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 1, 2, 0, 3, 1, 1, 1 };
        NumericUpDown[] value;
        List<EntityKeyValue> entityKeyValues;
        int pointer;
        List<string> history = new List<string>();

        public EntityEditor(ROM rom, int point)
        {
            InitializeComponent();
            numericUpDown_pointer.Value = point;
            this.rom = rom;
            value = new NumericUpDown[]
            {
                numericUpDown_value1,
                numericUpDown_value2,
                numericUpDown_value3,
            };
            button_apply.Visible = false;

            button_search_Click(0, new EventArgs());
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            button_apply.Visible = true;
            entityKeyValues = new List<EntityKeyValue>();
            int pointer = (int)numericUpDown_pointer.Value;
            string str = pointer.ToString("X");


            int offset = 0xb50000 | pointer;
            

            offset &= 0xffff;
            
            if (offset > 0x8000)
            {
                offset |= 0xb50000;
            }
            else
            {
                //0xbbb154 - scripts start
                int tempPointer = pointer * 4;
                offset = (int)rom.Read24(tempPointer + 0xbae0a7);
                //return new List<string>();
            }


            int times = 0;

            try
            {
                while (true)
                {
                    // To avoid infinite loops
                    if (times++ > 100)
                    {
                        throw new Exception("Timed out. Custom");
                    }
                    int mod = 0;
                    int key = rom.Read16(offset + mod);
                    mod += 2;
                    EntityKeyValue ekv = new EntityKeyValue(key, offset);
                    if (key >= 0x8000)
                    {
                        int commandIndex = key >> 8;
                        commandIndex &= 0x7f;
                        var @params = paramCountLut[commandIndex];
                        while (@params-- > 0)
                        {
                            ekv.values.Add(rom.Read16(offset + mod));
                            mod += 2;
                        }
                    }
                    else
                    {
                        ekv.values.Add(rom.Read16(offset + mod));
                        mod += 2;
                    }
                    offset += mod;
                    // Finally add to our list
                    entityKeyValues.Add(ekv);
                    if (key == 0x8000)
                    {
                        break;
                    }
                }

                listBox_initCodes.Items.Clear();
                listBox_initCodes.Items.AddRange(entityKeyValues.ToArray());
                listBox_initCodes.SelectedIndex = 0;

                if (!history.Contains(str))
                {
                    AddToHistory(str);
                }

            }
            catch (Exception ex)
            {
                numericUpDown_pointer.Value = this.pointer;
                MessageBox.Show($"{ex.Message}\n Error. Did you enter in a bad pointer?");
            }

            pointer = (int)numericUpDown_pointer.Value;
            listBox_history.SelectedIndex = 0;
        }

        private void listBox_initCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityKeyValue ekv = (EntityKeyValue)listBox_initCodes.SelectedItem;
            numericUpDown_key.Value = ekv.key;
            label_address.Text = ekv.address.ToString("X6");

            for (int i = 0; i < 3; i++)
            {
                if (i < ekv.values.Count)
                {
                    value[i].Enabled = true;
                    value[i].Value = ekv.values[i];
                }
                else
                {
                    value[i].Enabled = false;
                    value[i].Value = 0;

                }
            }

        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            int selection = listBox_initCodes.SelectedIndex;
            var ekv = (EntityKeyValue)listBox_initCodes.SelectedItem;
            int mod = 0;
            rom.Write16(ekv.address + mod, (int)numericUpDown_key.Value);
            mod += 2;
            for (int i = 0; i < ekv.values.Count; i++)
            {
                rom.Write16(ekv.address + mod, (int)value[i].Value);
                ekv.values[i] = (int)value[i].Value;
                mod += 2;
            }
            if (Global.mod)
            {

                var file = File.ReadAllLines(filePath).ToList();
                string thisAddress = $"\t//{((int)(numericUpDown_pointer.Value)).ToString("X")}";
                DeleteIfRepeat(file, thisAddress);
                file.Add(thisAddress);
                file.Add($"\t.addr 0x{ekv.address.ToString("X")}");
                file.Add($"\t.data16\t0x{ekv.key.ToString("X4")}");
                foreach (var value in ekv.values)
                {
                    file.Add($"\t.data16\t0x{value.ToString("X4")}");
                }
                file.Add("");
                File.WriteAllLines(filePath, file.ToArray());
            }

            button_search_Click(0, new EventArgs());
            listBox_initCodes.SelectedIndex = selection;
            
        }

        private void DeleteIfRepeat(List<string> file, string thisAddress)
        {
            int addrIndex = file.IndexOf(thisAddress);
            if (addrIndex != -1)
            {
                do
                {
                    file.RemoveAt(addrIndex);
                } while (addrIndex < file.Count && !file[addrIndex].Contains("//"));
            }
        }

        private void numericUpDown_pointer_ValueChanged(object sender, EventArgs e)
        {
            //button_apply.Visible = false;
        }

        private void listBox_initCodes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = (EntityKeyValue)listBox_initCodes.SelectedItem;
            switch (selected.key)
            {
                case 0x8100:
                    MessageBox.Show("Not implemented yet");
                    break;
                case 0x8800:
                    var pEdit = new Palette_Editor(rom, rom.sd, selected.values[0], false);
                    pEdit.ClickGetPalette();
                    pEdit.ShowDialog();
                    break;
                case 0x8200:
                    pointer = (int)numericUpDown_pointer.Value;
                    numericUpDown_pointer.Value = selected.values[0];
                    button_search_Click(0, new EventArgs());
                    break;
                default:
                    if (selected.values[0] < 0x8000)
                    {
                        MessageBox.Show("Error. Invalid");
                        return;
                    }

                    pointer = (int)numericUpDown_pointer.Value;
                    
                    numericUpDown_pointer.Value = selected.values[0];
                    button_search_Click(0, new EventArgs());
                    break;
            }
        }

        private void listBox_initCodes_MouseDown(object sender, MouseEventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                listBox_initCodes_MouseDoubleClick(0, new MouseEventArgs(MouseButtons.Left,0,0,0,0));
            }

        }

        void AddToHistory(string str)
        {
            history.Insert(0, str);
            listBox_history.Items.Clear();
            listBox_history.Items.AddRange(history.ToArray());
        }

        private void listBox_history_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox_history_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int pointer = Convert.ToInt32(listBox_history.SelectedItem.ToString(), 16);
            numericUpDown_pointer.Value = pointer;
            button_search_Click(0, new EventArgs());
        }
        public void MoveEntity (int x,int y)
        {

        }

        private void listBox_history_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBox_history_MouseDoubleClick(0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            }
        }
    }
    public class EntityKeyValue
    {
        public int key;
        public List<int> values;
        public int address;
        private Dictionary<int, string> keyNames = new Dictionary<int, string>()
        {
            [0xe89] = "X Speed",
            [0xef1] = "Y Speed",
            [0xf25] = "X Speed Limit",
        };

        public EntityKeyValue(int key, int address)
        {
            this.key = key;
            this.address = address;
            this.values = new List<int>();
        }
        public override string ToString()
        {
            string local = key.ToString("X4");
            string @return = $"[{local}]";
            if (key >= 0x8000)
                @return += "*";
            if (keyNames.ContainsKey(key))
            {
                //@return = $"[{keyNames[key]}/{local}]";
            }
            foreach (var value in values)
            {
                @return += $", {value.ToString("X4")}";
            }
            return @return;
        }


    }
}
