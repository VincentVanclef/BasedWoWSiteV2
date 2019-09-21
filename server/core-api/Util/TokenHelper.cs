using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using server.Data.Website;

namespace server.Util
{
    public static class TokenHelper
    {
        public static async Task<ApplicationUser> GetUser(ClaimsPrincipal user, UserManager<ApplicationUser> userManager)
        {
            if (!(user.Identity is ClaimsIdentity identity))
                return null;

            var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (emailClaim == null)
                return null;

            return await userManager.FindByEmailAsync(emailClaim.Value);
        }

        public static SecurityToken GenerateToken(ApplicationUser user, string securityKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Audience = "Titans-League",
                Issuer = "Titans-League",
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            // Add Roles
            user.UserRoles?.ForEach(role => tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name)));

            return new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
        }

        public static string SerializeToken(this SecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
