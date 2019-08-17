using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class ItemInstance
    {
        public int Guid { get; set; }
        public int ItemEntry { get; set; }
        public int OwnerGuid { get; set; }
        public int CreatorGuid { get; set; }
        public int GiftCreatorGuid { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }
        public string Charges { get; set; }
        public int Flags { get; set; }
        public string Enchantments { get; set; }
        public short RandomPropertyId { get; set; }
        public short Durability { get; set; }
        public int PlayedTime { get; set; }
        public string Text { get; set; }
        public int Transmog { get; set; }
    }
}
