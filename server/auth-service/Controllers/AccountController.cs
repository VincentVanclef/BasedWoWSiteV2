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
    [Route("/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly WebsiteContext _websiteContext;
        private readonly AuthContext _authContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager)
        {
            _websiteContext = websiteContext;
            _authContext = authContext;
            _userManager = userManager;
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

            var user = await _authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.CurrentUsername && acc.ShaPassHash == passwordHash);
            if (user == null)
                return BadRequest(new { message = "Current Password is incorrect. Authentication failed." });

            if (updateUsername)
            {
                // Make sure username is not already taken by someone else
                var result = await _authContext.Account.FirstOrDefaultAsync(acc => acc.Username == model.NewUsername && acc.Id != user.Id);
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

            _authContext.Account.Update(user);
            await _authContext.SaveChangesAsync();

            return Ok(user.Username);
        }

        /*[HttpDelete("delete/{id}")]
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
        }*/

        private string CalculateShaPassHash(string name, string password)
        {
            SHA1 sha = SHA1.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(name + ":" + password)).ToHexString();
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetAccountData()
        {
            var user = await GetUser();
            if (user == null)
                return null;

            var accountData = await _authContext.Account.FirstOrDefaultAsync(x => x.Id == user.AccountId);
            var banData = await _authContext.AccountBanned.FirstOrDefaultAsync(x => x.Id == user.AccountId && x.Active == 1);
            return Ok(JsonConvert.SerializeObject(new { accountData, banData }));
        }

        private async Task<ApplicationUser> GetUser()
        {
            if (!(User.Identity is ClaimsIdentity identity))
                return null;

            var emailClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserEmail");
            if (emailClaim == null)
                return null;

            var user = await _userManager.FindByEmailAsync(emailClaim.Value);
            return user;
        }
    }
}