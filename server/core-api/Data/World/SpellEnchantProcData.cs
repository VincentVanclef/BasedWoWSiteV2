using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellEnchantProcData
    {
        public int EnchantId { get; set; }
        public float Chance { get; set; }
        public float ProcsPerMinute { get; set; }
        public int HitMask { get; set; }
        public int AttributesMask { get; set; }
    }
}
