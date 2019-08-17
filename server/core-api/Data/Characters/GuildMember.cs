using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GuildMember
    {
        public int Guildid { get; set; }
        public int Guid { get; set; }
        public byte Rank { get; set; }
        public string Pnote { get; set; }
        public string Offnote { get; set; }
    }
}
