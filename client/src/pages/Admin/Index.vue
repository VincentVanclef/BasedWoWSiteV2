<template>
  <keep-alive>
    <div class="main-content">
      <router-view></router-view>
    </div>
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