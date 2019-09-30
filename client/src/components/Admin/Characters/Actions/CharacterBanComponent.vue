<template>
  <b-modal
    centered
    size="md"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Ban character ' + Character.name"
    ok-title="Save Ban Duration"
    header-bg-variant="info"
    @ok="SaveBan"
  >
    <b-container class="font-weight-bold">
      <b-form-group>
        <label>Duration</label>
        <date-picker
          id="ban-duration"
          name="ban-duration"
          v-model="Duration"
          :config="options"
          @dp-hide="SelectDuration"
          :class="{'form-control': true, 'error': errors.has('ban-duration') }"
          v-validate="'required|datetime'"
        ></date-picker>
        <b-tooltip placement="bottom" target="ban-duration">{{ getErrorMsg('ban-duration') }}</b-tooltip>
      </b-form-group>
      <b-form-group>
        <label>Reason</label>
        <b-textarea
          id="ban-reason"
          name="ban-reason"
          placeholder="Enter a specific reason"
          v-model="Reason"
          :class="{'form-control': true, 'error': errors.has('ban-reason') }"
          v-validate="'required|min:10|max:200'"
        ></b-textarea>
        <b-tooltip placement="bottom" target="ban-reason">{{ getErrorMsg('ban-reason') }}</b-tooltip>
      </b-form-group>
    </b-container>
  </b-modal>
</template>

<script>
import datePicker from "vue-bootstrap-datetimepicker";
import "pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css";

import moment from "moment";

export default {
  name: "CharacterBanComponent",
  props: ["realm"],
  data() {
    return {
      Character: null,
      ShowEditor: false,

      Duration: null,
      UnixTimestamp: 0,
      options: {
        format: "YYYY-MM-DD HH:mm:ss",
        useCurrent: true,
        showClear: true,
        showClose: true,
        toolbarPlacement: "bottom",
        sideBySide: false,
        widgetPositioning: {
          horizontal: "auto",
          vertical: "bottom"
        }
      },

      Reason: ""
    };
  },
  components: {
    "date-picker": datePicker
  },
  methods: {
    show(character) {
      this.Character = character;
      this.ShowEditor = true;
      this.Duration = moment();
      this.Reason = "";
    },
    getErrorMsg(field) {
      return this.errors.first(field);
    },
    SelectDuration(e) {
      const unix = moment(e.date).unix();
      this.UnixTimestamp = unix;
    },
    GetDuration(unix) {
      const then = moment(unix * 1000);
      return then.fromNow(true);
    },
    SaveBan(e) {
      e.preventDefault();

      this.$validator.validateAll().then(result => {
        if (result) {
          this.$bvModal
            .msgBoxConfirm(
              `Are you sure you wish to ban ${
                this.Character.name
              } for ${this.GetDuration(this.UnixTimestamp)}?`,
              {
                centered: true,
                okTitle: "Yes"
              }
            )
            .then(check => {
              if (check) {
                const Character = this.Character;
                const UnbanDate = this.UnixTimestamp;
                const Reason = this.Reason;
                const RealmType = this.realm.id;

                this.$store
                  .dispatch("admin/BanCharacter", {
                    Character,
                    UnbanDate,
                    Reason,
                    RealmType
                  })
                  .then(result => {
                    this.$root.ToastSuccess(
                      `${Character.name} has been banned for ${this.GetDuration(
                        UnbanDate
                      )}.`
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
  },
  computed: {},
  mounted() {
    this.$validator.extend("datetime", {
      getMessage: () =>
        "Please enter a valid duration. Minimum 30 minutes from now.",
      validate: value => {
        const now = moment(new Date(value)).unix();
        const min = moment()
          .add("30", "minutes")
          .unix();
        return now > min;
      }
    });
  }
};
</script>

<style scoped>
textarea {
  min-height: 300px;
  max-height: 600px;
}
</style>