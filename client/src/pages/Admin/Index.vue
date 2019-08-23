<template lang="html">
  <div class="main-content">
    <admin-nav></admin-nav>
    <keep-alive>
      <router-view v-if="!isLoading" :user="user" :Admins="GetAdmins"></router-view>
    </keep-alive>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";

export default {
  props: ["user"],
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
