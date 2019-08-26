<template lang="html">
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <router-view :user="user"></router-view>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";
import UserHelper from "@/helpers/UserHelper";

export default {
  name: "User",
  props: ["avatar", "user"],
  data() {
    return {};
  },
  computed: {
    isLoggedIn() {
      return UserHelper.IsLoggedIn();
    }
  },
  components: {
    "profile-nav": ProfileNav
  }
};
</script>

<style>
</style>