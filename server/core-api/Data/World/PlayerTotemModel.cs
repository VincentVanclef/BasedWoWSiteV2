using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerTotemModel
    {
        public byte TotemSlot { get; set; }
        public byte RaceId { get; set; }
        public int DisplayId { get; set; }
    }
}
