using System.Collections.Generic;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class DKCLevel
    {
        public List<Entrance> entrances = new List<Entrance>();
        public List<VerticalCamera> verticalCameras = new List<VerticalCamera>();

        public List<Entrance> GetEntrancesByLevel()
        {
            Entrance.GetGraphic();

            Entrance.counter = 0;
            List<Entrance> @return = new List<Entrance>();
            for (int i = 1; i < 0xe5; i++)
            {
                var entrance = rom.levelNameByCode[i];
                var index = i * 4;
                var offset = 0xBCBEF0 + index;
                if (entrance.Contains("- Bonus") || entrance.Contains("Kong's Cabin") || entrance.Contains("empty") || entrance.Contains("empty") || entrance.Contains("full") || i == 0x16 || entrance.Contains("Save"))
                    continue;
                if (entrance.Contains(lvlName))
                {
                    // i == code
                    @return.Add(new Entrance(offset, rom, this, i));                    
                }
            }
            return @return;
        }
        public void WriteEntrancesToROM()
        {
            foreach (var entrance in entrances)
            {
                int address = entrance.address;
                rom.Write16(address + 0, entrance.x);
                rom.Write16(address + 2, entrance.y);

            }
        }
        private List<VerticalCamera> GetVerticalCameras()
        {
            List<VerticalCamera> @return = new List<VerticalCamera>();
            if (rom.IsVertical(levelCode))
            {
                WriteLayersToROM();


                int offset;
                if (levelCode == 0x6d)
                {
                    offset = 0xb35f;
                } else
                {
                    offset = 0xab8c;
                }
                int start = rom.verticalCameraStart[levelCode];
                int end = rom.verticalCameraEnd[levelCode];
                string temp = "";
                for (int i = start, j = 0; i <= end; i += 2, j++)
                {
                    int pointer = rom.Read16(0xb80000 + offset + i);
                    int nextPointer = rom.Read16(0xb80000 + offset + i + 2);
                    var vc = new VerticalCamera(offset, rom, this, j, i, i + 2);
                    //var vc = new VerticalCamera(offset, rom, this, j, poi, nextPointer);
                    @return.Add(vc);
                    //temp += $"{i.ToString("X2")}: {vc} Pointer {pointer.ToString("X")}\n";
                    temp += $"{i.ToString("X2")}: {vc}\n";
                }
                //Clipboard.SetText(temp);

            }

            return @return;
        }
        private void WriteVcamsToROM()
        {
            //return;
            foreach (var v in verticalCameras)
            {
                v.WriteCamToROM();
            }
        }
    }
}
