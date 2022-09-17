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
    public partial class BossEditorr : Form
    {
        private const int GNAWTYX = 0xb5f897;
        private const int GNAWTYHP = 0xb5f89b;
        private const int GNAWTYBOUNDS = 0xb5f8a3;
        private const int GNAWTYINC = 0xb5f89f;

        private const int NECKY1HP = 0xb5faab;
        private const int NECKY1EXTRASHOTS = 0xb5fa97;
        private const int NECKY1SHOTS = 0xb5fa93;
        private const int NECKY1SPEED = 0xb5fa83;
        private const int NECKY1TIRE = 0xb5fB05;
        private const int NECKY1RECOIL = 0xb5fa8b;

        private const int BEEBARRELA = 0xb5fa49;
        private const int BEEBARRELB = 0xb5fa59;
        private const int BEESPEEDINC = 0xb5f9f1;
        private const int BEEBOUNDS = 0xb5f9e5;
        private const int BEESPEED = 0xb5f9ed;
        private const int BEESTUNTIME = 0xb5fa05;
        private const int BEEHRED = 0xb5f9f5;
        private const int BEEVRED = 0xb5f9fd;
        private const int BEEHP = 0xb5fa15;


        private const int DRUMPHASE = 0xb5f91b;
        private const int DRUMHOVER= 0xb5f95B;
        private const int DRUMINITPOUNDS = 0xb5f963;
        private const int DRUMPOUNDINC = 0xb5f967;


        private const int NECKY2HP = 0xb5faf9;
        private const int NECKY2EXTRASHOTS = 0xb5fae5;
        private const int NECKY2SHOTS = 0xb5fae1;
        private const int NECKY2SPEED = 0xb5fad1;
        private const int NECKY2RECOIL = 0xb5fad9;


        ROM rom;
        Form1 form;

        public BossEditorr(ROM rom, Form1 form)
        {
            InitializeComponent();
            this.rom = rom;
            this.form = form;
            // a9 00 00 - always
            // ad 79 05 - og
            // a9 01 00 - never
            var sub = rom.ReadSubArray(rom.DKBARRELONBOSS, 3, rom.rom.ToArray());
            switch (sub[1])
            {
                case 0x00:
                    radioButton_DKBarrelSpawnAlways.Checked = true;
                    break;
                case 0x01:
                    radioButton_DKBarrelSpawnNever.Checked = true;
                    break;
                default:
                    radioButton_DKBarrelSpawnOG.Checked = true;
                    break;
            }

            //f873
            var gnawtyWRAM = rom.ReadScriptWRAM(0xf873);
            numericUpDown_gnawtyX.Value = gnawtyWRAM[0xf25];
            numericUpDown_gnawtyHP.Value = gnawtyWRAM[0x14f9];
            numericUpDown_gnawtyBounds.Value = gnawtyWRAM[0x13e9];
            numericUpDown_gnawtyXSpeedIncrease.Value = gnawtyWRAM[0x0ded];
            // Necky 1
            numericUpDown_necky1HP.Value = rom.Read16(NECKY1HP);
            numericUpDown_necky1Extra.Value = rom.Read16(NECKY1EXTRASHOTS);
            numericUpDown_nkecky1Shots.Value = rom.Read16(NECKY1SHOTS);
            numericUpDown_necky1Speed.Value = rom.Read16(NECKY1SPEED);
            numericUpDown_necky1Recoil.Value = rom.Read16(NECKY1RECOIL);

            int neckyTire = rom.Read16(NECKY1TIRE);
            if (neckyTire > 0xe000 && rom.CheckSignature())
            {
                neckyTire = FindCustomPointer(neckyTire);
            }
            numericUpDown_necky1Tire.Value = neckyTire;

            // Bee

            int beeBarA = rom.Read16(BEEBARRELA);
            int beeBarB = rom.Read16(BEEBARRELB);
            if (beeBarA > 0xe000 && rom.CheckSignature())
            {
                beeBarA = FindCustomPointer(beeBarA);
            }
            if (beeBarB > 0xe000 && rom.CheckSignature())
            {
                beeBarB = FindCustomPointer(beeBarB);
            }
            numericUpDown_beeBarrelA.Value = beeBarA;
            numericUpDown_beeBarrelB.Value = beeBarB;
            numericUpDown_beeSpeedIncrease.Value = rom.Read16(BEESPEEDINC);
            numericUpDown_beeBounds.Value = rom.Read16(BEEBOUNDS);
            numericUpDown_beeSpeed.Value = rom.Read16(BEESPEED);
            numericUpDown_beeStunTime.Value = rom.Read16(BEESTUNTIME);
            numericUpDown_beeHRed.Value = rom.Read16(BEEHRED);
            numericUpDown_beeVRed.Value = rom.Read16(BEEVRED);
            numericUpDown_beeHP.Value = rom.Read16(BEEHP);

            // Drum
            numericUpDown_drumPhase1.Value = rom.Read16(DRUMPHASE + 0);
            numericUpDown_drumPhase2.Value = rom.Read16(DRUMPHASE + 4);
            numericUpDown_drumPhase3.Value = rom.Read16(DRUMPHASE + 8);
            numericUpDown_drumPhase4.Value = rom.Read16(DRUMPHASE + 12);
            numericUpDown_drumPhase5.Value = rom.Read16(DRUMPHASE + 16);
            numericUpDown_drumHover.Value = rom.Read16(DRUMHOVER);
            numericUpDown_drumInitPounds.Value = rom.Read16(DRUMINITPOUNDS);
            numericUpDown_drumPoundsIncrease.Value = rom.Read16(DRUMPOUNDINC);

            // Necky 2
            numericUpDown_necky2HP.Value = rom.Read16(NECKY2HP);
            numericUpDown_necky2ExtraShots.Value = rom.Read16(NECKY2EXTRASHOTS);
            numericUpDown_necky2Shots.Value = rom.Read16(NECKY2SHOTS);
            numericUpDown_necky2Speed.Value = rom.Read16(NECKY2SPEED);
            numericUpDown_necky2Recoil.Value = rom.Read16(NECKY2RECOIL);

        }

        // Gnawty speed b5f897
        private void button_apply_Click(object sender, EventArgs e)
        {
            var beeA = (int)numericUpDown_beeBarrelA.Value;
            var beeB = (int)numericUpDown_beeBarrelB.Value;
            var neckyTire = (int)numericUpDown_necky1Tire.Value;
            bool drum = numericUpDown_drumPhase1.Value < 0x8000 ||
                numericUpDown_drumPhase2.Value < 0x8000 ||
                numericUpDown_drumPhase3.Value < 0x8000 ||
                numericUpDown_drumPhase4.Value < 0x8000 ||
                numericUpDown_drumPhase5.Value < 0x8000;
            if (!rom.CheckSignature() && (beeA != 0x92c5 || beeB != 0x92c5 || drum || neckyTire < 0x8000))
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    form.LoadSch1eyBins();
                }
                else
                {
                    return;
                }
            }

            // a9 00 00 - always
            // ad 79 05 - og
            // a9 01 00 - never
            byte[] sub = new byte[] { 0xa9, 0x00, 0x00 };
            if (radioButton_DKBarrelSpawnAlways.Checked)
            {
                sub = new byte[] { 0xa9, 0x00, 0x00 };
            } else if (radioButton_DKBarrelSpawnNever.Checked)
            {
                sub = new byte[] { 0xa9, 0x01, 0x00 };
            }
            else
            {
                sub = new byte[] { 0xad, 0x79, 0x05 };

            }
            rom.WriteArrToROM(sub, rom.DKBARRELONBOSS);
            // DK barrel
            //rom.Write16(rom.DKBARRELONBOSS, !checkBox_dkbarrel.Checked ? 0x1dd0 : 0xeaea);


            // Gnawty
            rom.Write16(GNAWTYX, (int)numericUpDown_gnawtyX.Value);
            rom.Write16(GNAWTYHP, (int)numericUpDown_gnawtyHP.Value);
            rom.Write16(GNAWTYBOUNDS, (int)numericUpDown_gnawtyBounds.Value);
            rom.Write16(GNAWTYINC, (int)numericUpDown_gnawtyXSpeedIncrease.Value);

            // Necky 1
            rom.Write16(NECKY1HP, (int)numericUpDown_necky1HP.Value);
            rom.Write16(NECKY1EXTRASHOTS, (int)numericUpDown_necky1Extra.Value);
            rom.Write16(NECKY1SHOTS, (int)numericUpDown_nkecky1Shots.Value);
            rom.Write16(NECKY1SPEED, (int)numericUpDown_necky1Speed.Value);
            rom.Write16(NECKY1RECOIL, (int)numericUpDown_necky1Recoil.Value);

            var customNeckyA = rom.Read16(0xbae0a7 + neckyTire * 4);
            rom.Write16(NECKY1TIRE, neckyTire < 0x8000 ? customNeckyA : neckyTire);
            rom.Write16(NECKY1TIRE + 2, (numericUpDown_necky1Tire.Value >= 0x8000 ? 0x0b8d : 0x8000));
            rom.Write16(NECKY1TIRE - 2, (numericUpDown_necky1Tire.Value < 0x8000 ? 0x82ba : 0x8200));

            // Bee
            var customBeeA = rom.Read16(0xbae0a7 + beeA * 4);
            var customBeeB = rom.Read16(0xbae0a7 + beeB * 4);
            rom.Write16(BEEBARRELA, beeA < 0x8000 ? customBeeA : beeA);
            rom.Write16(BEEBARRELB, beeB < 0x8000 ? customBeeB : beeB);
            rom.Write16(BEEBARRELA + 2, (numericUpDown_beeBarrelA.Value == 0x92c5 ? 0x11a1 : 0x8000));
            rom.Write16(BEEBARRELB + 2, (numericUpDown_beeBarrelB.Value == 0x92c5 ? 0x11a1 : 0x8000));
            rom.Write16(BEEBARRELA - 2, (numericUpDown_beeBarrelA.Value < 0x8000 ? 0x82ba : 0x8200));
            rom.Write16(BEEBARRELB - 2, (numericUpDown_beeBarrelB.Value < 0x8000 ? 0x82ba : 0x8200));
            rom.Write16(BEESPEEDINC, (int)numericUpDown_beeSpeedIncrease.Value);
            rom.Write16(BEEBOUNDS, (int)numericUpDown_beeBounds.Value);
            rom.Write16(BEESPEED, (int)numericUpDown_beeSpeed.Value);
            rom.Write16(BEESTUNTIME, (int)numericUpDown_beeStunTime.Value);
            rom.Write16(BEEHRED, (int)numericUpDown_beeHRed.Value);
            rom.Write16(BEEVRED, (int)numericUpDown_beeVRed.Value);
            rom.Write16(BEEHP, (int)numericUpDown_beeHP.Value);

            // Drum
            rom.Write16(DRUMPHASE + 0, (int)numericUpDown_drumPhase1.Value);
            rom.Write16(DRUMPHASE + 4, (int)numericUpDown_drumPhase2.Value);
            rom.Write16(DRUMPHASE + 8, (int)numericUpDown_drumPhase3.Value);
            rom.Write16(DRUMPHASE + 12, (int)numericUpDown_drumPhase4.Value);
            rom.Write16(DRUMPHASE + 16, (int)numericUpDown_drumPhase5.Value);
            rom.Write16(DRUMHOVER, (int)numericUpDown_drumHover.Value);
            rom.Write16(DRUMINITPOUNDS, (int)numericUpDown_drumInitPounds.Value);
            rom.Write16(DRUMPOUNDINC, (int)numericUpDown_drumPoundsIncrease.Value);

            // Necky 2
            rom.Write16(NECKY2HP, (int)numericUpDown_necky2HP.Value);
            rom.Write16(NECKY2EXTRASHOTS, (int)numericUpDown_necky2ExtraShots.Value);
            rom.Write16(NECKY2SHOTS, (int)numericUpDown_necky2Shots.Value);
            rom.Write16(NECKY2SPEED, (int)numericUpDown_necky2Speed.Value);
            rom.Write16(NECKY2RECOIL, (int)numericUpDown_necky2Recoil.Value);

            MessageBox.Show("Applied!");

        }

        private void button_fixdrum_Click(object sender, EventArgs e)
        {
            if (!rom.CheckSignature())
            {
                MessageBox.Show("This applies ASM.", "WARNING");
                if (MessageBox.Show("Continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    form.LoadSch1eyBins();
                    MessageBox.Show("Done.");
                }
            }
            else
            {
                MessageBox.Show("Already fixed.");
            }
        }

        private void button_necky1Tire_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_necky1Tire.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_beeBarrelA_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_beeBarrelA.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_beeBarrelB_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_beeBarrelB.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int FindCustomPointer(int raw)
        {
            int i = 0;
            // bae0a7
            // Read the 32-bit pointer at index i
            var candidate = rom.Read16(0xbae0a7 + i++ * 4);
            do
            {
                if (candidate == raw)
                    // Index incremented before this is checked
                    return i - 1;
                candidate = rom.Read16(0xbae0a7 + i++ * 4);
            } while (candidate != 0);

            return raw;
        }

        private void button_drumPhase1_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_drumPhase1.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_drumPhase2_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_drumPhase2.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button_drumPhase3_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_drumPhase3.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button_drumPhase4_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_drumPhase4.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button_drumPhase5_Click(object sender, EventArgs e)
        {
            try
            {
                Popup pop = new Popup(rom, 0);
                if (pop.ShowDialog() == DialogResult.OK)
                {
                    string select = pop.@object;
                    int index = rom.objectIndexByString[select];
                    int value = rom.objectCodeByIndex[index];
                    numericUpDown_drumPhase5.Value = value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
