using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameEventPrerequisite
    {
        public byte EventEntry { get; set; }
        public int PrerequisiteEvent { get; set; }
    }
}
