import Vue from "vue";
import Vuex from "vuex";

import { productGetters, manufacturerGetters, authGetters } from './getters';
import { productMutations, cartMutations, manufacturerMutations, authMutations } from './mutations';
import { productActions, manufacturerActions, authActions } from './actions';

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
    status: "",
    token: localStorage.getItem("token") || "",
    user: localStorage.getItem("user") || "",
  },
  mutations: Object.assign({}, productMutations, cartMutations, manufacturerMutations, authMutations),
  getters: Object.assign({}, productGetters, manufacturerGetters, authGetters),
  actions: Object.assign({}, productActions, manufacturerActions, authActions)
});
