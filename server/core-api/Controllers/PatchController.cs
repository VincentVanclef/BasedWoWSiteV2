using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Context;
using server.Data.Website;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PatchController : ControllerBase
    {
        private readonly WebsiteContext _websiteContext;

        public PatchController(WebsiteContext websiteContext)
        {
            _websiteContext = websiteContext;
        }

        [HttpGet("GetPatchData")]
        public async Task<IActionResult> GetPatchData()
        {
            var data = await _websiteContext.GamePatches.ToArrayAsync();
            return Ok(data);
        }
    }
}
