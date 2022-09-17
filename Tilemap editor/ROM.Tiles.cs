using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class ROM
    {
		public struct SNESCharStruct
        {
			public List<List<byte>> @char;
			public SNESCharStruct (List<List<byte>> @char)
            {
				this.@char = @char;
            }
        }
		public List<byte[]> tile_vram = new List<byte[]>();
		public static int compressedSize = 0;
		public int metaTilemapOffset = 0;
		public byte[] metaTileset;

        // b89700
		// 5690 - compressed jungle
		public static byte[] DecompressDKC1 (byte[] compressed)
        {
			Cursor.Current = Cursors.WaitCursor;


			List<byte> decompressed = new List<byte>();
			// Index in compressed
			int cIndex = 0x80;
			// Loop through compressed commands
			while (compressed[cIndex] != 0)
            {
				byte command = compressed[cIndex++];
				// Raw, write, copy, common
				byte rawCommand = (byte)(command & 0xc0);
				if (rawCommand == 0xc0)
                {
					// Common
					int commonIndex = (command & 0x3f) * 2;
					decompressed.Add(compressed[commonIndex++]);
					decompressed.Add(compressed[commonIndex++]);

				}
				else if (rawCommand == 0x80)
				{
					// Copy
					int n = command & 0x3f;
					// Index in decompressed
					int dIndex = (compressed[cIndex++] << 0) | (compressed[cIndex++] << 8);

					// Copy n bytes
					while (n-- > 0)
                    {
						decompressed.Add(decompressed[dIndex++]);
                    }

				}
				else if (rawCommand == 0x40)
				{
					// Write
					int n = command & 0x3f;
					byte toRepeat = compressed[cIndex++];
					while (n-- > 0)
                    {
						decompressed.Add(toRepeat);
                    }
				}
				else if (rawCommand < 0x40)
                {
					// Raw
					int n = command & 0x3f;

					// Loop through number of raw
					while (n-- > 0)
                    {
						decompressed.Add(compressed[cIndex++]);
                    }

                }
				else
                {
					throw new Exception("Invalid command");
                }

			}

			compressedSize = cIndex;
			
			return decompressed.ToArray();

			Cursor.Current = Cursors.Default;

		}
		public List<List<byte>> DrawCharIndexes(byte[] @char)
		{

			List<List<byte>> @return = new List<List<byte>>();

			// Rows of resulting image
			for (int i = 0, index = 0; i < 8; i++)
			{
				@return.Add(new List<byte>());
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
					int whichPal = (colorIndex & 0xf0) >> 4;
					int whichCol = (colorIndex & 0xf) >> 0;

					@return[i].Add((byte)colorIndex);
				}
				index += 2;

			}


			return @return;
		}
		public void LoadVRAM(byte[] arr)
        {
			for (int i = 0; i < arr.Length; i += 0x20)
            {
				var sub = ReadSubArray(i, 0x20, arr);
				//var temp = DrawCharIndexes(sub);
				//tile_vram.Add(new SNESCharStruct(temp));
				tile_vram.Add(sub);
            }
        }
		public void ConstructTiles ()
        {

        }
		// Send tileset to dma
		// Palette to load 39A1DC

	}

}
