using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameEventQuestCondition
    {
        public byte EventEntry { get; set; }
        public int Quest { get; set; }
        public int ConditionId { get; set; }
        public float? Num { get; set; }
    }
}
