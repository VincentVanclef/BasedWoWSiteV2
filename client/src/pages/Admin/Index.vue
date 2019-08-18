<template lang="html">
  <div class="main-content">
    <admin-nav></admin-nav>
    <keep-alive>
      <router-view v-if="!isLoading" :User="GetUser" :Admins="GetAdmins"></router-view>
    </keep-alive>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";

export default {
  name: "admin-panel",
  data() {
    return {
      isLoading: true
    };
  },
  components: {
    "admin-nav": AdminNav
  },
  computed: {
    GetAdmins() {
      return this.$store.getters["admin/GetAdmins"];
    },
    GetUser() {
      return this.$store.getters.GetUser;
    }
  },
  created() {
    if (this.$store.getters["admin/GetAdmins"].length == 0) {
      this.$store
        .dispatch("admin/FetchAdmins")
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>
