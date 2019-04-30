<template lang="html">
  <register-form></register-form>
</template>

<script>
import Register from "@/components/Register";
import UserHelper from "../../helpers/UserHelper.js";

export default {
  name: "Register",
  data() {
    return {};
  },
  components: {
    "register-form": Register
  },
  beforeRouteEnter(to, from, next) {
    if (UserHelper.IsLoggedIn()) {
      next("/user/profile");
    } else {
      next();
    }
  }
};
</script>
