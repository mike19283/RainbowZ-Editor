using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class Form1
    {
        int bulkEndingCode = 0x68;
        List<ExportImport> datas = new List<ExportImport>();
        bool firstImport = false;
        private void exportStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<byte> stage = new List<byte>();
            GetStageForExport(stage);

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(s.FileName, stage.ToArray());
            }

        }

        private void GetStageForExport(List<byte> stage)
        {
            byte[] rainbowBytes = Encoding.ASCII.GetBytes("Rainbow19283");
            // 0
            stage.AddRange(thisLevel.WriteTilemapToFile());
            stage.AddRange(rainbowBytes);
            stage.AddRange(thisLevel.GetObjectMapFile());
            stage.AddRange(rainbowBytes);
            // 2
            stage.AddRange(thisLevel.GetCameraAsFile());
            stage.AddRange(rainbowBytes);
            stage.AddRange(thisLevel.GetBananasAsFile());
            stage.AddRange(rainbowBytes);
            // 4
            stage.AddRange(thisLevel.GetEntrancesAsFile());
            stage.AddRange(rainbowBytes);
            stage.AddRange(thisLevel.GetPathsAsFile());
            stage.AddRange(rainbowBytes);
            // 6
            stage.AddRange(thisLevel.GetLevelAttributesForExport());
            stage.AddRange(rainbowBytes);
            // 7
            stage.AddRange(thisLevel.GetLevelBoundariesForExport());
            stage.AddRange(rainbowBytes);
            // 8
            stage.AddRange(thisLevel.GetLevelMusicForExport());
            stage.AddRange(rainbowBytes);
            // 9
            stage.AddRange(GetMisc16ForExport());
            stage.AddRange(rainbowBytes);
            // 10
            stage.AddRange(GetMisc8ForExport());
            stage.AddRange(rainbowBytes);
            // 11 - ASM flag
            byte add = (byte)(rom.CheckSignature() ? 1 : 0);
            stage.Add(add);
            stage.AddRange(rainbowBytes);

        }

        private void importStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstImport = true;
            if (thisLevel == null)
            {
                return;
            }
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                byte[] arr = File.ReadAllBytes(d.FileName);
                ImportStage(arr);

                thisLevel = null;
                Level_select_Click(0, new EventArgs());
            }
        }

        private void ImportStage(byte[] arr)
        {
            var parts = Global.SplitArray(arr, "Rainbow19283");

            // Tilemap
            rom.WriteArrToROM(parts[0], thisLevel.tilemapOffset);
            //thisLevel.SetTilemapFromFile(parts[0]);

            if (!rom.IsVertical(thisLevel.levelCode))
            {
                // Objects
                rom.WriteArrToROM(parts[1].ToArray(), thisLevel.entities[0].address);
                // Cameras
                ImportCameras(parts[2]);
            }
            else
            {
                // Objects
                rom.WriteArrToROM(parts[1].ToArray(), thisLevel.verticalLayers[0].entities[0].address);
            }


            // Bananas

            rom.WriteArrToROM(parts[3].ToArray(), thisLevel.bananaMapOffset);
            if (parts[3].Length == 0)
            {
                thisLevel.ClearBananaMap();
            }

            // Entrances
            AddMultipleFromFile(parts[4].ToArray(), 4);

            // Path
            AddMultipleFromFile(parts[5].ToArray(), 8);

            // Attributes
            thisLevel.SetLevelAttributesImport(parts[6]);

            // Boundaries
            thisLevel.SetLevelBoundariesImport(parts[7]);

            // Music
            thisLevel.SetLevelMusicImport(parts[8]);

            // Misc16
            SetMisc16ForImport(parts[9]);

            // Misc8
            SetMisc8ForImport(parts[10]);

            // 11 - ASM flag
            if (parts[11][0] == 1 && firstImport)
            {
                firstImport = false;
                if (MessageBox.Show("Do you want to apply ASM? The previous mod had it.", "ASM", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    LoadSch1eyBins();
                }
            }
        }

        private void AddMultipleFromFile(byte[] arr, int args)
        {
            if (args == 4)
            {
                for (int i = 0; i < arr.Length; i += 3 + args)
                {
                    int address = (arr[i + 0] << 16) | (arr[i + 1] << 8) | (arr[i + 2] << 0);
                    if (args == 4)
                    {
                        rom.Write8(address + 0, arr[i + 3]);
                        rom.Write8(address + 1, arr[i + 4]);
                        rom.Write8(address + 2, arr[i + 5]);
                        rom.Write8(address + 3, arr[i + 6]);
                    }
                }
            }
            else if (args == 8)
            {
                int index = 0;
                while (index < arr.Length)
                {
                    int address = (arr[index++] << 16) |
                                  (arr[index++] << 8) |
                                  (arr[index++] << 0);
                    int size = (arr[index++] << 8) |
                               (arr[index++] << 0);
                    for (int i = 0; i < size; i++)
                    {
                        rom.Write8(address++, arr[index++]);
                    }

                }
            }
        }
        private byte[] GetMisc8ForExport()
        {
            List<byte> @return = new List<byte>();
            int levelCode = thisLevel.levelCode;
            @return.AddRange(rom.Read8ForExport(rom.LEVELCOORDSX + levelCode));
            @return.AddRange(rom.Read8ForExport(rom.LEVELCOORDSY + levelCode));
            @return.AddRange(rom.Read8ForExport(rom.LEVELCOORDSZ + levelCode));
            return @return.ToArray();
        } 
        private byte[] GetMisc16ForExport()
        {
            List<byte> @return = new List<byte>();
            @return.AddRange(rom.Read16LDAForExport(0xb987ed)); // Squawks
            @return.AddRange(rom.Read16LDAForExport(0xb6d150)); // K Rool
            @return.AddRange(rom.Read16LDAForExport(0xb8829b)); // Kong start

            foreach (var address in rom.WORLDTERMINATORS)
            {
                @return.AddRange(rom.Read16LDAForExport(address));
            }
            return @return.ToArray();
        } 
        private void SetMisc8ForImport (byte[] arr)
        {
            for (int i = 0; i < arr.Length; i += 4)
            {
                var segment = arr.Skip(i).Take(4).ToArray();
                rom.Write8Import(segment);
            }
        }
        private void SetMisc16ForImport (byte[] arr)
        {
            for (int i = 0; i < arr.Length; i += 5)
            {
                var segment = arr.Skip(i).Take(5).ToArray();
                rom.Write16Import(segment);
            }
        }
        private void exportBulkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 45
            List<byte> bulk = new List<byte>();
            byte[] bulkBytes = Encoding.ASCII.GetBytes("BulkExport");

            datas = new List<ExportImport>();

            for (int i = 0; true; i++)
            {
                comboBox_stages.SelectedIndex = i;
                comboBox_stages.Refresh();
                string x = comboBox_stages.SelectedItem.ToString();
                if (x == "")
                    continue;
                Level_select_Click(0, new EventArgs());
                if (thisLevel.levelCode == bulkEndingCode)
                    break;
                if (thisLevel.levelCode >= 0xe0)
                    continue;
                pictureBox_tilemap.Refresh();
                GetStageForExport(bulk);
                bulk.AddRange(bulkBytes);

            }

            // Misc
            bulk.AddRange(rom.ReadSubArray(0xb59000, 0x6fff, rom.rom.ToArray()));
            bulk.AddRange(bulkBytes);

            // Text
            int size = 0xb8a7e6 - 0xb8a07a;
            const int textAddr = 0xb8a07a;

            byte[] textArr = GetArr(size, textAddr);
            bulk.AddRange(textArr);
            bulk.AddRange(bulkBytes);

            // BG Palette            
            // B99A14 - B9D683 + 0x100
            int bgPalAddr = 0xb99a14;
            int bgPalSize = 0xb9d683 - bgPalAddr + 0x101;
            bulk.AddRange(GetArr(bgPalSize, bgPalAddr));
            bulk.AddRange(bulkBytes);

            // Obj Palette            
            // BC8226 - BC9016 + 0x1e
            int objPalAddr = 0xbc8226;
            int objPalSize = 0xbc9016 - objPalAddr + 0x1f;
            bulk.AddRange(GetArr(objPalSize, objPalAddr));
            bulk.AddRange(bulkBytes);

            // Kf
            bulk.AddRange(GetArr(0x7fff, 0xbc0000));
            bulk.AddRange(bulkBytes);

            // Credits
            bulk.AddRange(Global.ExportCredits(rom));
            bulk.AddRange(bulkBytes);


            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(s.FileName, bulk.ToArray());
            }

        }

        private byte[] GetArr(int size, int addr)
        {
            return rom.ReadSubArray(addr, size, rom.rom.ToArray());
        }

        private void importBulkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }
            firstImport = true;
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                byte[] arr = File.ReadAllBytes(d.FileName);
                var parts = Global.SplitArray(arr, "BulkExport");
                int index = 0;


                for (int i = 0; true; i++)
                {
                    thisLevel = null;
                    comboBox_stages.SelectedIndex = i;
                    comboBox_stages.Refresh();
                    string x = comboBox_stages.SelectedItem.ToString();
                    if (x == "")
                        continue;
                    Level_select_Click(0, new EventArgs());
                    pictureBox_tilemap.Refresh();
                    if (thisLevel.levelCode == bulkEndingCode)
                        break;

                    if (thisLevel.levelCode >= 0xe0)
                    {
                        continue;
                    }
                    ImportStage(parts[index++]);

                }

                // Import misc
                // Entity init bank
                rom.WriteArrToROM(parts[index++], 0xb59000);

                // Text 0xb8a07a
                rom.WriteArrToROM(parts[index++], 0xb8a07a);

                // BG Pal
                int bgPalAddr = 0xb99a14;
                rom.WriteArrToROM(parts[index++], bgPalAddr);


                // Obj Pal
                int objPalAddr = 0xbc8226;
                rom.WriteArrToROM(parts[index++], objPalAddr);

                // Kf
                rom.WriteArrToROM(parts[index++], 0xbc0000);


                // Credits
                Global.ImportCredits(rom, parts[index++]);

                thisLevel = null;
                pictureBox_tilemap.Image = null;
                //comboBox_stages.SelectedIndex = 0;
                comboBox_stages.Refresh();
                Level_select_Click(0, new EventArgs());
                MessageBox.Show("Done");
            }
        }
        private void ImportCameras (byte[] arr)
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                int address = thisLevel.cameraBoxes[0].address;
                rom.Write8(address + i, arr[i++]);
                rom.Write8(address + i, arr[i++]);
                rom.Write8(address + i, arr[i++]);
                rom.Write8(address + i, arr[i++]);
                rom.Write8(address + i, arr[i++]);
                rom.Write8(address + i, arr[i++]);
        
            }
        }

    }
    class ExportImport
    {
        public int address;
        public byte[] data;

        public ExportImport(byte[] data, int address)
        {
            this.data = data;
            this.address = address;
        }
    }
}
