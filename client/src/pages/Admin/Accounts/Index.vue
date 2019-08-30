<template>
  <keep-alive>
    <router-view
      :user="user"
      :roles="roles"
      :realms="Realms"
      :GameTrials="GameTrials"
      :GameMasters="GameMasters"
      :GameAdmins="GameAdmins"
    ></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "admin-panel-accounts",
  props: ["user", "GameTrials", "GameMasters", "GameAdmins"],
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
  computed: {
    Realms() {
      return this.$store.getters["realms/GetRealms"];
    }
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
