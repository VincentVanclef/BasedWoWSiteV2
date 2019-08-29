<template>
  <keep-alive>
    <router-view :user="user" :roles="roles" :realms="Realms"></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "admin-panel-accounts",
  props: ["user"],
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
          title: "Player"
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
    if (this.$store.getters["user/account/GetTotalAccounts"] === 0) {
      this.$store
        .dispatch("user/account/GetTotalAccounts")
        .finally(() => (this.isLoading = false));
    }
  }
};
</script>
