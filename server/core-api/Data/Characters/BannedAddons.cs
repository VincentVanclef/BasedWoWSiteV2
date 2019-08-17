using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class BannedAddons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
