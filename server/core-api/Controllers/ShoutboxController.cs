using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model;
using server.Model.Website;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShoutBoxController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WebsiteContext _websiteContext;
        private readonly UserPermissions _userPermissions;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public ShoutBoxController(UserManager<ApplicationUser> userManager, WebsiteContext websiteContext, UserPermissions userPermissions, IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
            _signalRHub = signalRHub;
        }

        [HttpGet("GetAllShouts")]
        public async Task<IActionResult> GetAllShouts()
        {
            var shouts = await _websiteContext.ShoutBox.OrderByDescending(o => o.Id).ToListAsync();

            await GetAuthorDetails(shouts);

            return Ok(shouts);
        }

        [Authorize]
        [HttpPost("Shout")]
        public async Task<IActionResult> Shout([FromBody] ShoutBoxModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            if (model.Message.Length < 10 || model.Message.Length > 200)
                return RequestHandler.BadRequest("Please enter a valid message");

            var shout = new ShoutBox
            {
                Message = model.Message,
                User = user.Id,
                Date = DateTime.UtcNow,
                Email = user.Email,
                Username = user.UserName.Capitalize()
            };

            await _websiteContext.ShoutBox.AddAsync(shout);
            await _websiteContext.SaveChangesAsync();

            await _signalRHub.Clients.All.ReceiveShoutBoxMessage(shout);

            return Ok();
        }

        [Authorize]
        [HttpPost("ClearShouts")]
        public async Task<IActionResult> ClearShouts()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (rank < (int)UserRanks.GMRanks.Admin)
                return RequestHandler.Unauthorized();

            var shouts = await _websiteContext.ShoutBox.ToListAsync();
            _websiteContext.RemoveRange(shouts);
            await _websiteContext.SaveChangesAsync();

            await _signalRHub.Clients.All.ClearShoutBox();

            return Ok();
        }

        private async Task GetAuthorDetails(IEnumerable<ShoutBox> shouts)
        {
            var authorCache = new Dictionary<string, Tuple<string, string>>();

            foreach (var author in shouts)
            {
                var userId = author.User.ToString();
                if (authorCache.ContainsKey(userId))
                {
                    author.Username = authorCache[userId].Item1;
                    author.Email = authorCache[userId].Item2;
                    continue;
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    continue;

                var authorName = user.UserName.Capitalize();
                author.Username = authorName;
                author.Email = user.Email;
                authorCache.Add(userId, Tuple.Create(authorName, user.Email));
            }
        }
    }
}