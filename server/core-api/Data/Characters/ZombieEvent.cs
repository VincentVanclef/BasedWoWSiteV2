using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class ZombieEvent
    {
        public int Guid { get; set; }
        public int Round { get; set; }
        public long Won { get; set; }
    }
}
