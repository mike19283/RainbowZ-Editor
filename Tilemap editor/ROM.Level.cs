using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public Dictionary<int, string> levelThemes = new Dictionary<int, string>()
        {
            [0x00] = "Jungles",
            [0x01] = "Caves",
            [0x02] = "Walkways",
            [0x03] = "Mines",
            [0x04] = "Factories",
            [0x05] = "Water Corals",
            [0x06] = "Temples",
            [0x07] = "Snow Glaciers",
            [0x08] = "Crystal Caves",
            [0x09] = "Mine Carts",
            [0x0A] = "Treetowns",
            [0x0B] = "Forests",
            [0x0C] = "Gangplank Galleon",
            [0x0D] = "Boss Lairs",

        };
        public Dictionary<int, int> levelExitObjects = new Dictionary<int, int>()
        {
            [0x16] = 0xE8C7,
            [0xc] = 0xEA25,
            [0x1] = 0xE9DF,
            [0xea] = 0xE9DF,
            [0xbf] = 0xEAB1,
            [0x17] = 0xEA6B,
            [0xd9] = 0xE935,
            [0x2e] = 0xEAC5,
            [0x7] = 0xE953,
            [0x31] = 0xE953,
            [0x42] = 0xEA2F,
            [0xa5] = 0xE9AD,
            [0xa4] = 0xE9AD,
            [0xd0] = 0xE98F,
            [0x43] = 0xEA89,
            [0xd] = 0xEA39,
            [0xde] = 0xEAA7,
            [0x24] = 0xE999,
            [0x6d] = 0xE9CB,
            [0xa7] = 0xE967,
            [0x3e] = 0xEABB,
            [0x14] = 0xE8E5,
            [0xce] = 0xE9FD,
            [0x40] = 0xE93F,
            [0x2f] = 0xE903,
            [0x18] = 0xE903,
            [0x22] = 0xEA9D,
            [0x27] = 0xEA57,
            [0x41] = 0xEA07,
            [0x30] = 0xE8DB,
            [0x12] = 0xE8BD,
            [0xa] = 0xEA61,
            [0x36] = 0xEA7F,
            [0x2b] = 0xE92B,
        };

        public Dictionary<int, int> verticalSpriteCameraStart = new Dictionary<int, int>()
        {
            [0xbf] = 0xf2,
            [0xde] = 0xf17c,
            [0x3e] = 0xa7be,
            [0x22] = 0xa584,
            [0x6d] = 0xd9a0,
        };
        public Dictionary<int, int> verticalCameraStart = new Dictionary<int, int>()
        {
            [0xbf] = 0xf2,
            [0xde] = 0x156,
            [0x3e] = 0x56,
            [0x22] = 0x00,
            [0x6d] = 0x00,
            [0x6d] = 0x00,
            [0xca] = 0x00,
            [0xc5] = 0x00,
            [0xc6] = 0x00,
        };
        public Dictionary<int, int> verticalCameraEnd = new Dictionary<int, int>()
        {
            [0xbf] = 0x122,
            [0xde] = 0x186,
            [0x3e] = 0xdc,
            [0x22] = 0x54,
            [0x6d] = 0x24,
            [0xca] = 0x24,
            [0xc5] = 0x24,
            [0xc6] = 0x24,
        };

        public Dictionary<string, Int32> levelCodeByString = new Dictionary<string, int>()
        {
            ["Jungle Hijinx - Kong's Cabin"] = 0x5c,
            ["Jungle Hijinxs"] = 0x16,
            ["Ropey Rampage"] = 0x0c,
            ["Reptile Rumble"] = 0x01,
            ["Coral Capers"] = 0xbf,
            ["Barrel Cannon Canyon"] = 0x17,
            ["Gnawty 1"] = 0xe0,

            ["Winky's Walkway"] = 0xd9,
            ["Mine Cart Carnage"] = 0x2e,
            ["Bouncy Bonanza"] = 0x07,
            ["Stop & Go Station"] = 0x31,
            ["Millstone Mayhem"] = 0x42,
            ["Necky 1"] = 0xe1,

            ["Vulture Culture"] = 0xa5,
            ["Tree Top Town"] = 0xa4,
            ["Forest Frenzy"] = 0xd0,
            ["Temple Tempest"] = 0x43,
            ["Orang-utan Gang"] = 0x0d,
            ["Clam City"] = 0xde,
            ["Queen Bee"] = 0xe5,

            ["Snow Barrel Blast"] = 0x24,
            ["Slipslide Ride"] = 0x6d,
            ["Ice Age Alley"] = 0xa7,
            ["Croctopus Chase"] = 0x3e,
            ["Torchlight Trouble"] = 0x14,
            ["Rope Bridge Rumble"] = 0xce,
            ["Gnawty 2"] = 0xe2,

            ["Oil Drum Alley"] = 0x40,
            ["Trick Track Trek"] = 0x2f,
            ["Elevator Antics"] = 0x18,
            ["Poison Pond"] = 0x22,
            ["Mine Cart Madness"] = 0x27,
            ["Blackout Basement"] = 0x41,
            ["Boss Dumb Drum"] = 0xe3,

            ["Tanked Up Trouble"] = 0x30,
            ["Manic Mincers"] = 0x12,
            ["Misty Mine"] = 0x0a,
            ["Loopy Lights"] = 0x36,
            ["Platform Perils"] = 0x2b,
            ["Necky 2"] = 0xe4,

            ["Gangplank Galleon"] = 0x68,

            ["W1"] = 0xec,
            ["W2"] = 0xed,
            ["W3"] = 0xe9,
            ["W4"] = 0xe8,
            ["W5"] = 0xe7,
            ["W6"] = 0xe6,

            ["Jungle Hijinxs (Bonus 1)"] = 0x6,
            ["Jungle Hijinxs (Bonus 2)"] = 0x1a,

            ["Jungle BG2"] = 0xf0,
            ["Cave BG2"] = 0xf1,
            ["Glaciers BG2"] = 0xf2,
        };
        public Dictionary<int, int> layersByCode = new Dictionary<int, int>()
        {
            [0xbf] = 3,
            [0xde] = 3,
            [0x6d] = 4,
            [0x3e] = 5,
            [0x22] = 5,
        };
        public Dictionary<int, int> layerMapOffset = new Dictionary<int, int>()
        {
            [0xbf] = 0xbde5fa,
            [0xde] = 0xbdf17c,
            [0x6d] = 0xbdd9a0,
            [0x3e] = 0xbda7be,
            [0x22] = 0xbda584,
        };
        public Dictionary<string, int> tilesetIndexByStage = new Dictionary<string, int>()
        {
            ["Banana hoard"] = 0x1b,
            ["Jungle Hijinxs"] = 0x1,
            ["Ropey Rampage"] = 0x1,
            ["Reptile Rumble"] = 0x2,
            ["Coral Capers"] = 0x7,
            ["Barrel Cannon Canyon"] = 0x1,
            ["Gnawty 1"] = 0x1a,

            ["Winky's Walkway"] = 0x9,
            ["Mine Cart Carnage"] = 0xa,
            ["Bouncy Bonanza"] = 0x2,
            ["Stop & Go Station"] = 0xc,
            ["Millstone Mayhem"] = 0xff,
            ["Necky 1"] = 0x1a,

            ["Vulture Culture"] = 0x13,
            ["Tree Top Town"] = 0x12,
            ["Forest Frenzy"] = 0x13,
            ["Temple Tempest"] = 0xff,
            ["Orang-utan Gang"] = 0x1,
            ["Clam City"] = 0x7,
            ["Queen Bee"] = 0x1a,

            ["Snow Barrel Blast"] = 0x8,
            ["Slipslide Ride"] = 0xf,
            ["Ice Age Alley"] = 0x8,
            ["Croctopus Chase"] = 0x7,
            ["Torchlight Trouble"] = 0x2,
            ["Rope Bridge Rumble"] = 0x12,
            ["Gnawty 2"] = 0x1a,

            ["Oil Drum Alley"] = 0xd,
            ["Trick Track Trek"] = 0x9,
            ["Elevator Antics"] = 0x2,
            ["Poison Pond"] = 0x7,
            //["Mine Cart Madness"] = 0xa,
            ["Mine Cart Madness"] = 0x9,
            ["Blackout Basement"] = 0xd,
            ["Boss Dumb Drum"] = 0x1a,

            ["Tanked Up Trouble"] = 0x9,
            ["Manic Mincers"] = 0x2,
            ["Misty Mine"] = 0x5,
            ["Loopy Lights"] = 0xc,
            ["Platform Perils"] = 0x9,
            ["Necky 2"] = 0x1a,

            ["Gangplank Galleon"] = 0xf0,

            ["Jungle Hijinxs (Bonus 1)"] = 0x2,
            ["Jungle Hijinxs (Bonus 2)"] = 0x1,
        };
        public Dictionary<string, int> headerIndex = new Dictionary<string, int>()
        {
            ["Jungle Hijinxs"] = 0x00,
            ["Ropey Rampage"] = 0x00,
            ["Reptile Rumble"] = 0x01,
            ["Coral Capers"] = 0x5,
            ["Barrel Cannon Canyon"] = 0x0,
            ["Gnawty 1"] = 0x0d,

            ["Winky's Walkway"] = 0x2,
            ["Mine Cart Carnage"] = 0x9,
            ["Bouncy Bonanza"] = 0x01,
            ["Stop & Go Station"] = 0x3,
            ["Millstone Mayhem"] = 0x6,
            ["Necky 1"] = 0x0d,

            ["Vulture Culture"] = 0xb,
            ["Tree Top Town"] = 0xa,
            ["Forest Frenzy"] = 0xb,
            ["Temple Tempest"] = 0x6,
            ["Orang-utan Gang"] = 0x00,
            ["Clam City"] = 0x5,
            ["Queen Bee"] = 0x0d,

            ["Snow Barrel Blast"] = 0x7,
            ["Slipslide Ride"] = 0x08,
            ["Ice Age Alley"] = 0x7,
            ["Croctopus Chase"] = 0x5,
            ["Torchlight Trouble"] = 0x1,
            ["Rope Bridge Rumble"] = 0xa,
            ["Gnawty 2"] = 0x0d,

            ["Oil Drum Alley"] = 0x4,
            ["Trick Track Trek"] = 0x2,
            ["Elevator Antics"] = 0x1,
            ["Poison Pond"] = 0x5,
            //["Mine Cart Madness"] = 0x9,
            ["Mine Cart Madness"] = 0x2,
            ["Blackout Basement"] = 0x4,
            ["Boss Dumb Drum"] = 0x0d,

            ["Tanked Up Trouble"] = 0x2,
            ["Manic Mincers"] = 0x1,
            ["Misty Mine"] = 0x3,
            ["Loopy Lights"] = 0x3,
            ["Platform Perils"] = 0x2,
            ["Necky 2"] = 0x0d,

            ["Gangplank Galleon"] = 0xc,

            ["Jungle Hijinxs (Bonus 1)"] = 0x01,
            ["Jungle Hijinxs (Bonus 2)"] = 0x00,
        };
        public Dictionary<string, int> paletteOffset = new Dictionary<string, int>()
        {
            ["Jungle Hijinxs"] = 0xb9a1dc,
            ["Oil Drum Alley"] = 0xb9b0a3,

            ["Ropey Rampage"] = 0xb9a1dc,
            //["Ropey Rampage"] = 0x45a1dc,
            ["Reptile Rumble"] = 0xb9a01c,
            ["Coral Capers"] = 0x399c1c,
            ["Barrel Cannon Canyon"] = 0xb9a1dc,
            ["Gnawty 1"] = 0x39CE63,

            ["Winky's Walkway"] = 0xb9a2dc,
            ["Mine Cart Carnage"] = 0xb99a14,
            ["Bouncy Bonanza"] = 0xb9ad65,
            ["Stop & Go Station"] = 0xb9a3dc,
            ["Millstone Mayhem"] = 0xb9b3a3,
            ["Necky 1"] = 0x39CE63,

            ["Vulture Culture"] = 0xb9c623,
            ["Tree Top Town"] = 0xb9b2a3,
            ["Forest Frenzy"] = 0xb9c623,
            ["Temple Tempest"] = 0xb9b3a3,
            ["Orang-utan Gang"] = 0xb9a1dc,
            ["Clam City"] = 0xb99c1c,
            ["Queen Bee"] = 0x39CE63,

            ["Snow Barrel Blast"] = 0xb99b1c,
            ["Slipslide Ride"] = 0xb9c723,
            ["Ice Age Alley"] = 0xb99b1c,
            ["Croctopus Chase"] = 0xb99d1c,
            ["Torchlight Trouble"] = 0xb9a01c,
            ["Rope Bridge Rumble"] = 0xb9b1a3,
            ["Gnawty 2"] = 0x39CE63,

            ["Oil Drum Alley"] = 0xb9b0a3,
            ["Trick Track Trek"] = 0xb9a2dc,
            ["Elevator Antics"] = 0xb9a01c,
            ["Poison Pond"] = 0xb99f1c,
            //["Mine Cart Madness"] = 0xb99a14,
            ["Mine Cart Madness"] = 0xb9a2dc,
            ["Blackout Basement"] = 0xb9b0a3,
            ["Boss Dumb Drum"] = 0x39CE63,

            ["Tanked Up Trouble"] = 0xb9a2dc,
            ["Manic Mincers"] = 0xb9ae65,
            ["Misty Mine"] = 0xb9a3dc,
            ["Loopy Lights"] = 0xb9a3dc,
            ["Platform Perils"] = 0xb9a2dc,
            ["Necky 2"] = 0x39CE63,

            ["Gangplank Galleon"] = 0x39D363,


            ["Jungle Hijinxs (Bonus 1)"] = 0xb9ad65,
            ["Jungle Hijinxs (Bonus 2)"] = 0xb9a1dc,
        };
        public Dictionary<int, int> metatilesetSize = new Dictionary<int, int>()
        {
            [0x0] = 0x24a,
            [0x4] = 0xd5,

            [0x01] = 0x01B4,
            [0x02] = 0x00FE,
            [0x03] = 0x015C,
            [0x05] = 0x023B,
            [0x06] = 0x0123,
            //[0x06] = 0x0246,
            [0x07] = 0x0182,
            [0x08] = 0x0189,
            [0x09] = 0x00E6,
            [0x0A] = 0x0080,
            [0x0B] = 0x0185,
            [0x0C] = 0x007C,
            [0x0D] = 0x007A,

        };
        public Dictionary<string, List<string>> levelsInTheme = new Dictionary<string, List<string>>()
        {
            ["Jungle Hijinxs"] = new List<string>() { "Jungle Hijinxs", "Ropey Rampage", "Barrel Cannon Canyon", "Orang-utan Gang" },

        };

        public Dictionary<string, int> allTilemapSizes = new Dictionary<string, int>()
        {
            ["Jungle Hijinxs"] = 0x1500,
            ["Ropey Rampage"] = 0x2080,
            //["Ropey Rampage"] = 0x2000,
            ["Reptile Rumble"] = 0x1a00,
            ["Coral Capers"] = 0x1d00,
            ["Gnawty 1"] = 0x200,

            ["Winky's Walkway"] = 0x13b0,
            ["Mine Cart Carnage"] = 0x4900,
            ["Bouncy Bonanza"] = 0x2480,
            ["Stop & Go Station"] = 0x2680,
            ["Millstone Mayhem"] = 0x2c00,
            ["Necky 1"] = 0x200,

            ["Vulture Culture"] = 0x2a00,
            ["Tree Top Town"] = 0x2900,
            ["Forest Frenzy"] = 0x2900,
            ["Temple Tempest"] = 0x3200,
            ["Orang-utan Gang"] = 0x25e0,
            ["Clam City"] = 0x1980,
            ["Queen Bee"] = 0x200,

            ["Snow Barrel Blast"] = 0x36e0,
            ["Slipslide Ride"] = 0x2e00,
            ["Ice Age Alley"] = 0x29a0,
            ["Croctopus Chase"] = 0x4400,
            ["Torchlight Trouble"] = 0x1500,
            ["Rope Bridge Rumble"] = 0x2300,
            ["Gnawty 2"] = 0x200,

            ["Oil Drum Alley"] = 0x2d60,
            ["Trick Track Trek"] = 0x2e00,
            ["Elevator Antics"] = 0x2900,
            ["Poison Pond"] = 0x3080,
            ["Mine Cart Madness"] = 0x3a00,
            ["Blackout Basement"] = 0x2900,
            ["Boss Dumb Drum"] = 0x200,

            ["Tanked Up Trouble"] = 0x3000,
            ["Manic Mincers"] = 0x2880,
            ["Misty Mine"] = 0x3180,
            ["Loopy Lights"] = 0x2f00,
            ["Platform Perils"] = 0x3080,
            ["Necky 2"] = 0x200,

            ["Gangplank Galleon"] = 0x200,

            ["Jungle Hijinxs (Bonus 1)"] = 0x400,
            ["Jungle Hijinxs (Bonus 2)"] = 0x100,
        };
        public Dictionary<string, int> allTilemapOffsets = new Dictionary<string, int>()
        {
            // Vertical not 100% accurate
            ["Jungle Hijinxs"] = 0xd90000,
            ["Ropey Rampage"] = 0xd91700,
            //["Ropey Rampage"] = 0x450000,
            ["Reptile Rumble"] = 0xda0100,
            ["Coral Capers"] = 0xe98c00,
            ["Barrel Cannon Canyon"] = 0xd96360,
            ["Gnawty 1"] = 0x03EDA0,

            ["Winky's Walkway"] = 0xcbcc80,
            ["Mine Cart Carnage"] = 0xe60d88,
            ["Bouncy Bonanza"] = 0xda1b00,
            ["Stop & Go Station"] = 0xdb3a4c,
            ["Millstone Mayhem"] = 0xec1f28,
            ["Necky 1"] = 0x03EDA0,

            ["Vulture Culture"] = 0xc36400,
            ["Tree Top Town"] = 0xc30000,
            ["Forest Frenzy"] = 0xc39200,
            ["Temple Tempest"] = 0xec4b28,
            ["Orang-utan Gang"] = 0xd93780,
            ["Clam City"] = 0xe9aa00,
            ["Queen Bee"] = 0x03EDA0,

            ["Snow Barrel Blast"] = 0xe03836,
            ["Slipslide Ride"] = 0xe105e5,
            ["Ice Age Alley"] = 0xe07836,
            ["Croctopus Chase"] = 0xe93080,
            ["Torchlight Trouble"] = 0xda7100,
            ["Rope Bridge Rumble"] = 0xc32b00,
            ["Gnawty 2"] = 0x03EDA0,

            ["Oil Drum Alley"] = 0xe20200,
            ["Trick Track Trek"] = 0xcb6b80,
            ["Elevator Antics"] = 0xda8600,
            ["Poison Pond"] = 0xe90000,
            ["Mine Cart Madness"] = 0xcb0000,
            ["Blackout Basement"] = 0xe22f60,
            ["Boss Dumb Drum"] = 0x03EDA0,

            ["Tanked Up Trouble"] = 0xcb9980,
            ["Manic Mincers"] = 0xda4080,
            ["Misty Mine"] = 0xdb08cc,
            ["Loopy Lights"] = 0xdb67cc,
            ["Platform Perils"] = 0xcb3b00,
            ["Necky 2"] = 0x03EDA0,

            ["Gangplank Galleon"] = 0xe30000,

            ["Jungle Hijinxs (Bonus 1)"] = 0xda6900,
            ["Jungle Hijinxs (Bonus 2)"] = 0xd95d60,
        };
        public Dictionary<int, string> levelNameByCode = new Dictionary<int, string>()
        {
            [0x0] = "NULL",
            [0x1] = "Reptile Rumble (level start)",
            [0x2] = "Reptile Rumble - Bonus 1",
            [0x3] = "Bouncy Bonanza - Winky Room",
            [0x4] = "Reptile Rumble - Bonus 3",
            [0x5] = "Manic Mincers - Bonus 1",
            [0x6] = "Jungle Hijinxs - Bonus 1",
            [0x7] = "Bouncy Bonanza (level start)",
            [0x8] = "Jungle Hijinxs (from Bonus 1)",
            [0x9] = "Reptile Rumble (from Bonus 1)",
            [0xa] = "Misty Mine (level start)",
            [0xb] = "Reptile Rumble (from Bonus 3)",
            [0xc] = "Ropey Rampage (level start)",
            [0xd] = "Orang-utan Gang (level start)",
            [0xe] = "Jungle Hijinxs (from house)",
            [0xf] = "Ropey Rampage (from Save)",
            [0x10] = "Bouncy Bonanza (from Winky Room)",
            [0x11] = "Bouncy Bonanza - Bonus 2",
            [0x12] = "Manic Mincers (level start)",
            [0x13] = "Torchlight Trouble (from Save)",
            [0x14] = "Torchlight Trouble (level start)",
            [0x15] = "Bouncy Bonanza (from Save)",
            [0x16] = "Jungle Hijinxs (level start)",
            [0x17] = "Barrel Cannon Canyon (level start)",
            [0x18] = "Elevator Antics (level start)",
            [0x19] = "Barrel Cannon Canyon (from Save)",
            [0x1a] = "Jungle Hijinxs - Bonus 2",
            [0x1b] = "Ropey Rampage - Bonus 2",
            [0x1c] = "Ropey Rampage - Bonus 1",
            [0x1d] = "Orang-utan Gang (from Save)",
            [0x1e] = "Orang-utan Gang - Bonus 3",
            [0x1f] = "Orang-utan Gang - Bonus 2",
            [0x20] = "Orang-utan Gang - Bonus 1",
            [0x21] = " empty jungle room + boss music???",
            [0x22] = "Poison Pond (level start)",
            [0x23] = "Elevator Antics (from Save)",
            [0x24] = "Snow Barrel Blast (level start)",
            [0x25] = "Jungle Hijinxs (from Save)",
            [0x26] = "Reptile Rumble (from Save)",
            [0x27] = "Mine Cart Madness (level start)",
            [0x28] = "Snow Barrel Blast (from Save)",
            [0x29] = "Manic Mincers (from Save)",
            [0x2a] = "Poison Pond (from Save)",
            [0x2b] = "Platform Perils (level start)",
            [0x2c] = "Platform Perils (from Save)",
            [0x2d] = "Misty Mine (from Save)",
            [0x2e] = "Mine Cart Carnage (level start)",
            [0x2f] = "Trick Track Trek (level start)",
            [0x30] = "Tanked Up Trouble (level start)",
            [0x31] = "Stop & Go Station (level start)",
            [0x32] = "Misty Mine - Bonus 2",
            [0x33] = "Misty Mine - Bonus 1",
            [0x34] = "Animal Token Room",
            [0x35] = "Millstone Mayhem (from warp)",
            [0x36] = "Loopy Lights (level start)",
            [0x37] = "Loopy Lights - Bonus 2",
            [0x38] = "Mine Cart Carnage (from Save)",
            [0x39] = "Trick Track Trek (from Save)",
            [0x3a] = "Tanked Up Trouble (from Save)",
            [0x3b] = "Mine Cart Madness (from Save)",
            [0x3c] = "Stop & Go Station (from Save)",
            [0x3d] = "Loopy Lights (from Save)",
            [0x3e] = "Croctopus Chase (level start)",
            [0x3f] = "Croctopus Chase (from Save)",
            [0x40] = "Oil Drum Alley (level start)",
            [0x41] = "Blackout Basement (level start)",
            [0x42] = "Millstone Mayhem (level start)",
            [0x43] = "Temple Tempest (level start)",
            [0x44] = "Oil Drum Alley (from Save)",
            [0x45] = "Blackout Basement (from Save)",
            [0x46] = "Barrel Cannon Canyon - Bonus 1",
            [0x47] = "Kong's Banana Hoard (empty)",
            [0x48] = "Reptile Rumble - Bonus 2",
            [0x49] = "Loopy Lights - Bonus 1",
            [0x4a] = "Stop & Go Station - Bonus 2",
            [0x4b] = "Stop & Go Station - Bonus 1",
            [0x4c] = "Kong's Banana Hoard (full)",
            [0x4d] = "Mine Cart Madness - Bonus 1",
            [0x4e] = "Platform Perils - Bonus 1",
            [0x4f] = "Winky's Walkway - Bonus 1",
            [0x50] = "Platform Perils - Bonus 2",
            [0x51] = "Winky's Walkway (from Bonus 1)",
            [0x52] = "Temple Tempest - Bonus 1",
            [0x53] = "Temple Tempest - Bonus 2",
            [0x54] = "Tree Top Town (warp)",
            [0x55] = "Millstone Mayhem - Bonus 1",
            [0x56] = "Millstone Mayhem - Bonus 2",
            [0x57] = "Millstone Mayhem - Bonus 3",
            [0x58] = "Millstone Mayhem (from Save)",
            [0x59] = "Temple Tempest (from Save)",
            [0x5a] = "Orang-utan Gang - Bonus 5",
            [0x5b] = "Orang-utan Gang - Bonus 4",
            [0x5c] = "Kong's Cabin",
            [0x5d] = "Barrel Cannon Canyon - Bonus 2",
            [0x5e] = "Credits",
            [0x5f] = "Jungle Hijinxs (from Kong's Banana Hoard)",
            [0x60] = "Oil Drum Alley - Bonus 4",
            [0x61] = "Oil Drum Alley - Bonus 2",
            [0x62] = "Slipslide Ride (warp)",
            [0x63] = "Oil Drum Alley - Bonus 1",
            [0x64] = "Blackout Basement - Bonus 1",
            [0x65] = "Vulture Culture (warp)",
            [0x66] = "Snow Barrel Blast - Bonus 3",
            [0x67] = "Snow Barrel Blast - Bonus 1",
            [0x68] = "Gangplank Galleon",
            [0x69] = "Snow Barrel Blast - Bonus 2",
            [0x6a] = "Ice Age Alley - Bonus 1",
            [0x6b] = "Ice Age Alley - Bonus 2",
            [0x6c] = "Expresso Bonus",
            [0x6d] = "Slipslide Ride (level start)",
            [0x6e] = "Jungle Hijinxs (from Bonus 2)",
            [0x6f] = "Ropey Rampage (from Bonus 1)",
            [0x70] = "Ropey Rampage (from Bonus 2)",
            [0x71] = "Orang-utan Gang (from Bonus 4)",
            [0x72] = "Orang-utan Gang (from Bonus 2)",
            [0x73] = "Orang-utan Gang (from Bonus 1)",
            [0x74] = "Orang-utan Gang (from Bonus 3)",
            [0x75] = "Orang-utan Gang (from Bonus 5)",
            [0x76] = "Barrel Cannon Canyon (from Bonus 1)",
            [0x77] = "Barrel Cannon Canyon (from Bonus 2)",
            [0x78] = "Bouncy Bonanza (from Bonus 1)",
            [0x79] = "Bouncy Bonanza (from Bonus 2)",
            [0x7a] = "Manic Mincers (from Bonus 1)",
            [0x7b] = "Manic Mincers (from Ledge Room)",
            [0x7c] = "Manic Mincers (from Bonus 2)",
            [0x7d] = "Elevator Antics (from Bonus 1)",
            [0x7e] = "Elevator Antics (from Bonus 2)",
            [0x7f] = "Elevator Antics (from Bonus 3)",
            [0x80] = "Misty Mine (from Bonus 1)",
            [0x81] = "Misty Mine (from Bonus 2)",
            [0x82] = "Stop & Go Station (from Bonus 1)",
            [0x83] = "Stop & Go Station (from Bonus 2)",
            [0x84] = "Loopy Lights (from Bonus 1)",
            [0x85] = "Loopy Lights (from Bonus 2)",
            [0x86] = "Platform Perils (from Bonus 1)",
            [0x87] = "Platform Perils (from Bonus 2)",
            [0x88] = "Trick Track Trek (from Bonus 1)",
            [0x89] = "Trick Track Trek (from Bonus 3)",
            [0x8a] = "Trick Track Trek (from Bonus 2)",
            [0x8b] = "Tanked Up Trouble (from Bonus 1)",
            [0x8c] = "Mine Cart Madness (from Bonus 1)",
            [0x8d] = "Mine Cart Madness (from Bonus 2)",
            [0x8e] = "Mine Cart Madness (from Bonus 3)",
            [0x8f] = "Oil Drum Alley (from Bonus 1)",
            [0x90] = "Oil Drum Alley (from Bonus 2/3)",
            [0x91] = "Oil Drum Alley (from Bonus 4)",
            [0x92] = "Blackout Basement (from Bonus 1)",
            [0x93] = "Blackout Basement (from Bonus 2)",
            [0x94] = "Snow Barrel Blast (from Bonus 1)",
            [0x95] = "Snow Barrel Blast (from Bonus 2)",
            [0x96] = "Snow Barrel Blast (from Bonus 3)",
            [0x97] = "Bouncy Bonanza - Bonus 1",
            [0x98] = "Manic Mincers - Bonus 2",
            [0x99] = "Manic Mincers - Ledge Room",
            [0x9a] = "Elevator Antics - Bonus 1",
            [0x9b] = "Elevator Antics - Bonus 2",
            [0x9c] = "Elevator Antics - Bonus 3",
            [0x9d] = "Trick Track Trek - Bonus 3",
            [0x9e] = "Trick Track Trek - Bonus 2",
            [0x9f] = "Tanked Up Trouble - Bonus 1",
            [0xa0] = "Mine Cart Madness - Bonus 2",
            [0xa1] = "Trick Track Trek - Bonus 1",
            [0xa2] = "Mine Cart Madness - Bonus 3",
            [0xa3] = "Blackout Basement - Bonus 2",
            [0xa4] = "Tree Top Town (level start)",
            [0xa5] = "Vulture Culture (level start)",
            [0xa6] = "Enguarde Bonus",
            [0xa7] = "Ice Age Alley (level start)",
            [0xa8] = "Ice Age Alley (from Save)",
            [0xa9] = "Tree Top Town (from Save)",
            [0xaa] = "Vulture Culture (from Save)",
            [0xab] = "Slipslide Ride (from Save)",
            [0xac] = "Ice Age Alley (from Bonus 1)",
            [0xad] = "Ice Age Alley (from Bonus 2)",
            [0xae] = "Millstone Mayhem (from Bonus 1)",
            [0xaf] = "Millstone Mayhem (from Bonus 2)",
            [0xb0] = "Millstone Mayhem (from Bonus 3)",
            [0xb1] = "Temple Tempest (from Bonus 1)",
            [0xb2] = "Temple Tempest (from Bonus 2)",
            [0xb3] = "Tree Top Town - Bonus 2",
            [0xb4] = "Tree Top Town - Bonus 1",
            [0xb5] = "Tree Top Town (from Bonus 1)",
            [0xb6] = "Tree Top Town (from Bonus 2)",
            [0xb7] = "Vulture Culture - Bonus 1",
            [0xb8] = "Vulture Culture - Bonus 2",
            [0xb9] = "Vulture Culture - Bonus 3",
            [0xba] = "Vulture Culture (from Bonus 1)",
            [0xbb] = "Vulture Culture (from Bonus 2)",
            [0xbc] = "Vulture Culture (from Bonus 3)",
            [0xbd] = "Trick Track Trek (warp)",
            [0xbe] = "Oil Drum Alley - Bonus 3",
            [0xbf] = "Coral Capers (level start)",
            [0xc0] = "Coral Capers (from Save)",
            [0xc1] = "Torchlight Trouble - Bonus 1",
            [0xc2] = "Torchlight Trouble (from Bonus 1)",
            [0xc3] = "Torchlight Trouble - Bonus 2",
            [0xc4] = "Torchlight Trouble (from Bonus 2)",
            [0xc5] = "Slipslide Ride - Bonus 2",
            [0xc6] = "Slipslide Ride - Bonus 3",
            [0xc7] = "Slipslide Ride (from Bonus 1)",
            [0xc8] = "Slipslide Ride (from Bonus 2)",
            [0xc9] = "Reptile Rumble (from Bonus 2)",
            [0xca] = "Slipslide Ride - Bonus 1",
            [0xcb] = "Slipslide Ride (from Bonus 3)",
            [0xcc] = "Mine Cart Carnage (warp)",
            [0xcd] = "Stop & Go Station (warp)",
            [0xce] = "Rope Bridge Rumble (level start)",
            [0xcf] = "Rope Bridge Rumble (from Save)",
            [0xd0] = "Forest Frenzy (level start)",
            [0xd1] = "Forest Frenzy (from Save)",
            [0xd2] = "Rambi Bonus",
            [0xd3] = "Winky Bonus",
            [0xd4] = "Forest Frenzy - Bonus 2",
            [0xd5] = "Rope Bridge Rumble - Bonus 1",
            [0xd6] = "Rope Bridge Rumble (from Bonus 2)",
            [0xd7] = "Rope Bridge Rumble - Bonus 2",
            [0xd8] = "Rope Bridge Rumble (from Bonus 1)",
            [0xd9] = "Winky's Walkway (level start)",
            [0xda] = "Winky's Walkway (from Save)",
            [0xdb] = "Forest Frenzy (from Bonus 2)",
            [0xdc] = "Forest Frenzy - Bonus 1",
            [0xdd] = "Forest Frenzy (from Bonus 1)",
            [0xde] = "Clam City (level start)",
            [0xdf] = "Clam City (from Save)",
            [0xe0] = "Very Gnawty's Lair",
            [0xe1] = "Necky's Nuts",
            [0xe2] = "Really Gnawty Rampage",
            [0xe3] = "Boss Dumb Drum",
            [0xe4] = "Necky's Revenge",
            [0xe5] = "Bumble B Rumble"
        };

        public Dictionary<int, bool> isBonus = new Dictionary<int, bool>()
        {
            [0x6] = true,
            [0x1a] = true,

        };

        public void AddToLevelFunc(string lvl, int palette, int tilemapStart, int tilemapSize, int tilemapIndex, int headerIndex1, int code)
        {
            paletteOffset[lvl] = palette;
            allTilemapOffsets[lvl] = tilemapStart;
            allTilemapSizes[lvl] = tilemapSize;
            levelCodeByString[lvl] = code;
            tilesetIndexByStage[lvl] = tilemapIndex;
            headerIndex[lvl] = headerIndex1;
            isBonus[code] = true;
        }
        public void AddToLevelFunc(string lvl, int palette, int tilemapIndex, int headerIndex1, int code)
        {
            paletteOffset[lvl] = palette;
            levelCodeByString[lvl] = code;
            tilesetIndexByStage[lvl] = tilemapIndex;
            headerIndex[lvl] = headerIndex1;
            isBonus[code] = true;
        }
        // lvl, pal, tmStart, tmSize, tmIndex, headerIndex1, code
        // lvl, pal, tmIndex, headerIndex1, code
        public void AddToLevel()
        {
            // Add bonuses
            AddToLevelFunc("Ropey Rampage - Bonus 1", 0xb9a1dc, 0xd95f60, 0x400, 1, 0, 0x1c);
            AddToLevelFunc("Ropey Rampage - Bonus 2", 0xb9a1dc, 0xd95d60, 0x100, 1, 0, 0x1b);
            AddToLevelFunc("Reptile Rumble - Bonus 1", 0xb9a01c, 0xda6900, 0x300, 2, 1, 0x2);
            AddToLevelFunc("Reptile Rumble - Bonus 3", 0xb9a01c, 0xda6d00, 0x200, 2, 1, 0x4);
            AddToLevelFunc("Reptile Rumble - Bonus 2", 0xb9a01c, 0xdab300, 0x200, 2, 1, 0x48);
            AddToLevelFunc("Barrel Cannon Canyon - Bonus 1", 0xb9a01c, 0xdaaf00, 0x400, 2, 1, 0x46);
            AddToLevelFunc("Barrel Cannon Canyon - Bonus 2", 0xb9a1dc, 0xd98f60, 0x100, 1, 0, 0x5d);

            AddToLevelFunc("Winky\'s Walkway - Bonus 1", 0xb9a2dc, 9, 2, 0x4f);
            AddToLevelFunc("Bouncy Bonanza - Bonus 1", 0xb9ad65, 2, 1, 0x97);
            AddToLevelFunc("Bouncy Bonanza - Bonus 2", 0xb9ad65, 2, 1, 0x11);
            AddToLevelFunc("Bouncy Bonanza - Winky Room", 0xb9ad65, 2, 1, 0x3);
            AddToLevelFunc("Stop & Go Station - Bonus 1", 0xb9a3dc, 0xdb06cc, 0x200, 0x5, 3, 0x4b);
            AddToLevelFunc("Stop & Go Station - Bonus 2", 0xb9a3dc, 0xdb05cc, 0x100, 0x5, 3, 0x4a);
            AddToLevelFunc("Millstone Mayhem - Bonus 1", 0xb9b3a3, 0xec7d28, 0x100, 0xff, 6, 0x55);
            AddToLevelFunc("Millstone Mayhem - Bonus 2", 0xb9b3a3, 0xec1728, 0x100, 0xff, 6, 0x56);
            AddToLevelFunc("Millstone Mayhem - Bonus 3", 0xb9b3a3, 0xec1728, 0x100, 0xff, 6, 0x57);

            AddToLevelFunc("Vulture Culture - Bonus 1", 0xb9c623, 0xc38dfe, 0x100, 0x13, 0xb, 0xb7);
            AddToLevelFunc("Vulture Culture - Bonus 2", 0xb9c623, 0xc38dfe, 0x100, 0x13, 0xb, 0xb8);
            AddToLevelFunc("Vulture Culture - Bonus 3", 0xb9c623, 0xc38dfe, 0x400, 0x13, 0xb, 0xb9);
            AddToLevelFunc("Tree Top Town - Bonus 1", 0xb9b2a3, 0x12, 0xa, 0xb4);
            AddToLevelFunc("Tree Top Town - Bonus 2", 0xb9b2a3, 0x12, 0xa, 0xb3);
            AddToLevelFunc("Forest Frenzy - Bonus 1", 0xb9c623, 0xc38dfe, 0x100, 0x13, 0xb, 0xdc);
            AddToLevelFunc("Forest Frenzy - Bonus 2", 0xb9c623, 0xc38dfe, 0x1600, 0x13, 0xb, 0xd4);
            AddToLevelFunc("Temple Tempest - Bonus 1", 0xb9b3a3, 0xec1728, 0x400, 0xff, 6, 0x52);
            AddToLevelFunc("Temple Tempest - Bonus 2", 0xb9b3a3, 0xec1728, 0x100, 0xff, 6, 0x53);
            // 20, 1f, 1e, 5b, 5a
            AddToLevelFunc("Orang-utan Gang - Bonus 1", 0xb9a1dc, 1, 0, 0x20);
            AddToLevelFunc("Orang-utan Gang - Bonus 2", 0xb9a1dc, 1, 0, 0x1f);
            AddToLevelFunc("Orang-utan Gang - Bonus 3", 0xb9a1dc, 1, 0, 0x1e);
            AddToLevelFunc("Orang-utan Gang - Bonus 4", 0xb9a1dc, 1, 0, 0x5b);
            AddToLevelFunc("Orang-utan Gang - Bonus 5", 0xb9a1dc, 1, 0, 0x5a);

            AddToLevelFunc("Snow Barrel Blast - Bonus 1", 0xb99b1c, 0xe07036, 0x100, 8, 7, 0x67);
            AddToLevelFunc("Snow Barrel Blast - Bonus 2", 0xb99b1c, 0xe06f36, 0x100, 8, 7, 0x69);
            AddToLevelFunc("Snow Barrel Blast - Bonus 3", 0xb99b1c, 0xe07036, 0x400, 8, 7, 0x66);
            //ca,c5,c6
            //AddToLevelFunc("Slipslide Ride - Bonus 1", 0xb9c723, 0xe105e5, 0x400, 0xf, 8, 0xca);
            //AddToLevelFunc("Slipslide Ride - Bonus 2", 0xb9c723, 0xe105e5, 0x400, 0xf, 8, 0xca);
            //AddToLevelFunc("Slipslide Ride - Bonus 3", 0xb9c723, 0xe101e5, 0x800, 0xf, 8, 0xca);
            AddToLevelFunc("Ice Age Alley - Bonus 1", 0xb99b1c, 0xe07636, 0x200, 8, 7, 0x6a);
            AddToLevelFunc("Ice Age Alley - Bonus 2", 0xb99b1c, 0xe07036, 0x100, 8, 7, 0x6b);
            AddToLevelFunc("Torchlight Trouble - Bonus 1", 0xb9a01c, 2, 1, 0xc1);
            AddToLevelFunc("Torchlight Trouble - Bonus 2", 0xb9a01c, 2, 1, 0xc3);
            //AddToLevelFunc("Rope Bridge Rumble - Bonus 1", 0xb9b1a3, 0xc34e00, 0x400, 0x12, 0xa, 0xd5);
            AddToLevelFunc("Rope Bridge Rumble - Bonus 1", 0xb9b1a3, 0x12, 0xa, 0xd5);
            AddToLevelFunc("Rope Bridge Rumble - Bonus 2", 0xb9b1a3, 0x12, 0xa, 0xd7);

            // 63, 61, be, 60
            AddToLevelFunc("Oil Drum Alley - Bonus 1", 0xb9b0a3, 0xd, 0x4, 0x63);
            AddToLevelFunc("Oil Drum Alley - Bonus 2", 0xb9b0a3, 0xd, 0x4, 0x61);
            AddToLevelFunc("Oil Drum Alley - Bonus 3", 0xb9b0a3, 0xd, 0x4, 0xbe);
            AddToLevelFunc("Oil Drum Alley - Bonus 4", 0xb9b0a3, 0xd, 0x4, 0x60);
            // a1, 9e, 9d
            AddToLevelFunc("Trick Track Trek - Bonus 1", 0xb9a2dc, 0x9, 0x2, 0xa1);
            AddToLevelFunc("Trick Track Trek - Bonus 2", 0xb9a2dc, 0x9, 0x2, 0x9e);
            AddToLevelFunc("Trick Track Trek - Bonus 3", 0xb9a2dc, 0x9, 0x2, 0x9d);
            // 9a, 9b, 9c
            AddToLevelFunc("Elevator Antics - Bonus 1", 0xb9a01c, 0x2, 0x1, 0x9a);
            AddToLevelFunc("Elevator Antics - Bonus 2", 0xb9a01c, 0x2, 0x1, 0x9b);
            AddToLevelFunc("Elevator Antics - Bonus 3", 0xb9a01c, 0x2, 0x1, 0x9c);
            // 4d, a0, ad
            AddToLevelFunc("Mine Cart Madness - Bonus 1", 0xb9ad65, 0x2, 0x1, 0x4d);
            AddToLevelFunc("Mine Cart Madness - Bonus 2", 0xb9a2dc, 0x9, 0x2, 0xa0);
            AddToLevelFunc("Mine Cart Madness - Bonus 3", 0xb9a2dc, 0x9, 0x2, 0xa2);
            // 64, a3, 
            AddToLevelFunc("Blackout Basement - Bonus 1", 0xb9b0a3, 0xd, 0x4, 0x64);
            AddToLevelFunc("Blackout Basement - Bonus 2", 0xb9b0a3, 0xd, 0x4, 0xa3);

            AddToLevelFunc("Tanked Up Trouble - Bonus 1", 0xb9a2dc, 9, 2, 0x9f);
            AddToLevelFunc("Manic Mincers - Bonus 1", 0xb9ae65, 2, 1, 0x5);
            AddToLevelFunc("Manic Mincers - Bonus 2", 0xb9ae65, 2, 1, 0x98);
            AddToLevelFunc("Manic Mincers - Ledge Room", 0xb9ae65, 2, 1, 0x99);
            AddToLevelFunc("Misty Mine - Bonus 1", 0xb9a3dc, 0xdb28cc + 0x3800, 0x700, 5, 3, 0x33);
            AddToLevelFunc("Misty Mine - Bonus 2", 0xb9a3dc, 0xdb28cc + 0x3800, 0x100, 5, 3, 0x32);
            // 49, 37
            AddToLevelFunc("Loopy Lights - Bonus 1", 0xb9a3dc, 0xdb28cc + 0x3b00, 0x400, 0xc, 3, 0x49);
            AddToLevelFunc("Loopy Lights - Bonus 2", 0xb9a3dc, 0xdb28cc + 0x6e00, 0x600, 0xc, 3, 0x37);
            AddToLevelFunc("Platform Perils - Bonus 1", 0xb9a2dc, 0x9, 2, 0x4e);
            AddToLevelFunc("Platform Perils - Bonus 2", 0xb9a2dc, 0x9, 2, 0x50);


        }


        public int TilesetIndex(int index, int lvlCode)
        {
            //if (Global.mod && lvlCode == 0xc)
            //{
                //return 0x4546f8;
            //}

            if (index == 0xff)
                return 0xe73bde;
            if (index == 0xf0)
                return 0x0f0000;
            int offset,
                a = index,
                x,
                y;



            //            Sub - routine A_b9a924          // 0 error(s).
            //                                            // Start at A_b9a924_b9a924
            //                                            // page = 0000
            //                                            // bank =   00

            //  a_b9a924_b9a924:	__PHK                  // PC[b9a924]={4b         }  s1
            //              __PHK                  // PC[b9a925]={4b         }  s2

            //            __PLB                  // PC[b9a926]={ab         }  s1
            //            __ASL A                // PC[b9a927]={0a         }  s1
            a <<= 1;
            //            __TAY                  // PC[b9a928]={a8         }  s1
            y = a;
            //            __LDX $a994,Y          // PC[b9a929]={be 94 a9   }  s1
            x = Read16(0xb9a994 + y);
        b9a92c:;
            //a_b9a924_b9a92c:	__SEP #$20             // PC[b9a92c]={e2 20      }  s1
            //			m_LDA $a994,X          // PC[b9a92e]={bd 94 a9   }  s1
            a = Read8(0xb9a994 + x);
            //			▼▼BEQ $= _a967          // PC[b9a931]={f0 34      }  s1
            if ((a & 0xff) == 0)
                goto b9a967;

            //            m_LDA $a998,X          // PC[b9a933]={bd 98 a9   }  s1
            a = Read8(0xb9a998 + x);
            //			▼▼BMI $= _a96b          // PC[b9a936]={30 33      }  s1
            if (a >= 0x80)
                goto b9a96b;

            //            m_LDA $a994,X          // PC[b9a938]={bd 94 a9   }  s1
            //            m_STA $4304            // PC[b9a93b]={8d 04 43   }  s1
            //            __LDY $a995,X          // PC[b9a93e]={bc 95 a9   }  s1
            //            __STY $4302            // PC[b9a941]={8c 02 43   }  s1
            //            __LDY $a997,X          // PC[b9a944]={bc 97 a9   }  s1
            //            __STY $2116            // PC[b9a947]={8c 16 21   }  s1
            //a_b9a924_b9a94a: __LDY $a999,X          // PC[b9a94a]={bc 99 a9   }  s1
            //         __STY $4305            // PC[b9a94d]={8c 05 43   }  s1
            //            m_LDA #$18             // PC[b9a950]={a9 18      }  s1
            //			m_STA $4301            // PC[b9a952]={8d 01 43   }  s1
            //            m_LDA #$01             // PC[b9a955]={a9 01      }  s1
            //			m_STA $4300            // PC[b9a957]={8d 00 43   }  s1
            //            m_STA $420b            // PC[b9a95a]={8d 0b 42   }  s1
            //            __REP #$20             // PC[b9a95d]={c2 20      }  s1
            //			__TXA                  // PC[b9a95f]={8a         }  s1
            a = x;
            //            __CLC                  // PC[b9a960]={18         }  s1
            //            __ADC #$0007           // PC[b9a961]={69 07 00   }  s1
            a += 7;
            //			__TAX                  // PC[b9a964]={aa         }  s1
            x = a;
            //			▲▲BRA $= _a92c          // PC[b9a965]={80 c5      }  s1
            goto b9a92c;
        b9a967:;
            //a_b9a924_b9a967: __REP #$20             // PC[b9a967]={c2 20      }  s1
            //			__PLB                  // PC[b9a969]={ab         }  s0
            //            __RTS                  // PC[b9a96a]={60         }  s0
            return 0;
        b9a96b:;
            //a_b9a924_b9a96b:	__REP #$20             // PC[b9a96b]={c2 20      }  s1
            //			__LDY $a995,X          // PC[b9a96d]={bc 95 a9   }  s1
            y = Read16(0xb9a995 + x);

            //            __LDA $a994,X          // PC[b9a970]={bd 94 a9   }  s1
            a = Read16(0xb9a994 + x);

            //            __AND #$00ff           // PC[b9a973]={29 ff 00   }  s1
            a &= 0xff;
            //			__PHX                  // PC[b9a976]={da         }  s3
            //            __JSR $b896fc          // PC[b9a977]={22 fc 96 b8}  s3

            offset = (a << 16) | y;
            return offset;

        }

        public byte[] GetDecompressedTiles(int offset)
        {
            var arr = ReadSubArray(offset, 0x10000 /* Decompression automatically stops */, rom.ToArray());            
            var decompressed = DecompressDKC1(arr);
            var temp = new byte[0x100 * 4 * 0x20];
            Array.Copy(decompressed, temp, decompressed.Length);
            return temp;
        }

        public bool IsVertical (int lvlCode)
        {
            // 4 18 21 23 30 - combo box indexes
            return lvlCode == 0xbf || lvlCode == 0xde || lvlCode == 0x6d || lvlCode == 0x3e || lvlCode == 0x22 || lvlCode == 0xca || lvlCode == 0xc5 || lvlCode == 0xc6 ? true : false;
        }
        public bool IsWater (int lvlCode)
        {
            // 4 18 21 23 30 - combo box indexes
            return lvlCode == 0xbf || lvlCode == 0xde || lvlCode == 0x3e || lvlCode == 0x22 ? true : false;
        }

        public Dictionary<int, int> startHeight = new Dictionary<int, int>()
        {
            [0xbf] = 0x48c5,
        };
        public string StringByLevelCode (int lvlCode)
        {
            string @return = "";
            foreach (KeyValuePair<string, int> keyValue in levelCodeByString)
            {
                if (keyValue.Value == lvlCode)
                {
                    @return = keyValue.Key;
                    break;
                }
            }
            return @return;
        }

        public string[] nameByLevelCode = new string[]
        {
            "Jungle Hijinx (Reptile Rumble object map?)",
            "Reptile Rumble (level start)",
            "Reptile Rumble - Bonus 1",
            "Bouncy Bonanza - Winky Room",
            "Reptile Rumble - Bonus 3",
            "Manic Mincers - Bonus 1",
            "Jungle Hijinx - Bonus 1",
            "Bouncy Bonanza (level start)",
            "Jungle Hijinx (from Bonus 1)",
            "Reptile Rumble (from Bonus 1)",
            "Misty Mine (level start)",
            "Reptile Rumble (from Bonus 3)",
            "Ropey Rampage (level start)",
            "Orang-utan Gang (level start)",
            "Jungle Hijinx (from treehouse)",
            "Ropey Rampage (from Save)",
            "Bouncy Bonanza (from Winky Room)",
            "Bouncy Bonanza - Bonus 2",
            "Manic Mincers (level start)",
            "Torchlight Trouble (from Save)",
            "Torchlight Trouble (level start)",
            "Bouncy Bonanza (from Save)",
            "Jungle Hijinx (level start)",
            "Barrel Cannon Canyon (level start)",
            "Elevator Antics (level start)",
            "Barrel Cannon Canyon (from Save)",
            "Jungle Hijinx - Bonus 2",
            "Ropey Rampage - Bonus 2",
            "Ropey Rampage - Bonus 1",
            "Orang-utan Gang (from Save)",
            "Orang-utan Gang - Bonus 3",
            "Orang-utan Gang - Bonus 2",
            "Orang-utan Gang - Bonus 1",
            " empty jungle room + boss music???",
            "Poison Pond (level start)",
            "Elevator Antics (from Save)",
            "Snow Barrel Blast (level start)",
            "Jungle Hijinx (from Save)",
            "Reptile Rumble (from Save)",
            "Mine Cart Madness (level start)",
            "Snow Barrel Blast (from Save)",
            "Manic Mincers (from Save)",
            "Poison Pond (from Save)",
            "Platform Perils (level start)",
            "Platform Perils (from Save)",
            "Misty Mine (from Save)",
            "Mine Cart Carnage (level start)",
            "Trick Track Trek (level start)",
            "Tanked Up Trouble (level start)",
            "Stop & Go Station (level start)",
            "Misty Mine - Bonus 2",
            "Misty Mine - Bonus 1",
            "Animal Token Room",
            "Millstone Mayhem (from warp)",
            "Loopy Lights (level start)",
            "Loopy Lights - Bonus 2",
            "Mine Cart Carnage (from Save)",
            "Trick Track Trek (from Save)",
            "Tanked Up Trouble (from Save)",
            "Mine Cart Madness (from Save)",
            "Stop & Go Station (from Save)",
            "Loopy Lights (from Save)",
            "Croctopus Chase (level start)",
            "Croctopus Chase (from Save)",
            "Oil Drum Alley (level start)",
            "Blackout Basement (level start)",
            "Millstone Mayhem (level start)",
            "Temple Tempest (level start)",
            "Oil Drum Alley (from Save)",
            "Blackout Basement (from Save)",
            "Barrel Cannon Canyon - Bonus 1",
            "Jungle Hijinx - Kong's Banana Hoard (empty)",
            "Reptile Rumble - Bonus 2",
            "Loopy Lights - Bonus 1",
            "Stop & Go Station - Bonus 2",
            "Stop & Go Station - Bonus 1",
            "Jungle Hijinx - Kong's Banana Hoard (full)",
            "Mine Cart Madness - Bonus 1",
            "Platform Perils - Bonus 1",
            "Winky's Walkway - Bonus 1",
            "Platform Perils - Bonus 2",
            "Winky's Walkway (from Bonus 1)",
            "Temple Tempest - Bonus 1",
            "Temple Tempest - Bonus 2",
            "Tree Top Town (warp)",
            "Millstone Mayhem - Bonus 1",
            "Millstone Mayhem - Bonus 2",
            "Millstone Mayhem - Bonus 3",
            "Millstone Mayhem (from Save)",
            "Temple Tempest (from Save)",
            "Orang-utan Gang - Bonus 5",
            "Orang-utan Gang - Bonus 4",
            "Jungle Hijinx - Kong's Cabin",
            "Barrel Cannon Canyon - Bonus 2",
            " Credits",
            "Jungle Hijinx (from Hoard)",
            "Oil Drum Alley - Bonus 4",
            "Oil Drum Alley - Bonus 2",
            "Slipslide Ride (warp)",
            "Oil Drum Alley - Bonus 1",
            "Blackout Basement - Bonus 1",
            "Vulture Culture (warp)",
            "Snow Barrel Blast - Bonus 3",
            "Snow Barrel Blast - Bonus 1",
            "Gangplank Galleon",
            "Snow Barrel Blast - Bonus 2",
            "Ice Age Alley - Bonus 1",
            "Ice Age Alley - Bonus 2",
            "Expresso Bonus",
            "Slipslide Ride (level start)",
            "Jungle Hijinx (from Bonus 2)",
            "Ropey Rampage (from Bonus 1)",
            "Ropey Rampage (from Bonus 2)",
            "Orang-utan Gang (from Bonus 4)",
            "Orang-utan Gang (from Bonus 2)",
            "Orang-utan Gang (from Bonus 1)",
            "Orang-utan Gang (from Bonus 3)",
            "Orang-utan Gang (from Bonus 5)",
            "Barrel Cannon Canyon (from Bonus 1)",
            "Barrel Cannon Canyon (from Bonus 2)",
            "Bouncy Bonanza (from Bonus 1)",
            "Bouncy Bonanza (from Bonus 2)",
            "Manic Mincers (from Bonus 1)",
            "Manic Mincers (from Ledge Room)",
            "Manic Mincers (from Bonus 2)",
            "Elevator Antics (from Bonus 1)",
            "Elevator Antics (from Bonus 2)",
            "Elevator Antics (from Bonus 3)",
            "Misty Mine (from Bonus 1)",
            "Misty Mine (from Bonus 2)",
            "Stop & Go Station (from Bonus 1)",
            "Stop & Go Station (from Bonus 2)",
            "Loopy Lights (from Bonus 1)",
            "Loopy Lights (from Bonus 2)",
            "Platform Perils (from Bonus 1)",
            "Platform Perils (from Bonus 2)",
            "Trick Track Trek (from Bonus 1)",
            "Trick Track Trek (from Bonus 3)",
            "Trick Track Trek (from Bonus 2)",
            "Tanked Up Trouble (from Bonus 1)",
            "Mine Cart Madness (from Bonus 1)",
            "Mine Cart Madness (from Bonus 2)",
            "Mine Cart Madness (from Bonus 3)",
            "Oil Drum Alley (from Bonus 1)",
            "Oil Drum Alley (from Bonus 2/3)",
            "Oil Drum Alley (from Bonus 4)",
            "Blackout Basement (from Bonus 1)",
            "Blackout Basement (from Bonus 2)",
            "Snow Barrel Blast (from Bonus 1)",
            "Snow Barrel Blast (from Bonus 2)",
            "Snow Barrel Blast (from Bonus 3)",
            "Bouncy Bonanza - Bonus 1",
            "Manic Mincers - Bonus 2",
            "Manic Mincers - Ledge Room",
            "Elevator Antics - Bonus 1",
            "Elevator Antics - Bonus 2",
            "Elevator Antics - Bonus 3",
            "Trick Track Trek - Bonus 3",
            "Trick Track Trek - Bonus 2",
            "Tanked Up Trouble - Bonus 1",
            "Mine Cart Madness - Bonus 2",
            "Trick Track Trek - Bonus 1",
            "Mine Cart Madness - Bonus 3",
            "Blackout Basement - Bonus 2",
            "Tree Top Town (level start)",
            "Vulture Culture (level start)",
            "Enguarde Bonus",
            "Ice Age Alley (level start)",
            "Ice Age Alley (from Save)",
            "Tree Top Town (from Save)",
            "Vulture Culture (from Save)",
            "Slipslide Ride (from Save)",
            "Ice Age Alley (from Bonus 1)",
            "Ice Age Alley (from Bonus 2)",
            "Millstone Mayhem (from Bonus 1)",
            "Millstone Mayhem (from Bonus 2)",
            "Millstone Mayhem (from Bonus 3)",
            "Temple Tempest (from Bonus 1)",
            "Temple Tempest (from Bonus 2)",
            "Tree Top Town - Bonus 2",
            "Tree Top Town - Bonus 1",
            "Tree Top Town (from Bonus 1)",
            "Tree Top Town (from Bonus 2)",
            "Vulture Culture - Bonus 1",
            "Vulture Culture - Bonus 2",
            "Vulture Culture - Bonus 3",
            "Vulture Culture (from Bonus 1)",
            "Vulture Culture (from Bonus 2)",
            "Vulture Culture (from Bonus 3)",
            "Trick Track Trek (warp)",
            "Oil Drum Alley - Bonus 3",
            "Coral Capers (level start)",
            "Coral Capers (from Save)",
            "Torchlight Trouble - Bonus 1",
            "Torchlight Trouble (from Bonus 1)",
            "Torchlight Trouble - Bonus 2",
            "Torchlight Trouble (from Bonus 2)",
            "Slipslide Ride - Bonus 2",
            "Slipslide Ride - Bonus 3",
            "Slipslide Ride (from Bonus 1)",
            "Slipslide Ride (from Bonus 2)",
            "Reptile Rumble (from Bonus 2)",
            "Slipslide Ride - Bonus 1",
            "Slipslide Ride (from Bonus 3)",
            "Mine Cart Carnage (warp)",
            "Stop & Go Station (warp)",
            "Rope Bridge Rumble (level start)",
            "Rope Bridge Rumble (from Save)",
            "Forest Frenzy (level start)",
            "Forest Frenzy (from Save)",
            "Rambi Bonus",
            "Winky Bonus",
            "Forest Frenzy - Bonus 2",
            "Rope Bridge Rumble - Bonus 1",
            "Rope Bridge Rumble (from Bonus 2)",
            "Rope Bridge Rumble - Bonus 2",
            "Rope Bridge Rumble (from Bonus 1)",
            "Winky's Walkway (level start)",
            "Winky's Walkway (from Save)",
            "Forest Frenzy (from Bonus 2)",
            "Forest Frenzy - Bonus 1",
            "Forest Frenzy (from Bonus 1)",
            "Clam City (level start)",
            "Clam City (from Save)",
            "Very Gnawty's Lair",
            "Necky's Nuts",
            "Really Gnawty Rampage",
            "Boss Dumb Drum",
            "Necky's Revenge",
            "Bumble B Rumble",

        };
        public List<LevelAndCode> GetRelatedLevels (string name)
        {
            try
            {
                var list = levelNameByCode.Where(kvp => kvp.Value.Contains(name) && !kvp.Value.Contains("- Bonus"));
                var list2 = list.Select(e => new LevelAndCode(e)).ToList();
                return list2;
            }
            catch
            {
                return null;
            }
        }
        public List<LevelAndCode> GetAllLevels ()
        {
            List<LevelAndCode> @return = new List<LevelAndCode>();
            foreach (KeyValuePair<int, string> lvl in levelNameByCode)
            {
                var temp = new LevelAndCode(lvl);
                @return.Add(temp);
            }
            @return = @return.Where(e => !e.str.Contains("NULL")).ToList();
            @return = @return.OrderBy(e => e.str).ToList();

            return @return;
        }
    }
}
