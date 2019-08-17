using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class ItemLootItems
    {
        public int ContainerId { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public byte FollowRules { get; set; }
        public byte Ffa { get; set; }
        public byte Blocked { get; set; }
        public byte Counted { get; set; }
        public byte UnderThreshold { get; set; }
        public byte NeedsQuest { get; set; }
        public int RndProp { get; set; }
        public int RndSuffix { get; set; }
    }
}
