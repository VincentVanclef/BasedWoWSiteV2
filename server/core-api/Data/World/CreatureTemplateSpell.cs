using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTemplateSpell
    {
        public int CreatureId { get; set; }
        public byte Index { get; set; }
        public int? Spell { get; set; }
        
    }
}
