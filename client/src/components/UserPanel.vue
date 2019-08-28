<template>
  <div class="card rounded" style="margin-bottom: 20px" v-if="user != null">
    <article class="card-body">
      <div class="card-title text-center mb-3 mt-1">
        <b-container>
          <b-row class="d-flex justify-content-center">
            <h5>Welcome</h5>
          </b-row>
          <b-row class="d-flex justify-content-center text-capitalize">
            <h4>
              <strong>{{ user.firstname }} {{ user.lastname }}</strong>
            </h4>
          </b-row>
        </b-container>
      </div>
      <hr class="border-dark" />
      <b-button-group vertical class="btn-block">
        <b-button
          variant="dark"
          to="/user/profile"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          View Profile
          <i class="fas fa-user float-right"></i>
        </b-button>
        <b-button
          variant="dark"
          to="/user/profile/password"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          Change Password
          <i class="fas fa-lock float-right"></i>
        </b-button>
        <b-button
          variant="dark"
          to="/user/vote"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          Vote
          <i class="fas fa-poll float-right"></i>
        </b-button>
        <b-button
          variant="dark"
          to="/user/donate"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          Donate
          <i class="fas fa-donate float-right"></i>
        </b-button>
        <b-button
          variant="dark"
          to="/user/account"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          Ingame Account
          <i class="fas fa-magic float-right"></i>
        </b-button>
        <b-button
          variant="dark"
          to="/user/characters"
          exact-active-class="active"
          class="text-left font-weight-bold"
        >
          Ingame Characters
          <i class="fas fa-users float-right"></i>
        </b-button>
      </b-button-group>
      <hr class="border-dark" />
      <b-button block variant="warning" class="font-weight-bold" @click="Logout">
        <i class="fa fa-sign-out"></i> Logout
      </b-button>
    </article>
  </div>
</template>

<script>
export default {
  props: ["user"],
  name: "UserPanel",
  data() {
    return {};
  },
  methods: {
    async Logout() {
        await this.$store.dispatch("user/Logout");
    }
  },
  created() {}
};
</script>

<style scoped>
h4 {
  text-transform: capitalize;
  word-wrap: break-word;
}
</style>
