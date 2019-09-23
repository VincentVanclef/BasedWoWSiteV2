using System.Collections.Generic;
using System.Threading.Tasks;
using server.Model.Character;
using server.Util;

namespace server.Services.ItemMapper
{
    public interface IItemMapperService
    {
        Task<List<InventoryModel>> MapInventory(RealmType realmType, List<InventoryModel> inventoryModels);
        Task<List<InventoryModel>> MapCustomInventory(RealmType realmType, List<InventoryModel> inventoryModels);
    }
}
