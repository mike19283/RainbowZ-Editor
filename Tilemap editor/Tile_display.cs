using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Tile_display : Form
    {
        PopupImage popupImage;
        ROM rom;
        DKCLevel thisLevel;
        public int selectedTileIndex;
        int columns;
        public int selectionMode = 0;
        bool left;
        public int leftIndex = 0;
        bool right;
        public int rightIndex = 0;
        bool mid;
        public List<int> midIndices = new List<int>();
        public List<List<int>> stamp = new List<List<int>>();
        public Bitmap stampImg;
        Point selectStamp;
        public string highlightOrPaste = "highlight";
        Form1 form;
        public bool scanned;
        public string autofill;
        public int autoUDLR = 0;
        public Bitmap platinum;

        public Tile_display(DKCLevel thisLevel, ROM rom, Form1 form)
        {
            InitializeComponent();
            this.form = form;
            this.rom = rom;
            this.thisLevel = thisLevel;
#if !DEBUG
            this.TopMost = true;

#endif
            selectedTileIndex = 0;
            
            //pictureBox_tiles.Image = new Bitmap("C:\\Users\\mikem\\OneDrive\\Pictures\\bananas.png");

            columns = (thisLevel.tiles.Count - 1) / 8 + 1;
            pictureBox_tiles.Size = new Size(256, columns * 32);
            pictureBox_tiles1.Size = new Size(256, columns * 32);
            pictureBox_tiles2.Size = new Size(256, columns * 32);
            DrawTileset(0);
            RefreshHistory();

            Global.mapChipX = pictureBox_tiles.Image.Width / 0x20;
            Global.mapChipY = pictureBox_tiles.Image.Height / 0x20;

        }


        private Bitmap SelectTile(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                var temp = selectedTileIndex & 0x3ff;
                var x = temp % 8 * 32;
                var y = (temp / 8) * 32;
                g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), x, y, 32, 32);
                
            }

            return bmp;
        }

        private void pictureBox_tiles_MouseClick(object sender, MouseEventArgs e)
        {
            int flips = 0;
            if (checkBox_xFlip.Checked)
                flips |= 0x4000;
            if (checkBox_yFlip.Checked)
                flips |= 0x8000;

            //SelectTile(e.X, e.Y);
            var x = e.X / 32;
            var y = e.Y / 32;
            var testSelected = x + y * 8;
            if (testSelected >= thisLevel.metaSize)
            {
                return;
            }
            selectedTileIndex = (int)testSelected | flips;
            DrawTileset(0, flips);
            //DrawTileset(selectedTileIndex);
        }
        private void DrawTileset(int start, int flips = 0)
        {
            Bitmap bmp = new Bitmap(8 * 32, columns * 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int y = 0; y < columns; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (start < thisLevel.tiles.Count)
                        {
                            Bitmap tile = thisLevel.GetTileByIndex(start | flips);
                            g.DrawImage(tile, x * 32, y * 32);
                            start++;
                        }
                    }
                }
            }
            pictureBox_tiles1.Image = bmp;
            pictureBox_tiles2.Image = bmp;
            bmp = SelectTile((Bitmap)bmp.Clone());
            pictureBox_tiles.Image = bmp;
        }

        private void tabControl_modes_Click(object sender, EventArgs e)
        {
            try
            {
                rom.sd.RefreshRbs();
                // Read copy from rbs
                var copied = rom.sd.DeserializeListList("Serialize", "Copy");
                form.copiedTilemap = copied;

                if (CheckUniquenessHistory())
                    form.hist.Add(new CopyHistory(copied, form.hist.Count, BuildPaste(form.copiedTilemap)));
                RefreshHistory();

            }
            catch { }


            selectionMode = tabControl_modes.SelectedIndex;

            DrawTileset(0, checkBox_xFlip.Checked ? 0x4000 : 0);

            button_clearStamp_Click(0, new EventArgs());

            autofill = "";
            var z = tabControl_modes.SelectedTab.ToString();
            if (tabControl_modes.SelectedTab.ToString() == "TabPage: {Autofill}")
            {
                radioButton_autoUp.Checked = true;
                radioButton_autoDown.Checked = false;
                radioButton_autoLeft.Checked = false;
                radioButton_autoRight.Checked = false;
                RadioButtonPress(0, new EventArgs());

            }
        }

        private void pictureBox_tiles1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 32, y = e.Y / 32;
            int index = x + (y * 8);
            index |= checkBox_xFlip1.Checked ? 0x4000 : 0;
            index |= checkBox_yFlip1.Checked ? 0x8000 : 0;
            if (left)
            {
                leftIndex = index;
                left = false;
                pictureBox_trail.Image = DrawTrail();
                button_l.Enabled = true;
            }
            if (right)
            {
                rightIndex = index;
                right = false;
                pictureBox_trail.Image = DrawTrail();
                button_r.Enabled = true;
            }
            if (mid)
            {
                midIndices.Add(index);
                mid = false;
                pictureBox_trail.Image = DrawTrail();
                button_m.Enabled = true;
            }

        }
        private void button_left_Click(object sender, EventArgs e)
        {
            left = true;
            button_l.Enabled = false;
        }

        private void button_r_Click(object sender, EventArgs e)
        {
            right = true;
            button_r.Enabled = false;
        }

        private void button_m_Click(object sender, EventArgs e)
        {
            mid = true;
            button_m.Enabled = false;
        }
        private Bitmap DrawTrail ()
        {
            Bitmap bmp = new Bitmap(256, 32);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int offset = 0;
                if (leftIndex != 0)
                {
                    g.DrawImage(thisLevel.GetTileByIndex(leftIndex), offset, 0);
                    offset += 32;
                }

                foreach (var index in midIndices)
                {
                    g.DrawImage(thisLevel.GetTileByIndex(index), offset, 0);
                    offset += 32;
                }

                if (rightIndex != 0)
                {
                    g.DrawImage(thisLevel.GetTileByIndex(rightIndex), offset, 0);
                    offset += 32;
                }
            }

            return bmp;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            leftIndex = 0;
            rightIndex = 0;
            midIndices = new List<int>();
            pictureBox_trail.Image = DrawTrail();
        }

        private void button_clearStamp_Click(object sender, EventArgs e)
        {
            // Clear behind the scenes
            var temp = new List<List<int>>() 
            {
                new List<int>() {0,0,0,0,0},
                new List<int>() {0,0,0,0,0},
                new List<int>() {0,0,0,0,0},
                new List<int>() {0,0,0,0,0},
                new List<int>() {0,0,0,0,0},
            };
            stamp = temp;


            // Display stamp
            pictureBox_stamp.Image = DrawStamp(stamp);
        }

        public Bitmap DrawStamp (List<List<int>> stamp)
        {
            Bitmap bmp = new Bitmap(160, 160);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        var img = thisLevel.GetTileByIndex(stamp[x][y]);
                        g.DrawImage(img, x * 32, y * 32);
                    }
                }
            }
            stampImg = bmp;
            return bmp;
        }
        private void checkBox_yFlipAll_Click(object sender, EventArgs e)
        {
            var chkbx = (CheckBox)sender;
            if (chkbx.Checked)
            {
                selectedTileIndex |= 0x8000;
            }
            else
            {
                selectedTileIndex &= 0x7fff;
            }

            //DrawTileset(0, chkbx.Checked ? 0x8000 : 0);
            DrawTileset(0, selectedTileIndex & 0xf000);

        }

        private void checkBox_xFlipAll_Click(object sender, EventArgs e)
        {
            var chkbx = (CheckBox)sender;
            if (chkbx.Checked)
            {
                selectedTileIndex |= 0x4000;
            }
            else
            {
                selectedTileIndex &= 0xbfff;
            }

            //DrawTileset(0, chkbx.Checked ? 0x4000 : 0);
            DrawTileset(0, selectedTileIndex & 0xf000);


        }

        private void pictureBox_stamp_MouseClick(object sender, MouseEventArgs e)
        {
            var bmp = DrawStamp(stamp);
            // Display stamp
            pictureBox_stamp.Image = bmp;
            int x = e.X / 32, y = e.Y / 32;
            selectStamp = new Point(x, y);

            using(Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawRectangle(new Pen(Color.Red), x * 32, y * 32, 32, 32);
            }

            pictureBox_stamp.Image = bmp;

        }

        private void pictureBox_tiles2_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 32, y = e.Y / 32;
            int selection = y * 8 + x;
            if (checkBox_xFlip2.Checked)
                selection |= 0x4000;
            if (checkBox_yFlip2.Checked)
                selection |= 0x8000;

            // Change our stamp index to our selection
            stamp[selectStamp.X][selectStamp.Y] = selection;

            // Redraw stamp
            pictureBox_stamp.Image = DrawStamp(stamp);
        }

        private void radioButton_highlight_CheckedChanged(object sender, EventArgs e)
        {
            highlightOrPaste = "highlight";
        }

        private void radioButton_paste_CheckedChanged(object sender, EventArgs e)
        {
            highlightOrPaste = "paste";
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DeleteHighlight();
        }

        private void DeleteHighlight()
        {
            if (form.highlightedTilemap == null)
                return;

            // Get start indexes
            int startX = form.startX / 32;
            int startY = form.startY / 32;
            // Loop through highlighted
            for (int y = 0; y < form.highlightedTilemap.Count; y++)
            {
                for (int x = 0; x < form.highlightedTilemap[0].Count; x++)
                {
                    thisLevel.tilemap[x + startX, y + startY] = 0;
                }

            }
            form.DrawScreen();
        }
        public void CopyHighlighted()
        {
            if (form.highlightedTilemap != null && form.highlightedTilemap.Count > 0)
            {
                var copied = Global.DeepCopyListList(form.highlightedTilemap);
                form.copiedTilemap = copied;
                if (CheckUniquenessHistory())
                    form.hist.Add(new CopyHistory(copied, form.hist.Count, BuildPaste(form.copiedTilemap)));
                RefreshHistory();
                // Get copy as string
                string copyAsString = GetCopiedAsString(copied);
                rom.sd.Write("Serialize", "Copy", copyAsString);
                rom.sd.SaveRbs();
            }
        }
        private void RefreshHistory ()
        {
            listBox_copyHistory.Items.Clear();
            listBox_copyHistory.Items.AddRange(form.hist.ToArray());
        }

        private void button_cut_Click(object sender, EventArgs e)
        {
            checkBox_highlightX.Checked = false;
            checkBox_highlightY.Checked = false;

            CopyHighlighted();
            DeleteHighlight();
            form.pastedImg = BuildPaste(form.copiedTilemap);
            
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            checkBox_highlightX.Checked = false;
            checkBox_highlightY.Checked = false;
 
            CopyHighlighted();
            form.pastedImg = BuildPaste(form.copiedTilemap);
        }
        private Bitmap BuildPaste(List<List<int>> tm)
        {
            Bitmap bmp = new Bitmap(tm[0].Count * 32, tm.Count * 32);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int y = 0; y < tm.Count; y++)
                {
                    for (int x = 0; x < tm[y].Count; x++)
                    {
                        Bitmap tile = thisLevel.GetTileByIndex(tm[y][x]);
                        g.DrawImage(tile, x * 32, y * 32);
                    }
                }
                g.DrawRectangle(new Pen(Color.White, 3), 0, 0, bmp.Width, bmp.Height);
            }
            return bmp;
        }

        private void button_xFlipPaste_Click(object sender, EventArgs e)
        {
            checkBox_highlightX.Checked = !checkBox_highlightX.Checked;

            List<List<int>> @return = new List<List<int>>();
            for (int y = 0; y < form.copiedTilemap.Count; y++)
            {
                @return.Add(new List<int>());
                for (int x = form.copiedTilemap[y].Count - 1; x >= 0; x--)
                {
                    var value = form.copiedTilemap[y][x];
                    @return[y].Add(value ^ 0x4000);
                }
            }

            form.copiedTilemap = @return;
            form.pastedImg = BuildPaste(form.copiedTilemap);
        }

        private void button_yFlipPaste_Click(object sender, EventArgs e)
        {
            if (form.copiedTilemap.Count != form.copiedTilemap[0].Count)
            {
                MessageBox.Show("Not a perfect square. Vertical flip not implemented yet.");
                return;
            }
            checkBox_highlightY.Checked = !checkBox_highlightY.Checked;

            List<List<int>> @return = new List<List<int>>();
            for (int y = form.copiedTilemap.Count - 1, i = 0; y >= 0; y--, i++)
            {
                @return.Add(new List<int>());
                for (int x = 0; x < form.copiedTilemap.Count; x++)
                {
                    var value = form.copiedTilemap[y][x];
                    @return[i].Add(value ^ 0x8000);
                }
            }

            form.copiedTilemap = @return;
            form.pastedImg = BuildPaste(form.copiedTilemap);
        }

        private void checkBox_displayLinks_CheckedChanged(object sender, EventArgs e)
        {
            if (/*checkBox_displayLinks.Checked*/true)
            {
                thisLevel.ReadAllConnections();
                scanned = true;
                autofill = "autofill";
                Bitmap bmp;
                bmp = thisLevel.ReDrawTilemap(true);
                bmp = form.DrawLinks(bmp);
                form.PictureboxSetter(bmp);
            }
            else
            {
                form.DrawScreen();
                scanned = false;
                autofill = "";
            }
        }

        private void button_getLinks_Click(object sender, EventArgs e)
        {
            thisLevel.ReadAllConnections();
        }
        private void RadioButtonPress (object sender, EventArgs e)
        {
            autofill = "autofill";
            if (radioButton_autoUp.Checked)
                autoUDLR = 0;
            else if (radioButton_autoDown.Checked)
                autoUDLR = 1;
            else if (radioButton_autoLeft.Checked)
                autoUDLR = 2;
            else if (radioButton_autoRight.Checked)
                autoUDLR = 3;
        }

        private void button_loadStamp_Click(object sender, EventArgs e)
        {
            StampCollection sc = new StampCollection(thisLevel, this);

            if (sc.ShowDialog() == DialogResult.OK)
            {
                stamp = sc.toReturn;
                pictureBox_stamp.Image = DrawStamp(stamp);
            }
        }

        private void button_saveStamp_Click(object sender, EventArgs e)
        {
            var id = Prompt.ShowDialog("Enter in a unique name", "Stamp name");
            if (id == "")
                return;
            var strArray = Encoding.ASCII.GetBytes(id);
            byte[] stampArr = new byte[strArray.Length + 51];
            Array.Copy(strArray, 0, stampArr, 51, strArray.Length);
            stampArr[0] = (byte)thisLevel.headerIndex;
            int index = 1;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    stampArr[index++] = (byte)(stamp[x][y] >> 0);//  value + stamp[x][y].ToString("X4") + ",";
                    stampArr[index++] = (byte)(stamp[x][y] >> 8);
                }
            }

            File.WriteAllBytes("Stamps\\" + id + ".bin", stampArr);

            //value = value.Substring(0, value.Length - 1);
            //string category = $"Stamps_{thisLevel.levelTheme}";
            //thisLevel.rom.sd.Write(category, id, value);
            //thisLevel.rom.sd.SaveRbs();

            MessageBox.Show("Saved");
        }

        private void button_stampClipboard_Click(object sender, EventArgs e)
        {
            List<List<int>> temp = new List<List<int>>()
            {
                new List<int>() { 0, 0, 0, 0, 0},
                new List<int>() { 0, 0, 0, 0, 0},
                new List<int>() { 0, 0, 0, 0, 0},
                new List<int>() { 0, 0, 0, 0, 0},
                new List<int>() { 0, 0, 0, 0, 0},
            };
            var copy = form.copiedTilemap;
            for (int y = 0; y < 5 && y < copy.Count; y++)
            {
                for (int x = 0; x < 5 && x < copy[0].Count; x++)
                {
                    temp[x][y] = form.copiedTilemap[y][x];
                }
            }
            stamp = temp;
            pictureBox_stamp.Image = DrawStamp(stamp);
        }

        private void button_mirrorX_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < stamp.Count; y++)
            {
                for (int x = 0; x < stamp[0].Count / 2; x++)
                {
                    // Swap first and last
                    stamp[x][y] ^= stamp[4 - x][y];
                    stamp[4 - x][y] ^= stamp[x][y];
                    stamp[x][y] ^= stamp[4 - x][y];
                }
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (stamp[x][y] == 0)
                        continue;

                    stamp[x][y] ^= 0x4000;
                }
            }
            pictureBox_stamp.Image = DrawStamp(stamp);
        }

        private void button_mirrorY_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < stamp.Count / 2; y++)
            {
                for (int x = 0; x < stamp[0].Count; x++)
                {
                    // Swap first and last
                    stamp[x][y] ^= stamp[x][4 - y];
                    stamp[x][4 - y] ^= stamp[x][y];
                    stamp[x][y] ^= stamp[x][4 - y];

                }
            }


            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (stamp[x][y] == 0)
                        continue;
                    stamp[x][y] ^= 0x8000;
                }
            }
            pictureBox_stamp.Image = DrawStamp(stamp);
        }

        private void listBox_copyHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox_highlightX.Checked = false;
            checkBox_highlightY.Checked = false;
            if (listBox_copyHistory.SelectedIndex == -1)
                return;
            var selected = (CopyHistory)listBox_copyHistory.SelectedItem;
            form.copiedTilemap = selected.copied;
            form.pastedImg = selected.bmp;

            if (popupImage != null)
            {
                popupImage.Close();
                timer_previewTimer.Enabled = false;
            }
            popupImage = new PopupImage(selected.bmp);
            popupImage.Show();
            timer_previewTimer.Enabled = true;
        }
        private bool CheckUniquenessHistory()
        {
            foreach (var copied in form.hist)
            {
                if (!copied.UniqueCopy(form.copiedTilemap))
                {
                    return false;
                }
            }
            return true;
        }

        private void timer_previewTimer_Tick(object sender, EventArgs e)
        {
            popupImage.Close();
            timer_previewTimer.Enabled = false;
        }

        private void button_exportMapchip_Click(object sender, EventArgs e)
        {
            DrawTilesetPlatinum(0);


            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Bmp (*.bmp)|*.bmp";

            if (s.ShowDialog() == DialogResult.OK)
            {
                platinum.Save(s.FileName, ImageFormat.Bmp);
                MessageBox.Show("Exported");
            }

        }
        private void DrawTilesetPlatinum(int start, int flips = 0)
        {
            var width = 256;
            var tempC = (thisLevel.tiles.Count - 1) / width + 1;
            int count = thisLevel.tiles.Count, x = 0, y = 0;


            Bitmap bmp = new Bitmap(width * 32, tempC * 32 * 4);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (; flips < 4; flips++)
                {
                    int[] fValues = new int[] { 0, 0x4000, 0x8000, 0xc000 };
                    int mod = fValues[flips];
                    for (int tileIndex = 0; tileIndex < count; tileIndex++)
                    {
                        Bitmap tile = thisLevel.GetTileByIndex(tileIndex | mod);
                        g.DrawImage(tile, x * 32, y * 32);
                        x++;
                        if (x >= 256)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }
            //bmp = SelectTile((Bitmap)bmp.Clone());
            platinum = bmp;
        }
        private string GetCopiedAsString(List<List<int>> copy)
        {
            string @return = $"{copy.Count},{copy[0].Count}";
            foreach (var _i in copy)
            {
                foreach (var _j in _i)
                {
                    @return += $",{_j.ToString("X")}";
                }
            }

            return @return;
        }


    }
    public class CopyHistory
    {
        int count = 0;
        public List<List<int>> copied;
        public Bitmap bmp;

        public CopyHistory (List<List<int>> copied, int count, Bitmap bmp)
        {
            this.copied = copied;
            this.count = count;
            this.bmp = bmp;
        }
        public override string ToString()
        {
            return count.ToString();
        }
        public Bitmap Preview()
        {
            int x = copied[0].Count * 32;
            int y = copied.Count * 32;
            Bitmap bmp = new Bitmap(x, y);

            return bmp;
        }
        public bool UniqueCopy(List<List<int>> compare)
        {
            if (copied.Count != compare.Count || copied[0].Count != compare[0].Count)
            {
                return true;
            }
            for (int i = 0; i < copied.Count; i++)
            {
                for (int j = 0; j < copied[i].Count; j++)
                {
                    if (copied[i][j] != compare[i][j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
