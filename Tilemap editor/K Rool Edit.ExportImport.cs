using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class K_Rool_Edit
    {
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BIN (*.bin)|*.bin";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var arr = rom.ReadSubArray(customAddress, 0xff7fff - customAddress, rom.rom.ToArray());
                File.WriteAllBytes(dialog.FileName, arr);
            }
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "BIN (*.bin)|*.bin";
            MessageBox.Show("This does not affect any jumps or cannonballs that were in old spots");
            MessageBox.Show("This also does not affect any changes made in other tools");
            if (d.ShowDialog() == DialogResult.OK)
            {
                WriteArrAddressToROM(customAddress);
                var arr = File.ReadAllBytes(d.FileName);
                rom.WriteArrToROM(arr, customAddress);
                loadFromEOMToolStripMenuItem_Click(0, new EventArgs());

            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BIN (*.bin)|*bin";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var arr = GetExportFileKkr();
            }
        }
        private byte[] GetExportFileKkr ()
        {
            List<byte> @return = new List<byte>();
            var kkrSplit = Encoding.ASCII.GetBytes("KkrSplit");


            @return.AddRange(rom.ReadSubArrayWithAddress(rom.ENEMYGROUPKKR, 4 * 10, rom.rom.ToArray()));
            @return.AddRange(kkrSplit);
            return @return.ToArray();
        }
    }
}
