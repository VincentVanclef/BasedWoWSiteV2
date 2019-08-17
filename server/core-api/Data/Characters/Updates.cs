using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Updates
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public string State { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int Speed { get; set; }
    }
}
