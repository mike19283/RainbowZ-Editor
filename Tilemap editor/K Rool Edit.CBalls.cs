using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class K_Rool_Edit
    {
        Dictionary<int, string> names = new Dictionary<int, string>()
        {
            [0x14f9] = "CBalls to spawn ([14f9])",
            [0xef1] = "Init Y speed ([0ef1])",
            [0xf8d] = "Delta Y per frame ([0f8d])",
            [0x1105] = "Animation timer ([1105])",
            [0x1631] = "Time to wait ([1631])",
            [0x11d5] = "Time between spawns ([11d5])",
        };
        Dictionary<int, int> cballHeader = new Dictionary<int, int>();
        Dictionary<int, int> cballData = new Dictionary<int, int>();
        public void CBallGoto ()
        {
            // Empty list boxes first
            listBox_cballHeader.Items.Clear();
            listBox_cballData.Items.Clear();

            // Fill header
            int address = (int)numericUpDown_cballPointer.Value;
            cballHeader[0x14f9] = rom.Read16(address + 0);
            cballHeader[0xef1] = rom.Read16(address + 2);
            cballHeader[0x1105] = rom.Read16(address + 4);
            cballHeader[0xf8d] = rom.Read16(address + 6);
            cballHeader[0x11d5] = rom.Read16(address + 8);
            cballHeader[0x1631] = rom.Read16(address + 10);

            address += 0xc;

            foreach (var kvp in cballHeader)
            {
                string toAdd = $"{names[kvp.Key]} = {kvp.Value.ToString("X4")}".PadLeft(35);
                listBox_cballHeader.Items.Add(toAdd);
            }

            // Fill data
            int numOfData = cballHeader[0x14f9];
            for (int i = 0; i < numOfData; i++)
            {
                int cballX = rom.Read16(address + i * 2);
                cballData[i] = cballX;
                listBox_cballData.Items.Add($"{i}. {cballX.ToString("X4")}");

            }

        }
        private void listBox_cballHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_cballHeader.SelectedIndex == -1)
                return;
            var element = cballHeader.ElementAt(listBox_cballHeader.SelectedIndex);
            numericUpDown_cballHeadKey.Value = element.Key;
            numericUpDown_cballHeadValue.Value = element.Value;
            numericUpDown_cballHeadValue.Focus();
        }

        private void listBox_cballData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var element = cballData.ElementAt(listBox_cballData.SelectedIndex);
            numericUpDown_cballDataX.Value = element.Value;
            numericUpDown_cballDataX.Focus();

        }

        private void button_cballApply_Click(object sender, EventArgs e)
        {
            if (listBox_cballHeader.SelectedIndex == -1)
                return;
            var curr = cballHeader.ElementAt(listBox_cballHeader.SelectedIndex);
            cballHeader[curr.Key] = (int)numericUpDown_cballHeadValue.Value;

            int address = (int)numericUpDown_cballPointer.Value;
            if (cballHeader.ElementAt(0).Value > (0x40 - 12) / 2)
            {
                MessageBox.Show("Error. Too many cannonballs!\nMax is 1a");
                return;
            }
            // Write
            for (int i = 0; i < cballHeader.Count; i++)
            {
                var item = cballHeader.ElementAt(i);
                rom.Write16(address + i * 2, item.Value);
            }

            // Redisplay
            var temp = listBox_cballHeader.SelectedIndex;
            CBallGoto();
            listBox_cballHeader.SelectedIndex = temp;
        }

        private void button_cballApplyData_Click(object sender, EventArgs e)
        {
            if (listBox_cballData.SelectedIndex == -1)
                return;
            var curr = cballData.ElementAt(listBox_cballData.SelectedIndex);
            cballData[curr.Key] = (int)numericUpDown_cballDataX.Value;

            int address = (int)numericUpDown_cballPointer.Value + 0xc;

            // Write
            for (int i = 0; i < cballData.Count; i++)
            {
                var item = cballData.ElementAt(i);
                rom.Write16(address + i * 2, item.Value);
            }

            // Redisplay
            var temp = listBox_cballData.SelectedIndex;
            CBallGoto();
            listBox_cballData.SelectedIndex = temp;

        }


        private void button_cballGoto_Click(object sender, EventArgs e)
        {
            CBallGoto();
        }
    }
}
