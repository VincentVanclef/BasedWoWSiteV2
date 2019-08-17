using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterBoost
    {
        public int Owner { get; set; }
        public byte BoostType { get; set; }
        public float BoostModifier { get; set; }
        public long UnsetDate { get; set; }
    }
}
