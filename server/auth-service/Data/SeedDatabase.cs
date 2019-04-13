using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace server.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<WebsiteContext>();
            var userManger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreatedAsync();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "admin@admin.dk",
                    Id = Guid.NewGuid(),
                    UserName = "admin"
                };

                var x = userManger.CreateAsync(user, "admin");
            }
        }
    }
}
