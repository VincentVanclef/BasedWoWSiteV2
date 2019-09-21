using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureModelInfo
    {
        public int DisplayId { get; set; }
        public float BoundingRadius { get; set; }
        public float CombatReach { get; set; }
        public byte Gender { get; set; }
        public int DisplayIdOtherGender { get; set; }
    }
}
