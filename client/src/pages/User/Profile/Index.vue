<template lang="html">
  <div class="container">
    <profile-nav></profile-nav>
    <div class="row">
      <keep-alive>
        <router-view v-bind:User="User"></router-view>
      </keep-alive>
    </div>
  </div>
</template>

<script>
import ProfileNav from "@/components/ProfileNav";

export default {
  name: "Profile",
  data() {
    return {
      User: null
    };
  },
  components: {
    "profile-nav": ProfileNav
  },
  created() {
    this.User = this.$store.getters.GetUser;
  }
};
</script>
