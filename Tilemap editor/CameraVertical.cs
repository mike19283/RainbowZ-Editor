using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public class CameraVertical
    {
        byte b0,
             b1,
             b6,
             b7;
        int endingX,
            endingY;
        DKCLevel thisLevel;
        ROM rom;
        int address;

        public CameraVertical(DKCLevel thisLevel, ROM rom, int address)
        {
            this.thisLevel = thisLevel;
            this.rom = rom;
            this.address = address;
        }
    }
}
