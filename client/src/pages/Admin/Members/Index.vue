<template>
  <keep-alive>
    <router-view :user="user" :Admins="Admins" :Moderators="Moderators" :roles="roles"></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "admin-panel-users",
  props: ["user", "Admins", "Moderators", "roles"],
  data() {
    return {};
  }
};
</script>
