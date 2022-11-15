using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class DKCLevel
    {
		int lower16Offset,
			upper16Offset,
			_d7,
			_d9,
			lower16Meta,
			_1b13,
			_1b0f,
			_db;
        int physicsOffset;
        int physicsUpUntil;
        public int levelCode;
		public ROM rom;
		public string lvlName;
		public int headerIndex,
			tilesetIndex,
			tilesetOffset;
		public byte[] decompressedChars;
		public int lvlXBoundStart;
		public int lvlXBoundEnd;
		public int metaSize;
		int metatilesetBank;
		//List<SNESChar> tiles;
		public List<List<Color>> palette;
		public Size sizeOfTileImage;
		public Size sizeOfTileMapImage;
		Bitmap srcTileset;
		public List<Bitmap> regTiles = new List<Bitmap>(),
					xFlipTiles = new List<Bitmap>(),
					yFlipTiles = new List<Bitmap>(),
					xyFlipTiles = new List<Bitmap>();
		public Tile_display te;
		public List<byte> meta;

		public int[] tilemap1;
		public int[,] tilemap;
		public int tilemapOffset;
		public int tilemapSize;
        List<byte[]> chars = new List<byte[]>();
		public List<Bitmap> tiles;
		public static string lvlInfoP = "public Dictionary<string,int> Palette = new Dictionary<string,int> ()\n{\n";
		public static string lvlInfoC = "public Dictionary<string,int> Chars = new Dictionary<string,int> ()\n{\n";
		public static string lvlInfoM = "public Dictionary<string,int> Meta = new Dictionary<string,int> ()\n{\n";
		public static string lvlInfoMS = "public Dictionary<string,int> MetaSize = new Dictionary<string,int> ()\n{\n";
		public List<Entity> entities;
		public int theme;
		public Form1 form;
		public List<Camera> cameraBoxes;
		public List<VerticalLayer> verticalLayers = new List<VerticalLayer>();
        public List<List<PlatformPath>> platformPaths;
        public string levelTheme;
        public byte[] layerData;
        public int layerAddress;
        public int paletteOffset;
        string entitymapFolder = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Level work\\Entities";
        public int entityMapOffset;
        public List<LevelAndCode> relatedLevels = new List<LevelAndCode>();
        public int extraEntitiesAvailable = 0;
        public Dictionary<int, byte[]> pathArray = new Dictionary<int, byte[]>();
        //62 - 8ea2
        public Dictionary<int, int> sizeByPlatform = new Dictionary<int, int>()
        {
            [0xb68ea2] = 62,
            [0xb68cbe] = 234,
            [0xb68bcc] = 242,
            [0xb68da8] = 250,
            [0xb68b16] = 182,
        };
        private Dictionary<int, List<Entity>> relatedEntities = new Dictionary<int, List<Entity>>();
        public bool trackBool = true;
        public List<int> pathAddresses = new List<int>();
        public int cameraOffset;

        public DKCLevel(string lvlName, ROM rom, Form1 form, bool entityLayers)
        {
            this.form = form;
            this.lvlName = lvlName;
            this.rom = rom;


            relatedLevels = rom.GetRelatedLevels(lvlName);


            Entity.counter = 0;
            rom.tile_vram = new List<byte[]>();
            entities = new List<Entity>();
            cameraBoxes = new List<Camera>();
            entrances = new List<Entrance>();
            bananas = new List<Banana>();
            platformPaths = new List<List<PlatformPath>>();


            levelCode = rom.levelCodeByString[lvlName];
            // Forest BG
            if (levelCode == 0xf0)
            {
                palette = rom.ReadPaletteFromROM(0xb9a1dc, 8, 16);
                paletteOffset = 0xb9a1dc;
                decompressedChars = rom.GetDecompressedTiles(0xd58fc0);
                lvlXBoundStart = 0xd91500;
                lvlXBoundEnd = 0xd91700;
                chars = ReadEveryChar();
                meta = rom.ReadSubArray(0xd9a3c0, 0x24a * 0x20, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();
                metaSize = 0x249;

                if (te != null)
                {
                    te.Close();
                    te.DialogResult = DialogResult.OK;
                }


                te = new Tile_display(this, rom, form);

                te.Show();
                tilemap1 = LoadTilemap();

                return;
            }
            // Cave BG
            if (levelCode == 0xf1)
            {
                metaSize = 0x1b3;
                paletteOffset = 0xb9A01C;
                palette = rom.ReadPaletteFromROM(paletteOffset, 8, 16);
                decompressedChars = rom.GetDecompressedTiles(0xdc0000);
                lvlXBoundStart = 0xda0000;
                lvlXBoundEnd = 0xda0100;
                chars = ReadEveryChar();
                meta = rom.ReadSubArray(0xdabf00, metaSize * 0x20, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                if (te != null)
                {
                    te.Close();
                    te.DialogResult = DialogResult.OK;
                }


                te = new Tile_display(this, rom, form);

                te.Show();
                tilemap1 = LoadTilemap();

                return;
            }
            // Mine BG
            if (levelCode == 0xf2)
            {
                metaSize = 0x182;
                paletteOffset = 0xb99B1C;
                palette = rom.ReadPaletteFromROM(paletteOffset, 8, 16);
                decompressedChars = rom.GetDecompressedTiles(0xfa219e);
                lvlXBoundStart = 0xe03636;
                lvlXBoundEnd = 0xe03836;
                chars = ReadEveryChar();
                meta = rom.ReadSubArray(0xe0aad6, metaSize * 0x20, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                if (te != null)
                {
                    te.Close();
                    te.DialogResult = DialogResult.OK;
                }


                te = new Tile_display(this, rom, form);

                te.Show();
                tilemap1 = LoadTilemap();

                return;
            }
            //lvlInfoP += $"[\"{lvlName}\"] = 0x{rom.paletteOffset[lvlName].ToString("X")},\n";


            paletteOffset = rom.paletteOffset[lvlName];
            palette = rom.ReadPalette(rom.paletteOffset[lvlName], 8, 16);

            ModifyPalettes();

            tilesetIndex = rom.tilesetIndexByStage[lvlName];
            tilesetOffset = rom.TilesetIndex(tilesetIndex, levelCode);
            //lvlInfoC += $"[\"{lvlName}\"] = 0x{tilesetOffset.ToString("X")},\n";

            var tempDecompressed = rom.GetDecompressedTiles(tilesetOffset);
            if (levelCode == 0x68)
            {
                tempDecompressed = rom.ReadSubArray(0x0f0000, 0x8500, rom.rom.ToArray());
            }
            //decompressedChars = rom.GetDecompressedTiles(tilesetOffset);

            headerIndex = rom.headerIndex[lvlName];
            GetInfo(headerIndex);
            levelTheme = rom.levelThemes[headerIndex];

            theme = lower16Offset | ((upper16Offset & 0xff) << 16);

            if (levelCode == 0x42 || levelCode == 0x43 || (new List<byte>() { 0x55, 0x56, 0x57, 0x52, 0x53 }).Contains((byte)levelCode))
            {
                // Remove first 20 bytes
                tempDecompressed = tempDecompressed.Skip(0x20).ToArray();


                // Wheel gnawties use bg 2
                var sub = rom.ReadSubArray(0xDBCCD2, 0x22c0, rom.rom.ToArray());
                var tempArr = new byte[0xf20];
                tempArr = Enumerable.Repeat((byte)0, 0xf20).ToArray();

                decompressedChars = new byte[sub.Length + tempDecompressed.Length + tempArr.Length];

                sub.CopyTo(decompressedChars, 0);
                tempDecompressed.CopyTo(decompressedChars, sub.Length);
                tempArr.CopyTo(decompressedChars, sub.Length + tempDecompressed.Length);
            }
            else
            {
                decompressedChars = new byte[tempDecompressed.Length];
                tempDecompressed.CopyTo(decompressedChars, 0);
            }
            if (levelCode == 0x24 || levelCode == 0xa7 || (new List<byte>() { 0x67, 0x66, 0x69, 0x6a, 0x6b }).Contains((byte)levelCode))
            {
                var tempD = new List<byte>();
                tempD.AddRange(Enumerable.Repeat((byte)0, 0x20));
                tempD.AddRange(decompressedChars.Skip(0x20).ToArray());
                tempD.AddRange(Enumerable.Repeat((byte)0, 0x2000));
                //tempD.AddRange(arrSnow);

                decompressedChars = tempD.ToArray();
                //decompressedChars = arrSnow;
            }
            // ==============================================================
            chars = ReadEveryChar();
            var tempChars = new List<byte[]>();
            tempChars.AddRange(chars);
            byte[] testZero = Enumerable.Repeat((byte)0, 0x20).ToArray();
            //for (int i = chars.Count - 1; i > 0; i--)
            //{
            //    if (chars[i].SequenceEqual(testZero))
            //    {
            //        // Ends up breaking 4-1 and 4-3. had to remove
            //        //chars.RemoveAt(i);
            //    } else
            //    {
            //        break;
            //    }

            //}

            FindStartAndEnd();

            metaSize = rom.metatilesetSize[headerIndex];
            if (levelCode == 0x68)
            {
                //metaSize = 0x180;
            }
            //metaSize = 0x800;
            List<byte> wtrcode = new List<byte> { 0xbf, 0xde, 0x3e, 0x22 };
            if (wtrcode.Contains((byte)levelCode))
                metatilesetBank = 0x10;
            else
                metatilesetBank = upper16Offset & 0xff;

            var metaOffset = (metatilesetBank << 16) | (lower16Meta << 0);
            meta = rom.ReadSubArray(metaOffset, metaSize * 0x20, rom.rom.ToArray()).ToList();
            //lvlInfoM += $"[\"{lvlName}\"] = 0x{metaOffset.ToString("X")},\n";
            //lvlInfoMS += $"[\"{lvlName}\"] = 0x{metaSize.ToString("X")},\n";

            tiles = ReadTileFromMeta();

            if (Global.mod && levelCode == 0xc)
            {
                palette = rom.ReadPaletteFromROM(0x45a1dc, 8, 16);
                paletteOffset = 0x45a1dc;
                decompressedChars = rom.GetDecompressedTiles(0x452000);
                chars = ReadEveryChar();
                lvlXBoundStart = 0x450000;
                lvlXBoundEnd = 0x452000;
                meta = rom.ReadSubArray(0x45b000, 0x24a0, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                //tilemapOffset = 0x450000;
                //tilemapSize = 0x1f00;

            }
            if (Global.mod && levelCode == 0xa7)
            {
                palette = rom.ReadPaletteFromROM(0x467800, 8, 16);
                paletteOffset = 0x467800;
                decompressedChars = rom.GetDecompressedTiles(0x468000);
                chars = ReadEveryChar();
                lvlXBoundStart = 0x460000;
                lvlXBoundEnd = 0x4629e0;
                meta = rom.ReadSubArray(0x463000, 0x3da0, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                //tilemapOffset = 0x450000;
                //tilemapSize = 0x1f00;

            }
            if (Global.mod && levelCode == 0xd0)
            {
                palette = rom.ReadPaletteFromROM(0x477800, 8, 16);
                paletteOffset = 0x477800;
                decompressedChars = rom.GetDecompressedTiles(0x478000);
                chars = ReadEveryChar();
                lvlXBoundStart = 0x470000;
                lvlXBoundEnd = 0x4718c0;
                meta = rom.ReadSubArray(0x473000, 0x3300, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                //tilemapOffset = 0x450000;
                //tilemapSize = 0x1f00;

            }
            // Coral capers
            if (Global.mod && levelCode == 0xbf)
            {
                palette = rom.ReadPaletteFromROM(0xb9a1dc, 8, 16);
                paletteOffset = 0xb9a1dc;
                decompressedChars = rom.GetDecompressedTiles(0xd58fc0);
                chars = ReadEveryChar();
                meta = rom.ReadSubArray(0xd9a3c0, 0x24a * 0x20, rom.rom.ToArray()).ToList();
                tiles = ReadTileFromMeta();

                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                //tilemapOffset = 0x450000;
                //tilemapSize = 0x1f00;

            }
            if (te != null)
            {
                te.Close();
                te.DialogResult = DialogResult.OK;
            }

            // Kingizor test compression
            decompressedChars = decompressedChars.Take(chars.Count * 0x20).ToArray();
            //Global.SaveArray(decompressedChars, "chars");
            te = new Tile_display(this, rom, form);

            te.Show();

            if (entityLayers && rom.IsVertical(levelCode))
            {
                RewriteLayers(lvlName, rom);
            }







            //byte[] arr = new byte[] { 0, 1, 2, 3 };

            //var x = Global.Read16(1, arr);
            tilemap1 = LoadTilemap();


            rom.ObjectParse();
            entities = ScanObjectMap();
            entrances = GetEntrancesByLevel();
            //Clipboard.SetText($"{lvlInfoP}" + "}" + $"\n{lvlInfoC}" + "}" + $"\n{lvlInfoM}" + "}" + $"\n{lvlInfoMS}" + "}" + $"\n");
            cameraBoxes = ScanCameraMap();
            bananas = ReadBananaMap();
            platformPaths = GetTrackPaths();
            verticalCameras = GetVerticalCameras();

            // Save level code so we can scan the object maps of related levels
            int tempLvlCode = levelCode;

            if (platformPaths != null)
            {
                trackBool = CheckSizeOfPath();
            }

            levelCode = tempLvlCode;
        }

        private void ModifyPalettes()
        {
            // Modify palettes
            foreach (var row in palette)
            {
                row[0] = Global.transparentClr;
            }
        }

        public void ShowTileEdit()
        {
            te.Show();
        }

        private void RewriteLayers(string lvlName, ROM rom)
        {
            int layerMapOffset = rom.layerMapOffset[levelCode];
            int layers = rom.layersByCode[levelCode];
            int total = 0;
            for (int layer = 0; layer < layers; layer++)
            {
                string fileName = $"{entitymapFolder}\\{lvlName} - Layer {layer} Entities.bin";
                var data = File.ReadAllBytes(fileName);
                int entityCount = data.Length / 8;
                total += entityCount;
                int prevEntityCount = rom.Read8(layerMapOffset - 7) + 1;
                if (layer == 0)
                {
                    rom.Write8(layerMapOffset + 1, entityCount - 1);
                }
                else
                {
                    rom.Write8(layerMapOffset - 2, prevEntityCount);
                    rom.Write8(layerMapOffset - 1, total - 1);
                    if (layer + 1 != layers)
                    {
                        rom.Write8(layerMapOffset + 0, prevEntityCount);
                        rom.Write8(layerMapOffset + 1, total - 1);
                    }

                }
                layerMapOffset += 8;

            }
            layerMapOffset = layerMapOffset - (layers) * 8;
            var arr = rom.ReadSubArray(layerMapOffset, 24, rom.rom.ToArray());
        }

        private List<byte[]> ReadEveryChar ()
        {
            List<byte[]> @return = new List<byte[]>();
			// Palette num
			int paletteIndex = 0;
			while (paletteIndex < 1)
            {
				var pal = palette[paletteIndex++];
				// Loop through decompressed
				for (int i = 0; i < decompressedChars.Length; i += 0x20)
                {
                    //var arr = decompressedChars.Skip(i).Take(0x20).ToArray();
                    var arr = new byte[0x20];
                    Array.Copy(decompressedChars, i, arr, 0, 0x20);

                    @return.Add(arr);

                }
            }


			return @return;



		}
		public Bitmap DrawChar(byte[] @char, List<Color> palette)
		{
            //Console.WriteLine($"{debug} - {a}");

            // Create image to return
            DirectBitmap bmp = new DirectBitmap(8, 8);

			// Rows of resulting image
			for (int i = 0, index = 0; i < 8; i++)
			{
                int ii = 8 * i;
				// Columns of resulting image
				for (int j = 0; j < 8; j++)
				{
					int colorIndex = 0;

					// Loop for bpp
					for (int k = 0; k < 4 /* bpp */ / 2; k++)
					{
						// >> To get the right bit, << to get the right bpp
						var x = (((@char[index + k * 16] >> (7 - j)) & 1) << (k * 2));
						var y = (((@char[index + 1 + k * 16] >> (7 - j)) & 1) << (k * 2 + 1));
						colorIndex |= x | y;
					}

					bmp.SetPixel(j + ii, palette[colorIndex]);
				}
				index += 2;

			}


			return bmp.Bitmap;
		}

		private int[] LoadTilemap()
        {
            if (rom.IsVertical(levelCode))
            {
                tilemapSize = rom.allTilemapSizes[lvlName];

                tilemapOffset = rom.allTilemapOffsets[lvlName];
            }
            else
            {
                try
                {
                    //tilemapSize = rom.allTilemapSizes[lvlName];
                    tilemapSize = lvlXBoundEnd - lvlXBoundStart;

                    tilemapOffset = rom.allTilemapOffsets[lvlName];
                    //tilemapOffset = lvlXBoundStart;
                }
                catch
                {
                    tilemapSize = lvlXBoundEnd - lvlXBoundStart;
                    tilemapOffset = lvlXBoundStart;

                }

            }
            if (Global.mod && levelCode == 0xc)
            {
                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                tilemapOffset = 0x450000;
                //tilemapSize = 0x2000;
                tilemapSize = lvlXBoundEnd - lvlXBoundStart;

            }
            if (Global.mod && levelCode == 0xa7)
            {
                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                tilemapOffset = 0x460000;
                //tilemapSize = 0x2000;
                tilemapSize = lvlXBoundEnd - lvlXBoundStart;

            }
            if (Global.mod && levelCode == 0xd0)
            {
                //var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
                tilemapOffset = 0x470000;
                //tilemapSize = 0x2000;
                tilemapSize = lvlXBoundEnd - lvlXBoundStart;

            }

            //if (!rom.IsVertical(levelCode)  && !(new List<byte>() { 0x55, 0x56, 0x57, 0x4a, 0x4b, 0xb7, 0xb8, 0xb9 }).Contains((byte)levelCode))
            //{
            //    tilemapSize = lvlXBoundEnd - lvlXBoundStart;
            //    tilemapOffset = lvlXBoundStart;
            //}
            //else
            //{
            //}

            //FIXME
            //tilemapSize = 0x8000;
            //tilemapOffset = theme;

            //var size = 0x20;
            var rawTilemap = rom.ReadSubArray(tilemapOffset, tilemapSize, rom.rom.ToArray());
			List<int> @return = new List<int>();

			if (rom.IsVertical(levelCode))
            {
				tilemap = ConvertTilemapVertical(rawTilemap);

            }
			else
            {
				tilemap = ConvertTilemap(rawTilemap);
			}

			return @return.ToArray();
        }
		public int[,] ConvertTilemap (byte[] tm)
        {
			int length = tm.Length;
			// Array has 2 bytes per tile
			length /= 2;
			// Divide out tiles per column
			length /= 0x10;
			int[,] @return = new int[length, 0x10];

			int offset = 0;
			for (int x = 0; x < length; x++)
			{
				for (int y = 0; y < 16; y++)
				{
					int pointer = Global.Read16(offset, tm);
					@return[x, y] = pointer;
					offset += 2;
				}
			}

			return @return;

		}
		public int[,] ConvertTilemapVertical (byte[] tm)
        {
			int setsOfRows = tm.Length / 0x80;

			int width = 0x40;
			int height = tm.Length;
			// Array has 2 bytes per tile
			height /= 2;
			// Divide out tiles per row
			height /= 0x40;
			//length /= 0x20;
			int[,] @return = new int[width, setsOfRows];

			int offset = 0;
			for (int y = 0; y < setsOfRows; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int pointer = Global.Read16(offset, tm);
					@return[x, y] = pointer;
					offset += 2;
				}
			}

			return @return;

		}
		private void GetInfo(int lvlIndex)
		{
			int _4c;
			int a, x, y;
			a = lvlIndex;
			//a_818c66_818c66: __PHB                  // PC[818c66]={8b         }  s1
			//		 __PHK                  // PC[818c67]={4b         }  s2
			//				__PLB                  // PC[818c68]={ab         }  s1
			//				__STA $4c              // PC[818c69]={85 4c      }  s1
			_4c = a;
			//				__ASL A                // PC[818c6b]={0a         }  s1
			a <<= 1;
			//				__TAY                  // PC[818c6c]={a8         }  s1
			y = a;
			//				__CLC                  // PC[818c6d]={18         }  s1
			//				__ADC $4c              // PC[818c6e]={65 4c      }  s1
			a += _4c;
			//				__TAX                  // PC[818c70]={aa         }  s1
			x = a;
			//				__LDA $8b94,X          // PC[818c71]={bd 94 8b   }  s1
			a = rom.Read16(0x818b94 + x);
			//				__STA $d3              // PC[818c74]={85 d3      }  s1
			lower16Offset = a;
			//				__SEP #$20             // PC[818c76]={e2 20      }  s1
			//				m_LDA $8bc0,X          // PC[818c78]={bd c0 8b   }  s1
			a = rom.Read8(0x818b94 + x);
			//				▼▼BNE $= _8c7f          // PC[818c7b]={d0 02      }  s1
			if (a == 0)
			{
				a = 0x80;
			}
			//				m_LDA #$80             // PC[818c7d]={a9 80      }  s1
			//	a_818c66_818c7f:	m_XBA                  // PC[818c7f]={eb         }  s1
			a <<= 8;
			//				m_LDA $8b96,X          // PC[818c80]={bd 96 8b   }  s1
			a = a | (rom.Read8(0x818b96 + x));
			//				__REP #$20             // PC[818c83]={c2 20      }  s1
			//				__STA $d5              // PC[818c85]={85 d5      }  s1
			upper16Offset = a;
			//				__LDA $8c04,X          // PC[818c87]={bd 04 8c   }  s1
			a = rom.Read16(0x818c04 + x);
			//				__STA $d7              // PC[818c8a]={85 d7      }  s1
			_d7 = a;
			//				__LDA $8c06,X          // PC[818c8c]={bd 06 8c   }  s1
			a = rom.Read16(0x818c06 + x);
			//				__AND #$00ff           // PC[818c8f]={29 ff 00   }  s1
			a &= 0xff;
			//				__ORA #$8000           // PC[818c92]={09 00 80   }  s1
			a |= 0x8000;
			//				__STA $d9              // PC[818c95]={85 d9      }  s1
			_d9 = a;
			//				__LDA $8bbe,X          // PC[818c97]={bd be 8b   }  s1
			a = rom.Read16(0x818bbe + x);
			//				__STA $1b11            // PC[818c9a]={8d 11 1b   }  s1
			lower16Meta = a;
			//				__LDA $8be8,Y          // PC[818c9d]={b9 e8 8b   }  s1
			a = rom.Read16(0x818be8 + y);
			//				__STA $1b13            // PC[818ca0]={8d 13 1b   }  s1
			_1b13 = a;
			//				__LDA $8c2e,Y          // PC[818ca3]={b9 2e 8c   }  s1
			a = rom.Read16(0x818c2e + y);
			//				__STA $db              // PC[818ca6]={85 db      }  s1
			_db = a;
			//				__LDA $8c4a,Y          // PC[818ca8]={b9 4a 8c   }  s1
			a = rom.Read16(0x818c4a + y);
			//				__STA $1b0f            // PC[818cab]={8d 0f 1b   }  s1
			_1b0f = a;
            //				__PLB                  // PC[818cae]={ab         }  s0
            //				__RTL                  // PC[818caf]={6b         }  s0

            physicsOffset = ((_d9 & 0xff) << 16) | (_d7 << 0);
            physicsUpUntil = _db;
		}
		private void FindStartAndEnd()
		{
			//$BC / B052 A5 3E       LDA $3E[$00:003E]   A: 0000 X: 0400 Y: 0108 P: eNvmxdIzc
			//$BC / B054 0A ASL A A:0016 X: 0400 Y: 0108 P: envmxdIzc
			//$BC / B055 AA TAX                     A: 002C X:0400 Y: 0108 P: envmxdIzc
			int tempX = levelCode << 1;
			//$BC / B056 BF 00 80 BC LDA $BC8000,x[$BC: 802C] A: 002C X:002C Y:0108 P: envmxdIzc
			//$BC / B05A AA TAX                     A: 957E X: 002C Y:0108 P: eNvmxdIzc
			//$BC / B05B CA DEX                     A: 957E X: 957E Y: 0108 P: eNvmxdIzc
			//$BC / B05C CA DEX                     A: 957E X: 957D Y: 0108 P: eNvmxdIzc
			//$BC / B05D CA DEX                     A: 957E X: 957C Y:0108 P: eNvmxdIzc
			//$BC / B05E CA DEX                     A: 957E X: 957B Y:0108 P: eNvmxdIzc
			tempX = rom.Read16(0xbc8000 + tempX) - 4;
			//$BC / B05F BF 02 00 BC LDA $BC0002,x[$BC: 957C] A: 957E X: 957A Y:0108 P: eNvmxdIzc
			lvlXBoundEnd = rom.Read16(0xbc0002 + tempX);
			//$BC / B063 A8 TAY                     A: 1400 X: 957A Y:0108 P: envmxdIzc
			//$BC / B064 BF 00 00 BC LDA $BC0000,x[$BC: 957A] A: 1400 X: 957A Y:1400 P: envmxdIzc
			lvlXBoundStart = rom.Read16(0xbc0000 + tempX);
			//$BC / B068 6B RTL                     A: 0000 X: 957A Y:1400 P: envmxdIZc

			int tempD5 = upper16Offset & 0xff;
			lvlXBoundStart = (tempD5 << 16) | lvlXBoundStart;
			lvlXBoundEnd = ((tempD5 << 16) | lvlXBoundEnd) + 0x100;


            // FIXME
            //lvlXBoundStart = 0;
            //lvlXBoundEnd = 0xa3bf;
		}


		public Bitmap DrawPalette(List<List<Color>> palette)
		{
			Bitmap bmp = new Bitmap((palette[0].Count * 20), (palette.Count * 20));
			using (Graphics g = Graphics.FromImage(bmp))
			{
				for (int r = 0; r < palette.Count; r++)
				{
					for (int c = 0; c < 16; c++)
					{
						Rectangle rect = new Rectangle(c * 20, r * 20, 20, 20);
						if (c < palette[r].Count)
						{
							g.FillRectangle(new SolidBrush(palette[r][c]), rect);
						}
						else
						{
							g.FillRectangle(new SolidBrush(Color.Black), rect);
						}
					}
				}
			}
			return bmp;
		}
		//private List<byte> 
		public List<Bitmap> ReadTileFromMeta()
		{
            byte[] m = meta.ToArray();
			List<Bitmap> @return = new List<Bitmap>();

			for (int i = 0; i < meta.Count; i += 0x20)
            {
                //var metaSub = meta.Skip(i).Take(0x20).ToArray();
                byte[] metaSub = new byte[0x20];
                Array.Copy(m, i, metaSub, 0, 0x20);

				// Look at each tile
				var index = 0;
				Bitmap bmp = new Bitmap(32, 32);

				using (Graphics g = Graphics.FromImage(bmp))
				{
					// Set each tile up from TL to BR
					for (int y = 0; y < 32; y += 8)
					{
						for (int x = 0; x < 32; x += 8)
						{
							try
							{
								int pointer = Global.Read16(index, metaSub);
								index += 2;
								int attr = pointer & 0xfc00;
								int paletteIndex = (attr & 0x1c00) >> 10;
								pointer &= 0x3ff;

								// Clone, so we don't modify existing array
								Bitmap @char = DrawChar(chars[pointer],palette[paletteIndex]);

								if ((attr & 0x4000) > 0)
								{
									@char.RotateFlip(RotateFlipType.RotateNoneFlipX);
								}
								if ((attr & 0x8000) > 0)
								{
									@char.RotateFlip(RotateFlipType.RotateNoneFlipY);
								}
								g.DrawImage(@char, x, y);
							}
							catch (Exception ex)
                            {
								MessageBox.Show($"{ex.Message} - tm{tilemap[x, y]}");
                            }
							
						}

					}

				}
				// Now we drew the whole tile
				@return.Add(bmp);

			}


			return @return;

		}
		public Bitmap ReDrawTilemap(bool showGrid)
		{
			int width = tilemap.GetLength(0), height = tilemap.GetLength(1);
			Bitmap bmp = new Bitmap(width * 32, height * 32);

			using (Graphics g = Graphics.FromImage(bmp))
			{
				for (int y = 0; y < height; y++)
				{
					for (int x = 0; x < width; x++)
					{
						int pointer = tilemap[x, y];
						Bitmap tile = GetTileByIndex(pointer);
						g.DrawImage(tile, x * 32, y * 32);
						if (showGrid)
						{
							g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0x40, 0xf0, 00, 00))), x * 32, y * 32, 32, 32);
						}
					}

				}

			}
			return bmp;
		}
		public Bitmap ReDrawGivenTilemap(bool showGrid, int[,] tm)
		{
			int width = tilemap.GetLength(0), height = tilemap.GetLength(1);
			Bitmap bmp = new Bitmap(width * 32, height * 32);

			using (Graphics g = Graphics.FromImage(bmp))
			{
				for (int y = 0; y < height; y++)
				{
					for (int x = 0; x < width; x++)
					{
						int pointer = tm[x, y];
						Bitmap tile = GetTileByIndex(pointer);
						g.DrawImage(tile, x * 32, y * 32);
						if (showGrid)
						{
							g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), x * 32, y * 32, 32, 32);
						}
					}

				}

			}
			return bmp;
		}
		public List<List<int>> GetPartialTilemap (int xOffset)
        {
			List<List<int>> @return = new List<List<int>>();
			// Pull out of established tilemap
			int maxWidth = 25;
			for (int x = xOffset; x < xOffset + maxWidth && x < tilemap.GetLength(0); x++)
            {
				// Add new 'row'
				@return.Add(new List<int>());
				for (int y = 0; y < 16; y++)
                {
					int temp = tilemap[x, y];
					@return[x].Add(temp);
                }
            }

			return @return;
        }
		public Bitmap GetTileByIndex(int index)
		{
            try
            {
                // Bits 14 and 15 are flips
                bool xFlip = (index & 0x4000) > 0,
                     yFlip = (index & 0x8000) > 0;
                // Clone so we leave our array untouched
                Bitmap bmp = (Bitmap)tiles[index & 0x3ff].Clone();
                if (xFlip)
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if (yFlip)
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return bmp;
            }
            catch
            {
                if (Global.firstError)
                {
                    MessageBox.Show("Error", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.firstError = false;
                }
                return new Bitmap(32, 32);
            }
		}

		public byte[] GameTilemap()
        {
			int w = tilemap.GetLength(0), h = tilemap.GetLength(1);
			byte[] arr = new byte[w * h * 2];
			int offset = 0;
			for (int x = 0; x < w; x++)
            {
				for (int y = 0; y < h; y++)
                {
					int pointer = tilemap[x, y];
					Global.Write16(pointer, offset, arr);
					offset += 2;
                }
            }

			return arr;
        }

		public int[,] TilemapDeepCopy()
        {
			return tilemap.Clone() as int[,];
        }

		public void SetTilemapFromFile(byte[] file)
		{
            if (rom.IsVertical(levelCode))
            {
                SetTilemapFromFileVertical(file);
                return;
            }
			//var size = 0x20;
			var rawTilemap = file;
			List<int> @return = new List<int>();
			tilemap = ConvertTilemap(rawTilemap);
		}
		public void SetTilemapFromFileVertical(byte[] file)
		{
			//var size = 0x20;
			var rawTilemap = file;
			List<int> @return = new List<int>();
			tilemap = ConvertTilemapVertical(rawTilemap);
		}
		public void WriteTilemapToROM ()
        {
			int index = 0;
			// Do things differently if vertical
			if (rom.IsVertical(levelCode))
            {
				for (int y = 0; y < tilemap.GetLength(1); y++)
                {
					for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
						var value = tilemap[x, y];
						rom.Write16(tilemapOffset + index, value, true);
						index += 2;
                    }
                }
            }
			else
            {
				for (int x = 0; x < tilemap.GetLength(0); x++)
				{
					for (int y = 0; y < tilemap.GetLength(1); y++)
					{
						var value = tilemap[x, y];
						rom.Write16(tilemapOffset + index, value, true);
						index += 2;
					}
				}

			}

		}
		public List<byte> WriteTilemapToFile ()
        {
            List<byte> @return = new List<byte>();
			int index = 0;
			// Do things differently if vertical
			if (rom.IsVertical(levelCode))
            {
				for (int y = 0; y < tilemap.GetLength(1); y++)
                {
					for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
                        var value = tilemap[x, y];
                        @return.Add((byte)(value >> 0));
                        @return.Add((byte)(value >> 8));

                        index += 2;
                    }
                }
            }
			else
            {
				for (int x = 0; x < tilemap.GetLength(0); x++)
				{
					for (int y = 0; y < tilemap.GetLength(1); y++)
					{
                        var value = tilemap[x, y];
                        @return.Add((byte)(value >> 0));
                        @return.Add((byte)(value >> 8));

                        index += 2;
                    }
                }

			}
            return @return;

		}
		public List<byte> WriteTilemapToFileFMF ()
        {
            List<byte> @return = new List<byte>();
			int index = 0;
			// Do things differently if vertical
            if (!rom.IsVertical(levelCode))
            {
                // Rotate tm
                int[,] newTm = new int[tilemap.GetLength(1), tilemap.GetLength(0)];
                for (int y = 0; y < tilemap.GetLength(1); y++)
                {
                    for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
                        newTm[y, x] = tilemap[x, y];
                    }
                }

            }
            if (rom.IsVertical(levelCode))
            {
				for (int y = 0; y < tilemap.GetLength(1); y++)
                {
					for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
                        var value = tilemap[x, y];
                        @return.Add((byte)(value >> 0));
                        @return.Add((byte)(value >> 8));

                        index += 2;
                    }
                }
            }
            else
            {
                for (int y = 0; y < tilemap.GetLength(1); y++)
                {
                    for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
                        var value = tilemap[x, y];
                        @return.Add((byte)(value >> 0));
                        @return.Add((byte)(value >> 8));

                        index += 2;
                    }
                }

                // Rotate tilemap

            }
            return @return;

		}

        //public List<>

		public List<byte> WriteTilemapToFile (int startX, int endX)
        {
            List<byte> @return = new List<byte>();
			int index = 0;
			// Do things differently if vertical
			if (rom.IsVertical(levelCode))
            {
				for (int y = 0; y < tilemap.GetLength(1); y++)
                {
					for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
						var value = tilemap[x, y];
                        @return.Add((byte)value);
						index += 1;
                    }
                }
            }
			else
            {
				for (int x = startX; x < endX; x++)
				{
					for (int y = 0; y < tilemap.GetLength(1); y++)
					{
                        var value = tilemap[x, y];
                        @return.Add((byte)(value >> 0));
                        @return.Add((byte)(value >> 8));

                        index += 2;
                    }
                }

			}
            return @return;

		}

		private List<Camera> ScanCameraMap()
        {
			List<Camera> @return = new List<Camera>();
			if (!rom.IsVertical(levelCode))
			{
				int address, index = 0;
				address = rom.Read16(0xbc8000 | levelCode * 2) | 0xbc0000;
                cameraOffset = address;

				while (rom.Read16(address) != 0xffff)
				{
					@return.Add(new Camera(address, rom, this, index++));

					// Next object
					address += 8;
				}

			}
			else
            {
			}
			return @return;
		}
		// Croc and slipslide do manual
		public void WriteCamerasToROM()
        {
            // Write addresses
            for (int i = 0; i < cameraBoxes.Count; i++)
            {
                var cam = cameraBoxes[i];
                cam.address = cameraOffset + i * 8;
            }

            foreach (var cam in cameraBoxes)
            {
				cam.WriteCamToROM();
            }
        }
		public void WriteBananasToROM()
        {
            // Reorganize address order
            for (int i = 0; i < bananas.Count; i++)
            {
                int newBanAddress = bananaMapOffset + i * 4;
                bananas[i].address = newBanAddress;
            }
			foreach (var b in bananas)
            {
                b.WriteAllToROM();
            }
        }
		public void WritePathsToROM()
        {
            // Write new addresses

            int index = 0;
			foreach (var p in platformPaths)
            {
                int address = pathAddresses[index++];
                rom.WriteArrToROM(pathArray[address], address);
            }
        }
		public void WriteAll()
        {
            if (Global.writeTm)
            {
                WriteTilemapToROM();
                WriteTilemapToROM();
            }
            if (levelCode > 0xe5)
            {
                return;
            }

            if (Global.writeEntrances)
            {
                WriteEntrancesToROM();
            }
            if (Global.writeCameras)
            {
                WriteCamerasToROM();
                WriteVcamsToROM();
            }
            if (Global.writeBananas)
            {
                WriteBananasToROM();
            }
            if (Global.writePaths)
            {
                WritePathsToROM();
            }
            //WriteLayersToROM();

            if (Global.writeEntities)
            {
                WriteObjectsToROM();
            }
            // Reset static vars
            Entity.counter = 0;
			Entrance.counter = 0;

		}
        private List<List<PlatformPath>> GetTrackPaths()
        {
            pathAddresses = new List<int>();
            List<List<PlatformPath>> @return = new List<List<PlatformPath>>();

            var platformEntities = entities.Where(e => e.wram[0xd45] == 0x58 && e.wram[0x100] == 0).ToArray();
            int index = 0;
            foreach (var ent in platformEntities)
            {
                var path = GetSinglePath(index++, ent.wram[0x1375]);
                @return.Add(path);
            }
            return @return;
        }
        private List<PlatformPath> GetSinglePath(int num, int pointer)
        {
            
            List<PlatformPath> @return = new List<PlatformPath>();
            int address = 0xb60000 | pointer;
            pathAddresses.Add(address);

            int previousSpeed = 0;
            for (int i = 0, index = 0; rom.Read16(address + i) != 0xffff; index++)
            {
                bool full = rom.Read16(address + i) == 0xfffe;
                var temp = new PlatformPath(address + i, rom, this, index, num, full, previousSpeed);
                @return.Add(temp);
                if (rom.Read16(address + i) == 0xfffe)
                    previousSpeed = rom.Read16(address + i + 2);
                i += rom.Read16(address + i) == 0xfffe ? 8 : 4;
            }

            return @return;

        }

        private Bitmap DrawChar(int[][] @char, List<Color> palette)
        {
            DirectBitmap bmp = new DirectBitmap(8, 8);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bmp.SetPixel(i, j, palette[@char[i][j]]);
                }
            }
            return bmp.Bitmap;

        }
        public byte[] GetCameraAsFile()
        {
            List<byte> @return = new List<byte>();
            if (!rom.IsVertical(levelCode))
            {
                foreach (var cam in cameraBoxes)
                {
                    @return.AddRange(cam.GetCaneraAsBytes());
                }
            }

            return @return.ToArray();
        }
        public byte[] GetBananasAsFile()
        {
            List<byte> @return = new List<byte>();
            foreach (var b in bananas)
            {
                @return.AddRange(b.GetBananaAsBytes());
            }

            return @return.ToArray();
        }
        public byte[] GetEntrancesAsFile()
        {
            List<byte> @return = new List<byte>();
            foreach (var entr in entrances)
            {
                @return.Add((byte)(entr.address >> 16));
                @return.Add((byte)(entr.address >> 8));
                @return.Add((byte)(entr.address >> 0));
                @return.AddRange(entr.GetEntranceAsBytes());
            }

            return @return.ToArray();
        }

        public byte[] GetPathsAsFile()
        {
            List<byte> @return = new List<byte>();
            foreach (var paths in platformPaths)
            {
                List<byte> one = new List<byte>();
                one.AddRange(Enumerable.Repeat((byte)0, 8));
                one.Add((byte)(paths[0].address >> 16));
                one.Add((byte)(paths[0].address >> 8));
                one.Add((byte)(paths[0].address >> 0));
                int count = 0;
                foreach ( var path in paths)
                {
                    var arr = path.GetBytes();
                    count += arr.Length;
                }
                one.Add((byte)(count >> 8));
                one.Add((byte)(count >> 0));

                foreach ( var path in paths)
                {
                    one.AddRange(path.GetBytes());
                }
                if (one.Count > 1)
                    one = one.Skip(8).ToList();
                @return.AddRange(one);

            }

            return @return.ToArray();
        }
        // False if can't fit
        // id = 58, 1375 = pointer, bank b6
        public bool CheckSizeOfPath()
        {
            for (int i = 0; i < platformPaths.Count; i++)
            {
                List<byte> arr = new List<byte>();
                for (int j = 0; j < platformPaths[i].Count; j++)
                {
                    var b = platformPaths[i][j].GetBytes();
                    if (b[0] == 0xff && b[1] == 0xff)
                    {
                        break;
                    }
                    arr.AddRange(platformPaths[i][j].GetBytes());
                }
                arr.Add(0xff);
                arr.Add(0xff);
                int address = pathAddresses[i];
                //int address = platformPaths[i][0].address;
                pathArray[address] = arr.ToArray();
                if (arr.Count > sizeByPlatform[address])
                {
                    return false;
                }
            }

            return true;
        }
        private void WriteCustomPathsToROM()
        {

        }
        
	}
}
