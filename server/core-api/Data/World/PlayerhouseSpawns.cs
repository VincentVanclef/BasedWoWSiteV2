using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerhouseSpawns
    {
        public int HouseId { get; set; }
        public byte SpawnType { get; set; }
        public int SpawnGuid { get; set; }
        public int SpawnEntry { get; set; }

        public virtual PlayerhouseSpawnTypes SpawnTypeNavigation { get; set; }
    }
}
