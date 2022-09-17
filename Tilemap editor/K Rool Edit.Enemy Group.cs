using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class K_Rool_Edit
    {
        public void EnemyGroupInit(int index)
        {

        }
        private void listBox_enemyGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //90f6e2

            int index = listBox_enemyGroup.SelectedIndex;
            index *= 4;
            int i = rom.ENEMYGROUPKKR + index;
            numericUpDown_enemyGroupA.Value = rom.Read16(i + 0);
            numericUpDown_enemyGroupB.Value = rom.Read16(i + 2);
        }

        private void button_enemyGroupApply_Click(object sender, EventArgs e)
        {
            int index = listBox_enemyGroup.SelectedIndex;
            index *= 4;
            int i = rom.ENEMYGROUPKKR + index;
            rom.Write16(i + 0, (int)numericUpDown_enemyGroupA.Value);
            rom.Write16(i + 2, (int)numericUpDown_enemyGroupB.Value);
        }

        private void button_enemyGroupA_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_enemyGroupA.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_enemyGroupB_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_enemyGroupB.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
