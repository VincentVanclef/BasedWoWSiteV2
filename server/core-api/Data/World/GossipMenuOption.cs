using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GossipMenuOption
    {
        public int MenuId { get; set; }
        public short OptionId { get; set; }
        public int OptionIcon { get; set; }
        public string OptionText { get; set; }
        public int OptionBroadcastTextId { get; set; }
        public byte OptionType { get; set; }
        public int OptionNpcFlag { get; set; }
        public int ActionMenuId { get; set; }
        public int ActionPoiId { get; set; }
        public byte BoxCoded { get; set; }
        public int BoxMoney { get; set; }
        public string BoxText { get; set; }
        public int BoxBroadcastTextId { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
