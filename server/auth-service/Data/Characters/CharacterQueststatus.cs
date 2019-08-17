using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterQueststatus
    {
        public int Guid { get; set; }
        public int Quest { get; set; }
        public byte Status { get; set; }
        public byte Explored { get; set; }
        public int Timer { get; set; }
        public short Mobcount1 { get; set; }
        public short Mobcount2 { get; set; }
        public short Mobcount3 { get; set; }
        public short Mobcount4 { get; set; }
        public short Itemcount1 { get; set; }
        public short Itemcount2 { get; set; }
        public short Itemcount3 { get; set; }
        public short Itemcount4 { get; set; }
        public short Itemcount5 { get; set; }
        public short Itemcount6 { get; set; }
        public short Playercount { get; set; }
    }
}
