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
        private readonly UserPermissions _userPermissions;

        public AdminController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager, UserPermissions userPermissions)
        {
            _websiteContext = websiteContext;
            _authContext = authContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
        }

        enum GMRanks
        {
            Admin = 3,
            Gamemaster = 2,
            Trial = 1
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.BadRequest("Unable to verify your identity");

            var rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (rank < (int)GMRanks.Admin)
                return BadRequest("You are not authorized to enter");

            return Ok();
        }

        /// <summary>
        /// Validate user rank is high enough
        /// </summary>
        /// <param name="rank">User Rank</param>
        /// <returns>True if user rank is higher than required rank</returns>
        [HttpGet("/validate/rank/{rank}")]
        public async Task<IActionResult> ValidateRank(int rank)
        {
            if (rank <= 0)
                return RequestHandler.BadRequest("Invalid rank");

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.BadRequest("Unable to verify your identity");

            var user_rank = await _userPermissions.GetRankByAccountId(user.AccountId);
            if (user_rank < rank)
                return BadRequest("You are not authorized to enter");

            return Ok();
        }
    }
}