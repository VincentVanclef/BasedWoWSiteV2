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
using server.Model.DTO;
using System.Security.Cryptography;
using server.Context;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AuthContext authContext;
        private readonly IConfiguration configuration;
        private readonly string JwtSecurityKey;

        public AuthController(UserManager<ApplicationUser> userManager, AuthContext authContext, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.authContext = authContext;
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

            var accountData = await authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);

            var userDTO = new WebAccDTO
            {
                Id = user.Id.ToString(),
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                VP = accountData.Vp,
                DP = accountData.Dp,
                AccountId = user.AccountId
            };

            return Ok(new
            {
                token,
                userDTO
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return Unauthorized();

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return BadRequest(new { message = "User with that email already exists" });

            var newAccount = await CreateIngameAccount(model.Username, model.Password, model.Email);
            if (newAccount == null)
                return BadRequest(new { message = "Username is already taken" });

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                AccountId = newAccount.Id,
                UserName = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors.First().Description });

            await authContext.SaveChangesAsync();

            var jwt = GenerateToken(newUser);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            DateTime expires = jwt.ValidTo;

            var userDTO = new WebAccDTO
            {
                Id = newUser.Id.ToString(),
                AccountId = newUser.AccountId,
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Email = newUser.Email,
                VP = 0,
                DP = 0
            };

            return Ok(new
            {
                token,
                userDTO
            });
        }

        private async Task<Account> CreateIngameAccount(string username, string password, string email)
        {
            var result = await authContext.Account.AnyAsync(acc => acc.Username == username);
            if (result)
                return null;

            var UpperUser = username.ToUpper();
            var upperPass = password.ToUpper();
            var passwordHash = CalculateShaPassHash(UpperUser, upperPass);

            int newId = await authContext.Account.MaxAsync(u => u.Id) + 1;

            var newAccount = new Account
            {
                Id = newId,
                Username = UpperUser,
                ShaPassHash = passwordHash,
                Email = email,
                RegMail = email,
            };

            var x = await authContext.Account.AddAsync(newAccount);

            var accountData = new AccountData
            {
                Id = newAccount.Id,
                Dp = 0,
                Vp = 0,
                ExtraMask = 0
            };

            await authContext.AccountData.AddAsync(accountData);

            return newAccount;
        }

        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword(ChangePassDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Unable to verify model" });

            if (model.NewPassword.ToUpper() != model.NewPasswordAgain.ToUpper())
                return BadRequest(new { message = "New Passwords do not match" });

            var user = await GetUser();
            if (user == null)
                return BadRequest(new { message = "Unable to validate your identity" }); ;

            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors.First().Description });

            return Ok();
        }

        private JwtSecurityToken GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim("UserEmail", user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecurityKey));

            var token = new JwtSecurityToken(
                issuer: "Titans-League",
                audience: "Titans-League",
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            return token;
        }

        private async Task<ApplicationUser> GetUser()
        {
            if (!(User.Identity is ClaimsIdentity identity))
                return null;

            var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserEmail");
            if (emailClaim == null)
                return null;

            var user = await userManager.FindByEmailAsync(emailClaim.Value);
            return user;
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }
    }
}