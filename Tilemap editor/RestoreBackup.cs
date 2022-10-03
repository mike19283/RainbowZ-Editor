using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class RestoreBackup : Form
    {
        StoredData sd;
        ROM rom;
        Dictionary<string, string> backups;
        public RestoreBackup(StoredData sd, ROM rom)
        {
            this.sd = sd;
            this.rom = rom;
            InitializeComponent();

            Populate(sd, rom);
        }

        private void Populate(StoredData sd, ROM rom)
        {
            listBox_backups.Items.Clear();
            string catName = "ROM Backups - " + rom.backupFileName;
            backups = sd.ReadCategory(catName);
            listBox_backups.Items.AddRange(backups.Values.ToArray());
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            if (listBox_backups.SelectedIndex < 0)
                return;
            try
            {
                var files = Directory.GetFiles("Backup Version\\" + rom.backupFileName);
                int index = listBox_backups.SelectedIndex;
                var file = files[index];
                byte[] data = File.ReadAllBytes(file);
                rom.rom = data.ToList();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sd.RemoveAll("ROM Backups - " + rom.backupFileName);
                sd.Write("ROM Backups - " + rom.backupFileName, rom.backupIndex.ToString(), DateTime.Now.ToString());
                sd.Write("ROM Backup Index - " + rom.backupFileName, "Index", rom.backupIndex.ToString());
                rom.backupIndex = 0;

                rom.WriteString(Global.signatureAddress, Global.signatureString);
                Directory.CreateDirectory("Backup Version\\" + rom.backupFileName);
                string backPath = $"Backup Version\\" + rom.backupFileName + $"\\{rom.backupIndex}.bac";
                System.IO.File.WriteAllBytes(backPath, rom.rom.ToArray());

                Populate(sd, rom);
            }
        }

        private void listBox_backups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                button_restore_Click(0, new EventArgs());
            }
        }
    }
}
