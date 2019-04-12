<template>
  <router-view></router-view>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      msg: "Welcome to the Admin Page"
    };
  },
  created() {
    document.title = "Admin Page";
  }
};
</script>

<style>
</style>