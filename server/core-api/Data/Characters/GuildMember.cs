using System;
using Newtonsoft.Json;

namespace server.Data.Characters
{
    [Serializable]
    public class GuildMember
    {
        public int GuildId { get; set; }
        public byte RankId { get; set; }
        public string Pnote { get; set; }
        public string OffNote { get; set; }

        [JsonProperty("guid")]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
