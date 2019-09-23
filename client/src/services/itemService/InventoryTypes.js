const InventoryTypes = {
  HEAD: 1,
  NECK: 2,
  SHOULDERS: 3,
  BODY: 4,
  CHEST: 5,
  WAIST: 6,
  LEGS: 7,
  FEET: 8,
  WRISTS: 9,
  HANDS: 10,
  FINGER: 11,
  TRINKET: 12,
  WEAPON: 13,
  SHIELD: 14,
  RANGED: 15,
  CLOAK: 16,
  TWOHWEAPON: 17,
  BAG: 18,
  TABARD: 19,
  ROBE: 20,
  WEAPONMAINHAND: 21,
  WEAPONOFFHAND: 22,
  HOLDABLE: 23,
  AMMO: 24,
  THROWN: 25,
  RANGEDRIGHT: 26,
  QUIVER: 27,
  RELIC: 28
};

const InventoryTypesMap = new Map([
  [InventoryTypes.HEAD, "Head"],
  [InventoryTypes.NECK, "Neck"],
  [InventoryTypes.SHOULDERS, "Shoulder"],
  [InventoryTypes.BODY, "Shirt"],
  [InventoryTypes.CHEST, "Chest"],
  [InventoryTypes.WAIST, "Waist"],
  [InventoryTypes.LEGS, "Legs"],
  [InventoryTypes.WRISTS, "Wrists"],
  [InventoryTypes.HANDS, "Hands"],
  [InventoryTypes.FEET, "Feet"],
  [InventoryTypes.FINGER, "Finger"],
  [InventoryTypes.TRINKET, "Trinket"],
  [InventoryTypes.WEAPON, "One-Handed"],
  [InventoryTypes.RANGED, "Ranged"],
  [InventoryTypes.SHIELD, "Shield"],
  [InventoryTypes.CLOAK, "Back"],
  [InventoryTypes.SHIELD, "Shield"],
  [InventoryTypes.BAG, "Bag"],
  [InventoryTypes.TABARD, "Tabard"],
  [InventoryTypes.ROBE, "Robe"],
  [InventoryTypes.WEAPONMAINHAND, "Main hand"],
  [InventoryTypes.WEAPONOFFHAND, "Off hand"],
  [InventoryTypes.HOLDABLE, "Holdable"],
  [InventoryTypes.AMMO, "Ammo"],
  [InventoryTypes.THROWN, "Thrown"],
  [InventoryTypes.RANGED, "Ranged"],
  [InventoryTypes.QUIVER, "Quiver"],
  [InventoryTypes.RELIC, "Relic"],
  [InventoryTypes.TWOHWEAPON, "Two-Hand"]
]);

export default {
  name: "InventoryTypes",

  //InventoryTypes,

  GetInventoryName: function(id) {
    return InventoryTypesMap.get(id);
  }
};
