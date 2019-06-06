<template lang="html">
  <div class="container">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div v-if="AccountData">
        <div class="row">
          <div class="col text-center">
            <h5>Showing Data For Account: {{ Account.accountData.Username }}</h5>
          </div>
        </div>
        <hr>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>New Username</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-user"></i>
                  </span>
                </div>
                <b-input
                  id="NewUsername"
                  name="new username"
                  class="form-control"
                  type="text"
                  ref="NewUsername"
                  v-model="NewUsername"
                  v-validate="'alpha_num|min:6'"
                  :class="{'form-control': true, 'error': errors.has('new username') }"
                  autofocus
                ></b-input>
                <b-tooltip placement="bottom" target="NewUsername">{{ getErrorMsg('new username') }}</b-tooltip>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Confirm New Username</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-user"></i>
                  </span>
                </div>
                <b-input
                  id="NewUsernameConfirm"
                  name="confirm new username"
                  class="form-control"
                  type="text"
                  v-model="NewUsernameConfirm"
                  v-validate="isConfirmUsernameRequired"
                  :class="{'form-control': true, 'error': errors.has('confirm new username') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="NewUsernameConfirm"
                >{{ getErrorMsg('confirm new username') }}</b-tooltip>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>New Password</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock"></i>
                  </span>
                </div>
                <b-input
                  id="NewPassword"
                  name="new password"
                  class="form-control"
                  type="password"
                  ref="NewPassword"
                  v-model="NewPassword"
                  v-validate="'min:8|max:16'"
                  :class="{'form-control': true, 'error': errors.has('new password') }"
                ></b-input>
                <b-tooltip placement="bottom" target="NewPassword">{{ getErrorMsg('new password') }}</b-tooltip>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Confirm New Password</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock"></i>
                  </span>
                </div>
                <b-input
                  id="NewPasswordConfirm"
                  name="confirm new password"
                  class="form-control"
                  type="password"
                  v-model="NewPasswordConfirm"
                  v-validate="isConfirmPasswordRequired"
                  :class="{'form-control': true, 'error': errors.has('confirm new password') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="NewPasswordConfirm"
                >{{ getErrorMsg('confirm new password') }}</b-tooltip>
              </div>
            </div>
          </div>
        </div>
        <div class="form-group">
          <div class="row">
            <div class="col-6">
              <label>Current Password</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock"></i>
                  </span>
                </div>
                <b-input
                  id="CurrentPassword"
                  name="current password"
                  class="form-control"
                  type="password"
                  v-model="CurrentPassword"
                  v-validate="'required|min:8|max:16'"
                  :class="{'form-control': true, 'error': errors.has('current password') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="CurrentPassword"
                >{{ getErrorMsg('current password') }}</b-tooltip>
              </div>
            </div>
            <div class="col">
              <button class="button update-account" @click="UpdateAccount" name="update">
                <i class="fa fa-pencil"></i>
                <span>Update Account</span>
              </button>
            </div>
          </div>
        </div>
        <h5>Account Information:</h5>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <div v-if="Account.accountData.Online == 1">
                <span class="badge badge-pill badge-success">Online</span>
              </div>
              <div v-else>
                <span class="badge badge-pill badge-danger">Offline</span>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>Creation Date</label>
              <b-input type="text" :value="GetDate(Account.accountData.Joindate)" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Login</label>
              <b-input type="text" :value="GetDate(Account.accountData.LastLogin)" disabled></b-input>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>Last Ip</label>
              <b-input type="text" :value="Account.accountData.LastIp" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Attempted Ip</label>
              <b-input type="text" :value="Account.accountData.LastAttemptIp" disabled></b-input>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Muted</label>
                  <b-input
                    type="text"
                    :value="Account.accountData.Mutetime > 0 ? 'Yes' : 'No'"
                    disabled
                  ></b-input>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label>Unmute Date</label>
                  <b-input
                    type="text"
                    :value="Account.accountData.Mutetime > 0 ? new Date(Account.accountData.Mutetime * 1000).toLocaleString() : ''"
                    disabled
                  ></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="Account.accountData.Mutereason" disabled></b-textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row" v-if="Account.banData != null">
          <div class="col-8">
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Banned</label>
                  <b-input type="text" value="Yes" disabled></b-input>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label>Unban Date</label>
                  <b-input
                    type="text"
                    :value="new Date(Account.banData.Unbandate * 1000).toLocaleString()"
                    disabled
                  ></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="Account.banData.Banreason" disabled></b-textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row" v-else>
          <div class="col-8">
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Banned</label>
                  <b-input type="text" value="No" disabled></b-input>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label>Unban Date</label>
                  <b-input disabled></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea disabled></b-textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div v-else>
        <h4>
          Unable to load any account data.
        </h4>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import moment from "moment";

const API_ACCOUNT = process.env.API.ACCOUNT;

export default {
  name: "Account",
  props: ["User"],
  data() {
    return {
      Account: null,
      Account: null,

      NewUsername: "",
      NewUsernameConfirm: "",
      NewPassword: "",
      NewPasswordConfirm: "",
      CurrentPassword: "",

      Loading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {
    isConfirmUsernameRequired() {
      return this.NewUsername.length
        ? "required|confirmed:NewUsername"
        : "confirmed:NewUsername";
    },
    isConfirmPasswordRequired() {
      return this.NewPassword.length
        ? "required|confirmed:NewPassword"
        : "confirmed:NewPassword";
    },
    AccountData() {
      return this.Account != null && this.Account.accountData != null;
    }
  },
  methods: {
    OnSelectionChange() {
      this.NewUsername = "";
      this.NewUsernameConfirm = "";
      this.NewPassword = "";
      this.NewPasswordConfirm = "";
      this.CurrentPassword = "";
      this.errors.clear();
    },
    async GetAccountData() {
      this.Loading = true;
      this.Account = null;
      let result;
      try {
        result = await this.$http.get(`${API_ACCOUNT}/data`);
      } catch (err) {
        if (err.response) {
          this.$toasted.error(err.response.data.message);
        } else {
          this.$toasted.error(err.message);
        }
      }

      return result.data;
    },
    async isFormValid() {
      const result = await this.$validator.validateAll();
      return result;
    },
    async UpdateAccount() {
      const formValid = await this.isFormValid();
      if (!formValid) {
        return;
      }

      const Id = parseInt(this.Account.accountData.Id);
      const CurrentUsername = this.Account.accountData.Username;
      const { NewUsername, NewPassword, CurrentPassword } = this;

      this.Loading = true;

      try {
        const result = await this.$http.post(`${API_ACCOUNT}/update`, {
          Id,
          NewUsername,
          NewPassword,
          CurrentUsername,
          CurrentPassword
        });
        this.$toasted.success(`Success! ${result.data} has been updated!`);
        this.Account.accountData.Username = result.data;
      } catch (err) {
        if (err.response) {
          this.$toasted.error(err.response.data.message);
        } else {
          this.$toasted.error(err.message);
        }
      } finally {
        this.Loading = false;
        this.OnSelectionChange();
      }
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  created() {
    this.GetAccountData()
      .then(result => (this.Account = result))
      .finally(() => {
        this.Loading = false;
        this.OnSelectionChange();
      });
  },
  mounted() {
    this.$root.$on("refreshAccounts", () => {
      this.GetAccountData()
        .then(result => (this.Account = result))
        .finally(() => {
          this.Loading = false;
          this.OnSelectionChange();
        });
    });
  }
};
</script>

<style scoped>
#account-list {
  text-align: center;
  font-weight: bold;
}

#atom-spinner {
  margin-top: 40%;
}

.badge {
  margin-top: 5px;
  width: 100%;
}

textarea {
  resize: vertical;
  max-height: 200px;
}

button {
  margin-top: 8%;
}
</style>
