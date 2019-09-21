using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class InstanceSpawnGroups
    {
        public short InstanceMapId { get; set; }
        public byte BossStateId { get; set; }
        public byte BossStates { get; set; }
        public int SpawnGroupId { get; set; }
        public byte Flags { get; set; }
    }
}
