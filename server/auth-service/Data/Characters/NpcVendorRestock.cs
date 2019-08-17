using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class NpcVendorRestock
    {
        public int OwnerGuid { get; set; }
        public int VendorEntry { get; set; }
        public int ItemEntry { get; set; }
        public int Count { get; set; }
        public int NextIncrementTime { get; set; }
    }
}
