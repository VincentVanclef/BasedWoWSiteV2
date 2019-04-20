using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Model;
using server.ApiExtensions;
using server.Data.Auth;

namespace server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly string JwtSecurityKey;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.JwtSecurityKey = configuration.GetSection("JWTKey")
                                               .GetSection("SecureKey")
                                               .Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null)
                return Unauthorized();

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest(new { message = "User not found" });

            bool passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordCheck)
                return BadRequest(new { message = "Username or password is incorrect" });

            var jwt = GenerateToken(user);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            DateTime expires = jwt.ValidTo;

            var userDTO = new WebAccDTO
            {
                Id = user.Id.ToString(),
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email
            };

            return Ok(new
            {
                token,
                userDTO,
                expires
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (model == null)
                return Unauthorized();

            /*var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
                return BadRequest(new { message = "User with that email already exists" });*/

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors.First().Description });

            var jwt = GenerateToken(newUser);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            DateTime expires = jwt.ValidTo;

            var userDTO = new WebAccDTO
            {
                Id = newUser.Id.ToString(),
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Email = newUser.Email
            };

            return Ok(new
            {
                token,
                userDTO,
                expires
            });
        }

        private JwtSecurityToken GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecurityKey));

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            return token;
        }
    }
}