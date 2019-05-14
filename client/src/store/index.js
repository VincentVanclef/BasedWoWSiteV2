import Vue from "vue";
import Vuex from "vuex";

import { mainGetters, authGetters, voteGetters, newsGetters } from "./getters";
import {
  mainMutations,
  authMutations,
  voteMutations,
  newsMutations
} from "./mutations";
import { authActions, voteActions, newsActions } from "./actions";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  state: {
    // Page title
    PageTitle: "",
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
    }
  },
  mutations: Object.assign(
    {},
    mainMutations,
    authMutations,
    voteMutations,
    newsMutations
  ),
  getters: Object.assign(
    {},
    mainGetters,
    authGetters,
    voteGetters,
    newsGetters
  ),
  actions: Object.assign({}, authActions, voteActions, newsActions)
});
