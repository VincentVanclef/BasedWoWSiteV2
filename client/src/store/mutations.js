import {
  ADD_PRODUCT,
  ADD_PRODUCT_SUCCESS,
  PRODUCT_BY_ID,
  PRODUCT_BY_ID_SUCCESS,
  UPDATE_PRODUCT,
  UPDATE_PRODUCT_SUCCESS,
  REMOVE_PRODUCT,
  REMOVE_PRODUCT_SUCCESS,
  ADD_TO_CART,
  REMOVE_FROM_CART,
  ALL_PRODUCTS,
  ALL_PRODUCTS_SUCCESS,
  ALL_MANUFACTURERS,
  ALL_MANUFACTURERS_SUCCESS,
  AUTH_REQUEST,
  AUTH_SUCCESS,
  AUTH_ERROR,
  AUTH_LOGOUT,
  VOTE_REQUEST_BEGIN,
  VOTE_REQUEST_SUCCESS,
  VOTE_REQUEST_ERROR,
  VOTE_TIMERS_REQUEST,
  VOTE_TIMERS_SUCCESS,
  VOTE_TIMERS_ERROR,
  VOTE_BEGIN,
  VOTE_SUCCESS,
  VOTE_ERROR,
  UPDATE_USER,
  NEWS_REQUEST,
  NEWS_SUCCESS,
  NEWS_ERROR
} from "./mutation-types";
import Vue from "vue";

export const productMutations = {
  [ALL_PRODUCTS](state) {
    // Called when fetching products
    state.showLoader = true;
  },
  [ALL_PRODUCTS_SUCCESS](state, payload) {
    // Called when products have been fetched
    state.showLoader = false;
    // Updates state products
    state.products = payload;
  },
  [PRODUCT_BY_ID](state) {
    // Called when fetching products by ID
    state.showLoader = true;
  },
  [PRODUCT_BY_ID_SUCCESS](state, payload) {
    // Called when product is fetched
    state.showLoader = false;
    // Updates state product
    state.product = payload;
  },
  [ADD_PRODUCT]: (state, payload) => {
    // ...Same pattern
    state.showLoader = true;
  },
  [ADD_PRODUCT_SUCCESS]: (state, payload) => {
    state.showLoader = false;
    state.products.push(payload);
  },
  [UPDATE_PRODUCT]: (state, payload) => {
    state.showLoader = true;
  },
  [UPDATE_PRODUCT_SUCCESS]: (state, payload) => {
    state.showLoader = false;
    state.products = state.products.map(p => {
      if (p._id === payload._id) {
        payload = {
          ...payload,
          manufacturer: state.manufacturers.filter(
            x => x._id === payload.manufacturer
          )[0]
        };
        return payload;
      }
      return p;
    });
  },
  [REMOVE_PRODUCT]: (state, payload) => {
    state.showLoader = true;
  },
  [REMOVE_PRODUCT_SUCCESS]: (state, payload) => {
    state.showLoader = false;
    const index = state.products.findIndex(p => p._id === payload);
    console.debug("index", index);
    state.products.splice(index, 1);
  }
};

export const cartMutations = {
  [ADD_TO_CART]: (state, payload) => state.cart.push(payload),
  [REMOVE_FROM_CART]: (state, payload) => {
    const index = state.cart.findIndex(p => p._id === payload);
    state.cart.splice(index, 1);
    console.log(state.cart, state.cart.length, index);
  }
};

export const manufacturerMutations = {
  [ALL_MANUFACTURERS](state) {
    state.showLoader = true;
  },
  [ALL_MANUFACTURERS_SUCCESS](state, payload) {
    state.showLoader = false;
    state.manufacturers = payload;
  }
};

export const authMutations = {
  [AUTH_REQUEST](state) {
    state.User.Status = "loading";
  },
  [AUTH_SUCCESS](state, payload) {
    const { token, userDTO } = payload;
    Vue.set(state.User, "Status", "success");
    Vue.set(state.User, "Token", token);
    Vue.set(state.User, "User", userDTO);
  },
  [AUTH_ERROR](state) {
    state.User.Status = "error";
  },
  [AUTH_LOGOUT](state) {
    state.User.Status = "";
    state.User.Token = "";
    state.User.User = null;
  },
  // Payload format: { index: "" | number, value: any }
  [UPDATE_USER](state, payload) {
    const { index, value } = payload;
    Vue.set(state.User.User, index, value);
    const userJSON = JSON.stringify(state.User.User);
    localStorage.setItem("user", userJSON);
  }
};

export const voteMutations = {
  [VOTE_REQUEST_BEGIN](state) {
    state.Vote.Sites.Status = false;
  },
  [VOTE_REQUEST_SUCCESS](state, payload) {
    state.Vote.Sites.Status = true;
    Vue.set(state.Vote.Sites, "Data", payload);
  },
  [VOTE_REQUEST_ERROR](state) {
    state.Vote.Sites.Status = false;
  },
  [VOTE_TIMERS_REQUEST](state) {
    state.Vote.Timers.Status = false;
  },
  [VOTE_TIMERS_SUCCESS](state, payload) {
    state.Vote.Timers.Status = true;
    state.Vote.Timers.Data = payload;
  },
  [VOTE_TIMERS_ERROR](state) {
    state.Vote.Timers.Status = false;
  },
  [VOTE_BEGIN](state) {
    state.Vote.Status = true;
  },
  [VOTE_SUCCESS](state, payload) {
    const { id, unsetTime } = payload;
    const site = state.Vote.Timers.Data.find(timer => timer.site == id);
    site
      ? (site.unsetTimer = unsetTime)
      : state.Vote.Timers.Data.push({ site: id, unsetTimer: unsetTime });

    state.Vote.Status = true;
  },
  [VOTE_ERROR](state) {
    state.Vote.Status = false;
  }
};

export const newsMutations = {
  [NEWS_REQUEST] (state) {
    Vue.set(state.News, 'Loading', true)
  },
  [NEWS_SUCCESS] (state, payload) {
    Vue.set(state.News, 'Data', payload)
    Vue.set(state.News, 'Loading', false)
  },
  [NEWS_ERROR] (state) {
    state.News.Loading = false
  }
};
