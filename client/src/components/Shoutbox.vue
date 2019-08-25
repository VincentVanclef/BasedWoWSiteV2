<template>
  <b-card
    class="shoutbox mt-3"
    header-bg-variant="dark"
    header-text-variant="white"
    body-bg-variant="secondary"
    body-text-variant="dark"
    footer-bg-variant="dark"
    footer-text-variant="white"
    border-variant="dark"
  >
    <div slot="header">Shoutbox</div>

    <b-card-text class="chat">
      <div v-if="IsLoading" class="d-flex justify-content-center">
        <semipolar-spinner :animation-duration="2000" :size="80" :color="'#7289da'" />
      </div>

      <div class="msg_card_body" ref="shoutbox">
        <div v-for="shout in GetSortedShouts" :key="shout.id">
          <div v-if="!IsShoutOwner(shout.user)" class="d-flex justify-content-start mb-3">
            <div class="img_cont_msg">
              <router-link :to="'/profile/' + shout.username">
                <vue-gravatar
                  class="rounded-circle user_img_msg text-capitalize"
                  :class="{'border-danger': IsAdmin(shout.user), 'border-primary': IsModerator(shout.user) }"
                  :email="shout.email"
                  alt="Gravatar"
                  default-img="https://i.imgur.com/0AwrvCm.jpg"
                  v-b-tooltip.hover.bottom
                  :title="shout.username"
                />
              </router-link>
            </div>
            <div class="msg_container">
              {{shout.message}}
              <span class="msg_time">
                {{GetDate(shout.date)}}
                <i
                  class="fa fa-edit click-able ml-1"
                  v-if="IsShoutOwner(shout.user) || IsUserAdmin || IsModerator"
                  @click="EditShout(shout)"
                ></i>
                <i
                  class="fa fa-trash click-able ml-1"
                  v-if="IsShoutOwner(shout.user) || IsUserAdmin || IsModerator"
                  @click="DeleteShout(shout.id)"
                ></i>
              </span>
            </div>
            <div class="form-group"></div>
          </div>

          <div v-else class="d-flex justify-content-end mb-4">
            <div class="msg_container_send">
              {{shout.message}}
              <span class="msg_time_send">
                {{GetDate(shout.date)}}
                <i
                  class="fa fa-edit click-able ml-1"
                  v-if="IsShoutOwner(shout.user) || IsUserAdmin || IsUserModerator"
                  @click="EditShout(shout)"
                ></i>
                <i
                  class="fa fa-trash click-able ml-1"
                  v-if="IsShoutOwner(shout.user) || IsUserAdmin || IsUserModerator"
                  @click="DeleteShout(shout.id)"
                ></i>
              </span>
            </div>
            <div class="img_cont_msg">
              <router-link :to="'/profile/' + shout.username">
                <vue-gravatar
                  class="rounded-circle user_img_msg text-capitalize"
                  :class="{'border-danger': IsAdmin(shout.user), 'border-primary': IsModerator(shout.user) }"
                  :email="shout.email"
                  alt="Gravatar"
                  default-img="https://i.imgur.com/0AwrvCm.jpg"
                  v-b-tooltip.hover.bottom
                  :title="shout.username"
                />
              </router-link>
            </div>
          </div>
        </div>
      </div>

      <hr class="border-dark" />

      <div class="input-group">
        <b-textarea
          id="shoutbox"
          name="shoutbox"
          type="text"
          v-model="NewShout"
          v-validate="'required|min:10|max:200'"
          class="form-control type_msg shoutbox-message"
          :class="{'error': errors.has('shoutbox') }"
          placeholder="Type your message..."
        ></b-textarea>
        <b-tooltip placement="bottom" target="shoutbox">{{ getErrorMsg('shoutbox') }}</b-tooltip>

        <div class="input-group-append">
          <span
            class="input-group-text send_btn"
            v-b-tooltip.hover.bottom
            title="Shout!"
            @click="Shout()"
          >
            <i class="fas fa-location-arrow"></i>
          </span>
        </div>
      </div>
    </b-card-text>

    <div slot="footer">
      <ul class="list-inline list-unstyled mb-0">
        <small>
          <li class="list-inline-item click-able float-left" v-if="IsAdmin" @click="ClearShouts()">
            <i class="fas fa-trash"></i>
            Clear Shouts
          </li>
        </small>
        <li class="list-inline-item float-right">
          Total Shouts
          <span class="font-orange font-weight-bold">{{GetShouts.length}}</span>
        </li>
      </ul>
    </div>

    <edit-shout ref="editShoutModal"></edit-shout>
  </b-card>
</template>

<script>
import UserHelper from "../helpers/UserHelper";
import { SemipolarSpinner } from "epic-spinners";
import moment from "moment";
import Gravatar from "vue-gravatar";
import config from "@/assets/config/config";
import EditShout from "@/components/Shoutbox/EditShout";

export default {
  props: ["user"],
  data() {
    return {
      NewShout: "",
      IsLoading: false,
      TotalShouts: 0
    };
  },
  components: {
    "vue-gravatar": Gravatar,
    "semipolar-spinner": SemipolarSpinner,
    "edit-shout": EditShout
  },
  computed: {
    GetShouts() {
      return this.$store.getters["shoutbox/GetAllShouts"];
    },
    GetSortedShouts() {
      const shouts = Object.assign([], this.GetShouts);
      return shouts.sort((a, b) => (a.id > b.id ? 1 : -1));
    },
    CanShout() {
      return UserHelper.CanShout();
    },
    IsUserAdmin() {
      return UserHelper.IsAdmin();
    },
    IsUserModerator() {
      return UserHelper.IsModerator();
    }
  },
  methods: {
    IsAdmin(userId) {
      return this.$store.getters["admin/GetAdminById"](userId);
    },
    IsModerator(userId) {
      return this.$store.getters["admin/GetModeratorById"](userId);
    },
    IsShoutOwner(userId) {
      return UserHelper.Equals(userId);
    },
    GetDate(date) {
      return moment(date).format("MMM D YYYY, HH:mm");
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    async isFieldValid(field) {
      const result = await this.$validator.validate(field);
      return result;
    },
    async Shout() {
      if (!UserHelper.IsLoggedIn()) {
        this.$toasted.error("Please login to shout");
        return;
      }

      const isFieldValid = await this.isFieldValid("shoutbox");
      if (!isFieldValid) {
        return;
      }

      const then = moment(this.user.shoutBoxTimer * 1000);
      const now = moment();
      if (then > now) {
        const timeLeft = moment
          .utc(moment(then).diff(moment(now)))
          .format("HH:mm:ss");
        this.$toasted.error(
          `You must wait ${timeLeft} until you can shout again.`
        );
        return;
      }

      this.IsLoading = true;

      try {
        await this.$store.dispatch("shoutbox/Shout", {
          message: this.NewShout
        });
      } catch (e) {
        this.$toasted.error(this.$root.GetErrorMessage(e));
        return;
      } finally {
        this.IsLoading = false;
      }
      this.NewShout = "";
      this.$toasted.success("New shout submitted succesfully");
      const unsetTime = new moment()
        .add(config.TIME_BETWEEN_SHOUTS, "seconds")
        .unix();
      this.$store.commit("user/UpdateUser", {
        index: "shoutBoxTimer",
        value: unsetTime
      });
    },
    async ClearShouts() {
      try {
        await this.$dialog.confirm(
          "Are you sure you wish to clear the shoutbox?"
        );
      } catch (e) {
        return;
      }

      try {
        await this.$store.dispatch("shoutbox/ClearShouts");
      } catch (e) {
        this.$toasted.error(this.$root.GetErrorMessage(e));
        return;
      }
    },
    async DeleteShout(id) {
      try {
        await this.$dialog.confirm(
          "Are you sure you wish to delete this shout?"
        );
      } catch (e) {
        return;
      }

      try {
        await this.$store.dispatch("shoutbox/DeleteShout", id);
      } catch (e) {
        this.$toasted.error(this.$root.GetErrorMessage(e));
        return;
      }

      this.$toasted.success("Shout deleted successfully");
    },
    EditShout(shout) {
      this.$refs.editShoutModal.show(shout);
    }
  },
  created() {
    if (this.GetShouts.length == 0) {
      this.IsLoading = true;
      this.$store
        .dispatch("shoutbox/FetchAllShouts")
        .catch(error => this.$toasted.error(this.$root.GetErrorMessage(e)))
        .finally(() => {
          this.IsLoading = false;
          this.TotalShouts = this.GetShouts.length;
        });
    }

    if (this.$store.getters["admin/GetAdmins"].length == 0) {
      this.IsLoading = true;
      this.$store
        .dispatch("admin/FetchAdmins")
        .catch(error => this.$toasted.error(error))
        .finally(() => (this.IsLoading = false));
    }
  },
  watch: {
    // Watch when shoutbox changes
    GetShouts: function(val) {
      // Only goto bottom when a new message is posted
      if (val.length > this.TotalShouts) {
        const shoutBox = this.$refs.shoutbox;
        shoutBox.scrollTop = shoutBox.scrollHeight;
      }

      this.TotalShouts = val.length;
    }
  }
};
</script>

<style scoped>
.shoutbox-message {
  height: 50px;
  resize: none;
}

.shoutbox-message::-webkit-scrollbar {
  width: 0 !important;
  background-color: #f5f5f5;
}

.chat {
  border-radius: 10px;
  max-height: 400px;
  padding: 10px;
  background-color: rgba(0, 0, 0, 0.4);
}

.card {
  background-color: rgba(0, 0, 0, 0.4) !important;
}

.msg_card_body::-webkit-scrollbar {
  width: 0 !important;
  background-color: #f5f5f5;
}

.msg_card_body {
  position: relative;
  max-height: 250px;
  overflow: auto;
}

.type_msg {
  background-color: rgba(0, 0, 0, 0.3);
  border: 0;
  color: white;
  height: 60px;
  overflow-y: auto;
}
.type_msg:focus {
  box-shadow: none;
  outline: 0px;
}

.shoutbox-send::-webkit-scrollbar {
  width: 0 !important;
  background-color: #f5f5f5;
}

.send_btn {
  border-radius: 0 15px 15px 0;
  background-color: rgba(0, 0, 0, 0.3);
  border: 0;
  color: white;
  cursor: pointer;
}

.search_btn {
  border-radius: 0 15px 15px 0;
  background-color: rgba(0, 0, 0, 0.3);
  border: 0;
  color: white;
  cursor: pointer;
}

.active {
  background-color: rgba(0, 0, 0, 0.3);
}
.user_img {
  position: relative;

  height: 70px;
  width: 70px;
  border: 1.5px solid #f5f6fa;
}
.user_img_msg {
  position: relative;

  height: 40px;
  width: 40px;
  border: 1.5px solid #f5f6fa;
}
.img_cont {
  height: 70px;
  width: 70px;
}
.img_cont_msg {
  margin-top: 3px;
  height: 40px;
  width: 40px;
}

.user_info {
  margin-top: auto;
  margin-bottom: auto;
  margin-left: 15px;
}
.user_info span {
  font-size: 20px;
  color: white;
}
.user_info p {
  font-size: 10px;
  color: rgba(255, 255, 255, 0.6);
}
.video_cam {
  margin-left: 50px;
  margin-top: 5px;
}
.video_cam span {
  color: white;
  font-size: 20px;
  cursor: pointer;
  margin-right: 20px;
}

.msg_container {
  margin-top: auto;
  margin-bottom: auto;
  margin-left: 10px;
  border-radius: 25px;
  background-color: #82ccdd;
  padding: 10px;
  position: relative;
  max-width: 65%;
  word-wrap: break-word;
}

.msg_container_send {
  margin-top: auto;
  margin-bottom: auto;
  margin-right: 10px;
  border-radius: 25px;
  background-color: #78e08f;
  padding: 10px;
  position: relative;
  max-width: 65%;
  word-wrap: break-word;
}

.msg_time {
  position: absolute;
  left: 0;
  bottom: -15px;
  color: rgba(255, 255, 255, 0.5);
  font-size: 10px;
  width: 150px;
  text-align: left;
}

.msg_time_send {
  position: absolute;
  right: 0;
  bottom: -15px;
  color: rgba(255, 255, 255, 0.5);
  font-size: 10px;
  width: 150px;
  text-align: right;
}

.msg_head {
  position: relative;
}
</style>

