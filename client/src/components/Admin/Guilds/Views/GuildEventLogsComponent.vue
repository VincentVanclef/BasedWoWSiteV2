<template>
  <b-modal
    centered
    size="xl"
    id="guild-event-logs-modal"
    v-if="ShowModal"
    v-model="ShowModal"
    @hide="CloseModal()"
    :title="`${guild.name}'s > Event Logs`"
    header-text-variant="white"
    header-bg-variant="dark"
  >
    <b-container class="bank-logs-container">
      <b-row class="inventory-stats mb-3">
        <b-col sm="12" md="12" lg="3" class="mb-3">
          <label class="control-label">Search Logs</label>
          <b-input
            type="text"
            id="log_search_actor"
            name="search actor"
            @input="isTyping = true"
            v-model="searchQueryActor"
            placeholder="Actor name"
            v-validate="'max:50'"
            :class="{'form-control': true, 'error': errors.has('search actor') }"
          />
          <b-tooltip placement="bottom" target="log_search_actor">{{ errors.first('search actor') }}</b-tooltip>
          <b-input
            type="text"
            id="log_search_target"
            name="search target"
            @input="isTyping = true"
            v-model="searchQueryTarget"
            placeholder="Target name"
            v-validate="'max:50'"
            class="mt-2"
            :class="{'form-control': true, 'error': errors.has('search target') }"
          />
          <b-tooltip
            placement="bottom"
            target="log_search_target"
          >{{ errors.first('search target') }}</b-tooltip>
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
              <font color="orange">{{log.playerName1}}</font>
            </a>
            <span v-if="log.eventType === LogTypes.INVITE_PLAYER">
              invites
              <font color="orange">{{log.playerName2}}</font>
            </span>
            <span v-if="log.eventType === LogTypes.JOIN_GUILD">joins the guild</span>
            <span v-if="log.eventType === LogTypes.PROMOTE_PLAYER">
              promotes
              <font color="orange">{{log.playerName2}}</font>
              to
              <font color="steel">{{GetRankName(log.newRank)}}</font>
            </span>
            <span v-if="log.eventType === LogTypes.DEMOTE_PLAYER">
              demotes
              <font color="orange">{{log.playerName2}}</font>
              to
              <font color="steel">{{GetRankName(log.newRank)}}</font>
            </span>
            <span v-if="log.eventType === LogTypes.UNINVITE_PLAYER">
              removes
              <font color="orange">{{log.playerName2}}</font>
              from the guild
            </span>
            <span v-if="log.eventType === LogTypes.LEAVE_GUILD">leaves the guild</span>
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
import moment from "moment";
import _ from "lodash";

export default {
  name: "GuildEventLogsComponent",
  props: ["guild", "realm"],
  data() {
    return {
      ShowModal: false,
      Loading: false,
      Logs: [],

      LogTypes: {
        INVITE_PLAYER: 1,
        JOIN_GUILD: 2,
        PROMOTE_PLAYER: 3,
        DEMOTE_PLAYER: 4,
        UNINVITE_PLAYER: 5,
        LEAVE_GUILD: 6
      },

      LogTypesArray: [
        { id: 1, name: "Invited" },
        { id: 2, name: "Joined" },
        { id: 3, name: "Promoted" },
        { id: 4, name: "Demoted" },
        { id: 5, name: "Uninvited" },
        { id: 6, name: "Left Guild" }
      ],

      searchQueryActor: "",
      searchQueryTarget: "",

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
    searchQueryActor: _.debounce(function() {
      this.isTyping = false;
    }, 1000),
    searchQueryTarget: _.debounce(function() {
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
    GuildRanks() {
      return this.guild.guildRanks;
    }
  },
  methods: {
    async show() {
      this.ShowModal = true;
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
          "user/guild/GetGuildEventLogs",
          {
            GuildId: this.guild.id,
            RealmType: this.realm.id
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
    GetRankName(rankId) {
      const rank = this.GuildRanks.find(x => x.id == rankId);
      return rank ? rank.rankName : "Unknown rank";
    },
    GetLogDate(timestamp) {
      return moment(timestamp * 1000).fromNow();
    },
    ApplySearchFilter() {
      let logs = [...this.Logs];

      const filterByActor = this.searchQueryActor;
      const filterByTarget = this.searchQueryTarget;

      // Filter by character
      if (filterByActor.length > 0) {
        logs = logs.filter(log =>
          log.playerName1.toLowerCase().includes(filterByActor.toLowerCase())
        );
      }

      if (filterByTarget.length > 0) {
        logs = logs.filter(
          log =>
            log.playerName2 &&
            log.playerName2.toLowerCase().includes(filterByTarget.toLowerCase())
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
      this.searchQueryActor = "";
      this.searchQueryTarget = "";
      this.ApplySearchFilter();
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