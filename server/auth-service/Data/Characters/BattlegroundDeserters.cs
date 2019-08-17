using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class BattlegroundDeserters
    {
        public int Guid { get; set; }
        public byte Type { get; set; }
        public DateTime Datetime { get; set; }
    }
}
