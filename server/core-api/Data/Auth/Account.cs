using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Auth
{
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string ShaPassHash { get; set; }
        public string V { get; set; }
        public string S { get; set; }
        public string Email { get; set; }
        public string RegMail { get; set; }
        public DateTime Joindate { get; set; }
        public string LastIp { get; set; }
        public string LastAttemptIp { get; set; }
        public int FailedLogins { get; set; }
        public byte Locked { get; set; }
        public string LockCountry { get; set; }
        public DateTime LastLogin { get; set; }
        public byte Online { get; set; }
        public long Mutetime { get; set; }
        public string Mutereason { get; set; }
        public string Muteby { get; set; }
        public byte Locale { get; set; }
        public string Os { get; set; }
        public int Recruiter { get; set; }

        public virtual List<AccountAccess> AccountAccess { get; set; }

        public virtual List<RbacAccountPermissions> RbacAccountPermissions { get; set; }
    }
}
