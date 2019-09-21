using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class RaceEventData
    {
        public RaceEventData()
        {
            RaceEventChopperlocations = new HashSet<RaceEventChopperlocations>();
            RaceEventStartlocations = new HashSet<RaceEventStartlocations>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public int MapId { get; set; }
        public byte? MinPlayers { get; set; }
        public byte? MaxPlayers { get; set; }
        public byte? Laps { get; set; }
        public string GossipIcon { get; set; }
        public int CheckPointEntry { get; set; }

        public virtual ICollection<RaceEventChopperlocations> RaceEventChopperlocations { get; set; }
        public virtual ICollection<RaceEventStartlocations> RaceEventStartlocations { get; set; }
    }
}
