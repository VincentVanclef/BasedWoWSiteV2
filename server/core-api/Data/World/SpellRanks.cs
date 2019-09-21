using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellRanks
    {
        public int FirstSpellId { get; set; }
        public int SpellId { get; set; }
        public byte Rank { get; set; }
    }
}
