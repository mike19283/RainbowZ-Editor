using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public List<int> pointersOfNewMaps = new List<int>()
        {
            0x0000, //81cc	Jungle Hijinx (Reptile Rumble object map?),	0	
            0x0000, //81cc	Reptile Rumble (level exit),	1	
            0x0000, //846c	Reptile Rumble - Bonus 1,	2	
            0x0000, //8484	Bouncy Bonanza - Winky Room,	3	
            0x0000, //849c	Reptile Rumble - Bonus 3,	4	
            0x0000, //84c4	Manic Mincers - Bonus 1,	5	
            0x0000, //84d4	Jungle Hijinx - Bonus 1,	6	
            0x0000, //84ec	Bouncy Bonanza (level exit),	7	
            0x8000, //95dc	Jungle Hijinx (from Bonus 1),	8	
            0x0000, //81cc	Reptile Rumble (from Bonus 1),	9	
            0x0000, //8834	Misty Mine (level exit),	a	
            0x0000, //81cc	Reptile Rumble (from Bonus 3),	b	
            0x0000, //8ad4	Ropey Rampage (level exit),	c	
            0x0000, //8d7c	Orang-utan Gang (level exit),	d	
            0x8000, //95dc	Jungle Hijinx (start),	e	
            0x0000, //8ad4	Ropey Rampage (from Save),	f	
            0x0000, //84ec	Bouncy Bonanza (from Winky Room),	10	
            0x0000, //90c4	Bouncy Bonanza - Bonus 2,	11	
            0x0000, //9104	Manic Mincers (level exit),	12	
            0x0000, //9434	Torchlight Trouble (from Save),	13	
            0x0000, //9434	Torchlight Trouble (level exit),	14	
            0x0000, //84ec	Bouncy Bonanza (from Save),	15	
            0x8000, //95dc	Jungle Hijinx (level exit),	16	
            0x0000, //981c	Barrel Cannon Canyon (level exit),	17	
            0x0000, //9cd4	Elevator Antics (level exit),	18	
            0x0000, //981c	Barrel Cannon Canyon (from Save),	19	
            0x0000, //a03c	Jungle Hijinx - Bonus 2,	1a	
            0x0000, //a04c	Ropey Rampage - Bonus 2,	1b	
            0x0000, //a05c	Ropey Rampage - Bonus 1,	1c	
            0x0000, //8d7c	Orang-utan Gang (from Save),	1d	
            0x0000, //a0a4	Orang-utan Gang - Bonus 3,	1e	
            0x0000, //a0cc	Orang-utan Gang - Bonus 2,	1f	
            0x0000, //a0fc	Orang-utan Gang - Bonus 1,	20	
            0x0000, //a10c	 empty jungle room + boss music???,	21	
            0x0000, //a10c	Poison Pond (level exit),	22	
            0x0000, //9cd4	Elevator Antics (from Save),	23	
            0x0000, //a7e0	Snow Barrel Blast (level exit),	24	
            0x8000, //95dc	Jungle Hijinx (from Save),	25	
            0x0000, //81cc	Reptile Rumble (from Save),	26	
            0x0000, //ac38	Mine Cart Madness (level exit),	27	
            0x0000, //a7e0	Snow Barrel Blast (from Save),	28	
            0x0000, //9104	Manic Mincers (from Save),	29	
            0x0000, //a10c	Poison Pond (from Save),	2a	
            0x0000, //aeb8	Platform Perils (level exit),	2b	
            0x0000, //aeb8	Platform Perils (from Save),	2c	
            0x0000, //8834	Misty Mine (from Save),	2d	
            0x0000, //b2b0	Mine Cart Carnage (level exit),	2e	
            0x0000, //b3f8	Trick Track Trek (level exit),	2f	
            0x0000, //b658	Tanked Up Trouble (level exit),	30	
            0x0000, //b9c0	Stop & Go Station (level exit),	31	
            0x0000, //be28	Misty Mine - Bonus 2,	32	
            0x0000, //be38	Misty Mine - Bonus 1,	33	
            0x0000, //be78	Animal Token Room,	34	
            0x0000, //cab8	Millstone Mayhem (from warp),	35	
            0x0000, //bee8	Loopy Lights (level exit),	36	
            0x0000, //c320	Loopy Lights - Bonus 2,	37	
            0x0000, //b2b0	Mine Cart Carnage (from Save),	38	
            0x0000, //b3f8	Trick Track Trek (from Save),	39	
            0x0000, //b658	Tanked Up Trouble (from Save),	3a	
            0x0000, //ac38	Mine Cart Madness (from Save),	3b	
            0x0000, //b9c0	Stop & Go Station (from Save),	3c	
            0x0000, //bee8	Loopy Lights (from Save),	3d	
            0x0000, //a5a6	Croctopus Chase (level exit),	3e	
            0x0000, //a5a6	Croctopus Chase (from Save),	3f	
            0x0000, //c370	Oil Drum Alley (level exit),	40	
            0x0000, //c810	Blackout Basement (level exit),	41	
            0x0000, //cab8	Millstone Mayhem (level exit),	42	
            0x0000, //cd38	Temple Tempest (level exit),	43	
            0x0000, //c370	Oil Drum Alley (from Save),	44	
            0x0000, //c810	Blackout Basement (from Save),	45	
            0x0000, //cff0	Barrel Cannon Canyon - Bonus 1,	46	
            0x0000, //d048	Jungle Hijinx - Kong's Banana Hoard (empty),	47	
            0x0000, //d068	Reptile Rumble - Bonus 2,	48	
            0x0000, //d0c8	Loopy Lights - Bonus 1,	49	
            0x0000, //d130	Stop & Go Station - Bonus 2,	4a	
            0x0000, //d160	Stop & Go Station - Bonus 1,	4b	
            0x0000, //d198	Jungle Hijinx - Kong's Banana Hoard (full),	4c	
            0x0000, //d1b8	Mine Cart Madness - Bonus 1,	4d	
            0x0000, //d210	Platform Perils - Bonus 1,	4e	
            0x0000, //d220	Winky's Walkway - Bonus 1,	4f	
            0x0000, //d270	Platform Perils - Bonus 2,	50	
            0x0000, //ee64	Winky's Walkway (from Bonus 1),	51	
            0x0000, //d280	Temple Tempest - Bonus 1,	52	
            0x0000, //d2f8	Temple Tempest - Bonus 2,	53	
            0x0000, //db2a	Tree Top Town (warp),	54	
            0x0000, //d310	Millstone Mayhem - Bonus 1,	55	
            0x0000, //d338	Millstone Mayhem - Bonus 2,	56	
            0x0000, //d350	Millstone Mayhem - Bonus 3,	57	
            0x0000, //cab8	Millstone Mayhem (from Save),	58	
            0x0000, //cd38	Temple Tempest (from Save),	59	
            0x0000, //d360	Orang-utan Gang - Bonus 5,	5a	
            0x0000, //d380	Orang-utan Gang - Bonus 4,	5b	
            0x0000, //d3a0	Jungle Hijinx - Kong's Cabin,	5c	
            0x0000, //d3d8	Barrel Cannon Canyon - Bonus 2,	5d	
            0x0000, //d400	 Credits,	5e	
            0x8000, //95dc	Jungle Hijinx (from Kong's Banana Hoard),	5f	
            0x0000, //d418	Oil Drum Alley - Bonus 4,	60	
            0x0000, //d468	Oil Drum Alley - Bonus 2,	61	
            0x0000, //d638	Slipslide Ride (warp),	62	
            0x0000, //d488	Oil Drum Alley - Bonus 1,	63	
            0x0000, //d4a0	Blackout Basement - Bonus 1,	64	
            0x0000, //de32	Vulture Culture (warp),	65	
            0x0000, //d508	Snow Barrel Blast - Bonus 3,	66	
            0x0000, //d568	Snow Barrel Blast - Bonus 1,	67	
            0x0000, //d578	Gangplank Galleon,	68	
            0x0000, //d590	Snow Barrel Blast - Bonus 2,	69	
            0x0000, //d5b0	Ice Age Alley - Bonus 1,	6a	
            0x0000, //d610	Ice Age Alley - Bonus 2,	6b	
            0x0000, //d620	Expresso Bonus,	6c	
            0x0000, //d638	Slipslide Ride (level exit),	6d	
            0x8000, //95dc	Jungle Hijinx (from Bonus 2),	6e	
            0x0000, //8ad4	Ropey Rampage (from Bonus 1),	6f	
            0x0000, //8ad4	Ropey Rampage (from Bonus 2),	70	
            0x0000, //8d7c	Orang-utan Gang (from Bonus 4),	71	
            0x0000, //8d7c	Orang-utan Gang (from Bonus 2),	72	
            0x0000, //8d7c	Orang-utan Gang (from Bonus 1),	73	
            0x0000, //8d7c	Orang-utan Gang (from Bonus 3),	74	
            0x0000, //8d7c	Orang-utan Gang (from Bonus 5),	75	
            0x0000, //981c	Barrel Cannon Canyon (from Bonus 1),	76	
            0x0000, //981c	Barrel Cannon Canyon (from Bonus 2),	77	
            0x0000, //84ec	Bouncy Bonanza (from Bonus 1),	78	
            0x0000, //84ec	Bouncy Bonanza (from Bonus 2),	79	
            0x0000, //9104	Manic Mincers (from Bonus 1),	7a	
            0x0000, //9104	Manic Mincers (from Ledge Room),	7b	
            0x0000, //9104	Manic Mincers (from Bonus 2),	7c	
            0x0000, //9cd4	Elevator Antics (from Bonus 1),	7d	
            0x0000, //9cd4	Elevator Antics (from Bonus 2),	7e	
            0x0000, //9cd4	Elevator Antics (from Bonus 3),	7f	
            0x0000, //8834	Misty Mine (from Bonus 1),	80	
            0x0000, //8834	Misty Mine (from Bonus 2),	81	
            0x0000, //b9c0	Stop & Go Station (from Bonus 1),	82	
            0x0000, //b9c0	Stop & Go Station (from Bonus 2),	83	
            0x0000, //bee8	Loopy Lights (from Bonus 1),	84	
            0x0000, //bee8	Loopy Lights (from Bonus 2),	85	
            0x0000, //aeb8	Platform Perils (from Bonus 1),	86	
            0x0000, //aeb8	Platform Perils (from Bonus 2),	87	
            0x0000, //b3f8	Trick Track Trek (from Bonus 1),	88	
            0x0000, //b3f8	Trick Track Trek (from Bonus 3),	89	
            0x0000, //b3f8	Trick Track Trek (from Bonus 2),	8a	
            0x0000, //b658	Tanked Up Trouble (from Bonus 1),	8b	
            0x0000, //ac38	Mine Cart Madness (from Bonus 1),	8c	
            0x0000, //ac38	Mine Cart Madness (from Bonus 2),	8d	
            0x0000, //ac38	Mine Cart Madness (from Bonus 3),	8e	
            0x0000, //c370	Oil Drum Alley (from Bonus 1),	8f	
            0x0000, //c370	Oil Drum Alley (from Bonus 2/3),	90	
            0x0000, //c370	Oil Drum Alley (from Bonus 4),	91	
            0x0000, //c810	Blackout Basement (from Bonus 1),	92	
            0x0000, //c810	Blackout Basement (from Bonus 2),	93	
            0x0000, //a7e0	Snow Barrel Blast (from Bonus 1),	94	
            0x0000, //a7e0	Snow Barrel Blast (from Bonus 2),	95	
            0x0000, //a7e0	Snow Barrel Blast (from Bonus 3),	96	
            0x0000, //d9ba	Bouncy Bonanza - Bonus 1,	97	
            0x0000, //d9ca	Manic Mincers - Bonus 2,	98	
            0x0000, //d9da	Manic Mincers - Ledge Room,	99	
            0x0000, //da22	Elevator Antics - Bonus 1,	9a	
            0x0000, //da32	Elevator Antics - Bonus 2,	9b	
            0x0000, //da8a	Elevator Antics - Bonus 3,	9c	
            0x0000, //da9a	Trick Track Trek - Bonus 3,	9d	
            0x0000, //daaa	Trick Track Trek - Bonus 2,	9e	
            0x0000, //daba	Tanked Up Trouble - Bonus 1,	9f	
            0x0000, //daca	Mine Cart Madness - Bonus 2,	a0	
            0x0000, //dada	Trick Track Trek - Bonus 1,	a1	
            0x0000, //daf2	Mine Cart Madness - Bonus 3,	a2	
            0x0000, //db12	Blackout Basement - Bonus 2,	a3	
            0x0000, //db2a	Tree Top Town (level exit),	a4	
            0x0000, //de32	Vulture Culture (level exit),	a5	
            0x0000, //e11a	Enguarde Bonus,	a6	
            0x0000, //e152	Ice Age Alley (level exit),	a7	
            0x0000, //e152	Ice Age Alley (from Save),	a8	
            0x0000, //db2a	Tree Top Town (from Save),	a9	
            0x0000, //de32	Vulture Culture (from Save),	aa	
            0x0000, //d638	Slipslide Ride (from Save),	ab	
            0x0000, //e152	Ice Age Alley (from Bonus 1),	ac	
            0x0000, //e152	Ice Age Alley (from Bonus 2),	ad	
            0x0000, //cab8	Millstone Mayhem (from Bonus 1),	ae	
            0x0000, //cab8	Millstone Mayhem (from Bonus 2),	af	
            0x0000, //cab8	Millstone Mayhem (from Bonus 3),	b0	
            0x0000, //cd38	Temple Tempest (from Bonus 1),	b1	
            0x0000, //cd38	Temple Tempest (from Bonus 2),	b2	
            0x0000, //e3d2	Tree Top Town - Bonus 2,	b3	
            0x0000, //e3ea	Tree Top Town - Bonus 1,	b4	
            0x0000, //db2a	Tree Top Town (from Bonus 1),	b5	
            0x0000, //db2a	Tree Top Town (from Bonus 2),	b6	
            0x0000, //e3fa	Vulture Culture - Bonus 1,	b7	
            0x0000, //e412	Vulture Culture - Bonus 2,	b8	
            0x0000, //e42a	Vulture Culture - Bonus 3,	b9	
            0x0000, //de32	Vulture Culture (from Bonus 1),	ba	
            0x0000, //de32	Vulture Culture (from Bonus 2),	bb	
            0x0000, //de32	Vulture Culture (from Bonus 3),	bc	
            0x0000, //b3f8	Trick Track Trek (warp),	bd	
            0x0000, //e492	Oil Drum Alley - Bonus 3,	be	
            0x0000, //e4aa	Coral Capers (level exit),	bf	
            0x0000, //e4aa	Coral Capers (from Save),	c0	
            0x0000, //e60c	Torchlight Trouble - Bonus 1,	c1	
            0x0000, //9434	Torchlight Trouble (from Bonus 1),	c2	
            0x0000, //e61c	Torchlight Trouble - Bonus 2,	c3	
            0x0000, //9434	Torchlight Trouble (from Bonus 2),	c4	
            0x0000, //e63c	Slipslide Ride - Bonus 2,	c5	
            0x0000, //e64c	Slipslide Ride - Bonus 3,	c6	
            0x0000, //d638	Slipslide Ride (from Bonus 1),	c7	
            0x0000, //d638	Slipslide Ride (from Bonus 2),	c8	
            0x0000, //81cc	Reptile Rumble (from Bonus 2),	c9	
            0x0000, //e6a4	Slipslide Ride - Bonus 1,	ca	
            0x0000, //d638	Slipslide Ride (from Bonus 3),	cb	
            0x0000, //b2b0	Mine Cart Carnage (warp),	cc	
            0x0000, //b9c0	Stop & Go Station (warp),	cd	
            0x0000, //e6b4	Rope Bridge Rumble (level exit),	ce	
            0x0000, //e6b4	Rope Bridge Rumble (from Save),	cf	
            0x0000, //e99c	Forest Frenzy (level exit),	d0	
            0x0000, //e99c	Forest Frenzy (from Save),	d1	
            0x0000, //ece4	Rambi Bonus,	d2	
            0x0000, //ecfc	Winky Bonus,	d3	
            0x0000, //edbc	Forest Frenzy - Bonus 2,	d4	
            0x0000, //eddc	Rope Bridge Rumble - Bonus 1,	d5	
            0x0000, //e6b4	Rope Bridge Rumble (from Bonus 2),	d6	
            0x0000, //ee54	Rope Bridge Rumble - Bonus 2,	d7	
            0x0000, //e6b4	Rope Bridge Rumble (from Bonus 1),	d8	
            0x0000, //ee64	Winky's Walkway (level exit),	d9	
            0x0000, //ee64	Winky's Walkway (from Save),	da	
            0x0000, //e99c	Forest Frenzy (from Bonus 2),	db	
            0x0000, //efbc	Forest Frenzy - Bonus 1,	dc	
            0x0000, //e99c	Forest Frenzy (from Bonus 1),	dd	
            0x0000, //efcc	Clam City (level exit),	de	
            0x0000, //efcc	Clam City (from Save),	df	
            0x0000, //f18e	Very Gnawty's Lair,	e0	
            0x0000, //f19e	Necky's Nuts,	e1	
            0x0000, //f1ae	Really Gnawty Rampage,	e2, 40	
            0x0000, //f1be	Boss Dumb Drum,	e3,30	
            0x0000, //f1ce	Necky's Revenge,	e4	
            0x0000, //f1de	Bumble B Rumble,	e5,24	

        };
    }
}
