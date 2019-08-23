<template lang="html">
  <div class="container">
    <div class="row">
      <keep-alive>
        <router-view :user="user"></router-view>
      </keep-alive>
    </div>
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
