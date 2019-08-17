using System;
using System.Collections.Generic;

namespace server.Data.Auth
{
    public partial class Account
    {
        public Account()
        {
            RbacAccountPermissions = new HashSet<RbacAccountPermissions>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string ShaPassHash { get; set; }
        public string V { get; set; }
        public string S { get; set; }
        public string Email { get; set; }
        public string RegMail { get; set; }
        public DateTimeOffset Joindate { get; set; }
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

        public virtual ICollection<RbacAccountPermissions> RbacAccountPermissions { get; set; }
    }
}
