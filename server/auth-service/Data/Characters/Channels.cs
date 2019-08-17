using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Channels
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public byte Announce { get; set; }
        public byte Ownership { get; set; }
        public string Password { get; set; }
        public string BannedList { get; set; }
        public int LastUsed { get; set; }
    }
}
