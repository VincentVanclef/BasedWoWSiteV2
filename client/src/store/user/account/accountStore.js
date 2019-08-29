import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.ACCOUNT;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Accounts: [],
    AccountData: null,
    BanData: null,
    TotalAccounts: 0
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetAccounts: state => state.Accounts,
    GetAccountData: state => state.AccountData,
    GetBanData: state => state.BanData,
    GetTotalAccounts: state => state.TotalAccounts
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetAccounts: (state, roles) => {
      Vue.set(state, "Accounts", roles);
    },
    SetTotalAccounts: (state, count) => {
      Vue.set(state, "TotalAccounts", count);
    },
    SetAccountData(state, data) {
      Vue.set(state, "AccountData", data);
    },
    UpdateAccountData(state, payload) {
      const { index, value } = payload;
      Vue.set(state.AccountData, index, value);
    },
    SetBanData(state, data) {
      Vue.set(state, "BanData", data);
    },
    UpdateAccountAccess(state, data) {
      const { oldAcc, newAcc } = data;
      Object.assign(oldAcc, newAcc);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetTotalAccounts: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetTotalAccounts`);
        context.commit("SetTotalAccounts", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    SearchAccounts: async (context, query) => {
      try {
        const response = await axios.get(`${API_URL}/SearchAccounts/${query}`);
        const { accounts, count } = response.data;
        context.commit("SetAccounts", accounts);
        return Promise.resolve({ accounts, count });
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetAccountData: async context => {
      try {
        const result = await axios.get(`${API_URL}/GetAccountData`);
        context.commit("SetAccountData", result.data.accountData);
        context.commit("SetBanData", result.data.banData);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UpdateUsername: async (context, payload) => {
      const {
        Id,
        NewUsername,
        NewPassword,
        CurrentUsername,
        CurrentPassword
      } = payload;

      try {
        const result = await axios.post(`${API_URL}/Update/Username`, {
          Id,
          NewUsername,
          NewPassword,
          CurrentUsername,
          CurrentPassword
        });
        context.commit("UpdateAccountData", {
          index: "Username",
          value: NewUsername
        });
        return Promise.resolve(result);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UpdatePassword: async (context, payload) => {
      const {
        Id,
        NewUsername,
        NewPassword,
        CurrentUsername,
        CurrentPassword
      } = payload;

      try {
        const result = await axios.post(`${API_URL}/update/password`, {
          Id,
          NewUsername,
          NewPassword,
          CurrentUsername,
          CurrentPassword
        });
        return Promise.resolve(result);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    UpdateAccountAccess: async (context, payload) => {
      const { account, realm, access } = payload;
      try {
        const result = await axios.post(`${API_URL}/UpdateAccountAccess`, {
          accountId: account.id,
          realmId: realm.id,
          accessId: access.id
        });
        context.commit("UpdateAccountAccess", {
          oldAcc: account,
          newAcc: result.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
