using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellThreat
    {
        public int Entry { get; set; }
        public int? FlatMod { get; set; }
        public float PctMod { get; set; }
        public float ApPctMod { get; set; }
    }
}
