using Newtonsoft.Json;

namespace server.Data.Characters
{
    public class CharacterBanned
    {
        [JsonProperty("guid")]
        public int CharacterId { get; set; }
        public int BanDate { get; set; }
        public int UnbanDate { get; set; }
        public string BannedBy { get; set; }
        public string BanReason { get; set; }
        public byte Active { get; set; }
    }
}
