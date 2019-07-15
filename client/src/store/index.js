import Vue from "vue";
import Vuex from "vuex";

import {
  mainGetters,
  adminGetters,
  authGetters,
  voteGetters,
  newsGetters,
  changelogGetters,
  pvpStatsGetters
} from "./getters";
import {
  mainMutations,
  adminMutations,
  authMutations,
  voteMutations,
  newsMutations,
  changelogMutations,
  pvpStatsMutations
} from "./mutations";
import {
  mainActions,
  adminActions,
  authActions,
  voteActions,
  newsActions,
  changelogActions,
  pvpStatsActions
} from "./actions";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  state: {
    // Page title
    PageTitle: "",
    // Admin Data
    Admin: {
      Loading: false,
      Data: []
    },
    // news
    News: {
      Loading: false,
      Data: [],
      Comments: []
    },
    // user states
    User: {
      Status: "",
      Token: localStorage.getItem("token") || "",
      User: JSON.parse(localStorage.getItem("user")) || null
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
    adminMutations,
    authMutations,
    voteMutations,
    newsMutations,
    changelogMutations,
    pvpStatsMutations
  ),
  getters: Object.assign(
    {},
    mainGetters,
    adminGetters,
    authGetters,
    voteGetters,
    newsGetters,
    changelogGetters,
    pvpStatsGetters
  ),
  actions: Object.assign(
    {},
    mainActions,
    adminActions,
    authActions,
    voteActions,
    newsActions,
    changelogActions,
    pvpStatsActions
  )
});
