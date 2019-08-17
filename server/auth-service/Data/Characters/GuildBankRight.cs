using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GuildBankRight
    {
        public int Guildid { get; set; }
        public byte TabId { get; set; }
        public byte Rid { get; set; }
        public byte Gbright { get; set; }
        public int SlotPerDay { get; set; }
    }
}
