using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Characters;
using server.Data.Website;
using server.Model;
using server.Model.Account;
using server.Model.Character;
using server.Services.Context;
using server.Services.ItemMapper;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContextService _contextService;
        private readonly WebsiteContext _websiteContext;
        private readonly IItemMapperService _itemMapperService;

        public CharacterController(UserManager<ApplicationUser> userManager, IContextService contextService, WebsiteContext websiteContext, IItemMapperService itemMapperService)
        {
            _websiteContext = websiteContext;
            _itemMapperService = itemMapperService;
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
            var characters = await (
                from character in context.Characters
                where character.Account == user.AccountId
                join guildMembers in context.GuildMembers on character.Id equals guildMembers.CharacterId into joinTable1
                from guildMembers in joinTable1.DefaultIfEmpty()
                join guild in context.Guilds on guildMembers.GuildId equals guild.Id into joinTable2
                from guild in joinTable2.DefaultIfEmpty()
                select new Character(character)
                {
                    Guild = guild,
                    CharacterBanned = character.CharacterBanned
                }
            ).ToListAsync();

            return Ok(characters);
        }

        [HttpPost("GetAllCharactersByAccountId")]
        public async Task<IActionResult> GetAllCharactersByAccountId([FromBody] SelectAccountModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);
            var characters = await (
                from character in context.Characters
                where character.Account == model.AccountId
                join guildMembers in context.GuildMembers on character.Id equals guildMembers.CharacterId into joinTable1
                from guildMembers in joinTable1.DefaultIfEmpty()
                join guild in context.Guilds on guildMembers.GuildId equals guild.Id into joinTable2
                from guild in joinTable2.DefaultIfEmpty()
                select new Character(character)
                {
                    Guild = guild,
                    CharacterBanned = character.CharacterBanned
                }
            ).ToListAsync();

            return Ok(characters);
        }

        [HttpPost("GetAllCharactersByName")]
        public async Task<IActionResult> GetAllCharactersByName([FromBody] SelectCharacterByNameModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);
            var characters = await (
                from character in context.Characters
                where character.Name.ToUpper().Contains(model.Name.ToUpper())
                join guildMembers in context.GuildMembers on character.Id equals guildMembers.CharacterId into joinTable1
                from guildMembers in joinTable1.DefaultIfEmpty()
                join guild in context.Guilds on guildMembers.GuildId equals guild.Id into joinTable2
                from guild in joinTable2.DefaultIfEmpty()
                select new Character(character)
                {
                    Guild = guild,
                    CharacterBanned = character.CharacterBanned
                }
            ).ToListAsync();

            var count = characters.Count();

            return Ok(new
            {
                characters = characters.Take(10),
                count
            });
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

            var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == model.Guid);
            if (character == null || character.IsOnline())
                return RequestHandler.BadRequest("Your character must be offline to use the Teleportation Service");

            var teleportLocation = await _websiteContext.UnstuckLocations.FirstOrDefaultAsync(x => x.Id == model.Location);
            if (teleportLocation == null)
                return RequestHandler.BadRequest("Unknown Teleport Location");

            character.PositionX = teleportLocation.PositionX;
            character.PositionY = teleportLocation.PositionY;
            character.PositionZ = teleportLocation.PositionZ;
            character.Map = teleportLocation.Map;
            character.AtLogin |= (int)AtLoginFlags.AtLoginResurrect;

            await context.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("BanCharacter")]
        public async Task<IActionResult> BanCharacter([FromBody] BanCharacterModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var context = _contextService.GetCharacterContext(model.RealmType);

            var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == model.Guid);
            if (character == null)
                return RequestHandler.BadRequest("Character does not exist");

            var banData = await context.CharacterBanned.AnyAsync(x => x.CharacterId == model.Guid && x.Active == 1);
            if (banData)
                return RequestHandler.BadRequest($"Character {character.Name} is already banned");

            var now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var ban = new CharacterBanned
            {
                CharacterId = model.Guid,
                Active = 1,
                BanDate = now,
                UnbanDate = model.UnbanDate,
                BannedBy = user.UserName,
                BanReason = model.Reason
            };

            await context.CharacterBanned.AddAsync(ban);
            await context.SaveChangesAsync();

            return Ok(character);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UnBanCharacter")]
        public async Task<IActionResult> UnBanCharacter([FromBody] UnBanCharacterModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var context = _contextService.GetCharacterContext(model.RealmType);

            var character = await context.Characters.FirstOrDefaultAsync(x => x.Id == model.Guid);
            if (character == null)
                return RequestHandler.BadRequest("Character does not exist");

            var banData = await context.CharacterBanned.Where(x => x.CharacterId == model.Guid && x.Active == 1).ToListAsync();
            if (!banData.Any())
                return RequestHandler.BadRequest($"Character {character.Name} is currently not banned");

            banData.ForEach(x => x.Active = 0);

            context.CharacterBanned.UpdateRange(banData);
            await context.SaveChangesAsync();

            return Ok(character);
        }

        [HttpPost("GetBanHistory")]
        public async Task<IActionResult> GetBanHistory([FromBody] SelectCharacterByGuidModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var history = await context.CharacterBanned.Where(x => x.CharacterId == model.Guid).ToListAsync();
            return Ok(history);
        }
    }
}