using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class TextEditor
    {
        private string[] baseNames = new string[]
        {
            "W1",
            "Jungle Hijinxs",
            "Ropey Rampage",
            "Reptile Rumble",
            "Coral Capers",
            "Barrel Cannon Canyon",
            "Gnawty 1",
            "W2",
            "Winky\'s Walkway",
            "Mine Cart Carnage",
            "Bouncy Bonanza",
            "Stop & Go Station",
            "Millstone Mayhem",
            "Necky 1",
            "W3",
            "Vulture Culture",
            "Tree Top Town",
            "Forest Frenzy",
            "Temple Tempest",
            "Orang-utan Gang",
            "Clam City",
            "Queen Bee",
            "W4",
            "Snow Barrel Blast",
            "Slipslide Ride",
            "Ice Age Alley",
            "Croctopus Chase",
            "Torchlight Trouble",
            "Rope Bridge Rumble",
            "Gnawty 2",
            "W5",
            "Oil Drum Alley",
            "Trick Track Trek",
            "Elevator Antics",
            "Poison Pond",
            "Mine Cart Madness",
            "Blackout Basement",
            "Boss Dumb Drum",
            "W6",
            "Tanked Up Trouble",
            "Manic Mincers",
            "Misty Mine",
            "Loopy Lights",
            "Platform Perils",
            "Necky 2",
            "Gangplank Galleon"

        };
        private int selectedIndex = 0;

        private void StageTextRefresh()
        {
            rom.usedSpace_Stage = new bool[rom.textEndStage - rom.textStartStage];
            listBox_stageBase.Items.Clear();
            listBox_stageCurrent.Items.Clear();
            var stages = baseNames.Select(e => rom.GetStage((byte)rom.levelCodeByString[e])).ToArray();
            listBox_stageCurrent.Items.AddRange(stages);
            listBox_stageBase.Items.AddRange(baseNames);

            listBox_stageBase.SelectedIndex = selectedIndex;
            listBox_stageCurrent.SelectedIndex = selectedIndex;

        }
        private void listBox_stageBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBox_stageBase.SelectedIndex;
            listBox_stageBase.SelectedIndex = selectedIndex;
            listBox_stageCurrent.SelectedIndex = selectedIndex;

        }

        private void listBox_stageCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curr = (Stage)listBox_stageCurrent.SelectedItem;
            textBox_stage.Text = curr.name;

        }
        private int FindNextSlot(string str)
        {
            int address = rom.textStartStage;
            int boolIndex = 0;
            while (address + str.Length < rom.textEndStage)
            {
                if (rom.usedSpace_Stage[boolIndex])
                {
                    address++;
                    boolIndex++;
                } 
                else
                {
                    var arr = rom.usedSpace_Stage.Skip(boolIndex).Take(str.Length).ToArray();
                    if (arr.Any(e => e))
                    {
                        address += str.Length;
                        boolIndex += str.Length;
                    }
                    else
                    {
                        return address;
                    }
                }
            }

            return address;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            var stage = (Stage)listBox_stageCurrent.SelectedItem;
            string str = textBox_stage.Text;
            if (str.Length <= 1)
                return;
            int address = FindNextSlot(str);
            int pointer = address & 0xffff;
            byte[] arr = rom.GetStringToDKCByteArray(str);
            rom.WriteArrToROM(arr, address);
            rom.Write16(stage.pointer, pointer);

            StageTextRefresh();
        }
        private void button_importall_Click(object sender, EventArgs e)
        {
            var arr = Global.LoadArray("Load stage names");
            if (arr != null)
                rom.WriteArrToROM(arr, 0xb8a07a);

            StageTextRefresh();
        }

        private void button_exportall_Click(object sender, EventArgs e)
        {
            int size = 0xb8a7e6 - 0xb8a07a;
            var arr = rom.ReadSubArray(0xb8a07a, size, rom.rom.ToArray());
            Global.SaveArray(arr, "Save stage names");
        }

    }
}
