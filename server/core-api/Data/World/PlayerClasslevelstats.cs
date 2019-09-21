using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerClasslevelstats
    {
        public byte Class { get; set; }
        public byte Level { get; set; }
        public short Basehp { get; set; }
        public short Basemana { get; set; }
    }
}
