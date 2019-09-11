import Vue from "vue";
import axios from "axios";
import roleStore from "./roles/roleStore";

const API_ADMIN = process.env.API.ADMIN;
const API_CHAR = process.env.API.CHARACTERS;
const API_ACCOUNT = process.env.API.ACCOUNT;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  modules: {
    roles: roleStore
  },
  // ----------------------------------------------------------------------------------
  state: {
    Admins: [],
    Moderators: [],
    Members: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetAdmins: state => state.Admins,
    GetAdminById: state => id => {
      return state.Admins.find(x => x.id === id);
    },
    GetAdminByUsername: state => name => {
      return state.Admins.find(x => x.userName === name);
    },
    GetModerators: state => state.Moderators,
    GetModeratorById: state => id => {
      return state.Moderators.find(x => x.id === id);
    },
    GetModeratorByUsername: state => name => {
      return state.Moderators.find(x => x.userName === name);
    },
    GetMembers: state => state.Members
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetAdmins: (state, data) => {
      Vue.set(state, "Admins", data);
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
    Authorize: async context => {
      try {
        await axios.post(`${API_ADMIN}/Authorize`);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
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
    SearchUsers: async (context, query) => {
      try {
        const response = await axios.get(`${API_ADMIN}/SearchUsers/${query}`);
        const { members, count } = response.data;
        context.commit("SetMembers", members);
        return Promise.resolve({ members, count });
      } catch (error) {
        return Promise.reject(error);
      }
    },
    BanCharacter: async (context, payload) => {
      const { Guid, UnbanDate, Reason, RealmType } = payload;
      try {
        const response = await axios.post(`${API_CHAR}/BanCharacter`, {
          Guid,
          UnbanDate,
          Reason,
          RealmType
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnBanCharacter: async (context, payload) => {
      const { Guid, RealmType } = payload;
      try {
        const response = await axios.post(`${API_CHAR}/UnBanCharacter`, {
          Guid,
          RealmType
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    BanAccount: async (context, payload) => {
      const { AccountId, UnBanDate, Reason } = payload;
      try {
        const response = await axios.post(`${API_ACCOUNT}/BanAccount`, {
          AccountId,
          UnBanDate,
          Reason
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnBanAccount: async (context, accountId) => {
      try {
        await axios.post(`${API_ACCOUNT}/UnBanAccount/${accountId}`);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    MuteAccount: async (context, payload) => {
      const { AccountId, MuteMinutes, Reason } = payload;
      try {
        const response = await axios.post(`${API_ACCOUNT}/MuteAccount`, {
          AccountId,
          MuteMinutes,
          Reason
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnMuteAccount: async (context, accountId) => {
      try {
        await axios.post(`${API_ACCOUNT}/UnMuteAccount/${accountId}`);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
