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
    public partial class WorldTerminator : Form
    {
        ROM rom;
        List<LevelAndCode> allLevels = new List<LevelAndCode>();

        public WorldTerminator(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;

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

            //allLevels.Sort(delegate(LevelAndCode a, LevelAndCode b) => 
            //{

            //});
            allLevels = allLevels.OrderBy(e => e.str).ToList();
            allLevels = allLevels.Where(e =>
            {
                var item = e.str;
                return !(item.Contains("(from") || item.Contains("Bonus") || item.Contains("NULL") || item.Contains("warp") || item.Contains("Winky Room") || item.Contains("Ledge Room") || item.Contains("Hoard") || item.Contains("Token Room"));
            }).ToList();
            allLevels.RemoveAt(0);

            var x = allLevels.ToArray();

            listBox_levelNames.Items.AddRange(x);
            listBox_world.SelectedIndex = 0;
            
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            string item = listBox_levelNames.SelectedItem.ToString();
            if (item.Contains("(from") || item.Contains("Bonus") || item.Contains("NULL"))
            {
                MessageBox.Show("Only regular exits and bosses work!");
                return;
            }
            int address = rom.WORLDTERMINATORS[listBox_world.SelectedIndex];
            int val = (int)numericUpDown_levelCode.Value;
            rom.Write16LDA(address, val);
            MessageBox.Show("Applied");
            listBox_world_SelectedIndexChanged(0, new EventArgs());
        }

        private void listBox_world_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_world.SelectedIndex;
            int val = rom.Read16LDA(rom.WORLDTERMINATORS[index]);
            numericUpDown_levelCode.Value = val;
            if (val <= 0xe5)
            {
                int lvlindex = Global.GetIndexOfCode(allLevels, val);
                listBox_levelNames.SelectedIndex = lvlindex;
            }
        }

        private void listBox_levelNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((LevelAndCode)listBox_levelNames.SelectedItem).code;
            numericUpDown_levelCode.Value = index;
        }
    }
}
