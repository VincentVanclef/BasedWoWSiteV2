<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Mute History for ' + Account.username"
    header-bg-variant="info"
  >
    <b-container class="font-weight-bold">
      <b-form-group>
        <b-table
          bordered
          striped
          responsive
          :items="Account.accountMuted"
          :fields="TableFields"
          :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
          :sort-by.sync="SortBy"
          :sort-desc="true"
          :tbody-tr-class="ActiveColor"
        >
          <span slot="Active" slot-scope="data">{{IsMuteActive(data.item) ? 'Yes' : 'No'}}</span>
          <span slot="muteDate" slot-scope="data">{{GetDate(data.value)}}</span>
          <span slot="muteTime" slot-scope="data">{{GetMuteDuration(data.value)}}</span>
        </b-table>
      </b-form-group>
    </b-container>
  </b-modal>
</template>

<script>
import moment from "moment";
import { SecsToTimeString } from "@/helpers/MethodHelper";

export default {
  name: "AccountViewBanHistory",
  data() {
    return {
      ShowEditor: false,
      Account: null,
      SortBy: "muteDate",
      TableFields: [
        // {
        //   key: "accountId",
        //   label: "Account Id",
        //   sortable: true
        // },
        {
          key: "mutedBy",
          label: "Muted By",
          sortable: true
        },
        {
          key: "muteReason",
          label: "Mute Reason",
          sortable: true
        },
        {
          key: "muteDate",
          label: "Mute Date",
          sortable: true
        },
        {
          key: "muteTime",
          label: "Mute Duration",
          sortable: true
        },
        "Active"
      ]
    };
  },
  methods: {
    show(account) {
      this.Account = account;
      this.ShowEditor = true;
    },
    GetDate(unix) {
      const date = moment(unix * 1000);
      return date.format("MM/D/YYYY HH:mm:ss");
    },
    GetMuteDuration(data) {
      return SecsToTimeString(data * 60);
    },
    IsAccountMuted() {
      const muteTime = this.Account.muteTime * 1000;
      const now = moment().unix();
      return muteTime !== 0 && muteTime < now;
    },
    IsMuteActive(data) {
      const startUnix = data.muteDate * 1000;
      const duration = data.muteTime * 60 * 1000;
      const endDate = moment(startUnix + duration);
      const now = moment();
      return now < endDate && this.IsAccountMuted();
    },
    ActiveColor(item, type) {
      return this.IsMuteActive(item) ? "table-danger" : "";
    }
  }
};
</script>