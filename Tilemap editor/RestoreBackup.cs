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
        List<FileBackups> backups;
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

            try
            {
                string folderName = "Backup Version\\" + rom.backupFileName + "\\";
                var fullPaths = Directory.GetFiles(folderName).ToArray();
                backups = new List<FileBackups>();
                for (int i = 0; i < fullPaths.Length; i++)
                {
                    FileBackups local = new FileBackups(fullPaths[i]);
                    backups.Add(local);
                }
            }
            catch
            {
                backups = new List<FileBackups>();
            }

            listBox_backups.Items.AddRange(backups.ToArray());
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            if (listBox_backups.SelectedIndex < 0)
                return;
            try
            {
                int index = listBox_backups.SelectedIndex;
                var file = backups[index].path;
                
                byte[] data = File.ReadAllBytes(file);
                rom.rom = data.ToList();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
            }
        }

        private void listBox_backups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                button_restore_Click(0, new EventArgs());
            }
        }

        private void listBox_backups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_restore_Click(0, new EventArgs());

        }
    }
    public class FileBackups
    {
        public string path;
        string display;

        public FileBackups(string path)
        {
            this.path = path;
            this.display = Global.FileNameParse(path);
        }
        public override string ToString()
        {
            return display;
        }
    }
}
