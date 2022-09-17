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
    public partial class Array_Editor : Form
    {
        ROM rom;
        List<LUTList_Name> list = new List<LUTList_Name>();
        List<LUTList_Data> dataList = new List<LUTList_Data>();
        NumericUpDown[] num;
        Dictionary<string, int> lutOffsets = new Dictionary<string, int>()
        {
            ["Base stage"] = 0xbcbaba,
            ["Funky's flights destination"] = 0x80f708,
            ["Music track"] = 0xb983b6,
            ["Music track - Global"] = 0x8ab159,
            ["Some level attributes"] = 0x81d102,
            ["Object Function Pointer Array"] = 0xbf8177,
            ["Overworld palettes"] = 0x80e1de,
            ["Object Maps"] = 0xbd8000,
            ["Entrance style"] = 0xbffd60,
            ["???"] = 0xbbcc9c,
            ["Perils links"] = 0x10ee96,
        };
        Dictionary<string, int> lutSizes = new Dictionary<string, int>()
        {
            ["Base stage"] = 0x100,
            ["Funky's flights destination"] = 6,
            ["Music track"] = 0xe5 * 2,
            ["Music track - Global"] = 0x40,
            ["Some level attributes"] = 0xe5 * 2,
            ["Object Function Pointer Array"] = 0x78 * 4,
            ["Overworld palettes"] = 26,
            ["Object Maps"] = 0xe5 * 2,
            ["Entrance style"] = 0x1cc,
            ["???"] = 10996,
            ["Perils links"] = 18 * 8,
        };
        Dictionary<string, int> indexLength = new Dictionary<string, int>()
        {
            ["Base stage"] = 1,
            ["Funky's flights destination"] = 1,
            ["Music track"] = 2,
            ["Music track - Global"] = 3,
            ["Some level attributes"] = 2,
            ["Object Function Pointer Array"] = 4,
            ["Overworld palettes"] = 2,
            ["Object Maps"] = 2,
            ["Entrance style"] = 2,
            ["???"] = 4,
            ["Perils links"] = 8,
        };
        Dictionary<string, int> indexedBy = new Dictionary<string, int>()
        {
            ["Base stage"] = 0x3e,
            ["Funky's flights destination"] = 1,
            ["Music track"] = 0x3e,
            ["Music track - Global"] = 3,
            ["Some level attributes"] = 0x3e,
            ["Object Function Pointer Array"] = 0xd45,
            ["Overworld palettes"] = 2,
            ["Object Maps"] = 0x3e,
            ["Entrance style"] = 0x3e,
            ["???"] = 4,
            ["Perils links"] = 5,
        };

        public Array_Editor(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;

            list = LoadListbox();
            listBox_addresses.Items.AddRange(list.ToArray());

            listBox_addresses.SelectedIndex = 0;

            
        }

        private List<LUTList_Name> LoadListbox()
        {
            int index = 0;
            List<LUTList_Name> @return = new List<LUTList_Name>();
            foreach (var key in lutOffsets)
            {
                var zKey = key.Key;
                var temp = new LUTList_Name(zKey, lutOffsets[zKey], lutSizes[zKey], indexLength[zKey], indexedBy[zKey], /*index++,*/ rom);
                @return.Add(temp);
            }
            return @return;
        }

        private void listBox_addresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var item = listBox_addresses.SelectedItem.ToString();
            var item = (LUTList_Name)listBox_addresses.SelectedItem;
            //richTextBox_editor.Text = item.Display();
            numericUpDown_offset.Value = item.offset;
            numericUpDown_arraySize.Value = item.size;
            numericUpDown_indexSize.Value = item.indexLength;
            numericUpDown_indexedBy.Value = item.indexedBy;

            button_goto_Click(0, new EventArgs());
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            var cloned = rom.Clone();
            try
            {
                var item = (LUTList_Data)listBox_array.SelectedItem;
                int address = item.address;
                string text = richTextBox_array.Text;
                text = text.Replace("\n", "").Replace("\r","");
                text = text.Replace(" ", "");
                if (text.Length / 2 < item.indexSize)
                {
                    throw new Exception("Not enough data provided!");
                }
                if (text.Length / 2 > item.indexSize)
                {
                    throw new Exception("More data than what could fit!");
                }
                for (int i = 0; i < text.Length; i += 2)
                {
                    string temp = text.Substring(i, 2);
                    int value = Convert.ToInt32(temp, 16);
                    rom.Write8(address++, value);
                }


                MessageBox.Show("Changed!");
            }
            catch (Exception ex)
            {
                rom.rom = cloned;
                MessageBox.Show(ex.Message);
            }

        }

        private void button_goto_Click(object sender, EventArgs e)
        {
            dataList = new List<LUTList_Data>();
            listBox_array.Items.Clear();
            int offset = (int)numericUpDown_offset.Value;
            int arraySize = (int)numericUpDown_arraySize.Value;
            int indexLength = (int)numericUpDown_indexSize.Value;
            int indexedBy = (int)numericUpDown_indexedBy.Value;


            for (int i = offset, j = 0; i < offset + arraySize; i += indexLength)
            {
                var dItem = new LUTList_Data(i, indexLength, rom, j++, indexedBy);
                dataList.Add(dItem);
            }
            listBox_array.Items.AddRange(dataList.ToArray());

            listBox_array.SelectedIndex = 0;
        }

        private void listBox_array_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (LUTList_Data)listBox_array.SelectedItem;

            // Write as string to textbox
            string arrayString = "";

            foreach (var b in item.data)
            {
                arrayString += $" {b.ToString("X2")}";
                arrayString = arrayString.Trim();
            }
            richTextBox_array.Text = arrayString;
        }
    }
    public class LUTList_Name
    {
        string name;
        public int offset;
        public int size;
        public int indexLength;
        public byte[] arr;
        public int indexedBy;
        int index;
        ROM rom;

        public LUTList_Name (string name, int offset, int size, int indexLength, int indexedBy, /*int index,*/ ROM rom)
        {
            this.name = name;
            this.offset = offset;
            this.size = size;
            this.indexLength = indexLength;
            this.indexedBy = indexedBy;
            //this.index = index;
            this.rom = rom;

        }
        public string Display()
        {
            string @return = "";

            for (int i = 0; i < size;)
            {
                for (int j = 0; j < indexLength; j++)
                {
                    @return += $"{(rom.Read8(offset + i + j)).ToString("X2")} ";
                }
                @return = @return.Trim();
                @return += "\n";
                i += indexLength;
            }

            return @return;
        }
        public void Edit (string text)
        {
            var cloned = rom.Clone();
            var spl = text.Split(new string[] { "\n", " " }, StringSplitOptions.None);
            spl = spl.Take(size).ToArray();
            var arr = Array.ConvertAll(spl, s => (int)Convert.ToInt32(s, 16));
            if (arr.Length != size || arr.Any(e => e > 255))
            {
                rom.rom = cloned;
                throw new Exception("INVALID DATA");
            }
            var arr2 = Array.ConvertAll(arr, a => (byte)a);
            rom.WriteArrToROM(arr2, offset);
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
    public class LUTList_Data
    {
        public int address;
        public int indexSize;
        ROM rom;
        int index;
        public List<byte> data = new List<byte>();
        int arrayBy;

        public LUTList_Data (int address, int indexSize, ROM rom, int index, int arrayBy)
        {
            this.address = address;
            this.indexSize = indexSize;
            this.rom = rom;
            this.index = index;
            this.arrayBy = arrayBy;

            ReadIndex();
        }
        private void ReadIndex ()
        {
            for (int i = 0; i < indexSize; i++)
            {
                var val = rom.Read8(i + address);
                data.Add((byte)val);
            }
        }
        public void WriteToRom ()
        {
            for (int i = 0; i < data.Count; i++)
            {
                var tempOffset = address + i;
                rom.Write8(tempOffset, data[i]);
            }
        }
        public override string ToString()
        {
            if (arrayBy == 0x3e)
            {
                try
                {
                    return $"{index.ToString($"X2")} - {rom.nameByLevelCode[index]}";
                }
                catch
                {
                    return $"{index.ToString($"X{indexSize}")}";
                }
            }
            else
            {
                return $"{index.ToString($"X2")}";
            }
        }
    }
}
