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
    <div class="form-group">
      <b-textarea
        id="new-message"
        name="new message"
        v-model="NewMessage.message"
        v-validate="'required|min:2|max:200'"
        :class="{'form-control': true, 'error': errors.has('new message') }"
        autofocus
      />
      <b-tooltip placement="auto" target="new-message">{{ getErrorMsg('new message') }}</b-tooltip>
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
      ShowEditor: false
    };
  },
  methods: {
    show(groupId, message) {
      this.GroupId = groupId;
      this.NewMessage = Object.assign({}, message);
      this.ShowEditor = true;
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
