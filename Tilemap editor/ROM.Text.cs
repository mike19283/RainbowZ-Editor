using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class ROM
    {
        public int textStartStage = 0xb8a246;
        public int textEndStage = 0xb8a7e6;
        public bool[] usedSpace_Stage;
        public byte[] GetStringToDKCByteArray(string name)
        {
            List<byte> localList = new List<byte>();
            for (int i = 0; i < name.Length; i++)
            {
                if (i != name.Length - 1)
                {
                    // Cast each char to byte
                    localList.Add((byte)name[i]);
                }
                else
                {
                    byte localByte = (byte)name[i];
                    // Turn on 7th bit
                    localByte |= 0x80;
                    localList.Add(localByte);
                }

            }

            return localList.ToArray();
        }

        public Stage GetStage(byte tempLevelCode)
        {
            /* 
            $B8/9F18 A6 3E       LDX $3E    [$00:003E]   A:00B8 X:0000 Y:0008 P:envmxdIzc
            $B8/9F1A BD 7A A0    LDA $A07A,x[$B8:A090]   A:00B8 X:0016 Y:0008 P:envmxdIzc
            $B8/9F1D 29 FF 00    AND #$00FF              A:0321 X:0016 Y:0008 P:envmxdIzc
            $B8/9F20 0A          ASL A                   A:0021 X:0016 Y:0008 P:envmxdIzc
            $B8/9F21 A8          TAY                     A:0042 X:0016 Y:0008 P:envmxdIzc
            $B8/9F22 B7 4C       LDA [$4C],y[$B8:A224]   A:0042 X:0016 Y:0042 P:envmxdIzc
            $B8/9F24 85 4C       STA $4C    [$00:004C]   A:A6E2 X:0016 Y:0042 P:eNvmxdIzc
            */
            UInt16 temp = Read16(0x38a07a + tempLevelCode);
            temp &= 0xff;
            temp <<= 1;
            int address = 0x38a1e2 + temp;
            UInt16 dkc4c = Read16(address);
            /*
            $B8/9F26 A0 00 00    LDY #$0000              A:A6E2 X:0016 Y:0042 P:eNvmxdIzc
            $B8/9F29 E2 20       SEP #$20                A:A6E2 X:0016 Y:0000 P:envmxdIZc
            $B8/9F2B B7 4C       LDA [$4C],y[$B8:A6E2]   A:A6E2 X:0016 Y:0000 P:envMxdIZc
            $B8/9F2D 30 03       BMI $03    [$9F32]      A:A64A X:0016 Y:0000 P:envMxdIzc
            $B8/9F2F C8          INY                     A:A64A X:0016 Y:0000 P:envMxdIzc
            $B8/9F30 80 F9       BRA $F9    [$9F2B]      A:A64A X:0016 Y:0001 P:envMxdIzc
             */
            String stage = "";
            Int32 currentAddress = 0x380000 + dkc4c + 0;
            int boolIndex = currentAddress - (textStartStage & 0x3fffff);
            // Loop through in 8 bit mode
            do
            {
                stage += Convert.ToChar(rom[currentAddress]);
                usedSpace_Stage[boolIndex++] = true;
                // Increment address
                currentAddress++;
            } while ((rom[currentAddress] & 0x80) == 0);
            stage += (char)(rom[currentAddress] - 0x80);
            usedSpace_Stage[boolIndex++] = true;
            return new Stage(stage,address);
        }

    }
    public class Stage
    {
        public int pointer;
        public string name;
        public Stage(string name, int pointer)
        {
            this.name = name;
            this.pointer = pointer;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
