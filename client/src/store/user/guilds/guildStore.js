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
      Guild: null
    },
    GuildBankComponent: {
      ShowModal: false,
      Realm: null,
      Guild: null,
      BankTabs: []
    }
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetGuilds: state => state.Guilds,
    GuildViewComponent: state => state.GuildViewComponent,
    GuildBankComponent: state => state.GuildBankComponent,
    GetGuildBanktabs: state => state.GuildBankComponent.BankTabs
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
      const { Realm, Guild } = data;
      state.GuildViewComponent.ShowModal = !state.GuildViewComponent.ShowModal;
      state.GuildViewComponent.Realm = Realm;
      state.GuildViewComponent.Guild = Guild;
    },
    ToggleGuildBankComponent(state, data) {
      const { Realm, Guild } = data;
      state.GuildBankComponent.ShowModal = !state.GuildBankComponent.ShowModal;
      state.GuildBankComponent.Realm = Realm;
      state.GuildBankComponent.Guild = Guild;
    },
    AssignBankTabs(state, tabs) {
      state.GuildBankComponent.BankTabs = tabs;
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
    GetGuildBankItems: async (context, payload) => {
      const { GuildId, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildBankItems`, {
          GuildId,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGuildBankTabs: async (context, payload) => {
      const { GuildId, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildBankTabs`, {
          GuildId,
          RealmType
        });

        const BankTabs = response.data;

        for (const tab of BankTabs) {
          if (tab.tabIcon.length === 0) {
            tab.tabIcon = "inv_misc_questionmark";
          } else {
            tab.tabIcon = tab.tabIcon.toLowerCase();
          }
        }

        context.commit("AssignBankTabs", BankTabs);
        return Promise.resolve(BankTabs);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGuildBankEventLogs: async (context, payload) => {
      const { GuildId, TabId, RealmType, EventTypes } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildBankEventLogs`, {
          GuildId,
          TabId,
          RealmType,
          EventTypes
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetGuildEventLogs: async (context, payload) => {
      const { GuildId, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetGuildEventLogs`, {
          GuildId,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    ShowGuildComponent: async (context, data) => {
      const { Realm, Guild } = data;

      context.commit("ToggleGuildComponent", {
        Realm,
        Guild
      });
    },
    CloseGuildComponent: (context, data) => {
      context.commit("ToggleGuildComponent", {
        Realm: null,
        Guild: null
      });
    },
    ShowGuildBankComponent: async (context, data) => {
      const { Realm, Guild } = data;

      context.commit("ToggleGuildBankComponent", {
        Realm,
        Guild
      });
    },
    CloseGuildBankComponent: (context, data) => {
      context.commit("ToggleGuildBankComponent", {
        Realm: null,
        Guild: null
      });
    }
  }
};
