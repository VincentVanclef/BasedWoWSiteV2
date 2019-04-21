<template>
  <div class="container">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="3000" :size="250" :color="'#7289da'"/>
    </div>
    <div v-else>
      <div v-if="Accounts.length > 0">
        <div class="row">
          <h5>
            Total Ingame Accounts:
            <strong>{{ Accounts.length }}</strong>
          </h5>
        </div>
        <div class="row">
          <label>Selected Account:</label>
          <select
            id="account-list"
            class="form-control"
            v-model="SelectedAccount"
            @change="OnSelectionChange"
          >
            <option
              v-for="acc in Accounts"
              :key="acc.accountData.Id"
              :value="acc"
            >{{ acc.accountData.Username }}</option>
          </select>
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
                  id="inputUsername"
                  name="username"
                  class="form-control"
                  type="text"
                  ref="username"
                  v-model="Username"
                  v-validate="'alpha_num|min:6'"
                  :class="{'form-control': true, 'error': errors.has('username') }"
                  autofocus
                ></b-input>
                <b-tooltip placement="bottom" target="inputUsername">{{ getErrorMsg('username') }}</b-tooltip>
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
                  id="inputUsernameConfirm"
                  name="confirm username"
                  class="form-control"
                  type="text"
                  v-model="UsernameConfirm"
                  v-validate="'confirmed:username'"
                  :class="{'form-control': true, 'error': errors.has('confirm username') }"
                  autofocus
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="inputUsernameConfirm"
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
                  id="inputPassword"
                  name="password"
                  class="form-control"
                  type="password"
                  ref="password"
                  value="********"
                  v-model="Password"
                  v-validate="'min:8'"
                  :class="{'form-control': true, 'error': errors.has('password') }"
                  autofocus
                ></b-input>
                <b-tooltip placement="bottom" target="inputPassword">{{ getErrorMsg('password') }}</b-tooltip>
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
                  id="inputPasswordConfirm"
                  name="confirm password"
                  class="form-control"
                  type="password"
                  v-model="PasswordConfirm"
                  v-validate="'confirmed:password'"
                  :class="{'form-control': true, 'error': errors.has('confirm password') }"
                  autofocus
                ></b-input>
                <b-tooltip
                  placement="bottom"
                  target="inputPasswordConfirm"
                >{{ getErrorMsg('confirm password') }}</b-tooltip>
              </div>
            </div>
          </div>
        </div>
        <div class="form-group">
          <button class="button" @click="UpdateAccount" name="update">
            <i class="fa fa-user"></i>
            <span>Update Account</span>
          </button>
          <button class="button" @click="UnlinkAccount" name="unlink">
            <i class="fa fa-trash"></i>
            <span>Unlink Account</span>
          </button>
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
          <router-link to="/user/create/account">Create</router-link> a new account?
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

      Username: "",
      UsernameConfirm: "",
      Password: "",
      PasswordConfirm: "",

      Loading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  computed: {},
  methods: {
    OnSelectionChange() {
      this.Username = "";
      this.UsernameConfirm = "";
      this.Password = "";
      this.PasswordConfirm = "";
    },
    async GetAccountData() {
      this.Loading = true;
      try {
        const result = await this.$http.get(`${API_ACCOUNT}/data`);
        for (const acc of result.data) {
          this.Accounts.push(JSON.parse(acc));
        }
      } catch (err) {
        console.log(err);
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

      const Id = parseInt(this.SelectedAccount.accountData.Id);
      const { Username, Password } = this;

      if (Username.length < 6 && Password.length < 8) {
        this.$toasted.error(
          "You must specify either a new username or a new password (or both) to update your account"
        );
        return;
      }

      this.Loading = true;

      try {
        const result = await this.$http.post(`${API_ACCOUNT}/update`, {
          Id,
          Username,
          Password
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
  mounted() {}
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
</style>
