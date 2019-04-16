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
          <b-nav-item-dropdown text="Admin" v-bind:class="{ 'active': isActive }">
            <b-dropdown-item href="#/admin">View Products</b-dropdown-item>
            <b-dropdown-item href="#/admin/new">New Product</b-dropdown-item>
          </b-nav-item-dropdown>
          <li class="nav-item">
            <router-link exact-active-class="active" class="nav-link" to="/cart">Cart</router-link>
          </li>
        </ul>
        <ul class="navbar-nav navbar-right" v-if="isLoggedIn">
          <li>
            <a href="#/user/register">
              <i class="fa fa-sign-in"></i> Sign Up
            </a>
          </li>
          <li>
            <a href="#/user/login">
              <i class="fa fa-user"></i> Login
            </a>
          </li>
        </ul>
      </div>
    </div>
  </b-navbar>
</template>

<script>
export default {
  data() {
    return {
      isLoggedIn: true
    };
  },
  computed: {
    isActive() {
      return this.$route.name == "Products" || this.$route.name == "New";
    }
  }
};
</script>
