const ItemBondingType = {
  NO_BIND: 0,
  BIND_WHEN_PICKED_UP: 1,
  BIND_WHEN_EQUIPED: 2,
  BIND_WHEN_USE: 3,
  BIND_QUEST_ITEM: 4,
  BIND_QUEST_ITEM1: 5 // not used in game
};

const ItemBondingTypeMap = new Map([
  [ItemBondingType.NO_BIND, ""],
  [ItemBondingType.BIND_WHEN_PICKED_UP, "Binds when picked up"],
  [ItemBondingType.BIND_WHEN_EQUIPED, "Binds when equipped"],
  [ItemBondingType.BIND_WHEN_USE, "Binds when used"],
  [ItemBondingType.BIND_QUEST_ITEM, "Quest Item"],
  [ItemBondingType.BIND_QUEST_ITEM1, "Quest Item"]
]);

export default {
  name: "ItemBondings",

  GetBonding: function(id) {
    return ItemBondingTypeMap.get(id);
  }
};
