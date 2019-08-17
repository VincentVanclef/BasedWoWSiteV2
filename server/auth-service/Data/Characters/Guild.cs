using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Guild
    {
        public int Guildid { get; set; }
        public string Name { get; set; }
        public int Leaderguid { get; set; }
        public byte EmblemStyle { get; set; }
        public byte EmblemColor { get; set; }
        public byte BorderStyle { get; set; }
        public byte BorderColor { get; set; }
        public byte BackgroundColor { get; set; }
        public string Info { get; set; }
        public string Motd { get; set; }
        public int Createdate { get; set; }
        public long BankMoney { get; set; }
        public byte Level { get; set; }
        public int Exp { get; set; }
    }
}
