using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Respawn
    {
        public short Type { get; set; }
        public int SpawnId { get; set; }
        public long RespawnTime { get; set; }
        public short MapId { get; set; }
        public int InstanceId { get; set; }
    }
}
