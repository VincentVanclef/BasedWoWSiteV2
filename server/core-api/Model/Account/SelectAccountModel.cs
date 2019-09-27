using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Account
{
    [Serializable]
    public class SelectAccountModel : RealmTypeModel
    {
        [Required]
        public int AccountId { get; set; }
    }
}
