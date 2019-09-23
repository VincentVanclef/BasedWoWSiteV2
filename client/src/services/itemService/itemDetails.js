import ItemQualities from "./ItemQualities";
import EquipmentSlots from "./EquipmentSlots";
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

    this.stat1 = {
      baseStat: BaseStats.includes(this.item.statType1),
      value: this.item.statValue1,
      description: this.GetStatValue(this.item.statType1, this.item.statValue1)
    };

    this.stat2 = {
      baseStat: BaseStats.includes(this.item.statType2),
      value: this.item.statValue2,
      description: this.GetStatValue(this.item.statType2, this.item.statValue2)
    };

    this.stat3 = {
      baseStat: BaseStats.includes(this.item.statType3),
      value: this.item.statValue3,
      description: this.GetStatValue(this.item.statType3, this.item.statValue3)
    };

    this.stat4 = {
      baseStat: BaseStats.includes(this.item.statType4),
      value: this.item.statValue4,
      description: this.GetStatValue(this.item.statType4, this.item.statValue4)
    };

    this.stat5 = {
      baseStat: BaseStats.includes(this.item.statType5),
      value: this.item.statValue5,
      description: this.GetStatValue(this.item.statType5, this.item.statValue5)
    };

    this.stat6 = {
      baseStat: BaseStats.includes(this.item.statType6),
      value: this.item.statValue6,
      description: this.GetStatValue(this.item.statType6, this.item.statValue6)
    };

    this.stat7 = {
      baseStat: BaseStats.includes(this.item.statType7),
      value: this.item.statValue7,
      description: this.GetStatValue(this.item.statType7, this.item.statValue7)
    };

    this.stat8 = {
      baseStat: BaseStats.includes(this.item.statType8),
      value: this.item.statValue8,
      description: this.GetStatValue(this.item.statType8, this.item.statValue8)
    };

    this.stat9 = {
      baseStat: BaseStats.includes(this.item.statType9),
      value: this.item.statValue9,
      description: this.GetStatValue(this.item.statType9, this.item.statValue9)
    };

    this.stat10 = {
      baseStat: BaseStats.includes(this.item.statType10),
      value: this.item.statType10,
      description: this.GetStatValue(
        this.item.statType10,
        this.item.statValue10
      )
    };

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
    for (const key of Object.keys(this)) {
      if (key.includes("stat")) {
        const stat = this[key];

        if (stat.value == 0) continue;

        if (stat.baseStat) {
          this.baseStats.push(stat);
        } else {
          this.otherStats.push(stat);
        }
      }
    }
  }

  GetBonding() {
    return ItemBondings.GetBonding(this.item.bonding);
  }
}
