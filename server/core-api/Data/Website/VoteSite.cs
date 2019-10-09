using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class VoteSite
    {
        [Key]
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public byte Value { get; set; }
        public int UnsetTime { get; set; }
    }
}
