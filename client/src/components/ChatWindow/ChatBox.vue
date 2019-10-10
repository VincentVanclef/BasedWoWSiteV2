<template>
  <div class="chat-window" v-if="IsLoggedIn">
    <div v-if="Expanded" class="chat-background">
      <div v-if="GroupChatsLoaded">
        <b-card no-body>
          <b-tabs
            card
            vertical
            nav-wrapper-class="w-25 text-left"
            nav-class="text-center p-0 bg-secondary"
            active-tab-class="p-1 bg-grey"
            active-nav-item-class="bg-light"
            content-class="w-75"
            v-model="GroupChatIndex"
          >
            <b-tab v-for="chat in GetGroupChats" :key="chat.id" @click="SetActiveChat(chat)">
              <template v-slot:title>
                <vue-gravatar
                  class="rounded-circle user_img"
                  :class="{'border-danger': IsAdmin(GetOtherMember(chat[INDEX_GROUP].members).id), 'border-primary': IsModerator(GetOtherMember(chat[INDEX_GROUP].members).id) }"
                  :email="GetOtherMember(chat[INDEX_GROUP].members).email"
                  alt="Gravatar"
                  default-img="https://i.imgur.com/0AwrvCm.jpg"
                  v-b-tooltip.hover.right
                  :title="GetOtherMember(chat[INDEX_GROUP].members).name"
                  v-contextmenu.groupchat="{ GroupId: chat[INDEX_GROUP].id }"
                />
              </template>
              <b-card-text class="chatbox" id="groupChatWindow">
                <section class="discussion">
                  <div
                    v-for="msg in chat[INDEX_GROUP].chatMessages"
                    :key="msg.id"
                    :class="msg.senderId === GetUser.id ? 'bubble recipient middle' : 'bubble sender middle'"
                    v-contextmenu.chatmessage="{ Message: msg }"
                    v-b-tooltip.hover
                    :title="GetDate(msg.dateTime)"
                  >{{msg.message}}</div>
                </section>
              </b-card-text>
            </b-tab>
            <b-tab @click="SetActiveChat(null)">
              <template v-slot:title>
                <div v-b-tooltip.hover.right title="Start new chat" class="text-dark">
                  <i class="fas fa-plus"></i>
                </div>
              </template>
              <b-card-text class="chatbox">
                <b-button
                  block
                  variant="info"
                  class="text-capitalize font-weight-bold"
                  v-for="user in GetUsersNotAlreadyChattingWith"
                  :key="user.id"
                  v-b-tooltip.hover.bottom
                  :title="`Start a chat with ${user.name}`"
                  @click="CreateNewChatGroup(user)"
                >
                  <i class="fas fa-plus"></i>
                  {{user.name}}
                </b-button>
              </b-card-text>
            </b-tab>
          </b-tabs>
        </b-card>
        <div class="input-group border-dark" v-if="ActiveChat">
          <b-textarea
            id="chatmessage"
            name="chat message"
            type="text"
            v-model="Message"
            v-validate="'required|min:2|max:200'"
            class="form-control type_msg chatbox-message"
            :class="{'error': errors.has('chat message') }"
            placeholder="Type your message..."
            @keydown.enter="SendNewMessage()"
          ></b-textarea>
          <b-tooltip
            v-if="errors.has('chat message')"
            placement="bottom"
            target="chatmessage"
          >{{ getErrorMsg('chat message') }}</b-tooltip>

          <div class="input-group-append">
            <span
              class="input-group-text send_btn"
              v-b-tooltip.hover.top
              title="Send Message"
              @click="SendNewMessage()"
            >
              <i class="fas fa-location-arrow"></i>
            </span>
          </div>
        </div>

        <edit-message ref="editMessageModal" />
      </div>
    </div>
    <div>
      <b-button
        class="close-button"
        block
        variant="dark"
        v-if="Expanded"
        @click="ToggleChatWindow()"
      >
        Close Chat Window
        <b-spinner v-if="!GroupChatsLoaded" small variant="success" label="Spinning"></b-spinner>
      </b-button>
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
import EditChatMessage from "./Actions/EditChatMessage";
import UserHelper from "@/helpers/UserHelper";
import moment from "moment";
import _ from "lodash";

export default {
  name: "ChatWindow",
  data() {
    return {
      Expanded: false,
      Message: "",
      ActiveChat: null,

      GroupChatIndex: 0,

      GroupChatsLoaded: false,

      INDEX_KEY: 0,
      INDEX_GROUP: 1
    };
  },
  components: {
    "edit-message": EditChatMessage
  },
  computed: {
    GetUser() {
      return this.$store.getters["user/GetUser"];
    },
    IsLoggedIn() {
      return UserHelper.IsLoggedIn();
    },
    IsUserAdmin() {
      return UserHelper.IsAdmin();
    },
    IsUserModerator() {
      return UserHelper.IsModerator();
    },
    GetUserClient() {
      return this.$store.getters["stats/GetOnlineUsers"].find(
        x => x.id === this.GetUser.id
      );
    },
    GetOnlineUsers() {
      const users = [...this.$store.getters["stats/GetOnlineUsers"]];
      return users.filter(x => x.id !== this.GetUser.id);
    },
    GetGroupChats() {
      return this.$store.getters["chat/GetGroupChats"];
    },
    GetUsersNotAlreadyChattingWith() {
      let onlineUsers = [...this.GetOnlineUsers];

      const activeChats = [...this.GetGroupChats.values()];
      const activeChatMembers = activeChats.map((a, b) => ({
        members: a.members
      }));

      for (const memberList of activeChatMembers) {
        for (const member of memberList.members) {
          onlineUsers = onlineUsers.filter(x => x.id !== member.id);
        }
      }

      return onlineUsers;
    }
  },
  methods: {
    async ToggleChatWindow() {
      this.Expanded = !this.Expanded;

      if (!this.GroupChatsLoaded) {
        try {
          await this.$store.dispatch("chat/GetGroupChats");
        } finally {
          this.GroupChatsLoaded = true;
        }
      }

      if (this.GetGroupChats.size > 0) {
        this.ActiveChat = this.GetGroupChats.values().next().value;
      }
    },
    EditMessage(message) {
      this.$refs.editMessageModal.show(this.ActiveChat.id, message);
    },
    SetActiveChat(chat) {
      this.ActiveChat = chat ? chat[this.INDEX_GROUP] : null;
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
    GetChatMessageColor(memberId) {
      return memberId === this.GetUser.id ? "#78e08f" : "#82ccdd";
    },
    GetOtherMember(members) {
      const member = members.find(x => x.id !== this.GetUser.id);
      return member;
    },
    GetChatMemberById(chat, memberId) {
      return chat.Members.find(x => x.Id === memberId);
    },
    IsMessageOwner(id) {
      return UserHelper.Equals(id);
    },
    ScrollIntoView() {
      const groupChatWindow = document.getElementById("groupChatWindow");
      if (groupChatWindow) {
        groupChatWindow.scrollTop = groupChatWindow.scrollHeight;
      }
    },
    async CreateNewChatGroup(user) {
      await this.$store.dispatch("chat/CreateGroupChat", {
        Members: [this.GetUserClient, user]
      });
    },
    async isFieldValid(field) {
      const result = await this.$validator.validate(field);
      return result;
    },
    async SendNewMessage() {
      if (!UserHelper.IsLoggedIn()) {
        this.$root.ToastError("Please login to chat");
        return;
      }

      const isFieldValid = await this.isFieldValid("chat message");
      if (!isFieldValid) {
        return;
      }

      const GroupId = this.ActiveChat.id;
      const Message = this.Message;

      try {
        await this.$store.dispatch("chat/SendGroupChatMessage", {
          GroupId,
          Message
        });
      } catch (error) {
        this.$root.ToastError(error.toString(), "Chat Error");
      }

      this.Message = "";
      const chatMessageBox = document.getElementById("chatmessage");
      chatMessageBox.focus();
    },
    async DeleteMessage(MessageId) {
      const check = await this.$bvModal.msgBoxConfirm(
        "Are you sure you wish to delete this message?",
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (check) {
        const GroupId = this.ActiveChat.id;
        await this.$store.dispatch("chat/DeleteMessage", {
          GroupId,
          MessageId
        });
        this.$root.ToastSuccess("Message deleted successfully");
      }
    },
    async LeaveGroupChat(GroupId) {
      const check = await this.$bvModal.msgBoxConfirm(
        "Are you sure you wish to leave this chat?",
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (check) {
        await this.$store.dispatch("chat/LeaveGroup", GroupId);
        this.$root.ToastSuccess("You have left the chat.");
        this.SetActiveChat(null);
      }
    }
  },
  watch: {
    GetGroupChats: _.debounce(function() {
      this.ScrollIntoView();
    }, 250),
    ActiveChat: _.debounce(function() {
      this.ScrollIntoView();
    }, 500)
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
  height: 400px;
  overflow: auto;
  position: relative;
}

.user_img {
  height: 100%;
  width: 100%;
  border: 2px solid #f5f6fa;
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

.discussion {
  width: 100%;
  margin: 0 auto;

  display: flex;
  flex-flow: column wrap;
}

.discussion > .bubble {
  border-radius: 1em;
  padding: 0.25em 0.75em;
  margin: 0.0625em;
  max-width: 100%;
}

.discussion > .bubble.sender {
  text-transform: capitalize;
  align-self: flex-start;
  color: aliceblue;
  background-color: slategray;
}
.discussion > .bubble.recipient {
  text-transform: capitalize;
  align-self: flex-end;
  color: whitesmoke;
  background-color: #0084ff;
}

.discussion > .bubble.sender.middle {
  border-bottom-left-radius: 0.1em;
  border-top-left-radius: 0.1em;
}

.discussion > .bubble.recipient.middle {
  border-bottom-right-radius: 0.1em;
  border-top-right-radius: 0.1em;
}
</style>