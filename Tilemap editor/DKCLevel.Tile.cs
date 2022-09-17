using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class DKCLevel
    {

        public List<int>[,] linksRead;
        public bool[,,,] linksCheck;
        public Dictionary<int, List<int>[]> linkDict;

        public Bitmap GetTileFromIndex(int index)
        {
            Bitmap @return = new Bitmap(32, 32);
            var attr = index & 0xc000;
            index &= 0x3ff;

            index <<= 4;
            //var bitplanes = new List<byte>(thisChar.bitplanes)


            // Construct this tile
            using (Graphics g = Graphics.FromImage(@return))
            {
                var num = 0;
                for (int y = 0; y < 32; y += 8)
                {
                    for (int x = 0; x < 32; x += 8)
                    {
                        if (index + num >= tiles.Count)
                            break;
                        try
                        {
                            var use = index + num++;
                            var thisChar = tiles[use];
                            //var bitplanes = thisChar.bitplanes;
                            //g.DrawImage(thisChar.DrawChar(bitplanes), x, y);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n" + ex.Message);
                            break;
                        }
                    }
                }
                if ((attr & 0x4000) == 0x4000)
                    @return.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if ((attr & 0x8000) == 0x8000)
                    @return.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            return @return;
        }
        public Bitmap DrawTilemap()
        {
            int height = 16 * 32;
            int width = (tilemap1.Length) / 16 * 32;
            sizeOfTileMapImage = new Size(width, height);


            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int x = 0; x < 26; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        var index = tilemap1[x * 16 + y];
                        index &= 0xc3ff;
                        g.DrawImage(GetTileFromIndex(index), x * 32, y * 32);
                    }
                }
            }

            return bmp;
        }
        public void ReadAllConnections()
        {
            if (Global.mod && levelCode == 0xbf)
            {
                metaSize = 0x24a;
            }
            linksRead = new List<int>[4, metaSize];
            linksCheck = new bool[metaSize, 4, metaSize,  4];
            linkDict = new Dictionary<int, List<int>[]>();

            try
            {

                int address = theme + (rom.IsVertical(levelCode) ? 0x80 : 0x20);
                if (Global.mod && levelCode == 0xbf)
                {
                    address = 0xd90000 + 0x20;
                }


                while (true)
            {
                int tile = rom.Read16(address);
                if ((tile & 0x3fff) > metaSize)
                    {
                        throw new Exception("");
                    }
                    int[] connectedTiles;
                    if (rom.IsVertical(levelCode))
                    {
                        if (Global.mod && levelCode == 0xbf)
                        {
                            connectedTiles = new int[4]
{
                            rom.Read16(address - 2),
                            rom.Read16(address + 2),
                            rom.Read16(address - 0x20),
                            rom.Read16(address + 0x20),
};

                        }
                        else
                        {
                            connectedTiles = new int[4]
{
                            rom.Read16(address - 0x80),
                            rom.Read16(address + 0x80),
                            rom.Read16(address - 2),
                            rom.Read16(address + 2),
};
                        }


                    }
                    else
                    {
                        connectedTiles = new int[4]
                        {
                            rom.Read16(address - 2),
                            rom.Read16(address + 2),
                            rom.Read16(address - 0x20),
                            rom.Read16(address + 0x20),
                        };

                    }
                    foreach (var connect in connectedTiles)
                {
                    if ((connect & 0x3fff) > metaSize)
                        throw new Exception();
                }
             
                int spot = address - theme;
                int flips = tile & 0xc000;
                if (!linkDict.ContainsKey(tile))
                {
                    linkDict[tile] = new List<int>[4];
                    linkDict[tile][0] = new List<int>();
                    linkDict[tile][1] = new List<int>();
                    linkDict[tile][2] = new List<int>();
                    linkDict[tile][3] = new List<int>();
                }

                    //if (tile == 0)
                    //{
                    //    address += 2;
                    //    continue;
                    //}




                // Are we on the top?
                if (spot % 0x20 == 0)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        var val = connectedTiles[i];
                        if (!linkDict[tile][i].Contains(val))
                        {
                            linkDict[tile][i].Add(val);
                        }
                    }
                    // Next tile
                    address += 2;

                    continue;
                }
                // Are we on the bottom?
                if (spot % 0x20 == 0x1e)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 1)
                            continue;
                        var val = connectedTiles[i];
                        if (!linkDict[tile][i].Contains(val))
                        {
                            linkDict[tile][i].Add(val);
                        }
                    }
                    // Next tile
                    address += 2;

                    continue;

                }
                // Get UDLR

                for (int i = 0; i < 4; i++)
                {
                    var val = connectedTiles[i];
                    if (!linkDict[tile][i].Contains(val))
                    {
                        linkDict[tile][i].Add(val);
                    }
                }
                // Next tile
                address += 2;
            }


            }
            catch
            {

            }
            MessageBox.Show("Done");

            // Setup linksCheck
            for (int direction = 0; direction < 4; direction++)
            {
                for (int from = 0; from < metaSize; from++)
                {

                }
            }
        }
    }
}
