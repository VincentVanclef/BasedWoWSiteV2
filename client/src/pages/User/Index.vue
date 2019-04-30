<template lang="html">
  <div class="main-content" v-bind:style="{backgroundImage: 'url(' + avatar + ')' }">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "User",
  props: ["avatar"],
  data() {
    return {};
  },
  created() {}
};
</script>

<style>
</style>