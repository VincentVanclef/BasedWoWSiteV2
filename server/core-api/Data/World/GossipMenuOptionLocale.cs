using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GossipMenuOptionLocale
    {
        public short MenuId { get; set; }
        public short OptionId { get; set; }
        public string Locale { get; set; }
        public string OptionText { get; set; }
        public string BoxText { get; set; }
    }
}
