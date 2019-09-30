<template>
  <div class="container">
    <div class="d-flex justify-content-center" v-if="Loading" id="atom-spinner">
      <semipolar-spinner :animation-duration="2000" :size="200" :color="'#7289da'" />
    </div>
    <div v-else>
      <div v-if="AccountData">
        <div class="row">
          <div class="col text-center">
            <h5>Showing Data For Account: {{ AccountData.username }}</h5>
          </div>
        </div>
        <hr />

        <h5 class="mb-3">Account Tools:</h5>
        <div class="form-group text-center">
          <b-row>
            <b-col>
              <button
                class="btn btn-dark btn-block"
                type="submit"
                @click="OpenChangeUsernameModal()"
              >
                <i class="fa fa-user fa-fw"></i> Change Username
              </button>
            </b-col>
            <b-col>
              <button
                class="btn btn-dark btn-block"
                type="submit"
                @click="OpenChangePasswordModal()"
              >
                <i class="fa fa-lock fa-fw"></i> Change Password
              </button>
            </b-col>
          </b-row>
        </div>

        <!-- USERNAME MODAL -->
        <b-modal
          id="update-username-modal"
          centered
          v-if="ShowUsernameEditor"
          v-model="ShowUsernameEditor"
          title="Change Username"
          ok-title="Change Username"
          header-bg-variant="info"
          @ok="UpdateUsername"
        >
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
                autocomplete="new-username"
                v-validate="'required|alpha_num|min:6'"
                :class="{'form-control': true, 'error': errors.has('new username') }"
                autofocus
              ></b-input>
              <b-tooltip placement="bottom" target="NewUsername">{{ getErrorMsg('new username') }}</b-tooltip>
            </div>
          </div>

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
                autocomplete="new-username"
                v-validate="'required|confirmed:NewUsername'"
                :class="{'form-control': true, 'error': errors.has('confirm new username') }"
              ></b-input>
              <b-tooltip
                placement="bottom"
                target="NewUsernameConfirm"
              >{{ getErrorMsg('confirm new username') }}</b-tooltip>
            </div>
          </div>

          <div class="form-group">
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
                autocomplete="new-password"
                v-validate="'required|min:8|max:16'"
                :class="{'form-control': true, 'error': errors.has('current password') }"
              ></b-input>
              <b-tooltip
                placement="bottom"
                target="CurrentPassword"
              >{{ getErrorMsg('current password') }}</b-tooltip>
            </div>
          </div>
        </b-modal>

        <!-- PASSWORD MODAL -->
        <b-modal
          id="update-password-modal"
          centered
          v-if="ShowPasswordEditor"
          v-model="ShowPasswordEditor"
          title="Change Password"
          ok-title="Change Password"
          header-bg-variant="info"
          @ok="UpdatePassword"
        >
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
                autocomplete="new-password"
                v-validate="'required|min:8|max:16'"
                :class="{'form-control': true, 'error': errors.has('new password') }"
              ></b-input>
              <b-tooltip placement="bottom" target="NewPassword">{{ getErrorMsg('new password') }}</b-tooltip>
            </div>
          </div>

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
                autocomplete="new-password"
                v-validate="'required|confirmed:NewPassword'"
                :class="{'form-control': true, 'error': errors.has('confirm new password') }"
              ></b-input>
              <b-tooltip
                placement="bottom"
                target="NewPasswordConfirm"
              >{{ getErrorMsg('confirm new password') }}</b-tooltip>
            </div>
          </div>

          <div class="form-group">
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
                autocomplete="new-password"
                v-validate="'required|min:8|max:16'"
                :class="{'form-control': true, 'error': errors.has('current password') }"
              ></b-input>
              <b-tooltip
                placement="bottom"
                target="CurrentPassword"
              >{{ getErrorMsg('current password') }}</b-tooltip>
            </div>
          </div>
        </b-modal>

        <h5>Account Information:</h5>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <div v-if="AccountData.online == 1">
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
              <b-input type="text" :value="GetDate(AccountData.joinDate)" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Login</label>
              <b-input type="text" :value="GetDate(AccountData.lastLogin)" disabled></b-input>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col">
            <div class="form-group">
              <label>Last Ip</label>
              <b-input type="text" :value="AccountData.lastIp" disabled></b-input>
            </div>
          </div>
          <div class="col">
            <div class="form-group">
              <label>Last Attempted Ip</label>
              <b-input type="text" :value="AccountData.lastAttemptIp" disabled></b-input>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Muted</label>
                  <b-input type="text" :value="AccountData.muteTime === 0 ? 'No' : 'Yes'" disabled></b-input>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label>Unmute Date</label>
                  <b-input type="text" :value="GetUnmuteDate(AccountData.muteTime)" disabled></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="AccountData.muteReason" disabled></b-textarea>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row" v-if="BanData != null">
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
                  <b-input type="text" :value="GetDate(BanData.unbanDate)" disabled></b-input>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col">
                <div class="form-group">
                  <label>Reason</label>
                  <b-textarea type="text" :value="BanData.banReason" disabled></b-textarea>
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
        <h4>Unable to load any account data.</h4>
      </div>
    </div>
  </div>
</template>

<script>
import { SemipolarSpinner } from "epic-spinners";
import moment from "moment";

export default {
  name: "Account",
  props: ["user"],
  data() {
    return {
      /* USERNAME */
      ShowUsernameEditor: false,
      NewUsername: "",
      NewUsernameConfirm: "",

      /* PASSWORD */
      ShowPasswordEditor: false,
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
    AccountData() {
      return this.$store.getters["user/account/GetAccountData"];
    },
    BanData() {
      return this.AccountData.accountBanned.find(x => x.active === 1);
    }
  },
  methods: {
    ResetForm() {
      this.NewUsername = "";
      this.NewUsernameConfirm = "";
      this.NewPassword = "";
      this.NewPasswordConfirm = "";
      this.CurrentPassword = "";
    },
    OpenChangeUsernameModal() {
      this.ResetForm();
      this.ShowUsernameEditor = true;
    },
    OpenChangePasswordModal() {
      this.ResetForm();
      this.ShowPasswordEditor = true;
    },
    UpdateUsername(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          const Id = parseInt(this.AccountData.id);
          const CurrentUsername = this.AccountData.username;
          const { NewUsername, NewPassword, CurrentPassword } = this;

          this.$store
            .dispatch("user/account/UpdateUsername", {
              Id,
              NewUsername,
              NewPassword,
              CurrentUsername,
              CurrentPassword
            })
            .then(res => {
              this.$bvToast.toast(`${res.data} has been updated!`, {
                  title: "Success",
                  variant: "success",
                  solid: true
              });
              this.$bvModal.hide("update-username-modal");
            });
        }
      });
    },
    UpdatePassword(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          const Id = parseInt(this.AccountData.id);
          const CurrentUsername = this.AccountData.username;
          const { NewUsername, NewPassword, CurrentPassword } = this;

          this.$store
            .dispatch("user/account/UpdatePassword", {
              Id,
              NewUsername,
              NewPassword,
              CurrentUsername,
              CurrentPassword
            })
            .then(res => {
                this.bvToast.toast(`${res.data} has been updated!`, {
                    title: "Success",
                    variant: "success",
                    solid: true
                });
              this.$bvModal.hide("update-password-modal");
            });
        }
      });
    },
    async GetAccountData() {
      this.Loading = true;
      try {
        await this.$store.dispatch("user/account/GetAccountData");
      } finally {
        this.Loading = false;
      }
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetUnmuteDate(time) {
      if (time === 0) return;
      let unmuteDate;
      const now = moment().unix() * 1000;
      if (time < 0) {
        const then = Math.abs(time) * 1000;
        unmuteDate = moment(now + then).format("MMMM Do YYYY, HH:mm:ss");
      } else {
        unmuteDate = moment(time * 1000).format("MMMM Do YYYY, HH:mm:ss");
      }
      return unmuteDate;
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  },
  created() {
    this.GetAccountData();
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
  min-height: 100px;
  max-height: 300px;
}
</style>
