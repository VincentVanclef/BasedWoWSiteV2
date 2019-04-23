<template>
  <div class="card rounded" style="margin-bottom: 20px" v-if="user != null">
    <article class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">
        Welcome,
        <strong>{{ user.firstname }}</strong>
      </h5>
      <hr>
      <div class>
        <ul class="user-menu">
          <li>
            <router-link to="/user/profile">View Website Profile</router-link>
          </li>
          <li>
            <router-link to="/user/profile/password">Change Website Password</router-link>
          </li>
          <li>
            <router-link to="/user/create/account">Create Ingame Account</router-link>
          </li>
          <li>
            <router-link to="/user/accounts">Manage Ingame Accounts</router-link>
          </li>
          <li>
            <router-link to="/user/vote">Vote Panel</router-link>
          </li>
          <li>
            <router-link to="/user/donate">Donation Panel</router-link>
          </li>
          <hr>
          <button id="logout-button" @click="Logout">
            <i class="fa fa-sign-out"></i> Logout
          </button>
        </ul>
      </div>
    </article>
  </div>
</template>

<script>
export default {
  name: "UserPanel",
  data() {
    return {
      user: null
    };
  },
  methods: {
    Logout() {
      this.$store.dispatch("Logout");
      this.$router.push("/news");
    }
  },
  created() {
    this.user = this.$store.getters.GetUser;
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
  font-size: 12px;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-menu a:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}

.user-menu button {
  display: block;
  background: #000000;
  border: 1px solid #000000;
  color: white;
  width: 205px;
  padding: 10px 15px;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 12px;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-menu button:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}
</style>
