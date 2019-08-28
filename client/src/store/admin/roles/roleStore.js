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
    },
    UpdateMember: (state, data) => {
      const { oldUser, newUser } = data;
      Object.assign(oldUser, newUser);
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
    UpdateUserRoles: async (context, data) => {
      try {
        const { user, roles } = data;
        const response = await axios.post(`${API_URL}/UpdateUserRoles`, {
          userId: user.id,
          roles
        });
        context.commit("UpdateMember", {
          oldUser: user,
          newUser: response.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
