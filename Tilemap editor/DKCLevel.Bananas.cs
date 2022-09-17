using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class DKCLevel
    {
        public int bananaMapOffset = 0;
        public List<Banana> bananas;
        public List<Banana> ReadBananaMap()
        {
            List<Banana> @return = new List<Banana>();
            int _30 = rom.Read8(0xb8b41d + levelCode);
            _30 *= 2;
            int pointer = rom.Read16(0xb8c0e1 + _30);
            bananaMapOffset = 0xb8c0e1 + pointer;
            for (int address = 0xb8c0e1 + pointer, i = 0; rom.Read16(address) != 0; address += 4, i++)
            {
                @return.Add(new Banana(address, rom, this, i));
            }
            return @return;
        }
        public void ClearBananaMap()
        {
            int _30 = rom.Read8(0xb8b41d + levelCode);
            _30 *= 2;
            int pointer =  rom.Read16(0xb8c0e1 + _30);
            rom.Write16(0xb8c0e1 + pointer, 0);
        }
    }
}
