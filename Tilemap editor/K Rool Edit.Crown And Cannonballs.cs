using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class K_Rool_Edit
    {
        // Hacked crown speed 93eeef
        // fce3 cannonballs
        // fc93 crown
        Dictionary<int, EntityKeyValue> crown = new Dictionary<int, EntityKeyValue>();
        Dictionary<int, EntityKeyValue> cball = new Dictionary<int, EntityKeyValue>();

        public void MiscModInit ()
        {
            crown = rom.GetEntityKeyValue(0xfc93);
            cball = rom.GetEntityKeyValue(0xfce3);
            numericUpDown_kkrCrownPal.Value = crown[0x8800].values[0];
            numericUpDown_kkrCrownAnim.Value = crown[0x8100].values[0];
            numericUpDown_kkrCrownY.Value = crown[0x8f00].values[1];
            numericUpDown_kkrCballPal.Value = cball[0x8800].values[0];
            numericUpDown_kkrCballAniim.Value = cball[0x8100].values[0];
            numericUpDown_kkrCannonballY.Value = cball[0x8f00].values[1];


            numericUpDown_miscKkrStartX.Value = rom.Read16(0xb5fc69);
            numericUpDown_miscKkrStartY.Value = rom.Read16(0xb5fc6b);
            numericUpDown_miscKkrLeap.Value = rom.Read16(0xb5fc63);

            const int kkrLeftBounds = 0xb6c9eb;
            const int kkrRightBounds = 0xb6c9f5;
            ushort leftBoundsROM = rom.Read16LDA(kkrLeftBounds);
            ushort rightBoundsROM = rom.Read16LDA(kkrRightBounds);
            if (leftBoundsROM != 0x13e9 && rightBoundsROM != 0x1375)
            {
                numericUpDown_miscLeftBounds.Value = leftBoundsROM;
                numericUpDown_miscRightBounds.Value = rightBoundsROM;
            }

            numericUpDown_miscKkrCrownTurnaround.Value = crown[0xdb9].values[0];

        }

        private void button_applyMisc_Click(object sender, EventArgs e)
        {
            int crownPalAddress = crown[0x8800].address;
            int crownAnimAddress = crown[0x8100].address;
            int crownYAddress = crown[0x8f00].address;
            int cballPalAddress = cball[0x8800].address;
            int cballAnimAddress = cball[0x8100].address;
            int cballYAddress = cball[0x8f00].address;
            rom.Write16(crownPalAddress + 2, (int)numericUpDown_kkrCrownPal.Value);
            rom.Write16(crownAnimAddress + 2, (int)numericUpDown_kkrCrownAnim.Value);
            rom.Write16(crownYAddress + 4, (int)numericUpDown_kkrCrownY.Value);
            rom.Write16(cballPalAddress + 2, (int)numericUpDown_kkrCballPal.Value);
            rom.Write16(cballAnimAddress + 2, (int)numericUpDown_kkrCballAniim.Value);
            rom.Write16(cballYAddress + 4, (int)numericUpDown_kkrCannonballY.Value);

            const int kkrLeftBounds = 0xb6c9eb;
            const int kkrRightBounds = 0xb6c9f5;
            ushort leftBoundsROM = rom.Read16LDA(kkrLeftBounds);
            ushort rightBoundsROM = rom.Read16LDA(kkrRightBounds);
            rom.Write8(kkrLeftBounds, 0xa9);
            rom.Write8(kkrRightBounds, 0xa9);
            rom.Write16LDA(kkrLeftBounds, (int)numericUpDown_miscLeftBounds.Value);
            rom.Write16LDA(kkrRightBounds, (int)numericUpDown_miscRightBounds.Value);

            rom.Write16(0xb5fc69, (int)numericUpDown_miscKkrStartX.Value);
            rom.Write16(0xb5fc6b, (int)numericUpDown_miscKkrStartY.Value);
            rom.Write16(0xb5fc63, (int)numericUpDown_miscKkrLeap.Value);
            var crownDistanceAddress = crown[0xdb9].address;
            rom.Write16(crownDistanceAddress + 2, (int)numericUpDown_miscKkrCrownTurnaround.Value);
            MessageBox.Show("Applied!");
        }

        private void button_kkrCrown_Click(object sender, EventArgs e)
        {
            var crownSelect = SelectEntityWith8100And8800();
            if (crownSelect != null)
            {
                numericUpDown_kkrCrownPal.Value = crownSelect[0x8800].values[0];
                numericUpDown_kkrCrownAnim.Value = crownSelect[0x8100].values[0];
            }
            else
            {
                MessageBox.Show("Not valid");
            }
        }

        private void button_kkrCball_Click(object sender, EventArgs e)
        {
            var cballSelect = SelectEntityWith8100And8800();
            if (cballSelect != null)
            {
                numericUpDown_kkrCballPal.Value = cballSelect[0x8800].values[0];
                numericUpDown_kkrCballAniim.Value = cballSelect[0x8100].values[0];
            }
            else
            {
                MessageBox.Show("Not valid");
            }

        }

        public Dictionary<int, EntityKeyValue> SelectEntityWith8100And8800 ()
        {
            Dictionary<int, EntityKeyValue> @return = null;
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    //numericUpDown_necky1Tire.Value = value;
                    var entity = rom.GetEntityKeyValue(value);
                    bool _8800Index = entity.ContainsKey(0x8800);
                    bool _8100Index = entity.ContainsKey(0x8100);
                    if (_8100Index && _8800Index)
                    {
                        @return = entity;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return @return;
        }
        private void button_restoreCrown_Click(object sender, EventArgs e)
        {
            // 8800 - 8314
            // 8100 - 1ab
            // 14
            numericUpDown_kkrCrownPal.Value = 0x8314;
            numericUpDown_kkrCrownAnim.Value = 0x1ab;
            numericUpDown_kkrCrownY.Value = 0x14;
        }

        private void button_restoreCball_Click(object sender, EventArgs e)
        {
            // 8800 - 829e
            // 8100 - 1b1
            // c0
            numericUpDown_kkrCballPal.Value = 0x829e;
            numericUpDown_kkrCballAniim.Value = 0x1b1;
            numericUpDown_kkrCannonballY.Value = 0xc0;

        }


    }
}
