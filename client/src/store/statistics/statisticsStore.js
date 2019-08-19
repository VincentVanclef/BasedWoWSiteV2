import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.STATISTICS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    OnlineUsers: 0
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetOnlineUsers: state => state.OnlineUsers
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetOnlineUsers: (state, count) => {
      Vue.set(state, "OnlineUsers", count);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {}
};
