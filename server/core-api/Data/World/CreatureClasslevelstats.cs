using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureClasslevelstats
    {
        public byte Level { get; set; }
        public byte Class { get; set; }
        public short Basehp0 { get; set; }
        public short Basehp1 { get; set; }
        public short Basehp2 { get; set; }
        public short Basemana { get; set; }
        public short Basearmor { get; set; }
        public short Attackpower { get; set; }
        public short Rangedattackpower { get; set; }
        public float DamageBase { get; set; }
        public float DamageExp1 { get; set; }
        public float DamageExp2 { get; set; }
        public string Comment { get; set; }
    }
}
