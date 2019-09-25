import CombatRatings from "./CombatRatings";
import EquipmentSlots from "./EquipmentSlots";
import ItemClassTypes from "./ItemClassTypes";

const BASE_ATTACK_TIME = 2000;
const BASE_MINDAMAGE = 1;
const BASE_MAXDAMAGE = 2;

const UnitMods = {
  MAINHAND: 22,
  OFFHAND: 23,
  RANGED: 24
};

const GetUnitMod = slot => {
  switch (slot) {
    case EquipmentSlots.MAINHAND:
      return UnitMods.MAINHAND;
    case EquipmentSlots.OFFHAND:
      return UnitMods.OFFHAND;
    case EquipmentSlots.RANGED:
      return UnitMods.RANGED;
  }
};

const GetAPMultiplier = weapon => {
  if (!weapon) return BASE_ATTACK_TIME / 1000;

  return weapon.delay / 1000;

  // This seems to not be used?
  switch (weapon.subclass) {
    case ItemClassTypes.ItemSubclassWeapon.AXE2:
    case ItemClassTypes.ItemSubclassWeapon.MACE2:
    case ItemClassTypes.ItemSubclassWeapon.POLEARM:
    case ItemClassTypes.ItemSubclassWeapon.SWORD2:
    case ItemClassTypes.ItemSubclassWeapon.STAFF:
    case ItemClassTypes.ItemSubclassWeapon.FISHING_POLE:
      return 3.3;
    case ItemClassTypes.ItemSubclassWeapon.BOW:
    case ItemClassTypes.ItemSubclassWeapon.GUN:
    case ItemClassTypes.ItemSubclassWeapon.CROSSBOW:
    case ItemClassTypes.ItemSubclassWeapon.THROWN:
      return 2.8;
    case ItemClassTypes.ItemSubclassWeapon.AXE:
    case ItemClassTypes.ItemSubclassWeapon.MACE:
    case ItemClassTypes.ItemSubclassWeapon.SWORD:
    case ItemClassTypes.ItemSubclassWeapon.EXOTIC:
    case ItemClassTypes.ItemSubclassWeapon.EXOTIC2:
    case ItemClassTypes.ItemSubclassWeapon.FIST:
      return 2.4;
    case ItemClassTypes.ItemSubclassWeapon.DAGGER:
      return 1.7;
    default:
      return weapon.delay / 1000;
  }
};

export default {
  name: "WeaponDamageCalculator",

  GetAttackSpeed: function(weapon, hasteRating, character, slot) {
    const combatRating =
      slot === EquipmentSlots.MAINHAND || EquipmentSlots.OFFHAND
        ? CombatRatings.CombatRating.HASTE_MELEE
        : CombatRatings.CombatRating.HASTE_RANGED;

    const combatRatingMultiplier = CombatRatings.GetRatingMultiplier(
      combatRating,
      character.class,
      character.level
    );

    const ratingPct = hasteRating * combatRatingMultiplier;
    const speed = weapon ? weapon.delay : BASE_ATTACK_TIME;

    return ((speed * ((100.0 - ratingPct) / 100.0)) / 1000.0).toFixed(2);
  },

  GetMinMaxDamage: function(weapon, attackPower) {
    const weaponMinDamage = weapon ? weapon.dmgMin1 : BASE_MINDAMAGE;
    const weaponMaxDamage = weapon ? weapon.dmgMax1 : BASE_MAXDAMAGE;

    const attackPowerMod = GetAPMultiplier(weapon);
    const attackPowerValue = (attackPower / 14.0) * attackPowerMod;

    const minDamage = Math.round(weaponMinDamage + attackPowerValue);
    const maxDamage = Math.round(weaponMaxDamage + attackPowerValue);
    return { minDamage, maxDamage };
  }
};
