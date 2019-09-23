<template>
  <keep-alive>
    <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
      <router-view :realmlist="Realmlist" :realms="realms" :user="user"></router-view>
    </div>
  </keep-alive>
</template>

<script>
import config from "@/assets/config/config.js";

export default {
  name: "Home",
  props: ["avatar", "user", "realms"],
  data() {
    return {
      Realmlist: config.REALMLIST
    };
  }
};
</script>
