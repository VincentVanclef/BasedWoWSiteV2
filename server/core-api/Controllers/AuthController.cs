using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using server.Data.Auth;
using server.Model;
using server.Model.DTO;
using server.ApiExtensions;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using server.Context;
using Microsoft.EntityFrameworkCore;
using server.Data.Website;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuthContext _authContext;
        private readonly UserPermissions _userPermissions;
        private readonly string _jwtSecurityKey;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, AuthContext authContext, UserPermissions userPermissions,
            IConfiguration configuration, IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _userManager = userManager;
            _signInManager = singInManager;
            _authContext = authContext;
            _userPermissions = userPermissions;
            _signalRHub = signalRHub;
            _jwtSecurityKey = configuration.GetSection("JWTKey")
                                               .GetSection("SecureKey")
                                               .Value;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RequestHandler.WrongCredentials();

            var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordCheck)
                return RequestHandler.WrongCredentials();

            var token = TokenHelper.GenerateToken(user, _jwtSecurityKey).SerializeToken();

            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);

            var rank = await _userPermissions.GetGameRankByAccountId(user.AccountId);

            var userDto = new WebAccDTO
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
                Location = user.Location,
                Roles = user.UserRoles?.Select(x => x.Role.Name).ToArray()
            };

            return Ok(new
            {
                token,
                userDto
            });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return RequestHandler.BadRequest("User with that email already exists");

            var newAccount = await CreateIngameAccount(model.Username, model.Password, model.Email);
            if (newAccount == null)
                return RequestHandler.BadRequest("Username is already taken");

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                AccountId = newAccount.Id,
                UserName = model.Username,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                JoinDate = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            var token = TokenHelper.GenerateToken(newUser, _jwtSecurityKey).SerializeToken();

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

            var userDto = new WebAccDTO
            {
                Id = newUser.Id.ToString(),
                AccountId = newUser.AccountId,
                Username = newUser.UserName,
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Email = newUser.Email,
                JoinDate = DateTime.UtcNow,
                Roles = new string[] { },
                Location = "Unknown",
                VP = 0,
                DP = 0
            };

            // Update Client
            var count = await _userManager.Users.CountAsync();
            await _signalRHub.Clients.All.UpdateUserInformations(newUser.UserName, count);

            return Ok(new
            {
                token,
                userDto
            });
        }

        private async Task<Account> CreateIngameAccount(string username, string password, string email)
        {
            var result = await _authContext.Account.AnyAsync(acc => acc.Username == username);
            if (result)
                return null;

            var upperUser = username.ToUpper();
            var upperPass = password.ToUpper();
            var passwordHash = CalculateShaPassHash(upperUser, upperPass);

            int? newId = await _authContext.Account.MaxAsync(u => (int?)u.Id) + 1 ?? 1;

            var newAccount = new Account
            {
                Id = newId.Value,
                Username = upperUser,
                ShaPassHash = passwordHash,
                Email = email,
                RegMail = email,
            };

            return newAccount;
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassDTO model)
        {
            if (model.NewPassword.ToUpper() != model.NewPasswordAgain.ToUpper())
                return RequestHandler.BadRequest("New Passwords do not match");

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(UpdateUserDTO model)
        {
            var updateUsername  = model.Username.Length >= 2;
            var updateFirstName = model.Firstname.Length >= 2;
            var updateLastName  = model.Lastname.Length >= 2;
            var updateLocation  = model.Location.Length >= 2;

            if (!updateFirstName && !updateLastName && !updateLocation && !updateUsername) 
                return RequestHandler.BadRequest("No data sent was suitable for change");

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.BadRequest("Unable to validate your identity");

            if (updateUsername)
            {
                var check = await _userManager.FindByNameAsync(model.Username.ToUpper());
                if (check != null)
                    return RequestHandler.BadRequest("Nickname already taken");

                user.UserName = model.Username;
            }
            if (updateFirstName)
                user.Firstname = model.Firstname;
            if (updateLastName)
                user.Lastname = model.Lastname;
            if (updateLocation)
                user.Location = model.Location;

            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpPost("GetUsername")]
        public async Task<IActionResult> GetUsername([FromBody] UserIdDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return RequestHandler.UserNotFound();

            return Ok(new { username = user.UserName });
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return RequestHandler.UserNotFound();

            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);

            var rank = await _userPermissions.GetGameRankByAccountId(user.AccountId);

            var userDto = new WebAccDTO
            {
                Id = "",
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                VP = accountData.Vp,
                DP = accountData.Dp,
                AccountId = user.AccountId,
                JoinDate = user.JoinDate,
                Location = user.Location,
                Roles = user.UserRoles?.Select(x => x.Role.Name).ToArray()
            };

            return Ok(userDto);
        }

        [HttpGet("GetUserInformations")]
        public async Task<IActionResult> GetUserInformations()
        {
            var user = await _userManager.Users.OrderByDescending(o => o.JoinDate).FirstOrDefaultAsync();
            var count = await _userManager.Users.CountAsync();
            return Ok(new { user = user?.UserName, count });
        }
    }
}