using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTemplateResistance
    {
        public int CreatureId { get; set; }
        public byte School { get; set; }
        public short? Resistance { get; set; }
        
    }
}
