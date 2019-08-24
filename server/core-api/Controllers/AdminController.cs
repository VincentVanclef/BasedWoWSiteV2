using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly WebsiteContext _websiteContext;
        private readonly AuthContext _authContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserPermissions _userPermissions;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;

        public AdminController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager, UserPermissions userPermissions,
            IHubContext<SignalRHub, ISignalRHub> signalRHub)
        {
            _websiteContext = websiteContext;
            _authContext = authContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
            _signalRHub = signalRHub;
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

        [HttpGet("GetAdmins")]
        public async Task<IActionResult> GetAdmins()
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

            var users = await _userManager.GetUsersInRoleAsync("Admin");

            var admins = users.Select(admin => 
                new UserDTO
                {
                    Id = admin.Id.ToString(),
                    Username = admin.UserName
                }).ToList();

            return Ok(admins);
        }
    }
}