using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public void ApplyBins()
        {
            var folder = "bins";
            System.IO.DirectoryInfo di = new DirectoryInfo(folder);

            FileInfo[] files = di.GetFiles("*.bin");

            foreach (var file in files)
            {
                // Look at address in file name
                var name = file.Name;
                name = name.Split('.')[0].Trim();
                name = name.Split('-')[1].Trim();
                int address = Convert.ToInt32(name, 16);

                // Get file as arr
                var arr = File.ReadAllBytes(file.FullName);

                WriteArrToROM(arr, address);

            }


        }

    }
}
