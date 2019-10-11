<template>
  <b-modal
    centered
    size="xl"
    v-if="ShowEditor"
    v-model="ShowEditor"
    :title="'Ban History for ' + Character.name"
    header-bg-variant="info"
  >
    <b-container class="font-weight-bold">
      <div v-if="Loading" class="text-center mt-4">
        <b-spinner style="width: 3rem; height: 3rem;" variant="primary" label="Spinning"></b-spinner>
      </div>
      <b-table
        v-if="!Loading"
        bordered
        striped
        responsive
        :items="Character.characterBanned"
        :fields="TableFields"
        :sort-compare-options="{ numeric: true, sensitivity: 'base' }"
        :sort-by.sync="SortBy"
        :sort-desc="true"
        :tbody-tr-class="ActiveColor"
        class="ban-history"
      >
        <template v-slot:cell(active)="data">{{data.value === 1 ? 'Yes' : 'No'}}</template>
        <template v-slot:cell(banDate)="data">{{GetDate(data.value)}}</template>
        <template v-slot:cell(unbanDate)="data">{{GetDate(data.value)}}</template>
      </b-table>
    </b-container>
  </b-modal>
</template>

<script>
import moment from "moment";

export default {
  name: "AccountViewBanHistory",
  props: ["realm"],
  data() {
    return {
      Loading: false,
      ShowEditor: false,
      Character: null,
      SortBy: "active",
      TableFields: [
        // {
        //   key: "guid",
        //   label: "Guid",
        //   sortable: true
        // },
        {
          key: "bannedBy",
          label: "Banned By",
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
    show(character) {
      this.Character = character;
      this.BanHistory = null;
      this.ShowEditor = true;
      this.GetBanHistory();
    },
    GetDate(unix) {
      const date = moment(unix * 1000);
      return date.format("MM/D/YYYY HH:mm:ss");
    },
    ActiveColor(item, type) {
      return item.active === 1 ? "table-danger" : "";
    },
    async GetBanHistory() {
      this.Loading = true;

      await this.$store.dispatch("user/characters/GetBanHistory", {
        Character: this.Character,
        RealmType: this.realm.id
      });

      this.Loading = false;
    }
  }
};
</script>

<style scoped>
.ban-history {
  max-height: 500px;
  overflow: auto;
}
</style>