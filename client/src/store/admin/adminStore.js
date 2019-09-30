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
    },
    UpdateAccount(state, data) {
      const { OldAccount, NewAccount } = data;
      Object.assign(OldAccount, NewAccount);
    },
    UpdateCharacter(state, data) {
      const { OldCharacter, NewCharacter } = data;
      Object.assign(OldCharacter, NewCharacter);
    },
    UpdateCharacterBanData(state, data) {
      const { Character, BanData } = data;
      Vue.set(Character, "characterBanned", BanData);
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
      const { Character, UnbanDate, Reason, RealmType } = payload;
      try {
        const response = await axios.post(`${API_CHAR}/BanCharacter`, {
          Guid: Character.guid,
          UnbanDate,
          Reason,
          RealmType
        });
        context.commit("UpdateCharacterBanData", {
          Character: Character,
          BanData: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnBanCharacter: async (context, payload) => {
      const { Character, RealmType } = payload;
      try {
        const response = await axios.post(`${API_CHAR}/UnBanCharacter`, {
          Guid: Character.guid,
          RealmType
        });
        context.commit("UpdateCharacterBanData", {
          Character: Character,
          BanData: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    BanAccount: async (context, payload) => {
      const { Account, UnBanDate, Reason } = payload;
      try {
        const response = await axios.post(`${API_ACCOUNT}/BanAccount`, {
          AccountId: Account.id,
          UnBanDate,
          Reason
        });
        context.commit("UpdateAccount", {
          OldAccount: Account,
          NewAccount: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnBanAccount: async (context, account) => {
      const AccountId = account.id;
      try {
        const response = await axios.post(
          `${API_ACCOUNT}/UnBanAccount/${AccountId}`
        );
        context.commit("UpdateAccount", {
          OldAccount: account,
          NewAccount: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    MuteAccount: async (context, payload) => {
      const { Account, MuteMinutes, Reason } = payload;
      try {
        const response = await axios.post(`${API_ACCOUNT}/MuteAccount`, {
          AccountId: Account.id,
          MuteMinutes,
          Reason
        });
        context.commit("UpdateAccount", {
          OldAccount: Account,
          NewAccount: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UnMuteAccount: async (context, account) => {
      const AccountId = account.id;
      try {
        const response = await axios.post(
          `${API_ACCOUNT}/UnMuteAccount/${AccountId}`
        );
        context.commit("UpdateAccount", {
          OldAccount: account,
          NewAccount: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
