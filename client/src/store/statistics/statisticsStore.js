import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.STATISTICS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    OnlineUsers: [],
    OnlineVisitors: 0,
    TopArenaTeams: [],
    TopArenaTeamMembers: [],
    TopHKPlayers: [],
    NewestUser: null,
    TotalUserCount: 0,
    TotalAccounts: 0,
    TotalCharacters: new Map(),
    TotalGuilds: new Map(),
    GameTrials: [],
    GameMasters: [],
    GameAdmins: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetOnlineUsers: state => state.OnlineUsers,
    GetOnlineVisitors: state => state.OnlineVisitors,
    GetTopArenaTeams: state => state.TopArenaTeams,
    GetTopArenaTeamMembers: state => state.TopArenaTeamMembers,
    GetTopHKPlayers: state => state.TopHKPlayers,
    GetNewestUser: state => state.NewestUser,
    GetTotalUserCount: state => state.TotalUserCount,
    GetTotalAccounts: state => state.TotalAccounts,
    GetTotalCharacters: state => realmId => {
      return state.TotalCharacters.get(realmId);
    },
    GetTotalGuilds: state => realmId => {
      return state.TotalGuilds.get(realmId);
    },

    GetGameTrials: state => state.GameTrials,
    GetGameMasters: state => state.GameMasters,
    GetGameAdmins: state => state.GameAdmins
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetOnlineUsers: (state, users) => {
      Vue.set(state, "OnlineUsers", users);
    },
    SetOnlineVisitors: (state, count) => {
      Vue.set(state, "OnlineVisitors", count);
    },
    AddTopArenaTeams: (state, data) => {
      state.TopArenaTeams.push(data);
    },
    AddTopArenaTeamMembers: (state, data) => {
      state.TopArenaTeamMembers.push(data);
    },
    AddTopHKPlayers: (state, data) => {
      state.TopHKPlayers.push(data);
    },
    SetNewestUser: (state, user) => {
      Vue.set(state, "NewestUser", user);
    },
    SetTotalAccounts: (state, count) => {
      Vue.set(state, "TotalAccounts", count);
    },
    SetTotalUserCount: (state, count) => {
      Vue.set(state, "TotalUserCount", count);
    },
    SetTotalCharacters: (state, data) => {
      const { Realm, Count } = data;
      state.TotalCharacters.set(Realm, Count);
    },
    SetTotalGuilds: (state, data) => {
      const { Realm, Count } = data;
      state.TotalGuilds.set(Realm, Count);
    },
    SetGameTrials: (state, data) => {
      Vue.set(state, "GameTrials", data);
    },
    SetGameMasters: (state, data) => {
      Vue.set(state, "GameMasters", data);
    },
    SetGameAdmins: (state, data) => {
      Vue.set(state, "GameAdmins", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetTopArenaTeams: async (context, payload) => {
      const { RealmType, Limit } = payload;

      try {
        const result = await axios.post(`${API_URL}/GetTopArenaTeams`, {
          RealmType,
          Limit
        });
        context.commit("AddTopArenaTeams", {
          RealmType,
          Data: result.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetTopTeamMembers: async (context, payload) => {
      const { RealmType, Teams } = payload;

      try {
        const result = await axios.post(`${API_URL}/GetTopArenaTeamMembers`, {
          RealmType,
          Teams
        });
        context.commit("AddTopArenaTeamMembers", {
          RealmType,
          Data: result.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetTopHKPlayers: async (context, payload) => {
      const { RealmType, Limit } = payload;

      try {
        const result = await axios.post(`${API_URL}/GetTopHKPlayers`, {
          RealmType,
          Limit
        });

        context.commit("AddTopHKPlayers", {
          RealmType,
          Data: result.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetNewestUser: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetUserInformations`);
        const { user, count } = response.data;
        context.commit("SetNewestUser", user);
        context.commit("SetTotalUserCount", count);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetTotalAccounts: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetTotalAccounts`);
        context.commit("SetTotalAccounts", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetTotalCharacters: async (context, realm) => {
      try {
        const response = await axios.get(
          `${API_URL}/GetTotalCharacters/${realm}`
        );
        context.commit("SetTotalCharacters", {
          Realm: realm,
          Count: response.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetTotalGuilds: async (context, realm) => {
      try {
        const response = await axios.get(`${API_URL}/GetTotalGuilds/${realm}`);
        context.commit("SetTotalGuilds", {
          Realm: realm,
          Count: response.data
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGameMasters: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetGameMasters`);
        const { trials, gamemasters, admins } = response.data;
        context.commit("SetGameTrials", trials);
        context.commit("SetGameMasters", gamemasters);
        context.commit("SetGameAdmins", admins);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
