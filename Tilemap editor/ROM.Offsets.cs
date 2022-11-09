using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        // ARRAYS
        public byte[] COPYRIGHTINIT = new byte[] { 0xa2, 0xe4, 0x00, 0xa9, 0x90, 0x06, 0xa0, 0x00, 0x20, 0x22, 0xad, 0x99, 0xb9 };
        public Dictionary<string, int> musicPointersByString = new Dictionary<string, int>()
        {
            ["Bonus Room Blitz"] = 0x8582,
            ["Bad Boss Boogie"] = 0x8589,
            ["Lost Life"] = 0x86fc,
            ["Jungle Groove"] = 0x8703,
            ["Cave Dweller Concert"] = 0x8908,
            ["Misty Menace"] = 0x89f0,
            ["Aquatic Ambiance"] = 0x8a84,
            ["Northern Hemispheres"] = 0x8b75,
            ["Mine Cart Madness"] = 0x8bc1,
            ["Life in the Mines"] = 0x8c16,
            ["Mine Cart Madness"] = 0x8c59,
            ["Fear Factory"] = 0x8ce8,
            ["Voices of the Temple"] = 0x8d5f,
            ["Ice Cave Chant"] = 0x8dc3,
            ["Treetop Rock"] = 0x8e1b,
            ["Forest Frenzy"] = 0x8e61,
            ["Gang-Plank Galleon"] = 0x8fb4,
            ["Cranky's Theme"] = 0x9015,
            ["The Credits Concerto"] = 0x901c,

            ["Candy's Love Song"] = 0xff65,
            ["Funky's Fugue"] = 0xff6c

        };
        public int[] WORLDCODES = new int[] 
        {
            0xeb,
            0xed,
            0xe9,
            0xe8,
            0xe7,
            0xe6,
            0x68,
        };

        // OFFSETS
        public int ATTRIBUTES = 0x81d102;
        public int CUSTOMATTRIBUTES = 0xbcfb4d;
        public int PERCENTBYSTAGE = 0xbcc288;
        //3983B6 - 398581 | PTR  | level music pointers
        public int MUSICTRACK = 0xb983b6;
        public int ENEMYGROUPKKR = 0x90f6e2;

        public int[] WORLDSTARTSLDA = new int[] 
        {
            0x80e8e9,
        };

        public int[] INTERACTIONS = new int[]
        {
            0xbfb977, // Donkey land
            0xbe9f32, // Donkey jump
        };
        public int[] WORLDTERMINATORS = new int[]
        {
            0xb8846b, 0xb88470, 0xb88475, 0xb8847a, 0xb8847f, 0xb88484,
        };

        public Dictionary<string, int> ENTRANCESTYLESBYSTRING = new Dictionary<string, int>()
        {
            ["nothing"] = 0x86CF,
            ["run to the left"] = 0x8725,
            ["run to the right as Rambi"] = 0x8733,
            ["run to the left as Winky"] = 0x873F,
            ["run to the right as Expresso"] = 0x874B,
            ["start as Enguarde"] = 0x8757,
            ["run to the right"] = 0x877B,
            ["barrel roulette style"] = 0x8810,
            ["walk to the right"] = 0x8818,
            ["start at entrance"] = 0x88E2,
            ["swimming"] = 0x8915,
        };
        public Dictionary<int, string> ENTRANCESTYLEBYCODE = new Dictionary<int, string>()
        {
            [0x86CF] = "nothing",
            [0x8725] = "run to the left",
            [0x8733] = "run to the right as Rambi",
            [0x873F] = "run to the left as Winky",
            [0x874B] = "run to the right as Expresso",
            [0x8757] = "start as Enguarde",
            [0x877B] = "run to the right",
            [0x8810] = "barrel roulette style",
            [0x8818] = "walk to the right",
            [0x88E2] = "start at entrance",
            [0x8915] = "swimming",
        };

        public int COLORMATHBYLEVEL = 0xB9D7AE;
        public int ENTRANCESTYLE = 0xBFFD60;
        public int LEVELCOORDSZ = 0xBCF44B,
                   LEVELCOORDSX = 0xBCF54B,
                   LEVELCOORDSY = 0xBCF64B;
        public int CUSTOMTRACKARRAY = 0x9dec90;
        public int[] CREDITSSIZELIMIT = new int[] { 887, 147 }; //147
        public int[] CREDITSSTARTLDA = new int[] { 0x81d5b6, 0x81eeb1 };
        public int[] CREDITSENDLDA = new int[] { 0x81d5c8, 0x81eebf };
        public int DKBARRELONBOSS = 0xb6ca49;
        public int LOADTRACKINA = 0xb99036;

    }
}
