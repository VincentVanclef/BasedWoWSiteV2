import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.SHOUTBOX;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Shouts: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetAllShouts: state => state.Shouts
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetShouts: (state, data) => {
      Vue.set(state, "Shouts", data);
    },
    AddNewShout: (state, shout) => {
      state.Shouts.unshift(shout);
    },
    AddShouts: (state, shouts) => {
      state.Shouts.push(...shouts);
    },
    EditShout: (state, newShout) => {
      const oldShout = state.Shouts.find(x => x.id == newShout.id);
      if (oldShout == null) return;
      Object.assign(oldShout, newShout);
    },
    DeleteShout: (state, id) => {
      const index = state.Shouts.findIndex(x => x.id == id);
      state.Shouts.splice(index, 1);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    GetShouts: async (context, payload) => {
      const { Index, Count } = payload;
      try {
        const response = await axios.post(`${API_URL}/GetShouts`, {
          Index,
          Count
        });
        context.commit("AddShouts", response.data);
        return Promise.resolve(response.data.length);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    GetAllShouts: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetAllShouts`);
        context.commit("SetShouts", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    Shout: async (context, shout) => {
      const { message } = shout;
      try {
        const response = await axios.post(`${API_URL}/Shout`, {
          message
        });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    ClearShouts: async context => {
      try {
        const response = await axios.post(`${API_URL}/ClearShouts`);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    EditShout: async (context, shout) => {
      try {
        await axios.post(`${API_URL}/EditShout`, shout);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    DeleteShout: async (context, id) => {
      try {
        await axios.post(`${API_URL}/DeleteShout/${id}`);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
