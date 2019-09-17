import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.GUILDS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Guilds: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGuilds: state => state.Guilds
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetGuilds: (state, guilds) => {
      state.Guilds.push(data);
    },
    UpdateGuild(state, data) {
      const { OldGuild, NewGuild } = data;
      Object.assign(OldGuild, NewGuild);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetGuildById: async (context, payload) => {
      const { GuildId, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildById`, {
          GuildId,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGuildByCharacter: async (context, payload) => {
      const { Guid, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildByCharacter`, {
          Guid,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
