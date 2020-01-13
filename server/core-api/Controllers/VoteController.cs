using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly WebsiteContext _websiteContext;
        private readonly AuthContext _authContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public VoteController(WebsiteContext websiteContext, AuthContext authContext, UserManager<ApplicationUser> userManager)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _authContext = authContext;
        }

        // GET: api/Vote
        [HttpGet("GetVoteSites")]
        public async Task<ActionResult<IEnumerable<VoteSite>>> GetVoteSites()
        {
            return await _websiteContext.VoteSites.ToListAsync();
        }

        [Authorize]
        [HttpGet("GetVoteTimers")]
        public async Task<IActionResult> GetVoteTimers()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return Unauthorized();

            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var timers = await _websiteContext.Votes
                                            .Where(votes => votes.UserId == user.Id && votes.UnsetTimer > now)
                                            .Select(x => new { x.Site, x.UnsetTimer })
                                            .ToListAsync();

            return Ok(timers);
        }


        // GET: api/Vote/5
        [HttpGet("GetVoteSites/{id}")]
        public async Task<IActionResult> GetVoteSites(byte id)
        {
            var voteSite = await _websiteContext.VoteSites.FindAsync(id);

            if (voteSite == null)
                return NotFound();

            return Ok(voteSite);
        }

        [Authorize]
        [HttpPost("vote/{id}")]
        public async Task<IActionResult> Vote(int id)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var voteSite = await _websiteContext.VoteSites.FirstOrDefaultAsync(site => site.Id == id);
            if (voteSite == null)
                return RequestHandler.BadRequest("Invalid vote site");

            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var voteCheck = await _websiteContext.Votes.AnyAsync(x => x.UserId == user.Id && x.Site == id && x.UnsetTimer > now);
            if (voteCheck)
                return RequestHandler.BadRequest("You have already voted for this site");

            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);
            if (accountData == null)
                return RequestHandler.Unauthorized();

            var unsetTime = voteSite.UnsetTime * 3600 + now;

            var newVote = new Vote
            {
                Site = voteSite.Id,
                UnsetTimer = unsetTime,
                UserId = user.Id
            };

            // Update TotalVotes
            user.TotalVotes += 1;

            // Add new vote to db
            await _websiteContext.Votes.AddAsync(newVote);
            await _websiteContext.SaveChangesAsync();

            // Add points to ingame acc
            accountData.Vp += voteSite.Value;
            await _authContext.SaveChangesAsync();

            return Ok(new { accountData.Vp, unsetTime });
        }

        [HttpGet("GetTopVoters")]
        public async Task<IActionResult> GetTopVoters()
        {
            var now = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds();

            var topvoter = await _websiteContext.Users.OrderByDescending(o => o.TotalVotes).Take(1).Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email,
                x.TotalVotes
            }).FirstOrDefaultAsync();

            var topvoters = (from v in _websiteContext.Votes
                             where v.UnsetTimer > now
                             group v by v.UserId into vg
                             let total = vg.Count()
                             orderby total descending
                             join u in _websiteContext.Users on vg.Key equals u.Id
                             select new { u.Id, u.UserName, u.Email, total }).Take(5);

            return Ok(new { topvoters, topvoter });
        }
    }
}
