//[116d] - phase pointer k rool
//152d = 2  - reset
//116d on kkr room, 152d on kkr
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
    public partial class K_Rool_Edit : Form
    {
        ROM rom;
        List<KkrIndex> data = new List<KkrIndex>();
        // Og address 0xb6eb45
        int customAddress = 0xFF6261;
        //int customAddress = 0xb6eb45;
        //int customAddress = 0xdce9e0;
        int previousIndex = -1;
        int nextIndirect = 0xff7000;
        int nextCannonball = 0xff7a00;
        List<byte> backup;
        bool focusBoolMain = false;
        Form1 form;
        List<int> usedCball = new List<int>();
        int startCannonball = 0xff7600;
        bool overflow;
        int enemyGroupIndex = 0;

        public K_Rool_Edit(ROM rom, Form1 form)
        {
            InitializeComponent();
            this.form = form;
            this.rom = rom;
            loadFromEOMToolStripMenuItem_Click(0, new EventArgs());
            backup = rom.Clone();
            AddHotKeyToAll(this);
            listBox_enemyGroup.SelectedIndex = 0;

            int kkrKredits = rom.Read16LDA(0xb6d150);
            //rom.Write8(0x81d323, 0x6b);

            fakeCreditsToolStripMenuItem.Checked = kkrKredits == 0x0;

            enableToolStripMenuItem.Checked = rom.CheckSignature();
        }
        private void ReadArray(byte[] arr)
        {
            List<KkrIndex> toRead = new List<KkrIndex>();
            bool end = false;
            int index = 0, highest = 0xff7000, highestCBall = 0xff7a00 - 0x100;
            nextIndirect = 0xff7000;
            //nextCannonball = 0xff7a00 - 0x100;
            do
            {
                KkrIndex kkrIndex = new KkrIndex();
                kkrIndex.SetIndex(index);
                kkrIndex.address = customAddress + index;
                bool tempB = Global.Read16(index, arr) != 0;
                int temp16 = 0, tempBank = 0, tempSize = 0, tempType = 0;

                while (tempB)
                {
                    int key = Global.Read16(index, arr);
                    index += 2;
                    int value = Global.Read16(index, arr);
                    index += 2;
                    if (key == 0x130d)
                    {
                        kkrIndex.SetType(value);
                        tempType = value;
                    }
                    if (key == 0x145d)
                        temp16 = value;
                    if (key == 0x1491)
                        tempBank = value;
                    if (key == 0x1341)
                        tempSize = value;

                    kkrIndex.AddKeyValuePair(key, value);

                    tempB = Global.Read16(index, arr) != 0;
                }

                if (temp16 >= 0x7000 && tempBank >= 0xff && tempType == 0x9)
                {
                    int tempAddress = (tempBank << 16) | temp16 + 10 * tempSize;
                    if (tempAddress > highest)
                    {
                        highest = tempAddress;
                    }

                }
                if (temp16 >= 0x7000 && tempBank >= 0xff && tempType == 0xb)
                {
                    int tempAddress = ((tempBank << 16) | temp16);
                    if (usedCball.IndexOf(tempAddress) == -1)
                    {
                        usedCball.Add(tempAddress);
                    }
                    //if (tempAddress > highestCBall)
                    //{
                    //    highestCBall = tempAddress;
                    //}

                }
                index += 4;
                toRead.Add(kkrIndex);
                end = Global.Read16(index - 2, arr) != 0;
            } while (end);
            data = toRead;

            nextIndirect = highest + 10;
            //nextCannonball = highestCBall;
        }
        private void loadFromEOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int offset = ReadArrAddressFromROM();
            var arr = rom.ReadSubArray(offset, 0x1000, rom.rom.ToArray());
            ReadArray(arr);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = 0;
        }
        private int ReadArrAddressFromROM()
        {
            if (Global.mod)
            {
                return 0xff6261;
            }
            int _16bit = rom.Read16(0xb6e84d);
            int bank = rom.Read16(0xb6e852);
            int offset = (bank << 16) + (_16bit);

            return offset;
        }
        private void WriteArrAddressToROM(int address)
        {

            int _16bit = address & 0xffff;
            int bank = address >> 16;
            rom.Write16(0xb6e84d, _16bit);
            rom.Write16(0xb6e852, bank);
        }
        private void ConvertToArr()
        {
            List<byte> converted = new List<byte>();
        }

        private void FillListbox()
        {
            var curr = data[comboBox_selectedIndex.SelectedIndex];


            listBox_data.Items.Clear();
            foreach (var kvp in curr.kvp)
            {
                listBox_data.Items.Add(kvp);
            }

            label_address.Text = curr.address.ToString("X");


            label_roughOG.Text = Global.HexToString(curr.GetIndex());
        }
        private void SetCombobox()
        {
            comboBox_selectedIndex.Items.Clear();
            int[] arr = new int[data.Count];
            Global.FillWithIndices(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                comboBox_selectedIndex.Items.Add($"{Global.HexToString(i)} - {data[i].GetType()}");
            }
        }


        private void saveToROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox_selectedIndex.SelectedIndex = 0;
            var arr = GetByteArrayToBeSaved();
            WriteArrAddressToROM(customAddress);
            rom.WriteArrToROM(arr, customAddress);
            //MessageBox.Show("Saved!");
        }

        private void comboBox_selectedIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillListbox();

            listBox_data.SelectedIndex = 0;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature() && (numericUpDown_key.Value >= 0x8000))
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

            // Which are we looking at?
            // First select array
            var arr = data[comboBox_selectedIndex.SelectedIndex];
            // Now select key value pair
            var keyValue = arr.kvp[listBox_data.SelectedIndex];

            keyValue.key = (int)numericUpDown_key.Value;
            keyValue.value = (int)numericUpDown_value.Value;

            var arr2 = GetByteArrayToBeSaved(); //
            WriteArrAddressToROM(customAddress); //
            rom.WriteArrToROM(arr2, customAddress); //
            ReadArray(arr2);
            //comboBox_selectedIndex.SelectedIndex = 0;
            var index = comboBox_selectedIndex.SelectedIndex;
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = index;
            RefreshListbox();
            //MessageBox.Show("Applied!");
            RefreshListbox();
        }
        private byte[] GetByteArrayToBeSaved()
        {
            List<byte> @return = new List<byte>();
            int index = 0;
            // Loop through indices
            for (int i = 0; i < data.Count; i++)
            {
                KkrIndex d = data[i];
                // d = each index, loop through dictionary 
                foreach (var kv in d.kvp)
                {
                    var k = kv.key;
                    var v = kv.value;

                    @return.Add((byte)(k >> 0));
                    @return.Add((byte)(k >> 8));
                    @return.Add((byte)(v >> 0));
                    @return.Add((byte)(v >> 8));

                    index += 4;
                }
                index += 4;
                @return.Add(0);
                @return.Add(0);
                if (i != data.Count - 1)
                {
                    @return.Add((byte)(index >> 0));
                    @return.Add((byte)(index >> 8));
                }
                else
                {
                    @return.Add(0);
                    @return.Add(0);
                }
            }



            return @return.ToArray();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0, 0);
            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (comboBox_selectedIndex.Items.Count == 1)
                return;
            var temp = comboBox_selectedIndex.SelectedIndex;
            var tempItems = comboBox_selectedIndex.Items.Count;
            data.RemoveAt(comboBox_selectedIndex.SelectedIndex);
            SetCombobox();
            if (temp == tempItems - 1)
            {
                comboBox_selectedIndex.SelectedIndex = temp - 1;
                comboBox_selectedIndex.Focus();
            }
            else
            {
                comboBox_selectedIndex.SelectedIndex = temp;
            }
        }

        private void listBox_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curr = data[comboBox_selectedIndex.SelectedIndex];
            var kvp = curr.kvp[listBox_data.SelectedIndex];
            numericUpDown_key.Value = kvp.key;
            numericUpDown_value.Value = kvp.value;
            if (focusBoolMain)
            {
                numericUpDown_value.Focus();
                numericUpDown_value.Select(4, 4);
            }
        }

        private void listBox_data_MouseDown(object sender, MouseEventArgs e)
        {
            focusBoolMain = true;

            var curr = data[comboBox_selectedIndex.SelectedIndex];
            var kvp = curr.kvp[listBox_data.SelectedIndex];

            if (e.Button == MouseButtons.Right && (kvp.key == 0x145d || kvp.key == 0x0100))
            {
                tabControlkkreditor.SelectedIndex = curr.GetTypeNum() == 9 ? 1 : 2;
                if (curr.GetTypeNum() == 0x9)
                {
                    int _16Bit = curr.kvp[curr.SearchInList(0x145d)].value;
                    int bank = curr.kvp[curr.SearchInList(0x1491)].value;
                    int address = (bank << 16) | _16Bit;

                    numericUpDown_pointer.Value = address;

                    Goto();
                }
                else if (curr.GetTypeNum() == 0xb)
                {
                    int _16Bit = curr.kvp[curr.SearchInList(0x145d)].value;
                    int bank = curr.kvp[curr.SearchInList(0x1491)].value;
                    int address = (bank << 16) | _16Bit;

                    numericUpDown_cballPointer.Value = address;
                    CBallGoto();
                }
                else if (curr.GetTypeNum() == 0x8005 || curr.GetTypeNum() == 0x8008)
                {
                    tabControlkkreditor.SelectedIndex = 3;
                    listBox_enemyGroup.SelectedIndex = curr.kvp[curr.SearchInList(0x0100)].value;
                }
            }

        }

        private void button_applyIndirect_Click(object sender, EventArgs e)
        {
            if (numericUpDown_pointer.Value == 0)
            {
                return;
            }
            int e89 = (int)numericUpDown_e89.Value;
            int ef1 = (int)numericUpDown_ef1.Value;
            int f8d = (int)numericUpDown_f8d.Value;
            int e21 = (int)numericUpDown_e21.Value;
            int anim = (int)numericUpDown_animationPointer.Value;
            int address = (int)numericUpDown_pointer.Value;
            rom.Write16(address + 0, e89);
            rom.Write16(address + 2, ef1);
            rom.Write16(address + 4, f8d);
            rom.Write16(address + 6, e21);
            rom.Write16(address + 8, anim);

            //MessageBox.Show("Applied!");

        }

        private void tabControlkkreditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlkkreditor.SelectedIndex)
            {
                case 4:
                    MiscModInit();
                    break;
                default:
                    numericUpDown_e89.Value = 0;
                    numericUpDown_ef1.Value = 0;
                    numericUpDown_f8d.Value = 0;
                    numericUpDown_e21.Value = 0;
                    numericUpDown_animationPointer.Value = 0;
                    numericUpDown_pointer.Value = 0;
                    numericUpDown_cballPointer.Value = 0;
                    numericUpDown_cballHeadKey.Value = 0;
                    numericUpDown_cballHeadValue.Value = 0;
                    numericUpDown_cballDataX.Value = 0;
                    listBox_cballHeader.Items.Clear();
                    listBox_cballData.Items.Clear();
                    break;
            }
        }

        private void button_indirect_Click(object sender, EventArgs e)
        {
            overflow = false;
            var tempIndex = comboBox_selectedIndex.SelectedIndex;
            var curr = data[comboBox_selectedIndex.SelectedIndex];
            var kvp = curr.kvp;
            int _16Bit = 0;
            int bank = 0;
            switch (curr.GetTypeNum())
            {
                case 0x9:
                    _16Bit = nextIndirect & 0xffff;
                    bank = nextIndirect >> 16;
                    break;
                case 0xb:
                    // Find unused
                    for (int i = startCannonball; i <= 0xff8000; i += 0x40)
                    {
                        if (i == 0xff8000)
                        {
                            MessageBox.Show("Overflow");
                            overflow = true;
                            return;
                        }
                        if (usedCball.IndexOf(i) == -1)
                        {
                            _16Bit = i & 0xffff;
                            bank = i >> 16;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            curr.AddKeyValuePair(0x145d, _16Bit);
            curr.AddKeyValuePair(0x1491, bank);
            var address = (bank << 16) | _16Bit;
            var arrJumps = new int[] { 0, 0, 0x70, 0x400, 0x1ac };
            var arrCball = new int[] { 0x9, 0xff00, 0x0040, 0xff60, 0x28, 0x28};
            for (int i = 0; i < curr.kvp.Count; i++)
            {
                if (curr.GetTypeNum() == 9)
                {
                    if (curr.kvp[i].key == 0x1341)
                    {
                        int times = curr.kvp[i].value;
                        while (times-- > 0)
                        {
                            rom.WriteArrOfIntsToROM(arrJumps, address);
                            address += 10;
                        }
                    }
                }
                else if (curr.GetTypeNum() == 0xb)
                {
                    var zeroes = Enumerable.Repeat((byte)0, 0x40).ToArray();
                    rom.WriteArrToROM(zeroes, address);
                    rom.WriteArrOfIntsToROM(arrCball, address);
                }
            }


            nextIndirect += 10;

            comboBox_selectedIndex_SelectedIndexChanged(0, new EventArgs());

            button_apply_Click(0, new EventArgs());
            loadFromEOMToolStripMenuItem_Click(0, new EventArgs());
            comboBox_selectedIndex.SelectedIndex = tempIndex;
        }
        private void Goto()
        {
            int address = (int)numericUpDown_pointer.Value;
            int e89 = rom.Read16(address + 0);
            int ef1 = rom.Read16(address + 2);
            int f8d = rom.Read16(address + 4);
            int e21 = rom.Read16(address + 6);
            int anim = rom.Read16(address + 8);
            numericUpDown_e89.Value = e89;
            numericUpDown_ef1.Value = ef1;
            numericUpDown_f8d.Value = f8d;
            numericUpDown_e21.Value = e21;
            numericUpDown_animationPointer.Value = anim;
            numericUpDown_startingX.Value = 0;
            numericUpDown_endingX.Value = 0;
        }

        private void button_goto_Click(object sender, EventArgs e)
        {
            Goto();
        }

        private void button_addKvp_Click(object sender, EventArgs e)
        {
            var curr = data[comboBox_selectedIndex.SelectedIndex];
            curr.kvp.Insert(listBox_data.SelectedIndex, new keyValuePair(0, 0));

            comboBox_selectedIndex_SelectedIndexChanged(0, new EventArgs());
        }

        private void button_removeKvp_Click(object sender, EventArgs e)
        {
            var curr = data[comboBox_selectedIndex.SelectedIndex];
            var kvp = curr.kvp;
            if (kvp.Count > 1)
            {
                kvp.RemoveAt(listBox_data.SelectedIndex);
            }

            comboBox_selectedIndex_SelectedIndexChanged(0, new EventArgs());

        }
        private void RefreshListbox()
        {
            var index = comboBox_selectedIndex.SelectedIndex;
            comboBox_selectedIndex.SelectedIndex = index;
            listBox_data.SelectedIndex = 0;
        }

        private void revertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.rom = backup.ToList();
            loadFromEOMToolStripMenuItem_Click(0, new EventArgs());
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 6);
            toInsert.AddKeyValuePair(0x1341, 1);
            toInsert.AddKeyValuePair(0x0e89, 0x400);
            toInsert.AddKeyValuePair(0x0f25, 0x100);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }


        private void throwCrownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            K_Rool_Throw_Options @throw = new K_Rool_Throw_Options();
            int animationPointer = 0x1a8;
            @throw.ShowDialog();
            animationPointer = @throw.pointer;


            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 3);
            toInsert.AddKeyValuePair(0x0e89, 0x400);
            toInsert.AddKeyValuePair(0x10d1, animationPointer);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void jumpUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var numStr = Prompt.ShowDialog("Enter in how many jumps you would like to insert (in hex):", "Jumps");
            if (numStr == "")
                return;
            int num = Convert.ToInt32(numStr, 16);


            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 9);
            toInsert.AddKeyValuePair(0x1341, num);
            toInsert.AddKeyValuePair(0x1561, 1);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

            button_indirect_Click(0, new EventArgs());


        }

        private void cannonballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0xb);
            toInsert.AddKeyValuePair(0x1341, 1);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

            button_indirect_Click(0, new EventArgs());

        }
        private void AddHotKeyToAll(Control ctrl)
        {
            ctrl.KeyDown += new KeyEventHandler(GlobalKeyDown);
            foreach (Control child in ctrl.Controls)
            {
                AddHotKeyToAll(child);
            }
        }
        private void GlobalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && ModifierKeys == Keys.Control)
            {
                saveToROMToolStripMenuItem_Click(0, new EventArgs());
                MessageBox.Show("Applied!");
            }
        }

        private void kvp_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_apply_Click(0, new EventArgs());
            }
        }

        private void kkrJumpsGotoKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_goto_Click(0, new EventArgs());
            }

        }

        private void keyDownApplyJumps(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (numericUpDown_pointer.Value == 0)
                {
                    MessageBox.Show("Wrong data.");
                    return;
                }
                button_applyIndirect_Click(0, new EventArgs());
            }

        }

        private void kDGotoCBall(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_cballGoto_Click(0, new EventArgs());
            }

        }

        private void kDCBallData(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_cballApplyData_Click(0, new EventArgs());
            }

        }

        private void kDCBallHeader(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_cballApply_Click(0, new EventArgs());
            }

        }

        private void kDApplyMisc(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_applyMisc_Click(0, new EventArgs());
            }

        }

        private void stallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var numStr = Prompt.ShowDialog("Enter in how many frames you would like to stall (in hex):", "Stall");
            if (numStr == "")
                return;
            int num = Convert.ToInt32(numStr, 16);


            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0xd);
            toInsert.AddKeyValuePair(0x1341, num);
            toInsert.AddKeyValuePair(0x11d5, 0xf);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

            //button_indirect_Click(0, new EventArgs());

        }

        private void copyAToBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var start = Prompt.ShowDialog("Enter the index in which you want to copy:", "Copy");
            var end = Prompt.ShowDialog("Enter the index in which you want to insert your copy:", "Copy");
            if (start == "" || end == "")
                return;
            int s = Convert.ToInt32(start, 16);
            int e1 = Convert.ToInt32(end, 16);
            if (s < data.Count && e1 < data.Count && s * e1 > 0)
            {
                data.Insert(e1, data[s]);
                //button_apply_Click(0, new EventArgs());
            }
        }

        private void comboBox_selectedIndex_MouseDown(object sender, MouseEventArgs e)
        {
            focusBoolMain = false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            var str = GetStringOfIndex();
            Clipboard.SetText(str);

        }
        private string GetStringOfIndex()
        {
            string @return = "";
            var index = comboBox_selectedIndex.SelectedIndex;
            foreach (var kvp in data[index].kvp)
            {
                @return += "," + Global.HexToString(kvp.key) + "=" + Global.HexToString(kvp.value);

            }
            @return = @return.Substring(1);
            return @return;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = comboBox_selectedIndex.SelectedIndex;
            KkrIndex toInsert = new KkrIndex();
            var lines = Clipboard.GetText().Split(',');
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                int key = Convert.ToInt32(parts[0], 16);
                int value = Convert.ToInt32(parts[1], 16);
                toInsert.AddKeyValuePair(key, value);
            }
            data.Insert(index, toInsert);
            //button_apply_Click(0, new EventArgs());
            saveToROMToolStripMenuItem_Click(0, new EventArgs());
            loadFromEOMToolStripMenuItem_Click(0, new EventArgs());
            comboBox_selectedIndex.SelectedIndex = index;
        }

        private void comboBox_selectedIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && ModifierKeys == Keys.Control)
            {
                copyToolStripMenuItem_Click(0, new EventArgs());
            }
            if (e.KeyCode == Keys.V && ModifierKeys == Keys.Control)
            {
                pasteToolStripMenuItem_Click(0, new EventArgs());
            }
            if (e.KeyCode == Keys.Delete)
            {
                button_remove_Click(0, new EventArgs());
            }
        }

        private void dKBarrelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8003);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());
        }

        private void checkpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8004);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void enemiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8005);
            toInsert.AddKeyValuePair(0x0100, 0x0000);
            toInsert.AddKeyValuePair(0x1341, 0x0001);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());
        }

        private void fakeCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fakeCreditsToolStripMenuItem.Checked = !fakeCreditsToolStripMenuItem.Checked;
            if (fakeCreditsToolStripMenuItem.Checked)
            {
                rom.Write16LDA(0xb6d150, 0x0000);
                // Don't reserve vram for kkr
                rom.Write8(0x81d323, 0xa9);
            }
            else
            {
                rom.Write16LDA(0xb6d150, 0x0001);
                rom.Write8(0x81d323, 0xa9);

            }
        }

        private void winningFanfareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0X12);
            toInsert.AddKeyValuePair(0x145d, 0x0);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());
        }

        private void kreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0X10);
            toInsert.AddKeyValuePair(0x145d, 0x1);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void lockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0X13);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x10);
            toInsert.AddKeyValuePair(0x145d, 0x5);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void getUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0xe);
            toInsert.AddKeyValuePair(0x1561, 0x0);
            toInsert.AddKeyValuePair(0x10d1, 0x1b0);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom.CheckSignature())
            {
                MessageBox.Show("Already applied");
                enableToolStripMenuItem.Checked = true;
                if (MessageBox.Show("Refresh?", "WARNING!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    form.LoadSch1eyBins();
                }
            }
            else
            {
                if (MessageBox.Show("Apply?", "WARNING!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    form.LoadSch1eyBins();
                    enableToolStripMenuItem.Checked = true;
                }
            }

        }

        private void unlockScreenToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8006);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void neckyTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8007);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void enemiesBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
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

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0x8008);
            toInsert.AddKeyValuePair(0x0100, 0x0000);
            toInsert.AddKeyValuePair(0x1341, 0x0001);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

        }

        private void button_autofill_Click(object sender, EventArgs e)
        {
            int D = (int)numericUpDown_endingX.Value - (int)numericUpDown_startingX.Value;
            int y = (int)numericUpDown_ef1.Value;
            int yD = (int)numericUpDown_f8d.Value;
            int newXSpeed = (D * 0x100) / (y / yD * 2);
            if (newXSpeed < 0)
            {
                newXSpeed *= -1;
                newXSpeed = 0x10000 - newXSpeed;
            }
            numericUpDown_e89.Value = newXSpeed;
        }

        private void customCannonballsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kkr_Cannonball_Options kkr_Cannonball_Options = new Kkr_Cannonball_Options();
            int selection = 0x16b;
            if (kkr_Cannonball_Options.ShowDialog() == DialogResult.OK)
            {
                selection = kkr_Cannonball_Options.option;
            }

            var temp = comboBox_selectedIndex.SelectedIndex;
            var toInsert = new KkrIndex();
            toInsert.AddKeyValuePair(0x130d, 0xb);
            toInsert.AddKeyValuePair(0x1341, 1);
            toInsert.AddKeyValuePair(0x0100, selection);

            data.Insert(comboBox_selectedIndex.SelectedIndex, toInsert);
            SetCombobox();
            comboBox_selectedIndex.SelectedIndex = temp;
            button_apply_Click(0, new EventArgs());

            button_indirect_Click(0, new EventArgs());

        }
    }
    public class KkrIndex
    {
        int baseAddress = 0xb6eb45;
        public int ogAddress;
        int index;
        //public Dictionary<int, int> keyValue = new Dictionary<int, int>();
        int size;
        Dictionary<int, string> types = new Dictionary<int, string>()
        {
            [0x6] = "Run",
            [0x3] = "Throw crown",
            [0x9] = "Jump up",
            [0xb] = "CBall Init",
            [0xc] = "CBall Spawn",
            [0x7] = "Fall through",
            [0xd] = "Stall",
            [0xe] = "Get up",
            [0xf] = "Stand still",
            [0x12] = "Winning fanfare",
            [0x10] = "Credits/Kredits",
            [0x13] = "Lock screen",
            [0x14] = "Stall 2",
            [0x8000] = "Run + spawn",
            [0x8001] = "Jump + spawn",
            [0x8002] = "Do After Throw",
            [0x8003] = "Spawn DK Barrel",
            [0x8004] = "Checkpoint",
            [0x8005] = "Enemies",
            [0x8006] = "Unlock screen",
            [0x8007] = "Necky tokens",
            [0x8008] = "Enemies (Lower)",
        };
        public int address;
        public string type = "???";
        public int typeNum = 0;
        public List<keyValuePair> kvp = new List<keyValuePair>();
        public void SetIndex(int index) => this.index = index + baseAddress;
        public int GetIndex() => this.index;
        public void AddKeyValuePair(int key, int value)
        {
            int searched = SearchInList(key);
            if (searched != -1 && kvp.Count > 0)
            {
                kvp.RemoveAt(searched);
            }
            kvp.Add(new keyValuePair(key, value));
            //keyValue[key] = value;
        }
        public int GetSize()
        {
            size = kvp.Count + 4;
            return size;
        }
        public void SetType(int value)
        {
            if (types.ContainsKey(value))
            {
                type = types[value];
            }
            typeNum = value;
        }
        public string GetType()
        {
            return type;
        }
        public int GetTypeNum()
        {
            return typeNum;
        }
        public override string ToString()
        {
            string @return = "";
            return @return;
        }
        public int SearchInList(int searchKey)
        {
            for (int i = 0; i < kvp.Count; i++)
            {
                if (kvp[i].key == searchKey)
                {
                    return i;
                }

            }
            return -1;
        }
        public void ModifyKvp(int key, int value, int index)
        {
            kvp[index].key = key;
            kvp[index].value = value;

        }
        public KkrIndex Clone()
        {
            KkrIndex @return = new KkrIndex();
            @return.address = address;
            @return.kvp.AddRange(kvp);

            return @return;
        }
    }
    public class keyValuePair
    {
        public int key = 0;
        public int value = 0;
        public string str;
        Dictionary<int, string> keyStrings = new Dictionary<int, string>()
        {
            [0x130d] = "Type",
            [0x1341] = "Times",
            [0x0e89] = "Speed",
            [0x0f25] = "Speed mod",
            [0x1561] = "Movement (keep)",
            [0x145d] = "Pointer",
            [0x1491] = "Bank pointer",
            [0x10d1] = "Animation pointer",
            [0x0100] = "Enemy group",
        };
        public keyValuePair(int key, int value)
        {
            this.key = key;
            this.value = value;
            if (keyStrings.ContainsKey(key))
            {
                str = keyStrings[key];
            }
            else
            {
                str = Global.HexToString(key);
            }
        }
        public override string ToString()
        {
            return $"{Global.HexToString(value)} = [{str}]";
            //return $"[{str}] = {Global.HexToString(value)}".PadLeft(24);
        }

    }
}
