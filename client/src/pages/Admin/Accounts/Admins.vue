<template>
  <account-view-component
    v-if="GameAdmins.length > 0"
    :user="user"
    :accounts="GameAdmins"
    :roles="roles"
    :realms="realms"
    :sm="6"
    :md="6"
    :lg="12"
    :query="''"
  ></account-view-component>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import AccountViewComponent from "@/components/Admin/Accounts/AccountViewComponent";

export default {
  name: "GameAdmins",
  props: ["user", "GameAdmins", "roles", "realms"],
  data() {
    return {};
  },
  components: {
    "account-view-component": AccountViewComponent
  }
};
</script>