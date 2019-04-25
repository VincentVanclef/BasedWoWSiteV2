<template>
  <b-navbar class="navbar navbar-expand-sm bg-dark navbar-dark">
    <div class="container">
      <a class="navbar-brand" href="/">
        <img src="../assets/wow-logo.png" alt width="60">
      </a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarResponsive"
        aria-controls="navbarResponsive"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav nav__left ml-auto">
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/">Home</router-link>
          </li>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/connect">How to Connect</router-link>
          </li>
          <b-nav-item-dropdown text="Profile" v-bind:class="{ 'active': isProfileActive }" v-if="isLoggedIn">
            <b-dropdown-item href="#/user/profile">View Website Profile</b-dropdown-item>
            <b-dropdown-item href="#/user/profile/password">Change Website Password</b-dropdown-item>
            <b-dropdown-item href="#/user/account">Manage Ingame Account</b-dropdown-item>
          </b-nav-item-dropdown>
          <li class="nav-item" v-if="isLoggedIn">
            <router-link exact-active-class="active" class="nav-link" to="/user/vote">Vote</router-link>
          </li>
          <li class="nav-item" v-if="isLoggedIn">
            <router-link exact-active-class="active" class="nav-link" to="/user/donate">Donate</router-link>
          </li>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/cart">Cart</router-link>
          </li>
          <b-nav-item-dropdown text="Admin" v-bind:class="{ 'active': isAdminActive }">
            <b-dropdown-item href="#/admin">View Products</b-dropdown-item>
            <b-dropdown-item href="#/admin/new">New Product</b-dropdown-item>
          </b-nav-item-dropdown>
        </ul>
        <ul class="navbar-nav navbar-right" v-if="!isLoggedIn">
          <li>
            <button class="active" @click="Register">
              <i class="fa fa-sign-in"></i> Sign Up
            </button>
          </li>
          <li>
            <button id="login-button" @click="Login">
              <i class="fa fa-user"></i> Login
            </button>
          </li>
        </ul>
        <ul class="navbar-nav navbar-right" v-else>
          <li>
            <button id="logout-button" @click="Logout">
              <i class="fa fa-sign-out"></i> Logout
            </button>
          </li>
        </ul>
      </div>
    </div>
  </b-navbar>
</template>

<script>
import UserHelper from "../helpers/UserHelper"

export default {
  data() {
    return {};
  },
  computed: {
    isAdminActive() {
      return this.$route.name == "Products" || this.$route.name == "New";
    },
    isProfileActive() {
      return this.$route.path.includes("user")
    },
    isLoggedIn() {
      return UserHelper.IsLoggedIn()
    }
  },
  methods: {
    Logout() {
      this.$store.dispatch("Logout");
      this.$router.push("/news");
    },
    Register() {
      this.$router.push("/user/register");
    },
    Login() {
      this.$router.push("/user/login");
    },
    
  }
};
</script>

<style scoped>
button {
  background: none !important;
  border: none;
  font: inherit;
  cursor: pointer;
  color: #ffffff;
  display: block;
  transition: all 150ms ease-out;
  text-transform: uppercase;
}
</style>

