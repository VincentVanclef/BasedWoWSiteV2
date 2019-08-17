using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GuildEventlog
    {
        public int Guildid { get; set; }
        public int LogGuid { get; set; }
        public byte EventType { get; set; }
        public int PlayerGuid1 { get; set; }
        public int PlayerGuid2 { get; set; }
        public byte NewRank { get; set; }
        public int TimeStamp { get; set; }
    }
}
