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
            index *= 8;
            int i = rom.ENEMYGROUPKKR + index;
            numericUpDown_enemyGroupA.Value = rom.Read16(i + 0);
            numericUpDown_enemyGroupB.Value = rom.Read16(i + 2);
            numericUpDown_enemyGroupC.Value = rom.Read16(i + 4);
        }

        private void button_enemyGroupApply_Click(object sender, EventArgs e)
        {
            int index = listBox_enemyGroup.SelectedIndex;
            index *= 8;
            int i = rom.ENEMYGROUPKKR + index;
            rom.Write16(i + 0, (int)numericUpDown_enemyGroupA.Value);
            rom.Write16(i + 2, (int)numericUpDown_enemyGroupB.Value);
            rom.Write16(i + 4, (int)numericUpDown_enemyGroupC.Value);
        }

        private void button_enemyGroupA_Click(object sender, EventArgs e)
        {
            int a = (int)numericUpDown_enemyGroupA.Value;
            try
            {
                Popup pop = new Popup(rom, a);
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
                MessageBox.Show("Did you apply ASM yet?");
            }

        }

        private void button_enemyGroupB_Click(object sender, EventArgs e)
        {
            int a = (int)numericUpDown_enemyGroupB.Value;
            try
            {
                Popup pop = new Popup(rom, a);
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
                MessageBox.Show("Did you apply ASM yet?");
            }

        }
        private void button_enemyGroupC_Click(object sender, EventArgs e)
        {
            int a = (int)numericUpDown_enemyGroupC.Value;
            try
            {
                Popup pop = new Popup(rom, a);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_enemyGroupC.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Did you apply ASM yet?");
            }


        }

    }
}
