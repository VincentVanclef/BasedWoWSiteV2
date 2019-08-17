using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterAchievementProgress
    {
        public int Guid { get; set; }
        public short Criteria { get; set; }
        public int Counter { get; set; }
        public int Date { get; set; }
    }
}
