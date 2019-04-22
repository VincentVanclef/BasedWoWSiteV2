import Vue from "vue";
import Vuex from "vuex";

import { productGetters, manufacturerGetters, authGetters, voteGetters } from './getters';
import { productMutations, cartMutations, manufacturerMutations, authMutations, voteMutations } from './mutations';
import { productActions, manufacturerActions, authActions, voteActions } from './actions';

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
    // user states
    User: {
      Status: "",
      Token: localStorage.getItem("token") || "",
      User: localStorage.getItem("user") || "",
    },
    Vote: {
      Status: "",
      Sites: []
    }
  },
  mutations: Object.assign({}, productMutations, cartMutations, manufacturerMutations, authMutations, voteMutations),
  getters: Object.assign({}, productGetters, manufacturerGetters, authGetters, voteGetters),
  actions: Object.assign({}, productActions, manufacturerActions, authActions, voteActions)
});
