<template>
  <div class="item_bg item-tooltip" v-show="visible">
    <div class="item_info" v-if="ItemDetails">
      <span class="q1" style="font-size: 16px">
        <font :color="ItemDetails.quality">{{ItemDetails.name}}</font>
      </span>
      <div
        style="clear: both;"
        v-if="ItemDetails.maxCount > 0"
      >{{ItemDetails.maxCount === 1 ? "Unique" : `Unique (${ItemDetails.maxCount})`}}</div>
      <div
        style="clear: both;"
        v-if="ItemDetails.bonding.id > 0"
      >{{ItemDetails.bonding.description}}</div>

      <div style="clear: both;">
        <div class="float-left">{{ItemDetails.inventory}}</div>
        <div class="float-right">{{ItemDetails.subclass}}</div>
      </div>

      <div style="clear: both;" v-if="ItemDetails.armor > 0">{{ItemDetails.armor}} Armor</div>

      <div style="clear: both;" v-if="ItemDetails.isWeapon">
        <div class="float-left">{{ItemDetails.dmgMin1}} - {{ItemDetails.dmgMax1}}</div>
        <div class="float-right">Speed {{ItemDetails.speed / 1000}}0</div>
        <div style="clear: both;">({{ItemDetails.dps}} damage per second)</div>
      </div>

      <div
        style="clear: both;"
        v-for="(stat, index) in ItemDetails.baseStats"
        :key="index"
      >{{stat.description}}</div>
      <!-- <br />

      <span class="socket-meta q0">Meta Socket</span>
      <br />
      <span class="socket-yellow q0">Yellow Socket</span>-->
      <div
        style="clear: both;"
        v-if="ItemDetails.requiredLevel"
      >Requires Level {{ItemDetails.requiredLevel}}</div>
      <div
        style="clear: both;"
        v-if="ItemDetails.itemLevel"
      >{{realm == 1 ? 'Upgrade' : 'Item'}} Level {{ItemDetails.itemLevel}}</div>
      <div v-for="(stat, index) in ItemDetails.otherStats" :key="index + 100">
        <span class="q2">Equip: {{stat.description}}</span>
      </div>
    </div>
  </div>
</template>

<script>
import ItemDetails from "@/services/itemService/itemDetails";

export default {
  name: "ItemTooltipComponent",
  data() {
    return {
      item: null,
      realm: 0,
      ItemDetails: null,
      visible: false
    };
  },
  computed: {
    ItemTemplate() {
      return this.item ? this.item.item : null;
    }
  },
  methods: {},
  created() {
    if (this.ItemTemplate) {
      this.ItemDetails = new ItemDetails(this.ItemTemplate);
    }
  }
};
</script>

<style scoped>
.item_bg {
  margin: 10px;
  margin-left: 5px;
  max-width: 300px;
  float: left;
}

.item-tooltip {
  min-width: 200px;
  color: #efefef;
  border: 1px solid #777;
  z-index: 999999;
  word-wrap: break-word;
  word-break: break-word;
  border-top: 1px solid #cfcfcf;
  box-shadow: 0px 0px 3px #000;
  -moz-box-shadow: 0px 0px 3px #000;
  -webkit-box-shadow: 0px 0px 3px #000;
  background-color: #070c21;
  background-color: rgba(7, 12, 33, 0.9);
}

.item_info {
  padding: 5px;
  font-size: 12px;
}

.q2 {
  color: #1eff00 !important;
}

/* Item quality colors */
.q {
  color: #ffd100;
}
.q0,
.q0 a {
  color: #9d9d9d;
}
.q1,
.q1 a {
  color: #ffffff;
}
.q2,
.q2 a,
.q2:hover {
  color: #1eff00;
}
.q3,
.q3 a {
  color: #0070dd;
}
.q4,
.q4 a {
  color: #a335ee;
}
.q5,
.q5 a {
  color: #ff8000;
}
.q6,
.q6 a {
  color: #e5cc80;
}
.q7,
.q7 a {
  color: #e5cc80;
}
.q8,
.q8 a {
  color: #ffff98;
}
.q9,
.q9 a {
  color: #71d5ff;
}
.q10,
.q10 a {
  color: #ffd100;
}

/* Sockets */
.socket-meta {
  padding-left: 26px;
  background: url("~@/assets/images/armory/misc/socket_meta.gif") no-repeat left
    center;
}
.socket-red {
  padding-left: 26px;
  background: url("~@/assets/images/armory/misc/socket_red.gif") no-repeat left
    center;
}
.socket-yellow {
  padding-left: 26px;
  background: url("~@/assets/images/armory/misc/socket_yellow.gif") no-repeat
    left center;
}
.socket-blue {
  padding-left: 26px;
  background: url("~@/assets/images/armory/misc/socket_blue.gif") no-repeat left
    center;
}
</style>