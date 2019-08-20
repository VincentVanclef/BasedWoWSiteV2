<template lang="html">
  <b-navbar class="navbar navbar-expand-sm bg-dark navbar-dark">
    <div class="container">
      <a class="navbar-brand" href="/">
        <img class="navbar-logo" :src="require('@/assets/images/wow-logo.png')" alt>
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
          <b-nav-item-dropdown text="Profile" v-bind:class="{ 'active': isProfileActive }" v-if="isLoggedIn">
            <router-link to="/user/profile" role="menuitem" class="dropdown-item">View Website Profile</router-link>
            <router-link to="/user/profile/password" role="menuitem" class="dropdown-item">Change Website Password</router-link>
            <router-link to="/user/account" role="menuitem" class="dropdown-item">Manage Ingame Account</router-link>
            <router-link to="/user/characters" role="menuitem" class="dropdown-item">Manage Ingame Characters</router-link>
          </b-nav-item-dropdown>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/connect">How to Connect</router-link>
          </li>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/online">Online Players</router-link>
          </li>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/changelog">Changelog</router-link>
          </li>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/pvpstats">PvP Statistics</router-link>
          </li>
          <li class="nav-item" v-if="isLoggedIn">
            <router-link exact-active-class="active" class="nav-link" to="/user/vote">Vote</router-link>
          </li>
          <li class="nav-item" v-if="isLoggedIn">
            <router-link exact-active-class="active" class="nav-link" to="/user/donate">Donate</router-link>
          </li>
        </ul>
        <ul class="navbar-nav navbar-right" v-if="!isLoggedIn">
          <li>
            <button class="navbar-button active" @click="Register">
              <i class="fa fa-sign-in"></i> Sign Up
            </button>
          </li>
          <li>
            <button class="navbar-button" @click="Login">
              <i class="fa fa-user"></i> Login
            </button>
          </li>
        </ul>
        <ul class="navbar-nav navbar-right" v-else>
          <li>
            <button class="navbar-button responsive" @click="Logout">
              <i class="fa fa-sign-out"></i> Logout
            </button>
          </li>
          <li v-if="isAdmin">
            <button class="navbar-button responsive" @click="Admin">
              <i class="fa fa-lock"></i> Admin Panel
            </button>
          </li>
        </ul>
      </div>
    </div>
  </b-navbar>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";

export default {
  data() {
    return {};
  },
  computed: {
    isAdmin() {
      return UserHelper.IsAdmin();
    },
    isProfileActive() {
      return this.$route.path.includes("user");
    },
    isLoggedIn() {
      return UserHelper.IsLoggedIn();
    }
  },
  methods: {
    Logout() {
      this.$store.dispatch("user/Logout");
      this.$router.push("/news");
    },
    Register() {
      this.$router.push("/user/register");
    },
    Login() {
      this.$router.push("/user/login");
    },
    Admin() {
      this.$router.push("/admin");
    }
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

.navbar {
  box-shadow: 0 4px 7px rgba(0, 0, 0, 0.16), 0 4px 7px rgba(0, 0, 0, 0.23);
}
</style>