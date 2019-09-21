using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestPoi
    {
        public int QuestId { get; set; }
        public int Id { get; set; }
        public int ObjectiveIndex { get; set; }
        public int MapId { get; set; }
        public int WorldMapAreaId { get; set; }
        public int Floor { get; set; }
        public int Priority { get; set; }
        public int Flags { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
