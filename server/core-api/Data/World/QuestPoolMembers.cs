using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestPoolMembers
    {
        public int QuestId { get; set; }
        public int PoolId { get; set; }
        public byte PoolIndex { get; set; }
        public string Description { get; set; }
    }
}
