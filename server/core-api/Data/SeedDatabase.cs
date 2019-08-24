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
        //public static async Task InitializeAsync(IServiceProvider serviceProvider)
        //{
        //    //var context = serviceProvider.GetRequiredService<WebsiteContext>();
        //    //var userManger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    //var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        //    //await context.Database.EnsureCreatedAsync();

        //    //var user = await userManger.FindByEmailAsync("admin@titans-league.com");

        //    //await roleManager.CreateAsync(new ApplicationRole("Admin"));
        //    //await userManger.AddToRoleAsync(user, "Admin");
        //    //await context.SaveChangesAsync();
        //}
    }
}
