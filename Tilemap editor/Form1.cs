using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Tilemap_editor
{
    public partial class Form1 : Form
    {
        public int snapPrecision = 0x20;
        bool once;
        StoredData sd;
        ROM rom;
        DKCLevel thisLevel;
        List<int> tilemap = new List<int>();
        Dictionary<string, Stack<int[,]>> undoTilemap = new Dictionary<string, Stack<int[,]>>();
        string stage = "";
        Dictionary<string, Dictionary<string, int[,]>> keep = new Dictionary<string, Dictionary<string, int[,]>>();
        public EntityEdit edit;
        Entrances entranceEdit;
        CameraEdit cameraEdit;
        BananaEdit bananaEdit;
        List<PictureBox> entityPBox;
        VerticalCameraEdit VerticalCameraEdit;
        bool undo = false;
        bool emu = false;
        int emuTimer = 0;
        int toCopyAddress;
        byte[] toCopy;
        List<Entity> copiedEntities;
        bool finished;
        string entitymapFolder = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Level work\\Entities";
        public bool displayGFX;
        public bool order = false;
        public List<int> commonEntities = new List<int>();
        public List<int> commonEntitiesType = new List<int>();
        public Dictionary<string, int> settings = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Working");
            try
            {
                var myFile = File.ReadAllLines("me.txt");
                foreach (var line in myFile)
                {
                    switch (line)
                    {
                        case "kkr":
                            kRoolEditToolStripMenuItem1.Enabled = true;
                            break;
                        case "mod":
                            modToolStripMenuItem.Visible = true;
                            break;
                        case "bg":
                            bgImporterToolStripMenuItem.Enabled = true;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
            try
            {
                Global.GetBananaGraphic();
            }
            catch
            {

            }



            AddSaveHotkeyToAll(this);
            var directory = Directory.GetFiles("bins\\..");
            foreach (var file in directory)
            {
                if (file.Contains("Backup-End"))
                {
                    loadRestoreLastBackupToolStripMenuItem.Enabled = true;
                    break;
                }
                loadRestoreLastBackupToolStripMenuItem.Enabled = false;
            }

            this.Text = Version.GetVersion() + " - ";
            sd = new StoredData("SDName.rbs");

            string sch1ey = sd.Read("Sch1ey", "mod");
            if (sch1ey != "")
            {
                //sch1eyToolStripMenuItem2.Checked = Convert.ToBoolean(sch1ey);
            }

            comboBox_stages.SelectedIndex = 0;
            //comboBox_stages.SelectedIndex = 33;
            //comboBox_stages.SelectedIndex = 3;
            var update = sd.Read("Connect", "Update");
            if (update == "true")
            {
                checkForUpdateToolStripMenuItem.Checked = true;
                Version.OnLoad();
            }


            AddUndoToAll(this);

#if DEBUG
            //saveTilemapToolStripMenuItem.Enabled = true;
#endif

            //try
            //{
            //    string path = sd.Read("File", "OG");


            //    rom = new ROM(sd);
            //    rom.LoadROM(path, "OG");
            //    //Global.romPath = romP;


            //    LoadOG();
            //}
            //catch (Exception ex) { rom = new ROM(sd); }


            try
            {
                string path = sd.Read("File", "Path");

                LoadROMFromString(path);

            }
            catch (Exception ex) { rom = new ROM(sd); }

            //saveTilemapToolStripMenuItem.Enabled = true;
            //Version.OnLoad();

            var custom = Global.GetCustomEndings(0x4c, rom);
            //File.WriteAllLines("custom.txt", custom);

            try
            {
                string countStr = sd.Read("First", "Count");
                int count;
                if (countStr == "")
                {
                    count = 2;
                }
                else
                {
                    count = Convert.ToInt32(countStr);
                }
                if (count-- > 0)
                {
                    MessageBox.Show("Consider supporting my patreon at https://www.patreon.com/rainbowsprinklez");

                    sd.Write("First", "Count", count.ToString());
                    sd.SaveRbs();

                }


            }
            catch
            {
                sd.Write("First", "Count", "3");
                sd.SaveRbs();
            }


        }

        private void LoadROMFromString(string path, bool backupLoad =  false)
        {
            //var tempBackup = System.IO.File.ReadAllBytes("Backup-Start.smc");
            var tempROM = System.IO.File.ReadAllBytes(path);


            //if (!tempBackup.SequenceEqual(tempROM))
            //{
            //    if (MessageBox.Show("Backup about to be overwritten. Continue?","WARNING!",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //    {
            //        Environment.Exit(-1);
            //        //throw new Exception("Close");
            //    }
            //}

            rom = new ROM(sd);
            rom.LoadROM(path);
            if (!rom.loadROMSuccess)
                return;
            this.Text = Version.GetVersion() + " - " + path;
            string emu = sd.Read("Connect", "EmuTest");
            ROM.emuPath = emu;
            string romP = sd.Read("Connect", "ROMTest");
            //Global.romPath = romP;


            byte[] backup = System.IO.File.ReadAllBytes("test.smc");
            if (!backupLoad && !rom.rom.SequenceEqual(backup))
            {
                if (MessageBox.Show("Restore backup?", "Backup not equal to current.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    rom.rom = new List<byte>();
                    rom.rom.AddRange(backup);
                }
            }
            Init();
        }

        private void Init()
        {
            // Credit fix
            rom.Write8(0x81d323, 0xa9);


            // Multi hit old code overwrite
            byte[] bf849f = new byte[] { 0xa9, 0x02, 0x00, 0x85, 0x84 };
            byte[] bfd060 = new byte[] { 0x22, 0x76, 0xf4, 0xbd };
            byte[] be9dca = new byte[] { 0x5c, 0xa4, 0x80, 0xbe };
            rom.WriteArrToROM(bf849f, 0xbf849f);
            //rom.WriteArrToROM(bfd060, 0xbfd060);
            rom.WriteArrToROM(be9dca, 0xbe9dca);

            saveAfterEachLevelToolStripMenuItem.Checked = rom.Read16(0xc4ff00) == 1;

            var value = rom.Read8(0xbcb946);
            customModsSchleyToolStripMenuItem.Checked = value == 0xea;

            // Read z coord array
            var zCoords = rom.ReadSubArray(rom.LEVELCOORDSZ, 0x100, rom.rom.ToArray());
            overwoldEditToolStripMenuItem.Enabled = !zCoords.SequenceEqual(Global.zeroes);
            //rom.Write16(0xc4ff00, (overwoldEditToolStripMenuItem.Enabled ? 1 : 0));

            aSMModsToolStripMenuItem.Checked = rom.CheckSignature();

            RemoveAllEventListeners();

            //rom.WriteArrToROM(rom.COPYRIGHTINIT, 0x80f299);

            //// Setup backup
            //Global.backupVersion = 0;
            //    Global.backupVersion = rom.Read16(0xca6ff8);
            //// Get backup files
            //string romName = Global.FileNameParse(rom.fileName);
            //Dictionary<string, string> allBackupsByFile = sd.ReadCategory("Backup - " + romName);
            var str = rom.ReadString(Global.signatureAddress, 7);
            if (str == Global.signatureString)
            {
                rom.Write16(0x80f2b3, 0xe4);
                rom.Write16(0x80f2b6, 0x450);
                rom.Write8(0x80f2a2, 0x22);
                rom.Write8(0x80f2a3, 0xad);
                rom.Write8(0x80f2a4, 0x99);
                rom.Write8(0x80f2a5, 0xb9);
            }

            restoreBackupToolStripMenuItem.Enabled = true;
            renameBackupToolStripMenuItem.Enabled = true;
            //rom.ApplyBins();
            rom.objectListRaw = new List<string>();
            rom.objectListRaw.Add("Custom Exits:");
            rom.objectListRaw.AddRange(StringParsing.CustomObjectList(StringParsing.customExitsRaw));
            rom.objectListRaw.Add("");
            rom.objectListRaw.AddRange(rom.objectListRawBackup);
            var mod = sd.Read("Connect", "Mod");
            if (mod == "true")
            {
                Global.mod = true;
                modToolStripMenuItem.Checked = true;
            }
            var sort = sd.Read("Connect", "Order");
            if (sort == "true")
            {
                orderEntitiesToolStripMenuItem.Checked = true;
            }
            //Init_Script_Editor ise = new Init_Script_Editor(sd, rom);
            //ise.Show();
            //ise.saveToolStripMenuItem_Click(0, new EventArgs());
            ////ise.Close();
            // rom.objectListRaw = toAdd;
            rom.ObjectParse();


            // Add all listeners
            pictureBox_tilemap.MouseDown += new MouseEventHandler(MouseDownEntity);
            pictureBox_tilemap.MouseLeave += new EventHandler(MouseLeaveEntity);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(MouseMoveEntity);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(MouseUpEntity);

            pictureBox_tilemap.MouseDown += new MouseEventHandler(PathMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(PathMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(PathMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(PathMouseUp);

            pictureBox_tilemap.MouseDown += new MouseEventHandler(BananaMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(BananaMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(BananaMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(BananaMouseUp);

            pictureBox_tilemap.MouseDown += new MouseEventHandler(CameraMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(CameraMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(CameraMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(CameraMouseUp);

            pictureBox_tilemap.MouseDown += new MouseEventHandler(EntranceMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(EntranceMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(EntranceMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(EntranceMouseUp);

            // V camera
            pictureBox_tilemap.MouseDown += new MouseEventHandler(VCameraMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(VCameraMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(VCameraMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(VCameraMouseUp);

            // Water auto
            pictureBox_tilemap.MouseDown += new MouseEventHandler(WaterMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(WaterMouseLeave);
            pictureBox_tilemap.MouseMove += new MouseEventHandler(WaterMouseMove);
            pictureBox_tilemap.MouseUp += new MouseEventHandler(WaterMouseUp);

            pictureBox_tilemap.MouseMove += new MouseEventHandler(CursorMove);

            pictureBox_tilemap.MouseClick += new MouseEventHandler(AF_MouseClick);

            AddEmuHotkeyToAll(this);

            loadRestoreLastBackupStartToolStripMenuItem.Enabled = true;
            int squawksMod;
            int squawksVersion;
            squawksMod = rom.Read16(0xb987ee);
            reverseSqwuaksToolStripMenuItem.Checked = squawksMod == 0x200;

            int kkrKredits = rom.Read16LDA(0xb6d150);
            quickFakeCreditsToolStripMenuItem.Checked = kkrKredits == 0x0;

            order = orderEntitiesToolStripMenuItem.Checked;

            if (comboBox_stages.SelectedIndex < 0)
                comboBox_stages.SelectedIndex = 0;
            Level_select_Click(0, new EventArgs());
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (thisLevel != null)
            //{
            //    thisLevel.entities = new List<Entity>();
            //    thisLevel.cameraBoxes = new List<Camera>();
            //    thisLevel.platformPaths = new List<List<PlatformPath>>();
            //    thisLevel.entrances = new List<Entrance>();
            //    thisLevel.bananas = new List<Banana>();

            //}
            CloseAll();
            rom.Load();
            this.Text = Version.GetVersion() + " - " + rom.path;
            thisLevel = null;
            saveTilemapToolStripMenuItem.Enabled = false;
            pictureBox_tilemap.Image = new Bitmap(1, 1);
            Init();       
        }

        public void Level_select_Click(object sender, EventArgs e)
        {
            if (thisLevel != null)
            {
                if (thisLevel.CheckSizeOfPath() == false)
                {
                    MessageBox.Show("Overflow on platform paths");
                    return;
                }
            }

            displayGFX = checkBox_image.Checked;

            var squawksModInt = rom.Read16LDA(0xb987ed); // if 200 set
            var kkrQuick = rom.Read16LDA(0xb6d150); // if 0 set
            reverseSqwuaksToolStripMenuItem.Checked = squawksModInt == 0x200;
            quickFakeCreditsToolStripMenuItem.Checked = kkrQuick == 0;


            if (comboBox_stages.SelectedItem.ToString() == "Mine cart c... lol. No")
            {
                MessageBox.Show("Go away, you degenerate");
                return;
            }
            if (rom == null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            if (thisLevel != null && orderEntitiesToolStripMenuItem.Checked)
            {

                thisLevel.OrderEntityList();
                thisLevel.OrderCameraList();
                thisLevel.OrderBananaList();
                //OrderReload();

            }
            //orderEntitiesToolStripMenuItem.Checked = true;
            // Close tileset if present
            if (thisLevel != null && thisLevel.te != null)
            {
                //Global.WriteToArr(rom);
                rom.AddToBackupList(rom.rom.ToArray());
                //undo = false;
                highlightedTilemap = null;
                thisLevel.WriteAll();

                thisLevel.te.Close();
                thisLevel.te.DialogResult = DialogResult.OK;
            }
            if (rom == null)
                return;
            if (!undo)
                rom.AddToBackupList(rom.rom.ToArray());
            undo = false;

            CloseAll();





            stage = comboBox_stages.SelectedItem.ToString();
            //string stage = sender.ToString();
            if (stage.Trim() == "")
            {
                return;
            }
            if (!undoTilemap.ContainsKey(stage))
            {
                undoTilemap[stage] = new Stack<int[,]>();
            }
            //try
            //{
            rom.SaveBackup();

            if (thisLevel != null)
            {
                thisLevel.entities = null;
                thisLevel.entrances = null;
                thisLevel.bananas = null;
                thisLevel.cameraBoxes = null;
                thisLevel.verticalCameras = null;
                thisLevel.verticalCameras = null;
            }
            var str = rom.ReadString(Global.signatureAddress, 7);
            if (stage.Contains("Tanked") && !rom.CheckSignature())
            {
                var arr = File.ReadAllBytes("bins\\platform paths Offset - B68BCC.bin");
                //rom.WriteArrToROM(arr, 0xb68bcc);
            }
            thisLevel = new DKCLevel(stage, rom, this, loadVerticalMapsToolStripMenuItem.Checked);
            radioButton_editEntrances.Visible = !rom.isBonus.ContainsKey(thisLevel.levelCode);

            checkBox_viewPaths.Visible = !rom.IsVertical(thisLevel.levelCode);
            radioButton_editPaths.Visible = !rom.IsVertical(thisLevel.levelCode);
            if (rom.IsVertical(thisLevel.levelCode))
            {
                checkBox_viewPaths.Checked = false;
                radioButton_editPaths.Checked = false;
            }

            

            label_lvlName.Text = $"{stage}: {thisLevel.levelCode.ToString("X2")}";
            //var arr = LoadTilemap();

            // ==================================================
            //var arr = LoadTilemap();

            //if (!rom.IsVertical(thisLevel.levelCode))
            //{
            //    //var subArray = (new List<int>(thisLevel.tilemap).GetRange(0, 26 * 16)).ToArray();

            //    thisLevel.SetTilemapFromFile(arr);
            //    Bitmap bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
            //    pictureBox_tilemap.Image = bmp;
            //    pictureBox_tilemap.Size = bmp.Size;
            //    //pictureBox_tilemap.Size = thisLevel.sizeOfTileMapImage;
            //}
            //else
            //{
            //    thisLevel.SetTilemapFromFileVertical(arr);
            //    Bitmap bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
            //    pictureBox_tilemap.Image = bmp;
            //    pictureBox_tilemap.Size = bmp.Size;

            //}

            // ==================================================

            DrawScreen();
            this.TopMost = true;
            this.TopMost = false;

            undoTilemap[stage].Push((int[,])thisLevel.tilemap.Clone());
            keepToolStripMenuItem_Click(0, new EventArgs());

            if (!once)
            {
                radioButton_editEntities.Click += new EventHandler(radioButton_editEntities_CheckedChanged);
                once = true;
            }

            if (radioButton_editEntities.Checked)
            {
                radioButton_editEntities_CheckedChanged(0, new EventArgs());
            }



            //MessageBox.Show(x.ToString("X"));
            Cursor.Current = Cursors.Default;

            timeremuTimer.Enabled = true;
            saveTilemapToolStripMenuItem.Enabled = true;
            pictureBox_tilemap.MouseMove += new MouseEventHandler(MoveMouse_Tile);
            finished = true;
            radioButton_editBananas_CheckedChanged(0, new EventArgs());
            //radioButton_editPaths_CheckedChanged(0, new EventArgs());
            radioButton_editBananas_CheckedChanged(0, new EventArgs());
            radioButton_editPaths_CheckedChanged(0, new EventArgs());
            CloseAll();
            thisLevel.te.Show();
            thisLevel.ShowTileEdit();

            radioButton_editterrain_Click(0, new EventArgs());
            if (radioButton_editEntities.Checked)
            {
                radioButton_editEntities_CheckedChanged(0, new EventArgs());
            }
            if (radioButton_editPaths.Checked)
            {
                radioButton_editPaths_CheckedChanged(0, new EventArgs());
            }
            if (radioButton_editCameras.Checked)
            {
                radioButton_editCameras_CheckedChanged(0, new EventArgs());
            }
        }

        private void checkBox_grid_CheckedChanged(object sender, EventArgs e)
        {
            DrawScreen();
        }

        private byte[] LoadTilemap ()
        {
            byte[] @return = new byte[0];
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Tilemap";
            d.Filter = "bin (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                @return = File.ReadAllBytes(d.FileName);

                var sub = d.FileName.Split(new string[] { "Offset - " }, StringSplitOptions.None)[1];
                sub = sub.Substring(0, sub.Length - 4);

                if (rom.IsVertical(thisLevel.levelCode))
                {
                    sub = sub.Substring(0, 6);
                }

                int offset = Convert.ToInt32(sub, 16);
                thisLevel.tilemapOffset = offset;


            }


            return @return;
        }

        private void exportTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Global.WriteToArr(rom);

            if (rom == null || thisLevel == null)
                return;

            Level_select_Click(0, new EventArgs());
            if (thisLevel.trackBool)
            {
                thisLevel.WriteAll();

                rom.SaveAsROM();
                Level_select_Click(0, new EventArgs());
                this.Text = Version.GetVersion() + " - " + rom.fileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();

            if (d.ShowDialog() == DialogResult.OK)
            {
                int index = d.FileName.LastIndexOf('\\');
                var folder = d.FileName.Substring(0, index);
                DirectoryInfo di = new DirectoryInfo(folder);

                FileInfo[] files = di.GetFiles("*.bin");

                foreach (var file in files)
                {
                    MessageBox.Show($"{file.FullName} - {file.Length.ToString("X")}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < comboBox_stages.Items.Count; i++)
            {
                comboBox_stages.SelectedIndex = i;
                Level_select_Click(0, new EventArgs());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!undoTilemap.ContainsKey(stage) || undoTilemap[stage].Count == 0)
                return;
            thisLevel.tilemap = undoTilemap[stage].Pop();
            DrawScreen();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void UndoHotkey(object semder, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
                undoToolStripMenuItem_Click(0, new EventArgs());
            else if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
                keepToolStripMenuItem_Click(0, new EventArgs());

            //else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                //saveLevelToFolderToolStripMenuItem_Click(0, new EventArgs());


        }
        private void AddUndoToAll (Control parent)
        {
            parent.KeyDown += new KeyEventHandler(UndoHotkey);

            foreach (Control child in parent.Controls)
            {
                AddUndoToAll(child);
            }
        }

        private void keepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stage == "")
                return;
            if (!keep.ContainsKey(stage))
                keep[stage] = new Dictionary<string, int[,]>();
            string now = keep[stage].Count.ToString();
            keep[stage][now] = (int[,])thisLevel.tilemap.Clone();            
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var x = keep.ContainsKey(stage);
            if (keep.ContainsKey(stage) && keep[stage].Count > 0)
            {
                var keys = keep[stage].Keys.ToArray();
                Restore restore = new Restore(keys);

                if (restore.ShowDialog() == DialogResult.OK)
                {
                    undoTilemap[stage].Push((int[,])thisLevel.tilemap.Clone());
                    var key = keys[restore.@return];
                    thisLevel.tilemap = (int[,])keep[stage][key].Clone();
                    DrawScreen();

                }
            }
        }
        public void DrawScreen()
        {
            if (thisLevel == null)
                return;
            if (!radioButton_editterrain.Checked)
            {
                if (thisLevel.te != null)
                {
                    //thisLevel.te.Close();
                }                
            }

            Bitmap bmp;
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
            }
            else
            {
                bmp = thisLevel.ReDrawTilemap(checkBox_grid.Checked);
            }
            if (checkBox_viewCam.Checked)
            {
                foreach (var cam in thisLevel.cameraBoxes)
                {
                    bmp = cam.DrawEntity(bmp, this);
                }
                foreach (var cam in thisLevel.verticalCameras)
                {
                    bmp = cam.DrawEntity(bmp, this);
                }
            }
            if (checkBox_viewEntities.Checked)
            {
                foreach (var entity in thisLevel.entities)
                {
                    bmp = entity.DrawEntity(bmp, this);
                }
                for (int i = 0; i < thisLevel.verticalLayers.Count; i++)
                {
                    var layer = thisLevel.verticalLayers[i];
                    bmp = layer.DrawLayer(bmp);
                    foreach (var entity in layer.entities)
                    {
                        bmp = entity.DrawEntity(bmp, this);
                    }
                }

            }
            if (checkBox_viewEntrances.Checked)
            {
                foreach (var entrance in thisLevel.entrances)
                {
                    bmp = entrance.DrawEntity(bmp, this);
                }
            }
            if (checkBox_viewBananas.Checked)
            {
                foreach (var b in thisLevel.bananas)
                {
                    bmp = b.DrawEntity(bmp, this);
                }
            }
            if (checkBox_viewPaths.Checked)
            {
                for (int i = 0; i < thisLevel.platformPaths.Count; i++)
                {
                    var ppl = thisLevel.platformPaths[i];
                    for (int j = 0; j < ppl.Count; j++)
                    {
                        var path = ppl[j];
                        bmp = path.DrawEntity(bmp, this);
                    }
                }
                
            }
            bmp = DrawEdges(bmp);
            

            if (pictureBox_tilemap.Image != null)
                pictureBox_tilemap.Image.Dispose();

            pictureBox_tilemap.Size = bmp.Size;
            pictureBox_tilemap.Image = bmp;

        }
        private Bitmap DrawEdges (Bitmap bmp)
        {
            if (!checkBox_drawEdges.Checked)
                return bmp;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int width = 0x200;
                var dif = thisLevel.lvlXBoundEnd - thisLevel.lvlXBoundStart;
                for (int i = 0; i < dif; i += width)
                {
                    //
                    var startPnt = new Point(i, 0);
                    var endPnt = new Point(i, 512);
                    var txtPnt = new Point(i + 20, 20);

                    g.DrawLine(new Pen(Color.Yellow), startPnt, endPnt);
                    g.DrawString($"{(i / width).ToString("X2")}", this.Font, new SolidBrush(Color.Yellow), txtPnt);
                }
                if (thisLevel.levelCode == 0x2b)
                {
                    for (int i = 0x400; i < dif; i += 0x300)
                    {
                        //
                        var startPnt = new Point(i, 0);
                        var endPnt = new Point(i, 512);
                        var txtPnt = new Point(i + 20, 40);

                        //g.DrawLine(new Pen(Color.Red, 2), startPnt, endPnt);
                        //g.DrawString($"{((i - 0x400) / 0x300).ToString("X2")}", this.Font, new SolidBrush(Color.Red), txtPnt);
                    }

                }
            }

            return bmp;
        }
        private void checkBox_viewEntities_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;

            radioButton_editEntities.Enabled = checkBox_viewEntities.Checked;

            DrawScreen();
        }


        private void checkBox_entrances_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;

            DrawScreen();
            radioButton_editEntrances.Enabled = checkBox_viewEntrances.Checked;
        }

        private void checkBox_editEntrances_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void entityEditorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EntityEditor entityEditor = new EntityEditor(rom, 0xb413);
            entityEditor.Show();
        }

        private void checkBox_viewCam_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;
            radioButton_editCameras.Enabled = checkBox_viewCam.Checked;
            DrawScreen();
        }

        private void checkBox_viewBananas_CheckedChanged(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;
            radioButton_editBananas.Enabled = checkBox_viewBananas.Checked;
            DrawScreen();

        }

        private void checkBox_editBananas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rom == null || rom.rom.Count == 0)
                return;
            rom.SaveBackup();
            Level_select_Click(0, new EventArgs());
            if (rom.IsROMChanged())
            {
                var str = "WARNING!";
                var warning = "Changes detected. Really quit?"; 
                if (MessageBox.Show(warning,str,MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                System.IO.File.WriteAllBytes("Backup-End.smc", rom.rom.ToArray());
            }
        }


        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Level_select_Click(0, new EventArgs());
            rom.LaunchEmu();
        }

        private void selectROMNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.SelectROMToLoad();
        }

        private void selectPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.SelectEmuPath();
        }

        private void launchEmulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Level_select_Click(0, new EventArgs());
                //System.Diagnostics.Process.Start(Global.emuPath);
                rom.SaveBackup();
                //System.Diagnostics.Process.Start("C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\EmulSNES(16).exe");
                System.Diagnostics.Process.Start(Global.emulPath);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //System.Diagnostics.Process.Start("C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\EmulSNES(16).exe", "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\test.smc");
        }


        private void globalUndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{rom.backedupList.Count}");
            if (rom.RestoreFromList())
            {
                undo = true;
                Level_select_Click(0, new EventArgs());

            }
        }

        private void initScriptEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init_Script_Editor script = new Init_Script_Editor(sd, rom);

            if (script.ShowDialog() == DialogResult.Cancel)
            {
                Level_select_Click(0, new EventArgs());
            }
        }

        private void modToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modToolStripMenuItem.Checked = !modToolStripMenuItem.Checked;
            if (modToolStripMenuItem.Checked)
            {
                sd.Write("Connect", "Mod", "true");
                sd.SaveRbs();

            }
            else
            {
                sd.Write("Connect", "Mod", "false");
                sd.SaveRbs();

            }
            Global.mod = !Global.mod;

        }

        private void clearTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < thisLevel.tilemap.GetLength(0); y++)
            {
                for (int x = 0; x < thisLevel.tilemap.GetLength(1); x++)
                {
                    thisLevel.tilemap[y, x] = 0;

                }

            }
            DrawScreen();
        }

        private void clearCameraMaphorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                for (int i = 0; i < thisLevel.cameraBoxes.Count; i++)
                {
                    // Now we are at the cam level
                    var cam = thisLevel.cameraBoxes[i];
                    cam.yTop = 0;
                    cam.yBottom = 0xff;
                }
                DrawScreen();
            }
            else
            {
            }
        }

        private void clearDefaultEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var entity in thisLevel.entities)
            {
                if (new int[] { 1, 0xf, 0xd }.Contains(entity.type))
                {
                    entity.pointer = 0xa51f;
                    entity.type = 1;
                }
            }
            // Do vertical
            foreach (var layer in thisLevel.verticalLayers)
            {
                foreach (var entity in layer.entities)
                {
                    if (new int[] { 1, 0xf, 0xd }.Contains(entity.type))
                    {
                        entity.pointer = 0xa51f;
                        entity.type = 1;
                    }
                }

            }

            DrawScreen();
        }

        private void orderEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderEntitiesToolStripMenuItem.Checked = !orderEntitiesToolStripMenuItem.Checked;
            order = orderEntitiesToolStripMenuItem.Checked;
            if (orderEntitiesToolStripMenuItem.Checked)
            {
                sd.Write("Connect", "Order", "true");
                sd.SaveRbs();
            }
            else
            {
                sd.Write("Connect", "Order", "false");
                sd.SaveRbs();
            }


            try
            {
                //thisLevel.OrderEntityList();
                //OrderReload();
            }
            catch { }
        }
        private List<Entity> SortEntities(List<Entity> entities)
        {
            for (int i = 0; i < entities.Count - 1; i++)
            {
                if (IsSorted(entities))
                    return entities;

                for (int j = 0; j < entities.Count - i - 1; j++)
                {
                    if (entities[j + 0].x > entities[j + 1].x)
                    {
                        Swap2Entities(entities[j + 0], entities[j + 1]);
                    }
                }
            }

            return entities;
        }
        private bool IsSorted(List<Entity> entities)
        {
            for (int i = 1; i < entities.Count; i++)
            {
                if (entities[i + 0].x < entities[i - 1].x)
                {
                    return false;
                }
            }

            return true;
        }
        private void Swap2Entities (Entity a, Entity b)
        {
            // Index
            a.local ^= b.local;
            b.local ^= a.local;
            a.local ^= b.local;

            // address
            a.address ^= b.address;
            b.address ^= a.address;
            a.address ^= b.address;

            // x
            a.x ^= b.x;
            b.x ^= a.x;
            a.x ^= b.x;

            // y
            a.y ^= b.y;
            b.y ^= a.y;
            a.y ^= b.y;

            // pointer
            a.pointer ^= b.pointer;
            b.pointer ^= a.pointer;
            a.pointer ^= b.pointer;

            // type
            a.type ^= b.type;
            b.type ^= a.type;
            a.type ^= b.type;


        }
        private void LaunchEmu (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && emuTimer == 0)
            {
                launchToolStripMenuItem_Click(0, new EventArgs());
                emuTimer = 20;



            }
        }
        private void AddEmuHotkeyToAll (Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.KeyDown += new KeyEventHandler(LaunchEmu);
                AddEmuHotkeyToAll(child);
            }

        }

        private void timeremuTimer_Tick(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = rom.loadROMSuccess;
            if (emuTimer > 0)
            {
                emuTimer--;
            }
            saveToolStripMenuItem.Enabled = rom != null;
            

        }

        private void verticalCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel.verticalCameras.Count > 0)
            {
                toCopyAddress = thisLevel.verticalCameras[0].address;
                toCopy = rom.ReadSubArray(toCopyAddress, 0x1000, rom.rom.ToArray());
                MessageBox.Show("Copied");
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toCopy != null)
            {
                rom.WriteArrToROM(toCopy, toCopyAddress);
                MessageBox.Show("Pasted");

            }
        }
        public void OrderReload ()
        {
            Level_select_Click(0, new EventArgs());
        }

        private void overwoldEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverworldEditor oe = new OverworldEditor(rom);
            var og = rom.Clone();
          //  try
        //    {
                oe.ShowDialog();
      //      }
    //        catch
  //          {
              //  rom.rom = og;
            //    MessageBox.Show("Error");
//            }
        }


        private void arrayEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var arr = new Array_Editor(rom);

            arr.ShowDialog();

        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisLevel.ReadAllConnections();
        }

        private void loadOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.Load("OG");
            LoadOG();
        }
        private void LoadOG ()
        {
            rom.SetupLinks();

        }

        private void paletteEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Palette_Editor pe = new Palette_Editor(rom, sd, thisLevel.paletteOffset, true);
                pe.ClickGetPalette();
                if (pe.ShowDialog() == DialogResult.OK)
                {
                    Level_select_Click(0, new EventArgs());
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        public void ReloadROM()
        {
            var temp = rom.fileName;
            rom = new ROM(sd);
            rom.LoadROM(temp);
            this.Text = Version.GetVersion() + " - " + rom.GetTitle();
        }

        private void objectCodeStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectFunctions obj = new ObjectFunctions(rom);

            obj.ShowDialog();
        }

        private void kRoolEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var backup = rom.Clone();
            try
            {
                K_Rool_Edit kkr = new K_Rool_Edit(rom, this);
                kkr.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                rom.rom = backup;
            }
        }

        private void expandROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rom.ExpandROM();
            rom.rom = rom.rom.Take(0x400000).ToList();
            MessageBox.Show("Done");
        }

        private void setStartEndOfLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }

            if (rom.IsVertical(thisLevel.levelCode))
            {
                MessageBox.Show("Not supported on vertical levels.");
                return;
            }

            var pointer = rom.Read16(0xbc8000 + thisLevel.levelCode * 2) - 4;
            int startInt = rom.Read16(0xbc0000 + pointer);
            int endInt = rom.Read16(0xbc0002 + pointer);


            string end = Prompt.ShowDialog("Enter in end", "End edit", endInt);
            if (end == "")
                return;
            int ed = Convert.ToInt32(end, 16);
            rom.Write16(0xbc0002 + pointer, ed);
            Level_select_Click(0, new EventArgs());
        }

        private void setStartEndOfLevelrelativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }

            if (rom.IsVertical(thisLevel.levelCode))
            {
                MessageBox.Show("Not supported on vertical levels.");
                return;
            }

            var pointer = rom.Read16(0xbc8000 + thisLevel.levelCode * 2) - 4;
            int startInt = rom.Read16(0xbc0000 + pointer);
            int endInt = rom.Read16(0xbc0002 + pointer);


            string end = Prompt.ShowDialog("Enter in end (relative)", "End edit", endInt);
            if (end == "")
                return;
            int ed = Convert.ToInt32(end, 16);
            rom.Write16(0xbc0002 + pointer, ed + endInt);
            Level_select_Click(0, new EventArgs());

        }

        private void hexEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HexEditor hex = new HexEditor(rom);
            hex.ShowDialog();
        }

        private void selectFrHEdPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Select hex exe";
            d.Filter = "EXE (*.exe)|*.exe";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var temp = d.FileName;

                var temp2 = temp.Substring(0, temp.LastIndexOf('\\') + 1);

                sd.Write("Connect", "Hex", temp);
                //sd.Write("Connect", "ROMTest", Global.romPath);
                sd.SaveRbs();

            }

        }

        private void launchHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Level_select_Click(0, new EventArgs());
            Level_select_Click(0, new EventArgs());
            var code = thisLevel.levelCode;
            var pointer = rom.Read16(0xbd8000 + code * 2);
            var addressInt = (0x3d0000 + pointer);
            var address = (0x3d0000 + pointer).ToString("x");

            if (!Global.entityEdit)
            {
                //Clipboard.SetText(address);

            }

            Global.entityEdit = false;

            try
            {

                string hexPath = sd.Read("Connect","Hex");
                System.Diagnostics.Process.Start(hexPath, Global.testROMpath);
                while (MessageBox.Show("Are you done?","",MessageBoxButtons.YesNo) == DialogResult.No) { }

                var temp = Global.testROMpath;
                rom = new ROM(sd);
                rom.LoadROM(temp, "", false);

                Init();
                Level_select_Click(0, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exportObjectMMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<byte> toExport = new List<byte>();

            if (!rom.IsVertical(thisLevel.levelCode))
            {
                foreach (var entity in thisLevel.entities)
                {
                    toExport.AddRange(entity.GetEntityAsBytes());
                }

                toExport.AddRange(Enumerable.Repeat((byte)0, 8));

                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "BIN (*.bin)|*.bin";

                if (s.ShowDialog() == DialogResult.OK)
                {
                    string newStr = s.FileName.Split('.')[0];

                    var addr = thisLevel.entities[0].address.ToString("X6");

                    File.WriteAllBytes(newStr + " Objects " + addr + ".bin", toExport.ToArray());
                }
            }
            else
            {
                foreach (var layer in thisLevel.verticalLayers)
                {
                    foreach (var entity in layer.entities)
                    {

                        toExport.AddRange(entity.GetEntityAsBytes());
                    }
                }

                toExport.AddRange(Enumerable.Repeat((byte)0, 8));

                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "BIN (*.bin)|*.bin";

                if (s.ShowDialog() == DialogResult.OK)
                {
                    string newStr = s.FileName.Split('.')[0];

                    var addr = thisLevel.verticalLayers[0].entities[0].address.ToString("X6");

                    File.WriteAllBytes(newStr + " Objects " + addr + ".bin", toExport.ToArray());
                }

            }
        }

        private void exportTilemapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            List<byte> toExport = new List<byte>();

            toExport.AddRange(thisLevel.WriteTilemapToFile());

            //toExport.AddRange(Enumerable.Repeat((byte)0, 32));

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                string newStr = s.FileName.Split('.')[0];

                var addr = rom.allTilemapOffsets[thisLevel.lvlName];

                File.WriteAllBytes(newStr + " Tilemap " + addr.ToString("X6") + ".bin", toExport.ToArray());


                //File.WriteAllBytes(s.FileName, toExport.ToArray());

            }

        }

        private void exportSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get range
            int start = Convert.ToInt32(Prompt.ShowDialog("Start", "Bounds"), 16);
            int end = (Convert.ToInt32(Prompt.ShowDialog("End", "Bounds"), 16) + 1);
            List<byte> toExport = new List<byte>();

            toExport.AddRange(thisLevel.WriteTilemapToFile(start * 16, end * 16));

            //toExport.AddRange(Enumerable.Repeat((byte)0, 32));

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BIN (*.bin)|*.bin";
            s.Title = "Tilemap";

            if (s.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(s.FileName, toExport.ToArray());

            }

            List<byte> toExport2 = new List<byte>();

            foreach (var entity in thisLevel.entities)
            {
                var lvlX = thisLevel.lvlXBoundStart & 0xffff;
                if (entity.x > end * 16 * 0x20 + lvlX)
                {
                    break;
                }
                if (entity.x >= start * 16 * 0x20 + lvlX)
                    toExport2.AddRange(entity.GetEntityAsBytes());
            }

            //toExport2.AddRange(Enumerable.Repeat((byte)0, 8));

            SaveFileDialog s2 = new SaveFileDialog();
            s2.Filter = "BIN (*.bin)|*.bin";
            s2.Title = "Objects";


            if (s2.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(s2.FileName, toExport2.ToArray());

            }

        }
        private void MoveMouse_Tile(object sender, MouseEventArgs e)
        {
            int x = e.X / 0x20;
            int y = e.Y / 0x20;

            label_tile.Text = $"({x.ToString("X")},{y.ToString("X")})";

        }

        private void importTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "BIN (*.bin)|*.bin";
            d.Title = "Tilemap";

            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var arr = File.ReadAllBytes(d.FileName);
                    thisLevel.SetTilemapFromFile(arr);
                    Level_select_Click(0, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void clearBananaMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < thisLevel.bananas.Count; i++)
            {
                // Now we are at the cam level
                var b = thisLevel.bananas[i];
                b.type = 2;
                //b.x = 0;
                //b.y = 0x100;
            }
            DrawScreen();

        }


        private void copyAllEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var deepCopy = thisLevel.entities.ToList();
            copiedEntities = deepCopy;
        }

        private void pasteAllEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curr = thisLevel.entities;
            var copy = copiedEntities;
            var currL = curr.Count;
            var copyL = copy.Count;
            int i;
            int address = 0;
            for (i = 0; i < copyL && i < currL; i++)
            {
                address = curr[i].address;
                curr[i].SetEntity(copy[i]);
            }
            rom.Write16(address + 8, 0);
            rom.Write16(address + 10, 0);
            rom.Write16(address + 12, 0);
            rom.Write16(address + 14, 0);
            if (i == copyL)
            {
                MessageBox.Show("Entire map copied");
            }
            else
            {
                MessageBox.Show($"Copied {i} entities");
                MessageBox.Show($"Missing {copyL - i} entities");

            }
            while (i < curr.Count)
            {
                curr.RemoveAt(i);
            }
            Level_select_Click(0, e);
        }

        private void objectMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Object map";
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var file = File.ReadAllBytes(d.FileName);
                int i;
                int index = 0;
                for (i = 0; i < thisLevel.entities.Count && i * 8 < file.Length; i++)
                {
                    var entity = thisLevel.entities[i];
                    entity.type = Read16(ref index, file);
                    entity.x = Read16(ref index, file);
                    entity.y = Read16(ref index, file);
                    entity.pointer = Read16(ref index, file);
                }
                if (thisLevel.entities.Count * 8 > file.Length)
                {
                    MessageBox.Show("Import with space left over");
                    MessageBox.Show($"{thisLevel.entities.Count - i} extra spots");
                }
                else if (i * 8 == file.Length)
                {
                    MessageBox.Show("Perfect import!");
                }
                else
                {
                    MessageBox.Show("Did not copy full map");
                }
            }
        }
        private int Read16 (ref int address, byte[] arr)
        {
            return (arr[address++] << 0) | (arr[address++] << 8);
        }

        private void exportCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cameras = thisLevel.cameraBoxes;
            if (cameras.Count < 1)
            {
                return;
            }
            SaveFileDialog s = new SaveFileDialog();
            s.Title = "Camera map";
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                List<byte> data = new List<byte>();
                foreach (var cam in cameras)
                {
                    // X
                    data.Add((byte)(cam.xLeft >> 0));
                    data.Add((byte)(cam.xLeft >> 8));
                    // YTop
                    data.Add((byte)(cam.yTop >> 0));
                    data.Add((byte)(cam.yTop >> 8));
                    // YBottom
                    data.Add((byte)(cam.yBottom >> 0));
                    data.Add((byte)(cam.yBottom >> 8));
                    data.Add(0);
                    data.Add(0);


                }
                string newStr = s.FileName.Split('.')[0];

                var addr = thisLevel.cameraBoxes[0].address.ToString("X6");

                //File.WriteAllBytes(newStr + " Objects " + addr + ".bin", toExport.ToArray());
                File.WriteAllBytes(newStr + " Cameras " + addr + ".bin", data.ToArray());
            }
        }

        private void camerashorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Camera map";
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var file = File.ReadAllBytes(d.FileName);
                var cameras = thisLevel.cameraBoxes;
                int i;
                int index = 0;
                for (i = 0; i < cameras.Count && i * 8 < file.Length; i++)
                {
                    var camera = cameras[i];
                    camera.xLeft = Read16(ref index, file);
                    camera.yTop = Read16(ref index, file);
                    camera.yBottom = Read16(ref index, file);
                    index += 2;
                }
                if (cameras.Count * 8 > file.Length)
                {
                    MessageBox.Show("Import with space left over");
                    MessageBox.Show($"{cameras.Count - i} extra spots");
                }
                else if (i * 8 == file.Length)
                {
                    MessageBox.Show("Perfect import!");
                }
                else
                {
                    MessageBox.Show("Did not copy full map");
                }
                DrawScreen();
            }


        }

        private void loopAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                string clipboard = "";
                //for (int i = 0; i < 46; i++)
                for (int i = 0; i < comboBox_stages.Items.Count; i++)
                //for (int i = 0; i < 5; i++)
                {
                    comboBox_stages.SelectedIndex = i;
                    if (comboBox_stages.SelectedItem.ToString() == "" || comboBox_stages.SelectedItem.ToString() == "Mine cart c... lol. No")
                    {
                        continue;
                    }
                    Level_select_Click(0, new EventArgs());
                    pictureBox_tilemap.Refresh();
                    SaveAssets(path);


                    //string name = thisLevel.lvlName + " Entities.bin";
                    //var bytes = thisLevel.GetObjectMapFile();
                    //string filename = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Level work\\Entities\\";
                    ////File.WriteAllBytes(filename + name, bytes);

                    //clipboard += $".import    \"Level work/Entities/{name}\"\n";
                }
            }
            //Clipboard.SetText(clipboard);

        }

        private void exportBananasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Title = "Camera map";
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                var bananasAll = thisLevel.bananas;
                List<byte> data = new List<byte>();
                foreach (var banana in bananasAll)
                {
                    // bbbbbbbb yyyyyybb xxxyyyyy xxxxxxxx (base 2)
                    var writeType = banana.type & 0x3fe;
                    var writeX = (banana.x / 8) & 0x7ff;
                    var writeY = (banana.y / 8) & 0x3ffff;
                    var test = writeY * 8;
                    var value = (writeType << 0) | (writeY << 10) | (writeX << 21);
                    //rom.Write32(banana.address, value);
                    data.Add((byte)(value >> 0));
                    data.Add((byte)(value >> 8));
                    data.Add((byte)(value >> 16));
                    data.Add((byte)(value >> 24));
                }
                string newStr = s.FileName.Split('.')[0];

                var addr = thisLevel.bananas[0].address.ToString("X6");

                File.WriteAllBytes(newStr + " Bananas " + addr + ".bin", data.ToArray());
            }

        }

        private void importBananaMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Banana map";
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var file = File.ReadAllBytes(d.FileName);
                string addressStr = d.FileName.Split('.')[0];
                addressStr = addressStr.Substring(addressStr.Length - 6);
                int addr = Convert.ToInt32(addressStr, 16);
                rom.WriteArrToROM(file, addr);
                thisLevel.bananas = thisLevel.ReadBananaMap();
                Level_select_Click(0, new EventArgs());
            }

        }

        private void importObjectsRawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Object map";
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                int pointer = rom.Read16(0xbd8000 + thisLevel.levelCode * 2);
                int addr = 0;
                addr = 0xbd0000 + pointer;


                var file = File.ReadAllBytes(d.FileName);
                rom.WriteArrToROM(file, addr);

                thisLevel = null;
                //thisLevel.entities = thisLevel.ScanObjectMap();
                Level_select_Click(0, new EventArgs());
            }

        }

        private void exportEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Title = "Entrances";
            s.Filter = "BIN (*.bin)|*.bin";

            if (s.ShowDialog() == DialogResult.OK)
            {
                List<byte> data = new List<byte>();

                foreach (var entrance in thisLevel.entrances)
                {
                    data.Add((byte)(entrance.address >> 16));
                    data.Add((byte)(entrance.address >> 8));
                    data.Add((byte)(entrance.address >> 0));
                    data.Add((byte)(entrance.x >> 0));
                    data.Add((byte)(entrance.x >> 8));
                    data.Add((byte)(entrance.y >> 0));
                    data.Add((byte)(entrance.y >> 8));


                    string newStr = s.FileName.Split('.')[0];

                    var addr = entrance.address.ToString("X6");


                }
                File.WriteAllBytes(s.FileName, data.ToArray());

            }


        }

        private void writeObjectMapPointersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rom.pointersOfNewMaps.Count; i++)
            {
                var pointer = rom.pointersOfNewMaps[i];
                var address = 0xbd8000 + i * 2;
                rom.Write16(address, pointer);

            }
        }

        private void allBananasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 46; i++)
            for (int i = 46; i < comboBox_stages.Items.Count; i++)
            {
                comboBox_stages.SelectedIndex = i;
                if (comboBox_stages.SelectedItem.ToString() == "" || comboBox_stages.SelectedItem.ToString() == "Mine cart c... lol. No")
                {
                    continue;
                }
                Level_select_Click(0, new EventArgs());

                pictureBox_tilemap.Refresh();


            }

        }

        private void saveLevelToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Level_select_Click(0, new EventArgs());
            //Thread.Sleep(5000);
            // Folder
            string folder = "C:\\Users\\mikem\\OneDrive\\TASwork\\DKSE\\Level work\\";
            string localFolder = "Level work\\";
            string entrancesStr = "Entrances\\";
            string camerasStr = "Cameras\\";
            string tilemapStr = "Tilemap\\";
            string entitiesStr = "Entities\\";
            string platformStr = "Track Paths\\";
            string patchEn = "Entrances_Patchlist.txt";
            string patchCam = "Cameras_Patchlist.txt";
            string patchTm = "Tilemap_Patchlist.txt";
            string platformTm = "Track Paths_Patchlist.txt";
            string addrString;
            string importString;
            foreach (var entrance in thisLevel.entrances)
            {
                // Save file
                var data = entrance.GetEntranceAsBytes();
                string extra = thisLevel.lvlName + " Entrance " + entrance.entranceCode.ToString("X2");
                string fileName = folder + entrancesStr + extra + ".bin";
                File.WriteAllBytes(fileName, data);
                addrString = "    .addr 0x" + entrance.address.ToString("X6");
                importString = "    .import \"" + localFolder + entrancesStr + extra +".bin\"";

                // Write strings
                string path = folder + entrancesStr + patchEn;
                List<string> file = (File.ReadAllLines(path)).ToList();
                int index = file.IndexOf(addrString);

                if (index != -1)
                {
                    file[index + 1] = importString;
                }
                else
                {
                    file.Add(addrString);
                    file.Add(importString);
                }
                File.WriteAllLines(path, file.ToArray());
            }

            // Get and save tm to file
            byte[] data2 = thisLevel.WriteTilemapToFile().ToArray();
            string fileName2 = folder + tilemapStr + thisLevel.lvlName + ".bin";
            File.WriteAllBytes(fileName2,data2);

            // Construct strings
            var addr = rom.allTilemapOffsets[thisLevel.lvlName];
            addrString = "    .addr 0x" + addr.ToString("X6");
            importString = "    .import \"" + localFolder + tilemapStr + thisLevel.lvlName + ".bin\"";

            // Write strings to file
            string path2 = folder + tilemapStr + patchTm;
            List<string> file2 = (File.ReadAllLines(path2)).ToList();
            int index2 = file2.IndexOf(addrString);
            
            if (index2 != -1)
            {
                file2[index2 + 1] = importString;
            }
            else
            {
                file2.Add(addrString);
                file2.Add(importString);
            }
            File.WriteAllLines(path2, file2.ToArray());


            // Only do if non-vertical
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                // Get cameras
                List<byte> data3 = new List<byte>();
                foreach (var camera in thisLevel.cameraBoxes)
                {
                    data3.AddRange(camera.GetCaneraAsBytes());
                }


                // Save to file
                string strAdd = thisLevel.lvlName + " Cameras.bin";
                File.WriteAllBytes(folder + camerasStr + strAdd, data3.ToArray());

                // Construct strings
                int cameraAddr = thisLevel.cameraBoxes[0].address;
                addrString = $"    .addr 0x{cameraAddr.ToString("X6")}";
                importString = $"    .import \"{localFolder + camerasStr + strAdd}\"";

                // Modify file
                string path3 = folder + camerasStr + patchCam;
                List<string> file3 = (File.ReadAllLines(path3)).ToList();
                int index3 = file3.IndexOf(addrString);

                if (index3 != -1)
                {
                    file3[index3 + 1] = importString;
                }
                else
                {
                    file3.Add(addrString);
                    file3.Add(importString);
                }
                File.WriteAllLines(path3, file3.ToArray());

                // Write entity file (pathlist all set)
                string fileName4 = folder + entitiesStr + thisLevel.lvlName + " Entities.bin";
                var data4 = thisLevel.GetObjectMapFile();

                File.WriteAllBytes(fileName4, data4);

                if (thisLevel.platformPaths.Count > 0)
                {
                    var tempPaths = thisLevel.GetPlatformsForExport();
                    foreach (var tempPath in tempPaths)
                    {
                        int address = tempPath.Key;
                        var platformData = tempPath.Value;
                        // Write file
                        string dataString = folder + platformStr + $"({thisLevel.lvlName}) Platforms {address.ToString("X6")}";
                        File.WriteAllBytes($"{dataString}.bin", platformData);
                        var romData = rom.ReadSubArray(address, platformData.Length, rom.rom.ToArray());
                        //File.WriteAllBytes($"{dataString}(2).bin", romData);
                        // Test if data is accurate
                        rom.WriteArrToROM(platformData, address);

                        // Construct strings to use
                        string fileP = folder + platformStr + platformTm;
                        string addrStringP = $".addr 0x{address.ToString("X6")}";
                        string importStrP = $".import \"{localFolder}{platformStr}({thisLevel.lvlName}) Platforms {address.ToString("X6")}.bin\"";
                        List<string> filePlatform = File.ReadAllLines(fileP).ToList();
                        int indexP = filePlatform.IndexOf(addrStringP);

                        if (indexP != -1)
                        {
                            filePlatform[indexP + 1] = importStrP;
                        }
                        else
                        {
                            filePlatform.Add(addrStringP);
                            filePlatform.Add(importStrP);
                        }
                        File.WriteAllLines(fileP, filePlatform.ToArray());

                    }

                }
            }
            else
            {
                string copyStr = "";
                for (int i = 0; i < thisLevel.verticalLayers.Count; i++)
                {
                    var verticalLayer = thisLevel.verticalLayers[i];
                    string fileName5 = $"{folder}{entitiesStr}{thisLevel.lvlName} - Layer {i} Entities.bin";
                    string toCopy = $"    .import \"{localFolder}{entitiesStr}{thisLevel.lvlName} - Layer {i} Entities.bin\"";
                    byte[] data5 = verticalLayer.GetEntitiesAsFile();

                    File.WriteAllBytes(fileName5, data5);
                    copyStr += toCopy + "\n";
                }
                // Save layer info
                string toCopy2 = $"    .import \"{localFolder}{entitiesStr}{thisLevel.lvlName} - Layers Offset.bin";
                string fileName6 = $"{folder}{entitiesStr}{thisLevel.lvlName} - Layers Offset.bin";
                File.WriteAllBytes(fileName6, thisLevel.layerData);





                Clipboard.Clear();
                Clipboard.SetText(copyStr);
            }


            MessageBox.Show("Done.");
        }

        private void exportStagePaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_drawEdges_CheckedChanged(object sender, EventArgs e)
        {
            DrawScreen();
        }

        private void stageSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox_tilemap.Image == null)
                return;
            var sectionsGFX = GetListOfImages();
            StageSections stageSections = new StageSections(sectionsGFX);
            stageSections.Show();
        }
        private List<Bitmap> GetListOfImages()
        {
            List<Bitmap> @return = new List<Bitmap>();
            Bitmap bmp = (Bitmap)pictureBox_tilemap.Image;
            for (int x = 0; x < bmp.Width; x += 0x200)
            {
                int rectWidth = x + 0x200 < bmp.Width ? 0x200 : bmp.Width - x;
                // Create rectangle to clone
                var cloneRect = new Rectangle(x, 0, rectWidth, 0x200);
                //try
                //{
                    Bitmap clonedBmp = bmp.Clone(cloneRect, bmp.PixelFormat);
                    @return.Add(clonedBmp);
                //}
                //catch (Exception ex)
                //{

                //}
                ////clonedBmp.Dispose();

            }
            return @return;
        }

        private void perilsSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel.levelCode == 0x2b)
            {
                PerilsRandomTerrain terrain = new PerilsRandomTerrain(rom);

                terrain.Show();
            }

        }

        private void dixieSpritePlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DixieSpritePlace dsp = new DixieSpritePlace(rom);
            dsp.ShowDialog();
        }

        private void exportfmfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Platinum file (*.fmf)|*.fmf";

            if (s.ShowDialog() == DialogResult.OK)
            {
                var tilemap = thisLevel.WriteTilemapToFileFMF();
                int count = thisLevel.tiles.Count;
                for (int i = 0; i < tilemap.Count; i += 2)
                {
                    var val = (tilemap[i] << 0) | (tilemap[i + 1] << 8);
                    int newTile = val & 0x3fff;
                    if ((val & 0x4000) > 0)
                    {
                        val ^= 0x4000;
                        newTile += (1 * count);
                    }
                    if ((val & 0x8000) > 0)
                    {
                        val ^= 0x8000;
                        newTile += (2 * count);
                    }
                    tilemap[i + 0] = (byte)(newTile >> 0);
                    tilemap[i + 1] = (byte)(newTile >> 8);
                }
                List<byte> save = new List<byte>();
                save.AddRange(new byte[] { 0x46, 0x4d, 0x46, 0x5f });
                save.Add((byte)(tilemap.Count >> 0));
                save.Add((byte)(tilemap.Count >> 8));
                save.AddRange(Enumerable.Repeat((byte)0, 2));
                int width = pictureBox_tilemap.Image.Width / 0x20;
                save.Add((byte)(width >> 0));
                save.Add((byte)(width >> 8));
                save.Add((byte)(width >> 16));
                save.Add((byte)(width >> 24));
                var h = pictureBox_tilemap.Image.Height / 0x20;
                save.Add((byte)(h >> 0));
                save.Add((byte)(h >> 8));
                save.Add((byte)(h >> 16));
                save.Add((byte)(h >> 24));


                save.Add((byte)(0x20));
                save.Add((byte)(0x20));
                save.Add((byte)(1));
                save.Add((byte)(0x10));

                save.AddRange(tilemap);
                File.WriteAllBytes(s.FileName, save.ToArray());

                MessageBox.Show("Exported");
            }
        }

        private void importPlatinumTilemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "FMF (*.fmf)|*.fmf";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var data = File.ReadAllBytes(d.FileName);
                var header = data.Take(0x14).ToArray();
                data = data.Skip(0x14).ToArray();

                data = ParsePlatinum(data);
                if (rom.IsVertical(thisLevel.levelCode))
                {
                    thisLevel.tilemap = thisLevel.ConvertTilemapVertical(data);
                    DrawScreen();
                }
                else
                {
                    int maxX = (header[0x8] << 0) | (header[0x9] << 8) | (header[0xa] << 16) | (header[0xb] << 24);
                    int maxY = (header[0xc] << 0) | (header[0xd] << 8) | (header[0xe] << 16) | (header[0xf] << 24);
                    data = GetTilemapFromFMFHorizontal(data, maxX, maxY);

                    thisLevel.tilemap = thisLevel.ConvertTilemap(data);
                    DrawScreen();
                }

            }
        }
        private byte[] ParsePlatinum(byte[] data)
        {
            int count = thisLevel.tiles.Count;
            int countX = count * 2;
            int countY = count * 3;
            int countXY = count * 4;
            for (int i = 0; i < data.Length; i += 2)
            {
                int val = (data[i + 0] << 0) | (data[i + 1] << 8);
                if (val < count)
                {

                }
                else if (val < countX)
                {
                    val -= count;
                    val |= 0x4000;
                }
                else if (val < countY)
                {
                    val -= countX;
                    val |= 0x8000;
                }
                else if (val < countXY)
                {
                    val -= countY;
                    val |= 0xc000;
                }
                else
                {
                    val = 0;
                }

                data[i + 0] = (byte)(val >> 0);
                data[i + 1] = (byte)(val >> 8);

            }

            return data;
        }
        private byte[] GetTilemapFromFMFHorizontal(byte[] data, int maxX, int maxY)
        {
            byte[] @return = new byte[data.Length];
            int x = 0, y = 0;
            for (int i = 0; i < data.Length; i += 2)
            {
                byte lo = data[i + 0];
                byte hi = data[i + 1];
                int index = y * 2 + x * 32;
                @return[index++] = lo;
                @return[index++] = hi;
                x++;
                if (x >= maxX)
                {
                    y++;
                    x = 0;
                }
            }

            return @return;
        }

        private void exportLevelAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
                return;
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = fbd.SelectedPath;
                SaveAssets(folderPath);

            }
        }

        private void SaveAssets(string folderPath)
        {
            string name = thisLevel.lvlName;
            string lvlPath = folderPath + "\\" + name;
            Directory.CreateDirectory(lvlPath);

            byte[] data = rom.ReadSubArray(thisLevel.paletteOffset, 0x100, rom.rom.ToArray());
            File.WriteAllBytes(lvlPath + "\\" + name + " Palette.bin", data);
            File.WriteAllBytes(lvlPath + "\\" + name + " Chars.bin", thisLevel.decompressedChars);
            File.WriteAllBytes(lvlPath + "\\" + name + " Meta.bin", thisLevel.meta.ToArray());
            File.WriteAllBytes(lvlPath + "\\" + name + " Tilemap.bin", thisLevel.WriteTilemapToFile().ToArray());
            thisLevel.te.platinum.Save(lvlPath + "\\" + name + " Mapchip.bmp", ImageFormat.Bmp);
            ExportObjects(lvlPath);
        }

        private void GetFileTitle(string str, OpenFileDialog d) => d.Title = $"{str}";
        private void GetFileFilter(string str, OpenFileDialog d) => d.Filter = $"{str.ToUpper()} (*.{str})|*.{str}";
        private void ExportObjects (string folderPath)
        {
            List<byte> toExport = new List<byte>();

            if (!rom.IsVertical(thisLevel.levelCode))
            {
                foreach (var entity in thisLevel.entities)
                {
                    toExport.AddRange(entity.GetEntityAsBytes());
                }

                toExport.AddRange(Enumerable.Repeat((byte)0, 8));

                var addr = thisLevel.entities[0].address.ToString("X6");

                File.WriteAllBytes(folderPath + "\\Objects " + addr + ".bin", toExport.ToArray());
            }
            else
            {
                foreach (var layer in thisLevel.verticalLayers)
                {
                    foreach (var entity in layer.entities)
                    {

                        toExport.AddRange(entity.GetEntityAsBytes());
                    }
                }
                string addr = thisLevel.verticalLayers[0].entities[0].address.ToString("X");
                toExport.AddRange(Enumerable.Repeat((byte)0, 8));

                File.WriteAllBytes(folderPath + "\\Objects " + addr + ".bin", toExport.ToArray());

            }

        }

        private void snapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = Prompt.ShowDialog("Enter in precision in hex", "Precision");
            if (str == "")
                return;
            try
            {
                if (str == "0")
                {
                    throw new Exception("Can't be zero!");
                }
                snapPrecision = Convert.ToInt32(str, 16);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void verticalEntityMapLayerCoordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel != null && rom.IsVertical(thisLevel.levelCode))
            {
                LayerControl lc = new LayerControl(thisLevel.verticalLayers);

                if (lc.ShowDialog() != DialogResult.OK)
                {
                    Level_select_Click(0, e);
                }
            }


        }

        private void exportInitScriptBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export Script Bank";
            dialog.Filter = Global.binFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var arr = rom.ReadSubArray(0xb59000, 0x6fff, rom.rom.ToArray());
                File.WriteAllBytes(dialog.FileName, arr);
            }
        }

        private void loadVerticalMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadVerticalMapsToolStripMenuItem.Checked = !loadVerticalMapsToolStripMenuItem.Checked;
        }

        private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreBackup rb = new RestoreBackup(sd, rom);

            if (rb.ShowDialog() == DialogResult.OK)
            {
                thisLevel = null;
                pictureBox_tilemap.Image = null;
                pictureBox_tilemap.Refresh();
                Level_select_Click(0, new EventArgs());
            }
        }

        private void renameBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = Prompt.ShowDialog("Enter in new backup name:", "Enter", rom.backupFileName);
            if (str != "")
            {
                rom.backupFileName = str;
            }
        }
        public bool CursorInBounds(int x, int y)
        {
            if (x < 0 || y < 0 ||
                x > pictureBox_tilemap.Image.Width ||
                y > pictureBox_tilemap.Image.Height)
            {
                return false;
            }
            return true;
        }

        private void copyrightEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyrightEdit ce = new CopyrightEdit(rom);
            ce.Show();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please go to my twitch for the most current: https://www.twitch.tv/rainbowsprinklez");
        }

        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditor text = new TextEditor(rom);

            if (text.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void RemoveAllEventListeners()
        {
            // Add all listeners
            pictureBox_tilemap.MouseDown -= new MouseEventHandler(MouseDownEntity);
            pictureBox_tilemap.MouseLeave -= new EventHandler(MouseLeaveEntity);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(MouseMoveEntity);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(MouseUpEntity);

            pictureBox_tilemap.MouseDown -= new MouseEventHandler(PathMouseDown);
            pictureBox_tilemap.MouseLeave += new EventHandler(PathMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(PathMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(PathMouseUp);

            pictureBox_tilemap.MouseDown -= new MouseEventHandler(BananaMouseDown);
            pictureBox_tilemap.MouseLeave -= new EventHandler(BananaMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(BananaMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(BananaMouseUp);

            pictureBox_tilemap.MouseDown -= new MouseEventHandler(CameraMouseDown);
            pictureBox_tilemap.MouseLeave -= new EventHandler(CameraMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(CameraMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(CameraMouseUp);

            pictureBox_tilemap.MouseDown -= new MouseEventHandler(EntranceMouseDown);
            pictureBox_tilemap.MouseLeave -= new EventHandler(EntranceMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(EntranceMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(EntranceMouseUp);

            // VCamera
            pictureBox_tilemap.MouseDown -= new MouseEventHandler(VCameraMouseDown);
            pictureBox_tilemap.MouseLeave -= new EventHandler(VCameraMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(VCameraMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(VCameraMouseUp);

            // Water autodraw
            pictureBox_tilemap.MouseDown -= new MouseEventHandler(WaterMouseDown);
            pictureBox_tilemap.MouseLeave -= new EventHandler(WaterMouseLeave);
            pictureBox_tilemap.MouseMove -= new MouseEventHandler(WaterMouseMove);
            pictureBox_tilemap.MouseUp -= new MouseEventHandler(WaterMouseUp);


            pictureBox_tilemap.MouseMove -= new MouseEventHandler(CursorMove);

            pictureBox_tilemap.MouseClick -= new MouseEventHandler(AF_MouseClick);

        }

        private void exportEntityInitBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var save = Global.SaveFile("Entity init", "BIN (*.bin)|*.bin");
            if (save != null)
            {
                var arr = rom.ReadSubArray(0xb58000, 0x7fff, rom.rom.ToArray());
                File.WriteAllBytes(save.FileName, arr);
            }
        }

        private void importEntityInitBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var import = Global.OpenFile("Entity init", "BIN (*.bin)|*.bin");
            if (import != null)
            {
                var arr = File.ReadAllBytes(import.FileName);
                rom.WriteArrToROM(arr, 0xb58000);
            }

        }

        private void loadRestoreLastBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool backupLoad = true;
            const string Path = "Backup-End.smc";
            LoadROMFromString(Path, backupLoad);
            pictureBox_tilemap.Image = null;
            Level_select_Click(0, new EventArgs());
        }

        private void reverseSqwuaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * 
                // Evil squawks setup
                .addr 0xb987ed
                lda #0x0200
                lda #0x0300 normal

                which squawks
                bed06a - 8817
             * */
            reverseSqwuaksToolStripMenuItem.Checked = !reverseSqwuaksToolStripMenuItem.Checked;
            if (reverseSqwuaksToolStripMenuItem.Checked)
            {
                rom.Write16LDA(0xb987ed, 0x200);
            }
            else
            {
                rom.Write16LDA(0xb987ed, 0x300);
            }
        }

        private void quickFakeCreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quickFakeCreditsToolStripMenuItem.Checked = !quickFakeCreditsToolStripMenuItem.Checked;
            if (quickFakeCreditsToolStripMenuItem.Checked)
            {
                rom.Write16LDA(0xb6d150, 0x0000);
            }
            else
            {
                rom.Write16LDA(0xb6d150, 0x0001);
            }

        }

        private void loadRestoreLastBackupStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool backupLoad = true;
            const string Path = "Backup-Start.smc";
            LoadROMFromString(Path, backupLoad);
            pictureBox_tilemap.Image = null;
            Level_select_Click(0, new EventArgs());

        }

        private void levelAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }

            LevelAttributes la = new LevelAttributes(rom, thisLevel, rom.ATTRIBUTES, this);
            la.ShowDialog();
        }

        private void musicEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }
            Music_Picker mp = new Music_Picker(rom, thisLevel.levelCode);
            mp.ShowDialog();
        }

        private void sch1eyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sch1eyToolStripMenuItem.Checked = !sch1eyToolStripMenuItem.Checked;
            sd.Write("Sch1ey", "mod", $"{sch1eyToolStripMenuItem.Checked}");
            sd.SaveRbs();
            if (sch1eyToolStripMenuItem.Checked)
            {
                LoadSch1eyBins();
            }
        }
        public void LoadSch1eyBins()
        {
            if (rom == null)
            {
                return;
            }
            if (rom.Read16(rom.CUSTOMATTRIBUTES) != 0x0000)
            {
                var arr = Enumerable.Repeat((byte)0, 0x200).ToArray();
                rom.WriteArrToROM(arr, rom.CUSTOMATTRIBUTES);
            }

            try
            {
                var files = Directory.GetFiles("ASM").ToArray();
                var shortenedFiles = files.Select(e => Global.FileNameParse(e).Substring(2)).ToArray();
                var addresses = shortenedFiles.Select(e => Convert.ToInt32(e, 16)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    var file = files[i];
                    var arr = File.ReadAllBytes(file);
                    rom.WriteArrToROM(arr, addresses[i]);
                }
                aSMModsToolStripMenuItem.Checked = true;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void worldTerminatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom == null)
            {
                return;
            }
            WorldTerminator wt = new WorldTerminator(rom);
            wt.ShowDialog();
        }
        private void startingKongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom == null)
            {
                return;
            }
            const int address = 0xb8829b;
            bool start = rom.Read16LDA(address) == 1;

            var kong = Prompt.ShowRadioBox("Select Donkey or Diddy to start", "Kong on game start", "Donkey", "Diddy", start, !start);
            if (kong == 0)
            {
                rom.Write16LDA(address, 0x1);
                MessageBox.Show("Set Donkey to start");
            }
            else if (kong == 1)
            {
                rom.Write16LDA(address, 0x2);
                MessageBox.Show("Set Diddy to start");

            }

        }

        private void aSMModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom.CheckSignature())
            {
                aSMModsToolStripMenuItem.Checked = true;
                MessageBox.Show("Already applied");
                if (MessageBox.Show("Refresh?", "WARNING!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    LoadSch1eyBins();
                }
            }
            else
            {
                if (MessageBox.Show("Apply?", "WARNING!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    LoadSch1eyBins();
                    aSMModsToolStripMenuItem.Checked = true;
                }
            }
        }

        private void kongAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rom == null)
            {
                return;
            }
            KongAttributes ka = new KongAttributes(rom);
            ka.ShowDialog();
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Global.transparentClr = colorDialog.Color;
            Level_select_Click(0, new EventArgs());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Global.WriteToArr(rom);

            if (rom == null)
                return;
            int index = comboBox_stages.SelectedIndex;
            if (comboBox_stages.SelectedIndex < 0 || comboBox_stages.SelectedItem.ToString() == "")
            {
                comboBox_stages.SelectedIndex = 0;
                index = 0;
            }
            Level_select_Click(0, new EventArgs());
            if (thisLevel == null)
                return;
            if (thisLevel.trackBool)
            {
                thisLevel.WriteAll();

                rom.SaveROM(comboBox_stages);
                comboBox_stages.SelectedIndex = index;
                Level_select_Click(0, new EventArgs());
                this.Text = Version.GetVersion() + " - " + rom.fileName;
            }

        }

        private void importEntrancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "BIN (*.bin)|*.bin";

            if (d.ShowDialog() == DialogResult.OK)
            {
                byte[] arr = File.ReadAllBytes(d.FileName);
                for (int i = 0; i < arr.Length; i += 7)
                {
                    int address = (arr[i + 0]) |
                                  (arr[i + 1]) |
                                  (arr[i + 2]);
                    int x = (arr[i + 3]) |
                            (arr[i + 4]);
                    int y = (arr[i + 5]) |
                            (arr[i + 6]);
                    rom.Write16(address + 0, x);
                    rom.Write16(address + 2, y);
                }

                thisLevel = null;
                Level_select_Click(0, new EventArgs());

            }
        }
        // Save and file menu polish
        private void timer_save_Tick(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = rom != null;

        }
        private void AddSaveHotkeyToAll (Control ctrl)
        {
            ctrl.KeyDown += new KeyEventHandler(SaveHotkey);
            foreach (Control child in ctrl.Controls)
            {
                AddSaveHotkeyToAll(child);
            }

        }
        private void SaveHotkey (object sender, KeyEventArgs e)
        {
            if (!saveToolStripMenuItem.Enabled)
                return;
            if (e.KeyCode == Keys.S && ModifierKeys == Keys.Control)
            {
                saveToolStripMenuItem_Click(0, new EventArgs());
            }
        }

        private void customLevelAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }
            if (!rom.CheckSignature())
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LoadSch1eyBins();
                    aSMModsToolStripMenuItem.Checked = true;
                    var arr = Enumerable.Repeat((byte)0, 0x200).ToArray();
                    rom.WriteArrToROM(arr, rom.CUSTOMATTRIBUTES);
                }
                else
                {
                    return;
                }

            }
            if (rom.Read16(rom.CUSTOMATTRIBUTES) != 0x0000)
            {
                var arr = Enumerable.Repeat((byte)0, 0x200).ToArray();
                rom.WriteArrToROM(arr, rom.CUSTOMATTRIBUTES);
            }

            LevelAttributes la = new LevelAttributes(rom, thisLevel, rom.CUSTOMATTRIBUTES, this);
            la.ShowDialog();

        }
        public Panel GetPanel ()
        {
            return panel_playground;
        }
        private void percentChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LoadSch1eyBins();
                }
                else
                {
                    return;
                }

            }

            new Custom_Percent(rom).ShowDialog();
        }

        private void customModsSchleyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customModsSchleyToolStripMenuItem.Checked = true;
            var address = 0xbcb946;
            byte[] arr = new byte[] { 0xea, 0xea, 0xea };
            rom.WriteArrToROM(arr, address);
            //byte[] arr = new byte[] { 0x20, 0xb1, 0xba };
            //rom.WriteArrToROM(arr, address);
            byte[] zeroes = Enumerable.Repeat((byte)0, 0xff).ToArray();
            rom.WriteArrToROM(zeroes, rom.LEVELCOORDSX);
            rom.WriteArrToROM(zeroes, rom.LEVELCOORDSY);
            rom.WriteArrToROM(zeroes, rom.LEVELCOORDSZ);

        }

        private void worldStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorldStartersSelect worldStartersSelect = new WorldStartersSelect(rom);

            worldStartersSelect.ShowDialog();
        }

        private void radioButton_editterrain_Click(object sender, EventArgs e)
        {
            CloseAll();
            thisLevel.ShowTileEdit();
            thisLevel.te.TopMost = true;
            thisLevel.te.TopMost = false;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void radioButton_editEntities_Click(object sender, EventArgs e)
        {
            if (radioButton_editEntities.Checked)
            {
                if (edit != null)
                    edit.Close();
                edit = new EntityEdit(thisLevel, rom, this);
                edit.Show();
            }

        }
        public void SetASM()
        {
            aSMModsToolStripMenuItem.Checked = true;
        }

        private void placeAllLevelsOnMap0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There is no undo for this! Please use backups.", "WARNING!");
            if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                rom.WriteArrToROM(Global.zeroes, rom.LEVELCOORDSZ);
                overwoldEditToolStripMenuItem.Enabled = false;
            }
        }

        private void saveAfterEachLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LoadSch1eyBins();
                    aSMModsToolStripMenuItem.Checked = true;
                }
                else
                {
                    return;
                }

            }


            saveAfterEachLevelToolStripMenuItem.Checked = !saveAfterEachLevelToolStripMenuItem.Checked;
            rom.Write16(0xc4ff00, (saveAfterEachLevelToolStripMenuItem.Checked ? 1 : 0));
        }

        private void bgImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bossEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BossEditorr boss = new BossEditorr(rom, this);
            boss.ShowDialog();
        }

        private void deleteExtraEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (thisLevel == null)
            {
                return;
            }
            var str = Prompt.ShowDialog("Enter in entity code:", "Delete Entity", "a51f");
            if (str == "")
                return;
            if (!rom.IsVertical(thisLevel.levelCode))
            {
                thisLevel.entities = thisLevel.entities.Where(el => el.pointer.ToString("x") != str.ToLower()).ToList();
            }
            else
            {
                for (int i = 0; i < thisLevel.verticalLayers.Count; i++)
                {
                    var layer = thisLevel.verticalLayers[i];
                    layer.entities = layer.entities.Where(el => el.pointer.ToString("x") != str.ToLower()).ToList();
                }

            }
            Level_select_Click(0, new EventArgs());
        }

        private void reAddBananasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.Write16(thisLevel.bananaMapOffset, 2);
            Level_select_Click(0, new EventArgs());
        }

        private void startingWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartingWorld sw = new StartingWorld(rom);
            sw.ShowDialog();
        }
        public void ConnectAllVCams()
        {
            Level_select_Click(0, new EventArgs());
            thisLevel.ConnectAllVerticalCameras();
            Level_select_Click(0, new EventArgs());
        }

        private void entranceStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntranceStyle es = new EntranceStyle(rom, thisLevel);

            es.ShowDialog();
        }

        private void colorMathControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color_Math_Control color_Math_Control = new Color_Math_Control(rom, thisLevel);

            color_Math_Control.ShowDialog();
        }
    }
}
