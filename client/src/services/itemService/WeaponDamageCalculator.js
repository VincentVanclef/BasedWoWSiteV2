import CombatRatings from "./CombatRatings";
import EquipmentSlots from "./EquipmentSlots";

const BASE_ATTACK_TIME = 2000;

export default {
  name: "WeaponDamageCalculator",

  GetAttackSpeed: function(weapon, hasteRating, character, slot) {
    if (!weapon) return BASE_ATTACK_TIME;

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
    const speed = weapon.item.delay;

    return ((speed * ((100.0 - ratingPct) / 100.0)) / 1000.0).toFixed(2);
  }
};
