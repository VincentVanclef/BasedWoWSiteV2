using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class LfgDungeonRewards
    {
        public int DungeonId { get; set; }
        public byte MaxLevel { get; set; }
        public int FirstQuestId { get; set; }
        public int OtherQuestId { get; set; }
    }
}
