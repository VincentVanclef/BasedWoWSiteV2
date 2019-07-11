import Vue from "vue";
import Vuex from "vuex";

import {
  mainGetters,
  adminGetters,
  authGetters,
  voteGetters,
  newsGetters
} from "./getters";
import {
  mainMutations,
  adminMutations,
  authMutations,
  voteMutations,
  newsMutations
} from "./mutations";
import {
  mainActions,
  adminActions,
  authActions,
  voteActions,
  newsActions
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
    }
  },
  mutations: Object.assign(
    {},
    mainMutations,
    adminMutations,
    authMutations,
    voteMutations,
    newsMutations
  ),
  getters: Object.assign(
    {},
    mainGetters,
    adminGetters,
    authGetters,
    voteGetters,
    newsGetters
  ),
  actions: Object.assign(
    {},
    mainActions,
    adminActions,
    authActions,
    voteActions,
    newsActions
  )
});
