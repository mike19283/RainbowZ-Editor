using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class DKCLevel
    {
        public List<Entity> ScanObjectMap()
        {
            Entity.counter = 0;
            List<Entity> @return = new List<Entity>();
            if (!rom.IsVertical(levelCode) || (new List<byte>() { 0xca, 0xc5, 0xc6 }).Contains((byte)levelCode))
            {
                int address;
                address = rom.Read16(0xbd8000 | levelCode * 2) | (Global.mod ?  0x430000 : 0xbd0000);
                entityMapOffset = address;

                while (rom.Read16(address) != 0)
                {
                    @return.Add(new Entity(address, rom, this));

                    // Next object
                    address += 8;
                }
                extraEntitiesAvailable = ScanForExtras(address);
            }
            else
            {
                List<VerticalLayer> vL = new List<VerticalLayer>();

                int address, index = 0;
                address = rom.Read16((Global.mod ? 0x436000 : 0xbd8000) | levelCode * 2) | 0xbd0000;
                address = rom.Read16(address + 6) | 0xbd0000;


                while (rom.Read16(address) != 0x0000)
                {
                	vL.Add(new VerticalLayer(index, this, rom, address));
                	// Next object
                	address += 8;
                	index++;
                }

                vL.Add(new VerticalLayer(index, this, rom, address));
                int count = vL.Count;
                vL[count - 1].firstEntity = vL[count - 2].nextFirst;
                vL[count - 1].lastEntity = vL[count - 2].nextLast;

                foreach (var vertical in vL)
                {
                    vertical.GetEntities_();
                }


                verticalLayers = vL;

                //ScanObjectMapsForLayers();

            }
            return @return;

        }

        private int ScanForExtras(int address)
        {
            int @return = 0;
            var zeroes = Enumerable.Repeat((byte)0, 8).ToArray();
            var d = rom.rom.ToArray();
            var arr = rom.ReadSubArray(address, 8, d);
            if (!arr.SequenceEqual(zeroes))
            {
                return @return;
            }
            address += 8;
            arr = rom.ReadSubArray(address, 8, d);

            while (arr.SequenceEqual(zeroes))
            {
                @return++;
                address += 8;
                arr = rom.ReadSubArray(address, 8, d);

            }

            return @return;
        }

        public void WriteObjectsToROM()
        {
            int address;
            address = rom.Read16(0xbd8000 | levelCode * 2) | (Global.mod ? 0x430000 : 0xbd0000);
            if (!rom.IsVertical(levelCode))
            {
                foreach (var entity in entities)
                {
                    entity.address = address;
                    entity.WriteToROM();
                    address += 8;
                }
            }
            else
            {
                foreach (var layer in verticalLayers)
                {
                    foreach (var entity in layer.entities)
                    {
                        entity.address = address;
                        entity.WriteToROM();
                        address += 8;
                    }
                }

            }
            int zeroSize = 0;
            var zeroesOG = Enumerable.Repeat((byte)0, 8).ToArray();

            for (int i = address; true; i += 8)
            {
                var arr = rom.ReadSubArray(i, 8, rom.rom.ToArray());
                if (arr.SequenceEqual(zeroesOG))
                {
                    zeroSize = (i - address) + 8;
                    break;
                }
            }
            var zeroesNew = Enumerable.Repeat((byte)0, zeroSize).ToArray();
            rom.WriteArrToROM(zeroesNew, address);


        }
        public void OrderEntityList ()
        {
            if (rom.IsVertical(levelCode))
            {
                for (int i = 0; i < verticalLayers.Count; i++)
                {
                    var layer = verticalLayers[i];
                    layer.entities = layer.entities.OrderBy(e => e.x).ToList();
                }
            }
            else
            {
                entities = entities.OrderBy(e => e.x).ToList();
            }
            return;
        }
        public void OrderBananaList ()
        {
            bananas = bananas.OrderBy(e => e.x).ToList();
            form.CloseAll();
            return;
        }
        private Entity FindLowest(List<Entity> given)
        {
            int lowestX = given[0].x;
            int index = 0;
            for (int i = 1; i < given.Count; i++)
            {
                var e = given[i];
                var lowestAndWidth = e.x;// - e.width;
                if (lowestAndWidth < lowestX)
                {
                    lowestX = lowestAndWidth;
                    index = i;
                }

            }
            Entity lowest = given[index];
            given.RemoveAt(index);
            return lowest;
        }
        public byte[] GetObjectMapFile()
        {
            List<Entity> temp = new List<Entity>();
            foreach (var layer in verticalLayers)
            {
                temp.AddRange(layer.entities);
            }
            temp.AddRange(entities);
            List<byte> @return = new List<byte>();

            foreach (var entity in temp)
            {
                @return.AddRange(entity.GetEntityAsBytes());
            }

            @return.AddRange(Enumerable.Repeat((byte)0, 8));
            return @return.ToArray();
        }
        public byte[] GetLayersAsBytes()
        {
            List<byte> @return = new List<byte>();
            var e = verticalLayers[0].entities;
            int x = verticalLayers[0].x;
            int y = verticalLayers[0].y;
            @return.Add(1);
            @return.Add((byte)(e.Count - 1));

            @return.Add((byte)(x >> 0));
            @return.Add((byte)(x >> 8));
            @return.Add((byte)(y >> 0));
            @return.Add((byte)(y >> 8));

            @return.Add((byte)(e.Count));
            e = verticalLayers[1].entities;
            @return.Add((byte)(@return[8 - 1 - 1] + e.Count - 1));
            


            for (int i = 1; i < verticalLayers.Count - 1; i++)
            {
                var vL = verticalLayers[i];
                e = vL.entities;


                x = verticalLayers[i].x;
                y = verticalLayers[i].y;
                @return.Add((byte)(@return[i * 8 - 2]));
                @return.Add((byte)(@return[i * 8 - 1]));

                @return.Add((byte)(x >> 0));
                @return.Add((byte)(x >> 8));
                @return.Add((byte)(y >> 0));
                @return.Add((byte)(y >> 8));

                @return.Add((byte)(@return[i * 8 - 2] + e.Count));
                e = verticalLayers[i + 1].entities;
                @return.Add((byte)(@return[i * 8 - 1] + e.Count));


                if (i == verticalLayers.Count - 2)
                {

                }
            }
            @return.Add(0);
            @return.Add(0);

            return @return.ToArray();
        }


        public void ReformatLayers()
        {

        }
        public void WriteLayersToROM ()
        {
            if (!rom.IsVertical(levelCode))
                return;
            int address = verticalLayers[0].address;

            var arr = rom.ReadSubArray(address, (verticalLayers.Count - 1) * 8, rom.rom.ToArray());

            var data = GetLayersAsBytes();
            if (!arr.SequenceEqual(data))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != data[i])
                    {
                        var a = arr[i];
                        var b = data[i];
                    }
                }

            }
            layerAddress = address;
            layerData = data;
            rom.WriteArrToROM(data, address);


        }
        public Dictionary<int, byte[]> GetPlatformsForExport()
        {
            Dictionary<int, byte[]> @return = new Dictionary<int, byte[]>();
            foreach (var platform in platformPaths)
            {
                List<byte> path = new List<byte>();
                int address = platform[0].address;
                foreach (var p in platform)
                {
                    path.AddRange(p.GetBytes());
                }
                //path[path.Count - 2] = 0xff;
                path.Add(0xff);
                path.Add(0xff);
                @return[address] = path.ToArray();
            }
            return @return;
        }
        private void ReCountLayer (int layerAddress)
        {
            int pointer = rom.Read16(0xbd8000 + levelCode * 2);
            int entityAddress = Global.mod ? 0x430000 + pointer : 0xbd0000 + pointer;
            int startEntityAddress = entityAddress;
            var entityCounts = CountEntitiesForLayer(entityAddress);
            List<byte> toWrite = new List<byte>();

            for (int address = layerAddress, i = 0; rom.Read16(address) != 0; address += 8, i++)
            {
                if (i == 0)
                {
                    toWrite.Add(1);
                }
                else
                {
                    toWrite.Add((byte)entityCounts[i - 1]);
                }
                toWrite.Add((byte)(entityCounts[i] - 1));
                toWrite.Add((byte)rom.Read8(layerAddress + 2));
                toWrite.Add((byte)rom.Read8(layerAddress + 3));
                toWrite.Add((byte)rom.Read8(layerAddress + 4));
                toWrite.Add((byte)rom.Read8(layerAddress + 5));
                toWrite.Add((byte)(entityCounts[i]));
                toWrite.Add((byte)(entityCounts[i + 1]));
            }

            rom.WriteArrToROM(toWrite.ToArray(), layerAddress);


        }
        private int[] CountEntitiesForLayer (int address)
        {
            List<int> @return = new List<int>();
            int pointer = rom.Read16(0xbd8000 + levelCode * 2);
            address += 8;
            for (int entityCount = 0; rom.Read16(address - 8) != 0; address += 8, entityCount++)
            {

                int prevX = rom.Read16(address - 6);
                int currX = rom.Read16(address + 2);
                if (currX < prevX)
                {
                    @return.Add(entityCount);
                    //entityCount = 0;
                }

            }



            return @return.ToArray();
        }
    }
}
