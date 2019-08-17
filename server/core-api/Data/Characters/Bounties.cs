using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Bounties
    {
        public long Guid { get; set; }
        public int? Posterguid { get; set; }
        public int? Money { get; set; }
        public int? Expiretime { get; set; }
    }
}
