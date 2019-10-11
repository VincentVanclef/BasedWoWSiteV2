<template>
  <b-modal
    centered
    size="md"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Mute Account ' + Account.username"
    ok-title="Save Mute Duration"
    header-bg-variant="info"
    @ok="SaveMute"
  >
    <b-container class="font-weight-bold">
      <b-form-group>
        <label>Duration (Minutes)</label>
        <b-input
          id="mute-duration"
          name="mute-duration"
          type="number"
          v-model="MuteMinutes"
          :class="{'form-control': true, 'error': errors.has('mute-duration') }"
          v-validate="'required|numeric|between:5,10080'"
        ></b-input>
        <b-tooltip v-if="errors.has('mute-duration')" placement="bottom" target="mute-duration">{{ getErrorMsg('mute-duration') }}</b-tooltip>
      </b-form-group>
      <b-form-group>
        <label>Reason</label>
        <b-textarea
          id="mute-reason"
          name="mute-reason"
          placeholder="Enter a specific reason"
          v-model="Reason"
          :class="{'form-control': true, 'error': errors.has('mute-reason') }"
          v-validate="'required|min:10|max:200'"
        ></b-textarea>
        <b-tooltip v-if="errors.has('mute-reason')" placement="bottom" target="mute-reason">{{ getErrorMsg('mute-reason') }}</b-tooltip>
      </b-form-group>
    </b-container>
  </b-modal>
</template>

<script>
import moment from "moment";

export default {
  name: "AccountMuteComponent",
  data() {
    return {
      Account: null,
      ShowEditor: false,

      MuteMinutes: 0,
      Reason: ""
    };
  },
  methods: {
    show(account) {
      this.Account = account;
      this.ShowEditor = true;
      this.MuteMinutes = 0;
      this.Reason = "";
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    SaveMute(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$bvModal
            .msgBoxConfirm(
              `Are you sure you wish to mute ${this.Account.username} for ${this.MuteMinutes} minutes?`,
              {
                centered: true,
                okTitle: "Yes"
              }
            )
            .then(check => {
              if (check) {
                const Account = this.Account;
                const MuteMinutes = this.MuteMinutes;
                const Reason = this.Reason;

                this.$store
                  .dispatch("admin/MuteAccount", {
                    Account,
                    MuteMinutes,
                    Reason
                  })
                  .then(result => {
                    this.$root.ToastSuccess(
                      `${Account.username} has been muted for ${MuteMinutes} minutes.`
                    );
                  })
                  .finally(() => {
                    this.ShowEditor = false;
                  });
              }
            });
        }
      });
    }
  }
};
</script>

<style scoped>
textarea {
  min-height: 100px;
  max-height: 300px;
}
</style>