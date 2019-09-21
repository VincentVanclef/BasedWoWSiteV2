using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GuildXpRequiredForLevel
    {
        public byte Level { get; set; }
        public int XpRequired { get; set; }
    }
}
