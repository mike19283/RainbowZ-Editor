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
    public partial class DixieSpritePlace : Form
    {
        ROM rom;

        public DixieSpritePlace(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetSprites();
        }

        private void GetSprites()
        {
            string folder = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Phyreburnz\\Rope swing";
            int placeAddress = 0x440000;
            int gfxOffset = 0xbbf820;
            var directory = Directory.GetFiles(folder);
            var files = directory.Where(el => el.EndsWith(".bin")).ToArray();


            foreach (var file in files)
            {
                var data = File.ReadAllBytes(file);
                rom.WriteArrToROM(data, placeAddress);
                rom.Write32(gfxOffset, placeAddress);

                gfxOffset += 4;
                placeAddress += data.Length;


            }
        }
    }
}
