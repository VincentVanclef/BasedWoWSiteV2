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
using server.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly WebsiteContext websiteContext;
        private readonly UserManager<ApplicationUser> userManager;

        public VoteController(WebsiteContext context, UserManager<ApplicationUser> userManager)
        {
            this.websiteContext = context;
            this.userManager = userManager;
        }

        // GET: api/Vote
        [HttpGet("GetVoteSites")]
        public async Task<ActionResult<IEnumerable<VoteSite>>> GetVoteSites()
        {
            return await websiteContext.VoteSites.ToListAsync();
        }

        [HttpGet("GetVoteTimers")]
        public async Task<IActionResult> GetVoteTimers()
        {
            var user = await GetUser();
            if (user == null)
                return BadRequest(new { message = "An error occoured when validating your identity" });

            var data = await websiteContext.Votes.Where(acc => acc.UserId == user.Id).Select(x => new { x.Site, x.UnsetTimer }).ToListAsync();
            return Ok(data);
        }


        // GET: api/Vote/5
        [HttpGet("GetVoteSites/{id}")]
        public async Task<ActionResult<VoteSite>> GetVoteSites(byte id)
        {
            var voteSite = await websiteContext.VoteSites.FindAsync(id);

            if (voteSite == null)
            {
                return NotFound();
            }

            return voteSite;
        }

        // PUT: api/Vote/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoteSites(byte id, VoteSite voteSites)
        {
            if (id != voteSites.Id)
            {
                return BadRequest();
            }

            websiteContext.Entry(voteSites).State = EntityState.Modified;

            try
            {
                await websiteContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteSitesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vote
        [HttpPost]
        public async Task<ActionResult<VoteSite>> PostVoteSites(VoteSite voteSites)
        {
            websiteContext.VoteSites.Add(voteSites);
            try
            {
                await websiteContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoteSitesExists(voteSites.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoteSites", new { id = voteSites.Id }, voteSites);
        }

        // DELETE: api/Vote/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VoteSite>> DeleteVoteSites(byte id)
        {
            var voteSites = await websiteContext.VoteSites.FindAsync(id);
            if (voteSites == null)
            {
                return NotFound();
            }

            websiteContext.VoteSites.Remove(voteSites);
            await websiteContext.SaveChangesAsync();

            return voteSites;
        }

        private bool VoteSitesExists(byte id)
        {
            return websiteContext.VoteSites.Any(e => e.Id == id);
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
