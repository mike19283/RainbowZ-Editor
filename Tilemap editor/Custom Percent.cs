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
    public partial class Custom_Percent : Form
    {
        private int arrayAddress;
        ROM rom;
        List<LevelAndCode> allLevels = new List<LevelAndCode>();

        public Custom_Percent(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            arrayAddress = rom.PERCENTBYSTAGE;
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
            allLevels.RemoveAt(0);

            var x = allLevels.ToArray();

            listBox_levelNames.Items.AddRange(x);

            listBox_levelNames.SelectedIndex = 0;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var item = (LevelAndCode)listBox_levelNames.SelectedItem;
            int val = (int)numericUpDown_value.Value;
            rom.Write8(arrayAddress + item.code, val);
            button_apply.Text += "!";
        }

        private void listBox_levelNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_apply.Text = "Apply";
            var item = (LevelAndCode)listBox_levelNames.SelectedItem;
            //02F7ED - 02FFFF(0x813 bytes)
            numericUpDown_value.Value = rom.Read8(arrayAddress + item.code);
        }

        private void button_zeroAndApply_Click(object sender, EventArgs e)
        {
            numericUpDown_value.Value = 0;
            button_apply_Click(0, new EventArgs());
        }

        private void button_zeroAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_levelNames.Items.Count; i++)
            {
                listBox_levelNames.SelectedIndex = i;
                numericUpDown_value.Value = 0;
                button_apply_Click(0, new EventArgs());
            }
        }
    }
}
