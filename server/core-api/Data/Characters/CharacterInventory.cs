using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterInventory
    {
        public int Guid { get; set; }
        public int Bag { get; set; }
        public byte Slot { get; set; }
        public int Item { get; set; }
    }
}
