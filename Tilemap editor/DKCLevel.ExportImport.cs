using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class DKCLevel
    {
        public byte[] GetLevelAttributesForExport()
        {
            List<byte> @return = new List<byte>();
            foreach (var related in relatedLevels)
            {
                int code = related.code;
                int address = rom.ATTRIBUTES + code * 2;
                int val = rom.Read16(address);

                @return.Add((byte)(address >> 16));
                @return.Add((byte)(address >> 8));
                @return.Add((byte)(address >> 0));
                @return.Add((byte)(val >> 0));
                @return.Add((byte)(val >> 8));

            }

            return @return.ToArray();
        }
        public void SetLevelAttributesImport(byte[] arr)
        {
            for (int i = 0; i < arr.Length; i += 5)
            {
                int address = (arr[i + 0] << 16) |
                              (arr[i + 1] << 8) |
                              (arr[i + 2] << 0);
                rom.Write8(address + 0, arr[i + 3]);
                rom.Write8(address + 1, arr[i + 4]);
            }
        }
        public byte[] GetLevelBoundariesForExport()
        {
            List<byte> @return = new List<byte>();

            var pointer = rom.Read16(0xbc8000 + levelCode * 2) - 4;

            int address = 0xbc0000 + pointer;

            @return.Add((byte)(address >> 16));
            @return.Add((byte)(address >> 8));
            @return.Add((byte)(address >> 0));
            @return.Add((byte)rom.Read8(address + 0));
            @return.Add((byte)rom.Read8(address + 1));
            @return.Add((byte)rom.Read8(address + 2));
            @return.Add((byte)rom.Read8(address + 3));



            return @return.ToArray();
        }
        public void SetLevelBoundariesImport(byte[] arr)
        {
            int address = (arr[0] << 16) |
                            (arr[1] << 8) |
                            (arr[2] << 0);
            rom.Write8(address + 0, arr[3]);
            rom.Write8(address + 1, arr[4]);
            rom.Write8(address + 2, arr[5]);
            rom.Write8(address + 3, arr[6]);
        }
        public byte[] GetLevelMusicForExport()
        {
            List<byte> @return = new List<byte>();
            foreach (var related in relatedLevels)
            {
                int code = related.code;
                int address = rom.MUSICTRACK + code * 2;
                int val = rom.Read16(address);

                @return.Add((byte)(address >> 16));
                @return.Add((byte)(address >> 8));
                @return.Add((byte)(address >> 0));
                @return.Add((byte)(val >> 0));
                @return.Add((byte)(val >> 8));

            }

            return @return.ToArray();
        }
        public void SetLevelMusicImport(byte[] arr)
        {
            for (int i = 0; i < arr.Length; i += 5)
            {
                int address = (arr[i + 0] << 16) |
                              (arr[i + 1] << 8) |
                              (arr[i + 2] << 0);
                rom.Write8(address + 0, arr[i + 3]);
                rom.Write8(address + 1, arr[i + 4]);
            }
        }

    }
}
