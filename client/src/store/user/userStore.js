import Vue from "vue";
import axios from "axios";

const API_AUTH = process.env.API.AUTH;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    NewestUser: ""
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetNewestUser: state => state.NewestUser
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetNewestUser: (state, user) => {
      Vue.set(state, "NewestUser", user);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetNewestUser: async context => {
      try {
        const response = await axios.get(`${API_AUTH}/GetNewestUser`);
        context.commit("SetNewestUser", response.data);
        return Promise.resolve();
      } catch (error) {
        console.log(error);
        return Promise.reject(error);
      }
    }
  }
};
