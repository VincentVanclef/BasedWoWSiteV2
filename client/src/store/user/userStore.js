import Vue from "vue";
import axios from "axios";

const API_AUTH = process.env.API.AUTH;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    NewestUser: "",
    TotalUserCount: 0
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetNewestUser: state => state.NewestUser,
    GetTotalUserCount: state => state.TotalUserCount
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetNewestUser: (state, user) => {
      Vue.set(state, "NewestUser", user);
    },
    SetTotalUserCount: (state, count) => {
      Vue.set(state, "TotalUserCount", count);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetNewestUser: async context => {
      try {
        const response = await axios.get(`${API_AUTH}/GetUserInformations`);
        const { user, count } = response.data;
        context.commit("SetNewestUser", user);
        context.commit("SetTotalUserCount", count);
        return Promise.resolve();
      } catch (error) {
        console.log(error);
        return Promise.reject(error);
      }
    }
  }
};
