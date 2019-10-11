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
            <b-tab v-for="chat in GetGroupChats" :key="chat.id" @click="SetActiveChatId(chat)">
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
                <b-badge
                  v-if="IsChatANewChat(chat[INDEX_GROUP].id)"
                  variant="danger"
                  class="chat-notification"
                >!</b-badge>
                <b-badge
                  v-if="!IsChatANewChat(chat[INDEX_GROUP].id) && GetUnreadMessages(chat[INDEX_GROUP])"
                  variant="danger"
                  class="chat-notification"
                >{{GetUnreadMessages(chat[INDEX_GROUP])}}</b-badge>
              </template>
              <b-card-text class="chatbox" :id="'groupChatWindow-'+chat[INDEX_GROUP].id">
                <section class="discussion">
                  <div
                    v-for="msg in chat[INDEX_GROUP].chatMessages"
                    :key="msg.id"
                    :class="msg.senderId === GetUser.id ? 'bubble recipient middle' : 'bubble sender middle'"
                    v-contextmenu.chatmessage="{ Message: msg }"
                    v-b-tooltip.hover
                    :title="GetDate(msg.dateTime)"
                  >
                    {{msg.message}}
                    <small v-if="msg.senderId === GetUser.id && !msg.read">
                      <i class="fas fa-hourglass-half"></i>
                    </small>
                  </div>
                </section>
              </b-card-text>
            </b-tab>
            <b-tab @click="SetActiveChatId(null)">
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
        <div class="input-group position-relative inline-block" v-if="ActiveChatId">
          <textarea
            id="chatmessage"
            name="chat message"
            type="text"
            v-model="Message"
            v-emojis
            v-validate="'required|min:2|max:200'"
            :class="{ 'regular-input type_msg chatbox-message': true,
            'regular-error': errors.has('chat message')}"
            placeholder="Type your message..."
            @keydown.enter="SendNewMessage()"
            @keydown.esc="ToggleChatWindow()"
          ></textarea>

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
        <b-badge
          variant="danger"
          v-if="GetNewGroupChats.size + GetAllUnreadMessages > 0"
        >{{GetNewGroupChats.size + GetAllUnreadMessages}}</b-badge>
      </b-button>
      <b-button
        class="open-button"
        block
        variant="dark"
        v-if="!Expanded"
        @click="ToggleChatWindow()"
      >
        Open Chat Window
        <b-spinner v-if="!GroupChatsLoaded" small variant="success" label="Spinning"></b-spinner>
        <b-badge
          variant="danger"
          v-if="GetNewGroupChats.size + GetAllUnreadMessages > 0"
        >{{GetNewGroupChats.size + GetAllUnreadMessages}}</b-badge>
      </b-button>
    </div>
  </div>
</template>

<script>
import EditChatMessage from "./Actions/EditChatMessage";
import UserHelper from "@/helpers/UserHelper";
import EmojiPicker from "@/components/Emoji/EmojiPicker";
import moment from "moment";
import _ from "lodash";

export default {
  name: "ChatWindow",
  data() {
    return {
      Expanded: false,
      Message: "",
      ActiveChatId: null,

      GroupChatIndex: 0,

      INDEX_KEY: 0,
      INDEX_GROUP: 1
    };
  },
  components: {
    "edit-message": EditChatMessage,
    "emoji-picker": EmojiPicker
  },
  computed: {
    GroupChatsLoaded() {
      return this.$store.getters["chat/GetLoadingStatus"];
    },
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
    GetNewGroupChats() {
      return this.$store.getters["chat/GetNewGroupChats"];
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

      const ActiveChats = [...this.GetGroupChats.values()];
      const ActiveChatMembers = ActiveChats.map((a, b) => a.members);

      for (const members of ActiveChatMembers) {
        for (const member of members) {
          onlineUsers = onlineUsers.filter(x => x.id !== member.id);
        }
      }

      return onlineUsers;
    },
    GetAllUnreadMessages() {
      if (!this.GetUser) return;

      const ActiveChats = [...this.GetGroupChats.values()];
      const activeMessages = ActiveChats.map((a, b) => a.chatMessages);

      let unreadMessageCount = 0;

      const userId = this.GetUser.id;

      for (const messages of activeMessages) {
        messages.reduce((acum, val) => {
          if (val.senderId !== userId && !val.read) {
            ++unreadMessageCount;
          }
        }, unreadMessageCount);
      }

      return unreadMessageCount;
    }
  },
  methods: {
    async ToggleChatWindow() {
      this.Expanded = !this.Expanded;

      if (this.GetGroupChats.size > 0) {
        this.ActiveChatId = this.GetGroupChats.keys().next().value;
        await this.MarkAllMessagesAsRead(this.ActiveChatId);
        this.SetChatFocus();
      }
    },
    AppendEmoji(emoji) {
      this.Message += emoji;
    },
    EditMessage(message) {
      this.$refs.editMessageModal.show(this.ActiveChatId, message);
    },
    GetUnreadMessages(groupChat) {
      if (!groupChat) return;

      const activeMessages = groupChat.chatMessages;

      let unreadMessageCount = 0;

      const userId = this.GetUser.id;

      activeMessages.reduce((acum, val) => {
        if (val.senderId !== userId && !val.read) {
          ++unreadMessageCount;
        }
      }, unreadMessageCount);

      return unreadMessageCount;
    },
    SetActiveChatId(chat) {
      this.ActiveChatId = chat ? chat[this.INDEX_KEY] : null;
      if (this.ActiveChatId) {
        if (this.GetNewGroupChats.has(this.ActiveChatId)) {
          this.$store.commit("chat/ClearNewGroupChat", this.ActiveChatId);
        }
        this.MarkAllMessagesAsRead(this.ActiveChatId);
      }
    },
    GetGroupChatById(id) {
      return this.$store.getters["chat/GetGroupById"](id);
    },
    async MarkAllMessagesAsRead(groupChatId) {
      const groupChat = this.GetGroupChatById(groupChatId);
      if (groupChat && this.GetUnreadMessages(groupChat)) {
        await this.$store.dispatch("chat/MarkAllMessagesAsRead", {
          UserId: this.GetUser.id,
          Group: groupChat
        });

        this.$forceUpdate();
      }
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
    IsChatANewChat(groupChatId) {
      return this.GetNewGroupChats.has(groupChatId);
    },
    ScrollIntoView() {
      if (this.ActiveChatId) {
        const groupChatWindow = document.getElementById(
          `groupChatWindow-${this.ActiveChatId}`
        );
        if (groupChatWindow) {
          groupChatWindow.scrollTop = groupChatWindow.scrollHeight;
        }
      }
    },
    SetChatFocus() {
      const chatMessageBox = document.getElementById("chatmessage");
      if (chatMessageBox) {
        chatMessageBox.focus();
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

      const GroupId = this.ActiveChatId;
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
      this.SetChatFocus();
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
        const GroupId = this.ActiveChatId;
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
        this.SetActiveChatId(null);
      }
    },
    async FetchChatMessages() {
      if (!this.GroupChatsLoaded) {
        await this.$store.dispatch("chat/GetGroupChats");
      }
    }
  },
  watch: {
    GetGroupChats: _.debounce(function() {
      this.MarkAllMessagesAsRead(this.ActiveChatId);
      this.ScrollIntoView();
    }, 250),
    ActiveChatId: _.debounce(function() {
      this.ScrollIntoView();
    }, 500),
    GetAllUnreadMessages: function(val, old) {
      if (val > old) {
        this.MarkAllMessagesAsRead(this.ActiveChatId);
      }
    }
  },
  mounted() {
    this.FetchChatMessages();
  }
};
</script>

<style scoped>
.chat-background {
  border: 1px solid whitesmoke;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.open-button {
  opacity: 0.6;
  outline: inherit;
}

.close-button {
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

.chat-notification {
  position: absolute;
  left: 1px;
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
  margin-top: 0.195em;
  max-width: 100%;
}

.discussion > .bubble.sender {
  align-self: flex-start;
  color: aliceblue;
  background-color: slategray;
}
.discussion > .bubble.recipient {
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