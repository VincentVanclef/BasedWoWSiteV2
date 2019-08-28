<template lang="html">
  <div class="main-content" v-if="IsAdmin">
    <admin-nav></admin-nav>
    <hr class="border-dark" />
    <router-view v-if="!isLoading" :user="user" :Admins="GetAdmins" :roles="GetRoles"></router-view>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";
import UserHelper from "@/helpers/UserHelper";

export default {
  props: ["user"],
  name: "admin-panel",
  data() {
    return {
      isLoading: false
    };
  },
  components: {
    "admin-nav": AdminNav
  },
  computed: {
    IsAdmin() {
      return UserHelper.IsAdmin();
    },
    GetAdmins() {
      return this.$store.getters["admin/GetAdmins"];
    },
    GetRoles() {
      return this.$store.getters["admin/roles/GetRoles"];
    }
  },
  created() {
    if (this.$store.getters["admin/GetAdmins"].length == 0) {
      this.isLoading = true;
      this.$store
        .dispatch("admin/FetchAdmins")
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.isLoading = false));
    }

    if (this.$store.getters["admin/roles/GetRoles"].length == 0) {
      this.isLoading = true;
      this.$store
        .dispatch("admin/roles/FetchRoles")
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>
