<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h4 class="text-center mb-4 mt-1">Sign In</h4>
      <hr />
      <div v-if="IsLoading" class="d-flex justify-content-center mb-2 mt-4">
        <b-spinner variant="dark" label="Spinning"></b-spinner>
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
                autocomplete="email"
                @keydown.enter="Login()"
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
                autocomplete="password"
                v-model="password"
                v-validate="'required|min:8'"
                :class="{'form-control': true, 'error': errors.has('password') }"
                @keydown.enter="Login()"
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
export default {
  data() {
    return {
      email: "",
      password: "",
      IsLoading: false
    };
  },
  computed: {},
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

      try {
        const user = await this.$store.dispatch("user/Login", {
          email,
          password
        });
        this.$root.ToastSuccess(
          `Welcome ${user.firstname} ${user.lastname}!`,
          "Login Successful"
        );
        this.$root.$emit("Login");
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
