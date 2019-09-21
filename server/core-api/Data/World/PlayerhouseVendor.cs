using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerhouseVendor
    {
        public int Entry { get; set; }
        public short Slot { get; set; }
        public int Item { get; set; }
        public byte Maxcount { get; set; }
        public int Incrtime { get; set; }
        public int ExtendedCost { get; set; }
        public int Cond { get; set; }
        public int BuyPrice { get; set; }
        public int BuyCount { get; set; }
        
    }
}
