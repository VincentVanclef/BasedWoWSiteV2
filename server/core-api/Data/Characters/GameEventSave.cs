using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GameEventSave
    {
        public byte EventEntry { get; set; }
        public byte State { get; set; }
        public int NextStart { get; set; }
    }
}
