<template lang="html">
  <div class="main-content">
    <admin-nav></admin-nav>
    <keep-alive>
      <router-view v-if="!Loading" v-bind:User="User" :Admins="Admins"></router-view>
    </keep-alive>
  </div>
</template>

<script>
import AdminNav from "@/components/Admin/AdminNav";

const API_ADMIN = process.env.API.ADMIN;

export default {
  name: "admin-panel",
  data() {
    return {
      User: null,
      Admins: [],
      Loading: true
    };
  },
  components: {
    "admin-nav": AdminNav
  },
  methods: {
    async GetAdmins() {
      let result;
      try {
        result = await this.$http.get(`${API_ADMIN}/get/admins`);
      } catch (error) {
        this.$toasted.error(error);
        return;
      }

      this.Admins = result.data;
    }
  },
  created() {
    this.GetAdmins().then(() => (this.Loading = false));

    this.User = this.$store.getters.GetUser;
  }
};
</script>
