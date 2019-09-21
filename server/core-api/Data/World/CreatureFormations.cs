using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureFormations
    {
        public int LeaderGuid { get; set; }
        public int MemberGuid { get; set; }
        public float Dist { get; set; }
        public float Angle { get; set; }
        public int GroupAi { get; set; }
        public short Point1 { get; set; }
        public short Point2 { get; set; }
    }
}
