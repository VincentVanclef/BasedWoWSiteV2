<template lang="html">
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <profile-nav></profile-nav>
    <router-view :user="user"></router-view>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";

export default {
  name: "User",
  props: ["avatar", "user"],
  data() {
    return {};
  },
  components: {
    "profile-nav": ProfileNav
  }
};
</script>

<style>
</style>