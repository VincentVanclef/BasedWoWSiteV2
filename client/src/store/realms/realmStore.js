import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.REALMS;
const STATUS_API = process.env.API.STATUS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Realms: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetRealms: state => state.Realms,
    GetRealmById: state => id => {
      return state.Realms.find(x => x.id == id);
    },
    GetRealmByName: state => name => {
      return state.Realms.find(x => x.name == name);
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetRealms: (state, data) => {
      Vue.set(state, "Realms", data);
    },
    SetOnlinePlayers: (state, payload) => {
      const { realmId, data } = payload;
      const realm = state.Realms.find(x => x.id == realmId);
      Vue.set(realm, "onlinePlayers", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchRealms: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetRealmInformations`);
        context.commit("SetRealms", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    FetchOnlinePlayersForRealm: async (context, realmId) => {
      try {
        const response = await axios.post(`${STATUS_API}/GetOnlinePlayers`, {
          RealmType: realmId
        });
        context.commit("SetOnlinePlayers", { realmId, data: response.data });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
