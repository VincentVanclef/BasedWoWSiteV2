using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterAchievement
    {
        public int Guid { get; set; }
        public short Achievement { get; set; }
        public int Date { get; set; }
    }
}
