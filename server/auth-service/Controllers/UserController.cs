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
using server.Context;
using server.Data;
using server.Model;

namespace server.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly WebsiteContext websiteContext;
        private readonly AuthContext authContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager)
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

            var user = await authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.Username);
            if (user != null)
                return BadRequest(new { message = "An account with this username already exists" });

            var UpperUser = model.Username.ToUpper();
            var upperPass = model.Password.ToUpper();
            var passwordHash = CalculateShaPassHash(UpperUser, upperPass);

            var identityUser = await GetUser();
            if (identityUser == null)
                return BadRequest(new { message = "An error occoured when validating your identity" });

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

            return Ok(new {
                message = $"Success! {model.Username} has been succesfully created!"
            });
        }

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }

        [HttpGet("accountdata")]
        public async Task<List<Account>> GetAccountData()
        {
            var user = await GetUser();
            if (user == null)
                return null;

            var data = websiteContext.IngameAccounts.Where(acc => acc.UserId == user.Id);

            List<Account> ingameAccountList = new List<Account>();
            foreach(var acc in data)
            {
                var ingameAcc = await authContext.Account.FirstOrDefaultAsync(x => x.Id == acc.AccountId);
                ingameAccountList.Add(ingameAcc);
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