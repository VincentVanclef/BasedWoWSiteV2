<template>
  <div>
    <div class="row justify-content-center">
      <ul class="nav nav-tabs user-menu">
        <li class="nav-item">
          <router-link to="/user/profile">Website Profile</router-link>
        </li>
        <li class="nav-item">
          <router-link to="#">Edit Profile</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/user/profile/password">Change Password</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/user/accounts">Ingame Accounts</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/user/accounts/link">Link Account</router-link>
        </li>
      </ul>
    </div>
    <hr>
  </div>
</template>

<script>
export default {
  name: "ProfileNav",
  data() {
    return {};
  }
};
</script>

<style scoped>
h5 {
  text-transform: capitalize;
}

.user-menu a {
  display: block;
  background: #efdb06;
  border: 1px solid #f9e610;
  color: #3d3d3d;
  padding: 10px 15px;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 15px;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-menu a:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}
</style>