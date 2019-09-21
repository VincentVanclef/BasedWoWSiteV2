using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomRewards
    {
        public string Target { get; set; }
        public int Entry { get; set; }
        public int Count { get; set; }
        public byte Type { get; set; }

        public virtual CustomRewardsType TypeNavigation { get; set; }
    }
}
