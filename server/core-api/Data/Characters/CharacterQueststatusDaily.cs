using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterQueststatusDaily
    {
        public int Guid { get; set; }
        public int Quest { get; set; }
        public int Time { get; set; }
    }
}
