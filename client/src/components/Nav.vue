<template lang="html">
  <b-navbar toggleable="lg" type="dark" variant="dark" class="">
    <b-container fluid>
      <b-navbar-brand to="/">
        <img
          class="navbar-logo"
          :src="require('@/assets/images/wow-logo.png')"
          alt
        />
        Titans-League
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item-dropdown
            left
            :class="{
              'router-link-active': isProfileActive,
              active: isProfileActive
            }"
          >
            <template v-slot:button-content>
              <i class="fas fa-user"></i> Profile
            </template>

            <b-dropdown-item to="/user/profile"
              ><i class="fas fa-user"></i> View Profile</b-dropdown-item
            >
            <b-dropdown-item to="/user/profile/password"
              ><i class="fas fa-lock"></i> Change Password</b-dropdown-item
            >
            <b-dropdown-item to="/user/vote"
              ><i class="fas fa-poll"></i> Vote</b-dropdown-item
            >
            <b-dropdown-item to="/user/donate"
              ><i class="fas fa-donate"></i> Donate</b-dropdown-item
            >
            <b-dropdown-item to="/user/account"
              ><i class="fas fa-magic"></i> Ingame Account</b-dropdown-item
            >
            <b-dropdown-item to="/user/characters"
              ><i class="fas fa-users"></i> Ingame Characters</b-dropdown-item
            >
          </b-nav-item-dropdown>

          <b-nav-item to="/connect" exact-active-class="active"
            ><i class="fas fa-info-circle"></i> How To Connect</b-nav-item
          >
          <b-nav-item to="/armory" exact-active-class="active"
            ><i class="fab fa-jedi-order"></i> Armory</b-nav-item
          >
          <b-nav-item to="/online" exact-active-class="active"
            ><i class="fas fa-globe-europe"></i> Online Players</b-nav-item
          >
          <b-nav-item to="/pvpstats" exact-active-class="active"
            ><i class="fas fa-fist-raised"></i> PvP Statistics</b-nav-item
          >
          <b-nav-item to="/changelog" exact-active-class="active"
            ><i class="fas fa-check-circle"></i> Changelog</b-nav-item
          >
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-item class="active" to="/user/register" v-if="!IsLoggedIn">
            <i class="fa fa-user-plus"></i> Sign Up
          </b-nav-item>

          <b-nav-item class="active" to="/user/login" v-if="!IsLoggedIn">
            <i class="fa fa-sign-in"></i> Login
          </b-nav-item>

          <b-nav-item class="active" @click="Logout" v-if="IsLoggedIn">
            <i class="fa fa-sign-out"></i> Logout
          </b-nav-item>

          <b-nav-item class="active" to="/admin" v-if="IsLoggedIn && isAdmin">
            <i class="fa fa-lock"></i> Admin Panel
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-container>
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
      return UserHelper.IsAdmin() || UserHelper.IsModerator();
    },
    isProfileActive() {
      return this.$route.path.includes("user");
    },
    IsLoggedIn() {
      return UserHelper.IsLoggedIn();
    }
  },
  methods: {
    async Logout() {
      await this.$store.dispatch("user/Logout");
      this.$root.$emit("Logout");
    }
  }
};
</script>

<style lang="scss">
.navbar {
  box-shadow: 0 4px 7px rgba(0, 0, 0, 0.16), 0 4px 7px rgba(0, 0, 0, 0.23);
}

.nav-link,
.active {
  background-image: linear-gradient(white, grey);
  background-size: 0 2px, auto;
  background-repeat: no-repeat;
  background-position: center bottom;
  transition: all 0.2s ease-out;

  &:hover {
    background-size: 95% 2px, auto;
  }
}

.router-link-active,
.router-link-exact-active {
  color: #fff !important;

  background-size: 95% 2px, auto;
}
</style>
