using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Characters;
using server.Model.Character;
using server.Model.Character.Guild;
using server.Services;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GuildController : ControllerBase
    {
        private readonly ContextService _contextService;

        public GuildController(ContextService contextService)
        {
            _contextService = contextService;
        }

        [HttpPost("GetGuildById")]
        public async Task<IActionResult> GetGuildById([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            return Ok(guild);
        }

        [HttpPost("GetGuildByCharacter")]
        public async Task<IActionResult> GetGuildByCharacter([FromBody] SelectCharacterByGuidModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var member = await context.GuildMembers.FirstOrDefaultAsync(x => x.CharacterId == model.Guid);
            if (member == null)
                return RequestHandler.BadRequest("This character is not in any guild");

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == member.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {member.GuildId} exists");

            return Ok(guild);
        }

        [HttpPost("GetGuildMembers")]
        public async Task<IActionResult> GetGuildMembers([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var members = await context.GuildMembers.Where(x => x.GuildId == guild.Id).ToListAsync();

            return Ok(members);
        }

        private async Task GetGuildCharacters(CharacterContext context, List<GuildMember> members)
        {
            var characters = await context.Characters.Where(x => members.Any(m => m.CharacterId == x.Id)).ToListAsync();

            foreach (var member in members)
            {
                member.Character = characters.FirstOrDefault(x => x.Id == member.CharacterId);
            }
        }

        [HttpPost("GetGuildEventLogs")]
        public async Task<IActionResult> GetGuildEventLogs([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildEventLogs = await context.GuildEventLogs.Where(x => x.GuildId == guild.Id).ToListAsync();
            return Ok(guildEventLogs);
        }

        [HttpPost("GetGuildBankItems")]
        public async Task<IActionResult> GetGuildBankItems([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildBankItems = await context.GuildBankItems.Where(x => x.GuildId == guild.Id).ToListAsync();
            return Ok(guildBankItems);
        }

        [HttpPost("GetGuildBankEventLogs")]
        public async Task<IActionResult> GetGuildBankEventLogs([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildBankEventLogs = await context.GuildBankEventLogs.Where(x => x.GuildId == guild.Id).ToListAsync();
            return Ok(guildBankEventLogs);
        }
    }
}