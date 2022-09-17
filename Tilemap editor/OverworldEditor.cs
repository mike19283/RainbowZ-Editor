using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class OverworldEditor : Form
    {
        #region Vars
        ROM rom;
        List<Level> allLevels = new List<Level>();
        Bitmap img;
        List<Level> levels = new List<Level>();
        string current;
        int linkTableA = 0xb89853;
        int linkTableA_end = 0xb89904;
        int linkTableB = 0xbcba67;
        int linkTableB_end = 0xbcbaac;
        int linkTableBCustom = 0xb3f908;
        int pathsLUT = 0xbcf13d;
        //int pathsOffset = 0x5c4d;
        int pathsOffset = 0xFeff;
        int headArray = 0xbcf3e2;
        int pathArray = 0xbcf32a;
        int pathArrayOG = 0xbcf32a;
        List<StagePath> paths;

        NumericUpDown[] num;
        string[] imageLocations = new string[]
        {
            "Main Overword/c116f1/7000/c10ff0/700/b9be03/100",
            "W1.1/c51012/7000/c50912/700/b9c103/100",
            "W1.2/c61757/7000/c61057/700/b9c003/100",
            "W2.1/c67cf7/7000/c675f7/700/b9c523/100",
            "W2.2/cc8bb4/7000/cc84b4/700/b9c423/100",
            "W4.1/f70000/7000/c40000/700/b9c323/100",
            "W4.2/f41558/7000/f40e57/700/b9c223/100",
            "W5.1/f20700/7000/f20000/700/b9cc83/100",
            "W5.2/ff0701/7000/ff0000/700/b9cd63/100",
            "W6.1/d10701/7000/d10000/700/b9d143/100",
            "W6.2/d16dc3/7000/d166c2/700/b9d243/100",
            "W3.1/ca0701/7000/ca0000/700/b9cf43/100",
            "W3.2/c828e4/7000/c821e4/700/b9d043/100",

        };
        Dictionary<string, int[]> levelsOnMap = new Dictionary<string, int[]>()
        {
            ["Main Overworld"] = new int[] { 0xeb, 0xec, 0xed, 0xe9, 0xe8, 0xe7, 0xe6, 0x68 },
            ["W1.1"] = new int[] { 0x16, 0x0c, 0xee, 0xea},
            ["W1.2"] = new int[] { 0x1, 0xbf, 0xf4, 0x17, 0xfa, 0xe0},
            ["W2.1"] = new int[] { 0xd9, 0x2e, 0x07, 0x31, 0xfb},
            ["W2.2"] = new int[] { 0xf5, 0x42, 0xef, 0xe1},
            ["W4.1"] = new int[] { 0x24, 0x6d, 0xa7, 0x3e, 0xf6, 0xce, 0xe2 },
            ["W4.2"] = new int[] { 0x14, 0xf6, 0xf0 },
            ["W5.1"] = new int[] { 0x40, 0x2f, 0x18, 0xfd },
            ["W5.2"] = new int[] { 0x22, 0x27, 0xf1, 0xf7, 0x41, 0xe3 },
            ["W6.1"] = new int[] { 0x30, 0x12, 0x0a, 0xf8 },
            ["W6.2"] = new int[] { 0x36, 0xfe, 0x2b, 0xf2, 0xe4 },
            ["W3.1"] = new int[] { 0xa5, 0xa4, 0xf9, 0xd0 },
            ["W3.2"] = new int[] { 0x43, 0xff, 0x0d, 0xf3, 0xde, 0xe5 },
        };
        Dictionary<string, int> levelIndices = new Dictionary<string, int>()
        {
            ["Main Overworld"] = 0,
            ["W1.1"] =1,
            ["W1.2"] =2,
            ["W2.1"] =3,
            ["W2.2"] =4,
            ["W4.1"] =5,
            ["W4.2"] =6,
            ["W5.1"] =7,
            ["W5.2"] =8,
            ["W6.1"] =9,
            ["W6.2"] =10,
            ["W3.1"] =11,
            ["W3.2"] =12,
        };
        //List<LevelCoords> levelCoords = new List<LevelCoords>();
        Dictionary<string, int> exits = new Dictionary<string, int>()
        {
            ["Jungle Hijinxs"] = 0xE8C7,
            ["Ropey Rampage"] = 0xEA25,
            ["Reptile Rumble"] = 0xE9DF,
            ["Coral Capers"] = 0xEAB1,
            ["Barrel Cannon Canyon"] = 0xEA6B,
            ["Winky's Walkway"] = 0xE935,
            ["Mine Cart Carnage"] = 0xEAC5,
            ["Bouncy Bonanza"] = 0xE953,
            ["Stop & Go Station"] = 0xE953,
            ["Millstone Mayhem"] = 0xEA2F,
            ["Vulture Culture"] = 0xE9AD,
            ["Tree Top Town"] = 0xE9AD,
            ["Forest Frenzy"] = 0xE98F,
            ["Temple Tempest"] = 0xEA89,
            ["Orang-utan Gang"] = 0xEA39,
            ["Clam City"] = 0xEAA7,
            ["Snow Barrel Blast"] = 0xE999,
            ["Slipslide Ride"] = 0xE9CB,
            ["Ice Age Alley"] = 0xE967,
            ["Croctopus Chase"] = 0xEABB,
            ["Torchlight Trouble"] = 0xE8E5,
            ["Rope Bridge Rumble"] = 0xE9FD,
            ["Oil Drum Alley"] = 0xE93F,
            ["Trick Track Trek"] = 0xE903,
            ["Elevator Antics"] = 0xE903,
            ["Poison Pond"] = 0xEA9D,
            ["Mine Cart Madness"] = 0xEA57,
            ["Blackout Basement"] = 0xEA07,
            ["Tanked Up Trouble"] = 0xE8DB,
            ["Manic Mincers"] = 0xE8BD,
            ["Misty Mine"] = 0xEA61,
            ["Loopy Lights"] = 0xEA7F,
            ["Platform Perils"] = 0xE92B,
        };
        Dictionary<int, int> connectionDictionary = new Dictionary<int, int>();

        public OverworldEditor(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            comboBox_overworld.SelectedIndex = 0;
            num = new NumericUpDown[]
            {
                //numericUpDown_connection1,
                //numericUpDown_connection2,
                //numericUpDown_connection3,
            };
            if (rom.Read16(pathsLUT) == pathsOffset)
            {
                pathArray = 0xbc0000 + pathsOffset;
            }
        }
        #endregion

        private void button_loadImage_Click(object sender, EventArgs e)
        {
            
            int worldIndex = levelIndices[comboBox_overworld.SelectedItem.ToString()];

            string text = imageLocations[worldIndex];
            string[] arr = text.Split('/');
            current = arr[0];
            var offsetTile = Convert.ToInt32(arr[1], 16);
            var sizeTile = Convert.ToInt32(arr[2], 16);
            var offsetTilemap = Convert.ToInt32(arr[3], 16);
            var sizeTilemap = Convert.ToInt32(arr[4], 16);
            var offsetPalette = Convert.ToInt32(arr[5], 16);
            var sizePalette = Convert.ToInt32(arr[6], 16);

            Bitmap bmp = rom.DisplayImage(offsetTile, sizeTile, offsetTilemap, sizeTilemap, offsetPalette, sizePalette);
            //if (worldIndex > 4)
            //{
            //    worldIndex -= 2;
            //    if (worldIndex < 5)
            //    {
            //        worldIndex += 8;
            //    }
            //}
            allLevels = new List<Level>();

            for (int i = 1; i < 256; i++)
            {
                allLevels.Add(new Level(i,rom));
            }

            levels = allLevels.Where(e2 => e2.xPos != 0 && e2.yPos != 0 &&
            e2.levelCode != 0x70 && e2.levelCode != 0x71 && e2.levelCode != 0x72 &&
            e2.levelCode != 0x73).ToList();

            foreach (var lvl in levels)
            {
                if (lvl.zPos != 0 && lvl.levelCode < 0xe0)
                {
                    lvl.GetExit();
                }
            }
            

            allLevels = new List<Level>();
            allLevels.AddRange(levels);

            levels = levels.Where(e2 => (e2.zPos == worldIndex)).ToList();
            //if (worldIndex == 1)
            //{
            //    levels = levels.Where(e2 => e2.levelCode != 0x70 &&
            //    e2.levelCode != 0x71 && e2.levelCode != 0x72).ToList();
            //}
            //else if (worldIndex == 2)
            //{
            //    levels = levels.Where(e2 => e2.levelCode != 0x73).ToList();

            //}


            listBox_levels.Items.Clear();
            listBox_levels.Refresh();
            FillListbox();

            ReadPathArray();
            bmp = DrawPaths(bmp);

            foreach (var lvl in levels)
            {
                lvl.DrawOverworldLevels(bmp);
            }

            pictureBox_mapPreview.Image = bmp;

            listBox_levels.SelectedIndex = 0;

            button_apply.Enabled = true;

            if (worldIndex == 0)
            {
                //numericUpDown_z.Enabled = false;
            }
            else
            {
                //numericUpDown_z.Enabled = true;
            }


        }
        private void ReadPathArray ()
        {
            ClearAllConnections();
            paths = new List<StagePath>();

            //var chosen = (Level)listBox_heads.SelectedItem;

            // Loop through arr
            for (int i = pathArray, j = 0; i < pathArray + 26; i += 2, j++)
            {
                int pointer = (pathArray & 0xff0000) | rom.Read16(i);
                
                int nextPair = rom.Read16(pointer);

                Dictionary<int, int> seenConnections = new Dictionary<int, int>();
                while (nextPair != 0)
                {
                    //int start = (int)(byte)(nextPair >> 0);
                    int start = (byte)(nextPair >> 0);
                    int dest = (nextPair >> 8);
                    var lvl = GetLevelByCode(start);
                    if (seenConnections.ContainsKey(start))
                    {
                        seenConnections[start]++;
                    }
                    else
                    {
                        seenConnections[start] = 1;
                    }
                    var temp = new StagePath(this, j);
                    temp.MarkStartAndEnd(start, dest);
                    paths.Add(temp);




                    pointer += 2;
                    nextPair = rom.Read16(pointer);
                }
            }
        }
        // Check if stage is offmap
        public bool OnSameMap (int start, int dest)
        {
            return GetLevelByCode(start).zPos == GetLevelByCode(dest).zPos;
        }
        public Level GetLevelByCode (int code)
        {
            foreach (var lvl in allLevels)
            {
                if (code == lvl.levelCode)
                    return lvl;
            }
            return null;
        }
        private void ClearAllConnections()
        {
            foreach (var lvl in allLevels)
            {
                lvl.connection1 = 0;
                lvl.connection2 = 0;
                lvl.connection3OffMap = 0;
            }
        }
        private void WritePathArray ()
        {
            CopyAllOver();

            //connectionDictionary = new Dictionary<int, int>();
            // COUNT CONNECTIONS ON SCREENS
            // Setup pointer array
            int currIndex = pathArray & 0xffff;
            currIndex += 26; // 13 16-bit pointers
            //rom.Write16(pathArray + 2 * 0, currIndex);

            for (int i = 1; i < 7; i++)
            {
                int count = 0;
                var prevWorldPaths = paths.Where(e => e.map == i - 1).ToArray();
                // Loop through each level in world
                count = prevWorldPaths.Length * 2;
                currIndex += count + 2;

                //rom.Write16(pathArray + 2 * i, currIndex);
            }

            // WRITE CONNECTIONS
            // Actually write paths
            for (int i = 0; i < 13; i++)
            {
                int pointer = rom.Read16(pathArray + i * 2) | 0xbc0000;
                var currPaths = paths.Where(e => e.map == i).ToArray();
                // Loop through all levels
                foreach (var path in currPaths)
                {
                    var x = path.map;
                    // Loop through each connection
                    //rom.Write8(pointer++, path.startStage);
                    //rom.Write8(pointer++, path.endStage);
                }
                //rom.Write16(pointer, 0);
            }


        }
        private void CopyAllOver()
        {
            // Copy levels to all  lvels
            for (int i = 0; i < levels.Count; i++)
            {
                for (int j = 0; j < allLevels.Count; j++)
                {
                    if (allLevels[j].levelCode == levels[i].levelCode)
                    {
                        allLevels[j] = levels[i];
                    }
                }
            }

        }
        private void ReadLinkTableA ()
        {
            int addeess = linkTableA;
            // Loop until level to beat is 0
            // Level to beat, path start, path end
        }
        private void WriteLinkTableA ()
        {
            int offset = linkTableA;
            var stages = allLevels.Where(e => e.xPos != 0 && e.yPos != 0).ToList();
            int stageIndex = 0;

            int i;
            for (i = offset; stageIndex < stages.Count; i += 3)
            {
                var lvl = stages[stageIndex++];
                var toBeat = lvl.levelCode;
                int startA = lvl.startA,
                    endA = lvl.endA,
                    startB = lvl.startB,
                    endB = lvl.endB,
                    startC = lvl.startC,
                    endC = lvl.endC;

                //rom.Write8(i + 0, toBeat);
                //rom.Write8(i + 1, startA);
                //rom.Write8(i + 2, endA);
                if (startB != 0)
                {
                    i += 3;

                    //rom.Write8(i + 0, toBeat);
                    //rom.Write8(i + 1, startB);
                    //rom.Write8(i + 2, endB);

                }
                if (startC != 0)
                {
                    i += 3;

                    //rom.Write8(i + 0, toBeat);
                    //rom.Write8(i + 1, startC);
                    //rom.Write8(i + 2, endC);

                }
            }
            //rom.Write8(i, 0);
        }
        private void FillListbox()
        {
            int index = comboBox_overworld.SelectedIndex;
            levels = allLevels.Where(e2 => e2.zPos == index).ToList();

            listBox_levels.Items.Clear();
            listBox_levels.Items.AddRange(levels.ToArray());
        }

        public Bitmap DrawPaths (Bitmap bmp)
        {
            var temp = paths.Where(e => e.map == comboBox_overworld.SelectedIndex).ToArray();
            foreach (var path in temp)
            {
                bmp = path.DrawPath(bmp);
            }
            return bmp;
        }

        private void listBox_heads_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReadPathArray();

            Array.ForEach(num, z => z.Value = 0);

            var chosen = (Level)listBox_levels.SelectedItem;
            numericUpDown_level.Value = chosen.levelCode;
            numericUpDown_z.Value = chosen.zPos;
            numericUpDown_x.Value = chosen.xPos;
            numericUpDown_y.Value = chosen.yPos;
            //numericUpDown_endA.Value = chosen.endA;
            numericUpDown_dUp.Value = chosen.up;
            numericUpDown_dDown.Value = chosen.down;
            numericUpDown_dLeft.Value = chosen.left;
            numericUpDown_dRight.Value = chosen.right;

            var temp = paths.Where(e2 => e2.startStage == chosen.levelCode).ToArray();
            //foreach (var path in temp)
            //{
            //    if (path.difMaps)
            //    {
            //        numericUpDown_connection3.Value = path.endStage;
            //    }
            //    else
            //    {
            //        if (numericUpDown_connection1.Value == 0)
            //        {
            //            numericUpDown_connection1.Value = path.endStage;
            //        }
            //        else
            //        {
            //            numericUpDown_connection2.Value = path.endStage;
            //        }

            //    }

            //}


            //numericUpDown_startA.Value = chosen.startA;
            //numericUpDown_startB.Value = chosen.startB;
            //numericUpDown_endB.Value = chosen.endB;
            //numericUpDown_startC.Value = chosen.startC;
            //numericUpDown_endC.Value = chosen.endC;

            label_stage.Text = chosen.level;
        }
        private void ReadLevelBeat()
        {
            var chosen = (Level)listBox_levels.SelectedItem;

        }
        private void OnLevelBeat()
        {
            var chosen = (Level)listBox_levels.SelectedItem;
            if (chosen.levelCode >= 0xe0)
                return;
            int address = rom.levelExitObjects[chosen.levelCode] + 0xb50000;
            //int toWrite = (int)numericUpDown_endA.Value;
            //rom.Write16(address + 6, toWrite);
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            //if (rom.Read24(0xbcba5e) == linkTableB)
            //{
            //    // Write link table B in new location
            //    //rom.Write24(0xbcba5e, linkTableBCustom);
            //    rom.Write24(0xbcba5e, linkTableA);

            //    // Zero out new location
            //    var zeroArr = Enumerable.Repeat((byte)0, 0x600).ToArray();
            //    rom.WriteArrToROM(zeroArr, linkTableBCustom);

            //    // Copy og there
            //    var ogLinkB = rom.ReadSubArray(linkTableB, linkTableB_end - linkTableB, rom.rom.ToArray());
            //    rom.WriteArrToROM(ogLinkB, linkTableBCustom);

            //}
            //if (rom.Read16(pathsLUT) + 0xbc0000 == 0xbcf32a)
            //{
            //    // Write link table B in new location
            //    //rom.Write24(0xbcba5e, linkTableBCustom);
            //    rom.Write16(pathsLUT, pathsOffset);

            //    // Zero out new location
            //    var zeroArr = Enumerable.Repeat((byte)0, 0x100).ToArray();
            //    rom.WriteArrToROM(zeroArr, pathsOffset + 0xbc0000);

            //    // Copy og there
            //    var ogPaths = rom.ReadSubArray(0xbcf32a, 0x100, rom.rom.ToArray());
            //    rom.WriteArrToROM(ogPaths, pathsOffset + 0xbc0000);

            //    pathArray = pathsOffset + 0xbc0000;

            //}

            int selected = listBox_levels.SelectedIndex;
            //OnLevelBeat();
            var chosen = (Level)listBox_levels.SelectedItem;
            chosen.zPos = (int)numericUpDown_z.Value;
            chosen.xPos = (int)numericUpDown_x.Value;
            chosen.yPos = (int)numericUpDown_y.Value;
            chosen.up = (int)numericUpDown_dUp.Value;
            chosen.down = (int)numericUpDown_dDown.Value;
            chosen.left = (int)numericUpDown_dLeft.Value;
            chosen.right = (int)numericUpDown_dRight.Value;

            //chosen.startA = (int)numericUpDown_startA.Value;
            //chosen.startB = (int)numericUpDown_startB.Value;
            //chosen.startC = (int)numericUpDown_startC.Value;
            //chosen.endA = (int)numericUpDown_endA.Value;
            //chosen.endB = (int)numericUpDown_endB.Value;
            //chosen.endC = (int)numericUpDown_endC.Value;

            //int counter = 0;
            //foreach (var path in paths)
            //{
            //    if (chosen.levelCode == path.startStage)
            //    {
            //        if (path.difMaps)
            //        {
            //            path.endStage = (int)numericUpDown_connection3.Value;
            //        }
            //        else
            //        {
            //            counter++;
            //            if (counter == 1)
            //                path.endStage = (int)numericUpDown_connection1.Value;
            //            if (counter == 2)
            //                path.endStage = (int)numericUpDown_connection2.Value;

            //        }
            //    }
            //}




            Bitmap bmp = (Bitmap)rom.img.Clone();

            foreach (var level in levels)
            {
                bmp = level.DrawOverworldLevels(bmp);
            }
            pictureBox_mapPreview.Image = bmp;
            FillListbox();

            WriteLocations();
            //WriteHeads();
            //WritePathArray();
            //WriteLinkTableA();

            button_loadImage_Click(0, new EventArgs());
            MessageBox.Show("Changed!");
        }
        private void WriteLocations()
        {
            foreach (var level in allLevels)
            {
                level.WriteToRom();
            }
        }
        private void WriteHeads ()
        {
            // Setup pointer array
            int currIndex = headArray & 0xffff;
            currIndex += 26; // 13 16-bit pointers
            rom.Write16(headArray + 2 * 0, currIndex);

            for (int i = 1; i < 7; i++)
            {
                var temp = allLevels.Where(e => e.zPos == i - 1).ToList();
                currIndex += temp.Count + 1;
                rom.Write16(headArray + 2 * i, currIndex);

            }

            // Actually write heads
            for (int i = 0; i < 7; i++)
            {
                //int z = headArray + i * 2;
                int pointer = rom.Read16(headArray + i * 2);

                var levelsInWorld = allLevels.Where(e => e.zPos == i).ToList();
                int j = 0;
                for (; j < levelsInWorld.Count; j++)
                {
                    var ptr = pointer + j;
                    rom.Write8(0xbc0000 + pointer + j, levelsInWorld[j].levelCode);
                }
                rom.Write8(0xbc0000 + pointer + j, 0);


            }
        }
    }

    public class Level
    {
        public int levelCode;
        ROM rom;
        public int xPos, yPos, zPos;
        public int connection1 = 0;
        public int connection2 = 0;
        public int connection3OffMap = 0;
        public string level;
        public int pathTo;
        public int onBeat;
        int directionUp = 0xbcf94b,
            directionDown = 0xbcfa4b,
            directionLeft = 0xbcf84b,
            directionRight = 0xbcf74b;
        public int up, down, left, right;
        int levelLinkTableA = 0xb89853;
        public int startA = 0, endA, startB, endB,
            startC, endC;

        public Level (int levelCode, ROM rom)
        {
            this.levelCode = levelCode;
            this.rom = rom;

            xPos = rom.Read8(rom.LEVELCOORDSX+ levelCode);
            yPos = rom.Read8(rom.LEVELCOORDSY + levelCode);
            zPos = rom.Read8(rom.LEVELCOORDSZ + levelCode);


            level = GetStageName();

            up = rom.Read8(directionUp + levelCode);
            down = rom.Read8(directionDown + levelCode);
            left = rom.Read8(directionLeft + levelCode);
            right = rom.Read8(directionRight + levelCode);

            ReadLinkTableA();
            
        }
        private void ReadLinkTableA()
        {
            startA = 0;
            startB = 0;
            startC = 0;
            endA = 0;
            endB = 0;
            endC = 0;
            for (int address = levelLinkTableA; rom.Read8(address) != 0; address += 3)
            {
                if (levelCode == rom.Read8(address))
                {
                    var start = rom.Read8(address + 1);
                    var end = rom.Read8(address + 2);
                    if (startA == 0)
                    {
                        startA = start;
                        endA = end;
                    }
                    else if (startB == 0)
                    {
                        startB = start;
                        endB = end;
                    }
                    else
                    {
                        startC = start;
                        endC = end;
                    }
                }
            }

        }

        public void GetExit()
        {
            int address = rom.levelExitObjects[levelCode] + 0xb50000;
            onBeat = rom.Read16(address + 6);
        }

        private string GetStageName()
        {
            try
            {
                string stage = rom.levelNameByCode[levelCode];
                var arr = stage.Split(new string[] { " (" }, StringSplitOptions.None);
                stage = arr[0];
                return stage;
            }
            catch { return ""; }
        }


        public Bitmap DrawOverworldLevels(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawEllipse(new Pen(Color.Red), xPos - 10, (0x100 - yPos) - 10, 10, 10);
                g.FillEllipse(new SolidBrush(Color.BlueViolet), xPos - 10, (0x100 - yPos) - 10, 10, 10);

                // assuming g is the Graphics object on which you want to draw the text
                GraphicsPath p = new GraphicsPath();
                p.AddString(
                    Global.HexToString(levelCode),             // text to draw
                    FontFamily.GenericSansSerif,  // or any other font family
                    (int)FontStyle.Regular,      // font style (bold, italic, etc.)
                    g.DpiY * 10f / 72,       // em size
                    new Point(xPos - 10, 236 - yPos),              // location where to draw text
                    new StringFormat());          // set options here (e.g. center alignment)
                g.DrawPath(new Pen(new SolidBrush(Color.White), 6), p);
                g.DrawPath(new Pen(new SolidBrush(Color.Black), 4), p);
                g.DrawPath(new Pen(new SolidBrush(Color.Yellow), 1), p);
                // + g.FillPath if you want it filled as well
                //g.DrawString(Global.HexToString(levelCode), new Font(new FontFamily("Times New Roman"), 11.8f, FontStyle.Bold),new SolidBrush(Color.White), xPos - 10, 233 - yPos);
                //g.DrawString(Global.HexToString(levelCode), new Font(new FontFamily("Times New Roman"), 10f, FontStyle.Bold),new SolidBrush(Color.Black), xPos - 10, 236 - yPos);
            }
            return bmp;
        }
        public override string ToString()
        {
            return $"{Global.HexToString(levelCode)} - ({Global.HexToString(zPos)},{Global.HexToString(xPos)},{Global.HexToString(yPos)})";
        }
        public void WriteToRom ()
        {
            //xPos = rom.Read8(levelCoordsX + levelCode);
            //yPos = rom.Read8(levelCoordsY + levelCode);
            //zPos = rom.Read8(levelCoordsZ + levelCode);
            rom.Write8(rom.LEVELCOORDSX + levelCode, xPos);
            rom.Write8(rom.LEVELCOORDSY + levelCode, yPos);
            rom.Write8(rom.LEVELCOORDSZ + levelCode, zPos);
            rom.Write8(directionUp + levelCode, up);
            rom.Write8(directionDown + levelCode, down);
            rom.Write8(directionLeft + levelCode, left);
            rom.Write8(directionRight + levelCode, right);

        }
    }
    public class StagePath
    {
        public OverworldEditor overworldEditor;
        public int startX = 0, startY = 0, endX = 0, endY = 0, startStage, endStage;
        public int map;
        public bool difMaps;

        public StagePath (OverworldEditor overworldEditor, int map)
        {
            this.overworldEditor = overworldEditor;
            this.map = map;
        }
        public void MarkStartAndEnd(int start, int end)
        {
            var startS = overworldEditor.GetLevelByCode(start);
            var endS = overworldEditor.GetLevelByCode(end);
            if (startS == null || endS == null)
                return;
            startStage = startS.levelCode;
            startX = startS.xPos;
            startY = startS.yPos;
            endStage = endS.levelCode;
            endX = endS.xPos;
            endY = endS.yPos;
            if (startS.zPos != endS.zPos)
            {
                difMaps = true;
                if (startS.zPos % 2 == 1)
                {
                    endX = 0xff;
                }
                else
                {
                    endX = 0;
                }
            }


        }
        public Bitmap DrawPath(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Point start = new Point(startX, 0x100 - startY);
                Point end = new Point(endX, 0x100 - endY);
                g.DrawLine(new Pen(Color.Red, 3), start, end);

            }
            return bmp;
        }
    }

}
