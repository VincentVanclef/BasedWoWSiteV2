using System.ComponentModel.DataAnnotations;
using server.Util;

namespace server.Model.Account
{
    public class AccessData
    {
        [Required]
        [Range(-1, (int)RealmType.Max)]
        public RealmType RealmType { get; set; }

        [Required]
        [Range((int)GameRoles.Player, (int)GameRoles.Admin)]
        public byte AccessId { get; set; }
    }
}