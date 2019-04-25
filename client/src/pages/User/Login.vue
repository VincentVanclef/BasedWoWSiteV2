<template lang="html">
  <login-form></login-form>
</template>

<script>
import Login from "@/components/Login";

export default {
  name: "Login",
  data() {
    return {};
  },
  components: {
    'login-form': Login
  },
  methods: {}
};
</script>
