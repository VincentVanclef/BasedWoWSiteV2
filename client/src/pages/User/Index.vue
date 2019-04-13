<template>
<div>
  <router-view></router-view>
</div>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      msg: "Welcome to the User Page"
    };
  },
  created() {
    document.title = "User Page";
  }
};
</script>

<style>
</style>