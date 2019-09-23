<template>
  <div class="item_bg item-tooltip" v-show="visible">
    <div class="item_info" v-if="ItemDetails">
      <span class="q1" style="font-size: 16px">
        <font :color="ItemDetails.quality">{{ItemDetails.name}}</font>
      </span>
      <br />Binds when picked up
      <br />
      <div class="float-left">{{ItemDetails.inventory}}</div>
      <div class="float-right">{{ItemDetails.subclass}}</div>
      <div style="clear:both;"></div>+37500 Stamina
      <br />

      <span class="socket-meta q0">Meta Socket</span>
      <br />
      <span class="socket-yellow q0">Yellow Socket</span>
      <span v-if="ItemDetails.requiredLevel">
        <br />
        Requires Level {{ItemDetails.requiredLevel}}
      </span>
      <span v-if="ItemDetails.itemLevel">
        <br />
        Item Level {{ItemDetails.itemLevel}}
      </span>
      <br />
      <span class="q2">Equip: Increases your armor penetration rating by 200.</span>
      <br />
      <span class="q2">Equip: Increases your resilience rating by 17.</span>
      <br />
      <span class="q2">Equip: Increases your haste rating by 17.</span>
      <br />
      <span class="q2">Equip: Increases your attack power by 37500.</span>
      <br />
      <span class="q2">Equip: Increases your spellpower by 37500.</span>
      <br />
      <span class="q2">Equip: Increases your critical strike rating by 200.</span>
      <br />
      <span class="q2">Equip: Increases your hit rating by 200.</span>
      <br />
      <span class="q2">Equip: Increases your spell critical strike rating by 200.</span>
      <br />
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
      console.log(this.ItemDetails);
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