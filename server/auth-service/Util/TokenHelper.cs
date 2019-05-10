using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using server.Data;

namespace server.Util
{
    public class TokenHelper
    {
        public static async Task<ApplicationUser> GetUser(ClaimsPrincipal User, UserManager<ApplicationUser> userManager)
        {
            if (!(User.Identity is ClaimsIdentity identity))
                return null;

            var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserEmail");
            if (emailClaim == null)
                return null;

            var user = await userManager.FindByEmailAsync(emailClaim.Value);
            return user;
        }
    }
}
