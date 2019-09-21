using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomBossData
    {
        public int Entry { get; set; }
        public int? EventId { get; set; }
        public int SpellId { get; set; }
        public int SpellMinDamage { get; set; }
        public int SpellMaxDamage { get; set; }
        public byte IsPct { get; set; }
        public string Message { get; set; }
        public int TimeBetweenCast { get; set; }
    }
}
