<template lang="html">
  <div class="container">
    <div class="profile">
      <b-row>
        <b-col cols="3">
          <div class="gravatar">
            <router-link to="/user/profile/gravatar">
              <vue-gravatar
                class="gravatar-image"
                :email="User.email"
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
              <img class="profile-icon" src="/static/images/user.png" title="Firstname">
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
              <div class="player-nickname" v-if="!NameInput">{{ User.firstname }}</div>
              <div v-else>
                <input
                  id="edit-firstname"
                  name="new firstname"
                  type="text"
                  class="update-input form-control"
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
                <button class="update-button" @click="NameInput = true; Firstname = ''">
                  <img src="/static/images/pencil.png" title="Edit Profile">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="update-button" @click="UpdateName()">
                    <i class="fa fa-check-circle" title="Save Changes"></i>
                  </button>
                  <button class="update-button" @click="NameInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/user.png" title="Firstname">
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
              <div class="player-nickname" v-if="!LastInput">{{ User.lastname }}</div>
              <div v-else>
                <input
                  id="edit-lastname"
                  name="new lastname"
                  type="text"
                  class="update-input form-control"
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
                <button class="update-button" @click="LastInput = true; Lastname = ''">
                  <img src="/static/images/pencil.png" title="Edit Profile">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="update-button" @click="UpdateLastName()">
                    <i class="fa fa-check-circle" title="Save Changes"></i>
                  </button>
                  <button class="update-button" @click="LastInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/world.png" title="Firstname">
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
              <div :class="User.location ? 'player-nickname' : ''" v-if="!LocInput">{{ User.location ? User.location : "Unknown" }}</div>
              <div v-else>
                <input
                  id="edit-location"
                  name="new location"
                  type="text"
                  class="update-input form-control"
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
                <button class="update-button" @click="LocInput = true; Location = ''">
                  <img src="/static/images/pencil.png" title="Edit Location">
                </button>
              </div>
              <div v-else>
                <b-row class="update-buttons">
                  <button class="update-button" @click="UpdateLocation()">
                    <i class="fa fa-check-circle" title="Save Changes"></i>
                  </button>
                  <button class="update-button" @click="LocInput = false">
                    <i class="fa fa-close fa-fw" title="Cancel"></i>
                  </button>
                </b-row>
              </div>
            </b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/mail-small.png" title="Firstname">
            </b-col>
            <b-col cols="3">Email</b-col>
            <b-col cols="6">
              <div class="text-color-purple">{{ User.email }}</div>
            </b-col>
          </b-row>
          <p>Account Information</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/expansion.png">
            </b-col>
            <b-col cols="3">Expansion</b-col>
            <b-col cols="5">
              <img src="/static/images/Wrath-Logo-Small.png">
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/rank.png">
            </b-col>
            <b-col cols="3">Account Rank</b-col>
            <b-col class="text-color-green">Player</b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/shield.png">
            </b-col>
            <b-col cols="3">Account Status</b-col>
            <b-col class="text-success">Active</b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/date.png">
            </b-col>
            <b-col cols="3">Join Date</b-col>
            <b-col>{{ GetDate(User.joinDate) }}</b-col>
          </b-row>
          <p>Account Miscellaneous</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/lightning.png" title="Vote Points">
            </b-col>
            <b-col cols="3">Vote Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ User.vp }}</strong></b-col>
            <b-col cols="1">
              <router-link to="/user/vote">
                <i class="fa fa-arrow-circle-right fa-fw" title="Vote Panel"></i>
              </router-link>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/coins.png" title="Donation Points">
            </b-col>
            <b-col cols="3">Donation Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ User.dp }}</strong></b-col>
            <b-col cols="1">
              <router-link to="/user/donate">
                <i class="fa fa-arrow-circle-right fa-fw" title="Donation Panel"></i>
              </router-link>
            </b-col>
          </b-row>
        </b-col>
      </b-row>
      <hr>
    </div>
  </div>
</template>

<script>
import { HollowDotsSpinner } from "epic-spinners";
import Gravatar from "vue-gravatar";
import moment from "moment";

const API_AUTH = process.env.API.AUTH;

export default {
  props: ["User"],
  data() {
    return {
      NameInput: false,
      NameLoading: false,
      LastInput: false,
      LastLoading: false,
      LocInput: false,
      LocLoading: false,

      Firstname: "",
      Lastname: "",
      Location: ""
    };
  },
  components: {
    "vue-gravatar": Gravatar,
    "epic-spinner": HollowDotsSpinner
  },
  methods: {
    isFieldValid(field) {
      const result = this.$validator.fields.find({ name: field });
      return result.flags.valid;
    },
    async UpdateName() {
      if (!this.isFieldValid("new firstname")) {
        return;
      }

      this.NameLoading = true;

      let result;
      const { Firstname } = this;
      try {
        result = await this.$http.post(`${API_AUTH}/update`, {
          Firstname,
          Lastname: "",
          Location: ""
        });
      } catch (err) {
        this.$toasted.error(err);
        return;
      } finally {
        this.NameLoading = false;
      }

      this.NameInput = false;
      this.Firstname = "";

      this.$store.commit("UPDATE_USER", {
        index: "firstname",
        value: Firstname
      });
      this.$toasted.success("Success! Firstname has been updated.");
    },
    async UpdateLastName() {
      if (!this.isFieldValid("new lastname")) {
        return;
      }

      this.LastLoading = true;

      let result;
      const { Lastname } = this;
      try {
        result = await this.$http.post(`${API_AUTH}/update`, {
          Firstname: "",
          Lastname,
          Location: ""
        });
      } catch (err) {
        if (err.message) {
          console.log(err.message);
        } else {
          console.log(err);
        }
      } finally {
        this.LastLoading = false;
      }

      this.LastInput = false;
      this.Lastname = "";

      this.$store.commit("UPDATE_USER", {
        index: "lastname",
        value: Lastname
      });
      this.$toasted.success("Success! Lastname has been updated.");
    },
    async UpdateLocation() {
      if (!this.isFieldValid("new location")) {
        return;
      }

      this.LocLoading = true;

      let result;
      const { Location } = this;
      try {
        result = await this.$http.post(`${API_AUTH}/update`, {
          Firstname: "",
          Lastname: "",
          Location
        });
      } catch (err) {
        if (err.message) {
          console.log(err.message);
        } else {
          console.log(err);
        }
      } finally {
        this.LocLoading = false;
      }

      this.LocInput = false;
      this.Location = "";

      this.$store.commit("UPDATE_USER", {
        index: "location",
        value: Location
      });
      this.$toasted.success("Success! Location has been updated.");
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
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

.overlay {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  opacity: 0;
  width: 74%;
  height: 33%;
  transition: 0.7s ease;
  background: black;
}

.gravatar:hover .overlay {
  opacity: 0.5;
}

.text {
  color: white;
  font-size: 1vw;
  position: absolute;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  text-align: center;
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

.profile-icon {
  height: 85%;
  width: 85%;
}

.user-information {
  padding-right: 0 !important;
}

.update-button {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}

.update-input {
  font-size: 0.75vw;
  width: 7vw;
  height: 1.5vw;
}

.update-buttons {
  margin-left: 1px;
}
</style>
