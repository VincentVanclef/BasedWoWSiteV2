using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name) : base(name)
        {
        }

        public virtual List<ApplicationUserRole> UserRoles { get; set; }
        //public virtual List<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}