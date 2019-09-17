using System.ComponentModel.DataAnnotations;

namespace server.Model.Character.Guild
{
    public class GetGuildByIdModel : RealmTypeModel
    {
        [Required]
        public int GuildId { get; set; }
    }
}
