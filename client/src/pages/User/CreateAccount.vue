<template>
  <register-form></register-form>
</template>

<script>
import CreateWoWAccount from "@/components/CreateWoWAccount";

export default {
  name: "Register",
  data() {
    return {};
  },
  components: {
    "register-form": CreateWoWAccount
  }
};
</script>
