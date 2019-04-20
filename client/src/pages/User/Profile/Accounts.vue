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
          <select id="account-list" class="form-control" v-model="SelectedAccount">
            <option v-for="acc in Accounts" :key="acc.id" :value="acc">{{ acc.username }}</option>
          </select>
        </div>
        <hr>
        <form @submit.prevent="UpdateAccount">
          <div class="row">
            <div class="col">
              <div class="form-group">
                <label>Username</label>
                <input
                  type="text"
                  :placeholder="SelectedAccount.username"
                  v-model="SelectedAccount.username"
                  v-validate="'required|min:8'"
                  name="username"
                  :class="{'form-control': true, 'error': errors.has('username') }"
                >
                <span
                  class="small text-danger"
                  v-for="error in errors.collect('username')"
                  :key="error.id"
                >{{ error }}</span>
              </div>
            </div>
            <div class="col">
              <div class="form-group">
                <label>Created Date</label>
                <input
                  type="password"
                  :placeholder="GetDate(SelectedAccount.joindate)"
                  v-validate="'required|min:8'"
                  name="password"
                  disabled
                  class="form-control"
                >
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

const API_USER = config.API.USER;

export default {
  name: "Accounts",
  props: ["User"],
  data() {
    return {
      Accounts: [],
      SelectedAccount: null,

      Loading: false
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner
  },
  methods: {
    async GetAccountData() {
      this.Loading = true;
      try {
        const result = await this.$http.get(`${API_USER}/accountdata`);
        for (const acc of result.data) {
          this.Accounts.push(acc);
        }
      } catch (err) {
        console.log(err);
      }
    },
    UpdateAccount() {
      alert("test");
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
    }
  },
  created() {
    this.User = this.$store.getters.user;

    this.GetAccountData()
      .then(() => (this.SelectedAccount = this.Accounts[0]))
      .finally(() => (this.Loading = false));
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
