using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace server.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public override string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ApplicationRole : IdentityRole<Guid> { }
}
