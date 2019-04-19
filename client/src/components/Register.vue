<template>
  <div id="register-form">
    <div class="card rounded">
      <article class="card-body">
      <h4 class="card-title text-center mb-4 mt-1">You are steps away from joining our great server!</h4>
        <hr>
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
              name="Firstname"
              data-vv-as="Firstname"
              class="form-control"
              placeholder="First Name"
              type="text"
              v-model="Firstname"
              v-validate="'required|alpha|min:2'"
              :class="{'form-control': true, 'error': errors.has('Firstname') }"
              autofocus
            ></b-input>
            <b-tooltip placement="bottom" target="inputName">{{ getErrorMsg('Firstname') }}</b-tooltip>
          </div>
        </div>
        <div class="form-group">
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <i class="fa fa-user fa-fw"></i>
              </span>
            </div>
            <b-input
              id="inputLastName"
              name="Lastname"
              data-vv-as="Lastname"
              class="form-control"
              placeholder="Last Name"
              type="text"
              v-model="Lastname"
              v-validate="'required|alpha|min:2'"
              :class="{'form-control': true, 'error': errors.has('Lastname') }"
              autofocus
            ></b-input>
            <b-tooltip placement="bottom" target="inputLastName">{{ getErrorMsg('Lastname') }}</b-tooltip>
          </div>
        </div>
        <div class="form-group">
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <i class="fa fa-envelope fa-fw"></i>
              </span>
            </div>
            <b-input
              id="inputEmail"
              name="Email"
              class="form-control"
              placeholder="Email"
              type="text"
              v-model="Email"
              v-validate="'required|email'"
              :class="{'form-control': true, 'error': errors.has('Email') }"
              autofocus
            ></b-input>
            <b-tooltip placement="bottom" target="inputEmail">{{ getErrorMsg('Email') }}</b-tooltip>
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
          <button
            type="submit"
            class="btn btn-signin btn-primary btn-block"
          >Register</button>
          <b-alert
            id="alert-msg"
            fade
            dismissible
            variant="danger"
            :show="dismissCountDown"
            @dismiss-count-down="countDownChanged"
          >{{alertMsg}}
          </b-alert>
        </div>
        <p class="text-center forgot-password" v-if="!dismissCountDown">
          <a href="#" class="forgot-password">Already have an account?</a>
        </p>
      </form>
      </article>
    </div>
  </div>
</template>

<script>
import config from '../config.js';

export default {
  data() {
    return {
      Firstname: "",
      Lastname: "",
      Email: "",
      Password: "",
      PasswordAgain: "",

      alertMsg: "",
      dismissSecs: 5,
      dismissCountDown: 0
    };
  },
  components: {
  },
  computed: {
    isFormValid() {
      return !this.errors.any();
    }
  },
  methods: {
    async register() {
      if (!this.isFormValid) {
        return;
      }

      const { Firstname, Lastname, Password, Email } = this;
      const result = await this.$store.dispatch("Register", { Firstname, Lastname, Password, Email });
      switch (result) {
        case 0:
        this.$router.push("/user");
        break;
        case 1:
        this.showAlert("Login Service Down.")
        break;
        case 2:
        this.showAlert(`${Email} already registered.`)
        break;
        default:
        this.showAlert("Unknown Error.");
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