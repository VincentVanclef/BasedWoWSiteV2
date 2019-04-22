using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server.Context;
using server.Data;
using server.Model;
using server.Model.DTO;

namespace server.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly WebsiteContext websiteContext;
        private readonly AuthContext authContext;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager)
        {
            this.websiteContext = websiteContext;
            this.authContext = authContext;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountModel model)
        {
            if (model == null)
                return BadRequest(new { message = "You have to be logged in to create an ingame account" });

            var identityUser = await GetUser();
            if (identityUser == null)
                return BadRequest(new { message = "An error occoured when validating your identity" });

            int count = await websiteContext.IngameAccounts.CountAsync(x => x.UserId == identityUser.Id);
            if (count >= 5)
                return BadRequest(new { message = "You can max have 5 ingame accounts per website account" });

            var user = await authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.Username);
            if (user != null)
                return BadRequest(new { message = "An account with this username already exists" });

            var UpperUser = model.Username.ToUpper();
            var upperPass = model.Password.ToUpper();
            var passwordHash = CalculateShaPassHash(UpperUser, upperPass);
            
            var newAccount = new Account
            {
                Username = UpperUser,
                ShaPassHash = passwordHash,
                Email = identityUser.Email,
                RegMail = identityUser.Email,
            };

            await authContext.Account.AddAsync(newAccount);
            await authContext.SaveChangesAsync();

            var ingameAccount = new IngameAccounts
            {
                UserId = identityUser.Id,
                AccountId = newAccount.Id
            };

            await websiteContext.IngameAccounts.AddAsync(ingameAccount);
            await websiteContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("link/account")]
        public async Task<IActionResult> LinkAccount([FromBody] AccountDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Form data is incorrect" });

            var identityUser = await GetUser();
            if (identityUser == null)
                return BadRequest(new { message = "An error occoured when validating your identity" });

            int count = await websiteContext.IngameAccounts.CountAsync(x => x.UserId == identityUser.Id);
            if (count >= 5)
                return BadRequest(new { message = "You can max have 5 ingame accounts per website account" });

            string UpperUser = model.Username.ToUpper();
            string upperPass = model.Password.ToUpper();
            string passwordHash = CalculateShaPassHash(UpperUser, upperPass);

            var user = await authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.Username && acc.ShaPassHash == passwordHash);
            if (user == null)
                return BadRequest(new { message = "No ingame account found with this username and password" });

            bool check = await websiteContext.IngameAccounts.AnyAsync(acc => acc.AccountId == user.Id);
            if (check)
                return BadRequest(new { message = "This account is already linked to another website account" });

            var ingameAccount = new IngameAccounts
            {
                UserId = identityUser.Id,
                AccountId = user.Id
            };

            await websiteContext.IngameAccounts.AddAsync(ingameAccount);
            await websiteContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Account model is incorrect" });

            bool updateUsername = model.NewUsername != null && model.NewUsername.Length >= 6;
            bool updatePassword = model.NewPassword != null && model.NewPassword.Length >= 8;

            // Malformed packet sent - bypassed veevalidation
            if (!updateUsername && !updatePassword)
                return BadRequest(new { message = "No data sent was suitable for change" });

            string upperUser = model.CurrentUsername.ToUpper();
            string upperPass = model.CurrentPassword.ToUpper();
            string passwordHash = CalculateShaPassHash(upperUser, upperPass);

            var user = await authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.CurrentUsername && acc.ShaPassHash == passwordHash);
            if (user == null)
                return BadRequest(new { message = "Current Password is incorrect. Authentication failed." });

            if (updateUsername)
            {
                // Make sure username is not already taken by someone else
                var result = await authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.NewUsername && acc.Id != user.Id);
                if (result != null)
                    return BadRequest(new { message = "Username is already taken" });
            }

            if (updateUsername)
                user.Username = model.NewUsername.ToUpper();

            if (updatePassword)
            {
                user.ShaPassHash = passwordHash;
                user.V = "";
                user.S = "";
            }

            authContext.Account.Update(user);
            await authContext.SaveChangesAsync();

            return Ok(user.Username);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIngameAccount(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Invalid account id" });

            var identityUser = await GetUser();
            if (identityUser == null)
                return BadRequest(new { message = "An error occoured when validating your identity" });

            var ingameAcc = await websiteContext.IngameAccounts.FirstOrDefaultAsync(acc => acc.AccountId == id);
            if (ingameAcc == null)
                return BadRequest(new { message = "This account is not linked to your website account" });

            websiteContext.IngameAccounts.Remove(ingameAcc);
            await websiteContext.SaveChangesAsync();
            return Ok();
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }

        [HttpGet("data")]
        public async Task<List<string>> GetAccountData()
        {
            var user = await GetUser();
            if (user == null)
                return null;

            var data = websiteContext.IngameAccounts.Where(acc => acc.UserId == user.Id);

            List<string> ingameAccountList = new List<string>();
            foreach(var acc in data)
            {
                var accountData = await authContext.Account.FirstOrDefaultAsync(x => x.Id == acc.AccountId);
                var banData = await authContext.AccountBanned.FirstOrDefaultAsync(x => x.Id == acc.AccountId && x.Active == 1);
                ingameAccountList.Add(JsonConvert.SerializeObject(new { accountData, banData }));
            }

            return ingameAccountList;
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
    }
}