<template>
  <div>
    <h3>Accounts {{ User.firstname }}</h3>
  </div>
</template>

<script>
import config from "@/config";

const API_USER = config.API.USER;

export default {
  name: "Accounts",
  props: ['User'],
  data() {
    return {
        Accounts: [],
    };
  },
  methods: {
    async GetAccountData() {
      this.Loading = true;
      try {
        const result = await this.$http.get(`${API_USER}/accountdata`);
        for (const acc of result.data) {
          this.Accounts.push(acc);
        }
      } catch (err) {
        console.log(err);
      }
    }
  },
  created() {
    this.User = this.$store.getters.user;

    this.GetAccountData().finally(() => (this.Loading = false));
  }
};
</script>
