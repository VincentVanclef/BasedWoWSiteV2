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

        [Authorize(Roles = "Admin")]
        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize()
        {
            var isAdmin = await Utilities.IsUserAdmin(User, _userManager);
            if (!isAdmin)
                return RequestHandler.Unauthorized();

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetAdminsAndModerators")]
        public async Task<IActionResult> GetAdminsAndModerators()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var moderators = await _userManager.GetUsersInRoleAsync("Moderator");

            var adminsDto = admins.OrderByDescending(x => x.Id).ToArray();
            var moderatorsDto = moderators.Except(adminsDto.Select(x => x)).OrderByDescending(x => x.Id).ToArray();

            return Ok(new { admins = adminsDto, moderators = moderatorsDto });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SearchUsers/{query}")]
        public async Task<IActionResult> SearchUsers(string query)
        {
            var members = await
                _userManager.Users.Where(x => x.UserName.Contains(query)
                                              || x.Email.Contains(query)
                                              || x.Firstname.Contains(query))
                                              .ToListAsync();

            var count = members.Count();

            return Ok(new
            {
                members = members.Take(10),
                count
            });
        }
    }
}