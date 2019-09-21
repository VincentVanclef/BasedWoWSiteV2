using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomSharedLoot
    {
        public int CreatureEntry { get; set; }
        public int ItemEntry { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public float Chance { get; set; }
    }
}
