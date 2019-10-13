<template>
  <b-modal
    centered
    v-if="showEditor"
    v-model="showEditor"
    title="Edit Shout"
    ok-title="Save Changes"
    header-bg-variant="info"
    @ok="EditShout"
  >
    <div class="input-group position-relative inline-block">
      <textarea
        id="new-shout"
        name="new shout"
        v-model="newShout.message"
        v-validate="'required|min:10|max:200'"
        :class="{'regular-input': true, 'error': errors.has('new shout') }"
        v-emojis="{ PosRight: 0.5 }"
        autofocus
      />
      <b-tooltip
        v-if="errors.has('new shout')"
        placement="auto"
        target="new-shout"
      >{{ getErrorMsg('new shout') }}</b-tooltip>
    </div>
  </b-modal>
</template>


<script>
export default {
  props: ["shout"],
  data() {
    return {
      newShout: null,
      showEditor: false
    };
  },
  methods: {
    show(shout) {
      this.newShout = Object.assign({}, shout);
      this.showEditor = true;
    },
    AppendEmoji(emoji) {
      this.newShout.message += emoji;
    },
    EditShout(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$store
            .dispatch("shoutbox/EditShout", this.newShout)
            .then(result => {
              this.$root.ToastSuccess("Shout successfully edited");
            })
            .finally(() => {
              this.$bvModal.hide("new-shout");
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
