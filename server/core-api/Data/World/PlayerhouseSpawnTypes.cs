using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerhouseSpawnTypes
    {
        public PlayerhouseSpawnTypes()
        {
            PlayerhouseSpawns = new HashSet<PlayerhouseSpawns>();
        }

        public byte SpawnType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayerhouseSpawns> PlayerhouseSpawns { get; set; }
    }
}
