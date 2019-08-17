using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using server.Context;
using server.Data.Website;

namespace server.Data
{
    public class SeedDatabase
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<WebsiteContext>();
            var userManger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await context.Database.EnsureCreatedAsync();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "admin@admin.dk",
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Firstname = "Vincent",
                    Lastname = "Vanclef"
                };

                var x = userManger.CreateAsync(user, "admin");
            }
        }
    }
}
