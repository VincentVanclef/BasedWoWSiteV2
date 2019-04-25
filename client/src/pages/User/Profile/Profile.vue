<template>
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
              <div class="overlay">
                <div class="text">Change Avatar</div>
              </div>
            </router-link>
          </div>
        </b-col>
        <b-col cols="9" class="user-information">
          <p>User Information</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/user.png" title="Name">
            </b-col>
            <b-col cols="3">Name</b-col>
            <b-col cols="3" class="player-nickname">{{ User.firstname }}</b-col>
            <b-col cols="1">
              <router-link to="/user/profile/edit">
                <img src="/static/images/pencil.png" title="Edit Profile">
              </router-link>
            </b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/world.png">
            </b-col>
            <b-col cols="3">Location</b-col>
            <b-col cols="3">{{ User.location ? User.location : "Unknown" }}</b-col>
            <b-col cols="1">
              <router-link to="/user/profile/edit">
                <img src="/static/images/pencil.png" title="Edit Profile">
              </router-link>
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
            <b-col cols="3" class="text-color-green">{{ User.vp }}</b-col>
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
            <b-col cols="3" class="text-color-green">{{ User.dp }}</b-col>
            <b-col cols="1">
              <router-link to="/user/donate">
                <i class="fa fa-arrow-circle-right fa-fw" title="Donation Panel"></i>
              </router-link>
            </b-col>
          </b-row>
        </b-col>
      </b-row>
    </div>
  </div>
</template>

<script>
import Gravatar from "vue-gravatar";

export default {
  props: ["User"],
  data() {
    return {};
  },
  components: {
    "vue-gravatar": Gravatar
  },
  methods: {
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
  created() {}
};
</script>

<style scoped>
.gravatar {
  position: relative;
  width: 50%;
}

.gravatar-image {
  width: 130px;
  height: 130px;
  border: 1px solid #cbcbcb;
  padding: 7px;
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
  width: 130px;
  height: 130px;
  opacity: 0;
  transition: 0.7s ease;
  background: black;
}

.gravatar:hover .overlay {
  opacity: 0.5;
}

.text {
  color: white;
  font-size: 20px;
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
}

.player-nickname {
  color: #c47e2c;
}

.profile-icon {
  height: 20px;
  width: 20px;
}

.user-information {
  padding-right: 0 !important;
}
</style>
