<template>
  <div id="register-form">
    <div class="card rounded">
      <article class="card-body">
        <h4
          class="card-title text-center mb-4 mt-1"
        >This account will be used to login to our servers</h4>
        <hr>
        <div class="d-flex justify-content-center" v-if="loading" id="atom-spinner">
          <semipolar-spinner :animation-duration="3000" :size="150" :color="'#7289da'"/>
        </div>
        <div v-else>
          <form @submit.prevent="register">
            <div class="form-group">
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-user fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="inputName"
                  name="Username"
                  data-vv-as="Username"
                  class="form-control"
                  placeholder="Username"
                  type="text"
                  v-model="Username"
                  v-validate="'required|alpha_num|min:6'"
                  :class="{'form-control': true, 'error': errors.has('Username') }"
                  autofocus
                ></b-input>
                <b-tooltip placement="bottom" target="inputName">{{ getErrorMsg('Username') }}</b-tooltip>
              </div>
            </div>
            <div class="form-group">
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="inputPassword"
                  name="Password"
                  class="form-control"
                  placeholder="Password"
                  type="password"
                  v-model="Password"
                  v-validate="'required|min:8'"
                  ref="Password"
                  :class="{'form-control': true, 'error': errors.has('Password') }"
                ></b-input>
                <b-tooltip placement="bottom" target="inputPassword">{{ getErrorMsg('Password') }}</b-tooltip>
              </div>
            </div>
            <div class="form-group">
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="inputPasswordAgain"
                  name="confirm password"
                  class="form-control"
                  placeholder="Confirm Password"
                  type="password"
                  v-model="PasswordAgain"
                  v-validate="'required|confirmed:Password'"
                  :class="{'form-control': true, 'error': errors.has('confirm password') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="inputPasswordAgain"
                >{{ getErrorMsg('confirm password') }}</b-tooltip>
              </div>
            </div>
            <div class="form-group">
              <button type="submit" class="btn btn-signin btn-primary btn-block">Register</button>
              <b-alert
                id="alert-msg"
                fade
                dismissible
                variant="danger"
                :show="dismissCountDown"
                @dismiss-count-down="countDownChanged"
              >{{alertMsg}}</b-alert>
            </div>
            <p class="text-center forgot-password" v-if="!dismissCountDown">
              <a href="#" class="forgot-password">Already have an account?</a>
            </p>
          </form>
        </div>
      </article>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import config from "../config.js";

const API_ACCOUNT = config.API.ACCOUNT;

export default {
  data() {
    return {
      Username: "",
      Password: "",
      PasswordAgain: "",

      alertMsg: "",
      dismissSecs: 5,
      dismissCountDown: 0,

      loading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {},
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async register() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      this.loading = true;

      const { Username, Password } = this;

      try {
        await this.$http.post(`${API_ACCOUNT}/register`, {
          Username,
          Password
        });

        this.$router.push("/user");
        this.$toasted.success(
          `Success! Account ${Username} has successfully been created!`
        );
      } catch (err) {
        if (err.response) {
          this.$toasted.error(err.response.data.message);
        } else {
          this.$toasted.error(err.message);
        }
      }

      this.loading = false;
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

<style scoped>
#register-form {
  text-align: center;
}

#alert-msg {
  margin-top: 20px;
}

.card {
  background-color: #eeeeee;
  /* just in case there no content*/
  margin: 0 auto;
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
  transform: scaleX(1.03);
}

.forgot-password {
  text-decoration: none;
}

.forgot-password:hover,
.forgot-password:active,
.forgot-password:focus {
  transform: scaleX(1.05);
}
</style>