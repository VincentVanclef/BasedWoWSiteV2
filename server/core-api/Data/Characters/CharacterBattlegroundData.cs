using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterBattlegroundData
    {
        public int Guid { get; set; }
        public int InstanceId { get; set; }
        public short Team { get; set; }
        public float JoinX { get; set; }
        public float JoinY { get; set; }
        public float JoinZ { get; set; }
        public float JoinO { get; set; }
        public short JoinMapId { get; set; }
        public int TaxiStart { get; set; }
        public int TaxiEnd { get; set; }
        public int MountSpell { get; set; }
    }
}
