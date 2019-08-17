using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GuildBankItem
    {
        public int Guildid { get; set; }
        public byte TabId { get; set; }
        public byte SlotId { get; set; }
        public int ItemGuid { get; set; }
    }
}
