using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Palette_Editor : Form
    {
        ROM rom;
        List<List<Color>> colors = new List<List<Color>>();
        List<List<Color>> colorsPreMod;
        int timerWrite = 0;
        int hue = 180, saturation = 50, luminance = 50;
        // ORIGINAL
        const int HUE = 180, SATURATION = 50, LUMINANCE = 50;
        public static bool modify = false;
        Dictionary<int, TextBox> textBoxes = new Dictionary<int, TextBox>();
        Palette_HSLEdit chooseHSL;
        StoredData sd;

        public Palette_Editor(ROM rom, StoredData sd, int pointer = 0, bool bg = true)
        {
            this.rom = rom;
            this.sd = sd;
            InitializeComponent();
            // Initialize textbox dictionary before anything happens
            textBoxes[textBox_offset.GetHashCode()] = textBox_offset;
            textBoxes[textBox_rows.GetHashCode()] = textBox_rows;
            textBoxes[textBox_columns.GetHashCode()] = textBox_columns;


            comboBox_palStyle.SelectedIndex = bg ? 1 : 0;
            textBox_offset.Text = bg ? (pointer & 0x3fffff).ToString("X") : (0x3c0000 + pointer).ToString("X");


            // Disable export at start
            exportbmpToolStripMenuItem.Enabled = false;
        }

        private void Init()
        {
            //MessageBox.Show("path");

            timer_saveAs.Enabled = true;

            panel_workZone.Visible = true;
            rom.ReadPaletteFromROM(0, 0, 0);
            DisplayPalette();
            textBox_rows.Text = "8";
            textBox_columns.Text = "16";
            textBox_offset.Text = "0";
            // Clear all images every time
            ClearAllPictureBoxes(this);


            this.Text = rom.GetTitle();

            // Disable export at start
            exportbmpToolStripMenuItem.Enabled = false;
            importbmpToolStripMenuItem.Enabled = false;
            button_write.Enabled = false;
            button_AddToBookmarks.Enabled = false;

            // Set false so we can load more than 1
            rom.loadROMSuccess = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom.Load();
            if (rom.loadROMSuccess)
            {
                Init();
            }


        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void comboBox_palStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox_palStyle.SelectedIndex;
            if (index == 0)
            {
                textBox_rows.Text = "1";
                textBox_columns.Text = "15";
            }
            else if (index == 1)
            {
                textBox_rows.Text = "8";
                textBox_columns.Text = "16";

            }
        }

        public void DisplayPalette()
        {

            // Clear all images every time
            ClearAllPictureBoxes(this);

            var rows = Convert.ToInt32(textBox_rows.Text);
            var columns = Convert.ToInt32(textBox_columns.Text);
            // Set picture size
            pictureBox_palette.Size = new System.Drawing.Size(columns * 20, rows * 20);
            // Fill picture
            pictureBox_palette.Image = CreateBitmapAtRuntime(columns * 20, rows * 20);


        }

        private void button_palette_Click(object sender, EventArgs e)
        {

            var rows = textBox_rows.Text;
            var columns = textBox_columns.Text;
            var offset = textBox_offset.Text;
            if (offset.Length != 0 && rows.Length != 0 && rows != "0" && columns.Length != 0 && columns != "0")
            {
                int length = Convert.ToInt32(textBox_rows.Text) * Convert.ToInt32(textBox_columns.Text) * 2;
                int maxOffset = 0x3fffff - length;
                if (Convert.ToInt32(textBox_offset.Text, 16) > maxOffset + 1)
                {
                    MessageBox.Show("Error");
                    return;
                }

                button_AddToBookmarks.Enabled = true;
                button_modifyAll.Enabled = true;


                var r = Convert.ToInt32(textBox_rows.Text);
                var c = Convert.ToInt32(textBox_columns.Text);
                var o = Convert.ToInt32(textBox_offset.Text, 16);

                o &= 0x3fffff;

                colors = rom.ReadPaletteFromROM(o, r, c);

                DisplayPalette();
                // Disable export at start
                exportbmpToolStripMenuItem.Enabled = true;
                importbmpToolStripMenuItem.Enabled = true;
                button_write.Enabled = true;

                // Reset HSL
                hue = 180;
                saturation = 50;
                luminance = 50;

                //colorsPreMod = null;
                colorsPreMod = DeepCopy(colors);

            }
        }
        public Bitmap CreateBitmapAtRuntime(int width, int height)
        {
            // Create bitmap based on selected option
            Bitmap thisPalette = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(thisPalette))
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    for (int j = 0; j < colors[i].Count; j++)
                    {
                        g.FillRectangle(new SolidBrush(colors[i][j]), j * 20, i * 20, 20, 20);
                    }
                }
            }
            return (Bitmap)thisPalette.Clone();
        }
        public void ClearAllPictureBoxes(Control ctrl)
        {
            var pict = ctrl as PictureBox;
            if (pict == null)
            {
                foreach (Control child in ctrl.Controls)
                    ClearAllPictureBoxes(child);
            }
            else
            {
                pict.Image = null;
            }

        }
        public void PictureBoxClickAction(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;
            PictureBox pb = (PictureBox)sender;
            if (pb.Image != null)
            {
                Bitmap pal = (Bitmap)pb.Image;
                // Each color is 20 x 20 pixels
                int x = m.X / 20;
                int y = m.Y / 20;

                bool exist = x - 1 > -1;
                bool exist2 = x - 2 > -1;


                ColorDialog cdialog = new ColorDialog();
                // Show a custom color history
                cdialog.CustomColors = new int[]
                {
                    ColorTranslator.ToOle(colors[y][x]),
                    ColorTranslator.ToOle(exist? colors[y][x - 1] : new Color ()),
                    ColorTranslator.ToOle(exist2? colors[y][x - 2] : new Color ()),

                };

                // Display selector and assign color where clicked 
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    colors[y][x] = cdialog.Color;

                    DisplayPalette();

                    //colorsPreMod = null;
                    // Reset HSL
                    hue = 180;
                    saturation = 50;
                    luminance = 50;

                }
            }
        }

        private void button_write_Click(object sender, EventArgs e)
        {
            int address = Convert.ToInt32(textBox_offset.Text, 16);
            rom.WritePaletteToROM(colors, address);
            timerWrite = 300;
            colorsPreMod = DeepCopy(colors);
            hue = 180;
            saturation = 50;
            luminance = 50;

        }
        private void timer_written_Tick(object sender, EventArgs e)
        {
            if (timerWrite != 0)
            {
                label_write.Visible = true;
                timerWrite -= 10;
            }
            else
            {
                label_write.Visible = false;
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void importbmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFunc();

        }


        private void ImportFunc()
        {
            if (textBox_offset.Text.Length == 0)
            {
                MessageBox.Show("Error!");
                return;
            }

            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Bitmap (*.bmp;)|*.bmp;";
            d.Title = "Select a Bitmap to use";

            if (d.ShowDialog() == DialogResult.OK)
            {
                var byteArray = File.ReadAllBytes(d.FileName);
                Bitmap bmp = BytesToBitmap(byteArray);
                pictureBox_palette.Image = bmp;
                int width = bmp.Width / 20;
                int height = bmp.Height / 20;
                textBox_rows.Text = height.ToString();
                textBox_columns.Text = width.ToString();
                colors = GetColorsFromBitmap(bmp);

                // Reset HSL
                hue = 180;
                saturation = 50;
                luminance = 50;
            }
        }
        public List<List<Color>> GetColorsFromBitmap(Bitmap bmp)
        {
            List<List<Color>> @return = new List<List<Color>>();

            // Initialize size
            for (int i = 0; i < bmp.Height; i += 20)
            {
                @return.Add(new List<Color>());
                for (int j = 0; j < bmp.Width; j += 20)
                {
                    @return[i / 20].Add(new Color());
                }
            }

            // Loop through bitmap
            for (int i = 0; i < bmp.Height; i += 20)
            {
                for (int j = 0; j < bmp.Width; j += 20)
                {
                    @return[i / 20][j / 20] = bmp.GetPixel(j, i);
                }
            }
            return @return;

        }

        public static Bitmap BytesToBitmap(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                ms.Position = 0;
                Bitmap img = (Bitmap)Image.FromStream(ms);
                return img;
            }
        }

        private void exportbmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files (*.bmp)|*.bmp;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox_palette.Image.Width);
                int height = Convert.ToInt32(pictureBox_palette.Image.Height);
                Bitmap bmp = new Bitmap(width, height);
                bmp = (Bitmap)pictureBox_palette.Image;
                bmp.Save(dialog.FileName.Substring(0, dialog.FileName.Length - 4) + " - 0x" + textBox_offset.Text + ".bmp", ImageFormat.Bmp);
                MessageBox.Show("Exported!");
            }

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var currentCombo = e.KeyData.ToString();
            if (currentCombo == "V, Control")
            {
                return;
            }
            if (Regex.IsMatch(currentCombo, "D[1-9]\\, Shift"))
            {
                e.SuppressKeyPress = true;
                return;

            }


            button_modifyAll.Enabled = false;
            button_AddToBookmarks.Enabled = false;
            exportbmpToolStripMenuItem.Enabled = false;
            //importbmpToolStripMenuItem.Enabled = false;


            // Get hash
            int hash = sender.GetHashCode();

            // Which textbox are we looking at?
            TextBox tb = textBoxes[hash];


            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab)
            {
                return;
            }

            // Cast event to string
            var current = e.KeyCode.ToString();
            int numpad = current.IndexOf("NumPad");
            current = current.Substring(numpad == 0 ? 6 : 0);
            if (current.Contains("D") && current.Length > 1)
            {
                current = current.Substring(1);
            }
            if (tb == textBox_offset && !"0123456789abcdefABCDEF".Contains(current) || tb != textBox_offset && !"0123456789".Contains(current))
            {
                e.SuppressKeyPress = true;
                return;
            }

            if (tb.Text == "")
            {
                return;
            }
            if (tb.SelectionLength > 0) { return; }

            string result = textBoxes[hash].Text + current;
            // Check which number format to convert to
            int resNum;
            if (tb == textBox_offset)
            {
                resNum = Convert.ToInt32(result, 16);
            }
            else
            {
                resNum = Convert.ToInt32(result);
            }

            int length = Convert.ToInt32(textBox_rows.Text) * Convert.ToInt32(textBox_columns.Text) * 2;
            int maxOffset = 0x400000 - length;
            // Get the max each textbox could be
            Dictionary<int, int> max = new Dictionary<int, int>()
            {
                [textBox_offset.GetHashCode()] = maxOffset + 1,
                [textBox_rows.GetHashCode()] = 0x10,
                [textBox_columns.GetHashCode()] = 0x10
            };
            if (resNum <= 0 || resNum >= max[hash])
            {
                e.SuppressKeyPress = true;
                return;
            }


        }

        private void timer_saveAs_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button_AddToBookmarks_Click(object sender, EventArgs e)
        {
            Palette_AddToBookmarks add = new Palette_AddToBookmarks();
            if (add.ShowDialog() == DialogResult.OK)
            {
                string bookmarkName = add.bookmarkName;
                string bookmarkPointer = textBox_offset.Text;
                sd.Write(ROM.gameTitleAsString + "Custom", bookmarkPointer, bookmarkName);
                rom.gameCustompointers[bookmarkPointer] = bookmarkName;
            }
        }

        private void button_modifyAll_Click(object sender, EventArgs e)
        {
            // Backup before mod
            if (colorsPreMod == null)
            {
                colorsPreMod = DeepCopy(colors);
            }

            timer_hsl.Enabled = true;

            //Task.Run(() =>
            //{
            chooseHSL = new Palette_HSLEdit(hue, saturation, luminance);
            chooseHSL.StartPosition = FormStartPosition.Manual;
            chooseHSL.Left = 200;
            chooseHSL.Top = 300;
            chooseHSL.ShowDialog();
            //});

        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Get values
            var rows = textBox_rows.Text;
            var columns = textBox_columns.Text;
            if (rows == "1" && columns == "15")
            {
                comboBox_palStyle.SelectedIndex = 0;
            }
            else if (rows == "8" && columns == "16")
            {
                comboBox_palStyle.SelectedIndex = 1;
            }
            else
            {
                comboBox_palStyle.SelectedIndex = 2;
            }



        }

        private Color HSLtoRGBColor(double h, double s, double l)
        {
            /*
             view-source:https://www.rapidtables.com/convert/color/hsl-to-rgb.html
             if( h<0 ) h=0;
			if( s<0 ) s=0;
			if( l<0 ) l=0;
			if( h>=360 ) h=359;
			if( s>100 ) s=100;
			if( l>100 ) l=100;
            */
            if (h < 0) h = 0;
            if (s < 0) s = 0;
            if (l < 0) l = 0;
            if (h >= 360) h = 359;
            if (s > 100) s = 100;
            if (l > 100) l = 100;

            //s/=100;
            //l/=100;
            //C = (1-Math.abs(2*l-1))*s;
            //hh = h/60;
            //X = C*(1-Math.abs(hh%2-1));
            //r = g = b = 0;
            s /= 100;
            l /= 100;
            double C = (1 - Math.Abs(2 * l - 1)) * s;
            double hh = h / 60;
            double X = C * (1 - Math.Abs(hh % 2 - 1));
            double r = 0.0, g = 0.0, b = 0.0;

            //if( hh>=0 && hh<1 )
            //{
            //	r = C;
            //	g = X;
            //}
            //else if( hh>=1 && hh<2 )
            //{
            //	r = X;
            //	g = C;
            //}
            //else if( hh>=2 && hh<3 )
            //{
            //	g = C;
            //	b = X;
            //}
            //else if( hh>=3 && hh<4 )
            //{
            //	g = X;
            //	b = C;
            //}
            //else if( hh>=4 && hh<5 )
            //{
            //	r = X;
            //	b = C;
            //}
            //else
            //{
            //	r = C;
            //	b = X;
            //}

            if (hh >= 0 && hh < 1)
            {
                r = C;
                g = X;
            }
            else if (hh >= 1 && hh < 2)
            {
                r = X;
                g = C;
            }
            else if (hh >= 2 && hh < 3)
            {
                g = C;
                b = X;
            }
            else if (hh >= 3 && hh < 4)
            {
                g = X;
                b = C;
            }
            else if (hh >= 4 && hh < 5)
            {
                r = X;
                b = C;
            }
            else
            {
                r = C;
                b = X;
            }

            //m = l-C/2;
            //r += m;
            //g += m;
            //b += m;
            //r *= 255.0;
            //g *= 255.0;
            //b *= 255.0;
            //r = Math.round(r);
            //g = Math.round(g);
            //b = Math.round(b);

            double m = l - C / 2;
            r += m;
            g += m;
            b += m;
            r *= 255.0;
            g *= 255.0;
            b *= 255.0;
            r = Math.Round(r);
            g = Math.Round(g);
            b = Math.Round(b);


            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        public void ChangeWholePalette()
        {
            // Loop through row
            for (int i = 0; i < colors.Count; i++)
            {
                // Loop through column
                for (int j = 0; j < colors[i].Count; j++)
                {
                    // Get hue, sat, and lum
                    var h = colorsPreMod[i][j].GetHue();
                    var s = colorsPreMod[i][j].GetSaturation() * 100;
                    var l = colorsPreMod[i][j].GetBrightness() * 100;

                    h += ((hue - HUE));// & 360);
                    s += ((saturation - SATURATION));
                    l += ((luminance - LUMINANCE));

                    colors[i][j] = HSLtoRGBColor(h, s, l);
                }
            }
        }
        // Deep copy
        public List<List<Color>> DeepCopy(List<List<Color>> toCopy)
        {
            List<List<Color>> @return = new List<List<Color>>();

            // Loop through rows
            for (int i = 0; i < toCopy.Count; i++)
            {
                @return.Add(new List<Color>());
                // Loop through columns
                for (int j = 0; j < toCopy[i].Count; j++)
                {
                    // Now we are looking at colors
                    @return[i].Add(toCopy[i][j]);
                }
            }


            return @return;
        }
        public void Save()
        {
            //iniFile.SaveIni();
            //rom.SaveAsROM();
            //this.Text = Version.versionString + " - " + rom.GetTitle();

        }


        private void bFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_rows.Text = "8";
            textBox_columns.Text = "16";
            GetBookmark("BG");
        }

        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_rows.Text = "1";
            textBox_columns.Text = "15";
            GetBookmark("Object");
        }

        private void Palette_Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBookmark("Custom");
        }
        public void GetBookmark(string type)
        {
            Palette_Bookmarks bkmk;
            switch (type)
            {
                case "BG":
                    bkmk = new Palette_Bookmarks(rom.gameBGpointers);
                    break;
                case "Object":
                    bkmk = new Palette_Bookmarks(rom.gameObjpointers);

                    break;
                default:
                    bkmk = new Palette_Bookmarks(rom.gameCustompointers);
                    break;
            }

            if (bkmk.ShowDialog() == DialogResult.OK)
            {
                textBox_offset.Text = bkmk.selectedKey;
            }
        }
        private void timer_hsl_Tick(object sender, EventArgs e)
        {


            hue = Palette_HSLEdit.hue;
            saturation = Palette_HSLEdit.sat;
            luminance = Palette_HSLEdit.lum;

            // Change each color based on HSL
            ChangeWholePalette();
            DisplayPalette();

            if (chooseHSL.DialogResult == DialogResult.OK)
            {
                timer_hsl.Enabled = false;
            }
        }
        public double[] GetAverageHSL()
        {
            // Create a holder for our hsl
            double[] hsl = new double[3] { 0, 0, 0 };
            int total = 0;

            // Loop through
            foreach (var row in colors)
            {
                foreach (var col in row)
                {
                    hsl[0] += col.GetHue();
                    hsl[1] += col.GetSaturation();
                    hsl[2] += col.GetBrightness();

                    total++;
                }
            }
            // Divide each by total to get average
            hsl[0] /= total;
            hsl[1] /= total;
            hsl[2] /= total;

            return hsl;
        }

        public void ClickGetPalette()
        {
            button_palette_Click(0, new EventArgs());
        }
    }
}
