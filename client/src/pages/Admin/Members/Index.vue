<template>
  <keep-alive>
    <router-view :user="user" :Admins="Admins" :roles="roles"></router-view>
  </keep-alive>
</template>

<script>
export default {
  name: "admin-panel-users",
  props: ["user", "Admins", "roles"],
  data() {
    return {};
  }
};
</script>
