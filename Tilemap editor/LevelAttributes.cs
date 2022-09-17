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
    public partial class LevelAttributes : Form
    {
        bool toggle = true;
        ROM rom;
        int levelCode;
        string[] attributesByBit = new string[]
        {
            "Clear KONG letters", // 1
            "Non-start entry?", // 2
            "Squawks light", // 4
            "Color math?", // 8
            "Darker palettes", // 10
            "Bonus flag", // 20
            "Has animal flag", // 40
            "Unused?", // 80
            "Squawks spawn (if 4)", // 100
            "Dead zone (y)", // 200
            "Animal bonus", // 400
            "Warpable", // 800
            "Kong Letter flag", // 1000
            "Quick Death flag", // 2000
            "Pause Death flag", // 4000
            "Multihit Diddy", // 8000
            "Unused",
        };
        string[] customAttributesByBit = new string[]
        {
            "Animal Token Restart", // 1
            "Unused", // 2
            "Unused", // 4
            "Unused", // 8
            "Unused", // 10
            "Unused", // 20
            "Unused", // 40
            "Unused", // 80
            "Unused", // 100
            "Unused", // 200
            "Unused", // 400
            "Unused", // 800
            "Unused", // 1000
            "Unused", // 2000
            "Unused", // 4000
            "Unused", // 8000
            "Unused",
        };
        List<CheckBox> checkBoxes = new List<CheckBox>();
        DKCLevel thisLevel;
        int attrAddress;
        Form1 form;
        List<LevelAndCode> allLevels = new List<LevelAndCode>();
        List<int> invalidCodes = new List<int>
        {
            0x34, 0x47, 0x4c, 0x5e,
            0x6c, 0xa6, 0xd2, 0xd3,
        };

        public LevelAttributes(ROM rom, DKCLevel thisLevel, int attrAddress, Form1 form)
        {
            InitializeComponent();
            this.rom = rom;            
            this.levelCode = thisLevel.levelCode;
            this.thisLevel = thisLevel;
            this.attrAddress = attrAddress;
            this.form = form;
            numericUpDown_levelCode.Value = levelCode;

            string[] allLevelsR = rom.levelNameByCode.Select(e =>
            {
                string @return = e.Value;
                if (@return.Contains("start"))
                {
                    @return = @return.Split('(')[0];
                }
                return @return;
            }).ToArray();
            allLevels = allLevelsR.Select((e, i) => new LevelAndCode(new KeyValuePair<int, string>(i, e))).ToList();

            allLevels = allLevels.OrderBy(e => e.str).ToList();

            listBox_level.Items.AddRange(allLevels.ToArray());





            LoadAttributes();
            int local = Global.GetIndexOfCode(allLevels, levelCode);
            listBox_level.SelectedIndex = local;
        }
        private void LoadAttributes ()
        {
            checkBoxes = new List<CheckBox>();
            int address = attrAddress + levelCode * 2;
            label_address.Text = "Address: " + address.ToString("X");
            int attr = rom.Read16(address);
            label_attr.Text = attr.ToString("X4");
            for (int i = 0; i < 16; i++)
            {
                int x, y;
                if (i < 8)
                {
                    x = 12;
                    y = 12 + (i * 20);
                }
                else
                {
                    x = 164;
                    y = 12 + ((i - 8) * 20);
                }
                CheckBox checkBox = new CheckBox();
                checkBox.Checked = ((1 << (i)) & attr) > 0;
                if (attrAddress == 0x81d102)
                    checkBox.Text = attributesByBit[i] + " " + (1 << i).ToString("X");
                else
                    checkBox.Text = customAttributesByBit[i] + " " + (1 << i).ToString("X");
                checkBox.Location = new Point(x, y);
                checkBox.Width = 150;
                Controls.Add(checkBox);
                checkBoxes.Add(checkBox);

            }
        }
        private void ReLoadAttributes ()
        {
            int address = attrAddress + levelCode * 2;
            label_address.Text = "Address: " + address.ToString("X");
            int attr = rom.Read16(address);
            label_attr.Text = attr.ToString("X4");
            for (int i = 0; i < 16; i++)
            {
                CheckBox checkBox = checkBoxes[i];
                checkBox.Checked = ((1 << (i)) & attr) > 0;

            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            levelCode = (int)numericUpDown_levelCode.Value;

            int total = 0;
            for (int i = 0; i < 16; i++)
            {
                int bit = checkBoxes[i].Checked ? 1 : 0;
                total |= bit << i;                
            }
            if (total > 0x1000 && !rom.CheckSignature())
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
            rom.Write16(attrAddress + levelCode * 2, total);
            string str = button_apply.Text;
            if (toggle)
            {
                str = "Applied";
                toggle = false;
            }
            str += "!";
            button_apply.Text = str;
            label_attr.Text = total.ToString("X4");

            //this.DialogResult = DialogResult.OK;
        }

        private void listBox_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_level.SelectedIndex == -1)
            {
                return;
            }
            var level = (LevelAndCode)listBox_level.SelectedItem;
            button_applySanity.Enabled = level.code == thisLevel.levelCode;
            levelCode = level.code;
            numericUpDown_levelCode.Value = levelCode;
            toggle = true;
            button_apply.Text = "Apply";
            ReLoadAttributes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_applyToAll_Click(object sender, EventArgs e)
        {
            int total = GetAttr();

            var bitwise = '|';

            BitwiseModAttr(total, bitwise);
            MessageBox.Show("Done.");
        }

        private void button_applyAllGlobal_Click(object sender, EventArgs e)
        {
            int total = GetAttr();

            var bitwise = '&';

            BitwiseModAttr(total, bitwise);
            MessageBox.Show("Done.");
        }

        private void BitwiseModAttr(int total, char bitwise)
        {
            for (int i = 0; i < 0xe6; i++)
            {
                if (invalidCodes.IndexOf(i) != -1)
                    continue;
                
                int addr = attrAddress + i * 2;
                int attr = rom.Read16(addr);
                switch (bitwise)
                {
                    case '&':
                        attr &= total;
                        break;
                    case '|':
                        attr |= total;
                        break;
                    case '^':
                        attr ^= total;
                        break;
                    default:
                        break;
                }
                rom.Write16(addr, attr);
            }
        }

        private int GetAttr()
        {
            int total = 0;
            for (int i = 0; i < 16; i++)
            {
                int bit = checkBoxes[i].Checked ? 1 : 0;
                total |= (bit << i);
            }

            return total;
        }

        private void button_allXOR_Click(object sender, EventArgs e)
        {
            int total = GetAttr();

            var bitwise = '^';

            BitwiseModAttr(total, bitwise);
            MessageBox.Show("Done.");

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            levelCode = (int)numericUpDown_levelCode.Value;
            listBox_level.SelectedIndex = Global.GetIndexOfCode(allLevels, levelCode);
        }

        private void button_applySanity_Click(object sender, EventArgs e)
        {
            if(numericUpDown_levelCode.Value != thisLevel.levelCode)
            {
                MessageBox.Show("This only works on the loaded level!");
                return;
            }

            button_apply_Click(0, new EventArgs());
            foreach (var lvl in thisLevel.relatedLevels)
            {
                numericUpDown_levelCode.Value = lvl.code;
                button_apply_Click(0, new EventArgs());

            }

        }
    }
    public class LevelAndCode
    {
        public int code;
        public string str;

        public LevelAndCode (KeyValuePair<int, string> kvp)
        {
            code = kvp.Key;
            str = kvp.Value;
        }

        public override string ToString()
        {
            return str; 
        }
    }
}
