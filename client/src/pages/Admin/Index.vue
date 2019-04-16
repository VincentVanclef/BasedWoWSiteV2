<template>
  <keep-alive>
    <router-view></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      msg: "Welcome to the Admin Page"
    };
  },
  created() {}
};
</script>

<style>
</style>