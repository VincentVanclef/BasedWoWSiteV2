using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpawnGroup
    {
        public int GroupId { get; set; }
        public byte SpawnType { get; set; }
        public int SpawnId { get; set; }
    }
}
