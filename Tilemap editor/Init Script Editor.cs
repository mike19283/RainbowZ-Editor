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
    public partial class Init_Script_Editor : Form
    {
        string[] lines;
        StoredData sd;
        ROM rom;
        

        public Init_Script_Editor(StoredData sd, ROM rom)
        {
            InitializeComponent();
            this.sd = sd;
            this.rom = rom;
            string path = sd.Read("Files", "MyScripts");

            try
            {
                Init(path);

            }
            catch { }
        }
        private void Init (string path)
        {
            List<string> display = new List<string>();
            lines = System.IO.File.ReadAllLines(path);

            sd.Write("Files", "MyScripts", path);
            sd.SaveRbs();

            int splIndex = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line =="// =====")
                {
                    splIndex = i;
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                if (i >= splIndex + 1)
                {
                    display.Add(lines[i]);
                }
            }
            lines = display.ToArray();
            richTextBox_scriptText.Text = String.Join("\n", lines);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Text (*.txt)|*.txt";

            if (d.ShowDialog() == DialogResult.OK)
            {
                Init(d.FileName);
            }
        }
        private string[] FormatForSave()
        {
            lines = richTextBox_scriptText.Lines;
            List<string> @return = new List<string>()
            {
                "ScriptPointers:"
            };
            List<string> toAdd = new List<string>() { "Custom:" };
            int index = 0;
            List<byte> arrToCopy = new List<byte>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                line = line.Trim();
                if (line.EndsWith(":"))
                {
                    string name = line.Substring(0, line.Length - 1);
                    string counter = $"// {index.ToString("X")}";
                    string data = $".data32     ={name}";
                    @return.Add(counter);
                    @return.Add(data);
                    toAdd.Add($"{name}={index.ToString("X4")}");
                    index++;
                }
            }
            int offsetLength = @return.Count * 2;
            arrToCopy.AddRange(Enumerable.Repeat((byte)0, offsetLength));
            // Loop through again to create list
            int nextIndex = offsetLength;
            int offset = 0;
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    var line = lines[i];
            //    line = line.Trim();
            //    if (line.EndsWith(":"))
            //    {
            //        for (int j = i + 1; j < lines.Length && lines[j].Contains(".data16"); j++)
            //        {
            //            var tempLine = lines[j].Trim();

            //            // FIX
            //            if (tempLine.StartsWith("//") || tempLine == "")
            //            {
            //                continue;
            //            }

            //            var str = tempLine.Split(new string[] { ".data16" }, StringSplitOptions.None)[1].Trim();
            //            var spl = str.Split(',');
            //            // Write entire script first
            //            List<byte> temp = new List<byte>();
            //            //temp.AddRange(Enumerable.Repeat((byte)0, spl.Length * 2));
            //            foreach (var val in spl)
            //            {
            //                var v = val.Trim();
            //                v = v.Substring(2);
            //                var num = Convert.ToInt32(v, 16);
            //                // Convert val to bytes
            //                byte b0 = (byte)(num >> 0);
            //                byte b1 = (byte)(num >> 8);
            //                temp.Add(b0);
            //                temp.Add(b1);
            //            }


            //            //for (int k = 1; k < spl.Length; j++)
            //            //{

            //            //}
            //            arrToCopy.AddRange(temp);
            //        }

            //        // Setup pointer
            //        //0xbbb154
            //        int address = 0xbbb154 + nextIndex;
            //        arrToCopy[offset + 0] = (byte)(address >> 0);
            //        arrToCopy[offset + 1] = (byte)(address >> 8);
            //        arrToCopy[offset + 2] = (byte)(address >> 16);
            //        nextIndex = arrToCopy.Count;

            //        offset += 4;
            //    }
            //}
            //rom.WriteArrToROM(arrToCopy.ToArray(), 0xbbb154);


            @return.Add("// =====");
            @return.AddRange(lines);

            // Add to 'raw' 
            toAdd.Add("");
            toAdd.AddRange(rom.objectListRawBackup);
            rom.objectListRaw = toAdd;
            rom.ObjectParse();
            return @return.ToArray();
        }
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = sd.Read("Files", "MyScripts");
            FormatForSave();
            //System.IO.File.WriteAllLines(path, FormatForSave());
        }

        private void richTextBox_scriptText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                try
                {
                    saveToolStripMenuItem_Click(0, new EventArgs());
                    //MessageBox.Show("Save");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
        }
    }
}
