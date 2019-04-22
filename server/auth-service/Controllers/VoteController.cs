using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server;
using server.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly WebsiteContext _context;

        public VoteController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: api/Vote
        [HttpGet("GetVoteSites")]
        public async Task<ActionResult<IEnumerable<VoteSite>>> GetVoteSites()
        {
            return await _context.VoteSites.ToListAsync();
        }

        // GET: api/Vote/5
        [HttpGet("GetVoteSites/{id}")]
        public async Task<ActionResult<VoteSite>> GetVoteSites(byte id)
        {
            var voteSite = await _context.VoteSites.FindAsync(id);

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

            _context.Entry(voteSites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.VoteSites.Add(voteSites);
            try
            {
                await _context.SaveChangesAsync();
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
            var voteSites = await _context.VoteSites.FindAsync(id);
            if (voteSites == null)
            {
                return NotFound();
            }

            _context.VoteSites.Remove(voteSites);
            await _context.SaveChangesAsync();

            return voteSites;
        }

        private bool VoteSitesExists(byte id)
        {
            return _context.VoteSites.Any(e => e.Id == id);
        }
    }
}
