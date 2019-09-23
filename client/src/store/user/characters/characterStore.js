import axios from "axios";

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
    },
    UpdateCharacter(state, data) {
      const { OldCharacter, NewCharacter } = data;
      Object.assign(OldCharacter, NewCharacter);
    },
    UpdateCharacterBanData(state, data) {
      const { OldBanData, NewBanData } = data;
      Object.assign(OldBanData, NewBanData);
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
    },
    GetAllCharactersByName: async (context, payload) => {
      const { RealmType, Name } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetAllCharactersByName`, {
          RealmType,
          Name
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetBanHistory: async (context, payload) => {
      const { Character, RealmType } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetBanHistory`, {
          Guid: Character.guid,
          RealmType
        });
        context.commit("UpdateCharacterBanData", {
          OldBanData: Character.characterBanned,
          NewBanData: response.data
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
