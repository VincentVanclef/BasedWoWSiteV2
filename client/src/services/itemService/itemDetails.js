import ItemQualities from "./ItemQualities";
import InventoryTypes from "./InventoryTypes";
import ItemClassTypes from "./ItemClassTypes";
import ItemStatTypes from "./ItemStatTypes";
import ItemBondings from "./ItemBondings";

const BaseStats = [0, 1, 3, 4, 5, 6, 7];

export default class ItemDetails {
  constructor(item) {
    this.item = item;

    this.name = item.name;
    this.itemLevel = item.itemLevel;
    this.maxCount = item.maxCount;
    this.requiredLevel = item.requiredLevel;
    this.quality = this.GetItemQuality();
    this.inventory = this.GetInventoryName();
    this.class = this.GetClassName();
    this.subclass = this.GetSubclassName();

    this.isWeapon = this.item.class === 2;

    this.dmgMin1 = parseInt(this.item.dmgMin1);
    this.dmgMax1 = parseInt(this.item.dmgMax1);
    this.dmgMin2 = parseInt(this.item.dmgMin2);
    this.dmgMax2 = parseInt(this.item.dmgMax2);

    this.speed = this.item.delay;

    this.dps = this.CalculateDps();

    this.bonding = {
      id: this.item.bonding,
      description: this.GetBonding()
    };

    this.baseStats = [];
    this.otherStats = [];

    this.SetupStats();
  }

  CalculateDps() {
    if (this.item.delay > 0) {
      const speed = this.item.delay / 1000;
      return ((this.item.dmgMin1 + this.item.dmgMax1) / 2 / speed).toFixed(1);
    }

    return 0;
  }

  GetInventoryName() {
    return InventoryTypes.GetInventoryName(this.item.inventoryType);
  }

  GetItemQuality() {
    return ItemQualities.GetQuality(this.item.quality);
  }

  GetClassName() {
    return ItemClassTypes.GetItemClassName(this.item.class);
  }

  GetSubclassName() {
    return ItemClassTypes.GetItemSubclassName(
      this.item.class,
      this.item.subclass
    );
  }

  GetStatTypeName(statType) {
    return ItemStatTypes.GetStatType(statType);
  }

  GetStatValue(statType, statValue) {
    const isBaseStat = BaseStats.includes(statType);
    const isNegative = statValue < 0;
    const statName = this.GetStatTypeName(statType);

    if (isBaseStat) {
      return isNegative
        ? `-${statValue} ${statName}`
        : `+${statValue} ${statName}`;
    } else {
      return isNegative
        ? `Decreases your ${statName} by ${statValue}.`
        : `Increases your ${statName} by ${statValue}.`;
    }
  }

  SetupStats() {
    for (const key of Object.keys(this.item)) {
      if (key.includes("statType")) {
        const statNumber = key.replace(/\D/g, "");
        const statValue = this.item[`statValue${statNumber}`];

        if (statValue === 0) continue;

        const statName = `stat${statNumber}`;
        const statType = this.item[key];

        this[statName] = {
          value: statValue,
          description: this.GetStatValue(statType, statValue)
        };

        const isBaseStat = BaseStats.includes(statType);

        if (isBaseStat) {
          this.baseStats.push(this[statName]);
        } else {
          this.otherStats.push(this[statName]);
        }
      }
    }
  }

  GetBonding() {
    return ItemBondings.GetBonding(this.item.bonding);
  }
}
