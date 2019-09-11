using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Account
{
    [Serializable]
    public class BanAccountModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int UnBanDate { get; set; }

        [Required]
        public string Reason { get; set; }
    }
}