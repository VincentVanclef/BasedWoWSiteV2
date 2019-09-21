using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameEventNpcVendor
    {
        public byte EventEntry { get; set; }
        public int Guid { get; set; }
        public short Slot { get; set; }
        public int Item { get; set; }
        public int Maxcount { get; set; }
        public int Incrtime { get; set; }
        public int ExtendedCost { get; set; }
    }
}
