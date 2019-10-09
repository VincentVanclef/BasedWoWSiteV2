using System;
using Microsoft.AspNetCore.Identity;

namespace server.Data.Website
{
    [Serializable]
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        //public virtual ApplicationRole Role { get; set; }
    }
}