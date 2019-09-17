using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Characters
{
    public class GuildMember
    {
        public int GuildId { get; set; }
        public int Guid { get; set; }
        public byte RankId { get; set; }
        public string Pnote { get; set; }
        public string OffNote { get; set; }

        [NotMapped]
        public Character Character { get; set; }
    }
}
