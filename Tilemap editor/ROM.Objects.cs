using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class ROM
    {
        static byte[] paramCountLut = new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 1, 2, 0, 3, 1, 1, 1 };
        bool custom = true;

        public List<string> objectListRaw = new List<string>();
        public List<string> objectListRawBackup = new List<string>()
        {
            "Custom:",
            "Evil Winky=0000",
            "Evil Expresso=0001",
            "Evil Rambi=0002",
            "",
            "Evil Gnawty=0007",
            "Evil Kritter=0008",
            "Evil Klaptrap=0009",
            "Evil Klump=000a",
            "Evil Army=000b",
            "Evil Krusha=000c",
            "Evil MiniNecky=000d",
            "Evil Necky=000e",
            "Evil Manky=000f",
            "Evil PerchedNecky=0010",
            "Evil Bitesize=0011",
            "Evil ChompsJr=0012",
            "Evil Squidge=0013",
            "Evil Chomps=0014",
            "",
            "Friendly Stationary Necky=0006",
            "Friendly Manky=0015",
            "Friendly Gnawty=0016",
            "Friendly Kritter=0017",
            "Friendly MiniNecky=0018",
            "Friendly Klump=0019",
            "Friendly Flying NeckyL=001a",
            "Friendly Flying NeckyR=001b",
            "",
            "Custom Podobo=001c",
            "Custom Podobo Can=001d",
            "Custom Podobo Ground=0024",
            "",
            "Thwomp=001e",
            "",
            "Pit Launch(Klaptrap)=001f",
            "Pit Launch(Army)=0021",
            "",
            "Army Insta-roll=0020",
            "",
            "Kaizo Block=0022",
            "",
            "Swim Powerup=0132",
            "Jump Powerup=0133",
            "Roll Powerup=0023",
            "Speed Powerup=0136",
            "",
            "Respawning Roll Powerup=0025",
            "Respawning Swim Powerup=0134",
            "Respawning Jump Powerup=0135",
            "Respawning Speed Powerup=0137",
            "",
            "Respawning Rimmed barrel=0026",
            "Respawning Steel keg=0027",
            "",
            "Custom Warp R1=0028",
            "Custom Warp L1=0029",
            "Custom Warp R2=002a",
            "Custom Warp L2=002b",
            "",
            "Custom Switch Mincer=002e",
            "",
            "Custom Cannonball=002f",
            "Custom CannonballR=0031",
            "Custom CannonballD=0049",
            "",
            "Necky spit Rambi Token A=0032",
            "Necky spit Rambi Token B=0035",
            "Necky spit Rambi Token C=0037",
            "Necky spit Enguarde Token A=0039",
            "Necky spit Enguarde Token B=003b",
            "Necky spit Enguarde Token C=003d",
            "Necky spit Expresso Token A=003f",
            "Necky spit Expresso Token B=0041",
            "Necky spit Expresso Token C=0043",
            "Necky spit Expresso Token D=0045",
            "Necky spit Red Homing Winky Token=0047",
            "",
            "Custom steel keg=004b",
            "",
            "Custom cave platform (circle)=0139",
            "",

            "Custom upside down:",
            "Script_Upside_Down_97D1_Purple_Klaptrap=013A",
            "Script_Upside_Down_97F3_Purple_Klaptrap__stationary_=013B",
            "Script_Upside_Down_9641_Klaptrap__walking_b_f_foward_=013C",
            "Script_Upside_Down_9665_Klaptrap__walking_b_f_backward_=013D",
            "Script_Upside_Down_9689_Klaptrap__walking_b_f_foward__long_=013E",
            "Script_Upside_Down_9443_Kritter__Green__walking_b_f_=013F",
            "Script_Upside_Down_94ED_Kritter__Green=0140",
            "Script_Upside_Down_953B_Kritter__Grey__jumping_foward_=0141",
            "Script_Upside_Down_958D_Kritter__Brown__jumping_=0142",
            "Script_Upside_Down_98B3_Klump__walking_foward_=0143",
            "Script_Upside_Down_98C1_Klump__wait__then_walk_backward_=0144",
            "Script_Upside_Down_98D3_Klump__wait__then_walk_foward_=0145",
            "Script_Upside_Down_98E5_Klump__walking_backward_=0146",
            "Script_Upside_Down_9CCF_Slippa__slow_=0147",
            "Script_Upside_Down_9CD9_Slippa__fast_=0148",
            "Script_Upside_Down_9CE3_Slippa=0149",
            "Script_Upside_Down_A26F_Green_Zinger__arch_b_f_backward_=014A",
            "Script_Upside_Down_A285_Green_Zinger__arch_b_f_backward__short_=014B",
            "Script_Upside_Down_A29B_Green_Zinger__arch_b_f_backward__long_=014C",
            "Script_Upside_Down_A467_Army=014D",
            "Script_Upside_Down_A471_Army__slow_=014E",
            "Script_Upside_Down_A47B_Army__Facing_Rightwards_=014F",
            "Script_Upside_Down_B3F7_Gnawty__walking_b_f__short_=0150",
            "Script_Upside_Down_B405_Gnawty__walking_b_f_=0151",
            "Script_Upside_Down_B413_Gnawty__constant_movement_=0152",
            "Script_Upside_Down_B427_Gnawty__wait__then_walk_backward_=0153",
            "Script_Upside_Down_B5AB_Grey_Krusha__walking_b_f_backward__short_=0154",
            "Script_Upside_Down_B5BD_Krusha__constant_movement_=0155",
            "Script_Upside_Down_B5CB_Krusha__constant_movement_=0156",
            "Script_Upside_Down_B5E3_Krusha__wait__then_walk_backward_=0157",
            "Script_Upside_Down_B86D_Mini_Necky__stationary___shoot_nuts_=0158",
            "Script_Upside_Down_B8D5_Mini_Necky__move_upwards___shoot_nuts__very_slow_=0159",
            "Script_Upside_Down_B8C7_Mini_Necky__move_upwards___shoot_nuts__slow_=015A",
            "Script_Upside_Down_B863_Mini_Necky__move_upwards___shoot_nuts_=015B",
            "Script_Upside_Down_BD29_Necky__constant_movement__very_slow_=015C",
            "Script_Upside_Down_BD37_Necky__constant_movement_=015D",
            "Script_Upside_Down_BD45_Necky__constant_movement__fast_=015E",
            "Script_Upside_Down_BD61_Necky__stationary_=015F",
            "Script_Upside_Down_BD95_Manky_Kong__slow_=0160",
            "Script_Upside_Down_BD9F_Manky_Kong__very_slow_moving_barrels_=0161",
            "Script_Upside_Down_BDA9_Manky_Kong=0162",
            "Script_Upside_Down_BDB3_Manky_Kong__fast_=0163",
            "Script_Upside_Down_E4B7_Rockkroc__running_b_f_=0164",
            "Script_Upside_Down_E4C5_Rockkroc__running_b_f__short_=0165",
            "Script_Upside_Down_E4D3_Rockkroc__running_b_f_backward__long_=0166",
            "Script_Upside_Down_E4E1_Rockkroc__running_b_f_foward_=0167",
            "Script_Upside_Down_E667_OIL_Drum__constant_flame_=0168",
            "Script_Upside_Down_E671_OIL_Drum__interval_between_flame_rise_=0169",
            "Script_Upside_Down_E67B_OIL_Drum__rapid_flame_rise_=016A",


            "",
            "Animal Crates:",
            "Animal Crate, Enguarde=91DD",
            "Animal Crate, Expresso=91CF",
            "Animal Crate, Rambi=91B3",
            "Animal Crate, Squawks=91EF",
            "Animal Crate, Winky=91C1",
            "",
            "Army:",
            "Army (Facing Rightwards)=A47B",
            "Army (slow)=A471",
            "Army=A467",
            "",
            "Barrel Cannons (Auto):",
            "Barrel Cannon (AutoFire)=CEAF",

            "Barrel Cannon (AutoFire)=DBB9",

            "Barrel Cannon (AutoFire)=C93B",

            "Barrel Cannon (AutoFire)=CB95",

            "Barrel Cannon (AutoFire)=D2D1",

            "Barrel Cannon (AutoFire)=D619",

            "Barrel Cannon (AutoFire)=D67F",

            "Barrel Cannon (AutoFire)=C86B",

            "Barrel Cannon (AutoFire)=DBED",

            "Barrel Cannon (AutoFire)=DC0B",

            "Barrel Cannon (AutoFire) [Distance - ULTRA]=D5B3",

            "Barrel Cannon (AutoFire) [Shoots - DOWNLEFT, Distance - ULTRA]=D63B",

            "Barrel Cannon (AutoFire) [Shoots - LEFT, Distance - ULTRA-WEAK]=DC47",

            "Barrel Cannon (AutoFire) [Shoots - LEFT] (NO PAL)=D543",

            "Barrel Cannon (AutoFire) [Shoots - LEFT, Distance - JUGGERNAUT]=D227",

            "Barrel Cannon (AutoFire) [Shoots - LEFT, Speed -  BERSERK]=D559",

            "Barrel Cannon (AutoFire) [Points - DOWNLEFT, Shoots - UPLEFT]=D591",

            "Barrel Cannon (AutoFire)=DC29",

            "Barrel Cannon (AutoFire)=C7E9",

            "Barrel Cannon (AutoFire)=C89F",

            "Barrel Cannon (AutoFire)=C9F1",

            "Barrel Cannon (AutoFire)=D149",

            "Barrel Cannon (AutoFire)=D26B",

            "Barrel Cannon (AutoFire)=DAA9",

            "Barrel Cannon (AutoFire) [Disappears]=DB85",

            "Barrel Cannon (AutoFire) [Distance - ULTRA]=CDDD",

            "Barrel Cannon (AutoFire)=CC05",

            "Barrel Cannon (AutoFire)=D0EB",

            "Barrel Cannon (AutoFire)=D52D",

            "Barrel Cannon (AutoFire)=DB6B",

            "Barrel Cannon (AutoFire)=DC65",

            "Barrel Cannon (AutoFire)=DC7F",

            "Barrel Cannon (AutoFire)=CE37",

            "Barrel Cannon (AutoFire)=CF91",

            "Barrel Cannon (AutoFire)=D315",

            "Barrel Cannon (AutoFire)=D513",

            "Barrel Cannon (AutoFire)=CEEB",

            "Barrel Cannon (AutoFire)=D56F",

            "Barrel Cannon (AutoFire)=C837",

            "Barrel Cannon (AutoFire)=CE73",

            "Barrel Cannon (AutoFire)=CA25",

            "Barrel Cannon (AutoFire)=CDA1",

            "Barrel Cannon (AutoFire)=D189",

            "Barrel Cannon (AutoFire) [Distance - ULTRA]=D5D5",

            "Barrel Cannon (AutoFire)=C8D3",

            "Barrel Cannon (AutoFire)=CECD",

            "Barrel Cannon (AutoFire)=D1A7",

            "Barrel Cannon (AutoFire)=D249",

            "Barrel Cannon (AutoFire)=DC99",

            "Barrel Cannon (AutoFire)=CBAF",

            "Barrel Cannon (AutoFire)=CDBF",

            "Barrel Cannon (AutoFire)=CAC5",

            "Barrel Cannon (AutoFire)=C955",

            "Barrel Cannon (AutoFire)=DB1D",

            "Barrel Cannon (AutoFire) [Distance - JUGGERNAUT]=CBE7",

            "Barrel Cannon (AutoFire)=C8B9",

            "Barrel Cannon (AutoFire)=C9A3",

            "Barrel Cannon (AutoFire)=CB61",

            "Barrel Cannon (AutoFire)=CBC9",

            "Barrel Cannon (AutoFire)=D28D",

            "Barrel Cannon (AutoFire)=D337",

            "Barrel Cannon (AutoFire)=DBD3",

            "Barrel Cannon (AutoFire)=CA3F",

            "Barrel Cannon (AutoFire)=CE55",

            "Barrel Cannon (AutoFire)=D5F7",

            "Barrel Cannon (AutoFire) [Distance - JUGGERNAUT - slightly less]=DA87",

            "Barrel Cannon (AutoFire) [Distance - JUGGERNAUT]=CCB1",

            "Barrel Cannon (AutoFire)=CC75",

            "Barrel Cannon (AutoFire)=CC93",

            "Barrel Cannon (AutoFire)=CCCF",

            "Barrel Cannon (AutoFire)=CE91",

            "Barrel Cannon (AutoFire)=D1E7",

            "Barrel Cannon (AutoFire)=C96F",

            "Barrel Cannon (AutoFire) [Distance - JUGGERNAUT - longest]=DA65",

            "Barrel Cannon (AutoFire)=C81D",

            "Barrel Cannon (AutoFire)=CA73",

            "Barrel Cannon (AutoFire)=CCED",

            "Barrel Cannon (AutoFire)=CD0B",

            "Barrel Cannon (AutoFire)=CDFB",

            "Barrel Cannon (AutoFire)=D073",

            "Barrel Cannon (AutoFire)=D127",

            "Barrel Cannon (AutoFire)=D2F3",

            "Barrel Cannon (AutoFire)=DB37",

            "Barrel Cannon (AutoFire) [Distance - ULTRA]=D65D",

            "Barrel Cannon (AutoFire) [Distance - ULTRAPLUS]=D16B",

            "Barrel Cannon (AutoFire)=CA0B",

            "Barrel Cannon (AutoFire)=D051",

            "Barrel Cannon (AutoFire)=CD83",

            "Barrel Cannon (AutoFire)=D37B",
            "",
            "Barrel Cannons:",
            "Barrel Cannon=C781",

            "Barrel Cannon=CB2D",

            "Barrel Cannon=CFEF",

            "Barrel Cannon=D109",

            "Barrel Cannon=C803",

            "Barrel Cannon=CA59",

            "Barrel Cannon=D00D",

            "Barrel Cannon=D02F",

            "Barrel Cannon=D8AB",

            "Barrel Cannon=DF95",

            "Barrel Cannon=C989",

            "Barrel Cannon=DCD5",

            "Barrel Cannon=DCF7",

            "Barrel Cannon=DD19",

            "Barrel Cannon=DD3B",

            "Barrel Cannon=DD5D",

            "Barrel Cannon [Distance - ~13 Tiles]=CADF",

            "Barrel Cannon [Rotates+Moves Simultaneously]=DF59",

            "Barrel Cannon=C767",

            "Barrel Cannon=C79B",

            "Barrel Cannon=CB47",

            "Barrel Cannon=CB7B",

            "Barrel Cannon=CD29",

            "Barrel Cannon=CFD1",

            "Barrel Cannon=DCB3",

            "Barrel Cannon=DEFF",

            "Barrel Cannon=DF1D",

            "Barrel Cannon [Oscillates+Moves Simultaneously]=DF77",

            "Barrel Cannon=D0AF",

            "Barrel Cannon=D6FB",

            "Barrel Cannon=D737",

            "Barrel Cannon=D791",

            "Barrel Cannon=D7AF",

            "Barrel Cannon=D7CD",

            "Barrel Cannon=D7EB",

            "Barrel Cannon=D809",

            "Barrel Cannon=D827",

            "Barrel Cannon=D845",

            "Barrel Cannon=CAF9",

            "Barrel Cannon=CB13",

            "Barrel Cannon=DB9F",

            "Barrel Cannon=D867",

            "Barrel Cannon [Distance - ~8 Tiles]=C8ED",

            "Barrel Cannon=D999",

            "Barrel Cannon=D9BB",

            "Barrel Cannon=D9DD",

            "Barrel Cannon [Rotates+Moves On Load Simultaneously]=D9FF",

            "Barrel Cannon [Rotates+Moves On Load Simultaneously]=DA21",

            "Barrel Cannon=C907",

            "Barrel Cannon=C921",

            "Barrel Cannon=C9BD",

            "Barrel Cannon=C9D7",

            "Barrel Cannon=CAA7",

            "Barrel Cannon=CF4D",

            "Barrel Cannon=CF6F",

            "Barrel Cannon=CFAF",

            "Barrel Cannon=D209",

            "Barrel Cannon=D2AF",

            "Barrel Cannon=D359",

            "Barrel Cannon=D469",

            "Barrel Cannon=D889",

            "Barrel Cannon=D955",

            "Barrel Cannon=D977",

            "Barrel Cannon=DE69",

            "Barrel Cannon=DE87",

            "Barrel Cannon=DEA5",

            "Barrel Cannon=DEC3",

            "Barrel Cannon=DEE1",

            "Barrel Cannon=D1C5",

            "Barrel Cannon=D4F1",

            "Barrel Cannon=D911",

            "Barrel Cannon [Distance - ~8 Tiles]=C885",

            "Barrel Cannon=C7B5",

            "Barrel Cannon=CF09",

            "Barrel Cannon=CF2B",

            "Barrel Cannon=D447",

            "Barrel Cannon=D48B",

            "Barrel Cannon=D4AD",

            "Barrel Cannon=D4CF",

            "Barrel Cannon=D6A1",

            "Barrel Cannon=D6DD",

            "Barrel Cannon=D8CD",

            "Barrel Cannon=DE4B",

            "Barrel Cannon=C851",

            "Barrel Cannon=D0CD",

            "Barrel Cannon=D719",

            "Barrel Cannon=D091",
            "",
            "Barrels:",
            "DK Barrel (Alt)=BBB1",
            "DK Barrel=9349",
            "Floating DK Barrel=9357",
            "Vine Barrel (Alt)=BBD3",
            "Vine Barrel=92EF",
            "Steel Keg=9255",
            "Rimmed Barrel (Stop & Go)=92B7",
            "Rimmed Barrel=92A9",
            "TNT Barrel (Alt)=9399",
            "TNT Barrel=938F",
            "",
            "Bonus Stuff:",
            "BONUS ENTRANCE - Elevator Antics #1=ECC3",
            "BONUS ENTRANCE - Elevator Antics #2=ECD5",
            "BONUS ENTRANCE - Elevator Antics #3=ECE7",
            "BONUS ENTRANCE - Misty Mine=ECF9",
            "BONUS ENTRANCE - Orang-utan Gang #1=ED27",
            "BONUS EXIT (All Bonuses)=EA93",
            "BONUS - Balloons Roulette=F1F5",
            "BONUS - Find The [Engaurde Token]=F2E7",
            "BONUS - Find The [Green Balloon]=F28D",
            "BONUS - Find The [Rambi Token]=F2DD",
            "BONUS - Find The [Red Balloon], ...during Blackouts=F27B",
            "BONUS - Find The [Red Balloon]=F269",
            "BONUS - Find The [Winky Token]=F2D3",
            "BONUS - K-O-N-G-Banana Roulette [Red Balloon]=F1D1",
            "BONUS - Klaptrap Bash Purple x1, [Red Balloon]=F34B",
            "BONUS - Klaptrap Bash x1, [Rambi Token], ...in Darkness=F31D",
            "BONUS - Klaptrap Bash x1, [Rambi Token]=F30F",
            "BONUS - Klaptrap Bash x2, [Red Balloon]=F33D",
            "BONUS - Klaptrap Bash x3, [Red Balloon]=F365",
            "BONUS - Kremheads Spelling Bee - KONG, [Expresso Token]=F4BF",
            "BONUS - Kremheads Spelling Bee - RARE, [Enguarde Token]=F4E5",
            "BONUS - Roulette [Get Prize or Barrel], Balloon-Bunch-Banana=F22B",
            "BONUS - Roulette [Get Prize], Balloon-Bunch-Banana =F219",
            "BONUS - Roulette [Get Prize], Balloon-Bunch-Banana-WinkyToken=F207",
            "BONUS - Spelling Bee, DONKEY KONG COUNTRY, [Balloons]=F50B",
            "BONUS - Spelling Bee, NINTENDO, [Red Balloon] =F585",
            "BONUS - Spelling Bee, WINKY RAMBI ENGAURDE EXPRESSO, [Tokens]=F5B7",
            "BONUS - Tokens Roulette=F1E3",
            "Bonus/Warp Exit (Disappears)(NO PAL)=AEE1",
            "Bonus/Warp Exit (Disappears)(NO PAL)=AF0D",
            "Bonus Barrel - Blackout Basement=AB4B",
            "Bonus Barrel - Bouncy Bonanza #2=AB17",
            "Bonus Barrel - Forest Frenzy #1=AE3D",
            "Bonus Barrel - Ice Age Alley #1=AD3D",
            "Bonus Barrel - Ice Age Alley #2=AD57",
            "Bonus Barrel - Loopy Lights #1=AC4F",
            "Bonus Barrel - Millstone Mayhem #1=AD23",
            "Bonus Barrel - Millstone Mayhem #2=AD05",
            "Bonus Barrel - Mine Cart Madness #1=AB99",
            "Bonus Barrel - Mine Cart Madness #2=ABB3",
            "Bonus Barrel - Mine Cart Madness #3=ABCD",
            "Bonus Barrel - Oil Drum Alley=AB31",
            "Bonus Barrel - Platform Perils #1=AB7F",
            "Bonus Barrel - Platform Perils #2=ABE7",
            "Bonus Barrel - Reptile Rumble #2=ADD9",
            "Bonus Barrel - Rope-Bridge Rumble #1=AE23",
            "Bonus Barrel - Rope-Bridge Rumble #2=AE09",
            "Bonus Barrel - Ropey Rampage=AB65",
            "Bonus Barrel - Slipslide Ride=ADBF",
            "Bonus Barrel - Snow Barrel Blast #1=AC69",
            "Bonus Barrel - Snow Barrel Blast #2=AC83",
            "Bonus Barrel - Snow Barrel Blast #3=AC9D",
            "Bonus Barrel - Stop & Go Station #2=AC35",
            "Bonus Barrel - Tanked Up Trouble=ACD1",
            "Bonus Barrel - Temple Tempest #2=ACEB",
            "Bonus Barrel - Tree Top Town #1=AD8B",
            "Bonus Barrel - Tree Top Town #2=AD71",
            "Bonus Barrel - Trick Track Trek #1=AC01",
            "Bonus Barrel - Trick Track Trek #2=ACB7",
            "Bonus Barrel - Trick Track Trek #3=AC1B",
            "Bonus Barrel - Vulture Culture #1=ADA5",
            "Bonus Barrel - Winky's Walkway=AE57",
            "Bonus Exit Hole - Bouncy Bonanza #1=F093",
            "Bonus Exit Hole - Loopy Lights #2=F0BF",
            "Bonus Exit Hole - Manic Mincers #2=F0A9",
            "Bonus Exit Hole - Reptile Rumble #1=F067",
            "Bonus Exit Hole - Reptile Rumble #3=F07D",
            "Bonus Exit Wall - Barrel Cannon Canyon #1=F0E7",
            "Bonus Exit Wall - Barrel Cannon Canyon #2=F0FD",
            "Bonus Exit Wall - Jungle Hijinx #1=F113",
            "Bonus Exit Wall - Orang-utan Gang #5=F13F",
            "Bonus Exit Wall - Ropey Rampage #1=F129",
            "Bonus Wall - Barrel Cannon Canyon #1=EE67",
            "Bonus Wall - Barrel Cannon Canyon #2=EE79",
            "Bonus Wall - Blackout Basement #2=EEE5",
            "Bonus Wall - Forest Frenzy #2=EF3F",
            "Bonus Wall - Jungle Hijinx #1=EE0D",
            "Bonus Wall - Jungle Hijinx #2=EE1F",
            "Bonus Wall - Millstone Mayhem #3=EEF7",
            "Bonus Wall - Oil Drum Alley #2=EED3",
            "Bonus Wall - Oil Drum Alley #3=EEC1",
            "Bonus Wall - Oil Drum Alley #4=EEAF",
            "Bonus Wall - Orang-utan Gang #2=EE31",
            "Bonus Wall - Orang-utan Gang #3=EE9D",
            "Bonus Wall - Orang-utan Gang #4=EE43",
            "Bonus Wall - Orang-utan Gang #5=EE55",
            "Bonus Wall - Ropey Rampage #1=EE8B",
            "Bonus Wall - Slipslide Ride #1=EF51",
            "Bonus Wall - Slipslide Ride #2=EF63",
            "Bonus Wall - Temple Tempest #1=EF09",
            "Bonus Wall - Vulture Culture #2=EF1B",
            "Bonus Wall - Vulture Culture #3=EF2D",
            "Hidden Bonus - Bouncy Bonanza #1=ED7D",
            "Hidden Bonus - Loopy Lights #2=EDD7",
            "Hidden Bonus - Manic Mincers #1=ED8F",
            "Hidden Bonus - Manic Mincers #2=EDA1",
            "Hidden Bonus - Misty Mine=EDB3",
            "Hidden Bonus - Reptile Rumble #1=ED59",
            "Hidden Bonus - Reptile Rumble #3=ED6B",
            "Hidden Bonus - Stop & Go Station #1=EDC5",
            "Hidden Bonus - Torchlight Trouble #1=EDE9",
            "Hidden Bonus - Torchlight Trouble #2=EDFB",
            "",
            "Bosses:",
            "Very Gnawty=F841",
            "Master Necky=FA61",
            "Queen B.=F9BB",
            "Really Gnawty=F865",
            "Boss Dumb Drum=F90D",
            "Master Necky Snr.=FAAF",
            "King K. Rool=FC55",
            "",
            "Checkpoints:",
            "Checkpoint Barrel - Barrel Cannon Canyon=B6F1",
            "Checkpoint Barrel - Blackout Basement=B7A5",
            "Checkpoint Barrel - Bouncy Bonanza=B6E7",
            "Checkpoint Barrel - Clam City=B813",
            "Checkpoint Barrel - Coral Capers=B7EB",
            "Checkpoint Barrel - Croctopus Chase=B791",
            "Checkpoint Barrel - Elevator Antics=B705",
            "Checkpoint Barrel - Forest Frenzy=B7FF",
            "Checkpoint Barrel - Ice Age Alley=B7C3",
            "Checkpoint Barrel - Jungle Hijinx=B70F",
            "Checkpoint Barrel - Loopy Lights=B787",
            "Checkpoint Barrel - Manic Mincers=B72D",
            "Checkpoint Barrel - Millstone Mayhem=B7AF",
            "Checkpoint Barrel - Mine Cart Carnage=B755",
            "Checkpoint Barrel - Mine Cart Madness=B773",
            "Checkpoint Barrel - Misty Mine=B74B",
            "Checkpoint Barrel - Oil Drum Alley=B79B",
            "Checkpoint Barrel - Orang-utan Gang=B6FB",
            "Checkpoint Barrel - Platform Perils=B741",
            "Checkpoint Barrel - Poison Pond=B737",
            "Checkpoint Barrel - Reptile Rumble=B719",
            "Checkpoint Barrel - Rope Bridge Rumble=B7F5",
            "Checkpoint Barrel - Ropey Rampage=B6D3",
            "Checkpoint Barrel - Slipslide Ride=B7E1",
            "Checkpoint Barrel - Snow Barrel Blast=B723",
            "Checkpoint Barrel - Stop & Go Station=B77D",
            "Checkpoint Barrel - Tanked Up Trouble=B769",
            "Checkpoint Barrel - Temple Tempest=B7B9",
            "Checkpoint Barrel - Torchlight Trouble=B6DD",
            "Checkpoint Barrel - Tree Top Town=B7CD",
            "Checkpoint Barrel - Trick Track Trek=B75F",
            "Checkpoint Barrel - Vulture Culture=B7D7",
            "Checkpoint Barrel - Winky's Walkway=B809",
            "",
            "Coal Elevators:",
            "Coal Elevators #1 (Elevator Antics)=B62B",
            "Coal Elevators #2 (Elevator Antics)=B635",
            "Coal Elevators #3 (Elevator Antics)=B63F",
            "Coal Elevators #4 (Elevator Antics)=B649",
            "Coal Elevators #5 (Elevator Antics)=B653",
            "Coal Elevators #6 (Elevator Antics)=B65D",
            "Coal Elevators #7 (Elevator Antics)=B667",
            "Coal Elevators #8 (Elevator Antics)=B671",
            "Coal Elevators #9 (Elevator Antics)=B67B",
            "",
            "Collectibles:",
            "Banana Bunch=A51F",
            "Extra-Life Balloon, Blue (float away)=E5FF",
            "Extra-Life Balloon, Blue=E615",
            "Extra-Life Balloon, Green (float away)=E5D1",
            "Extra-Life Balloon, Green=E5E7",
            "Extra-Life Balloon, Red (float away)=E5A3",
            "Extra-Life Balloon, Red=E5B9",
            "Golden Letter, G=A575",
            "Golden Letter, K=A551",
            "Golden Letter, N=A569",
            "Golden Letter, O=A55D",
            "Golden Token, Enguarde=A5B7",
            "Golden Token, Expresso=A5AD",
            "Golden Token, Rambi=A599",
            "Golden Token, Winky=A5A3",
            "",
            "Fuel:",
            "Fuel Drum - 1 Unit=E047",
            "Fuel Drum - 3 Units=E063",
            "Fuel Drum - 5 Units=E071",
            "Fueled Platform #1 (Tanked Up Trouble)=E07F",
            "Fueled Platform #2 (Tanked Up Trouble)=E095",
            "",
            "Gnawty:",
            "Gnawty (constant movement)=B413",
            "Gnawty (move b/f backward)=BB77",
            "Gnawty (move b/f backward, very slow)=BB65",
            "Gnawty (wait, then walk backward)=B427",
            "Gnawty (wait, then walk backward)=B439",
            "Gnawty (wait, then walk backward)=B45D",
            "Gnawty (wait, then walk foward)=B44B",
            "Gnawty (walking b/f)=B405",
            "Gnawty (walking b/f, short)=B3F7",
            "",
            "Item Cache:",
            "Item Cache {Banana Bunch} (Loopy Lights)=B685",
            "Item Cache {Banana Bunch} (ground slappable)=9A6B",
            "Item Cache {Barrel} (Alt)=9AEF",
            "Item Cache {Barrel}=9AE5",
            "Item Cache {DK Barrel}=9AFD",
            "Item Cache {Golden Letter, G} (Alt)=9AA1",
            "Item Cache {Golden Letter, G}=9A97",
            "Item Cache {Golden Letter, K}=9A79",
            "Item Cache {Golden Letter, N}=9A8D",
            "Item Cache {Golden Letter, O}=9A83",
            "Item Cache {Golden Token, Enguarde}=9AC3",
            "Item Cache {Golden Token, Winky}=9B47",
            "Item Cache {Pushable Tire, Old}=9B29",
            "Item Cache {Pushable Tire}=9B33",
            "Item Cache {Steel Keg}=9ADB",
            "Item Cache {TNT Barrel}=9B15",
            "Hidden Item Cache {Bunch/1UP}=9A61",
            "",
            "Klaptrap:",
            "Klaptrap (move R/L, 8 tiles, centered)=9603",
            "Klaptrap (move R/L, ~9 tiles, ~2 left from coord)=9619",
            "Klaptrap (move right constantly)=9711",
            "Klaptrap (wait, then walk)=9735",
            "Klaptrap (walking b/f backward)=9665",
            "Klaptrap (walking b/f backward, short)=96BF",
            "Klaptrap (walking b/f foward)=9641",
            "Klaptrap (walking b/f foward, long)=9689",
            "Klaptrap (walking b/f semi-backward)=96D1",
            "Klaptrap (walking b/f semi-foward)=96E3",
            "Klaptrap (walking b/f, short)=96AD",
            "Klaptrap=96F5",
            "Klaptrap=9703",
            "",
            "Purple Klaptrap (stationary)=97F3",
            "Purple Klaptrap=97D1",
            "Purple Klaptrap=97DB",
            "",
            "Klump:",
            "Klump (move b/f backward)=BB9F",
            "Klump (wait, then walk backward)=98C1",
            "Klump (wait, then walk foward)=98D3",
            "Klump (walking b/f backward)=9963",
            "Klump (walking b/f backward, long)=997F",
            "Klump (walking b/f backward, short)=999B",
            "Klump (walking b/f foward, long)=998D",
            "Klump (walking b/f, long)=9955",
            "Klump (walking b/f, short)=9971",
            "Klump (walking backward)=98E5",
            "Klump (walking foward)=98B3",
            "",
            "Kritter:",
            "Kritter, Blue (blue, small hops right)=9C39",
            "Kritter, Blue (high jumps foward)=9C15",
            "Kritter, Blue (jumps foward)=9C4F",
            "Kritter, Blue (short jumps foward)=9C27",
            "Kritter, Blue (walk backward then jump)=9C61",
            "Kritter, Blue (walk foward then jump)=9C7F",
            "Kritter, Brown (jumping)=958D",
            "Kritter, Gold (leaping b/f, backward)=9BBF",
            "Kritter, Gold (leaping b/f, foward)=9BD1",
            "Kritter, Gold, w/Arms Up (leaping b/f backward)=9BAD",
            "Kritter, Gold, w/Arms Up (leaping b/f backward, fast)=9B9F",
            "Kritter, Gold, w/Arms Up (leaping b/f foward)=9B83",
            "Kritter, Green (walking b/f backward)=A4BD",
            "Kritter, Green (walking b/f backward, long)=A503",
            "Kritter, Green (walking b/f backward, short)=A493",
            "Kritter, Green (walking b/f backward, short)=A4D9",
            "Kritter, Green (walking b/f foward, very long)=A4E7",
            "Kritter, Green (walking b/f semi-backward)=A511",
            "Kritter, Green (walking b/f)=9443",
            "Kritter, Green (walking b/f)=A485",
            "Kritter, Green (walking b/f, short)=A4CB",
            "Kritter, Green (walking b/f, very long)=A4F5",
            "Kritter, Green=94ED",
            "Kritter, Grey (jumping foward)=953B",
            "",
            "Krusha:",
            "Krusha (walking b/f backward)=B53D",
            "Krusha (walking b/f semi-foward, very long)=B559",
            "Krusha (walking b/f backward, short)=B575",
            "Krusha (walking b/f backward, short)=B587",
            "Krusha (constant movement)=B5BD",
            "Krusha (constant movement)=B5CB",
            "Krusha (wait, then walk backward)=B5E3",
            "Grey Krusha (walking b/f backward, short)=B5AB",
            "Grey Krusha (move b/f backward)=BB89",
            "",
            "Level Exit:",
            "LEVEL EXIT - Barrel Cannon Canyon=EA6B",
            "LEVEL EXIT - Blackout Basement=EA07",
            "LEVEL EXIT - Bouncy Bonanza, Stop & Go Station=E953",
            "LEVEL EXIT - Clam City=EAA7",
            "LEVEL EXIT - Coral Capers=EAB1",
            "LEVEL EXIT - Croctopus Chase=EABB",
            "LEVEL EXIT - Forest Frenzy=E98F",
            "LEVEL EXIT - Ice Age Alley=E967",
            "LEVEL EXIT - Jungle Hijinxs=E8C7",
            "LEVEL EXIT - Loopy Lights=EA7F",
            "LEVEL EXIT - Manic Mincers=E8BD",
            "LEVEL EXIT - Millstone Mayhem=EA2F",
            "LEVEL EXIT - Mine Cart Carnage (Exit via Minecart Only)=EAC5",
            "LEVEL EXIT - Mine Cart Madness=EA57",
            "LEVEL EXIT - Misty Mine=EA61",
            "LEVEL EXIT - Oil Drum Alley=E93F",
            "LEVEL EXIT - Orang-utan Gang=EA39",
            "LEVEL EXIT - Platform Perils=E92B",
            "LEVEL EXIT - Poison Pond=EA9D",
            "LEVEL EXIT - Reptile Rumble=E9DF",
            "LEVEL EXIT - Rope Bridge Rumble=E9FD",
            "LEVEL EXIT - Ropey Rampage=EA25",
            "LEVEL EXIT - Slipslide Ride=E9CB",
            "LEVEL EXIT - Snow Barrel Blast=E999",
            "LEVEL EXIT - Tanked Up Trouble=E8DB",
            "LEVEL EXIT - Temple Tempest0+00=EA89",
            "LEVEL EXIT - Torchlight Trouble=E8E5",
            "LEVEL EXIT - Trick Track Trek, Elevator Antics=E903",
            "LEVEL EXIT - Vulture Culture, Tree Top Town=E9AD",
            "LEVEL EXIT - Winky's Walkway=E935",
            "",
            "Manky:",
            "Manky Kong (fast)=BDB3",
            "Manky Kong (fast, fast-moving barrels)=BDBD",
            "Manky Kong (fast-moving barrels)=BDEF",
            "Manky Kong (slow)=BD95",
            "Manky Kong (three consecutive barrels)=BDE5",
            "Manky Kong (very slow-moving barrels)=BD9F",
            "Manky Kong=BDA9",
            "",
            "Barrel, Rolling Left=E3E9",
            "",
            "Mincer:",
            "Mincer (arch up b/f, very long, fast)=B0F7",
            "Mincer (move b/f backward)=B31D",
            "Mincer (move b/f foward)=B2D7",
            "Mincer (move b/f, backward, long)=B2AD",
            "Mincer (move b/f, backward, long, slow)=B2BB",
            "Mincer (move b/f, semi-backward)=B29F",
            "Mincer (move b/f, semi-backward)=B339",
            "Mincer (move up/down upward)=B19B",
            "Mincer (move up/down upward, short)=B20B",
            "Mincer (move up/down upward, slow)=B17F",
            "Mincer (move up/down, slow)=B1B7",
            "Mincer (move up/down, very long)=B1EF",
            "Mincer (move up/down, very short)=B227",
            "Mincer (move up/down, very very long)=B1FD",
            "Mincer, Move Left/Right (long)=B2F3",
            "Mincer, Move Left/Right (long, faster, off-center)=B30F",
            "Mincer, Move Left/Right (very long)=B2E5",
            "Mincer, Move Left/Right (very long, faster)=B301",
            "Mincer, Move Up/Down (Centered, shorter, faster)=B1E1",
            "Mincer, Move Up/Down (Centered, tall)=B163",
            "Mincer, Move Up/Down (Centered, tall, very slow)=DFD9",
            "Mincer, Move Up/Down (up from coord)=B219",
            "Mincer, Revolve (Fwd) (very wide)=AFD3",
            "Mincer, Revolve (Fwd) <Init #1>=AF79",
            "Mincer, Revolve (Fwd) <Init #2>=AFC1",
            "Mincer, Revolve (Rev) (fast)=AF67",
            "Mincer, Revolve (Rev) (short)=B087",
            "Mincer, Revolve (Rev) (short, fast)=B01B",
            "Mincer, Revolve (Rev) (slow)=B099",
            "Mincer, Revolve (Rev) (slow, very long) <Init #1>=B02D",
            "Mincer, Revolve (Rev) (slow, very long) <Init #2>=B03F",
            "Mincer, Revolve (Rev) (slow, very long) <Init #3>=B051",
            "Mincer, Revolve (Rev) (very wide)=B063",
            "Mincer, Revolve (Rev) <Init #1>=AF55",
            "Mincer, Revolve (Rev) <Init #2>=AF8B",
            "Mincer, Revolve (Rev) <Init #3>=AF9D",
            "Mincer, Stationary=B155",
            "",
            "Mine cart:",
            "Mine Cart (jump out of cart)=C667",
            "Krash (Stationary)=C675",
            "Mine Cart (jump with cart)=C683",
            "Mine Cart (derailed)=C691",
            "Krash=C69F",
            "Krash (???)=C6AD",
            "",
            "Mini-Drum:",
            "Mini-Drum {Army} (shot up high)=C58F",
            "Mini-Drum {Army}=C585",
            "Mini-Drum {Gnawty}=C56D",
            "Mini-Drum {Gnawty}=C577",
            "Mini-Drum {Klaptrap}=C559",
            "Mini-Drum {Slippa} (behind only)=C599",
            "Mini-Drum {Slippa}=C4E5",
            "Mini-Drum {Slippa}=C51B",
            "",
            "Mini-Necky:",
            "Mini-Necky (inch upward a few times)=B895",
            "Mini-Necky (move up once)=B881",
            "Mini-Necky (move up/down shoot 2 nuts)=B8B3",
            "Mini-Necky (move up/down shoot 2 nuts, diff init)=B8BD",
            "Mini-Necky (move up/down shoot 3 nuts)=B84F",
            "Mini-Necky (move up/down shoot 3 nuts, 2nd nut shot earlier)=B859",
            "Mini-Necky (move upwards) (shoot nuts)=B863",
            "Mini-Necky (move upwards) (shoot nuts, fast)=B89F",
            "Mini-Necky (move upwards) (shoot nuts, slightly faster)=B88B",
            "Mini-Necky (move upwards) (shoot nuts, slow)=B8C7",
            "Mini-Necky (move upwards) (shoot nuts, very slow)=B8D5",
            "Mini-Necky (stationary) (shoot nuts)=B86D",
            "",
            "Necky:",
            "Necky (constant movement)=BD37",
            "Necky (constant movement, fast)=BD45",
            "Necky (constant movement, very slow)=BD29",
            "Necky (move b/f)=BD17",
            "Necky (move b/f, short)=BD05",
            "Necky (move up/down semi-upward, short)=BCAB",
            "Necky (move up/down)=BC99",
            "Necky (move up/down, long)=BC87",
            "Necky (move up/down, short)=BCBD",
            "Necky (move up/down, slower)=BCCF",
            "Necky (revolve upward)=BC63",
            "Necky (revolve upward, slower)=BC75",
            "Necky (stationary)=BD61",
            "Necky Nut Thrown Leftwards=91FD",
            "",
            "Oil Drum:",
            "OIL Drum (constant flame)=E667",
            "OIL Drum (interval between flame rise)=E671",
            "OIL Drum (rapid flame rise)=E67B",
            "",
            "Perched Necky:",
            "Perched Necky (1 nut rightwards, steady pace)=C721",
            "Perched Necky (1 nut, brisk pace)=C753",
            "Perched Necky (1 nut, fast pace)=C735",
            "Perched Necky (1 nut, steady pace)=C749",
            "Perched Necky (3 nuts, brisk pace)=C75D",
            "Perched Necky (3 nuts, fast pace)=C73F",
            "Perched Necky (3 nuts, steady pace)=C703",
            "",
            "Platforms:",
            "Arrow Platform [Down] (falls immediately)=BA5B",
            "Arrow Platform [Down] (long)=BA31",
            "Arrow Platform [Down] (long, fast)=BA3F",
            "Arrow Platform [Down] (long, fast)=BA4D",
            "Arrow Platform [Down] (shakes/falls)=B967",
            "Arrow Platform [Down] (slower)=B9F9",
            "Arrow Platform [Down] (very short)=BA23",
            "Arrow Platform [Down] (very slow, long)=BA07",
            "Arrow Platform [Down] (very slow, very short)=BA15",
            "Arrow Platform [Down]=B9EB",
            "Arrow Platform [Left] (constant)=BA77",
            "Arrow Platform [Left]=BA69",
            "Arrow Platform [Right] (fast, shorter)=BACB",
            "Arrow Platform [Right] (semi-short)=BB57",
            "Arrow Platform [Right] (short)=BB2D",
            "Arrow Platform [Right] (slow)=BA85",
            "Arrow Platform [Right] (slow, long)=BAF5",
            "Arrow Platform [Right] (slow, shorter)=BAAF",
            "Arrow Platform [Right] (slow, shorter)=BABD",
            "Arrow Platform [Right] (very slow, long)=BAD9",
            "Arrow Platform [Right]=BA93",
            "Arrow Platform [Right]=BB03",
            "Arrow Platform [Up] (even faster)=B9C1",
            "Arrow Platform [Up] (faster)=B9B3",
            "Arrow Platform [Up] (much faster)=B9CF",
            "Arrow Platform [Up] (much faster, more)=B9DD",
            "Arrow Platform [Up]=B9A5",
            "",
            "Cave/Temple Platform (fake)=A627",
            "Cave/Temple Platform (hovering up/down upward, slow)=A77F",
            "Cave/Temple Platform (hovering up/down)=A7A1",
            "Cave/Temple Platform (moving b/f backward)=A64D",
            "Cave/Temple Platform (moving b/f semi-backward)=A66F",
            "Cave/Temple Platform (moving b/f semi-backward)=A6D5",
            "Cave/Temple Platform (moving b/f semi-backward)=A6F7",
            "Cave/Temple Platform (moving b/f semi-backward)=A719",
            "Cave/Temple Platform (moving b/f semi-backward, slow)=A75D",
            "Cave/Temple Platform (moving b/f semi-backward, very long, fast)=A6B3",
            "Cave/Temple Platform (moving b/f, fast)=A691",
            "Cave/Temple Platform=A5DB",
            "Cave/Temple Platform=A605",
            "",
            "Factory Platform (fake)=A99B",
            "Factory Platform (moving b/f semi-backward)=A9C5",
            "Factory Platform (moving b/f semi-backward, short)=A9EB",
            "Factory Platform (moving b/f semi-backward, slow)=AA11",
            "Factory Platform (moving up/down upward)=AA5D",
            "Factory Platform (moving up/down)=AA37",
            "Factory Platform=A96D",
            "",
            "Mineshaft Platform (fake)=A813",
            "Mineshaft Platform (moving b/f backward)=A889",
            "Mineshaft Platform (moving b/f backward, shorter)=A8D5",
            "Mineshaft Platform (moving b/f semi-backward)=A83D",
            "Mineshaft Platform (moving b/f semi-backward, faster)=A863",
            "Mineshaft Platform (moving b/f semi-foward)=A8AF",
            "Mineshaft Platform (moving b/f)=A8FB",
            "Mineshaft Platform (moving up/down downward)=A947",
            "Mineshaft Platform (moving up/down upward)=A921",
            "Mineshaft Platform=A7E5",
            "",
            "Rooms:",
            "ROOM ENTRANCE - Kong's Banana Hoard=ED19",
            "ROOM ENTRANCE - Kong's Cabin=ED39",
            "ROOM ENTRANCE - Manic Mincers Room=ED0B",
            "ROOM ENTRANCE - Winky Room (Bouncy Bonanza)=ECB5",
            "ROOM EXIT - Manic Mincers Room=E9A3",
            "",
            "Red Gnawty on Millstone:",
            "Red Gnawty on Millstone; move up/down (faster)=F7B9",
            "Red Gnawty on Millstone; move up/down (slower)=F7AB",
            "Red Gnawty on Millstone; move up/down (very fast)=F7C7",
            "Red Gnawty on Millstone; move up/down=F79D",
            "Red Gnawty on Millstone; moving left/right (longer)=F781",
            "Red Gnawty on Millstone; moving left/right (shorter)=F773",
            "Red Gnawty on Millstone; moving left/right=F78F",
            "Red Gnawty on Millstone=F7D5",
            "Red Gnawty on Millstone=F7E7",
            "Red Gnawty on Millstone=F7F9",
            "Red Gnawty on Millstone=F80B",
            "Red Gnawty on Millstone=F81D",
            "Red Gnawty on Millstone=F82F",
            "",
            "Rockkroc:",
            "Rockkroc (move b/f)=BBDD",
            "Rockkroc (running b/f backward, long)=E4D3",
            "Rockkroc (running b/f foward)=E4E1",
            "Rockkroc (running b/f)=E4B7",
            "Rockkroc (running b/f)=E527",
            "Rockkroc (running b/f, short)=E4C5",
            "Rockkroc (running b/f, short)=E4FD",
            "Rockkroc (running b/f, very short)=E4EF",
            "",
            "Rope:",
            "Rope (Hangs In-Place)=BF0B",
            "Rope (Hangs In-Place)=BF1D",
            "Rope (moves left when grabbed;  ~6 tiles)=BFFD",
            "Rope (moves right when grabbed;  ~5 tiles)=C017",
            "Rope (moves right when grabbed;  ~6 tiles, off-center)=BF7B",
            "Rope (moves right when grabbed;  ~6 tiles, slow)=C031",
            "Rope (moves right when grabbed;  ~8 tiles, fast)=BF95",
            "Rope (moves right when grabbed; ~11 tiles)=C099",
            "Rope (moves right when grabbed; ~12 tiles)=BFAF",
            "Rope (moves right when grabbed; ~14 tiles)=BFC9",
            "Rope (moves right when grabbed; ~35 tiles)=C0B3",
            "Rope (moves right when grabbed; ~37 tiles)=C04B",
            "Rope (moves right when grabbed; ~45 tiles)=BFE3",
            "Rope (moves right when grabbed; ~90 tiles)=C07F",
            "Rope (moving b/f backward)=BF33",
            "Rope (moving b/f)=BF45",
            "Rope (moving b/f, very long, fast)=BF69",
            "",
            "Swinging Rope; Wait for Grab (???)=A41B",
            "Swinging Rope; Wait for Grab=A411",
            "Swinging Rope=A3BD",
            "",
            "Iced Rope, Blue (Hangs In-Place)=BE91",
            "Iced Rope, Blue (slow)=BEA9",
            "Iced Rope, Blue (slow)=BEB7",
            "Iced Rope, Blue [Zero Movement]=BE9B",
            "Iced Rope, Purple (Hangs In-Place)=BEFD",
            "Iced Rope, Purple (moves a little when grabbed)=BE77",
            "Iced Rope, Purple (slow)=BEEF",
            "Iced Rope, Purple=BEC5",
            "",
            "Slippa:",
            "Slippa (fast)=9CD9",
            "Slippa (slow)=9CCF",
            "Slippa=9CE3",
            "",
            "Switch Barrel:",
            "Switch Barrel (Themed)=E70F",
            "Switch Barrel (Themed)=E719",
            "Switch Barrel (Themed)=E723",
            "Switch Barrel (Themed)=E72D",
            "Switch Barrel (Themed)=E737",
            "Switch Barrel (Themed)=E741",
            "Switch Barrel (Themed)=E74B",
            "Switch Barrel (Themed)=E755",
            "Switch Barrel (Themed)=E75F",
            "Switch Barrel (Themed)=E769",
            "Switch Barrel (Themed)=E773",
            "Switch Barrel (Themed)=E77D",
            "Switch Barrel (Themed)=E787",
            "Switch Barrel (Themed)=E791",
            "Switch Barrel (Themed)=E79B",
            "Switch Barrel (Themed)=E7A5",
            "Switch Barrel (Themed)=E7AF",
            "Switch Barrel (Themed)=E7B9",
            "Switch Barrel (Themed)=E7C3",
            "Switch Barrel (Themed)=E7CD",
            "Switch Barrel (Themed)=E7D7",
            "Switch Barrel (Themed)=E7E1",
            "Switch Barrel (Themed)=E7EB",
            "Switch Barrel (Themed)=E7F5",
            "Switch Barrel (Themed)=E7FF",
            "Switch Barrel (Themed)=E809",
            "Switch Barrel (Themed)=E813",
            "Switch Barrel (Themed)=E81D",
            "Switch Barrel (Themed)=E827",
            "Switch Barrel (Themed)=E831",
            "Switch Barrel (Themed)=E83B",
            "Switch Barrel (Themed)=E845",
            "Switch Barrel (Themed)=E84F",
            "Switch Barrel (Themed)=E859",
            "Switch Barrel (Themed)=E863",
            "Switch Barrel (Themed)=E86D",
            "Switch Barrel (Themed)=E877",
            "Switch Barrel (Themed)=E881",
            "Switch Barrel (Themed)=E88B",
            "",
            "",
            "Tire:",
            "Pushable Tire, Old=915F",
            "Pushable Tire=9155",
            "Half-Buried Tire, Old (Low Velocity + Gravity, Bouncy Bonanza Only)=9103",
            "Half-Buried Tire, Old (Upside-Down)=90E5",
            "Half-Buried Tire, Old=907F",
            "Half-Buried Tire, Old=90C3",
            "Half-Buried Tire=90A1",
            "Floating Tire (Force Collisions From Below)=9033",
            "Floating Tire, Old=9055",
            "Floating Tire=9071",
            "",
            "Triggers:",
            "TIMER TRIGGER - Blue Balloon (Snow Barrel Blast)=04E0",
            "TIMER TRIGGER - Red Balloon (Temple Tempest Bonus #1)=00B0",
            "TIMER TRIGGER - Warp Barrel (Vulture Culture)=0230",
            "TRIGGER - Blackout Basement=E6BD",
            "TRIGGER - Clear Weather (Snow Glaciers)=FD76",
            "TRIGGER - Fog #1 (Misty Mine)=FD31",
            "TRIGGER - Fog #2 (Misty Mine)=FD38",
            "TRIGGER - Full Blizzard (Snow Glaciers)=FD99",
            "TRIGGER - Incoming Blizzard L1 (Snow Glaciers)=FD7D",
            "TRIGGER - Incoming Blizzard L2 (Snow Glaciers)=FD84",
            "TRIGGER - Incoming Blizzard L3 (Snow Glaciers)=FD8B",
            "TRIGGER - Incoming Blizzard L4 (Snow Glaciers)=FD92",
            "TRIGGER - Night/Day (Jungles)=FD50",
            "TRIGGER - Stop & Go Station, Loopy Lights=E69F",
            "TRIGGER - Sunrise/End-Storm Part 1 (Ropey Rampage) =FDB3",
            "TRIGGER - Sunrise/End-Storm Part 2 (Ropey Rampage) =FD46",
            "TRIGGER - Sunrise/End-Storm Part 3 (Ropey Rampage) =FD63",
            "",
            "Track Platform:",
            "Track Platform #1 (Trick Track Trek)=E0AB",
            "Track Platform #2 (Trick Track Trek)=E0C1",
            "Track Platform (Trick Track Trek Bonus #1)=E0D7",
            "",
            "Underwater Fake Wall:",
            "UNDERWATER FAKE WALL - Clam City #1=E363",
            "UNDERWATER FAKE WALL - Coral Capers #1=E2F7",
            "UNDERWATER FAKE WALL - Coral Capers #2=E309",
            "UNDERWATER FAKE WALL - Croctopus Chase #1=E2E5",
            "UNDERWATER FAKE WALL - Croctopus Chase #2=E2D3",
            "UNDERWATER FAKE WALL - Enguarde Bonus East Area=E33F",
            "UNDERWATER FAKE WALL - Enguarde Bonus North Area=E351",
            "UNDERWATER FAKE WALL - Enguarde Bonus South Area=E31B",
            "UNDERWATER FAKE WALL - Enguarde Bonus West Area=E32D",
            "UNDERWATER FAKE WALL - Poison Pond #1=E29D",
            "UNDERWATER FAKE WALL - Poison Pond #2=E2AF",
            "UNDERWATER FAKE WALL - Poison Pond #3=E2C1",
            "",
            "Vertical Level Script:",
            "Vertical Level Script (Clam City)=F17C",
            "Vertical Level Script (Coral Capers)=E5FA",
            "Vertical Level Script (Croctopus Chase)=A7BE",
            "Vertical Level Script (Poison Pond)=A584",
            "Vertical Level Script (Slipslide Ride)=D9A0",
            "",
            "Warp:",
            "WARP ENTRANCE - Stop & Go Station=ED4B",
            "Warp Barrel - Millstone Mayhem=AEB5",
            "Warp Barrel - Mine Cart Carnage=ADF3",
            "Warp Barrel - Slipslide Ride=AE71",
            "Warp Barrel - Tree Top Town=AE9F",
            "Warp Barrel - Trick Track Trek=AECB",
            "Warp Barrel - Vulture Culture (Time-Limit, DK Only)=AE89",
            "",
            "Water Enemies:",
            "Bitesize (move L/R, 2 tiles, centered)=C32D",
            "Bitesize (move L/R, 5 tiles, left from coord)=C31B",
            "Bitesize (move L/R, 7 tiles, left from coord)=C309",
            "Bitesize (move L/R, 8 tiles, right from coord)=C2E5",
            "Bitesize (moving left)=C3BF",
            "Bitesize (moving left, fast)=C437",
            "Bitesize (moving left, semi-fast)=C449",
            "Bitesize (moving left, slow)=C3E3",
            "Bitesize (moving left, very fast)=C46D",
            "Bitesize (moving right)=C421",
            "Bitesize (moving right, slow)=C40B",
            "Bitesize (moving right, very slow)=C3F5",
            "",
            "Blue Croctopus (just sits there?)=E1E9",
            "Blue Croctopus (move left then down into obscurity)=E1B3",
            "Blue Croctopus (move left then up into obscurity)=E1D7",
            "Blue Croctopus (move up, left, then up)=E159",
            "Blue Croctopus=E123",
            "Blue Croctopus=E135",
            "Blue Croctopus=E147",
            "Blue Croctopus=E16B",
            "Blue Croctopus=E17D",
            "Blue Croctopus=E18F",
            "Blue Croctopus=E1A1",
            "Blue Croctopus=E1C5",
            "Blue Croctopus=E1FB",
            "",
            "Chomps (move L/R)=C1F3",
            "Chomps (move L/R)=C201",
            "Chomps (moving b/f)=C1E5",
            "Chomps (moving b/f)=C213",
            "Chomps (moving left)=C34D",
            "Chomps (moving right)=C35B",
            "",
            "Chomps Jr. (move L/R, ~2.5 tiles)=C281",
            "Chomps Jr. (move L/R, ~3 tiles)=C273",
            "Chomps Jr. (move L/R, ~4 tiles)=C265",
            "Chomps Jr. (move L/R, ~8 tiles)=C257",
            "Chomps Jr. (moving b/f)=C293",
            "Chomps Jr. (moving left constantly)=C38D",
            "Chomps Jr. (moving right)=C39F",
            "",
            "Clambo (1 pearl, left)=E46B",
            "Clambo (1 pearl, right)=E475",
            "Clambo (1 pearl, up-left)=E461",
            "Clambo (2 pearls, V left)=E457",
            "Clambo (2 pearls, V right)=E449",
            "Clambo (2 pearls, V up)=E42B",
            "Clambo (3 pearls, T up)=E421",
            "Clambo (5 pearls, down)=E43F",
            "Clambo (5 pearls, up)=E435",
            "",
            "Purple Croctopus (move around square border downward)=E231",
            "Purple Croctopus=E20D",
            "Purple Croctopus=E21F",
            "Purple Croctopus=E24B",
            "Purple Croctopus=E26F",
            "",
            "Squidge (moving down, fast)=C159",
            "Squidge (moving left)=C17D",
            "Squidge (moving up)=C16B",
            "Squidge (moving up, fast)=C18F",
            "Squidge, Move Only Up-Left=C135",
            "Squidge, Move Only Up-Right=C123",
            "",
            "Zinger:",
            "Zinger=9D21",
            "Zinger (move up/down, long)=9D2F",
            "Zinger (slow, long)=9D3D",
            "Zinger (downward from coord)=9D4B",
            "Zinger (downward from coord, long)=9D59",
            "Zinger (slow, long)=9D75",
            "Zinger (slow)=9D83",
            "Zinger (fast, very long)=9D91",
            "Zinger (fast, long)=9D9F",
            "Zinger (upward from coord)=9DAD",
            "Zinger (fast, long)=9DBB",
            "Zinger (semi-downward from coord)=9DD7",
            "Zinger (semi-downward from coord, longer)=9DE5",
            "Zinger (semi-upward from coord, short)=9DF3",
            "Zinger (move up/down short)=9E01",
            "Zinger (slow, downward from coord)=9E1D",
            "Zinger (upward from coord, very long)=9E2B",
            "Zinger (upward from coord, slow)=9E45",
            "Zinger (down init, very long)=9E53",
            "Zinger (up init, very long)=9E61",
            "Orange Zinger (b/f backward, short)=9E95",
            "Orange Zinger (b/f, long)=9EC1",
            "Orange Zinger (b/f backward, long)=9ED7",
            "Orange Zinger (hover around in place)=9F19",
            "Orange Zinger (b/f backward, very long)=9F2F",
            "Orange Zinger (b/f forward, very long)=9F45",
            "Orange Zinger (b/f semi-backward, long)=9F5B",
            "Orange Zinger (hover)=9F71",
            "Orange Zinger (hover sideways in place)=9F87",
            "Orange Zinger (b/f backward)=9FB3",
            "Orange Zinger (b/f short)=9FC9",
            "Orange Zinger (b/f semi-short)=9FF5",
            "Orange Zinger (stationary)=A00B",
            "Orange Zinger (b/f backward, short)=A021",
            "Orange Zinger (move b/f fast, ~4 tiles, centered)=9F9D",
            "Red Zinger (revolve backward, long)=A0D5",
            "Red Zinger (revolve backward)=A0F9",
            "Red Zinger (revolve backward CC)=A12F",
            "Red Zinger (revolve backward CC, fast)=A141",
            "Red Zinger (revolve backward CC, very fast)=A153",
            "Red Zinger (revolve backward CC, slow)=A165",
            "Red Zinger (revolve backward)=A177",
            "Red Zinger (revolve backward, slow)=A189",
            "Red Zinger (revolve semi-backward, slow)=A19B",
            "Red Zinger (revolve semi-backward CC, slow)=A1AD",
            "Red Zinger (revolve backward CC, long)=A1BF",
            "Red Zinger (revolve backward CC, long, slow)=A1D1",
            "Red Zinger (revolve backward CC, long, a little faster)=A1E3",
            "Red Zinger (revolve backward CC, slow/smooth)=A1F5",
            "Red Zinger (revolve backward CC, very long, slow)=A207",
            "Red Zinger (revolve backward, very long, slow)=A219",
            "Red Zinger (revolve backward, fast) 1 faster=A22B",
            "Green Zinger (arch b/f backward)=A26F",
            "Green Zinger (arch b/f backward, short)=A285",
            "Green Zinger (arch b/f backward, long)=A29B",
            "Green Zinger (arch b/f backward, diff init)=A2B1",
            "Green Zinger (arch b/f backward, diff init)=A2C3",
            "Green Zinger (arch b/f backward, faster)=A2D5",
            "Green Zinger (downward arch)=A2E7",
            "Green Zinger (arch b/f backward, diff init)=A2FD",
            "Green Zinger (arch up/down)=A30F",
            "Green Zinger (arch up/down, facing left, FAST)=A319",
            "Green Zinger (arch up/down, faster)=A321",
            "Green Zinger (arch up/down, facing backward)=A333",
            "Green Zinger (arch b/f, faster, long)=A349",
            "",
            "BETA:",
            "Barrel, Rolling Right [BETA]=E3BB",
            "Steel Keg (Alt) [BETA]=9227",
            "Fuel Drum - 2 Units [BETA]=E055",
            "Mini-Drum {Slippa} (Upside-Down) [BETA]=C5A3",
            "Mini-Drum {Army} (Upside-Down) [BETA]=C5AD",
            "Mini-Drum {Army} (very long delays) (Upside-Down) [BETA]=C5B7",
            "Kritter, Green constant movement, jumps very high=99A9",
            "Kritter, Green constant movement, jumps very low=99E7",
            "Item Cache {Golden Token, Rambi}[BETA]=9AAB",
            "Item Cache {Golden Token, Expresso}[BETA]=9AB7",
            "Kritter, Gold (leaping b/f backward, 96px) [BETA]=9B91",
            "Kritter, Green (walking b/f centered, 30px) [BETA]=A4A1",
            "Kritter, Green (walking b/f centered, 300px) [BETA]=A4AF",
            "Zinger (top init, 140px) [BETA]=9DC9",
            "Orange Zinger (b/f centered, 100px) [BETA]=A037",
            "Mincer, Revolve (Rev) 110px, 30 frames/rotation [BETA]=B075",
            "Mincer (Move b/f) 235px, 8 pixels/frame [BETA]=B2C9",
            "Mincer (Move b/f) 440px, 8 pixels/frame [BETA]=B32B",
            "Gnawty (constant movement backwards) [BETA]=B41D",
            "Krusha (walking b/f backward, 150px) [BETA]=B521",
            "Krusha (walking b/f backward, 110px) [BETA]=B52F",
            "Krusha (walking b/f centered, 70px) [BETA]=B54B",
            "Krusha (walking b/f centered, 200px) [BETA]=B567",
            "Krusha (walking b/f centered, 40px) [BETA]=B599",
            "Mini-Necky (move vertical) (shoot nuts, 60 frames) [BETA]=B877",
            "Mini-Necky (move vertical) (shoot nuts, 45 frames) [BETA]=B8A9",
            "Arrow Platform [Right] 230px @ 2 pixels/frame [BETA]=BAA1",
            "Arrow Platform [Right] 370px @ 2 pixels/frame [BETA]=BAE7",
            "Arrow Platform [Right] 260px @ 2 pixels/frame [BETA]=BB11",
            "Arrow Platform [Right] 300px @ 2 pixels/frame [BETA]=BB1F",
            "Necky (move up/down 110px @ 8ppf) [BETA]=BCE1",
            "Necky (move b/f 160px @ 8ppf) [BETA]=BCF3",
            "Necky (move right endlessly @ 4ppf) [BETA],=BD53",
            "Manky Kong (3/4) [BETA]=BDC7",
            "Manky Kong (4, Wait Less Each Time) [BETA]=BDD1",
            "Manky Kong (2/4/2) [BETA]=BDDB",
            "Iced Rope, Purple Slower Drag [BETA]=BED3",
            "Iced Rope, Purple Slower Drag [BETA]=BEE1",
            "Rope [BETA] (moves b/f centered; 300px)=BF57",
            "Rope [BETA] (moves right when grabbed; 1150px)=C065",
            "Mini-Drum {Klaptrap} (front and back) [BETA]=C4FD",
            "Mini-Drum {Klaptraps x2} (front only) [BETA]=C507",
            "Mini-Drum {Armys x2} (front only) [BETA]=C511",
            "Perched Necky [BETA](5 nuts, steady pace)=C717",
            "Perched Necky [BETA](2 nuts, steady pace; Thrown Back then Down)=C72B",
            "Barrel Cannon (AutoFire) [Distance - 440px] [Moves FAST!] [BETA]=CA8D",
            "Rockkroc [BETA] (running b/f centered, 214px)=E50B",
            "Rockkroc [BETA] (running b/f centered, 40px)=E519",
            "",
            "Script sets:",
            "Script Pushable Tire, Old + Moving Platform w/Tire (Bouncy Bonanza)=87D4",
            "Script Set of 2 Arching Zingers (Bouncy Bonanza)=87F4",
            "Script Set of 2 Gold Kritters (Bouncy Bonanza)=8814",
            "Script Set of 4 Mini-Drums {Slippa}=8AA4",
            "Script ???=8BE8",
            "Script Manky Kong + Barrels #1 (Orang-utan Gang)=8FC4",
            "Script Manky Kong + Barrels #2 (Orang-utan Gang)=8FE4",
            "Script Manky Kong + Barrels #3 (Orang-utan Gang)=9004",
            "Script Manky Kong + Barrels #4 (Orang-utan Gang)=9044",
            "Script Manky Kong + Barrels #5 (Orang-utan Gang)=9064",
            "Script Manky Kong + Barrels #6 (Orang-utan Gang)=9084",
            "Script Revolving Mincers #1 (Manic Mincers)=93CC",
            "Script Revolving Mincers #2 (Manic Mincers)=93EC",
            "Script ???=9414",
            "Script Set of 3 Gnawtys (Jungle Hijinxs)=97F4",
            "Script Set of Barrel Cannons #1 (Barrel Cannon Canyon)=9BE4",
            "Script Set of Barrel Cannons #2 (Barrel Cannon Canyon)=9C0C",
            "Script Set of Barrel Cannons #3 w/Zigners (Barrel Cannon Canyon)=9C2C",
            "Script Set of Barrel Cannons #4 w/Zigner (Barrel Cannon Canyon)=9C64",
            "Script Set of Barrel Cannons #5 (Barrel Cannon Canyon)=9C8C",
            "Script Set of Barrel Cannons #6 w/Zigner (Barrel Cannon Canyon)=9CB4",
            "Script Set of 3 Zingers (Elevator Antics)=9F94",
            "Script Set of 2 Orange Zingers (Elevator Antics)=9FBC",
            "Script Set of 2 Klumps Walking Right (Elevator Antics)=9FDC",
            "Script ???=9FFC",
            "Script Set of Mincers #1 (Poison Pond)=A40C",
            "Script Set of Mincers #2 (Poison Pond)=A42C",
            "Script Set of Mincers #3 (Poison Pond)=A44C",
            "Script Set of Mincers #4 (Poison Pond)=A46C",
            "Script Set of Mincers #5 (Poison Pond)=A4B4",
            "Script Set of Mincers #6 (Poison Pond)=A4E4",
            "Script Set of Mincers #7 (Poison Pond)=A524",
            "Script Set of Mincers #8 (Poison Pond)=A544",
            "Script Set of Mincers #9 (Poison Pond)=A564",
            "Script Set of 3 Neckys (Snow Barrel Blast)=ABE8",
            "Script Set of 3 Klaptraps (Snow Barrel Blast)=AC10",
            "Script Manky Kong + Barrel (Trick Track Trek)=B5F0",
            "Script Manky Kong + Barrels (Trick Track Trek)=B610",
            "Script Set of 2 Neckys (Trick Track Trek)=B630",
            "Script Set of 2 Zingers (Tanked Up Trouble)=B9A0",
            "Script Set of 2 Rockkrocs #1=BCF8",
            "Script Set of 2 Rockkrocs #2=BD18",
            "Script Set of 1 Rockkroc (one missing?)=BD38",
            "Script Set of 2 Rockkrocs on Moving Platforms=BD50",
            "Script Set of 3 Klaptraps (Stop & Go Station)=BD80",
            "Script Set of 2 Rockkrocs #3=BDA8",
            "Script Set of 2 Rockkrocs #4=BDC8",
            "Script Set of 2 Rockkrocs #5=BDE8",
            "Script Set of 2 Rockkrocs #6=BE08",
            "Script Set of 2 Cave Platforms, Moving b/f (Loopy Lights)=C2C0",
            "Script Set of 2 Cave Platforms, Moving up/down (Loopy Lights)=C2E0",
            "Script Manky Kong + ??? (Loopy Lights)=C300",
            "Script Oil Barrel Set #1=C688",
            "Script Set of 3 Blue Kritters (Oil Drum Alley)=C708",
            "Script Oil Barrel Set #2=C730",
            "Script Oil Barrel Set #3=C750",
            "Script Manky Kong=C770",
            "Script Manky Kong (A little faster)=C790",
            "Script Manky Kong (Faces Kong, Fast)=C7B0",
            "Script Manky Kong (Faces Kong, Faster)=C7D0",
            "Script Manky Kong + Barrels (Oil Drum Alley)=C7F0",
            "Script Set of 2 Factory Platforms, Moving Up/Down (Blackout Basement)=CA28",
            "Script Set of 2 Factory Platforms, Moving b/f (Blackout Basement)=CA48",
            "Script Set of 4 Green Kritters (Blackout Basement)=CA68",
            "Script Manky Kong + Barrels (Blackout Basement)=CA98",
            "Script Set of 3 Mincers (moving up/down, FAST)=D9FA",
            "Script Set of 5 Barrel Cannons (Tree Top Town)=DDFA",
            "Script ???=E0FA",
            "Script Set of 3 Swinging Ropes (Ice Age Alley)=E32A",
            "Script Set of 2 Swinging Ropes (Ice Age Alley)=E352",
            "Script Manky Kong + Barrels #1 (Ice Age Alley)=E372",
            "Script Manky Kong + Barrels #2 (Ice Age Alley)=E392",
            "Script Manky Kong + Barrels #3 (Ice Age Alley)=E3B2",
            "Script Set of 2 Gold Kritters #1 (Rope Bridge Rumble)=E91C",
            "Script Set of 2 Gold Kritters #2 (Rope Bridge Rumble)=E93C",
            "Script Set of Cave Platforms/Tires/Zingers (Rope Bridge Rumble)=E95C",
            "Script Set of 2 Ropes (Moving b/f mirrored ~6 tiles)=ECC4",
            "Script Set of 3 Croctopi Moving in Squares (Clam City)=F154",
            "",
            "Misc:",
            "100-Second Timer - Enguarde=FB8F",
            "100-Second Timer - Expresso=FBC5",
            "100-Second Timer - Rambi=FBA1",
            "100-Second Timer - Winky=FBB3",
            "Arrow Sign Pointing Left=FBF1",
            "Arrow Sign=FBD7",
            "BANANA HOARD - Empty...=F1B5",
            "BANANA HOARD - Full!!!=F1C3",
            "Butterfly, Dark-Azure/Red=B931",
            "Butterfly, Purple/Yellow=B913",
            "Butterfly, Red/Yellow=B91D",
            "Butterfly, Yellow/Gold=B927",
            "DK Isle=FC3F",
            "Ending Credits Script=FE01",
            "EVENT - Exit Treehouse (From Inside Treehouse)=F173",
            "EVENT - Exit Treehouse (Upon Level Entry)=F155",
            "Exit Sign=FC0B",
            "Kong's Banana Hoard Sign=FC25",
            "Light Fixture, Brown=C5F3",
            "Light Fixture, Green=C5DF",
            "Light Fixture, Stop & Go=C5E9",
            "Whale (Picture Frame in Treehouse)=E3A3",
            "",
            //"Custom:",
            //"Jumproll cannon slow=0008",
            //"100-Second Timer - Expresso=FBC5",
            //"100-Second Timer - Rambi=FBA1",

        };
        public Dictionary<string, int> objectIndexByString = new Dictionary<string, int>();
        public Dictionary<int, string> objectStringByIndex = new Dictionary<int, string>();
        public Dictionary<int, int> objectCodeByIndex = new Dictionary<int, int>();
        public Dictionary<int, int> objectIndexByCode = new Dictionary<int, int>();
        public List<string> objectString = new List<string>();
        public List<string> objectCategories = new List<string>();
        public Dictionary<string, int> objectCategoriesByString = new Dictionary<string, int>();
        public Dictionary<string, int> objectPointerByString = new Dictionary<string, int>();
        public Dictionary<int, string> objectStringByPointer = new Dictionary<int, string>();


        public void ObjectParse()
        {
            objectString = new List<string>();
            objectCategories = new List<string>();
            objectCategoriesByString = new Dictionary<string, int>();
            objectIndexByCode = new Dictionary<int, int>();
            objectIndexByString = new Dictionary<string, int>();
            objectCodeByIndex = new Dictionary<int, int>();
            objectStringByIndex = new Dictionary<int, string>();
            objectPointerByString = new Dictionary<string, int>();
            objectStringByPointer = new Dictionary<int, string>();

            for (int i = 0; i < objectListRaw.Count; i++)
            {
                // What are we looking at?
                string item = objectListRaw[i];
                // If empty, contiinue
                if (item == "")
                {
                    objectString.Add(item);
                    continue;
                }

                // Are we on a heading?
                if (item.Contains(":"))
                {
                    objectCategoriesByString[item] = i;
                    // Remove ':'
                    var temp = item.Split(':')[0];
                    objectCategories.Add(temp);

                    // Do expected
                    objectString.Add(item);
                    continue;
                }

                // Split string to name and code (split at '=')
                var stringArr = item.Split('=');
                string itemByString = $"{(i - 1).ToString("X")}. {stringArr[0]}";
                int itemByCode = Convert.ToInt32(stringArr[1], 16);
                if (itemByCode < 0x8000 && false)
                {
                    continue;
                }

                objectString.Add(itemByString);
                objectCodeByIndex[i] = itemByCode;
                objectIndexByCode[itemByCode] = i;
                objectStringByIndex[i] = itemByString;
                objectIndexByString[itemByString] = i;
                objectStringByPointer[itemByCode] = itemByString;
            }
        }
        public List<string> ReadScript(Int32 address)
        {
            address &= 0xffff;

            if (address > 0x8000)
            {
                address |= 0x350000;
            }
            else
            {
                return new List<string>();
            }

            List<string> rtn = new List<string>();
            Stack<int> calls = new Stack<int>();


            string spaces = "";

            while (true)
            {
                // Read command value
                Int32 command = Read16(ref address);

                // What category is command?
                if (command < 0x8000)
                {
                    // Set array value
                    Int32 value = Read16(ref address);
                    rtn.Add(spaces + string.Format("[{0:x}] = {1:x}", command, value));
                }
                else
                {
                    // Hard-coded call
                    command >>= 8;
                    UInt16[] values = new UInt16[paramCountLut[command - 0x80]];
                    for (int i = 0; i < values.Length; i++)
                    {
                        var v = Read16(address);
                        values[i] = v;
                    }

                    // Build a string
                    string txt = string.Format("{0:x} -> ", command);
                    for (int i = 0; i < values.Length; i++)
                    {
                        var value = Read16(ref address);
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
        public int[] ReadScriptWRAM(Int32 address)
        {
            var wram = new int[0x2000];
            try
            {
                int pointer = address;
                address &= 0xffff;

                if (address > 0x8000)
                {
                    address |= 0x350000;
                }
                else
                {
                    //0xbbb154 - scripts start
                    int tempPointer = pointer * 4 + 8;
                    address = (int)Read24(tempPointer + 0xbae09f);
                    //return new List<string>();
                }

                List<string> rtn = new List<string>();
                Stack<int> calls = new Stack<int>();


                string spaces = "";

                while (true)
                {
                    // Read command value
                    Int32 command = Read16(ref address);

                    // What category is command?
                    if (command < 0x8000)
                    {
                        // Set array value
                        Int32 value = Read16(ref address);
                        wram[command] = value;
                        rtn.Add(spaces + string.Format("[{0:x}] = {1:x}", command, value));
                    }
                    else
                    {
                        // Hard-coded call
                        command >>= 8;
                        UInt16[] values = new UInt16[paramCountLut[command - 0x80]];
                        for (int i = 0; i < values.Length; i++)
                        {
                            var v = Read16(address);
                            values[i] = v;
                            switch (command)
                            {
                                case 0x81:
                                    break;
                                case 0x88:
                                    break;
                                case 0x97:
                                    break;
                                default:
                                    break;
                            }
                        }

                        // Build a string
                        string txt = string.Format("{0:x} -> ", command);
                        for (int i = 0; i < values.Length; i++)
                        {
                            var value = Read16(ref address);
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
                                    return wram;
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
                return null;
            }
        }
        public int[] ReadScriptKeyValue(Int32 address)
        {
            var wram = new int[0x2000];
            try
            {
                int pointer = address;
                address &= 0xffff;

                if (address > 0x8000)
                {
                    address |= 0x350000;
                }
                else
                {
                    //0xbbb154 - scripts start
                    int tempPointer = pointer * 4 + 8;
                    address = (int)Read24(tempPointer + 0xbae09f);
                    //return new List<string>();
                }

                List<string> rtn = new List<string>();
                Stack<int> calls = new Stack<int>();


                string spaces = "";

                while (true)
                {
                    // Read command value
                    Int32 command = Read16(ref address);

                    // What category is command?
                    if (command < 0x8000)
                    {
                        // Set array value
                        Int32 value = Read16(ref address);
                        wram[command] = value;
                        rtn.Add(spaces + string.Format("[{0:x}] = {1:x}", command, value));
                    }
                    else
                    {
                        // Hard-coded call
                        command >>= 8;
                        UInt16[] values = new UInt16[paramCountLut[command - 0x80]];
                        for (int i = 0; i < values.Length; i++)
                        {
                            var v = Read16(address);
                            values[i] = v;
                            switch (command)
                            {
                                case 0x81:
                                    break;
                                case 0x88:
                                    break;
                                case 0x97:
                                    break;
                                default:
                                    break;
                            }
                        }

                        // Build a string
                        string txt = string.Format("{0:x} -> ", command);
                        for (int i = 0; i < values.Length; i++)
                        {
                            var value = Read16(ref address);
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
                                    return wram;
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
                return null;
            }
        }
        public Dictionary<int, EntityKeyValue> GetEntityKeyValue(int pointer)
        {
            byte[] paramCountLut = new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 1, 2, 0, 3, 1, 1, 1 };
            Dictionary<int, EntityKeyValue> entityKeyValues;

            entityKeyValues = new Dictionary<int, EntityKeyValue>();
            string str = pointer.ToString("X");

            Stack<int> stack = new Stack<int>();

            int offset = 0xb50000 | pointer;


            offset &= 0xffff;

            if (offset > 0x8000)
            {
                offset |= 0xb50000;
            }
            else
            {
                //0xbbb154 - scripts start
                int tempPointer = pointer * 4;
                offset = (int)Read24(tempPointer + 0xbae0a7);
                //return new List<string>();
            }


            int times = 0;

            try
            {
                while (true)
                {
                    // To avoid infinite loops
                    if (times++ > 100)
                    {
                        throw new Exception("Timed out. Custom");
                    }
                    int mod = 0;
                    int key = Read16(offset + mod);
                    mod += 2;
                    EntityKeyValue ekv = new EntityKeyValue(key, offset);
                    if (key >= 0x8000)
                    {
                        int commandIndex = key >> 8;
                        commandIndex &= 0x7f;
                        var @params = paramCountLut[commandIndex];
                        while (@params-- > 0)
                        {
                            ekv.values.Add(Read16(offset + mod));
                            mod += 2;
                        }
                        switch (key >> 8)
                        {
                            case 0x82:
                                int bank = Read8(offset);
                                if (bank == 0)
                                {
                                    bank = 0xb5;
                                }
                                int newPtr = Read16(offset + 2);
                                stack.Push(offset + mod);
                                offset = (bank << 16) | (newPtr << 0);
                                continue;
                                break;
                            case 0x80:
                                if (stack.Count <= 0)
                                {
                                    return entityKeyValues;
                                }
                                offset = stack.Pop();
                                continue;

                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        ekv.values.Add(Read16(offset + mod));
                        mod += 2;
                    }
                    offset += mod;
                    // Finally add to our list
                    entityKeyValues[key] = ekv;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n Error. Did you enter in a bad pointer?");
            }

            return entityKeyValues;

        }


    }
}
