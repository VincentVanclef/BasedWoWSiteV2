<template lang="html">
  <div class="container justify-content-center">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="200" :color="'#7289da'"/>
    </div>
    <div v-else>
      <form @submit.prevent="ChangePassword()">
        <div class="form-group">
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <i class="fa fa-lock fa-fw"></i>
              </span>
            </div>
            <b-input
              id="CurrentPassword"
              name="Current Password"
              class="form-control"
              placeholder="Current Password"
              type="password"
              v-model="CurrentPassword"
              v-validate="'required|alpha_dash|min:8'"
              :class="{'form-control': true, 'error': errors.has('Current Password') }"
            ></b-input>
            <b-tooltip
              placement="bottom"
              target="CurrentPassword"
            >{{ getErrorMsg('Current Password') }}</b-tooltip>
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
              placeholder="New Password"
              type="password"
              v-model="NewPassword"
              v-validate="'required|alpha_dash|min:8'"
              ref="Password"
              :class="{'form-control': true, 'error': errors.has('Password') }"
            ></b-input>
            <b-tooltip placement="bottom" target="Password">{{ getErrorMsg('Password') }}</b-tooltip>
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
              id="PasswordConfirm"
              name="Confirm New Password"
              class="form-control"
              placeholder="Confirm Password"
              type="password"
              v-model="NewPasswordAgain"
              v-validate="'required|confirmed:Password'"
              :class="{'form-control': true, 'error': errors.has('Confirm Password') }"
            ></b-input>
            <b-tooltip
              placement="bottom"
              target="PasswordConfirm"
            >{{ getErrorMsg('Confirm Password') }}</b-tooltip>
          </div>
        </div>
        <div class="form-group">
          <button type="submit" class="btn btn-signin btn-primary btn-block">Change Password</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_AUTH = process.env.API.AUTH;

export default {
  props: ["User"],
  data() {
    return {
      CurrentPassword: "",
      NewPassword: "",
      NewPasswordAgain: "",

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

      try {
        await this.$dialog.confirm("Continue changing website password?");
      } catch (e) {
        return;
      }

      this.Loading = true;

      try {
        const { CurrentPassword, NewPassword, NewPasswordAgain } = this;
        const result = await this.$http.post(`${API_AUTH}/ChangePassword`, {
          CurrentPassword,
          NewPassword,
          NewPasswordAgain
        });
        this.$toasted.success("Success! Website Password has been changed");
        this.CurrentPassword = "";
        this.NewPassword = "";
        this.NewPasswordAgain = "";
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
