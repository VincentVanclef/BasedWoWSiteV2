<template>
  <b-container>
    <login-form></login-form>
  </b-container>
</template>

<script>
import Login from "@/components/Login";
import UserHelper from "../../helpers/UserHelper.js";

export default {
  name: "Login",
  data() {
    return {};
  },
  components: {
    "login-form": Login
  },
  methods: {},
  beforeRouteEnter(to, from, next) {
    if (UserHelper.IsLoggedIn()) {
      next("/user/profile");
    } else {
      next();
    }
  }
};
</script>
