<template>
  <keep-alive>
    <router-view
      :user="user"
      :roles="roles"
      :realms="realms"
      :GameTrials="GameTrials"
      :GameMasters="GameMasters"
      :GameAdmins="GameAdmins"
    ></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "admin-panel-accounts",
  props: ["user", "GameTrials", "GameMasters", "GameAdmins", "realms"],
  data() {
    return {
      roles: [
        {
          id: 3,
          title: "Admin"
        },
        {
          id: 2,
          title: "Gamemaster"
        },
        {
          id: 1,
          title: "Trial"
        },
        {
          id: 0,
          title: "None"
        }
      ]
    };
  },
  created() {
    if (this.$store.getters["stats/GetTotalAccounts"] === 0) {
      this.$store
        .dispatch("stats/GetTotalAccounts")
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>
