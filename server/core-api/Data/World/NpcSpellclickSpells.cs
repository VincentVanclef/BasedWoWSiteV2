using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class NpcSpellclickSpells
    {
        public int NpcEntry { get; set; }
        public int SpellId { get; set; }
        public byte CastFlags { get; set; }
        public short UserType { get; set; }
    }
}
