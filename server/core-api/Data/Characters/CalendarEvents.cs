using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CalendarEvents
    {
        public long Id { get; set; }
        public int Creator { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Type { get; set; }
        public int Dungeon { get; set; }
        public int Eventtime { get; set; }
        public int Flags { get; set; }
        public int Time2 { get; set; }
    }
}
