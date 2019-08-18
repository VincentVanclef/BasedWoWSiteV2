<template>
  <div class="card rounded" style="margin-bottom: 20px" v-if="user != null">
    <article class="card-body">
      <div class="card-title text-center mb-4 mt-1">
        <h5>
          Welcome,
          <strong>{{ user.firstname }}</strong>
        </h5>
      </div>
      <hr class="hr-style" />
      <div class>
        <ul class="user-menu">
          <li>
            <router-link to="/user/profile">View Website Profile</router-link>
          </li>
          <li>
            <router-link to="/user/profile/password">Change Website Password</router-link>
          </li>
          <li>
            <router-link to="/user/account">Manage Ingame Account</router-link>
          </li>
          <li>
            <router-link to="/user/characters">Mange Ingame Characters</router-link>
          </li>
          <li>
            <router-link to="/user/vote">Vote Panel</router-link>
          </li>
          <li>
            <router-link to="/user/donate">Donation Panel</router-link>
          </li>
          <hr class="hr-style" />
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
  word-wrap: break-word;
}

.user-menu a {
  display: block;
  background: #ffc107;
  border: 1px solid #ffc107;
  color: #3d3d3d;
  padding: 10px 15px;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  transform: scaleX(1);
  word-wrap: break-word;
  transition: transform 200ms ease-in;
}

.user-menu a:hover {
  text-decoration: none;
  transform: scaleX(1.03);
}

.user-menu button {
  display: block;
  background: #000000;
  border: 1px solid #000000;
  color: white;
  width: 100%;
  padding: 10px;
  font-family: "PT Sans", sans-serif;
  font-weight: bold;
  text-transform: uppercase;
  transform: scaleX(1);
  transition: transform 200ms ease-in;
}

.user-menu button:hover {
  text-decoration: none;
  transform: scaleX(1.02);
}
</style>
