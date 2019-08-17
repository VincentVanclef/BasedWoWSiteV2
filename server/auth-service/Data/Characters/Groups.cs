using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Groups
    {
        public int Guid { get; set; }
        public int LeaderGuid { get; set; }
        public byte LootMethod { get; set; }
        public int LooterGuid { get; set; }
        public byte LootThreshold { get; set; }
        public long Icon1 { get; set; }
        public long Icon2 { get; set; }
        public long Icon3 { get; set; }
        public long Icon4 { get; set; }
        public long Icon5 { get; set; }
        public long Icon6 { get; set; }
        public long Icon7 { get; set; }
        public long Icon8 { get; set; }
        public byte GroupType { get; set; }
        public byte Difficulty { get; set; }
        public byte RaidDifficulty { get; set; }
        public int MasterLooterGuid { get; set; }
    }
}
