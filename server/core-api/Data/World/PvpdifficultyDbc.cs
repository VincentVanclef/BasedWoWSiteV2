using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PvpdifficultyDbc
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public int BracketId { get; set; }
        public int MinUpgrades { get; set; }
        public int MaxUpgrades { get; set; }
        public int Difficulty { get; set; }
    }
}
