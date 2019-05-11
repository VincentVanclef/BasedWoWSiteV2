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
using server.Util;

namespace server.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthContext _authContext;
        private readonly IConfiguration _configuration;
        private readonly string _JwtSecurityKey;

        public AuthController(UserManager<ApplicationUser> userManager, AuthContext authContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authContext = authContext;
            _JwtSecurityKey = configuration.GetSection("JWTKey")
                                               .GetSection("SecureKey")
                                               .Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null)
                return Unauthorized();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            bool passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordCheck)
                return BadRequest(new { message = "Username or password is incorrect" });

            var jwt = GenerateToken(user);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            DateTime expires = jwt.ValidTo;

            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);

            var userDTO = new WebAccDTO
            {
                Id = user.Id.ToString(),
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                VP = accountData.Vp,
                DP = accountData.Dp,
                AccountId = user.AccountId,
                JoinDate = user.JoinDate,
                Location = user.Location
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

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return BadRequest(new { message = "User with that email already exists" });

            var newAccount = await CreateIngameAccount(model.Username, model.Password, model.Email);
            if (newAccount == null)
                return BadRequest(new { message = "Username is already taken" });

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                AccountId = newAccount.Id,
                UserName = model.Username,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                JoinDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors.First().Description });

            // All good - now we add and save the new entities
            var accountData = new AccountData
            {
                Id = newAccount.Id,
                Dp = 0,
                Vp = 0,
                ExtraMask = 0
            };

            await _authContext.Account.AddAsync(newAccount);
            await _authContext.AccountData.AddAsync(accountData);
            await _authContext.SaveChangesAsync();

            var jwt = GenerateToken(newUser);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            DateTime expires = jwt.ValidTo;

            var userDTO = new WebAccDTO
            {
                Id = newUser.Id.ToString(),
                AccountId = newUser.AccountId,
                Username = newUser.UserName,
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
            var result = await _authContext.Account.AnyAsync(acc => acc.Username == username);
            if (result)
                return null;

            var UpperUser = username.ToUpper();
            var upperPass = password.ToUpper();
            var passwordHash = CalculateShaPassHash(UpperUser, upperPass);

            int? newId = await _authContext.Account.MaxAsync(u => (int?)u.Id) + 1;
            if (newId == null)
                newId = 1;

            var newAccount = new Account
            {
                Id = newId.Value,
                Username = UpperUser,
                ShaPassHash = passwordHash,
                Email = email,
                RegMail = email,
            };

            return newAccount;
        }

        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword(ChangePassDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Unable to verify model" });

            if (model.NewPassword.ToUpper() != model.NewPasswordAgain.ToUpper())
                return BadRequest(new { message = "New Passwords do not match" });

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return BadRequest(new { message = "Unable to validate your identity" });

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors.First().Description });

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateUserDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Unable to verify model" });

            bool UpdateUsername  = model.Username.Length >= 2;
            bool UpdateFirstName = model.Firstname.Length >= 2;
            bool UpdateLastName  = model.Lastname.Length >= 2;
            bool UpdateLocation  = model.Location.Length >= 2;

            if (!UpdateFirstName && !UpdateLastName && !UpdateLocation && !UpdateUsername) 
                return BadRequest(new { message = "No data sent was suitable for change" });

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return BadRequest(new { message = "Unable to validate your identity" });

            if (UpdateUsername)
            {
                var check = await _userManager.FindByNameAsync(model.Username.ToUpper());
                if (check != null)
                    return BadRequest(new { message = "Nickname already taken" });

                user.UserName = model.Username;
            }
            if (UpdateFirstName)
                user.Firstname = model.Firstname;
            if (UpdateLastName)
                user.Lastname = model.Lastname;
            if (UpdateLocation)
                user.Location = model.Location;

            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpPost("getusername")]
        public async Task<IActionResult> GetUsername([FromBody] UserIdDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return RequestHandler.BadRequest("No user with this id exists");

            return Ok(new { username = user.UserName });
        }

        private JwtSecurityToken GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim("UserEmail", user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSecurityKey));

            var token = new JwtSecurityToken(
                issuer: "Titans-League",
                audience: "Titans-League",
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            return token;
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }
    }
}