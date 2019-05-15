using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.ApiExtensions;
using server.Context;
using server.Data;
using server.Util;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly WebsiteContext _websiteContext;
        private readonly AuthContext _authContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager)
        {
            _websiteContext = websiteContext;
            _authContext = authContext;
            _userManager = userManager;
        }

        enum GMRanks
        {
            Admin = 3,
            Gamemaster = 2,
            Trial = 1
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.BadRequest("Unable to verify your identity");

            var PermissionsHandler = new UserPermissions(_authContext);

            var rank = await PermissionsHandler.GetRankByAccountId(user.AccountId);
            if (rank < (int)GMRanks.Admin)
                return BadRequest("You are not authorized to enter");

            return Ok();
        }

    }
}