using System;
using System.Linq;
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
using server.Data.Auth;
using server.Data.Website;
using server.Model.Account;
using server.Model.DTO;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Authorize]
    [Route("/[controller]")]
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

        [HttpPost("Update/Username")]
        public async Task<IActionResult> UpdateUsername([FromBody] UpdateAccountDTO model)
        {
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

        [HttpPost("Update/Password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateAccountDTO model)
        {
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

        [HttpGet("GetAccountData")]
        public async Task<IActionResult> GetAccountData()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return null;

            var accountData = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == user.AccountId);
            var banData = await _authContext.AccountBanned.FirstOrDefaultAsync(x => x.Id == user.AccountId && x.Active == 1);
            return Ok(JsonConvert.SerializeObject(new { accountData, banData }));
        }

        [HttpGet("GetPermissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var result = await _userPermissions.GetPermissionsByRank(user.AccountId);

            return Ok(result);
        }

        [HttpGet("GetTotalAccounts")]
        public async Task<IActionResult> GetTotalAccounts()
        {
            return Ok(await _authContext.Account.CountAsync());
        }

        [HttpGet("SearchAccounts/{query}")]
        public async Task<IActionResult> SearchAccounts(string query)
        {
            int.TryParse(query, out var accountId);

            var accounts = await _authContext.Account.Where(x =>
                                                            x.Username.Contains(query)
                                                         || x.Email.Contains(query)
                                                         || x.LastIp.Contains(query)
                                                         || x.Id == accountId).Select(x => new
                                                         {
                                                             x.Id,
                                                             x.Username,
                                                             x.Email,
                                                             x.LastIp,
                                                             x.Joindate,
                                                             x.LastLogin,
                                                             x.Muteby,
                                                             x.Mutereason,
                                                             x.Mutetime,
                                                             x.Locked,
                                                             x.AccountAccess
                                                         }).ToListAsync();

            if (accountId > 0)
                accounts = accounts.Where(x => x.Id == accountId).ToList();

            var count = accounts.Count();

            return Ok(new
            {
                accounts = accounts.Take(10),
                count
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateAccountAccess")]
        public async Task<IActionResult> UpdateAccountAccess([FromBody] UpdateAccountAccessModel model)
        {
            var current = await _authContext.AccountAccess.FirstOrDefaultAsync(x => x.AccountId == model.AccountId && x.RealmId == model.RealmId);
            var removeAll = model.RealmId == -1 && model.AccessId == (byte)GameRoles.Player;

            switch (model.AccessId)
            {
                case (byte)GameRoles.Player:
                    {
                        if (removeAll)
                        {
                            var allAccess = _authContext.AccountAccess.Where(x => x.AccountId == model.AccountId).ToArray();
                            _authContext.AccountAccess.RemoveRange(allAccess);
                        }
                        else if (current != null)
                        {
                            _authContext.AccountAccess.Remove(current);
                        }
                    }
                    break;
                case (byte)GameRoles.Trial:
                case (byte)GameRoles.GameMaster:
                case (byte)GameRoles.Admin:
                    {
                        if (current != null)
                        {
                            current.Gmlevel = model.AccessId;
                            _authContext.AccountAccess.Update(current);
                        }
                        else
                        {
                            var accountAccess = new AccountAccess
                            {
                                AccountId = model.AccountId,
                                Gmlevel = model.AccessId,
                                RealmId = model.RealmId
                            };

                            await _authContext.AccountAccess.AddAsync(accountAccess);
                        }
                    }
                    break;
            }

            await _authContext.SaveChangesAsync();

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == model.AccountId);
            return Ok(account);
        }
    }
}