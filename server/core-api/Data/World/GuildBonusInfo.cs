using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GuildBonusInfo
    {
        public byte Level { get; set; }
        public byte Bonus { get; set; }
        public float Multiplier { get; set; }
    }
}
