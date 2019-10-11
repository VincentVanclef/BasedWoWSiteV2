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
          :sort-by.sync="SortBy"
          :sort-desc="true"
          :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
          :tbody-tr-class="ActiveColor"
        >
          <template v-slot:cell(active)="data">{{data.value === 1 ? 'Yes' : 'No'}}</template>
          <template v-slot:cell(banDate)="data">{{GetDate(data.value)}}</template>
          <template v-slot:cell(unbanDate)="data">{{GetDate(data.value)}}</template>
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
      SortBy: "banDate",
      TableFields: [
        // {
        //   key: "accountId",
        //   label: "Account Id",
        //   sortable: true
        // },
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
    },
    ActiveColor(item, type) {
      return item.active === 1 ? "table-danger" : "";
    }
  }
};
</script>