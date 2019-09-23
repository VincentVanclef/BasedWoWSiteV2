<template>
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <armory-nav></armory-nav>
    <hr class="border-dark" />
    <router-view :realms="realms" :user="user"></router-view>
  </div>
</template>

<script>
import ArmoryNav from "@/components/Armory/ArmoryNav";

export default {
  name: "Armory",
  props: ["avatar", "user", "realms"],
  data() {
    return {};
  },
  components: {
    "armory-nav": ArmoryNav
  }
};
</script>