<template lang="html">
  <div class="container">
    <div class="row">
      <keep-alive>
        <router-view v-bind:User="User"></router-view>
      </keep-alive>
    </div>
  </div>
</template>

<script>
export default {
  name: "Profile",
  data() {
    return {
      User: null
    };
  },
  created() {
    this.User = this.$store.getters["user/GetUser"];
  }
};
</script>
