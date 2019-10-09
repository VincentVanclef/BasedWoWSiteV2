using System;
using Microsoft.AspNetCore.Identity;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        //public virtual ApplicationUser User { get; set; }
    }
}