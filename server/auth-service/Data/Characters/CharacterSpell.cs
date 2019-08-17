using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterSpell
    {
        public int Guid { get; set; }
        public int Spell { get; set; }
        public byte Active { get; set; }
        public byte Disabled { get; set; }
    }
}
