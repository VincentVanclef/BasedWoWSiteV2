import ItemQualities from "./ItemQualities";
import EquipmentSlots from "./EquipmentSlots";
import InventoryTypes from "./InventoryTypes";
import ItemClassTypes from "./ItemClassTypes";

export default class ItemDetails {
  constructor(item) {
    this.item = item;

    this.name = item.name;
    this.itemLevel = item.itemLevel;
    this.requiredLevel = item.requiredLevel;
    this.quality = this.GetItemQuality();
    this.inventory = this.GetInventoryName();
    this.class = this.GetClassName();
    this.subclass = this.GetSubclassName();
  }

  CalculateDamage() {
    const minDmg = item.minDmg;
    const maxDmg = item.maxDmg;
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
}
