<template lang="html">
  <div class="container">
    <div class="profile">
      <b-row>
        <b-col cols="3">
          <div class="gravatar">
            <router-link to="/user/profile/gravatar">
              <vue-gravatar
                class="gravatar-image"
                :email="user.email"
                alt="Gravatar"
                default-img="https://i.imgur.com/0AwrvCm.jpg"
              />
            </router-link>
          </div>
        </b-col>
        <b-col cols="9" class="user-information">
          <p>User Information</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/user.png')" title="Name displayed on the site">
            </b-col>
            <b-col cols="3">Nickname</b-col>
            <div v-if="UsernameLoading">
              <epic-spinner
                  :animation-duration="1500"
                  :size="50"
                  :color="'#7289da'"
                />
            </div>
            <b-col cols="3" v-if="!UsernameLoading">
              <div class="player-nickname" v-if="!UsernameInput">{{ user.username }}</div>
              <div v-else>
                <input
                  id="edit-nickname"
                  name="new nickname"
                  type="text"
                  class="profile-update-input form-control"
                  v-model="Username"
                  v-validate="'required|alpha|min:2|max:15'"
                  :class="{'form-control': true, 'error': errors.has('new nickname') }"
                  placeholder="New nickname"
                >
                <b-tooltip
                  placement="bottom"
                  target="edit-nickname"
                >{{ getErrorMsg('new nickname') }}</b-tooltip>
              </div>
            </b-col>
            <b-col cols="2" v-if="!UsernameLoading">
              <div v-if="!UsernameInput">
                <button class="profile-update-button" @click="UsernameInput = true; Username = ''">
                  <img :src="require('@/assets/images/pencil.png')" title="Edit Profile">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="profile-update-button" @click="UpdateUsername()">
                    <i class="fa fa-check-circle fa-fw" title="Save Changes"></i>
                  </button>
                  <button class="profile-update-button" @click="UsernameInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/user.png')" title="Firstname">
            </b-col>
            <b-col cols="3">Firstname</b-col>
            <div v-if="NameLoading">
              <epic-spinner
                  :animation-duration="1500"
                  :size="50"
                  :color="'#7289da'"
                />
            </div>
            <b-col cols="3" v-if="!NameLoading">
              <div class="player-nickname" v-if="!NameInput">{{ user.firstname }}</div>
              <div v-else>
                <input
                  id="edit-firstname"
                  name="new firstname"
                  type="text"
                  class="profile-update-input form-control"
                  v-model="Firstname"
                  v-validate="'required|alpha|min:2|max:15'"
                  :class="{'form-control': true, 'error': errors.has('new firstname') }"
                  placeholder="New firstname"
                >
                <b-tooltip
                  placement="bottom"
                  target="edit-firstname"
                >{{ getErrorMsg('new firstname') }}</b-tooltip>
              </div>
            </b-col>
            <b-col cols="2" v-if="!NameLoading">
              <div v-if="!NameInput">
                <button class="profile-update-button" @click="NameInput = true; Firstname = ''">
                  <img :src="require('@/assets/images/pencil.png')" title="Edit Profile">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="profile-update-button" @click="UpdateName()">
                    <i class="fa fa-check-circle fa-fw" title="Save Changes"></i>
                  </button>
                  <button class="profile-update-button" @click="NameInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/user.png')" title="Firstname">
            </b-col>
            <b-col cols="3">Lastname</b-col>
            <div v-if="LastLoading">
              <epic-spinner
                  :animation-duration="1500"
                  :size="50"
                  :color="'#7289da'"
                />
            </div>
            <b-col cols="3" v-if="!LastLoading">
              <div class="player-nickname" v-if="!LastInput">{{ user.lastname }}</div>
              <div v-else>
                <input
                  id="edit-lastname"
                  name="new lastname"
                  type="text"
                  class="profile-update-input form-control"
                  v-model="Lastname"
                  v-validate="'required|alpha|min:2|max:30'"
                  :class="{'form-control': true, 'error': errors.has('new lastname') }"
                  placeholder="New lastname"
                >
                <b-tooltip
                  placement="bottom"
                  target="edit-lastname"
                >{{ getErrorMsg('new lastname') }}</b-tooltip>
              </div>
            </b-col>
            <b-col cols="2" v-if="!LastLoading">
              <div v-if="!LastInput">
                <button class="profile-update-button" @click="LastInput = true; Lastname = ''">
                  <img :src="require('@/assets/images/pencil.png')" title="Edit Profile">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="profile-update-button" @click="UpdateLastName()">
                    <i class="fa fa-check-circle fa-fw" title="Save Changes"></i>
                  </button>
                  <button class="profile-update-button" @click="LastInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/world.png')" title="Firstname">
            </b-col>
            <b-col cols="3">Location</b-col>
            <div v-if="LocLoading">
              <epic-spinner
                  :animation-duration="1500"
                  :size="50"
                  :color="'#7289da'"
                />
            </div>
            <b-col cols="3" v-if="!LocLoading">
              <div :class="user.location ? 'player-nickname' : ''" v-if="!LocInput">{{ user.location ? user.location : "Unknown" }}</div>
              <div v-else>
                <input
                  id="edit-location"
                  name="new location"
                  type="text"
                  class="profile-update-input form-control"
                  v-model="Location"
                  v-validate="'required|alpha|min:2|max:30'"
                  :class="{'form-control': true, 'error': errors.has('new location') }"
                  placeholder="New location"
                >
                <b-tooltip
                  placement="bottom"
                  target="edit-location"
                >{{ getErrorMsg('new location') }}</b-tooltip>
              </div>
            </b-col>
            <b-col cols="2" v-if="!LocLoading">
              <div v-if="!LocInput">
                <button class="profile-update-button" @click="LocInput = true; Location = ''">
                  <img :src="require('@/assets/images/pencil.png')" title="Edit Location">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="profile-update-button" @click="UpdateLocation()">
                    <i class="fa fa-check-circle fa-fw" title="Save Changes"></i>
                  </button>
                  <button class="profile-update-button" @click="LocInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/mail-small.png')" title="Email">
            </b-col>
            <b-col cols="3">Email</b-col>
            <b-col cols="6">
              <div class="text-color-purple">{{ user.email }}</div>
            </b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/rank.png')">
            </b-col>
            <b-col cols="3">Website Roles</b-col>
            <b-col><span v-for="role in user.roles" :key="role.id"><font :color="GetRoleColor(role)">[{{role}}] </font></span></b-col>
          </b-row>
          <p>Account Information</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/expansion.png')">
            </b-col>
            <b-col cols="3">Expansion</b-col>
            <b-col cols="5">
              <img :src="require('@/assets/images/Wrath-Logo-Small.png')">
            </b-col>
          </b-row>

          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/shield.png')">
            </b-col>
            <b-col cols="3">Account Status</b-col>
            <b-col class="text-success">Active</b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/date.png')">
            </b-col>
            <b-col cols="3">Join Date</b-col>
            <b-col>{{ GetDate(user.joinDate) }}</b-col>
          </b-row>
          <p>Account Miscellaneous</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/lightning.png')" title="Vote Points">
            </b-col>
            <b-col cols="3">Vote Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ user.vp }}</strong></b-col>
            <b-col cols="1">
              <router-link to="/user/vote">
                <i class="fa fa-arrow-circle-right fa-fw" title="Vote Panel"></i>
              </router-link>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" :src="require('@/assets/images/coins.png')" title="Donation Points">
            </b-col>
            <b-col cols="3">Donation Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ user.dp }}</strong></b-col>
            <b-col cols="1">
              <router-link to="/user/donate">
                <i class="fa fa-arrow-circle-right fa-fw" title="Donation Panel"></i>
              </router-link>
            </b-col>
          </b-row>
        </b-col>
      </b-row>
      <hr>
      <b-list-group-item>
        <div class="form-group text-center">Game Account Access:</div>
          <b-row>
            <b-table
              responsive
              striped
              bordered
              :items="user.accountAccess"
              :fields="TableFields"
              :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
            >
              <span slot="realmId" slot-scope="data">{{GetRealmNameById(data.value)}}</span>
              <span slot="gmlevel" slot-scope="data">
                <font :color="GetGameRankColor(data.value)">{{GetGameRankName(data.value)}}</font>
            </span>
          </b-table>
        </b-row>
      </b-list-group-item>
    </div>
  </div>
</template>

<script>
import { HollowDotsSpinner } from "epic-spinners";
import Gravatar from "vue-gravatar";
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";

const API_AUTH = process.env.API.AUTH;

export default {
  props: ["user"],
  data() {
    return {
      UsernameInput: false,
      UsernameLoading: false,
      NameInput: false,
      NameLoading: false,
      LastInput: false,
      LastLoading: false,
      LocInput: false,
      LocLoading: false,

      Username: "",
      Firstname: "",
      Lastname: "",
      Location: "",

      TableFields: [
        //{ key: "accountId", sortable: true, tdClass: "th-accountId" },
        { key: "gmlevel", sortable: true, tdClass: "th-gmlevel" },
        {
          key: "realmId",
          label: "Realm",
          sortable: true,
          tdClass: "th-realmid"
        }
      ]
    };
  },
  components: {
    "vue-gravatar": Gravatar,
    "epic-spinner": HollowDotsSpinner
  },
  computed: {
    Realms() {
      return this.$store.getters["realms/GetRealms"];
    }
  },
  methods: {
    isFieldValid(field) {
      const result = this.$validator.fields.find({ name: field });
      return result.flags.valid;
    },
    async UpdateUsername() {
      if (!this.isFieldValid("new nickname")) {
        return;
      }

      const { Username } = this;

      if (Username == this.user.username) {
        this.$toasted.error("New nickname is identical to the current one");
        return;
      }

      let result;

      this.UsernameLoading = true;

      try {
        result = await this.$http.post(`${API_AUTH}/UpdateAccount`, {
          Username,
          Firstname: "",
          Lastname: "",
          Location: ""
        });
      } finally {
        this.UsernameLoading = false;
      }

      if (result != null) {
        this.UsernameInput = false;
        this.Username = "";

        this.$store.commit("user/UpdateUser", {
          index: "username",
          value: Username
        });
        this.$toasted.success("Success! Nickname has been updated.");
      }
    },
    async UpdateName() {
      if (!this.isFieldValid("new firstname")) {
        return;
      }

      const { Firstname } = this;

      if (Firstname == this.user.firstname) {
        this.$toasted.error("New firstname is identical to the current one");
        return;
      }

      let result;
      this.NameLoading = true;
      try {
        result = await this.$http.post(`${API_AUTH}/UpdateAccount`, {
          Firstname,
          Lastname: "",
          Location: "",
          Username: ""
        });
      } finally {
        this.NameLoading = false;
      }

      if (result != null) {
        this.NameInput = false;
        this.Firstname = "";

        this.$store.commit("user/UpdateUser", {
          index: "firstname",
          value: Firstname
        });
        this.$toasted.success("Success! Firstname has been updated.");
      }
    },
    async UpdateLastName() {
      if (!this.isFieldValid("new lastname")) {
        return;
      }

      const { Lastname } = this;

      if (Lastname == this.user.lastname) {
        this.$toasted.error("New lastname is identical to the current one");
        return;
      }

      let result;
      this.LastLoading = true;

      try {
        result = await this.$http.post(`${API_AUTH}/UpdateAccount`, {
          Firstname: "",
          Lastname,
          Location: "",
          Username: ""
        });
      } finally {
        this.LastLoading = false;
      }

      if (result != null) {
        this.LastInput = false;
        this.Lastname = "";

        this.$store.commit("user/UpdateUser", {
          index: "lastname",
          value: Lastname
        });
        this.$toasted.success("Success! Lastname has been updated.");
      }
    },
    async UpdateLocation() {
      if (!this.isFieldValid("new location")) {
        return;
      }

      const { Location } = this;

      if (Location == this.user.location) {
        this.$toasted.error("New location is identical to the current one");
        return;
      }

      let result;
      this.LocLoading = true;

      try {
        result = await this.$http.post(`${API_AUTH}/UpdateAccount`, {
          Username: "",
          Firstname: "",
          Lastname: "",
          Location
        });
      } finally {
        this.LocLoading = false;
      }

      if (result != null) {
        this.LocInput = false;
        this.Location = "";

        this.$store.commit("user/UpdateUser", {
          index: "location",
          value: Location
        });
        this.$toasted.success("Success! Location has been updated.");
      }
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetRoleColor(roles) {
      return UserHelper.GetRoleColor(roles);
    },
    GetGameRankColor(rank) {
      return UserHelper.GetGameRankColor(rank);
    },
    GetGameRankName(rank) {
      return UserHelper.GetGameRankName(rank);
    },
    GetRealmById(id) {
      return this.Realms.find(x => x.id == id);
    },
    GetRealmNameById(id) {
      const realm = this.GetRealmById(id);
      return realm ? realm.name : "Global";
    }
  },
  created() {}
};
</script>

<style scoped>
.gravatar-image {
  width: 100%;
  height: 100%;
  max-width: 130px;
  max-height: 130px;
  border: 1px solid #cbcbcb;
  padding: 0.3vw;
  background: #fff;
  -webkit-border-radius: 4px;
  -moz-border-radius: 4px;
  border-radius: 4px;
  -webkit-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -moz-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  -o-box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
  box-shadow: -2px 2px 6px -1px rgba(0, 0, 0, 0.3);
}

.gravatar:hover .overlay {
  opacity: 0.5;
}

.text-color-green {
  color: #408080;
  text-transform: capitalize;
}

.text-color-purple {
  color: #7289da;
}

.player-nickname {
  color: #c47e2c;
  text-transform: capitalize;
}

.user-information {
  padding-right: 0 !important;
}

.profile-update-button {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}

.profile-update-input {
  min-width: 60px;
}

.update-buttons {
  margin-left: 1px;
}
</style>
