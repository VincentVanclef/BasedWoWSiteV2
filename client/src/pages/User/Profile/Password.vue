<template lang="html">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="200" :color="'#7289da'"/>
    </div>
    <b-container v-else>
      <b-card
      header="This is the password used to login to the Titans League website."
      header-text-variant="dark"
      footer-tag="footer"
      align="center">
        <div class="form-group">
          <div class="input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <i class="fa fa-lock fa-fw"></i>
              </span>
            </div>
            <b-input
              id="currentpassword"
              name="current password"
              placeholder="Current password"
              type="password"
              v-model="CurrentPassword"
              v-validate="'required|min:8|max:30'"
              :class="{'form-control': true, 'error': errors.has('current password') }"
            ></b-input>
            <b-tooltip
              placement="bottom"
              target="currentpassword"
            >{{ getErrorMsg('current password') }}</b-tooltip>
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
              id="password"
              name="password"
              placeholder="New password"
              type="password"
              v-model="NewPassword"
              v-validate="'required|alpha_dash|min:8'"
              ref="Password"
              :class="{'form-control': true, 'error': errors.has('password') }"
            ></b-input>
            <b-tooltip placement="bottom" target="password">{{ getErrorMsg('password') }}</b-tooltip>
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
              id="passwordconfirm"
              name="confirm password"
              placeholder="Confirm password"
              type="password"
              v-model="NewPasswordAgain"
              v-validate="'required|confirmed:password'"
              :class="{'form-control': true, 'error': errors.has('confirm password') }"
            ></b-input>
            <b-tooltip
              placement="bottom"
              target="passwordconfirm"
            >{{ getErrorMsg('confirm password') }}</b-tooltip>
          </div>
        </div>
        <div slot="footer">
          <b-button block variant="primary" class="font-weight-bold" @click="ChangePassword()"><i class="fa fa-lock"></i> Change Password</b-button>
        </div>
      </b-card>
    </b-container>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";

const API_AUTH = process.env.API.AUTH;

export default {
  props: ["user"],
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
      } catch (e) {
        this.$toasted.error(this.$root.GetErrorMessage(e));
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
