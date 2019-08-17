using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterQueststatusRewarded
    {
        public int Guid { get; set; }
        public int Quest { get; set; }
        public byte Active { get; set; }
    }
}
