using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace server.Data.Auth
{
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string ShaPassHash { get; set; }

        [JsonIgnore]
        public string V { get; set; }

        [JsonIgnore]
        public string S { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string RegMail { get; set; }
        public DateTime JoinDate { get; set; }
        public string LastIp { get; set; }
        public string LastAttemptIp { get; set; }
        public int FailedLogins { get; set; }
        public byte Locked { get; set; }

        [JsonIgnore]
        public string LockCountry { get; set; }
        public DateTime LastLogin { get; set; }
        public byte Online { get; set; }
        public long MuteTime { get; set; }
        public string MuteReason { get; set; }
        public string MuteBy { get; set; }

        [JsonIgnore]
        public byte Locale { get; set; }
        public string Os { get; set; }
        public int Recruiter { get; set; }

        public virtual List<AccountAccess> AccountAccess { get; set; }
        public virtual List<AccountBanned> AccountBanned { get; set; }
        public virtual List<AccountMuted> AccountMuted { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual List<RbacAccountPermissions> RbacAccountPermissions { get; set; }
    }
}
