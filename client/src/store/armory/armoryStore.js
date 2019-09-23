import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.ARMORY;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    ItemDisplayInfoMap: new Map(),
    ArmoryViewComponent: {
      ShowModal: false,
      Character: null,
      Realm: null
    }
  },
  // ----------------------------------------------------------------------------------
  getters: {
    ArmoryViewComponent: state => state.ArmoryViewComponent,
    GetItemDisplayInfoMap: state => state.ItemDisplayInfoMap,
    GetItemIconByDisplayId: state => id => {
      const icon = state.ItemDisplayInfoMap.get(id);
      return icon;
    }
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    ToggleArmoryComponent(state, data) {
      const { Realm, Character } = data;
      state.ArmoryViewComponent.ShowModal = !state.ArmoryViewComponent
        .ShowModal;
      state.ArmoryViewComponent.Character = Character;
      state.ArmoryViewComponent.Realm = Realm;
    },
    SetItemDisplayInfo(state, data) {
      const { id, icon } = data;
      state.ItemDisplayInfoMap.set(id, icon);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetItemIcon: async (context, id) => {
      if (id === 0) return;

      const icon = context.getters.GetItemIconByDisplayId(id);
      if (icon) return icon;

      try {
        const response = await axios.get(`${API_URL}/GetItemDisplayInfo/${id}`);
        context.commit("SetItemDisplayInfo", response.data);
        return Promise.resolve(response.data.icon);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetCharacterInventory: async (context, payload) => {
      const { RealmType, Guid } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetCharacterInventory`, {
          Guid,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetCharacterStats: async (context, payload) => {
      const { RealmType, Guid } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetCharacterStats`, {
          Guid,
          RealmType
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    ShowArmoryComponent: async (context, data) => {
      const { Realm, Character } = data;

      context.commit("ToggleArmoryComponent", {
        Realm,
        Character
      });
    },
    CloseArmoryComponent: (context, data) => {
      context.commit("ToggleArmoryComponent", {
        Realm: null,
        Guild: null
      });
    }
  }
};
