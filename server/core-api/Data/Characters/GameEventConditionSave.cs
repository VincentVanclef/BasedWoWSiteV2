using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GameEventConditionSave
    {
        public byte EventEntry { get; set; }
        public int ConditionId { get; set; }
        public float? Done { get; set; }
    }
}
