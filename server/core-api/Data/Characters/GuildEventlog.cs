using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Characters
{
    public class GuildEventLog
    {
        public int GuildId { get; set; }
        public int LogGuid { get; set; }
        public byte EventType { get; set; }
        public int PlayerGuid1 { get; set; }
        public int PlayerGuid2 { get; set; }
        public byte NewRank { get; set; }
        public int TimeStamp { get; set; }

        [NotMapped]
        public string PlayerName1 { get; set; }

        [NotMapped]
        public string PlayerName2 { get; set; }
    }
}
