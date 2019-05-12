import axios from "axios";

const API_STORE = process.env.API.STORE;
const API_AUTH = process.env.API.AUTH;
const API_VOTE = process.env.API.VOTE;
const API_NEWS = process.env.API.NEWS;

import {
  ADD_PRODUCT,
  ADD_PRODUCT_SUCCESS,
  PRODUCT_BY_ID,
  PRODUCT_BY_ID_SUCCESS,
  UPDATE_PRODUCT,
  UPDATE_PRODUCT_SUCCESS,
  REMOVE_PRODUCT,
  REMOVE_PRODUCT_SUCCESS,
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

export const productActions = {
  allProducts({ commit }) {
    commit(ALL_PRODUCTS);
    axios.get(`${API_STORE}/products`).then(response => {
      commit(ALL_PRODUCTS_SUCCESS, response.data);
    });
  },
  productById({ commit }, payload) {
    commit(PRODUCT_BY_ID);
    axios.get(`${API_STORE}/products/${payload}`).then(response => {
      console.log(payload, response.data);
      commit(PRODUCT_BY_ID_SUCCESS, response.data);
    });
  },
  addProduct({ commit }, payload) {
    commit(ADD_PRODUCT);
    axios.post(`${API_STORE}/products`, payload).then(response => {
      commit(ADD_PRODUCT_SUCCESS, response.data);
    });
  },
  updateProduct({ commit }, payload) {
    commit(UPDATE_PRODUCT);
    axios
      .put(`${API_STORE}/products/${payload._id}`, payload)
      .then(response => {
        commit(UPDATE_PRODUCT_SUCCESS, response.data);
      });
  },
  removeProduct({ commit }, payload) {
    commit(REMOVE_PRODUCT);
    axios.delete(`${API_STORE}/products/${payload}`, payload).then(response => {
      console.debug("response", response.data);
      commit(REMOVE_PRODUCT_SUCCESS, response.data);
    });
  }
};

export const manufacturerActions = {
  allManufacturers({ commit }) {
    commit(ALL_MANUFACTURERS);
    axios.get(`${API_STORE}/manufacturers`).then(response => {
      commit(ALL_MANUFACTURERS_SUCCESS, response.data);
    });
  }
};

export const authActions = {
  async Login({ commit }, loginModel) {
    commit(AUTH_REQUEST);
    try {
      const data = await axios.post(`${API_AUTH}/login`, loginModel);
      const { token, userDTO } = data.data;
      const userJSON = JSON.stringify(userDTO);

      commit(AUTH_SUCCESS, { token, userDTO });

      localStorage.setItem("token", token);
      localStorage.setItem("user", userJSON);

      axios.defaults.headers.common.Authorization = token;

      return "success";
    } catch (err) {
      commit(AUTH_ERROR);
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async Register({ commit }, registerModel) {
    commit(AUTH_REQUEST);
    try {
      const data = await axios.post(`${API_AUTH}/register`, registerModel);
      const { token, userDTO } = data.data;
      const userJSON = JSON.stringify(userDTO);

      commit(AUTH_SUCCESS, { token, userDTO });

      localStorage.setItem("token", token);
      localStorage.setItem("user", userJSON);

      axios.defaults.headers.common.Authorization = token;

      return "success";
    } catch (err) {
      commit(AUTH_ERROR);
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  Logout({ commit }) {
    commit(AUTH_LOGOUT);
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    delete axios.defaults.headers.common.Authorization;
  }
};

export const voteActions = {
  async GetVoteSites({ commit }) {
    commit(VOTE_REQUEST_BEGIN);
    try {
      const result = await axios.get(`${API_VOTE}/GetVoteSites`);
      commit(VOTE_REQUEST_SUCCESS, result.data);
      return "success";
    } catch (err) {
      commit(VOTE_REQUEST_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async GetVoteTimers({ commit }) {
    commit(VOTE_TIMERS_REQUEST);
    try {
      const result = await axios.get(`${API_VOTE}/GetVoteTimers`);
      commit(VOTE_TIMERS_SUCCESS, result.data);
      return "success";
    } catch (err) {
      commit(VOTE_TIMERS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async Vote({ commit }, site) {
    commit(VOTE_BEGIN);
    let result;
    const id = site.id;
    try {
      result = await axios.post(`${API_VOTE}/vote/${id}`);
    } catch (err) {
      commit(VOTE_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }

    const { unsetTime, vp } = result.data;
    commit(VOTE_SUCCESS, { id, unsetTime });
    commit(UPDATE_USER, { index: "vp", value: vp });
    return "success";
  }
};

export const newsActions = {
  async GetNews({ commit }) {
    commit(NEWS_REQUEST);
    let result;
    try {
      result = await axios.get(API_NEWS);
      for (const news of result.data) {
        const commentsData = await axios.get(
          `${process.env.API.NEWS}/comments/${news.id}/total`
        );

        const { total } = commentsData.data;
        news.totalComments = total;
      }
    } catch (err) {
      commit(NEWS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
    commit(NEWS_SUCCESS, result.data);
    return "success";
  }
};
