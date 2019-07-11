<template>
  <div>
    <div class="row justify-content-center">
      <ul class="nav nav-tabs user-nav">
        <li class="nav-item">
          <router-link to="/admin/news">News</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/admin/members">Members</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/user/account">Ingame Account</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/user/account">Characters Options</router-link>
        </li>
      </ul>
    </div>
    <hr>
  </div>
</template>

<script>
export default {
  name: "AdminNav",
  data() {
    return {};
  }
};
</script>

<style scoped>
.user-nav a {
  display: block;
  background: #efdb06;
  border: 1px solid #f9e610;
  color: #3d3d3d;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-nav a:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}
</style>