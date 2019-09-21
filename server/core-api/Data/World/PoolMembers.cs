using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PoolMembers
    {
        public short Type { get; set; }
        public int SpawnId { get; set; }
        public int PoolSpawnId { get; set; }
        public double Chance { get; set; }
        public string Description { get; set; }
    }
}
