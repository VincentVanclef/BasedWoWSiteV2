using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using server.Data.Characters;
using server.Model.Character;
using server.Services.Context;
using server.Util;
using CustomItemUpgrades = server.Data.World.CustomItemUpgrades;

namespace server.Services.ItemMapper
{
    public class ItemMapperService : IItemMapperService
    {
        private const double MaxWeaponDamageBonus = 1.3d;
        private const double TwoHandBonus = 1.5d;

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

        public async Task<List<InventoryModel>> MapCustomInventory(RealmType realmType, List<InventoryModel> inventoryModels, int owner = 0)
        {
            var worldContext = _contextService.GetWorldContext(realmType);
            var characterContext = _contextService.GetCharacterContext(realmType);

            var itemEntries = inventoryModels.Select(x => x.ItemEntry).ToList();
            var itemGuids = inventoryModels.Select(x => x.ItemGuid).ToList();

            var upgrades = await characterContext.CustomItemUpgrades.Where(x => itemGuids.Contains(x.ItemGuid) && x.IsActive()).ToListAsync();
            var upgradesInfo = await worldContext.CustomItemUpgrades.ToListAsync();

            var items = await worldContext.ItemTemplate.Where(x => itemEntries.Contains(x.Entry)).ToListAsync();

            var sets = await characterContext.CustomItemUpgradeSets.Where(x => x.Owner == owner).ToListAsync();
            if (!sets.Any())
                sets.Add(new CustomItemUpgradeSets(owner, 0, "Main Set"));

            var character = await characterContext.Characters.Where(x => x.Id == owner).Select(x => new { Name = x.Name, Class = x.Class }).FirstOrDefaultAsync();

            var classColor = Utilities.GetClassColor(character.Class);

            foreach (var item in items)
            {
                var inventoryItem = inventoryModels.FirstOrDefault(x => x.ItemEntry == item.Entry);
                if (inventoryItem == null)
                    continue;

                var upgrade = upgrades.FirstOrDefault(x => x.ItemGuid == inventoryItem.ItemGuid);
                if (upgrade == null)
                    continue;

                var activeSet = sets.Find(x => x.SetId == upgrade.SetId);
                if (activeSet == null)
                    continue;

                CustomItemUpgrades upgradeStatType;

                if (upgrade.StatId1 > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId1);
                    item.StatType1 = upgradeStatType?.StatType ?? 0;
                    item.StatValue1 = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.StatId2 > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId2);
                    item.StatType2 = upgradeStatType?.StatType ?? 0;
                    item.StatValue2 = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.StatId3 > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId3);
                    item.StatType3 = upgradeStatType?.StatType ?? 0;
                    item.StatValue3 = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.StatId4 > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId4);
                    item.StatType4 = upgradeStatType?.StatType ?? 0;
                    item.StatValue4 = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.StatId5 > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId5);
                    item.StatType5 = upgradeStatType?.StatType ?? 0;
                    item.StatValue5 = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.ArmorId > 0)
                {
                    upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.ArmorId);
                    item.Armor = upgradeStatType?.StatValue ?? 0;
                }

                if (upgrade.DmgId1 > 0 || upgrade.DmgId2 > 0)
                {
                    if (item.Class == (int)ItemClass.ITEM_CLASS_WEAPON)
                    {
                        var twoHandBonus = item.InventoryType == (int)InventoryType.INVTYPE_TWOHANDWEAPON ? TwoHandBonus : 1.0f;

                        upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.DmgId1);
                        item.DmgMin1 = (float)((upgradeStatType?.StatValue ?? 0) * twoHandBonus);
                        item.DmgMax1 = (float)((upgradeStatType?.StatValue ?? 0) * MaxWeaponDamageBonus * twoHandBonus);

                        upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.DmgId2);
                        item.DmgMin2 = (float)((upgradeStatType?.StatValue ?? 0) * twoHandBonus);
                        item.DmgMax2 = (float)((upgradeStatType?.StatValue ?? 0) * MaxWeaponDamageBonus * twoHandBonus);
                    }
                }

                if (!upgrade.Name.IsNullOrEmpty())
                {
                    item.Name = upgrade.Name;
                }

                if (upgrade.Quality >= 0)
                {
                    item.Quality = (byte)upgrade.Quality;
                }

                if (upgrade.UpgradeLevel > 0)
                {
                    item.ItemLevel = (short)upgrade.UpgradeLevel;
                }

                // Not in use yet
                //upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId6);
                //item.StatType6 = upgradeStatType?.StatType ?? 0;
                //item.StatValue6 = upgradeStatType?.StatValue ?? 0;

                //upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId7);
                //item.StatType7 = upgradeStatType?.StatType ?? 0;
                //item.StatValue7 = upgradeStatType?.StatValue ?? 0;

                //upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId8);
                //item.StatType8 = upgradeStatType?.StatType ?? 0;
                //item.StatValue8 = upgradeStatType?.StatValue ?? 0;

                //upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId9);
                //item.StatType9 = upgradeStatType?.StatType ?? 0;
                //item.StatValue9 = upgradeStatType?.StatValue ?? 0;

                //upgradeStatType = upgradesInfo.FirstOrDefault(x => x.Id == upgrade.StatId10);
                //item.StatType10 = upgradeStatType?.StatType ?? 0;
                //item.StatValue10 = upgradeStatType?.StatValue ?? 0;

                item.Description =
                    "--- Upgrade Information ---" +
                    $"<br />Owner: |cff{classColor}{character.Name}|r." +
                    $"<br />Upgrade Level: |cffFF0000{upgrade.UpgradeLevel}|r." +
                    $"<br />Set: |cffFF0000{activeSet.SetName}|r.";
            }

            foreach (var inventoryModel in inventoryModels)
            {
                inventoryModel.Item = items.FirstOrDefault(x => x.Entry == inventoryModel.ItemEntry);
            }

            return inventoryModels;
        }
    }
}
