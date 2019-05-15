<template lang="html">
  <div class="container">
    <div class="profile">
      <b-row>
        <b-col cols="3">
          <div class="gravatar">
            <vue-gravatar
            class="gravatar-image"
            :email="user.email"
            alt="Gravatar"
            default-img="https://i.imgur.com/0AwrvCm.jpg"
            />
          </div>
        </b-col>
        <b-col cols="9" class="user-information">
          <p>User Information</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/user.png" title="Name displayed on the site">
            </b-col>
            <b-col cols="3">Nickname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.username }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/user.png" title="Firstname">
            </b-col>
            <b-col cols="3">Firstname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.firstname }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/user.png" title="Firstname">
            </b-col>
            <b-col cols="3">Lastname</b-col>
            <b-col cols="4">
              <div class="player-nickname">{{ user.lastname }}</div>
            </b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/world.png" title="Firstname">
            </b-col>
            <b-col cols="3">Location</b-col>
            <b-col cols="4">
              <div :class="user.location ? 'player-nickname' : ''">{{ user.location ? user.location : "Unknown" }}</div>
            </b-col>
          </b-row>
          <b-row class="form-group">
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/mail-small.png" title="Firstname">
            </b-col>
            <b-col cols="3">Email</b-col>
            <b-col cols="6">
              <div class="text-color-purple">{{ user.email }}</div>
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
            <b-col><font :color="GetRankColor(User.rank)">{{ GetRank(User.rank) }}</font></b-col>
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
            <b-col>{{ GetDate(user.joinDate) }}</b-col>
          </b-row>
          <!-- <p>Account Miscellaneous</p>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/lightning.png" title="Vote Points">
            </b-col>
            <b-col cols="3">Vote Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ user.vp }}</strong></b-col>
          </b-row>
          <b-row>
            <b-col cols="1">
              <img class="profile-icon" src="/static/images/coins.png" title="Donation Points">
            </b-col>
            <b-col cols="3">Donation Points</b-col>
            <b-col cols="3" class="text-color-green"><strong>{{ user.dp }}</strong></b-col>
          </b-row>-->
        </b-col>
      </b-row>
      <hr>
    </div>
  </div>
</template>

<script>
import Gravatar from "vue-gravatar";
import moment from "moment";
import UserHelper from "@/helpers/UserHelper";

export default {
  props: ["user"],
  data() {
    return {};
  },
  components: {
    "vue-gravatar": Gravatar
  },
  methods: {
    GetDate(date) {
      return moment(date).format("MMMM Do YYYY, HH:mm:ss");
    },
    GetRankColor(rank) {
      return UserHelper.GetRankColor(rank);
    },
    GetRank(rank) {
      return UserHelper.GetRankName(rank);
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