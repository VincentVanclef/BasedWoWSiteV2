using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class LfgData
    {
        public int Guid { get; set; }
        public int Dungeon { get; set; }
        public byte State { get; set; }
    }
}
