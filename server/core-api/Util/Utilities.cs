using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using server.ApiExtensions;
using server.Data.Website;

namespace server.Util
{
    public static class Utilities
    {
        public static async Task<bool> IsUserSuperAdmin(ClaimsPrincipal claimsPrincipal, UserManager<ApplicationUser> userManager)
        {
            var user = await TokenHelper.GetUser(claimsPrincipal, userManager);
            if (user == null)
                return false;

            return await userManager.IsInRoleAsync(user, "Super Admin");
        }

        public static async Task<bool> IsUserAdmin(ClaimsPrincipal claimsPrincipal, UserManager<ApplicationUser> userManager)
        {
            var user = await TokenHelper.GetUser(claimsPrincipal, userManager);
            if (user == null)
                return false;

            return await userManager.IsInRoleAsync(user, "Admin");
        }

        public static async Task<bool> IsUserAdmin(this ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            return await userManager.IsInRoleAsync(user, "Admin");
        }

        public static async Task<bool> IsUserModerator(ClaimsPrincipal claimsPrincipal, UserManager<ApplicationUser> userManager)
        {
            var user = await TokenHelper.GetUser(claimsPrincipal, userManager);
            if (user == null)
                return false;

            return await userManager.IsInRoleAsync(user, "Moderator");
        }
    }
}
