import Vue from "vue";
import axios from "axios";
import store from "../../index";

const API_URL = process.env.API.VOTE;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    Sites: [],
    Timers: [],
    TopVoter: null,
    TopVoters: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetVoteSites: state => state.Sites,
    GetVoteTimers: state => state.Timers,
    GetTopVoter: state => state.TopVoter,
    GetTopVoters: state => state.TopVoters
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetVoteSites: (state, data) => {
      Vue.set(state, "Sites", data);
    },
    SetVoteTimers: (state, data) => {
      Vue.set(state, "Timers", data);
    },
    Vote: (state, payload) => {
      const { id, unsetTime } = payload;
      const site = state.Timers.find(timer => timer.site == id);
      if (site != null) {
        site.unsetTimer = unsetTime;
      } else {
        state.Timers.push({ site: id, unsetTimer: unsetTime });
      }
    },
    VoteRequestStart: (state, id) => {
      const site = state.Sites.find(site => site.id == id);
      site.isLoading = true;
    },
    VoteRequestFinish: (state, id) => {
      const site = state.Sites.find(site => site.id == id);
      site.isLoading = false;
    },
    SetTopVoter: (state, data) => {
      Vue.set(state, "TopVoter", data);
    },
    SetTopVoters: (state, data) => {
      Vue.set(state, "TopVoters", data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchVoteSites: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetVoteSites`);
        context.commit("SetVoteSites", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    FetchVoteTimers: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetVoteTimers`);
        context.commit("SetVoteTimers", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    FetchTopVoters: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetTopVoters`);
        const { topvoter, topvoters } = response.data;
        context.commit("SetTopVoter", topvoter);
        context.commit("SetTopVoters", topvoters);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    Vote: async (context, site) => {
      try {
        const response = await axios.post(`${API_URL}/vote/${site.id}`);
        const { unsetTime, vp } = response.data;
        context.commit("Vote", { id: site.id, unsetTime });
        store.commit("user/UpdateUser", { index: "vp", value: vp });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
