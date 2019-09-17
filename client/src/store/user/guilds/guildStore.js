import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.GUILDS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Guilds: [],
    GuildViewComponent: {
      ShowModal: false,
      Realm: null,
      Character: false,
      Guild: null
    }
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGuilds: state => state.Guilds,
    GuildViewComponent: state => state.GuildViewComponent
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetGuilds: (state, guilds) => {
      state.Guilds.push(data);
    },
    UpdateGuild(state, data) {
      const { OldGuild, NewGuild } = data;
      Object.assign(OldGuild, NewGuild);
    },
    ToggleGuildComponent(state, data) {
      const { Realm, Character, Guild } = data;
      state.GuildViewComponent.ShowModal = !state.GuildViewComponent.ShowModal;
      state.GuildViewComponent.Realm = Realm;
      state.GuildViewComponent.Character = Character;
      state.GuildViewComponent.Guild = Guild;
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
    },
    ShowGuildComponent: async (context, data) => {
      const { Realm, Character } = data;

      const Guild = await context.dispatch("GetGuildByCharacter", {
        Guid: Character.guid,
        RealmType: Realm.id
      });

      context.commit("ToggleGuildComponent", {
        Realm,
        Character,
        Guild
      });
    },
    CloseGuildComponent: (context, data) => {
      context.commit("ToggleGuildComponent", {
        Realm: null,
        Character: null,
        Guild: null
      });
    }
  }
};
