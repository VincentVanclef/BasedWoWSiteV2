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
    <div class="form-group">
      <b-textarea
        id="new-comment"
        name="new comment"
        v-model="newComment.comment"
        v-validate="'required|min:10|max:200'"
        :class="{'form-control': true, 'error': errors.has('new comment') }"
        autofocus
      />
      <b-tooltip placement="auto" target="new-comment">{{ getErrorMsg('new comment') }}</b-tooltip>
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
    EditComment(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$store
            .dispatch("news/EditComment", this.newComment)
            .catch(e => this.toasted.error(this.$root.GetErrorMessage(e)))
            .then(result => {
              this.$toasted.success("Comment successfully edited");
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
  height: 50px;
  min-height: 50px;
  max-height: 100px;
}
</style>