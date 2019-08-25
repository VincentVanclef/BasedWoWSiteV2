import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.ADMIN;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Admins: [],
    Moderators: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetAdmins: state => state.Admins,
    GetAdminById: state => id => {
      return state.Admins.find(x => x.id === id);
    },
    GetAdminByUsername: state => name => {
      return state.Admins.find(x => x.username === name);
    },
    GetModerators: state => state.Moderators,
    GetModeratorById: state => id => {
      return state.Moderators.find(x => x.id === id);
    },
    GetModeratorByUsername: state => name => {
      return state.Moderators.find(x => x.username === name);
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetAdmins: (state, data) => {
      Vue.set(state, "Admins", data);
    },
    SetModerators: (state, data) => {
      Vue.set(state, "Moderators", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchAdmins: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetAdminsAndModerators`);
        const { admins, moderators } = response.data;
        context.commit("SetAdmins", admins);
        context.commit("SetModerators", moderators);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
