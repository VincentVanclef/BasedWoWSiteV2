<template>
  <div class="card rounded" style="margin-bottom: 20px">
    <article class="card-body">
      <h4 class="card-title text-center mb-4 mt-1">Sign In</h4>
      <hr>
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
              v-validate="'required|min:8'"
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
    </article>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    login() {
      const { email, password } = this;
      /*await this.$store.dispatch("login", { email, password });
            this.$router.push("/");*/
      alert(email + " " + password);
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped lang="css">
.card-container.card {
  background-color: #7289da;
}

/*
 * Card component
 */
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
  transform: scaleX(1.05);
}

.forgot-password {
  color: black;
  text-decoration: none;
}

.forgot-password:hover,
.forgot-password:active,
.forgot-password:focus {
  transform: scaleX(1.05);
}
</style>
