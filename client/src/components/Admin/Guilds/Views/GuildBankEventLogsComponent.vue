<template>
  <b-modal
    centered
    size="xl"
    id="guild-bank-logs-modal"
    v-if="ShowModal && BankTab"
    v-model="ShowModal"
    @hide="CloseModal()"
    :title="`${guild.name}'s Vault > ${BankTab.tabName} > Logs`"
    header-text-variant="white"
    header-bg-variant="dark"
  >
    <b-container class="bank-logs-container">
      <b-row class="inventory-stats mb-3">
        <b-col sm="12" md="12" lg="3" class="mb-3">
          <label class="control-label">Search Logs</label>
          <b-input
            type="text"
            id="log_search_char_name"
            name="search character"
            @input="isTyping = true"
            v-model="searchQueryCharacter"
            placeholder="Character name"
            v-validate="'max:50'"
            :class="{'form-control': true, 'error': errors.has('search character') }"
          />
          <b-tooltip
            placement="bottom"
            target="log_search_char_name"
          >{{ errors.first('search character') }}</b-tooltip>
          <b-input
            type="text"
            id="log_search_item_name"
            name="search item"
            @input="isTyping = true"
            v-model="searchQueryItem"
            placeholder="Item name"
            v-validate="'max:50'"
            class="mt-2"
            :class="{'form-control': true, 'error': errors.has('search item') }"
          />
          <b-tooltip
            placement="bottom"
            target="log_search_item_name"
          >{{ errors.first('search item') }}</b-tooltip>
        </b-col>
        <b-col cols="6" md="6" lg="3">
          <label class="control-label">Search Event Types</label>
          <b-form-select
            v-model="SelectedEventTypes"
            multiple
            :select-size="3"
            @change="isTyping = true"
          >
            <option v-for="type in LogTypesArray" :key="type.id" :value="type.id">{{ type.name }}</option>
          </b-form-select>
        </b-col>
        <b-col cols="6" md="6" lg="3">
          <label class="control-label">Sort By</label>
          <b-form-radio-group
            stacked
            v-model="SelectedSort"
            :options="SortOptions"
            @change="isTyping = true"
          ></b-form-radio-group>
        </b-col>
        <b-col cols="6" md="6" lg="3" class="d-flex flex-column-reverse">
          <b-button block variant="dark" class="mt-3" @click="ClearFilter()">Clear Filter</b-button>
        </b-col>
      </b-row>
      <b-row class="full-width text-center">
        <div v-if="Loading" class="center-content">
          <b-spinner style="width: 4rem; height: 4rem;" variant="primary" label="Spinning"></b-spinner>
        </div>

        <b-list-group class="bank-log-view">
          <b-list-group-item
            class="bg-dark text-white"
            v-for="log in searchResult"
            :key="log.logGuid"
          >
            <a
              :href="`/armory/characters/search/?realm=${realm.id}&query=${log.playerName}`"
              target="_blank"
            >
              <font color="orange">{{log.playerName}}</font>
            </a>
            <span v-if="log.eventType === LogTypes.DEPOSIT_ITEM">
              deposited
              <span v-itemtooltip="{item: log.item, realm: realm}">
                <font :color="GetQuality(log.item.quality)">[{{log.item.name}}]</font>
              </span>
              x {{log.itemStackCount}}
            </span>
            <span v-if="log.eventType === LogTypes.WITHDRAW_ITEM">
              <font color="red">withdrew</font>
              <span v-itemtooltip="{item: log.item, realm: realm}">
                <font :color="GetQuality(log.item.quality)">[{{log.item.name}}]</font>
              </span>
              x {{log.itemStackCount}}
            </span>
            <span v-if="log.eventType === LogTypes.MOVE_ITEM">
              moved
              <span v-itemtooltip="{item: log.item, realm: realm}">
                <font :color="GetQuality(log.item.quality)">[{{log.item.name}}]</font>
              </span>
              x {{log.itemStackCount}} from {{BankTab.tabName}} to {{GetOtherBankTab(log.destTabId)}}
            </span>
            <font color="teal">({{GetLogDate(log.timeStamp)}})</font>
          </b-list-group-item>
        </b-list-group>
      </b-row>
    </b-container>
    <template v-slot:modal-footer>
      <div class="w-100">
        <span class="float-left font-weight-bold">
          <ul class="list-inline list-unstyled mb-1"></ul>
          <li class="list-inline-item">
            Total Logs:
            <b-badge variant="primary">{{Logs.length}}</b-badge>
          </li>
          <li class="list-inline-item">
            Filtered Logs:
            <b-badge variant="primary">{{searchResult.length}}</b-badge>
          </li>
        </span>
        <b-button variant="primary" class="float-right" @click="CloseModal()">Close</b-button>
      </div>
    </template>
  </b-modal>
</template>

<script>
import ItemQualities from "@/services/itemService/ItemQualities";
import moment from "moment";
import _ from "lodash";

export default {
  name: "GuildBankViewComponent",
  props: ["guild", "realm"],
  data() {
    return {
      ShowModal: false,
      Loading: false,
      BankTab: null,
      Logs: [],

      LogTypes: {
        DEPOSIT_ITEM: 1,
        WITHDRAW_ITEM: 2,
        MOVE_ITEM: 3
      },

      LogTypesArray: [
        { id: 1, name: "Deposit" },
        { id: 2, name: "Withdraw" },
        { id: 3, name: "Move" }
      ],

      searchQueryCharacter: "",
      searchQueryItem: "",

      searchResult: [],
      isTyping: false,

      SelectedEventTypes: [],

      SelectedSort: null,

      SortOptions: [
        {
          text: "No Sort",
          value: null
        },
        {
          text: "Character",
          value: {
            sort: (logA, logB) => (logA.playerName > logB.playerName ? 1 : -1)
          }
        },
        {
          text: "Event Type",
          value: {
            sort: (logA, logB) => (logA.eventType > logB.eventType ? 1 : -1)
          }
        },
        {
          text: "Log Time",
          value: {
            sort: (logA, logB) => (logA.timeStamp < logB.timeStamp ? 1 : -1)
          }
        }
      ]
    };
  },
  watch: {
    searchQueryCharacter: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    searchQueryItem: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    SelectedEventTypes: _.debounce(function() {
      this.isTyping = false;
    }, 1500),
    SelectedSort: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    isTyping: function(value) {
      if (!value) {
        this.ApplySearchFilter();
      }
    }
  },
  computed: {
    BankTabs() {
      return this.$store.getters["user/guild/GetGuildBanktabs"];
    }
  },
  methods: {
    async show(bankTab) {
      this.BankTab = bankTab;
      this.ShowModal = true;
      this.ApplyQuery();
      console.log("opened");
      await this.GetLogsForBankTab();
    },
    OpenModal() {},
    CloseModal() {
      this.Logs = [];
      this.searchResult = [];
      this.ClearFilter();
      this.ShowModal = false;
    },
    async GetLogsForBankTab() {
      this.Loading = true;

      try {
        const logs = await this.$store.dispatch(
          "user/guild/GetGuildBankEventLogs",
          {
            GuildId: this.guild.id,
            TabId: this.BankTab.tabId,
            RealmType: this.realm.id,
            EventTypes: [
              this.LogTypes.DEPOSIT_ITEM,
              this.LogTypes.WITHDRAW_ITEM,
              this.LogTypes.MOVE_ITEM
            ]
          }
        );

        this.Logs = logs.sort((logA, logB) =>
          logA.timeStamp < logB.timeStamp ? 1 : -1
        );

        this.searchResult = [...this.Logs];
      } finally {
        this.Loading = false;
      }
    },
    GetQuality(quality) {
      return ItemQualities.GetQuality(quality);
    },
    GetLogDate(timestamp) {
      return moment(timestamp * 1000).fromNow();
    },
    GetOtherBankTab(tab) {
      const otherTab = this.BankTabs.find(x => x.tabId == tab);
      return otherTab ? otherTab.tabName : "Unknown Tab";
    },
    ApplySearchFilter() {
      let logs = [...this.Logs];

      const filterByCharacter = this.searchQueryCharacter;
      const filterByItem = this.searchQueryItem;

      // Filter by character
      if (filterByCharacter.length > 0) {
        logs = logs.filter(log =>
          log.playerName.toLowerCase().includes(filterByCharacter.toLowerCase())
        );
      }

      if (filterByItem.length > 0) {
        logs = logs.filter(log =>
          log.item.name.toLowerCase().includes(filterByItem.toLowerCase())
        );
      }

      if (this.SelectedEventTypes.length > 0) {
        logs = logs.filter(log =>
          this.SelectedEventTypes.includes(log.eventType)
        );
      }

      if (this.SelectedSort) {
        logs = logs.sort(this.SelectedSort.sort);
      }

      this.searchResult = logs;
    },
    ClearFilter() {
      this.SelectedSort = null;
      this.SelectedEventTypes = [];
      this.searchQueryCharacter = "";
      this.searchQueryItem = "";
      this.ApplySearchFilter();
      this.ClearQuery();
    },
    ApplyQuery() {
      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign({}, QUERY, {
          showTabLog: this.BankTab.tabId
        })
      });
    },
    ClearQuery() {
      const QUERY = this.$route.query;

      this.$router.replace({
        query: Object.assign({}, QUERY, {
          showTabLog: undefined
        })
      });
    }
  }
};
</script>

<style scoped>
.bank-logs-container {
  min-height: 300px;
  width: 100%;
}

.bank-log-view {
  position: relative;
  height: 500px;
  overflow: auto;
  width: 100%;
}

.inventory-stats {
  font-family: "Trebuchet MS", "Lucida Sans Unicode", "Lucida Grande",
    "Lucida Sans", Arial, sans-serif;
}
</style>