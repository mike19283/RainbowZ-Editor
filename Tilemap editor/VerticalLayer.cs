using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public class VerticalLayer
    {
        public int firstEntity, lastEntity, nextFirst, nextLast;
        public int x, y, index, address;
        DKCLevel level;
        ROM rom;
        public List<Entity> entities;

        public VerticalLayer (int index, DKCLevel level, ROM rom, int address)
        {
            this.address = address;
            this.level = level;
            this.rom = rom;
            this.index = index;

            firstEntity = rom.Read8(address + 0);
            if (firstEntity == 1)
                firstEntity = 0;
            lastEntity = rom.Read8(address + 1);
            x = rom.Read16(address + 2);
            y = rom.Read16(address + 4);
            nextFirst = rom.Read8(address + 6);
            nextLast  = rom.Read8(address + 7);
        }
        public void GetEntities_ ()
        {
            entities = GetEntities();
        }

        public Bitmap DrawLayer(Bitmap bmp)
        {
            using(Graphics g = Graphics.FromImage(bmp))
            {
                int size = 0x10;
                int y_displacement = GetVerticalDisplacement(y);
                g.FillEllipse(new SolidBrush(Color.Red), x - size, y_displacement - size, size * 2, size * 2);
            }
            return bmp;
        }

        public int GetVerticalDisplacement(int y)
        {
            int displacement = 0;
            // Top of image
            var topOG = level.theme & 0xffff;
            var topOfLevel = level.tilemapOffset & 0xffff;
            var dif = (topOfLevel / 4 - topOG / 4);
            var posInWhole = 0x7000 - y;
            displacement = posInWhole - dif;

            return displacement;
        }

        private List<Entity> GetEntities()
        {
            List<Entity> @return = new List<Entity>();
            int objmap = rom.Read16(0xbd8000 + 2 * level.levelCode) + (Global.mod ? 0x430000 : 0xbd0000);
            int start = objmap + firstEntity * 8;
            int end = objmap + lastEntity * 8;
            for (int i = start, index = 0; i <= end && rom.Read16(i) != 0; i += 8, index++)
            {
                int address = i;
                var temp = new Entity(address, rom, level, true, this.index);
                @return.Add(temp);
            }

            return @return;
        }
        public byte[] GetEntitiesAsFile()
        {
            List<byte> @return = new List<byte>();
            var ent = GetEntities();

            foreach (var entity in ent)
            {
                @return.AddRange(entity.GetEntityAsBytes());
            }

            return @return.ToArray();
        }
        public override string ToString()
        {
            return $"Layer: {index}";
        }

    }
}
