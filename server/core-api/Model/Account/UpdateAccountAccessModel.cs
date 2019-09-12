using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using server.Util;

namespace server.Model.Account
{
    public class UpdateAccountAccessModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public List<AccessData> AccessData { get; set; }
    }

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
