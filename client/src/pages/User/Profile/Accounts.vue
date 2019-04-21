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
            <option v-for="acc in Accounts" :key="acc.id" :value="acc">{{ acc.username }}</option>
          </select>
        </div>
        <hr>
        <form @submit.prevent="UpdateAccount">
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
            <button class="button">
              <i class="fa fa-user"></i>
              <span>Update Account</span>
            </button>
          </div>
        </form>
      </div>
      <div v-else>
        <h4>Unable to load any account data.</h4>
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
  computed: {
  },
  methods: {
    OnSelectionChange() {
      this.Username = ""
      this.UsernameConfirm = ""
      this.Password = ""
      this.PasswordConfirm = ""
    },
    async GetAccountData() {
      this.Loading = true;
      try {
        const result = await this.$http.get(`${API_ACCOUNT}/data`);
        for (const acc of result.data) {
          this.Accounts.push(acc);
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

      const Id = parseInt(this.SelectedAccount.id)
      const { Username, Password } = this

      if (Username.length < 6 && Password.length < 8) {
          this.$toasted.error("You must specify either a new username or a new password (or both) to update your account")
          return;
      }

      this.Loading = true;

      try {
        const result = await this.$http.post(`${API_ACCOUNT}/update`, { Id, Username, Password });
        this.$toasted.success(`Success! ${this.SelectedAccount.username} has been updated!`);
        this.SelectedAccount.username = Username
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
    this.User = this.$store.getters.user;

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
</style>
