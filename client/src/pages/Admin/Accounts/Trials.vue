<template>
  <account-view-component
    :user="user"
    :members="Moderators"
    :roles="roles"
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
  name: "Moderators",
  props: ["user", "Moderators", "roles"],
  data() {
    return {};
  },
  components: {
    "account-view-component": AccountViewComponent
  }
};
</script>