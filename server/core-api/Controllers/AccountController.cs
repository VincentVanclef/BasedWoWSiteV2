using System;
using System.Collections.Generic;
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

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == user.AccountId);
            return Ok(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetPermissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var result = await _userPermissions.GetPermissionsByRank(user.AccountId);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SearchAccounts/{query}")]
        public async Task<IActionResult> SearchAccounts(string query)
        {
            int.TryParse(query, out var accountId);

            var accounts = await _authContext.Account.Where(x =>
                                                            x.Username.Contains(query)
                                                         || x.Email.Contains(query)
                                                         || x.LastIp.Contains(query)
                                                         || x.Id == accountId).ToListAsync();

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

            switch (model.AccessId)
            {
                case (byte)GameRoles.Player:
                    {
                        if (current != null)
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

        [Authorize(Roles = "Admin")]
        [HttpPost("BanAccount")]
        public async Task<IActionResult> BanAccount([FromBody] BanAccountModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == model.AccountId);
            if (account == null)
                return RequestHandler.BadRequest("Account does not exist");

            var banData = await _authContext.AccountBanned.AnyAsync(x => x.AccountId == model.AccountId && x.Active == 1);
            if (banData)
                return RequestHandler.BadRequest($"Account {account.Username} is already banned");

            var now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var ban = new AccountBanned
            {
                AccountId = model.AccountId,
                Active = 1,
                BanReason = model.Reason,
                UnbanDate = model.UnBanDate,
                BanDate = now,
                BannedBy = user.UserName
            };

            await _authContext.AccountBanned.AddAsync(ban);
            await _authContext.SaveChangesAsync();

            return Ok(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UnBanAccount/{accountId}")]
        public async Task<IActionResult> UnBanAccount(int accountId)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == accountId);
            if (account == null)
                return RequestHandler.BadRequest("Account does not exist");

            var banData = await _authContext.AccountBanned.Where(x => x.AccountId == accountId && x.Active == 1).ToListAsync();
            if (!banData.Any())
                return RequestHandler.BadRequest($"Account {account.Username} is not currently banned");

            banData.ForEach(x => x.Active = 0);

            _authContext.AccountBanned.UpdateRange(banData);
            await _authContext.SaveChangesAsync();

            return Ok(account);
        }

        [AllowAnonymous]
        [HttpGet("GetBanHistory/{accountId}")]
        public async Task<IActionResult> GetBanHistory(int accountId)
        {
            var history = await RetrieveBanHistory(accountId);
            return Ok(history);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("MuteAccount")]
        public async Task<IActionResult> MuteAccount([FromBody] MuteAccountModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == model.AccountId);
            if (account == null)
                return RequestHandler.BadRequest("Account does not exist");
            
            var now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var mute = new AccountMuted
            {
                AccountId = model.AccountId,
                MuteReason = model.Reason,
                MuteTime = model.MuteMinutes,
                MuteDate = now,
                MutedBy = user.UserName
            };

            account.MuteTime = (model.MuteMinutes * (int)TimeConstants.MINUTE) * -1;
            account.MuteBy = user.UserName;
            account.MuteReason = model.Reason;

            _authContext.Account.Update(account);

            await _authContext.AccountMuted.AddAsync(mute);
            await _authContext.SaveChangesAsync();

            return Ok(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UnMuteAccount/{accountId}")]
        public async Task<IActionResult> UnMuteAccount(int accountId)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var account = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == accountId);
            if (account == null)
                return RequestHandler.BadRequest("Account does not exist");

            var now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (account.MuteTime == 0 || account.MuteTime > now)
                return RequestHandler.BadRequest($"Account {account.Username} is not currently muted");

            account.MuteTime = 0;
            account.MuteBy = "";
            account.MuteReason = "";

            _authContext.Account.Update(account);
            await _authContext.SaveChangesAsync();

            return Ok(account);
        }

        [AllowAnonymous]
        [HttpGet("GetMuteHistory/{accountId}")]
        public async Task<IActionResult> GetMuteHistory(int accountId)
        {
            var history = await RetrieveMuteHistory(accountId);
            return Ok(history);
        }

        private async Task<List<AccountBanned>> RetrieveBanHistory(int accountId)
        {
            return await _authContext.AccountBanned.Where(x => x.AccountId == accountId).ToListAsync();
        }

        private async Task<List<AccountMuted>> RetrieveMuteHistory(int accountId)
        {
            return await _authContext.AccountMuted.Where(x => x.AccountId == accountId).ToListAsync();
        }
    }
}