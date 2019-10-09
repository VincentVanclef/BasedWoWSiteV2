using System;
using Microsoft.AspNetCore.Identity;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        //public virtual ApplicationUser User { get; set; }
    }
}