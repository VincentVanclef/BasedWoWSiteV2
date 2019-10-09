using System;
using Microsoft.AspNetCore.Identity;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}