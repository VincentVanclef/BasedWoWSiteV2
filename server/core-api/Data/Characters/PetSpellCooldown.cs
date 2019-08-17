using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class PetSpellCooldown
    {
        public int Guid { get; set; }
        public int Spell { get; set; }
        public int Time { get; set; }
        public int CategoryId { get; set; }
        public int CategoryEnd { get; set; }
    }
}
