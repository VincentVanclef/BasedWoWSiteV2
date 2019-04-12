<template>
  <div>
    <form @submit.prevent="register">
      <div class="form-group">
        <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">
              <i class="fa fa-user"></i>
            </span>
          </div>
          <b-input
            id="inputName"
            name="name"
            class="form-control"
            placeholder="Name"
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
              <i class="fa fa-user"></i>
            </span>
          </div>
          <b-input
            id="inputLastName"
            name="lastname"
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
              <i class="fa fa-envelope"></i>
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
            v-validate="'required|min:8'"
            :class="{'form-control': true, 'error': errors.has('password') }"
          ></b-input>
          <b-tooltip placement="bottom" target="inputPassword">{{ getErrorMsg('password') }}</b-tooltip>
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
            id="inputPasswordAgain"
            name="passwordAgain"
            class="form-control"
            placeholder="********"
            type="password"
            v-model="passwordAgain"
            v-validate="'required|min:8'"
            :class="{'form-control': true, 'error': errors.has('passwordAgain') }"
          ></b-input>
          <b-tooltip
            placement="bottom"
            target="inputPasswordAgain"
          >{{ getErrorMsg('passwordAgain') }}</b-tooltip>
        </div>
      </div>
      <div class="form-group">
        <button type="submit" class="btn btn-signin btn-primary btn-block">Register</button>
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
  methods: {
    register() {
        if (this.errors.length > 0)
        alert('success');
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style>
</style>