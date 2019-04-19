<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h4 class="card-title text-center mb-4 mt-1">Sign In</h4>
      <hr>
      <div class="d-flex justify-content-center" v-if="isLoggingIn" id="atom-spinner">
        <semipolar-spinner :animation-duration="3000" :size="150" :color="'#7289da'"/>
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
          <b-alert
            id="alertMsg"
            fade
            dismissible
            variant="danger"
            :show="dismissCountDown"
            @dismiss-count-down="countDownChanged"
          >{{alertMsg}}</b-alert>
          <p class="text-center forgot-password" v-show="!dismissCountDown">
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
      alertMsg: "",
      dismissSecs: 5,
      dismissCountDown: 0
    };
  },
  computed: {
    isFormValid() {
      return !this.errors.any();
    },
    isLoggingIn() {
      return this.$store.getters.authStatus == "loading";
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async login() {
      if (!this.isFormValid) {
        return;
      }

      const { email, password } = this;
      const result = await this.$store.dispatch("Login", { email, password });

      switch (result) {
        case 0:
          this.$router.push("/user");
          break;
        case 1:
          this.showAlert("Login service down.");
          break;
        case 2:
          this.showAlert("User not found.");
          this.$validator.errors.add({
            field: "email",
            msg: "User not found"
          });
          this.$validator.errors.add({
            field: "password",
            msg: "User not found"
          });
          break;
        default:
          this.showAlert("Unknown error.");
          break;
      }
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    showAlert(msg) {
      this.alertMsg = msg;
      this.dismissCountDown = this.dismissSecs;
    }
  }
};
</script>

<style scoped lang="css">
#atom-spinner {
  margin-top: 25px;
}

#alertMsg {
  font-size: 13px;
}

.card-container.card {
  background-color: #7289da;
}

.card {
  /* just in case there no content*/
  margin: 0 auto;
  height: 310px;
  /* shadows and rounded borders */
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  border-radius: 2px;
  -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
}

.btn.btn-signin {
  /* background-color: linear-gradient(rgb(104, 145, 162), rgb(12, 97, 33));*/
  font-weight: bold;
  font-size: 15px;
  height: 36px;
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
  transform: scaleX(1.05);
}

.forgot-password {
  margin-top: 20px;
  color: black;
  text-decoration: none;
}

.forgot-password:hover,
.forgot-password:active,
.forgot-password:focus {
  transform: scaleX(1.06);
}
</style>
