<template>
  <div class="item-container" alt="helmet">
    <div v-if="Loading" class="text-center">
      <b-spinner
        style="width: 2rem; height: 2rem; margin-top: 18px;"
        variant="dark"
        label="Spinning"
      ></b-spinner>
    </div>
    <b-img
      v-if="!item"
      class="no-item"
      rounded
      :src="require('@/assets/images/armory/equipment_slots/' + GetDefaultIcon)"
    ></b-img>
    <b-img
      v-if="item && ItemIcon"
      class="item"
      rounded
      v-itemtooltip="{ item: item, realm: realm }"
      :src="'https://wow.zamimg.com/images/wow/icons/large/' + ItemIcon + '.jpg'"
    ></b-img>
  </div>
</template>

<script>
import EquipmentSlots from "@/services/itemService/EquipmentSlots";

export default {
  props: ["entry", "eSlot", "item", "realm"],
  data() {
    return {
      Loading: false,
      ItemIcon: null
    };
  },
  computed: {
    DisplayId() {
      const itemTemplate = this.item;
      return itemTemplate ? itemTemplate.item.displayId : 0;
    },
    GetDefaultIcon() {
      let icon = "";
      switch (this.eSlot) {
        case EquipmentSlots.HEAD:
          icon = "head.png";
          break;
        case EquipmentSlots.NECK:
          icon = "neck.png";
          break;
        case EquipmentSlots.SHOULDERS:
          icon = "shoulders.png";
          break;
        case EquipmentSlots.BODY:
          icon = "body.png";
          break;
        case EquipmentSlots.CHEST:
          icon = "chest.png";
          break;
        case EquipmentSlots.WAIT:
          icon = "waist.png";
          break;
        case EquipmentSlots.LEGS:
          icon = "legs.png";
          break;
        case EquipmentSlots.FEET:
          icon = "feet.png";
          break;
        case EquipmentSlots.WRISTS:
          icon = "wrist.png";
          break;
        case EquipmentSlots.HANDS:
          icon = "hands.png";
          break;
        case EquipmentSlots.BACK:
          icon = "chest.png";
          break;
        case EquipmentSlots.MAINHAND:
          icon = "mainHand.png";
          break;
        case EquipmentSlots.OFFHAND:
          icon = "secondaryHand.png";
          break;
        case EquipmentSlots.RANGED:
          icon = "ranged.png";
          break;
        case EquipmentSlots.TABARD:
          icon = "tabard.png";
          break;
        case EquipmentSlots.FINGER1:
        case EquipmentSlots.FINGER2:
          icon = "finger.png";
          break;
        case EquipmentSlots.TRINKET1:
        case EquipmentSlots.TRINKET2:
          icon = "trinket.png";
          break;
      }
      return icon;
    },
    GetItemDisplayInfoMap() {
      return this.$store.getters["armory/GetItemDisplayInfoMap"];
    }
  },
  methods: {
    async GetItemIcon() {
      if (this.DisplayId === 0) return;

      this.Loading = true;

      const icon = await this.$store.dispatch(
        "armory/GetItemIcon",
        this.DisplayId
      );

      this.ItemIcon = icon;

      this.Loading = false;
    }
  },
  created() {
    this.GetItemIcon();
  }
};
</script>

<style scoped>
.item-container {
  margin-top: 0.2rem;
  background-image: url("http://transcend-wow.com/application/images/misc/item_frame.png");
  background-repeat: no-repeat;
  background-position: top center;
  min-width: 68px;
  min-height: 68px;
}

.item {
  padding: 6px;
}

.no-item {
  padding: 4px;
}
</style>