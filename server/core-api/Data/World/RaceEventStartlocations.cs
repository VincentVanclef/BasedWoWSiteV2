using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class RaceEventStartlocations
    {
        public byte EventId { get; set; }
        public byte Index { get; set; }
        public float? PosX { get; set; }
        public float? PosY { get; set; }
        public float? PosZ { get; set; }
        public float? Orientation { get; set; }

        public virtual RaceEventData Event { get; set; }
    }
}
