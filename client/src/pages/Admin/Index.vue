<template lang="html">
  <div class="main-content">
    <admin-nav></admin-nav>
    <keep-alive>
      <router-view v-bind:User="User"></router-view>
    </keep-alive>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";

export default {
  name: "admin-panel",
  data() {
    return {
      User: null
    };
  },
  components: {
    "admin-nav": AdminNav
  },
  created() {
    this.User = this.$store.getters.GetUser;
  }
};
</script>
