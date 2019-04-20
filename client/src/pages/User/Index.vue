<template>
  <keep-alive>
    <router-view></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "User",
  data() {
    return {
      msg: "Welcome to the User Profile"
    };
  },
  created() {
    document.title = "User Profile";
  }
};
</script>

<style>
</style>