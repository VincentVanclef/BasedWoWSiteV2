using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Account
{
    [Serializable]
    public class MuteAccountModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int MuteMinutes { get; set; }

        [Required]
        public string Reason { get; set; }
    }
}