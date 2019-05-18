using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server;
using server.ApiExtensions;
using server.Context;
using server.Data;
using server.Model.DTO;
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
                return RequestHandler.BadRequest("An error occoured when validating your identity");

            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var data = await _websiteContext.Votes.Where(votes => votes.UserId == user.Id && votes.UnsetTimer > now).Select(x => new { x.Site, x.UnsetTimer }).ToListAsync();
            return Ok(data);
        }


        // GET: api/Vote/5
        [HttpGet("GetVoteSites/{id}")]
        public async Task<ActionResult<VoteSite>> GetVoteSites(byte id)
        {
            var voteSite = await _websiteContext.VoteSites.FindAsync(id);

            if (voteSite == null)
            {
                return NotFound();
            }

            return voteSite;
        }

        [Authorize]
        [HttpPost("vote/{id}")]
        public async Task<IActionResult> Vote(int id)
        {
            if (!ModelState.IsValid)
                return RequestHandler.BadRequest("Model is invalid");

            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.BadRequest("An error occoured when validating your identity");

            var voteSite = await _websiteContext.VoteSites.FirstOrDefaultAsync(site => site.Id == id);
            if (voteSite == null)
                return RequestHandler.BadRequest("Invalid vote site");

            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            bool voteCheck = await _websiteContext.Votes.AnyAsync(x => x.UserId == user.Id && x.Site == id && x.UnsetTimer > now);
            if (voteCheck)
                return RequestHandler.BadRequest("You have already voted for this site");

            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(acc => acc.Id == user.AccountId);
            if (accountData == null)
                return RequestHandler.BadRequest("Unable to locate any accountData. Contact an administrator.");

            long unsetTime = voteSite.UnsetTime * 3600 + now;

            var newVote = new Vote
            {
                Site = voteSite.Id,
                UnsetTimer = unsetTime,
                UserId = user.Id
            };

            await _websiteContext.Votes.AddAsync(newVote);
            await _websiteContext.SaveChangesAsync();

            // Add points to ingame acc
            accountData.Vp += voteSite.Value;
            await _authContext.SaveChangesAsync();

            return Ok(new { accountData.Vp, unsetTime });
        }

        private async Task<bool> VoteSitesExists(byte id)
        {
            return await _websiteContext.VoteSites.AnyAsync(e => e.Id == id);
        }

        [HttpGet("GetTopVoters")]
        public async Task<IActionResult> GetTopVoters()
        {
            // 1 Week ago
            long now = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds();

            var topvoter = await (from v in _websiteContext.Votes
                           group v by v.UserId into vg
                           let total = vg.Count()
                           orderby total descending
                           join u in _websiteContext.Users on vg.Key equals u.Id
                           select new { u.UserName, total }).FirstOrDefaultAsync();

            var topvoters = (from v in _websiteContext.Votes
                             where v.UnsetTimer > now
                             group v by v.UserId into vg
                             let total = vg.Count()
                             orderby total descending
                             join u in _websiteContext.Users on vg.Key equals u.Id
                             select new { u.UserName, total }).Take(5);

            return Ok(new { topvoters, topvoter });
        }
    }
}
