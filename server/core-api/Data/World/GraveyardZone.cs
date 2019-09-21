using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GraveyardZone
    {
        public int Id { get; set; }
        public int GhostZone { get; set; }
        public short Faction { get; set; }
        public string Comment { get; set; }
    }
}
