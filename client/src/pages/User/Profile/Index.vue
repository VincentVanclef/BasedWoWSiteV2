<template lang="html">
  <div class="container">
    <keep-alive>
      <router-view :user="user"></router-view>
    </keep-alive>
  </div>
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
