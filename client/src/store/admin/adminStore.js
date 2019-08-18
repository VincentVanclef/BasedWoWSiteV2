import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.ADMIN;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Admins: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetAdmins: state => state.Admins,
    GetAdminById: state => id => {
      return state.Admins.find(x => x.id == id);
    },
    GetAdminByUsername: state => name => {
      return state.Admins.find(x => x.username == name);
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetAdmins: (state, data) => {
      Vue.set(state, "Admins", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchAdmins: async context => {
      try {
        const response = await axios.get(`${API_URL}/get/admins`);
        context.commit("SetAdmins", response.data);
        return Promise.resolve(context.state.Admins);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
