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
    public partial class WorldStartersSelect : Form
    {
        ROM rom;
        List<LevelAndCode> allLevels = new List<LevelAndCode>();

        public WorldStartersSelect(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;

            allLevels = rom.GetAllLevels();
            listBox_levelList.Items.AddRange(allLevels.ToArray());
            listBox_world.SelectedIndex = 0;
        }

        private void listBox_world_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_world.SelectedIndex == -1)
                return;
            int worldStartAddress = rom.WORLDSTARTSLDA[listBox_world.SelectedIndex];
            int worldStartValue = rom.Read16LDA(worldStartAddress);

            int index = Global.GetIndexOfCode(allLevels, worldStartValue);
            listBox_levelList.SelectedIndex = index;

        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var lvl = allLevels[listBox_levelList.SelectedIndex];
            int worldStartAddress = rom.WORLDSTARTSLDA[listBox_world.SelectedIndex];
            rom.Write16LDA(worldStartAddress, lvl.code);
            MessageBox.Show("Applied");
        }
    }
}
