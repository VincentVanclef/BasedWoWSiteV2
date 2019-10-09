using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public int AccountId { get; set; }

        [MinLength(2)]
        [MaxLength(16)]
        public string Firstname { get; set; }

        [MinLength(2)]
        [MaxLength(16)]
        public string Lastname { get; set; }
        public byte Online { get; set; }
        public DateTime JoinDate { get; set; }
        public string Location { get; set; }
        public int TotalVotes { get; set; }

        public bool IsOnline()
        {
            return Online == 1;
        }

        //public virtual List<ApplicationUserClaim> Claims { get; set; }
        //public virtual List<ApplicationUserLogin> Logins { get; set; }
        //public virtual List<ApplicationUserToken> Tokens { get; set; }

        public virtual List<ApplicationUserRole> UserRoles { get; set; }

        // Overrides
        [JsonIgnore]
        public override string PasswordHash { get; set; }

        [JsonIgnore]

        public override string ConcurrencyStamp { get; set; }

        [JsonIgnore]
        public override int AccessFailedCount { get; set; }

        [JsonIgnore]
        public override string PhoneNumber { get; set; }

        [JsonIgnore]
        public override bool LockoutEnabled { get; set; }

        [JsonIgnore]
        public override bool EmailConfirmed { get; set; }

        [JsonIgnore]
        public override bool PhoneNumberConfirmed { get; set; }

        [JsonIgnore]
        public override string SecurityStamp { get; set; }

        [JsonIgnore]
        public override bool TwoFactorEnabled { get; set; }

        [JsonIgnore]
        public override DateTimeOffset? LockoutEnd { get; set; }
    }
}
