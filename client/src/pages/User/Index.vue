<template lang="html">
  <div class="main-content" :style="{backgroundImage: 'url(' + avatar + ')' }">
    <router-view :user="user"></router-view>
  </div>
</template>

<script>
export default {
  name: "User",
  props: ["avatar", "user"],
  data() {
    return {};
  }
};
</script>

<style>
</style>