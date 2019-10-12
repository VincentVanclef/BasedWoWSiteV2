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
      <div v-if="Loading" class="d-flex justify-content-center">
        <semipolar-spinner :animation-duration="2000" :size="80" :color="'#7289da'" />
      </div>

      <div class="msg_card_body" id="shoutboxWindow">
        <div
          class="text-center text-secondary font-italic click-able"
          @click="LoadMoreShouts()"
          v-if="!AllShoutsLoaded"
        >
          <small>
            <span v-if="!LoadingShouts">
              <i class="fas fa-download"></i> Load more...
            </span>
            <b-spinner v-if="LoadingShouts" variant="info" type="grow"></b-spinner>
          </small>
        </div>
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
        <textarea
          id="shoutbox"
          v-emojis
          name="shoutbox"
          type="text"
          v-model="NewShout"
          v-validate="'required|min:2|max:200'"
          class="regular-input type_msg shoutbox-message"
          :class="{'regular-error': errors.has('shoutbox') }"
          placeholder="Type your message..."
          @keypress.enter="Shout"
        ></textarea>
        <b-tooltip
          v-if="errors.has('shoutbox')"
          placement="bottom"
          target="shoutbox"
        >{{ getErrorMsg('shoutbox') }}</b-tooltip>

        <div class="input-group-append">
          <span
            class="input-group-text send_btn"
            v-b-tooltip.hover.bottom
            title="Shout!"
            @click="Shout"
          >
            <i class="fas fa-location-arrow"></i>
          </span>
        </div>
      </div>
    </b-card-text>

    <div slot="footer">
      <ul class="list-inline list-unstyled mb-0">
        <li
          class="list-inline-item click-able float-left"
          v-if="IsUserAdmin"
          @click="ClearShouts()"
        >
          <small>
            <i class="fas fa-trash"></i>
            Clear Shouts
          </small>
        </li>
        <li class="list-inline-item float-right">
          Total Shouts
          <span class="font-orange font-weight-bold">{{TotalShouts}}</span>
        </li>
      </ul>
    </div>

    <edit-shout ref="editShoutModal"></edit-shout>
  </b-card>
</template>

<script>
import UserHelper from "@/helpers/UserHelper";
import { SemipolarSpinner } from "epic-spinners";
import moment from "moment";
import config from "@/assets/config/config";
import EditShout from "./Actions/EditShout";

const SHOUT_LOAD_COUNT = 5;

export default {
  props: ["user"],
  data() {
    return {
      NewShout: "",
      Loading: false,
      LoadingShouts: false,
      AllShoutsLoaded: false,

      CurrentShouts: 0
    };
  },
  components: {
    "semipolar-spinner": SemipolarSpinner,
    "edit-shout": EditShout
  },
  computed: {
    GetShouts() {
      return this.$store.getters["shoutbox/GetAllShouts"];
    },
    GetSortedShouts() {
      const shouts = [...this.GetShouts];
      return shouts.sort((a, b) => (a.id > b.id ? 1 : -1));
    },
    GetShoutIndex() {
      const startId = this.GetShouts.length > 0 ? this.GetShouts[0].id : 0;
      const index = this.GetShouts.reduce(
        (id, shout) => (shout.id < id ? shout.id : id),
        startId
      );
      return index;
    },
    TotalShouts() {
      return this.GetShouts.length;
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
    AppendEmoji(emoji) {
      this.NewShout += emoji;
    },
    async isFieldValid(field) {
      const result = await this.$validator.validate(field);
      return result;
    },
    async LoadMoreShouts() {
      const Index = this.GetShoutIndex;
      const Count = SHOUT_LOAD_COUNT;

      this.LoadingShouts = true;

      try {
        const amount = await this.$store.dispatch("shoutbox/GetShouts", {
          Index,
          Count
        });
        if (amount === 0) this.AllShoutsLoaded = true;
      } finally {
        this.LoadingShouts = false;
      }
    },
    async Shout(e) {
      e.preventDefault();

      if (!UserHelper.IsLoggedIn()) {
        this.$root.ToastError("Please login to shout");
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
        this.$root.ToastError(
          `You must wait ${timeLeft} until you can shout again.`
        );
        return;
      }

      const message = this.NewShout;
      this.NewShout = "";

      try {
        await this.$store.dispatch("shoutbox/Shout", message);
        this.$root.ToastSuccess("New shout submitted succesfully");
        const unsetTime = new moment()
          .add(config.TIME_BETWEEN_SHOUTS, "seconds")
          .unix();
        this.$store.commit("user/UpdateUser", {
          index: "shoutBoxTimer",
          value: unsetTime
        });
        const shoutbox = document.getElementById("shoutbox");
        shoutbox.focus();
      } finally {
        this.$nextTick(() => {
          this.$validator.reset();
        });
      }
    },
    async ClearShouts() {
      const check = await this.$bvModal.msgBoxConfirm(
        "Are you sure you wish to clear the shoutbox?",
        {
          centered: true,
          okTitle: "Yes"
        }
      );
      if (check) {
        await this.$store.dispatch("shoutbox/ClearShouts");
        this.$root.ToastSuccess("Shouts deleted successfully");
      }
    },
    async DeleteShout(id) {
      const check = await this.$bvModal.msgBoxConfirm(
        "Are you sure you wish to delete this shout?",
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (check) {
        await this.$store.dispatch("shoutbox/DeleteShout", id);
        this.$root.ToastSuccess("Shout deleted successfully");
      }
    },
    EditShout(shout) {
      this.$refs.editShoutModal.show(shout);
    }
  },
  created() {
    if (this.GetShouts.length == 0) {
      this.Loading = true;
      this.$store
        .dispatch("shoutbox/GetShouts", {
          Index: 0,
          Count: SHOUT_LOAD_COUNT
        })
        .finally(() => {
          this.Loading = false;
          const shoutBox = document.getElementById("shoutboxWindow");
          shoutBox.scrollTop = shoutBox.scrollHeight;
        });
    }
  },
  watch: {
    // Watch when shoutbox changes
    GetShouts: function(val, old) {
      // Only goto bottom when a new message is posted
      if (val.length > this.CurrentShouts && !this.LoadingShouts) {
        const shoutBox = document.getElementById("shoutboxWindow");
        shoutBox.scrollTop = shoutBox.scrollHeight;
      }

      this.CurrentShouts = val.length;
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
  max-height: 450px;
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
  max-height: 315px;
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
  border: 2px solid #f5f6fa;
}
.user_img_msg {
  position: relative;

  height: 40px;
  width: 40px;
  border: 2px solid #f5f6fa;
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

