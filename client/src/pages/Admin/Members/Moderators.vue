<template>
  <member-view-component :user="user" :members="Moderators" :roles="roles" :sm="6" :md="6" :lg="12"></member-view-component>
</template>

<script>
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";
import MemberViewComponent from "@/components/Admin/Members/MemberViewComponent";

export default {
  name: "Moderators",
  props: ["user", "Moderators", "roles"],
  data() {
    return {};
  },
  components: {
    "member-view-component": MemberViewComponent
  }
};
</script>