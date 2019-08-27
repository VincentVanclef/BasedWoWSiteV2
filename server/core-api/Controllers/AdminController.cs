using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.DTO;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [Authorize]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AuthContext _authContext;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public AdminController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, UserPermissions userPermissions,
            IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signalRHub = signalRHub;
            _authContext = authContext;
        }

        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (!isAdmin)
            {
                // Log him out so his token gets removed
                await _signalRHub.Clients.User(user.Id.ToString()).LogoutUser();
                return RequestHandler.Unauthorized();
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetAdminsAndModerators")]
        public async Task<IActionResult> GetAdminsAndModerators()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var moderators = await _userManager.GetUsersInRoleAsync("Moderator");

            var adminsDto = admins.Select(x => new
            {
                id = x.Id.ToString(),
                username = x.UserName
            }).ToArray();
            var moderatorsDto = moderators.Select(x => new
            {
                id = x.Id.ToString(),
                username = x.UserName
            }).Except(adminsDto.Select(x => x)).ToArray();

            return Ok(new { admins = adminsDto, moderators = moderatorsDto });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SearchUsers/{query}")]
        public async Task<IActionResult> SearchUsers(string query)
        {
            var result = await _userManager.Users.Where(x => x.UserName.Contains(query)).Include(x => x.UserRoles).ToListAsync();
            var count = result.Count();

            return Ok(new
            {
                members = result.Take(10),
                count
            });
        }
    }
}