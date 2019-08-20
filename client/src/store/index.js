import Vue from "vue";
import Vuex from "vuex";

import newsStore from "./news/newsStore";
import adminStore from "./admin/adminStore";
import statisticsStore from "./statistics/statisticsStore";
import userStore from "./user/userStore";

import { mainGetters, voteGetters, changelogGetters } from "./getters";
import { mainMutations, voteMutations, changelogMutations } from "./mutations";
import { mainActions, voteActions, changelogActions } from "./actions";

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
    }
  },
  mutations: Object.assign(
    {},
    mainMutations,
    voteMutations,
    changelogMutations
  ),
  getters: Object.assign({}, mainGetters, voteGetters, changelogGetters),
  actions: Object.assign({}, mainActions, voteActions, changelogActions)
});
