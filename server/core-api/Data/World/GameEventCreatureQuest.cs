using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameEventCreatureQuest
    {
        public byte EventEntry { get; set; }
        public int Id { get; set; }
        public int Quest { get; set; }
    }
}
