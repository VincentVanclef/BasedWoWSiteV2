import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.ROLES;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Roles: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetRoles: state => state.Roles
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetRoles: (state, roles) => {
      Vue.set(state, "Roles", roles);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchRoles: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetRoles`);
        context.commit("SetRoles", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    AddUserToRoles: async (context, data) => {
      try {
        const { userId, roles } = data;
        const response = await axios.post(`${API_URL}/AddUserToRoles`, {
          userId,
          roles
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
