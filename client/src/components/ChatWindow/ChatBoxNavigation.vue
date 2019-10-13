<template>
  <ul class="sidenav__tabs">
    <li
      class="sidenav__tab"
      v-for="chat in GetSortedChats"
      :key="chat.id"
      @click="SetActiveChatId(chat.id)"
      :class="{ 'active-tab': GetActiveChatId == chat.id }"
    >
      <vue-gravatar
        :id="'group-chat-' + chat.id"
        class="rounded-circle user_img"
        :class="{'border-danger': IsAdmin(GetOtherMember(chat.members).id), 'border-primary': IsModerator(GetOtherMember(chat.members).id) }"
        :email="GetOtherMember(chat.members).email"
        alt="Gravatar"
        default-img="https://i.imgur.com/0AwrvCm.jpg"
        v-contextmenu.groupchat="{ GroupId: chat.id, User: GetOtherMember(chat.members) }"
      />
      <b-tooltip :target="'group-chat-' + chat.id" placement="right" boundary="window">
        <span class="text-capitalize">{{GetOtherMember(chat.members).name}}</span>
        <br />
        <small>Last Activity: {{GetDate(GetOtherMember(chat.members).lastAccessed)}}</small>
      </b-tooltip>
      <b-badge v-if="IsChatANewChat(chat.id)" variant="danger" class="chat-notification">!</b-badge>
      <b-badge
        v-if="!IsChatANewChat(chat.id) && GetUnreadMessages(chat)"
        variant="danger"
        class="chat-notification"
      >{{GetUnreadMessages(chat)}}</b-badge>
    </li>
  </ul>
</template>

<script>
export default {
  name: "ChatBoxNavigation",
  props: ["user"],
  data() {
    return {};
  },
  computed: {
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
    GetActiveChatId() {
      return this.$store.getters["chat/GetActiveChatId"];
    },
    ChatBoxController() {
      return this.$parent;
    }
  },
  methods: {
    SetActiveChatId(id) {
      return this.ChatBoxController.SetActiveChatId(id);
    },
    GetDate(date) {
      return this.ChatBoxController.GetDate(date);
    },
    IsAdmin(userId) {
      return this.ChatBoxController.IsAdmin(userId);
    },
    IsModerator(userId) {
      return this.ChatBoxController.IsModerator(userId);
    },
    GetOtherMember(members) {
      return this.ChatBoxController.GetOtherMember(members);
    },
    GetUnreadMessages(groupChat) {
      return this.ChatBoxController.GetUnreadMessages(groupChat);
    },
    IsChatANewChat(id) {
      return this.ChatBoxController.IsChatANewChat(id);
    },
    async LeaveGroupChat(groupChat) {
      await this.ChatBoxController.LeaveGroupChat(groupChat);
    }
  },
  watch: {
    GetSortedChats: function(val, old) {
      this.$forceUpdate();
    }
  }
};
</script>

<style scoped>
.sidenav__tabs {
  text-align: center;
  background-color: #6c757d;
  box-shadow: 1px 1px 3px 0 rgba(0, 0, 0, 0.3);
}
.sidenav__tab {
  align-self: flex-start;
  list-style-type: none;
  /*   border-bottom: 1px solid #ccc; */
  padding: 0.4em;
  color: #eee;
  letter-spacing: 0;
  transition: all 300ms;
}

.sidenav__tab:hover {
  background-color: #343a40;
  cursor: pointer;
  box-shadow: 0 5px 5px -2px rgba(0, 0, 0, 0.22);
}

.sidenav__tabs:last-child {
  margin-bottom: 0 !important;
}

.sidenav__tab__info {
  font-size: 0.65em;
  margin-top: 3px;
  color: #ccc;
  font-style: italic;
  letter-spacing: 0;
}
.active-tab {
  background-color: #f8f9fa;
  box-shadow: 0 5px 5px -2px rgba(0, 0, 0, 0.22);
}

.user_img {
  height: 75%;
  width: 75%;
  border: 2px solid #f5f6fa;
}

.chat-notification {
  position: absolute;
  left: 1px;
}
</style>