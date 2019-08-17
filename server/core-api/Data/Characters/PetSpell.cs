using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class PetSpell
    {
        public int Guid { get; set; }
        public int Spell { get; set; }
        public byte Active { get; set; }
    }
}
