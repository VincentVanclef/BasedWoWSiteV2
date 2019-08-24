<template lang="html">
  <div id="register-form">
    <div class="card rounded">
      <article class="card-body">
        <h5
          class="card-title text-center mb-4 mt-1"
        >You are steps away from joining our great server!</h5>
        <p>Email will be used to login to the website, and username to our game servers.</p>
        <hr>
      <div class="d-flex justify-content-center" v-if="IsLoading">
        <semipolar-spinner :animation-duration="2000" :size="150" :color="'#7289da'"/>
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
                name="Firstname"
                data-vv-as="Firstname"
                class="form-control"
                placeholder="First Name"
                type="text"
                v-model="Firstname"
                v-validate="'required|alpha|min:2|max:16'"
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
                v-validate="'required|alpha|min:2|max:16'"
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
                v-validate="'required|email|max:100'"
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
                  <i class="fa fa-user fa-fw"></i>
                </span>
              </div>
              <b-input
                id="Username"
                name="Username"
                data-vv-as="Username"
                class="form-control"
                placeholder="Username"
                type="text"
                v-model="Username"
                v-validate="'required|alpha_num|min:8|max:16'"
                :class="{'form-control': true, 'error': errors.has('Username') }"
                autofocus
              ></b-input>
              <b-tooltip placement="bottom" target="Username">{{ getErrorMsg('Username') }}</b-tooltip>
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
                v-validate="'required|min:8|max:16'"
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
          </div>
          <a href="#" class="forgot-password">Already have an account?</a>
        </form>
        </div>
      </article>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

export default {
  props: ["user"],
  data() {
    return {
      Firstname: "",
      Lastname: "",
      Email: "",
      Username: "",
      Password: "",
      PasswordAgain: "",
      IsLoading: false
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

      this.IsLoading = true;
      const { Username, Firstname, Lastname, Password, Email } = this;
      try {
        const result = await this.$store.dispatch("user/Register", {
          Firstname,
          Lastname,
          Username,
          Password,
          Email
        });
      } catch (e) {
        this.$toasted.error(this.$root.GetErrorMessage(e));
        return;
      } finally {
        this.IsLoading = false;
      }

      this.$toasted.success(`Welcome ${this.Firstname} ${this.Lastname}!`);
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped>
#register-form {
  text-align: center;
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
  height: 30%;
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