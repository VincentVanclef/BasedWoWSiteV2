using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Data.Characters
{
    [Serializable]
    public class Guild
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeaderGuid { get; set; }
        public byte EmblemStyle { get; set; }
        public byte EmblemColor { get; set; }
        public byte BorderStyle { get; set; }
        public byte BorderColor { get; set; }
        public byte BackgroundColor { get; set; }
        public string Info { get; set; }
        public string Motd { get; set; }
        public int CreateDate { get; set; }
        public long BankMoney { get; set; }
        public byte Level { get; set; }
        public int Exp { get; set; }

        public virtual List<GuildMember> GuildMembers { get; set; }
        public virtual List<GuildRank> GuildRanks { get; set; }
    }
}
