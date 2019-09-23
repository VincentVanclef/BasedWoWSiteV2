const ItemClass = {
  CONSUMABLE: 0,
  CONTAINER: 1,
  WEAPON: 2,
  GEM: 3,
  ARMOR: 4,
  REAGENT: 5,
  PROJECTILE: 6,
  TRADE_GOODS: 7,
  GENERIC: 8,
  RECIPE: 9,
  MONEY: 10,
  QUIVER: 11,
  QUEST: 12,
  KEY: 13,
  PERMANENT: 14,
  MISC: 15,
  GLYPH: 16
};

const ItemClassMap = new Map([
  [ItemClass.CONSUMABLE, "Consumeable"],
  [ItemClass.CONTAINER, "Container"],
  [ItemClass.WEAPON, "Weapon"],
  [ItemClass.GEM, "Gem"],
  [ItemClass.ARMOR, "Armor"],
  [ItemClass.REAGENT, "Reagent"],
  [ItemClass.PROJECTILE, "Projectile"],
  [ItemClass.TRADE_GOODS, "Trade Goods"],
  [ItemClass.GENERIC, "Generic"],
  [ItemClass.RECIPE, "Recipe"],
  [ItemClass.MONEY, "Money"],
  [ItemClass.QUIVER, "Quiver"],
  [ItemClass.QUEST, "Quest"],
  [ItemClass.KEY, "Key"],
  [ItemClass.PERMANENT, "Permanent"],
  [ItemClass.MISC, "Misc"],
  [ItemClass.GLYPH, "Glyph"]
]);

const ItemSubclassConsumable = {
  CONSUMABLE: 0,
  POTION: 1,
  ELIXIR: 2,
  FLASK: 3,
  SCROLL: 4,
  FOOD: 5,
  ITEM_ENHANCEMENT: 6,
  BANDAGE: 7,
  CONSUMABLE_OTHER: 8
};

const ItemSubclassConsumableMap = new Map([
  [ItemSubclassConsumable.CONSUMABLE, "Consumeable"],
  [ItemSubclassConsumable.POTION, "Potion"],
  [ItemSubclassConsumable.ELIXIR, "Elixir"],
  [ItemSubclassConsumable.FLASK, "Flask"],
  [ItemSubclassConsumable.SCROLL, "Scroll"],
  [ItemSubclassConsumable.FOOD, "Food"],
  [ItemSubclassConsumable.ITEM_ENHANCEMENT, "Enhancement"],
  [ItemSubclassConsumable.BANDAGE, "Bandage"],
  [ItemSubclassConsumable.CONSUMABLE_OTHER, "Other"]
]);

const ItemSubclassContainer = {
  CONTAINER: 0,
  SOUL_CONTAINER: 1,
  HERB_CONTAINER: 2,
  ENCHANTING_CONTAINER: 3,
  ENGINEERING_CONTAINER: 4,
  GEM_CONTAINER: 5,
  MINING_CONTAINER: 6,
  LEATHERWORKING_CONTAINER: 7,
  INSCRIPTION_CONTAINER: 8
};

const ItemSubclassWeapon = {
  AXE: 0,
  AXE2: 1,
  BOW: 2,
  GUN: 3,
  MACE: 4,
  MACE2: 5,
  POLEARM: 6,
  SWORD: 7,
  SWORD2: 8,
  STAFF: 10,
  EXOTIC: 11,
  EXOTIC2: 12,
  FIST: 13,
  MISC: 14,
  DAGGER: 15,
  THROWN: 16,
  SPEAR: 17,
  CROSSBOW: 18,
  WAND: 19,
  FISHING_POLE: 20
};

const ItemSubclassWeaponMap = new Map([
  [ItemSubclassWeapon.AXE, "Axe"],
  [ItemSubclassWeapon.AXE2, "Axe"],
  [ItemSubclassWeapon.BOW, "Bow"],
  [ItemSubclassWeapon.GUN, "Gun"],
  [ItemSubclassWeapon.MACE, "Mace"],
  [ItemSubclassWeapon.MACE2, "Mace"],
  [ItemSubclassWeapon.POLEARM, "Polearm"],
  [ItemSubclassWeapon.SWORD, "Sword"],
  [ItemSubclassWeapon.SWORD2, "Sword"],
  [ItemSubclassWeapon.STAFF, "Staff"],
  [ItemSubclassWeapon.EXOTIC, "Exotic"],
  [ItemSubclassWeapon.EXOTIC2, "Exotic"],
  [ItemSubclassWeapon.FIST, "Fist Weapon"],
  [ItemSubclassWeapon.MISC, "Miscellaneous"],
  [ItemSubclassWeapon.DAGGER, "Dagger"],
  [ItemSubclassWeapon.THROWN, "Thrown"],
  [ItemSubclassWeapon.SPEAR, "Spear"],
  [ItemSubclassWeapon.CROSSBOW, "Crossbow"],
  [ItemSubclassWeapon.WAND, "Wand"],
  [ItemSubclassWeapon.FISHING_POLE, "Fishing Pole"]
]);

const ItemSubclassGem = {
  RED: 0,
  BLUE: 1,
  YELLOW: 2,
  PURPLE: 3,
  GREEN: 4,
  ORANGE: 5,
  META: 6,
  SIMPLE: 7,
  PRISMATIC: 8
};

const ItemSubclassArmor = {
  MISC: 0,
  CLOTH: 1,
  LEATHER: 2,
  MAIL: 3,
  PLATE: 4,
  BUCKLER: 5,
  SHIELD: 6,
  LIBRAM: 7,
  IDOL: 8,
  TOTEM: 9,
  SIGIL: 10
};

const ItemSubclassArmorMap = new Map([
  [ItemSubclassArmor.MISC, "Misc"],
  [ItemSubclassArmor.CLOTH, "Cloth"],
  [ItemSubclassArmor.LEATHER, "Leather"],
  [ItemSubclassArmor.MAIL, "Mail"],
  [ItemSubclassArmor.PLATE, "Plate"],
  [ItemSubclassArmor.BUCKLER, "Buckler"],
  [ItemSubclassArmor.SHIELD, "Shield"],
  [ItemSubclassArmor.LIBRAM, "Libram"],
  [ItemSubclassArmor.IDOL, "Idol"],
  [ItemSubclassArmor.TOTEM, "Totem"],
  [ItemSubclassArmor.SIGIL, "Sigil"]
]);

const ItemSubclassReagent = {
  REAGENT: 0
};

const ItemSubclassProjectile = {
  WAND: 0, // ABS
  BOLT: 1, // ABS
  ARROW: 2,
  BULLET: 3,
  THROWN: 4 // ABS
};

const ItemSubclassTradeGoods = {
  TRADE_GOODS: 0,
  PARTS: 1,
  EXPLOSIVES: 2,
  DEVICES: 3,
  JEWELCRAFTING: 4,
  CLOTH: 5,
  LEATHER: 6,
  METAL_STONE: 7,
  MEAT: 8,
  HERB: 9,
  ELEMENTAL: 10,
  TRADE_GOODS_OTHER: 11,
  ENCHANTING: 12,
  MATERIAL: 13,
  ARMOR_ENCHANTMENT: 14,
  WEAPON_ENCHANTMENT: 15
};

const ItemSubclassGeneric = {
  GENERIC: 0
};

const ItemSubclassRecipe = {
  BOOK: 0,
  LEATHERWORKING_PATTERN: 1,
  TAILORING_PATTERN: 2,
  ENGINEERING_SCHEMATIC: 3,
  BLACKSMITHING: 4,
  COOKING_RECIPE: 5,
  ALCHEMY_RECIPE: 6,
  FIRST_AID_MANUAL: 7,
  ENCHANTING_FORMULA: 8,
  FISHING_MANUAL: 9,
  JEWELCRAFTING_RECIPE: 10
};

const ItemSubclassMoney = {
  MONEY: 0
};

const ItemSubclassQuiver = {
  QUIVER0: 0, // ABS
  QUIVER1: 1, // ABS
  QUIVER: 2,
  AMMO_POUCH: 3
};

const ItemSubclassQuest = {
  QUEST: 0
};

const ItemSubclassKey = {
  KEY: 0,
  LOCKPICK: 1
};

const ItemSubclassPermanent = {
  PERMANENT: 0
};

const ItemSubclassJunk = {
  JUNK: 0,
  JUNK_REAGENT: 1,
  JUNK_PET: 2,
  JUNK_HOLIDAY: 3,
  JUNK_OTHER: 4,
  JUNK_MOUNT: 5
};

const ItemSubclassGlyph = {
  WARRIOR: 1,
  PALADIN: 2,
  HUNTER: 3,
  ROGUE: 4,
  PRIEST: 5,
  DEATH_KNIGHT: 6,
  SHAMAN: 7,
  MAGE: 8,
  WARLOCK: 9,
  DRUID: 11
};

export default {
  name: "ItemClassTypes",

  GetItemClassName: function(itemClass) {
    return ItemClassMap.get(itemClass);
  },

  GetItemSubclassName: function(itemClass, itemSubclass) {
    switch (itemClass) {
      case ItemClass.ARMOR:
        return ItemSubclassArmorMap.get(itemSubclass);
      case ItemClass.WEAPON:
        return ItemSubclassWeaponMap.get(itemSubclass);
    }
  }
};
