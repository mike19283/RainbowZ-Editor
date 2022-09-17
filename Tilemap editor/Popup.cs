using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class Popup : Form
    {
        public string @object;
        ROM rom;
        private ushort orientation;
        private ushort palettePointer;
        private ushort defaultAnim;
        private int _14c5;
        private int _145d;
        private int _f25;
        private int _ff5;
        private int _fc1;
        private int idCode;
        private int pointer;
        byte[] paramCountLut = new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 1, 2, 0, 3, 1, 1, 1 };
        Bitmap sprite;
        private List<Color> palette;
        Dictionary<int, int> xPositions = new Dictionary<int, int>()
        {
            [0x0] = 0,
            [0x1] = -4,
            [0x2] = -8,
            [0x3] = -12,
            [0x4] = -16,
            [0x5] = -12,
            [0x6] = -8,
            [0x7] = -4,
            [0x8] = 0,
            [0x9] = 4,
            [0xa] = 8,
            [0xb] = 12,
            [0xc] = 16,
            [0xd] = 12,
            [0xe] = 8,
            [0xf] = 4,
        };
        Dictionary<int, int> yPositions = new Dictionary<int, int>()
        {
            [0x0] = -16,
            [0x1] = -12,
            [0x2] = -8,
            [0x3] = -4,
            [0x4] = 0,
            [0x5] = 4,
            [0x6] = 8,
            [0x7] = 12,
            [0x8] = 16,
            [0x9] = 12,
            [0xa] = 8,
            [0xb] = 4,
            [0xc] = 0,
            [0xd] = -4,
            [0xe] = -8,
            [0xf] = -12,
        };
        Font drawFont = new Font("Arial", 14);
        SolidBrush drawBrush = new SolidBrush(Color.Gold);
        int drawX = 3;
        int drawY = 10;
        StringFormat drawFormat = new StringFormat();
        
        public Popup(ROM rom, int pointer)
        {
            InitializeComponent();
            this.rom = rom;
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            listBox_obj_list.Items.AddRange(rom.objectString.ToArray());
            listBox_obj_list.SelectedIndex = 0;
            comboBox_category.Items.AddRange(rom.objectCategories.ToArray());
            comboBox_category.SelectedIndex = 4;
            if (pointer >= 0x8000)
                listBox_obj_list.SelectedIndex = rom.objectIndexByCode[pointer];

        }

        private void listBox_obj_list_DoubleClick(object sender, EventArgs e) => Confirm();

        private void listBox_obj_list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Confirm();
            }
        }

        public void Confirm()
        {
            var selection = listBox_obj_list.SelectedItem.ToString();
            if (selection.Length > 1 && !selection.Contains(':'))
            {
                @object = listBox_obj_list.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_obj_list.SelectedIndex = listBox_obj_list.Items.Count - 1;
            listBox_obj_list.SelectedIndex = rom.objectCategoriesByString[$"{comboBox_category.SelectedItem}:"];
        }

        private void listBox_obj_list_MouseDown(object sender, MouseEventArgs e)
        {
            // On right click
            if (e.Button == MouseButtons.Right)
            {
                Confirm();
            }

        }
        List<string> ReadScript(Int32 address)
        {
            try
            {
                address &= 0xffff;

                if (address > 0x8000)
                {
                    address |= 0x350000;
                }
                else
                {
                    //0xbbb154 - scripts start
                    int tempPointer = pointer * 4 + 8;
                    address = (int)rom.Read24(tempPointer + 0xbae09f);
                    //return new List<string>();
                }

                List<string> rtn = new List<string>();
                Stack<int> calls = new Stack<int>();


                string spaces = "";

                while (true)
                {
                    // Read command value
                    Int32 command = rom.Read16(ref address);

                    // What category is command?
                    if (command < 0x8000)
                    {
                        // Set array value
                        Int32 value = rom.Read16(ref address);
                        if (command == 0xd45)
                        {
                            idCode = value;
                        }
                        if (command == 0x145d)
                        {
                            _145d = value;
                        }
                        if (command == 0x14c5)
                        {
                            _14c5 = value;
                        }
                        switch (command)
                        {
                            case 0xf25:
                                _f25 = value;
                                break;
                            case 0xff5:
                                _ff5 = value;
                                break;
                            case 0xfc1:
                                _fc1 = value;
                                break;
                            default:
                                break;
                        }
                        rtn.Add(spaces + string.Format("[{0:x}] = {1:x}", command, value));
                    }
                    else
                    {
                        // Hard-coded call
                        command >>= 8;
                        UInt16[] values = new UInt16[paramCountLut[command - 0x80]];
                        for (int i = 0; i < values.Length; i++)
                        {
                            var v = rom.Read16(address);
                            values[i] = v;
                            switch (command)
                            {
                                case 0x81:
                                    defaultAnim = v;
                                    break;
                                case 0x88:
                                    palettePointer = v;
                                    break;
                                case 0x97:
                                    orientation = v;
                                    break;
                                default:
                                    break;
                            }
                        }

                        // Build a string
                        string txt = string.Format("{0:x} -> ", command);
                        for (int i = 0; i < values.Length; i++)
                        {
                            var value = rom.Read16(ref address);
                            txt += string.Format("{0:x} ", value);
                        }
                        // Command specific actions
                        switch (command)
                        {
                            case 0x80:
                                // Return
                                if (calls.Count <= 0)
                                {
                                    rtn.Add("==========");
                                    return rtn;
                                }

                                rtn.Add(Environment.NewLine);
                                address = calls.Pop();
                                spaces = new string(' ', calls.Count);
                                break;
                            case 0x82:
                                // Call
                                calls.Push(address);
                                address = values[0] + 0x350000;
                                spaces = new string(' ', calls.Count);
                                break;
                            default: rtn.Add(spaces + txt); break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                palettePointer = 0;
                defaultAnim = 0;
                orientation = 0;
                sprite = null;
                return null;
            }
        }

        private void listBox_obj_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = listBox_obj_list.SelectedItem.ToString();
            try
            {
                GetPointer(selection);
                ReadScript(0xb50000 + pointer);
                if (palettePointer != 0 && defaultAnim != 0)
                    SetupGraphic();
                if (idCode == 0x38)
                {
                    if ((_145d & 0x4) == 0)
                    {
                        //1b88
                        sprite = rom.ReadFromSpriteHeader(0x1b88, palette);

                    }

                    sprite = DrawCannonDirections(sprite);
                }

                pictureBox_spritePreview.Image = sprite;
            }
            catch (Exception ex)
            {
            }
        }

        private void GetPointer(string selection)
        {
            pointer = rom.objectIndexByString[selection];
            pointer = rom.objectCodeByIndex[pointer];
        }

        private void SetupGraphic()
        {
            palette = rom.ReadPalette(0xbc0000 | palettePointer)[0];

            int index = GetSpriteIndex(1);
            try
            {
                sprite = rom.ReadFromSpriteHeader(index, palette);
                if ((orientation & 0x4000) > 0)
                {
                    sprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                if ((orientation & 0x8000) > 0)
                {
                    sprite.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }
            }
            catch
            {
                sprite = null;
            }
        }
        int GetSpriteIndex(int index)
        {
            int animationArray = rom.Read16(0xbe8572 + defaultAnim * 2);
            int indexPtr = 0xbe0000 + animationArray + index;
            return rom.Read16(indexPtr);
        }

        private Bitmap DrawCannonDirections(Bitmap bmp)
        {
            int d = _14c5 & 0xf0;
            d >>= 3;
            int directionGFX = rom.Read16((_145d & 4) > 0 ? 0xbed9ae + d : 0xbed9ce + d);
            bmp = rom.ReadFromSpriteHeader(directionGFX, palette);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                int inDirection = (_14c5 & 0xf0) >> 4;
                int outDirection = (_14c5 & 0xf000) >> 12;
                double inX = 5 * xPositions[inDirection] + 0x80;
                double inY = -5 * yPositions[inDirection] + 0x80;
                double outX = 5 * xPositions[outDirection] + 0x80;
                double outY = -5 * yPositions[outDirection] + 0x80;
                double slope;
                try
                {
                    slope = (inY - outY) / (inX - outX);

                }
                catch (Exception ex)
                {
                    slope = 0;
                }
                var inPen = new Pen(Color.Red, 4.0f);
                var outPen = new Pen(Color.Green, 2.0f);
                var inPoint = new Point((int)inX, (int)inY);
                var outPoint = new Point((int)outX, (int)outY);
                var origin = new Point(0x80, 0x80);
                //g.DrawLine(inPen, origin, inPoint);
                g.DrawLine(outPen, origin, outPoint);

                // In line
                // Y intercept = 0
                g.DrawString("[145d] = " + _145d.ToString("X4"), drawFont, drawBrush, drawX + 0, drawY + 0);
                g.DrawString("[14c5] = " + _14c5.ToString("X4"), drawFont, drawBrush, drawX + 0, drawY + 40);
                g.DrawString("[f25] = " + _f25.ToString("X4"), drawFont, drawBrush, drawX + 0, drawY + 80);
                g.DrawString("[ff5] Speed, hi = " + _ff5.ToString("X4"), drawFont, drawBrush, drawX + 0, drawY + 120);
                g.DrawString("[fc1] Duration = " + _fc1.ToString("X4"), drawFont, drawBrush, drawX + 0, drawY + 160);
            }
            return bmp;
        }

    }
}
