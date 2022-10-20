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
    public partial class ROM
    {
        public List<byte> rom = new List<byte>();
        public List<byte> tryCatch = new List<byte>();
        public byte[] backupRom;
        public string fileName = "";
        public bool loadROMSuccess = false;
        public bool saved = false;
        public static int seed = 0;
        public StoredData sd;
        public int maxFileNameLength = 80;
        public static string gameTitleAsString;
        public string path = "";
        public Stack<byte[]> backedupList = new Stack<byte[]>();
        public static string emuPath;
        public static string romPath = "test.smc";
        //public static string romPath = Global.romPath;
        public Dictionary<string, string> gameBGpointers = new Dictionary<string, string>();
        public Dictionary<string, string> gameObjpointers = new Dictionary<string, string>();
        public Dictionary<string, string> gameCustompointers = new Dictionary<string, string>();

        public int romVersion = 0;
        public int backupIndex = 0;
        public string backupFileName = "";
        private int maxBackupCount = 50;

        public ROM(StoredData sd)
        {
            this.sd = sd;
        }

        public void Load (string category = "Path") 
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "ROM file (*.smc;*.sfc)|*.smc;*.sfc";
            d.Title = "Select a proper DKC ROM";

            while (d.ShowDialog() == DialogResult.OK)
            {
                if (LoadROM(d.FileName, category))
                    break;
            }
        }
        public  bool LoadROM (string path, string category = "Path", bool  notHex = true)
        {


            // Refresh Ini
            sd.RefreshRbs();
            //Loading my file and displaying all my content.
            backupRom = File.ReadAllBytes(path);
            backupRom = backupRom.Skip(backupRom.Length == 0x400200 ? 0x200 : 0).ToArray();
            
            // As seen in header
            var gameTitle = new ArraySegment<byte>(backupRom, 0XFFC0, 21).ToArray();
            gameTitleAsString = GetTitleFromHeader(gameTitle);
            // Verify checksum
            //if (GetChecksum(backupRom) == 0x163e1202.ToString("x"))
            if (backupRom[0xffdb] == 0 && (VerifyROM(gameTitle, "DONKEY KONG COUNTRY  ") || VerifyROM(gameTitle, "DKC Hack   [DKC v1.0]")))
            {
                AddToLevel();

                // Copy backup to main
                RestoreFromBackup();
                loadROMSuccess = true;

                this.path = path;
                this.fileName = path;

                fileName = path;
                // Add to recents
                //sd.AddToRecents(path);

                // TODO add check for recents
                // Write to ini as recent
                if (notHex)
                {
                    sd.Write("File", category, path);
                    sd.SaveRbs();
                }

                backedupList = new Stack<byte[]>();
                var temp = new List<byte>();
                temp.AddRange(rom.ToArray());
                backedupList.Push(temp.ToArray());

                gameBGpointers = sd.ReadCategory(gameTitleAsString + "BG");
                gameObjpointers = sd.ReadCategory(gameTitleAsString + "Obj");
                gameCustompointers = sd.ReadCategory(gameTitleAsString + "Custom");


                System.IO.File.WriteAllBytes("Backup-Start.smc", rom.ToArray());

                backupFileName = Global.FileNameParse(path);
                //ReadBackup();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid file");
                return false;
            }

        }

        private void ReadBackup()
        {

            string backupString = Global.FileNameParse(fileName);
            var str = ReadString(Global.signatureAddress, 7);
            try
            {
                backupFileName = ReadString(Global.signatureAddress + 8, 0x20);
                var index = sd.Read("ROM Backup Index - " + backupFileName, "Index");
                backupIndex = Convert.ToInt32(index);
            }
            catch
            {
                //WriteString(0xca6f08, backupString);
                //backupFileName = ReadString(Global.signatureAddress + 8, 0x20);

                backupFileName = Global.FileNameParse(fileName);
                sd.Write("ROM Backups - " + backupFileName, backupIndex.ToString(), DateTime.Now.ToString());
                sd.Write("ROM Backup Index - " + backupFileName, "Index", backupIndex.ToString());
                backupIndex = 0;

                //WriteString(0xca6f00, Global.signatureString);
                Directory.CreateDirectory("Backup Version\\" + backupFileName);
                string backPath = $"Backup Version\\" + backupFileName + $"\\{backupIndex}.bac";
                System.IO.File.WriteAllBytes(backPath, rom.ToArray());
            }
            sd.SaveRbs();
        }

        public UInt16 Read8(Int32 address)
        {
            //address &= 0x3fffff;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)rom[address++];
        }
        public UInt16 Read8(ref Int32 address)
        {
            //address &= 0x3fffff;
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)rom[address++];
        }
        public UInt16 Read16(Int32 address)
        {
            if (address == 0x400000)
            {

            }
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            if (address == 0x400000 || address > 0x3fefff)
            {

            }
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public UInt16 Read16(ref Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public byte[] Read16ForExport(Int32 address)
        {
            int val = Read16(address);
            return new byte[]
            {
                (byte)(address >> 16),
                (byte)(address >> 8),
                (byte)(address >> 0),
                (byte)(val >> 8),
                (byte)(val >> 0),
            };
        }
        public UInt16 Read16LDA(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            address++;
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public byte[] Read8ForExport(Int32 address)
        {
            int val = Read8(address);
            return new byte[]
            {
                (byte)(address >> 16),
                (byte)(address >> 8),
                (byte)(address >> 0),
                (byte)(val >> 0),
            };
        }
        public byte[] Read16LDAForExport(Int32 address)
        {
            address++;
            int val = Read16(address);
            return new byte[]
            {
                (byte)(address >> 16),
                (byte)(address >> 8),
                (byte)(address >> 0),
                (byte)(val >> 8),
                (byte)(val >> 0),
            };
        }
        public UInt32 Read24(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt32)(
                (rom[address++] << 0) |
                (rom[address++] << 8) |
                (rom[address++] << 16));
        }
        public UInt32 Read32(Int32 address)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            return (UInt32)(
                (rom[address++] << 0) |
                (rom[address++] << 8) |
                (rom[address++] << 16) |
                (rom[address++] << 24));
        }
        public string ReadString (int address, int size)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            string str = "";
            for (int i = 0; rom[address + i] != 0; i++)
            {
                str += (char)rom[address + i];
            }

            return str;
        }

        public byte[] ReadSubArray(Int32 address, int size, byte[] arr)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            byte[] @return = new byte[size];
            Array.Copy(arr, address, @return, 0, size);
            //var @return = (new List<byte>(arr.ToList().GetRange(address, size)).ToArray());
            return @return;
        }
        public int[] ReadSubIntArray(Int32 address, int size, byte[] arr)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            byte[] temp = new byte[size];
            Array.Copy(arr, address, temp, 0, size);
            int[] @return = new int[temp.Length / 2];
            for (int i = 0; i < @return.Length; i++)
            {
                int num = (temp[i * 2] << 0) | (temp[i * 2 + 1] << 8);
                @return[i] = num;
            }
            return @return;
        }
        public byte[] ReadSubArrayWithAddress(Int32 address, int size, byte[] arr)
        {
            List<byte> @return = new List<byte>();
            @return.Add((byte)(address >> 16));
            @return.Add((byte)(address >> 8));
            @return.Add((byte)(address >> 0));
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            byte[] temp= new byte[size];
            Array.Copy(arr, address, temp, 0, size);
            //var @return = (new List<byte>(arr.ToList().GetRange(address, size)).ToArray());
            @return.AddRange(temp);
            return @return.ToArray();
        }

        public byte[] ConvertAddressToBytes(int address)
        {
            return new byte[]
            {
                (byte)(address >> 16),
                (byte)(address >> 8),
                (byte)(address >> 0),
            };
        }
        public byte[] ConvertValueToBytes(int value)
        {
            return new byte[]
            {
                (byte)(value >> 0),
                (byte)(value >> 8),
            };
        }


        public void Write8(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);

            //AddToBackupList(rom.ToArray());
        }
        public void Write8(ref Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            if (address >= 0x3c95db && address <= 0x3c95dc)
            {

            }
            rom[address++] = (byte)(value >> 0);
        }
        public void Write16(Int32 address, Int32 value, bool tm = false)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            if (address >= 0x3c95db && address <= 0x3c95dc)
            {

            }
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
        }
        public void Write8Import(byte[] arr)
        {
            int address = (arr[0] << 16) |
                          (arr[1] << 8) |
                          (arr[2] << 0);
            int value = (arr[3] << 0);
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);

            Write8(address, value);
        }
        public void Write16Import(byte[] arr)
        {
            int address = (arr[0] << 16) |
                          (arr[1] << 8) |
                          (arr[2] << 0);
            int value = (arr[3] << 8) |
                        (arr[4] << 0);
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);


            // Actually write
            Write16(address, value);
        }
        public void Write16LDA(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            address++;
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
        }
        public void Write16(ref Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            //AddToBackupList(rom.ToArray());
        }
        public void Write24(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            rom[address++] = (byte)(value >> 16);
            //AddToBackupList(rom.ToArray());
        }
        public void Write32(Int32 address, Int32 value)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            // Actually write
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
            rom[address++] = (byte)(value >> 16);
            rom[address++] = (byte)(value >> 24);
        }

        public void WriteString(Int32 address, string str)
        {
            address &= (address > 0x7fffff ? 0x3fffff : 0xffffff);
            foreach (var letter in str)
            {
                rom[address++] = (byte)(letter);
            }
            //AddToBackupList(rom.ToArray());
        }
        public void WriteArrToROM(byte[] arr, int destIndex)
        {
            List<byte> temp = new List<byte>(rom);
            try
            {
                destIndex &= (destIndex > 0x7fffff ? 0x3fffff : 0xffffff);
                int i = destIndex;
                int index = 0;
                int size = arr.Length;
                while (index < size)
                {
                    Write8(i++, arr[index++]);
                }
            }
            catch
            {
                rom = temp;
            }
        }
        public void WriteSubarrayWithAddress(byte[] arr)
        {
            List<byte> temp = new List<byte>(rom);
            try
            {
                int destIndex = 0;
                destIndex |= (arr[0] << 16);
                destIndex |= (arr[1] << 8);
                destIndex |= (arr[2] << 0);
                destIndex &= (destIndex > 0x7fffff ? 0x3fffff : 0xffffff);
                int i = destIndex;
                int index = 3;
                int size = arr.Length;
                while (index < size)
                {
                    Write8(i++, arr[index++]);
                }
            }
            catch
            {
                rom = temp;
            }
        }
        public void WriteArrOfIntsToROM(int[] arr, int destIndex)
        {
            destIndex &= (destIndex > 0x7fffff ? 0x3fffff : 0xffffff);
            int i = destIndex;
            int index = 0;
            int size = arr.Length;
            while (index < size)
            {
                Write16(i, arr[index++]);
                i++;
                i++;
            }
        }


        public void RestoreFromBackup()
        {
            // Make sure rom is clear
            rom = new List<byte>();
            // Copy Over
            rom.AddRange(backupRom);
        }

        // For ROM validation
        private string GetChecksum(byte[] tempArr)
        {
            Int32 checksum = 0;
            foreach (var @byte in tempArr)
                checksum += @byte;
            return checksum.ToString("x");
        }
        // Compare header title
        public bool VerifyROM (byte[] arr, string headerString)
        {
            // Loop through string
            for (int i = 0; i < headerString.Length; i++)
            {
                if (headerString[i] != (char)arr[i])
                {
                    return false;
                }
            }

            return true;
        }


        // Save file
        public void SaveROM(ComboBox stage)
        {
            WriteBackup();
            System.IO.File.WriteAllBytes(fileName, rom.ToArray());


            saved = true;

            sd.Write("File", "Path", fileName);
            sd.SaveRbs();

            MessageBox.Show("Saved!");

            //RestoreFromBackup();

            WriteToBackup();

        }

        // Save As file
        public void SaveAsROM()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "ROM file (*.smc)|*.smc;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                fileName = dialog.FileName;

                WriteBackup();
                System.IO.File.WriteAllBytes(dialog.FileName, rom.ToArray());


                saved = true;

                sd.Write("File", "Path", fileName);
                sd.SaveRbs();

                MessageBox.Show("Saved!");

                //RestoreFromBackup();

                WriteToBackup();
            }
        }

        private void WriteBackup()
        {
            WriteString(Global.signatureAddress, Global.signatureString);
            backupIndex++;
            backupIndex %= maxBackupCount;
            backupFileName = Global.FileNameParse(path);

            //var backupString = Global.FileNameParse(fileName);
            //var backupFolder = fileName.Substring(0, fileName.Length - 4);
            //WriteString(Global.signatureAddress + 8, backupFileName);
            Directory.CreateDirectory("Backup Version\\" + backupFileName);

            string dateTime = DateTime.Today.ToLongDateString();
            dateTime = DateTime.Now.ToString();
            dateTime = dateTime.Replace('/', '-');
            dateTime = dateTime.Replace(':', ' ');
            //sd.Write("ROM Backups - " + backupFileName, $"{backupIndex}", dateTime);
            //sd.Write("ROM Backup Index - " + backupFileName, "Index", backupIndex.ToString());


            string backPath = $"Backup Version\\" + backupFileName + $"\\{dateTime}.bac";
            System.IO.File.WriteAllBytes(backPath, rom.ToArray());

            RemoveTooMany();
        }

        private void RemoveTooMany()
        {
            var files = Directory.GetFiles("Backup Version\\" + backupFileName);
            while (files.Length >  Convert.ToInt32(Properties.Resources.BackupSize))
            {
                var oldestFile = new DirectoryInfo("Backup Version\\" + backupFileName).GetFiles()
                .OrderBy(f => f.CreationTime).First();
                File.Delete("Backup Version\\" + backupFileName + "\\" + oldestFile.ToString());
                files = Directory.GetFiles("Backup Version\\" + backupFileName);
            }
        }



        public void SaveBackup()
        {
            try
            {
                var x = Global.testROMpath;
                //byte[] arr = Global.ToArray(rom);
                byte[] arr = rom.ToArray();
                System.IO.File.WriteAllBytes(Global.testROMpath, arr);
            }
            catch
            {

            }
        }
        public bool IsROMChanged ()
        {
            if (rom.Count != backupRom.Length)
            {
                return true;
            }
            // Loop through every byte and check
            for (int i = 0; i < rom.Count; i++)
            {
                if (rom[i] != backupRom[i])
                {
                    return true;
                }
            }
            return false;
        }
        private void WriteToBackup ()
        {
            backupRom = new byte[rom.Count];
            for (int i = 0; i < backupRom.Length; i++)
            {
                backupRom[i] = rom[i];
            }
        }

        public string GetTitle()
        {
            var @return = (fileName.Length > maxFileNameLength) ? fileName.Substring(fileName.Length - maxFileNameLength) : fileName;

            return @return;
        }

        public string GetTitleFromHeader (byte[] arr)
        {
            var @return = "";
            foreach (var @byte in arr)
            {
                @return += (char)@byte;
            }
            return @return;
        }

        public void ExpandROM()
        {
            // Expand logically first
            rom[0xffd7] = 0xd;

            // Expand to 6 mb
            var expandBy = new byte[0x200000];
            rom.AddRange(expandBy);

            // - In the file, expand to 6mb and copy the data from 0x008000-0x00FFFF to 0x408000-0x40FFFF
            for (int i = 0x8000; i <= 0xffff; i++)
            {
                rom[0x400000 + i] = rom[i];
            }
            //for (int i = 0x260000; i <= 0x26ffff; i++)
            //{
            //    rom[0x400000 + i] = rom[i];
            //}


            // Deep copy to be sure
            var temp = new List<byte>();
            temp.AddRange(rom);
            // Copy to backup
            //backupRom = temp.ToArray();

        }
        public void AddToBackupList (byte[] arr)
        {
            if (backedupList.Count > 0)
            {
                var topmost = backedupList.Peek();
                if (Global.SequenceEqual(topmost, arr))
                    return;
            }

            List<byte> temp = new List<byte>();
            temp.AddRange(arr);
            backedupList.Push(temp.ToArray());
            foreach(var a in backedupList)
            {
                var z = GetChecksum(a);

            }
        }
        public bool RestoreFromList()
        {
            if (backedupList.Count == 0)
                return false;
            rom = backedupList.Pop().ToList();
            return true;
        }
        public void LaunchEmu()
        {
            try
            {
                SaveBackup();
                System.Diagnostics.Process.Start(emuPath, romPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void SelectROMToLoad ()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Select ROM";
            d.Filter = "SMC/SFC (*.smc;*.sfc)|*.smc;*.sfc";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var temp = d.FileName;
                Global.romPath = d.FileName;

                //sd.Write("Connect", "EmuTest", Global.emuPath);
                sd.Write("Connect", "ROMTest", Global.romPath);
                sd.SaveRbs();

            }
            

        }
        public void SelectEmuPath()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Select emu exe";
            d.Filter = "EXE (*.exe)|*.exe";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var temp = d.FileName;
                emuPath = d.FileName;

                var temp2 = temp.Substring(0, temp.LastIndexOf('\\') + 1);
                
                sd.Write("Connect", "EmuTest", emuPath);
                //sd.Write("Connect", "ROMTest", Global.romPath);
                sd.SaveRbs();

            }

        }
        public List<byte> Clone()
        {
            List<byte> @return = new List<byte>();
            @return.AddRange(rom);
            return @return;
        }
        public bool CheckSignature()
        {
            var str = ReadString(0x3AE09F, 7);
            return str == "Rainbow";
        }
        public bool CheckSignatureNonASM()
        {
            var str = ReadString(0x3AE09F, 7);
            return str == "Rainbow";
        }

        public void CreateTryCatchBackup()
        {
            List<byte> temp = new List<byte>();
            temp.AddRange(rom);
            tryCatch = temp;
        }
        public void RestoreTryCatchBackup()
        {
            rom = tryCatch;
        }
        public string GetCreditTextBlock(byte[] arr)
        {
            string @return = "";
            for (int i = 0; i < arr.Length; i++)
            {
                byte b = arr[i];
                if (b == 0)
                {
                    @return += "\n";
                }
                else if (b >= 0x80)
                {
                    b &= 0x7f;
                    @return += (char)b;
                    @return += "\n";

                }
                else
                {
                    @return += (char)b;
                }
            }
            return @return;
        }
        public string GetTextBlock(byte[] arr)
        {
            string @return = "";
            for (int i = 0; arr[i] != 0; i++)
            {
                byte b = arr[i];
                if (b >= 0x80)
                {
                    b &= 0x7f;
                    @return += (char)b;
                    @return += "\n";
                }
                else
                {
                    @return += (char)b;
                }
            }
            return @return;
        }
        public byte[] GetByteArrayFromCreditTextBlock(string text)
        {
            var last = text[text.Length - 1];
            if (last != 0xa)
            {
                text += '\n';
            }

            List<byte> @return = new List<byte>();
            for (int i = 0; i < text.Length - 1; i++)
            {
                var c = text[i];
                var next = text[i + 1];
                if (c > 0xa && next != 0xa)
                {
                    @return.Add((byte)c);
                }
                else if (c > 0xa && next == 0xa)
                {
                    byte l = (byte)(((byte)c) | 0x80);
                    @return.Add(l);
                }
                else if (c == 0xa &&next == 0xa)
                {
                    @return.Add(0xa0);
                }
                else 
                {
                    continue;
                }


                last = text[i];
            }
            @return.Add(0);
            @return.Add(0);

            return @return.ToArray();

        }

        public byte[] GetByteArrayFromTextBlock(string text)
        {
            text += '\n';
            List<byte> @return = new List<byte>();
            for (int i = 1; i < text.Length; i++)
            {
                var c = text[i];
                var prev = text[i - 1];
                if (prev == 0xa)
                {
                    continue;
                }
                else if (c == 0xa)
                {
                    byte b = (byte)(prev | 0x80);
                    @return.Add(b);
                }
                else
                {
                    @return.Add((byte)prev);
                }
            }
            int count = @return.Count;
            @return.Add(0);

            return @return.ToArray();

        }



    }
}
