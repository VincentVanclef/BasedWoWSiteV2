<template>
  <section id="chatDiscussionWindow">
    <div v-if="ActiveChat" class="discussion">
      <div
        v-for="msg in ActiveChat.chatMessages"
        :key="msg.id"
        :class="msg.senderId === user.id ? 'bubble recipient middle' : 'bubble sender middle'"
        v-contextmenu.chatmessage="{ Message: msg }"
        v-b-tooltip.hover
        :title="GetDate(msg.dateTime)"
      >
        {{msg.message}}
        <small v-if="msg.senderId === user.id && !msg.read">
          <i class="fas fa-hourglass-half"></i>
        </small>
      </div>
    </div>
    <div v-if="!ActiveChat">
      <div v-if="isLoading" class="center-content">
        <b-spinner variant="success" label="Spinning"></b-spinner>
      </div>

      <div v-if="!isLoading">
        <div class="text-center font-weight-bold bg-info p-2">
          Found {{resultsCount}} members.
          <br />
          {{GetUsersNotAlreadyChattingWith.length}} are available for chat.
        </div>

        <hr />

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
      </div>
    </div>
    <edit-message ref="editMessageModal" />
  </section>
</template>

<script>
import EditChatMessage from "./Actions/EditChatMessage";

export default {
  name: "ChatBoxDiscussion",
  props: ["user", "isLoading", "resultsCount"],
  data() {
    return {};
  },
  components: {
    "edit-message": EditChatMessage
  },
  computed: {
    ActiveChat() {
      return this.$store.getters["chat/GetActiveChat"];
    },
    ActiveChatId() {
      return this.$store.getters["chat/GetActiveChatId"];
    },
    GetGroupChats() {
      return this.$store.getters["chat/GetGroupChats"];
    },
    ChatBoxController() {
      return this.$parent;
    },
    GetUsersNotAlreadyChattingWith() {
      return this.ChatBoxController.GetUsersNotAlreadyChattingWith;
    }
  },
  methods: {
    EditMessage(message) {
      this.$refs.editMessageModal.show(this.ActiveChat.id, message);
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
    IsMessageOwner(senderId) {
      return this.ChatBoxController.IsMessageOwner(senderId);
    },
    ScrollIntoView() {
      return this.ChatBoxController.ScrollIntoView();
    },
    async CreateNewChatGroup(user) {
      await this.ChatBoxController.CreateNewChatGroup(user);
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
    }
  },
  watch: {
    GetGroupChats: _.debounce(function() {
      this.ScrollIntoView();
    }, 200),
    ActiveChatId: _.debounce(function() {
      this.ScrollIntoView();
    }, 200)
  }
};
</script>

<style scoped>
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