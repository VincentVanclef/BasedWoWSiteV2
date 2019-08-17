using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CustomItemUpgradeSets
    {
        public int Owner { get; set; }
        public byte SetId { get; set; }
        public string SetName { get; set; }
    }
}
