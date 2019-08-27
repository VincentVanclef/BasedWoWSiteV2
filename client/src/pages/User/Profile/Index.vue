<template lang="html">
  <keep-alive>
    <router-view :user="user"></router-view>
  </keep-alive>
</template>

<script>
export default {
  props: ["user"],
  name: "Profile",
  data() {
    return {};
  }
};
</script>
