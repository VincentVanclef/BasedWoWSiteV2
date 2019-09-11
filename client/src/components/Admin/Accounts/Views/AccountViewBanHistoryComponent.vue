<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Ban History for ' + Account.username"
    header-bg-variant="info"
  >
    <b-container class="font-weight-bold">
      <b-form-group>
        <b-table
          bordered
          striped
          responsive
          :items="Account.accountBanned"
          :fields="TableFields"
          :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
        >
          <span slot="active" slot-scope="data">{{data.value === 1 ? 'Yes' : 'No'}}</span>
          <span slot="banDate" slot-scope="data">{{GetDate(data.value)}}</span>
          <span slot="unbanDate" slot-scope="data">{{GetDate(data.value)}}</span>
        </b-table>
      </b-form-group>
    </b-container>
  </b-modal>
</template>

<script>
import moment from "moment";

export default {
  name: "AccountViewBanHistory",
  data() {
    return {
      ShowEditor: false,
      Account: null,
      TableFields: [
        {
          key: "accountId",
          label: "Account Id",
          sortable: true
        },
        {
          key: "bannedBy",
          label: "banned By",
          sortable: true
        },
        {
          key: "banReason",
          label: "Ban Reason",
          sortable: true
        },
        {
          key: "banDate",
          label: "Ban Date",
          sortable: true
        },
        {
          key: "unbanDate",
          label: "Unban Date",
          sortable: true
        },
        {
          key: "active",
          label: "Active",
          sortable: true
        }
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
    }
  }
};
</script>