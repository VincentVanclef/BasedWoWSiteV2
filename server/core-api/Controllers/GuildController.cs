using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Data.Characters;
using server.Data.Website;
using server.Data.World;
using server.Model.Character;
using server.Model.Character.Guild;
using server.Services.Context;
using server.Services.ItemMapper;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GuildController : ControllerBase
    {
        private readonly IContextService _contextService;
        private readonly IItemMapperService _itemMapperService;

        public GuildController(IContextService contextService, IItemMapperService itemMapperService)
        {
            _contextService = contextService;
            _itemMapperService = itemMapperService;
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

            var guildBankItems = await context.GuildBankItems
                .Where(x => x.GuildId == guild.Id)
                .Join(context.ItemInstance, gItem => gItem.ItemGuid, item => item.Guid, (gItem, item) => new {gItem, item})
                .Select(x => new InventoryModel
                {
                    ItemEntry = x.item.ItemEntry,
                    ItemGuid = x.item.Guid,
                    ItemCount = x.item.Count,
                    Slot = x.gItem.TabId
                }).ToListAsync();

            var mappedInventory = await _itemMapperService.MapInventory(model.RealmType, guildBankItems);
            return Ok(mappedInventory);
        }

        [HttpPost("GetGuildBankEventLogs")]
        public async Task<IActionResult> GetGuildBankEventLogs([FromBody] GetGuildBankEventLogsModel model)
        {
            var characterContext = _contextService.GetCharacterContext(model.RealmType);
            var worldContext = _contextService.GetWorldContext(model.RealmType);

            var guild = await characterContext.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildBankEventLogs = await characterContext.GuildBankEventLogs
                .Where(x => x.GuildId == guild.Id && x.TabId == model.TabId && model.EventTypes.Contains(x.EventType))
                .Join(characterContext.Characters, log => log.PlayerGuid, character => character.Id, (log, character) => new {log, character})
                .Select(x => new GuildBankEventLog
                {
                    GuildId = x.log.GuildId,
                    EventType = x.log.EventType,
                    ItemOrMoney = x.log.ItemOrMoney,
                    TabId = x.log.TabId,
                    PlayerGuid = x.log.PlayerGuid,
                    DestTabId = x.log.DestTabId,
                    LogGuid = x.log.LogGuid,
                    TimeStamp = x.log.TimeStamp,
                    ItemStackCount = x.log.ItemStackCount,
                    PlayerName = x.character.Name
                })
                .ToListAsync();

            if (model.EventTypes.Any(eventType => eventType <= (int)GuildBankEventLogTypes.GUILD_BANK_LOG_MOVE_ITEM))
            {
                var itemEntries = guildBankEventLogs.Where(x => x.EventType <= (int)GuildBankEventLogTypes.GUILD_BANK_LOG_MOVE_ITEM).Select(x => x.ItemOrMoney).Distinct().ToList();

                var items = await worldContext.ItemTemplate.Where(x => itemEntries.Contains(x.Entry)).ToListAsync();

                foreach (var log in guildBankEventLogs)
                {
                    log.Item = items.FirstOrDefault(x => x.Entry == log.ItemOrMoney);
                }
            }

            return Ok(guildBankEventLogs);
        }

        [HttpPost("GetAllGuildBankEventLogs")]
        public async Task<IActionResult> GetAllGuildBankEventLogs([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildBankEventLogs = await context.GuildBankEventLogs.Where(x => x.GuildId == guild.Id).ToListAsync();
            return Ok(guildBankEventLogs);
        }

        [HttpPost("GetGuildBankTabs")]
        public async Task<IActionResult> GetGuildBankTabs([FromBody] GetGuildByIdModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var guild = await context.Guilds.FirstOrDefaultAsync(x => x.Id == model.GuildId);
            if (guild == null)
                return RequestHandler.BadRequest($"No Guild with id {model.GuildId} exists");

            var guildBankTabs = await context.GuildBankTabs.Where(x => x.GuildÍd == guild.Id).ToListAsync();
            return Ok(guildBankTabs);
        }
    }
}