<template>
  <div class="container" id="register-form">
    <div class="title">
      <h4>You are steps away from joining our great server!</h4>
    </div>
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
            name="name"
            data-vv-as="first name"
            class="form-control"
            placeholder="First Name"
            type="text"
            v-model="name"
            v-validate="'required|alpha|min:2'"
            :class="{'form-control': true, 'error': errors.has('name') }"
            autofocus
          ></b-input>
          <b-tooltip placement="bottom" target="inputName">{{ getErrorMsg('name') }}</b-tooltip>
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
            name="lastname"
            data-vv-as="last name"
            class="form-control"
            placeholder="Last Name"
            type="text"
            v-model="lastName"
            v-validate="'required|alpha|min:2'"
            :class="{'form-control': true, 'error': errors.has('lastname') }"
            autofocus
          ></b-input>
          <b-tooltip placement="bottom" target="inputLastName">{{ getErrorMsg('lastname') }}</b-tooltip>
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
              <i class="fa fa-lock fa-fw"></i>
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
            ref="password"
            :class="{'form-control': true, 'error': errors.has('password') }"
          ></b-input>
          <b-tooltip placement="bottom" target="inputPassword">{{ getErrorMsg('password') }}</b-tooltip>
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
            placeholder="********"
            type="password"
            v-model="passwordAgain"
            v-validate="'required|confirmed:password'"
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
          v-bind:disabled="!isFormValid"
          class="btn btn-signin btn-primary btn-block"
        >Register</button>
      </div>
      <p class="text-center forgot-password">
        <a href="#" class="forgot-password">Already have an account?</a>
      </p>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: "",
      lastName: "",
      email: "",
      password: "",
      passwordAgain: ""
    };
  },
  computed: {
    isFormValid() {
      return !this.errors.any();
    }
  },
  methods: {
    register() {
      if (!this.isFormValid) {
        return;
      }

      alert("success");
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
  width: 50%;
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