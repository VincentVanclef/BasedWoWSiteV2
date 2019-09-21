using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTemplateMovement
    {
        public int CreatureId { get; set; }
        public byte Ground { get; set; }
        public byte Swim { get; set; }
        public byte Flight { get; set; }
        public byte Rooted { get; set; }
        public byte Chase { get; set; }
        public byte Random { get; set; }
    }
}
