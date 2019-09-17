using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public class GuildBankEventLog
    {
        public int GuildId { get; set; }
        public int LogGuid { get; set; }
        public byte TabId { get; set; }
        public byte EventType { get; set; }
        public int PlayerGuid { get; set; }
        public int ItemOrMoney { get; set; }
        public short ItemStackCount { get; set; }
        public byte DestTabId { get; set; }
        public int TimeStamp { get; set; }
    }
}
