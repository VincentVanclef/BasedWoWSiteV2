import Vue from "vue";
import axios from "axios";
import store from "../../index";

const API_URL = process.env.API.CHARACTERS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Characters: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetCharacters: state => state.Characters
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetCharacters: (state, data) => {
      state.Characters.push(data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetAllCharactersByUser: async (context, payload) => {
      const { RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetAllCharactersByUser`, {
          RealmType
        });
        const data = {
          realmid: RealmType,
          data: response.data
        };
        context.commit("SetCharacters", data);
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetAllCharactersByAccountId: async (context, payload) => {
      const { RealmType, AccountId } = payload;
      try {
        const response = await axios.post(
          `${API_URL}/GetAllCharactersByAccountId`,
          {
            RealmType,
            AccountId
          }
        );
        const data = {
          realmid: RealmType,
          data: response.data
        };
        return Promise.resolve(data);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
