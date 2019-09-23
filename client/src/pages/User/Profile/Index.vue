<template lang="html">
  <keep-alive>
    <router-view :user="user" :realms"realms"></router-view>
  </keep-alive>
</template>

<script>
export default {
  props: ["user", "realms"],
  name: "Profile",
  data() {
    return {};
  }
};
</script>
