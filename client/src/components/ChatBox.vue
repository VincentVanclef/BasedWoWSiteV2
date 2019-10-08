<template>
  <div class="chat-window" v-if="IsLoggedIn">
    <div v-if="Expanded" class="chat-background">
      <div class="chatbox overflow-auto">
        <b-card no-body class="h-100">
          <b-tabs
            card
            vertical
            justified
            align
            nav-wrapper-class="w-25 text-left"
            nav-class="text-center p-0 bg-secondary"
            active-tab-class="p-1"
            active-nav-item-class="bg-light"
          >
            <b-tab v-for="(groupChat, index) in GetGroupChats" :key="index">
              <template v-slot:title>
                <vue-gravatar
                  class="rounded-circle user_img"
                  :class="{'border-danger': IsAdmin(GetOtherMember(groupChat.Members).id), 'border-primary': IsModerator(GetOtherMember(groupChat.Members).id) }"
                  :email="GetOtherMember(groupChat.Members).email"
                  alt="Gravatar"
                  default-img="https://i.imgur.com/0AwrvCm.jpg"
                  v-b-tooltip.hover.right
                  :title="GetOtherMember(groupChat.Members).name"
                />
              </template>
              <b-card-text>
                <b-list-group>
                  <b-list-group-item>{{groupChat.GroupId}}</b-list-group-item>
                </b-list-group>
              </b-card-text>
            </b-tab>
            <b-tab>
              <template v-slot:title>
                <div v-b-tooltip.hover.right title="Start new chat" class="text-dark">
                  <i class="fas fa-plus"></i>
                </div>
              </template>
              <b-card-text>
                <b-button
                  block
                  variant="info"
                  class="text-capitalize font-weight-bold"
                  v-for="user in GetOnlineUsers"
                  :key="user.id"
                  v-b-tooltip.hover.bottom
                  :title="`Start a chat with ${user.clients[0].clientName}`"
                  @click="CreateNewChatGroup(user)"
                >
                  <i class="fas fa-plus"></i>
                  {{user.clients[0].clientName}}
                </b-button>
              </b-card-text>
            </b-tab>
          </b-tabs>
        </b-card>
      </div>
      <div class="input-group border-dark">
        <b-textarea
          id="chatmessage"
          name="chat message"
          type="text"
          v-model="Message"
          v-validate="'required|min:10|max:200'"
          class="form-control type_msg chatbox-message"
          :class="{'error': errors.has('chat message') }"
          placeholder="Type your message..."
        ></b-textarea>
        <b-tooltip placement="bottom" target="chatmessage">{{ getErrorMsg('chat message') }}</b-tooltip>

        <div class="input-group-append">
          <span class="input-group-text send_btn" v-b-tooltip.hover.top title="Send Message">
            <i class="fas fa-location-arrow"></i>
          </span>
        </div>
      </div>
    </div>
    <div>
      <b-button
        class="close-button"
        block
        variant="dark"
        v-if="Expanded"
        @click="ToggleChatWindow()"
      >Close Chat Window</b-button>
      <b-button
        class="open-button"
        block
        variant="dark"
        v-if="!Expanded"
        @click="ToggleChatWindow()"
      >Open Chat Window</b-button>
    </div>
  </div>
</template>

<script>
import UserHandler from "@/helpers/UserHelper";
import moment from "moment";

export default {
  name: "ChatWindow",
  data() {
    return {
      Expanded: false,
      Message: ""
    };
  },
  computed: {
    GetUser() {
      return this.$store.getters["user/GetUser"];
    },
    GetSelf() {
      return this.$store.getters["stats/GetOnlineUsers"].find(
        x => x.id === this.GetUser.id
      );
    },
    IsLoggedIn() {
      return UserHandler.IsLoggedIn();
    },
    GetOnlineUsers() {
      const users = [...this.$store.getters["stats/GetOnlineUsers"]];
      return users.filter(x => x.id !== this.GetUser.id);
    },
    GetGroupChats() {
      return this.$store.getters["chat/GetGroupChats"];
    },
    GetGroupChatsAsArray() {
      return Array.from(this.GetGroupChats.values());
    }
  },
  methods: {
    ToggleChatWindow() {
      this.Expanded = !this.Expanded;
    },
    GetDate(date) {
      return moment(date).format("MMM D YYYY, HH:mm");
    },
    IsAdmin(userId) {
      return this.$store.getters["admin/GetAdminById"](userId);
    },
    IsModerator(userId) {
      return this.$store.getters["admin/GetModeratorById"](userId);
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    async CreateNewChatGroup(user) {
      await this.$store.dispatch("chat/CreateGroupChat", {
        Owner: this.GetUser.id,
        Members: [this.GetSelf, user]
      });
    },
    GetOtherMember(members) {
      const memberArray = Array.from(members.values());
      const otherMember = memberArray.find(
        x => x.Identity.id !== this.GetUser.id
      );
      const mappedMember = {
        id: otherMember.Identity.id,
        name: otherMember.Identity.clients[0].clientName,
        email: otherMember.Identity.clients[0].clientEmail
      };
      return mappedMember ? mappedMember : null;
    },
    Test(k) {
      console.log(k);
    }
  },
  mounted() {}
};
</script>

<style scoped>
.chat-window {
  bottom: 0;
  left: 1%;
  position: fixed;
  width: 320px;
  z-index: 1000;
  resize: both;
}

.chat-background {
  border: 1px solid whitesmoke;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.open-button {
  opacity: 0.6;
  bottom: 0;
  outline: inherit;
}

.close-button {
  bottom: 0;
  outline: inherit;
}

.close-button:focus,
.open-button:focus {
  outline: none;
}

.chatbox {
  width: 100%;
  max-height: 500px;
  min-height: 200px;
  background-color: whitesmoke;
}

.user_img {
  height: 100%;
  width: 100%;
  border: 2px solid #f5f6fa;
}

.msg_container {
  position: relative;
  word-wrap: break-word;
}

.msg_time {
  color: rgba(255, 255, 255, 0.9);
  font-size: 10px;
  text-align: left;
}

.type_msg {
  height: 60px;
  overflow-y: auto;
  line-height: 2;
}

.chatbox-message {
  height: 50px;
  resize: none;
}

.chatbox-message::-webkit-scrollbar {
  width: 0 !important;
  background-color: #f5f5f5;
}
</style>