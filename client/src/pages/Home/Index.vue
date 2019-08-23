<template>
  <keep-alive>
    <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
      <router-view :realmlist="Realmlist" :user="user"></router-view>
    </div>
  </keep-alive>
</template>

<script>
import config from "@/assets/config/config.js";
import { EventBus } from "@/helpers/EventBus.js";

export default {
  name: "Home",
  props: ["avatar", "user"],
  data() {
    return {
      Realmlist: config.REALMLIST
    };
  }
};
</script>
