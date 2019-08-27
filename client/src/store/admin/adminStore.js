import Vue from "vue";
import axios from "axios";

const API_ADMIN = process.env.API.ADMIN;
const API_ROLES = process.env.API.ROLES;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Admins: [],
    Moderators: [],
    Members: [],
    Roles: []
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
    },
    GetMembers: state => state.Members,
    GetRoles: state => state.Roles
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetAdmins: (state, data) => {
      Vue.set(state, "Admins", data);
    },
    SetRoles: (state, roles) => {
      Vue.set(state, "Roles", roles);
    },
    SetModerators: (state, data) => {
      Vue.set(state, "Moderators", data);
    },
    SetMembers: (state, data) => {
      Vue.set(state, "Members", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchAdmins: async context => {
      try {
        const response = await axios.get(`${API_ADMIN}/GetAdminsAndModerators`);
        const { admins, moderators } = response.data;
        context.commit("SetAdmins", admins);
        context.commit("SetModerators", moderators);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    FetchRoles: async context => {
      try {
        const response = await axios.get(`${API_ROLES}/GetRoles`);
        context.commit("SetRoles", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SearchUsers: async (context, query) => {
      try {
        const response = await axios.get(`${API_ADMIN}/SearchUsers/${query}`);
        const { members, count } = response.data;
        context.commit("SetMembers", members);
        return Promise.resolve({ members, count });
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
