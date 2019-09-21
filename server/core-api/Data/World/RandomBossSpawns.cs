using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class RandomBossSpawns
    {
        public int Entry { get; set; }
        public float? X { get; set; }
        public float? Y { get; set; }
        public float? Z { get; set; }
        public int Map { get; set; }
        public string Hint { get; set; }
    }
}
