using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterReputation
    {
        public int Guid { get; set; }
        public short Faction { get; set; }
        public int Standing { get; set; }
        public short Flags { get; set; }
    }
}
