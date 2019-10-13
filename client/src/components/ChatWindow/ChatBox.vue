<template>
  <div class="chat-window" v-if="IsLoggedIn">
    <div v-if="Expanded && GroupChatsLoaded" class="chat-background">
      <b-row no-gutters class="h-100">
        <b-col cols="3" class="chat-navigation">
          <chat-box-navigation :user="GetUser" />
        </b-col>
        <b-col cols="9" class="chat-discussion" id="chatDiscussion">
          <chat-box-discussion
            :user="GetUser"
            :isLoading="SearchLoadingStatus"
            :resultsCount="ResultsCount"
          />
        </b-col>
      </b-row>
    </div>
    <b-row no-gutters v-if="Expanded && GroupChatsLoaded">
      <b-col cols="3" class="new-chat">
        <b-button
          block
          variant="primary"
          class="new-chat-button close-button"
          @click="SetActiveChatId(null)"
          :class="{ 'active-tab': ActiveChatId == null }"
          v-b-tooltip.hover
          title="Start new chat"
        >
          <i class="fas fa-plus"></i>
        </b-button>
      </b-col>

      <b-col cols="9">
        <b-textarea
          v-if="ActiveChatId"
          id="chatmessage"
          name="chat message"
          type="text"
          v-model="Message"
          v-emojis="{ PosRight: 0.5 }"
          v-validate="'required|min:2|max:200'"
          :class="{ 'type_msg': true, 'error': errors.has('chat message')}"
          placeholder="Type your message..."
          @keydown.enter="SendNewMessage"
          @keydown.esc="ToggleChatWindow()"
        ></b-textarea>

        <b-input
          style="height: 62px;"
          v-if="!ActiveChatId"
          type="text"
          @input="IsTyping = true"
          v-model="SearchQuery"
          placeholder="Search user"
        />

        <b-tooltip
          v-if="errors.has('chat message')"
          placement="bottom"
          target="chatmessage"
        >{{ getErrorMsg('chat message') }}</b-tooltip>
      </b-col>
    </b-row>
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
import UserHelper from "@/helpers/UserHelper";
import EmojiPicker from "@/components/Emoji/EmojiPicker";
import moment from "moment";

import ChatBoxNaviation from "./ChatBoxNavigation";
import ChatBoxDiscussion from "./ChatBoxDiscussion";

import _ from "lodash";

export default {
  name: "ChatWindow",
  data() {
    return {
      Expanded: false,
      Message: "",
      SearchLoadingStatus: false,
      SearchQuery: "",
      ResultsCount: 0,
      SearchResults: [],

      IsTyping: false,

      INDEX_KEY: 0,
      INDEX_GROUP: 1
    };
  },
  components: {
    "emoji-picker": EmojiPicker,
    "chat-box-navigation": ChatBoxNaviation,
    "chat-box-discussion": ChatBoxDiscussion
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
    ActiveChatId() {
      return this.$store.getters["chat/GetActiveChatId"];
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
    GetSortedChats() {
      const chats = [...this.GetGroupChats.values()];
      return (
        this.GetGroupChats &&
        chats.sort((a, b) => (a.lastModified < b.lastModified ? 1 : -1))
      );
    },
    GetUsersNotAlreadyChattingWith() {
      let onlineUsers = [...this.SearchResults];

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
      return this.GroupChatsLoaded && unreadMessageCount;
    }
  },
  methods: {
    async ToggleChatWindow(forced) {
      this.Expanded = !this.Expanded;

      if (forced) {
        this.Expanded = true;
      }

      if (this.Expanded) {
        if (this.GetGroupChats.size > 0) {
          this.SetActiveChatId(this.GetSortedChats[0].id);
          await this.MarkAllMessagesAsRead(this.ActiveChatId);
          this.SetChatFocus();
          this.ScrollIntoView();
        }
      } else {
        this.SetActiveChatId(null);
      }
    },
    AppendEmoji(emoji) {
      this.Message += emoji;
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
    SetActiveChatId(id) {
      this.$store.commit("chat/SetActiveChat", id);
      if (this.ActiveChatId) {
        if (this.GetNewGroupChats.has(this.ActiveChatId)) {
          this.$store.commit("chat/ClearNewGroupChat", this.ActiveChatId);
        }
        this.MarkAllMessagesAsRead(this.ActiveChatId);
      } else {
        this.$nextTick(() => {
          this.$validator.reset();
        });
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
      if (date == "0001-01-01T00:00:00") return "Never";
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
    SetChatFocus() {
      const chatMessageBox = document.getElementById("chatmessage");
      if (chatMessageBox) {
        chatMessageBox.focus();
      }
    },
    UpdatePageTitle(val) {
      const documentTitle = document.title.replace(/[\(]+[0-9]+[\)]/g, "");
      if (val > 0) {
        document.title = `(${val}) ${documentTitle}`;
      } else {
        document.title = documentTitle;
      }
    },
    ScrollIntoView() {
      if (this.ActiveChatId) {
        const chatDiscussion = document.getElementById("chatDiscussion");
        const chatDiscussionWindow = document.getElementById(
          "chatDiscussionWindow"
        );
        if (chatDiscussion && chatDiscussionWindow) {
          chatDiscussion.scrollTop = chatDiscussionWindow.scrollHeight;
        }
      }
    },
    async CreateNewChatGroup(user) {
      const newGroupChat = await this.$store.dispatch("chat/CreateGroupChat", {
        Id: user.id,
        Email: user.email,
        Name: user.name
      });

      this.$root.ToastSuccess(
        `You have successfully started a new chat with ${user.name}!`,
        "Chat"
      );

      this.SetActiveChatId(newGroupChat.id);
    },
    async isFieldValid(field) {
      const result = await this.$validator.validate(field);
      return result;
    },
    async SendNewMessage(e) {
      e.preventDefault();
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

      this.Message = "";
      this.SetChatFocus();

      try {
        await this.$store.dispatch("chat/SendGroupChatMessage", {
          GroupId,
          Message
        });
      } catch (error) {
        this.$root.ToastError(error.toString(), "Chat Error");
      } finally {
        this.$nextTick(() => {
          this.$validator.reset();
        });
      }
    },
    async LeaveGroupChat(groupChat) {
      const check = await this.$bvModal.msgBoxConfirm(
        `Are you sure you wish to leave the chat with ${
          this.GetOtherMember(groupChat.members).name
        }?`,
        {
          centered: true,
          okTitle: "Yes"
        }
      );

      if (check) {
        if (!groupChat) {
          this.$root.ToastError(
            `Unable to locate chat with id: ${groupChat.id}`,
            "Chat Error"
          );
          return;
        }

        await this.$store.dispatch("chat/LeaveGroup", {
          UserId: this.GetUser.id,
          Group: groupChat
        });
        this.$root.ToastSuccess("You have left the chat.");
        this.SetActiveChatId(null);
      }
    },
    async FetchChatMessages() {
      if (!this.GroupChatsLoaded && this.GetUser) {
        await this.$store.dispatch("chat/GetGroupChats");
      }
    },
    async SearchUser(searchQuery) {
      this.SearchResults = [];
      this.ResultsCount = 0;
      this.SearchQuery = searchQuery;
      this.SearchLoadingStatus = true;
      try {
        await this.$store
          .dispatch("chat/SearchUsers", searchQuery)
          .then(result => {
            //this.isLoading = false;
            const { members, count } = result;
            this.ResultsCount = count;
            this.SearchResults = members;
          });
      } finally {
        this.SearchLoadingStatus = false;
      }
    }
  },
  watch: {
    GetAllUnreadMessages: function(val, old) {
      if (val > old) this.MarkAllMessagesAsRead(this.ActiveChatId);
      if (val !== old) this.UpdatePageTitle(val);
    },
    SearchQuery: _.debounce(function() {
      this.IsTyping = false;
    }, 1000),
    IsTyping: async function(value) {
      if (!value && this.SearchQuery.length > 0) {
        await this.SearchUser(this.SearchQuery);
      }
    }
  },
  mounted() {
    this.FetchChatMessages();
  },
  created() {
    this.$root.$on("GroupChatInviteSuccessful", () => {
      this.ToggleChatWindow(true);
    });
    this.$root.$on("GroupChatLeaveSuccessful", groupId => {
      this.ToggleChatWindow(true);
      if (this.ActiveChatId === groupId) {
        this.SetActiveChatId(null);
      }
    });
  }
};
</script>

<style scoped>
.chat-background {
  border: 1px solid;
  background-color: whitesmoke;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
  height: 400px;
}

.chat-navigation {
  background-color: #6c757d;
  max-height: 100%;
  overflow: auto;
}

.chat-discussion {
  max-height: 100%;
  overflow: auto;
  padding: 2px;
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

.type_msg {
  resize: none;
  overflow-y: auto;
}

.send_btn {
  cursor: pointer;
}

.new-chat {
  color: #343a40;
}

.new-chat-button {
  height: 100%;
  font-size: 20px;
}

.chat-message-inputs {
  border: none;
  height: 50px;
}
</style>