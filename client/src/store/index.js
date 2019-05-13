import Vue from "vue";
import Vuex from "vuex";

import {
  productGetters,
  manufacturerGetters,
  authGetters,
  voteGetters,
  newsGetters
} from "./getters";
import {
  productMutations,
  cartMutations,
  manufacturerMutations,
  authMutations,
  voteMutations,
  newsMutations
} from "./mutations";
import {
  productActions,
  manufacturerActions,
  authActions,
  voteActions,
  newsActions
} from "./actions";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  state: {
    // bought items
    cart: [],
    // ajax loader
    showLoader: false,
    // selected product
    product: {},
    // all products
    products: [],
    // all manufacturers
    manufacturers: [],
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
    productMutations,
    cartMutations,
    manufacturerMutations,
    authMutations,
    voteMutations,
    newsMutations
  ),
  getters: Object.assign(
    {},
    productGetters,
    manufacturerGetters,
    authGetters,
    voteGetters,
    newsGetters
  ),
  actions: Object.assign(
    {},
    productActions,
    manufacturerActions,
    authActions,
    voteActions,
    newsActions
  )
});
