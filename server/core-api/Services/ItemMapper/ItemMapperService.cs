using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Model.Character;
using server.Services.Context;
using server.Util;

namespace server.Services.ItemMapper
{
    public class ItemMapperService : IItemMapperService
    {
        private readonly IContextService _contextService;

        public ItemMapperService(IContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<List<InventoryModel>> MapInventory(RealmType realmType, List<InventoryModel> inventoryModels)
        {
            var worldContext = _contextService.GetWorldContext(realmType);

            var itemEntries = inventoryModels.Select(x => x.ItemEntry).ToList();

            var items = await worldContext.ItemTemplate.Where(x => itemEntries.Contains(x.Entry)).ToListAsync();

            foreach (var inventoryModel in inventoryModels)
            {
                inventoryModel.Item = items.FirstOrDefault(x => x.Entry == inventoryModel.ItemEntry);
            }

            return inventoryModels;
        }
    }
}
