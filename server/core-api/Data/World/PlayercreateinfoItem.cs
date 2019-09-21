using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayercreateinfoItem
    {
        public byte Race { get; set; }
        public byte Class { get; set; }
        public int Itemid { get; set; }
        public byte Amount { get; set; }
    }
}
