import Vue from "vue";
import axios from "axios";

const API_STATISTICS = process.env.API.STATISTICS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    OnlineUsers: 0,
    TopArenaTeams: [],
    TopArenaTeamMembers: [],
    TopHKPlayers: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetOnlineUsers: state => state.OnlineUsers,
    GetTopArenaTeams: state => state.TopArenaTeams,
    GetTopArenaTeamMembers: state => state.TopArenaTeamMembers,
    GetTopHKPlayers: state => state.TopHKPlayers
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetOnlineUsers: (state, count) => {
      Vue.set(state, "OnlineUsers", count);
    },
    AddTopArenaTeams: (state, data) => {
      state.TopArenaTeams.push(data);
    },
    AddTopArenaTeamMembers: (state, data) => {
      state.TopArenaTeamMembers.push(data);
    },
    AddTopHKPlayers: (state, data) => {
      state.TopHKPlayers.push(data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetTopArenaTeams: async (context, payload) => {
      const { RealmType, Limit } = payload;

      try {
        const result = await axios.post(`${API_STATISTICS}/GetTopArenaTeams`, {
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
        const result = await axios.post(
          `${API_STATISTICS}/GetTopArenaTeamMembers`,
          {
            RealmType,
            Teams
          }
        );
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
        const result = await axios.post(`${API_STATISTICS}/GetTopHKPlayers`, {
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
    }
  }
};
