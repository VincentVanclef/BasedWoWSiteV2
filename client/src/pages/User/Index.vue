<template>
  <div>
    <router-view></router-view>
  </div>
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