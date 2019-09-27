using System.ComponentModel.DataAnnotations;

namespace server.Model.Character.Guild
{
    public class GetGuildByNameModel : RealmTypeModel
    {
        [Required]
        public string GuildName { get; set; }
    }
}
