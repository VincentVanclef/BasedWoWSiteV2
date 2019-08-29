<template lang="html">
  <div class="main-content" v-if="IsAdmin">
    <admin-nav></admin-nav>
    <hr class="border-dark" />
    <router-view v-if="!isLoading" 
    :user="user" 
    :Admins="GetAdmins" 
    :Moderators="GetModerators"
    :roles="GetRoles" 
    :GameTrials="GetGameTrials"
    :GameMasters="GetGameMasters"
    :GameAdmins="GetGameAdmins"></router-view>
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
    GetModerators() {
      return this.$store.getters["admin/GetModerators"];
    },
    GetRoles() {
      return this.$store.getters["admin/roles/GetRoles"];
    },
    GetGameTrials() {
      return this.$store.getters["stats/GetGameTrials"];
    },
    GetGameMasters() {
      return this.$store.getters["stats/GetGameMasters"];
    },
    GetGameAdmins() {
      return this.$store.getters["stats/GetGameAdmins"];
    }
  },
  created() {
    this.$store.dispatch("admin/Authorize").then(() => {
      if (this.$store.getters["stats/GetGameMasters"].length == 0) {
        this.isLoading = true;
        this.$store
          .dispatch("stats/GetGameMasters")
          .finally(() => (this.isLoading = false));
      }

      if (this.$store.getters["admin/roles/GetRoles"].length == 0) {
        this.isLoading = true;
        this.$store
          .dispatch("admin/roles/FetchRoles")
          .finally(() => (this.isLoading = false));
      }
    });
  }
};
</script>
