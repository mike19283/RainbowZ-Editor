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
    #region Text
    public partial class TextEditor : Form
    {
        ROM rom;
        Dictionary<int, List<TextBlock>> textBlocks = new Dictionary<int, List<TextBlock>>();
        Dictionary<int, string> textArrayNames = new Dictionary<int, string>()
        {
            [0xc4] = "Cranky A",
            [0x30] = "Cranky B",
            [0x184] = "Cranky C",
            [0x244] = "Cranky D",
            [0x2c4] = "Cranky E",
            [0x144] = "Cranky F",
            [0x354] = "Candy Opening",
            [0x344] = "Candy Random",
            [0x36c] = "Funky Opening",
            [0x374] = "Funky Random",
            [0x384] = "Funky DK Only",
            [0x388] = "Funky Diddy Only",
            [0x3a8] = "Cranky Closing",
        };
        Dictionary<int, int> textArrayPointerAndSizes = new Dictionary<int, int>()
        {
            [0xc4] = 0x40,
            [0x30] = 0x4a,
            [0x184] = 0x60,
            [0x244] = 0x40,
            [0x2c4] = 0x40,
            [0x144] = 0x20,
            [0x354] = 0x4,
            [0x344] = 0xc,
            [0x36c] = 0x8,
            [0x374] = 0x10,
            [0x384] = 0x4,
            [0x388] = 0x4,
            [0x3a8] = 0x20,
        };
        
        public TextEditor(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            Cursor.Current = Cursors.WaitCursor;

            tabControl_text.SelectedIndex = 0;
            tabControl_text_SelectedIndexChanged(0, new EventArgs());

            AddGlobalHotkeyToAll(this);
            Cursor.Current = Cursors.Default;


        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void listBox_tablePointers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_tablePointers.SelectedIndex;
            var keys = textArrayNames.Keys.ToArray();
            int indexInt = keys[index];

            listBox_textPointers.Items.Clear();
            listBox_textPointers.Items.AddRange(textBlocks[indexInt].ToArray());
            listBox_textPointers.SelectedIndex = 0;
        }

        private void listBox_textPointers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tb = (TextBlock)listBox_textPointers.SelectedItem;
            richTextBox_preview.Text = tb.str;
        }
        private void KFTextInit()
        {
            textBlocks = new Dictionary<int, List<TextBlock>>();
            var d = rom.rom.ToArray();
            foreach (var kvp in textArrayPointerAndSizes)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                List<TextBlock> tbs = new List<TextBlock>();
                var pointers = rom.ReadSubIntArray(0x3c0000 | key, value, d);
                foreach (var pointer in pointers)
                {
                    TextBlock textBlock = new TextBlock(rom, pointer, 0xbc, d);
                    tbs.Add(textBlock);
                }
                textBlocks[key] = tbs;
            }
            string[] pointerArr = textBlocks.Select(e => textArrayNames[e.Key]).ToArray();
            listBox_tablePointers.Items.Clear();
            listBox_tablePointers.Items.AddRange(pointerArr);

            listBox_tablePointers.SelectedIndex = 0;
            //listBox_textPointers.SelectedIndex = 0;

        }

        private void tabControl_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl_text.SelectedIndex)
            {
                case 0:
                    KFTextInit();
                    break;
                case 1:
                    StageTextRefresh();
                    break;
                case 2:
                    CreditsInit();
                    break;
                default:
                    break;
            }
        }


        private void button_master_Click(object sender, EventArgs e)
        {
            switch (tabControl_text.SelectedIndex)
            {
                case 1:
                    button_apply_Click(sender, e);
                    break;
                default:
                    break;
            }

        }
        private void AddGlobalHotkeyToAll(Control ctrl)
        {
            ctrl.KeyDown += new System.Windows.Forms.KeyEventHandler(GlobalHotkey);
            foreach (Control child in ctrl.Controls)
            {
                AddGlobalHotkeyToAll(child);
            }

        }
        private void GlobalHotkey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_master_Click(sender, e);
            }
        }

        private void button_kfTextApply_Click(object sender, EventArgs e)
        {
            string str = richTextBox_preview.Text;
            var arr = rom.GetByteArrayFromTextBlock(str);
            TextBlock tb = (TextBlock)listBox_textPointers.SelectedItem;
            if (str.Length > tb.size)
            {
                if (MessageBox.Show("Size longer than previous. Continue?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            rom.WriteArrToROM(arr, tb.address);
            tb.str = str;
            MessageBox.Show("Done");

        }

        private void button_export_kfText_Click(object sender, EventArgs e)
        {
            var arr = rom.ReadSubArray(0xbc0000, 0x7fff, rom.rom.ToArray());
            Global.SaveArray(arr, "Kong Family Text");
            
        }

        private void button_import_kfText_Click(object sender, EventArgs e)
        {
            var arr = Global.LoadArray("Kong Family Text");
            if (arr != null)
            {
                rom.WriteArrToROM(arr, 0xbc0000);
                KFTextInit();
            }
        }

    }

    #endregion
    public class TextBlock
    {
        public int pointer;
        public string str;
        public int address;
        public int size;

        public TextBlock (ROM rom, int pointer, int textBank, byte[] d)
        {
            this.pointer = pointer;
            address = (textBank << 16) | pointer;
            var arr = rom.ReadSubArray(address, 0x100, d);

            str = rom.GetTextBlock(arr);
            size = str.Length;


        }
        public override string ToString()
        {
            return pointer.ToString("X");
        }
    }
}
