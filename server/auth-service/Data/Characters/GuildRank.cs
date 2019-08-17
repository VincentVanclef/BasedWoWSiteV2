using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GuildRank
    {
        public int Guildid { get; set; }
        public byte Rid { get; set; }
        public string Rname { get; set; }
        public int Rights { get; set; }
        public int BankMoneyPerDay { get; set; }
    }
}
