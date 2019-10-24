<template>
  <b-modal
    centered
    v-if="showEditor"
    v-model="showEditor"
    title="Edit Comment"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="EditComment"
  >
    <div class="input-group position-relative inline-block">
      <textarea
        id="new-comment"
        name="new comment"
        v-model="newComment.comment"
        v-validate="'required|min:10|max:200'"
        :class="{'regular-input': true, 'error': errors.has('new shout') }"
        v-emojis="{ PosRight: 0.5 }"
        autofocus
      />
      <b-tooltip
        v-if="errors.has('new comment')"
        placement="auto"
        target="new-comment"
      >{{ getErrorMsg('new comment') }}</b-tooltip>
    </div>
  </b-modal>
</template>

<script>
export default {
  props: ["comment"],
  data() {
    return {
      newComment: null,
      showEditor: false
    };
  },
  methods: {
    show(comment) {
      this.newComment = Object.assign({}, comment);
      this.showEditor = true;
    },
    AppendEmoji(emoji) {
      this.newComment.comment += emoji;
    },
    EditComment(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$store
            .dispatch("news/EditComment", this.newComment)
            .then(result => {
              this.$root.ToastSuccess("Comment successfully edited");
            })
            .finally(() => {
              this.$bvModal.hide("new-comment");
              this.showEditor = false;
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