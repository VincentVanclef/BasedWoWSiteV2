using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ZombieDeathmatchRewards
    {
        public byte Round { get; set; }
        public int Entry { get; set; }
        public int Count { get; set; }
        public byte Type { get; set; }
    }
}
