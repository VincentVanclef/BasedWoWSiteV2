import Vue from "vue";
import Vuex from "vuex";

import newsStore from "./news/newsStore";
import adminStore from "./admin/adminStore";
import statisticsStore from "./statistics/statisticsStore";
import userStore from "./user/userStore";
import voteStore from "./user/vote/voteStore";
import shoutBoxStore from "./shoutbox/shoutBoxStore";
import realmStore from "./realms/realmStore";

import { mainGetters, changelogGetters } from "./getters";
import { mainMutations, changelogMutations } from "./mutations";
import { mainActions, changelogActions } from "./actions";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  modules: {
    news: newsStore,
    admin: adminStore,
    stats: statisticsStore,
    user: userStore,
    vote: voteStore,
    shoutbox: shoutBoxStore,
    realms: realmStore
  },
  state: {
    // Page title
    PageTitle: "",
    UnstuckLocations: [],
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
  mutations: Object.assign({}, mainMutations, changelogMutations),
  getters: Object.assign({}, mainGetters, changelogGetters),
  actions: Object.assign({}, mainActions, changelogActions)
});
