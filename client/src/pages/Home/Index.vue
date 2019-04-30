<template>
  <keep-alive>
    <router-view :realmlist="Realmlist"></router-view>
  </keep-alive>
</template>

<script>
import config from "../../../static/config/config.js";
import { EventBus } from "@/helpers/EventBus.js";

export default {
  name: "Home",
  data() {
    return {
      Realmlist: config.REALMLIST
    };
  },
  mounted() {
    EventBus.$on("SetMainHeight", function(payload) {
      console.log("yes");
    });
  }
};
</script>
