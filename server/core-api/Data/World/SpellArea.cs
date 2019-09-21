using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellArea
    {
        public int Spell { get; set; }
        public int Area { get; set; }
        public int QuestStart { get; set; }
        public int QuestEnd { get; set; }
        public int AuraSpell { get; set; }
        public int Racemask { get; set; }
        public byte Gender { get; set; }
        public byte Autocast { get; set; }
        public int QuestStartStatus { get; set; }
        public int QuestEndStatus { get; set; }
    }
}
