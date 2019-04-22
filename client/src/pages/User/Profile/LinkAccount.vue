<template>
  <div class="container justify-content-center">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <p>
        If you have an old account on our server, or simply wish to take over the ownership of an account, write the ingame username and password here to link it.
        <br><br>An ingame account can only be linked to 1 website account.
      </p>
      <form @submit.prevent="ChangePassword()">
        <div class="form-group">
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <i class="fa fa-lock fa-fw"></i>
              </span>
            </div>
            <b-input
              id="Username"
              name="Username"
              class="form-control"
              placeholder="Ingame Username"
              type="text"
              v-model="Username"
              v-validate="'required|alpha_num|min:5'"
              :class="{'form-control': true, 'error': errors.has('Username') }"
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
              id="Password"
              name="Password"
              class="form-control"
              placeholder="Ingame Password"
              type="password"
              v-model="Password"
              v-validate="'required|alpha_dash|min:4'"
              ref="Password"
              :class="{'form-control': true, 'error': errors.has('Password') }"
            ></b-input>
            <b-tooltip placement="bottom" target="Password">{{ getErrorMsg('Password') }}</b-tooltip>
          </div>
        </div>
        <div class="form-group">
          <button type="submit" class="btn btn-signin btn-primary btn-block">Link Account</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import config from "@/config";

const API_ACCOUNT = config.API.ACCOUNT;

export default {
  props: ["User"],
  data() {
    return {
      Username: "",
      Password: "",

      Loading: false
    };
  },
  methods: {
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async ChangePassword() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      this.Loading = true;

      try {
        const { Username, Password } = this;
        const result = await this.$http.post(`${API_ACCOUNT}/link/account`, {
          Id: 0,
          Username,
          Password
        });
        this.$toasted.success(
          `Success! You have linked ${Username} to your list of accounts`
        );
      } catch (err) {
        if (err.response) {
          this.$toasted.error(err.response.data.message);
        } else {
          this.$toasted.error(err.message);
        }
      } finally {
        this.Loading = false;
      }
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  }
};
</script>

<style scoped>
#atom-spinner {
  margin-top: 40%;
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
</style>
