using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Context.Realms.TwinkNation;
using server.Data;
using server.Data.Characters;
using server.Data.Realms;
using server.Services;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ContextService _contextService;

        public CharacterController(UserManager<ApplicationUser> userManager, ContextService contextService)
        {
            _userManager = userManager;
            _contextService = contextService;
        }

        [Authorize]
        [HttpGet("GetAllCharacters")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var context = _contextService.GetCharacterContext(RealmInformation.RealmType.TitansLeague);
            var characters = await context.Characters.Where(o => o.Account == user.AccountId).ToListAsync();

            return Ok(characters);
        }

        [HttpGet("GetAllCharacters/{accountId}")]
        public async Task<IActionResult> GetAllCharactersByAccountId(int accountId)
        {
            var context = _contextService.GetCharacterContext(RealmInformation.RealmType.TitansLeague);
            var characters = await context.Characters.Where(o => o.Account == accountId).ToListAsync();
            return Ok(characters);
        }

        
    }
}