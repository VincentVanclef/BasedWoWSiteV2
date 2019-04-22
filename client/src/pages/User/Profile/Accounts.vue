<template>
  <div class="container">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div v-if="Accounts.length > 0">
        <div class="row">
          <div class="col-6 text-left">
            <label>Selected Account:</label>
          </div>
          <div class="col-6 text-right">
            Total Accounts: {{ Accounts.length }}
          </div>
        </div>
        <div class="row">
          <div class="col">
            <select
              id="account-list"
              class="form-control"
              v-model="SelectedAccount"
              @change="OnSelectionChange()"
            >
              <option
                v-for="acc in Accounts"
                :key="acc.accountData.Id"
                :value="acc"
              >{{ acc.accountData.Username }}</option>
            </select>
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
                    <i class="fa fa-user fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="NewUsername"
                  name="NewUsername"
                  class="form-control"
                  type="text"
                  ref="NewUsername"
                  v-model="NewUsername"
                  v-validate="'alpha_num|min:6'"
                  :class="{'form-control': true, 'error': errors.has('NewUsername') }"
                  autofocus
                ></b-input>
                <b-tooltip placement="bottom" target="NewUsername">{{ getErrorMsg('NewUsername') }}</b-tooltip>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Confirm New Username</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-user fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="NewUsernameConfirm"
                  name="confirm username"
                  class="form-control"
                  type="text"
                  v-model="NewUsernameConfirm"
                  v-validate="isConfirmUsernameRequired"
                  :class="{'form-control': true, 'error': errors.has('confirm username') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="NewUsernameConfirm"
                >{{ getErrorMsg('confirm username') }}</b-tooltip>
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
                    <i class="fa fa-lock fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="NewPassword"
                  name="NewPassword"
                  class="form-control"
                  type="password"
                  ref="NewPassword"
                  v-model="NewPassword"
                  v-validate="'min:8'"
                  :class="{'form-control': true, 'error': errors.has('NewPassword') }"
                ></b-input>
                <b-tooltip placement="bottom" target="NewPassword">{{ getErrorMsg('NewPassword') }}</b-tooltip>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Confirm New Password</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">
                    <i class="fa fa-lock fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="NewPasswordConfirm"
                  name="confirm password"
                  class="form-control"
                  type="password"
                  v-model="NewPasswordConfirm"
                  v-validate="isConfirmPasswordRequired"
                  :class="{'form-control': true, 'error': errors.has('confirm password') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="NewPasswordConfirm"
                >{{ getErrorMsg('confirm password') }}</b-tooltip>
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
                    <i class="fa fa-lock fa-fw"></i>
                  </span>
                </div>
                <b-input
                  id="CurrentPassword"
                  name="current password"
                  class="form-control"
                  type="password"
                  v-model="CurrentPassword"
                  v-validate="'required|alpha_num|min:6'"
                  :class="{'form-control': true, 'error': errors.has('current password') }"
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="CurrentPassword"
                >{{ getErrorMsg('current password') }}</b-tooltip>
              </div>
            </div>
            <div class="col">
              <button class="button" @click="UpdateAccount" name="update">
                <i class="fa fa-user"></i>
                <span>Update Account</span>
              </button>
            </div>
            <div class="col">
              <button class="button" @click="UnlinkAccount" name="unlink">
                <i class="fa fa-trash"></i>
                <span>Unlink Account</span>
              </button>
            </div>
          </div>
        </div>
        <h5>Account Information:</h5>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <div v-if="SelectedAccount.accountData.Online == 1">
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
              <b-input type="text" :value="GetDate(SelectedAccount.accountData.Joindate)" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Login</label>
              <b-input type="text" :value="GetDate(SelectedAccount.accountData.LastLogin)" disabled></b-input>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>Last Ip</label>
              <b-input type="text" :value="SelectedAccount.accountData.LastIp" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Attempted Ip</label>
              <b-input type="text" :value="SelectedAccount.accountData.LastAttemptIp" disabled></b-input>
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
                    :value="SelectedAccount.accountData.Mutetime > 0 ? 'Yes' : 'No'"
                    disabled
                  ></b-input>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label>Unmute Date</label>
                  <b-input
                    type="text"
                    :value="SelectedAccount.accountData.Mutetime > 0 ? new Date(SelectedAccount.accountData.Mutetime * 1000).toLocaleString() : ''"
                    disabled
                  ></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="SelectedAccount.accountData.Mutereason" disabled></b-textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row" v-if="SelectedAccount.banData != null">
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
                    :value="new Date(SelectedAccount.banData.Unbandate * 1000).toLocaleString()"
                    disabled
                  ></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="SelectedAccount.banData.Banreason" disabled></b-textarea>
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
          <router-link to="/user/create/account">Create</router-link>a new account?
        </h4>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import config from "@/config";

const API_ACCOUNT = config.API.ACCOUNT;

export default {
  name: "Accounts",
  props: ["User"],
  data() {
    return {
      Accounts: [],
      SelectedAccount: null,

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
          return this.NewUsername.length ? 'required|confirmed:NewUsername' : 'confirmed:NewUsername';
      },
      isConfirmPasswordRequired() {
          return this.NewPassword.length ? 'required|confirmed:NewPassword' : 'confirmed:NewPassword';
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
      this.Accounts = [];
      try {
        const result = await this.$http.get(`${API_ACCOUNT}/data`);
        for (const acc of result.data) {
          this.Accounts.push(JSON.parse(acc));
        }
      } catch (err) {
        if (err.response) {
          this.$toasted.error(err.response.data.message);
        } else {
          this.$toasted.error(err.message);
        }
      }
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

      if (this.NewUsername == "" && this.NewPassword == "") {
          this.$toasted.error("A new username or password (or both) is required to update an account");
          return;
      }

      const Id = parseInt(this.SelectedAccount.accountData.Id);
      const CurrentUsername = this.SelectedAccount.accountData.Username;
      const { NewUsername, NewPassword, CurrentPassword } = this;
    
      if (NewPassword == null) {
          alert("yes")
      }
      this.Loading = true;

      try {
        const result = await this.$http.post(`${API_ACCOUNT}/update`, {
          Id,
          NewUsername,
          NewUsername,
          CurrentUsername,
          CurrentPassword
        });
        this.$toasted.success(`Success! ${result.data} has been updated!`);
        this.SelectedAccount.accountData.Username = result.data;
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
    async UnlinkAccount() {
      try {
        await this.$dialog.confirm(
          "Are you sure you wish to unlink this account?"
        );
      } catch (e) {
        return;
      }

      this.Loading = true;
      try {
        const id = parseInt(this.SelectedAccount.accountData.Id);
        const result = await this.$http.delete(`${API_ACCOUNT}/delete/${id}`);
        this.$toasted.success(
          `Success! ${
            this.SelectedAccount.accountData.Username
          } has been unlinked from your account`
        );

        const index = this.Accounts.indexOf(this.SelectedAccount);
        if (index >= 0) {
          this.Accounts.splice(index, 1);
        }
        if (this.Accounts.length > 0) {
          this.SelectedAccount = this.Accounts[0];
          this.OnSelectionChange();
        }
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
    GetDate(date) {
      const options = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
        second: "numeric"
      };
      const newdate = new Date(date);
      return new Intl.DateTimeFormat("it-IT", options).format(newdate);
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  created() {
    this.GetAccountData()
      .then(() => (this.SelectedAccount = this.Accounts[0]))
      .finally(() => {
        this.Loading = false;
        this.OnSelectionChange();
      });
  },
  mounted() {
    this.$root.$on("refreshAccounts", () => {
      this.GetAccountData()
        .then(() => (this.SelectedAccount = this.Accounts[0]))
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
  font-size: 20px;
}

textarea {
  resize: none;
}

button {
  margin-top: 31px;
}
</style>
