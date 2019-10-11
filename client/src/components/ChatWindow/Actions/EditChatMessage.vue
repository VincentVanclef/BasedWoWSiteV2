<template>
  <b-modal
    centered
    v-if="ShowEditor"
    v-model="ShowEditor"
    title="Edit Message"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="EditMessage"
  >
    <div class="input-group position-relative inline-block">
      <textarea
        id="new-message"
        name="new message"
        v-model="NewMessage.message"
        v-validate="'required|min:2|max:200'"
        :class="{'regular-input': true, 'error': errors.has('new message') }"
        v-emojis
        autofocus
      />
      <b-tooltip
        v-if="errors.has('new message')"
        placement="auto"
        target="new-message"
      >{{ getErrorMsg('new message') }}</b-tooltip>
    </div>
  </b-modal>
</template>


<script>
export default {
  props: ["message"],
  data() {
    return {
      NewMessage: null,
      GroupId: 0,
      Group: null,
      ShowEditor: false
    };
  },
  methods: {
    show(groupId, messageId) {
      this.GroupId = groupId;
      this.Group = this.GetGroupChatById(groupId);
      const message = this.Group.chatMessages.find(x => x.id === messageId);
      this.NewMessage = Object.assign({}, message);
      this.ShowEditor = true;
    },
    AppendEmoji(emoji) {
      this.NewMessage.message += emoji;
    },
    GetGroupChatById(id) {
      return this.$store.getters["chat/GetGroupById"](id);
    },
    EditMessage(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$store
            .dispatch("chat/EditMessage", {
              GroupId: this.GroupId,
              Message: this.NewMessage
            })
            .then(result => {
              this.$root.ToastSuccess("Message successfully edited");
            })
            .finally(() => {
              this.$bvModal.hide("new-shout");
              this.ShowEditor = false;
            });
        }
      });
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    }
  }
};
</script>

<style scoped>
textarea {
  height: 100px;
  min-height: 100px;
  max-height: 200px;
}
</style>
