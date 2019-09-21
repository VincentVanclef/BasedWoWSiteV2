using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomEnchanter
    {
        public int Id { get; set; }
        public int SpellId { get; set; }
        public byte Slot { get; set; }
        public int RequiredItemLevel { get; set; }
        public int Cond { get; set; }
        public byte Enabled { get; set; }
        public byte Sort { get; set; }
        public string Description { get; set; }
    }
}
