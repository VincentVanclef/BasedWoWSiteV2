using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Character.Guild
{
    public class GetGuildBankEventLogsModel : RealmTypeModel
    {
        [Required]
        public int GuildId { get; set; }

        [Required]
        public int TabId { get; set; }

        [Required]
        public List<int> EventTypes { get; set; }
    }
}
