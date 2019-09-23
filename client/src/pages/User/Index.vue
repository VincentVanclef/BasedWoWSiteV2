<template lang="html">
  <div class="main-content" :style="{backgroundImage: 'url(' + avatar + ')' }">
    <router-view :user="user" :realms="realms"></router-view>
  </div>
</template>

<script>
export default {
  name: "User",
  props: ["avatar", "user", "realms"],
  data() {
    return {};
  }
};
</script>

<style>
</style>