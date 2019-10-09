<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h4 class="text-center mb-4 mt-1">Sign In</h4>
      <hr />
      <div class="d-flex justify-content-center" v-if="IsLoading">
        <semipolar-spinner :animation-duration="2000" :size="150" :color="'#7289da'" />
      </div>
      <div v-else>
        <form @submit.prevent="login">
          <div class="form-group">
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="fa fa-user"></i>
                </span>
              </div>
              <b-input
                id="inputEmail"
                name="email"
                class="form-control"
                placeholder="Email"
                type="text"
                v-model="email"
                v-validate="'required|email'"
                :class="{'form-control': true, 'error': errors.has('email') }"
                autofocus
              ></b-input>
              <b-tooltip
                v-if="errors.has('email')"
                placement="bottom"
                target="inputEmail"
              >{{ getErrorMsg('email') }}</b-tooltip>
            </div>
          </div>
          <div class="form-group">
            <div class="input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <i class="fa fa-lock"></i>
                </span>
              </div>
              <b-input
                id="inputPassword"
                name="password"
                class="form-control"
                placeholder="********"
                type="password"
                v-model="password"
                v-validate="'required|min:8'"
                :class="{'form-control': true, 'error': errors.has('password') }"
              ></b-input>
              <b-tooltip
                v-if="errors.has('password')"
                placement="bottom"
                target="inputPassword"
              >{{ getErrorMsg('password') }}</b-tooltip>
            </div>
          </div>
          <div class="form-group">
            <b-button block variant="primary" class="font-weight-bold" @click="Login()">
              <i class="fa fa-sign-in"></i> Login
            </b-button>
          </div>
          <p class="text-center forgot-password">
            <a href="#" class="forgot-password">Forgot password?</a>
          </p>
        </form>
      </div>
    </article>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  data() {
    return {
      email: "",
      password: "",
      IsLoading: false
    };
  },
  computed: {},
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async Login() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      this.IsLoading = true;

      const { email, password } = this;

      let user = null;

      try {
        user = await this.$store.dispatch("user/Login", {
          email,
          password
        });
        this.$root.ToastSuccess(
          `Welcome ${user.firstname} ${user.lastname}!`,
          "Login Successful"
        );
      } finally {
        this.IsLoading = false;
      }
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped lang="css">
.forgot-password {
  color: black;
  text-decoration: none;
}

.forgot-password:hover,
.forgot-password:active,
.forgot-password:focus {
  transform: scaleX(1.04);
}
</style>
