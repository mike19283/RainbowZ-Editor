using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Palette_HSLEdit : Form
    {
        public static int hue = 180;
        public static int sat = 50;
        public static int lum = 50;
        TrackBar[] trackBars;
        TextBox[] textBoxes;
        Label[] labels;

        public Palette_HSLEdit(int h, int s, int l)
        {
            InitializeComponent();

            trackBars = new TrackBar[]
            {
                trackBar_hue,
                trackBar_saturation,
                trackBar_luminance,
            };
            textBoxes = new TextBox[]
            {
                textBox_hue,
                textBox_saturation,
                textBox_luminance,
            };
            labels = new Label[]
            {
                label_hue,
                label_saturation,
                label_luminance,
            };
            trackBar_hue.Value = hue;
            trackBar_saturation.Value = sat;
            trackBar_luminance.Value = lum;
            label_hue.Text = h.ToString();
            label_saturation.Text = s.ToString();
            label_luminance.Text = l.ToString();

            this.Location = new Point(300, 900);

        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var currentCombo = e.KeyData.ToString();
                if (currentCombo == "V, Ctrl")
                {
                    e.SuppressKeyPress = true;
                    return;
                }
                if (Regex.IsMatch(currentCombo, "D[1-9]\\, Shift"))
                {
                    e.SuppressKeyPress = true;
                    return;

                }

                var x = e.KeyCode;
                if (e.KeyCode == Keys.Back)
                {
                    throw new Exception();
                }


                // Cast event to string
                var current = e.KeyCode.ToString();
                int numpad = current.IndexOf("NumPad");
                current = current.Substring(numpad == 0 ? 6 : 0);

                if (current.Contains("D"))
                {
                    current = current.Substring(1);
                }
                if (!"0123456789abcdefABCDEF".Contains(current))
                {
                    e.SuppressKeyPress = true;
                    return;
                }


                int index = FindIndexTextBox(sender);

                string result = textBoxes[index].Text + current;
                int resNum = Convert.ToInt32(result);
                int[] max = new int[] { 360, 100, 100 };
                if (resNum <= 0 || resNum > max[index])
                {
                    e.SuppressKeyPress = true;
                    return;
                }
                trackBars[index].Value = resNum;
                labels[index].Text = result;
            }
            catch
            {
                return;
            }

        }
        public int FindIndexTextBox(object sender)
        {
            int index = -1;
            if (sender.GetHashCode() == textBox_hue.GetHashCode())
            {
                index = 0;
            }
            if (sender.GetHashCode() == textBox_saturation.GetHashCode())
            {
                index = 1;
            }
            if (sender.GetHashCode() == textBox_luminance.GetHashCode())
            {
                index = 2;
            }
            return index;
        }
        public int FindIndexTrackbar(object sender)
        {
            int index = -1;
            // Find the hashcode that matches
            // And set our index accordingly
            if (sender.GetHashCode() == trackBar_hue.GetHashCode())
            {
                index = 0;
            }
            if (sender.GetHashCode() == trackBar_saturation.GetHashCode())
            {
                index = 1;
            }
            if (sender.GetHashCode() == trackBar_luminance.GetHashCode())
            {
                index = 2;
            }
            return index;
        }

        private void trackBarUpdateLabel(object sender, EventArgs e)
        {
            // What is our index?
            int index = FindIndexTrackbar(sender);

            // Now that we know index, set appropriate label
            labels[index].Text = trackBars[index].Value.ToString();

            hue = trackBar_hue.Value;
            sat = trackBar_saturation.Value;
            lum = trackBar_luminance.Value;

        }
    }
}
