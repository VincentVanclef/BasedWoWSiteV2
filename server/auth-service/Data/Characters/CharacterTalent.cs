using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterTalent
    {
        public int Guid { get; set; }
        public int Spell { get; set; }
        public byte TalentGroup { get; set; }
    }
}
