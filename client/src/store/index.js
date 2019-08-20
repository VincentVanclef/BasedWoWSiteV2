import Vue from "vue";
import Vuex from "vuex";

import newsStore from "./news/newsStore";
import adminStore from "./admin/adminStore";
import statisticsStore from "./statistics/statisticsStore";
import userStore from "./user/userStore";

import {
  mainGetters,
  voteGetters,
  changelogGetters,
  pvpStatsGetters
} from "./getters";
import {
  mainMutations,
  voteMutations,
  changelogMutations,
  pvpStatsMutations
} from "./mutations";
import {
  mainActions,
  voteActions,
  changelogActions,
  pvpStatsActions
} from "./actions";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  modules: {
    news: newsStore,
    admin: adminStore,
    stats: statisticsStore,
    user: userStore
  },
  state: {
    // Page title
    PageTitle: "",
    UnstuckLocations: [],
    // user states
    User: {
      Status: "",
      Token: localStorage.getItem("token") || "",
      User: JSON.parse(localStorage.getItem("user")) || null,
      AccountData: null,
      BanData: null,
      Characters: []
    },
    Vote: {
      Status: false,
      Sites: {
        Data: [],
        Loading: false
      },
      Timers: {
        Data: [],
        Loading: false
      }
    },
    // Changelog
    Changelog: {
      Categories: {
        Loading: false,
        Data: []
      },
      Changes: {
        Loading: false,
        Data: []
      }
    },
    // PvP Statistics
    PvPStats: {
      TopArenaTeams: [],
      TopTeamMembers: [],
      TopHKPlayers: []
    }
  },
  mutations: Object.assign(
    {},
    mainMutations,
    voteMutations,
    changelogMutations,
    pvpStatsMutations
  ),
  getters: Object.assign(
    {},
    mainGetters,
    voteGetters,
    changelogGetters,
    pvpStatsGetters
  ),
  actions: Object.assign(
    {},
    mainActions,
    voteActions,
    changelogActions,
    pvpStatsActions
  )
});
