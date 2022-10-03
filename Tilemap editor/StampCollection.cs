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
    public partial class StampCollection : Form
    {
        DKCLevel thisLevel;
        Tile_display te;
        Dictionary<string, string> stampsD = new Dictionary<string, string>();
        List<Stamp> stamps = new List<Stamp>();
        public List<List<int>> toReturn;

        public StampCollection(DKCLevel thisLevel, Tile_display te)
        {
            InitializeComponent();
            this.thisLevel = thisLevel;
            this.te = te;
            Init();
        }
        private void Init ()
        {
            //stampsD = thisLevel.rom.sd.ReadCategory($"Stamps_{thisLevel.levelTheme}");
            stampsD = FormatStampFiles();

            var list = stampsD.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                stamps.Add(new Stamp(key, stampsD[key]));
            }
            listBox_stampList.Items.AddRange(stamps.ToArray());

            if (listBox_stampList.Items.Count > 0)
                listBox_stampList.SelectedIndex = 0;

        }
        private Dictionary<string, string> FormatStampFiles()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var files = Directory.GetFiles("Stamps");
            files = files.Where(e => File.ReadAllBytes(e)[0] == (byte)thisLevel.headerIndex).ToArray();
            foreach (var file in files)
            {
                string stampStr = "";
                byte[] data = File.ReadAllBytes(file);
                int index = 1;
                for (; index < 51;)
                {
                    int num = (data[index++] << 0) | (data[index++] << 8);
                    stampStr += num.ToString("X4") + ",";
                }
                data = data.Skip(51).ToArray();
                string name = Encoding.ASCII.GetString(data);
                dict[name] = stampStr;
            }

            return dict;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            if (listBox_stampList.SelectedIndex != -1)
                this.DialogResult = DialogResult.OK;
        }

        private void listBox_stampList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                button_select_Click(0, new EventArgs());

        }

        private void listBox_stampList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Stamp)listBox_stampList.SelectedItem;
            pictureBox_stampPreview.Image = te.DrawStamp(item.layout);
            toReturn = item.layout;
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (listBox_stampList.Items.Count <= 0)
                return;
            pictureBox_stampPreview.Image = null;
            string item = listBox_stampList.SelectedItem.ToString();
            string path = "Stamps\\" + item + ".bin";
            File.Delete(path);
            //thisLevel.rom.sd.Remove($"Stamps_{thisLevel.levelTheme}", item);
            listBox_stampList.Items.Clear();
            stampsD = new Dictionary<string, string>();
            stamps = new List<Stamp>();
            Init();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var curr = (Stamp)listBox_stampList.SelectedItem;

        //    thisLevel.rom.sd.Remove("Stamp", curr.name);

        //}
    }
    class Stamp
    {
        public string name;
        public List<List<int>> layout = new List<List<int>>()
        {
            new List<int>() { 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0},
            new List<int>() { 0, 0, 0, 0, 0},
        };

        public Stamp (string key, string value)
        {
            name = key;
            var arr = value.Split(',');
            int index = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    layout[x][y] = Convert.ToInt32(arr[index++], 16);
                }
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
