using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    partial class TextEditor
    {
        string creditText = "";
        List<byte> creditArr = new List<byte>();
        int creditsType = 0;

        private void CreditsInit()
        {
            int start = rom.Read16LDA(rom.CREDITSSTARTLDA[creditsType]) | 0x810000;
            int end = rom.Read16LDA(rom.CREDITSENDLDA[creditsType]) | 0x810000;
            var textArr = rom.ReadSubArray(start, end - start, rom.rom.ToArray());
            creditText = rom.GetCreditTextBlock(textArr);
            creditArr = new List<byte>();
            creditArr.AddRange(textArr);
            creditArr.Add(0);

            richTextBox_credits.Text = creditText;


        }
        private void button_creditsApply_Click(object sender, EventArgs e)
        {

            creditText = richTextBox_credits.Text;
            var arr = rom.GetByteArrayFromCreditTextBlock(creditText);

            if (arr.SequenceEqual(creditArr))
            {

            }
            
            if (arr.Length > rom.CREDITSSIZELIMIT[creditsType])
            {
                MessageBox.Show("Too long.");
                return;
            }

            int start = rom.Read16LDA(rom.CREDITSSTARTLDA[creditsType]) | 0x810000;
            int end = start + arr.Length | 0x810000;

            rom.Write16LDA(rom.CREDITSENDLDA[creditsType], (end & 0xffff) - 1);
            rom.WriteArrToROM(arr, start);

            CreditsInit();
            MessageBox.Show("Done.");
        }

        private void radioButton_real_CheckedChanged(object sender, EventArgs e)
        {
            creditsType = 0;
            CreditsInit();
        }

        private void radioButton_fake_CheckedChanged(object sender, EventArgs e)
        {
            creditsType = 1;
            CreditsInit();
        }

        private void button_export_credits_Click(object sender, EventArgs e)
        {
            var arr = Global.ExportCredits(rom);
            Global.SaveArray(arr.ToArray(), "Credits");
            
        }

        private void button_import_credits_Click(object sender, EventArgs e)
        {
            byte[] arr = Global.LoadArray("Credits");
            if (arr == null)
                return;
            Global.ImportCredits(rom, arr);
            CreditsInit();
            MessageBox.Show("Done");

        }

    }
}