<template lang="html">
  <div class="main-content">
    <admin-nav></admin-nav>
    <keep-alive>
      <router-view v-if="!IsLoading" :User="GetUser" :Admins="GetAdmins"></router-view>
    </keep-alive>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";

export default {
  name: "admin-panel",
  data() {
    return {};
  },
  components: {
    "admin-nav": AdminNav
  },
  computed: {
    IsLoading() {
      return this.$store.getters.GetAdminStatus;
    },
    GetAdmins() {
      return this.$store.getters.GetAdmins;
    },
    GetUser() {
      return this.$store.getters.GetUser;
    }
  },
  created() {
    if (this.$store.getters.GetAdmins.length == 0) {
      this.$store.dispatch("GetAdmins").then(result => {
        if (result != "success") {
          this.$toasted.error(result);
        }
      });
    }
  }
};
</script>
