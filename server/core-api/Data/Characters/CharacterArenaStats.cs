using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterArenaStats
    {
        public int Guid { get; set; }
        public byte Slot { get; set; }
        public short MatchMakerRating { get; set; }
    }
}
