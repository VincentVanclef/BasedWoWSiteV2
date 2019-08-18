using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model;
using server.Model.Account;
using server.Model.Character;
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
        private readonly WebsiteContext _websiteContext;

        public CharacterController(UserManager<ApplicationUser> userManager, ContextService contextService, WebsiteContext websiteContext)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _contextService = contextService;
        }

        [Authorize]
        [HttpPost("GetAllCharactersByUser")]
        public async Task<IActionResult> GetAllCharactersByUser([FromBody] RealmTypeModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var context = _contextService.GetCharacterContext(model.RealmType);
            var characters = await context.Characters.Where(o => o.Account == user.AccountId).ToListAsync();

            return Ok(characters);
        }

        [HttpPost("GetAllCharactersByAccountId")]
        public async Task<IActionResult> GetAllCharactersByAccountId([FromBody] SelectAccountModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);
            var characters = await context.Characters.Where(o => o.Account == model.AccountId).ToListAsync();

            return Ok(characters);
        }

        [HttpPost("GetUnstuckLocationsForRealm")]
        public async Task<IActionResult> GetUnstuckLocationsForRealm([FromBody] RealmTypeModel model)
        {
            var locations = await _websiteContext.UnstuckLocations.Where(x => x.RealmId == (int)model.RealmType).ToListAsync();
            return Ok(locations);
        }

        [HttpGet("GetAllUnstuckLocations")]
        public async Task<IActionResult> GetAllUnstuckLocations()
        {
            var locations = await _websiteContext.UnstuckLocations.ToListAsync();
            return Ok(locations);
        }

        [Authorize]
        [HttpPost("TeleportCharacter")]
        public async Task<IActionResult> TeleportCharacter([FromBody] TeleportCharacterModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var context = _contextService.GetCharacterContext(model.RealmType);

            var character = await context.Characters.FirstOrDefaultAsync(x => x.Guid == model.Guid);
            if (character == null || character.IsOnline())
                return BadRequest("Your character must be offline to use the Teleportation Service");

            var teleportLocation = await _websiteContext.UnstuckLocations.FirstOrDefaultAsync(x => x.Id == model.Location);
            if (teleportLocation == null)
                return RequestHandler.BadRequest("Unknown Teleport Location");

            character.PositionX = teleportLocation.PositionX;
            character.PositionY = teleportLocation.PositionY;
            character.PositionZ = teleportLocation.PositionZ;
            character.Map = teleportLocation.Map;
            character.AtLogin |= (int)AtLoginFlags.AT_LOGIN_RESURRECT;

            await context.SaveChangesAsync();

            return Ok();
        }

        enum AtLoginFlags
        {
            AT_LOGIN_NONE              = 0,
            AT_LOGIN_RENAME            = 1,
            AT_LOGIN_RESET_SPELLS      = 2,
            AT_LOGIN_RESET_TALENTS     = 4,
            AT_LOGIN_CUSTOMIZE         = 8,
            AT_LOGIN_RESET_PET_TALENTS = 16,
            AT_LOGIN_FIRST             = 32,
            AT_LOGIN_CHANGE_FACTION    = 64,
            AT_LOGIN_CHANGE_RACE       = 128,
            AT_LOGIN_RESURRECT         = 256,
        }
    }
}