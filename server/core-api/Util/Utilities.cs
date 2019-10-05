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

        public static string GetClassColor(int _class)
        {
            var color = "";
            switch ((WoWClasses)_class)
            {
                case WoWClasses.CLASS_DEATH_KNIGHT:
                    color = "C41F3B";
                    break;
                case WoWClasses.CLASS_DRUID:
                    color = "FF7D0A";
                    break;
                case WoWClasses.CLASS_HUNTER:
                    color = "ABD473";
                    break;
                case WoWClasses.CLASS_MAGE:
                    color = "69CCF0";
                    break;
                case WoWClasses.CLASS_PALADIN:
                    color = "F58CBA";
                    break;
                case WoWClasses.CLASS_PRIEST:
                    color = "FFFFFF";
                    break;
                case WoWClasses.CLASS_ROGUE:
                    color = "FFF569";
                    break;
                case WoWClasses.CLASS_SHAMAN:
                    color = "0070DE";
                    break;
                case WoWClasses.CLASS_WARLOCK:
                    color = "9482C9";
                    break;
                case WoWClasses.CLASS_WARRIOR:
                    color = "C79C6E";
                    break;
                case WoWClasses.CLASS_NONE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_class), _class, null);
            }

            return color;
        }
    }
}
