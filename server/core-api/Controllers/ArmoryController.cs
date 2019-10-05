using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.Character;
using server.Model.Character.Armory;
using server.Services.Context;
using server.Services.ItemMapper;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ArmoryController : ControllerBase
    {
        private readonly IContextService _contextService;
        private readonly IItemMapperService _itemMapperService;
        private readonly WebsiteContext _websiteContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArmoryController(IContextService contextService, IItemMapperService itemMapperService, WebsiteContext websiteContext, UserManager<ApplicationUser> userManager)
        {
            _contextService = contextService;
            _itemMapperService = itemMapperService;
            _websiteContext = websiteContext;
            _userManager = userManager;
        }

        [HttpPost("GetCharacterStats")]
        public async Task<IActionResult> GetCharacterStats([FromBody] SelectCharacterByGuidModel model)
        {
            var characterContext = _contextService.GetCharacterContext(model.RealmType);
            var stats = await characterContext.CharacterStats.FirstOrDefaultAsync(x => x.Guid == model.Guid);
            return Ok(stats);
        }

        [HttpPost("GetCharacterInventory")]
        public async Task<IActionResult> GetCharacterInventory([FromBody] SelectCharacterByGuidModel model)
        {
            var characterContext = _contextService.GetCharacterContext(model.RealmType);

            var inventory = await characterContext.CharacterInventory
                .Where(x => x.Guid == model.Guid&& x.Slot < (int)EquipmentSlots.EQUIPMENT_SLOT_END && x.Bag == 0)
                .Join(characterContext.ItemInstance, ci => ci.Item, i => i.Guid, (ci, i) => new {ci, i})
                .Select(x => new InventoryModel
                {
                    Slot = x.ci.Slot,
                    ItemEntry = x.i.ItemEntry,
                    ItemGuid = x.i.Guid
                }).OrderBy(o => o.Slot).ToListAsync();

            var mappedInventory = model.RealmType == RealmType.TitansLeague ?
                await _itemMapperService.MapCustomInventory(model.RealmType, inventory, model.Guid) :
                await _itemMapperService.MapInventory(model.RealmType, inventory);

            return Ok(mappedInventory);
        }

        [HttpPost("GetCharacterItems")]
        public async Task<IActionResult> GetCharacterItems([FromBody] SelectCharacterByGuidModel model)
        {
            var characterContext = _contextService.GetCharacterContext(model.RealmType);

            var inventory = await characterContext.ItemInstance.Where(x => x.OwnerGuid == model.Guid).Select(x => new InventoryModel
            {
                ItemEntry = x.ItemEntry,
                ItemCount = x.Count,
                ItemGuid = x.Guid
            }).ToListAsync();

            var mappedInventory = model.RealmType == RealmType.TitansLeague ?
                await _itemMapperService.MapCustomInventory(model.RealmType, inventory, model.Guid) :
                await _itemMapperService.MapInventory(model.RealmType, inventory);

            return Ok(mappedInventory);
        }

        [HttpGet("GetItemDisplayInfo/{id}")]
        public async Task<IActionResult> GetItemDisplayInfo(int id)
        {
            var displayInfo = await _websiteContext.ItemDisplayInfo.FirstOrDefaultAsync(x => x.Id == id);
            if (displayInfo == null)
                return RequestHandler.BadRequest($"No icon was found for display id {id}");

            return Ok(displayInfo);
        }

        [HttpPost("GetItemDisplayInfo")]
        public async Task<IActionResult> GetItemDisplayInfo([FromBody] ItemDisplayIdsRequestModel model)
        {
            var displayInfo = await _websiteContext.ItemDisplayInfo.Where(x => model.DisplayIds.Contains(x.Id)).ToListAsync();
            if (!displayInfo.Any())
                return RequestHandler.BadRequest("No icons was found for the given display ids");

            return Ok(displayInfo);
        }
    }
}