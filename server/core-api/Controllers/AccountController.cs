using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.DTO;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Authorize]
    [Route("/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebsiteContext _websiteContext;
        private readonly AuthContext _authContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserPermissions _userPermissions;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public AccountController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager, UserPermissions userPermissions, IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _websiteContext = websiteContext;
            _authContext = authContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
            _signalRHub = signalRHub;
        }

        [HttpPost("update/username")]
        public async Task<IActionResult> UpdateUsername([FromBody] UpdateAccountDTO model)
        {
            if (!ModelState.IsValid)
                return RequestHandler.BadRequest("Account model is incorrect");

            string CurrentUsername = model.CurrentUsername.ToUpper();
            string CurrentPassword = model.CurrentPassword.ToUpper();
            string CurrentPasswordHash = CalculateShaPassHash(CurrentUsername, CurrentPassword);

            var user = await _authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.CurrentUsername && acc.ShaPassHash == CurrentPasswordHash);
            if (user == null)
                return RequestHandler.BadRequest("Current Password is incorrect. Authentication failed.");

            string NewUsername = model.NewUsername.ToUpper();

            bool check = await _authContext.Account.AnyAsync(acc => acc.Username == NewUsername);
            if (check)
                return RequestHandler.BadRequest($"Username {model.NewUsername} is already taken. Please try again.");

            // Need to change the password as username is used in the hash
            string NewPasswordHash = CalculateShaPassHash(NewUsername, CurrentPassword);

            user.Username = NewUsername;
            user.ShaPassHash = NewPasswordHash;
            user.V = "";
            user.S = "";

            _authContext.Account.Update(user);
            await _authContext.SaveChangesAsync();

            return Ok(user.Username);
        }

        [HttpPost("update/password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateAccountDTO model)
        {
            if (!ModelState.IsValid)
                return RequestHandler.BadRequest("Account model is incorrect");

            string CurrentUsername = model.CurrentUsername.ToUpper();
            string CurrentPassword = model.CurrentPassword.ToUpper();
            string CurrentPasswordHash = CalculateShaPassHash(CurrentUsername, CurrentPassword);

            var user = await _authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.CurrentUsername && acc.ShaPassHash == CurrentPasswordHash);
            if (user == null)
                return RequestHandler.BadRequest("Current Password is incorrect. Authentication failed.");

            // Need to change the password as username is used in the hash
            string NewPassword = model.NewPassword.ToUpper();
            string NewPasswordHash = CalculateShaPassHash(CurrentUsername, NewPassword);

            user.ShaPassHash = NewPasswordHash;
            user.V = "";
            user.S = "";

            _authContext.Account.Update(user);
            await _authContext.SaveChangesAsync();

            return Ok(user.Username);
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetAccountData()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return null;

            var accountData = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == user.AccountId);
            var banData = await _authContext.AccountBanned.FirstOrDefaultAsync(x => x.Id == user.AccountId && x.Active == 1);
            return Ok(JsonConvert.SerializeObject(new { accountData, banData }));
        }

        [HttpGet("GetAccountPermissions")]
        public async Task<IActionResult> GetAccountPermissions()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var result = await _userPermissions.GetPermissionsByRank(user.AccountId);

            return Ok(result);
        }
    }
}