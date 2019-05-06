<template lang="html">
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h5 class="card-title text-center mb-4 mt-1">Sign In</h5>
      <hr>
      <div class="d-flex justify-content-center" v-if="isLoggingIn">
        <semipolar-spinner :animation-duration="2000" :size="150" :color="'#7289da'"/>
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
              <b-tooltip placement="bottom" target="inputEmail">{{ getErrorMsg('email') }}</b-tooltip>
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
                v-validate="'required|min:4'"
                :class="{'form-control': true, 'error': errors.has('password') }"
              ></b-input>
              <b-tooltip placement="bottom" target="inputPassword">{{ getErrorMsg('password') }}</b-tooltip>
            </div>
          </div>
          <div class="form-group">
            <button type="submit" class="btn btn-signin btn-primary btn-block">Login</button>
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
      password: ""
    };
  },
  computed: {
    isLoggingIn() {
      return this.$store.getters.GetAuthStatus == "loading";
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async login() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      const { email, password } = this;
      const data = await this.$store.dispatch("Login", { email, password });
      if (data == "success") {
        this.$router.push("/user/profile");
        this.$toasted.success(
          `Welcome ${this.$store.getters.GetUser.firstname}`
        );
      } else {
        this.$toasted.error(data);
      }
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped lang="css">
.btn.btn-signin {
  /* background-color: linear-gradient(rgb(104, 145, 162), rgb(12, 97, 33));*/
  font-weight: bold;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
  border: none;
  -o-transition: all 0.218s;
  -moz-transition: all 0.218s;
  -webkit-transition: all 0.218s;
  transition: all 0.218s;
}

.btn.btn-signin:hover,
.btn.btn-signin:active,
.btn.btn-signin:focus {
  transform: scaleX(1.04);
}

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
