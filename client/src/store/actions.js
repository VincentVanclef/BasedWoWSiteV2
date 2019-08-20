import axios from "axios";

const API_AUTH = process.env.API.AUTH;
const API_VOTE = process.env.API.VOTE;
const API_PVPSTATS = process.env.API.STATISTICS;
const API_CHAR = process.env.API.CHARACTERS;

import {
  VOTE_REQUEST_BEGIN,
  VOTE_REQUEST_SUCCESS,
  VOTE_REQUEST_ERROR,
  VOTE_TIMERS_REQUEST,
  VOTE_TIMERS_SUCCESS,
  VOTE_TIMERS_ERROR,
  VOTE_BEGIN,
  VOTE_SUCCESS,
  VOTE_ERROR,
  UPDATE_USER,
  PVPSTATS_ADD_TOPARENATEAMS,
  PVPSTATS_ADD_TOPARENATEAMMEMBERS,
  PVPSTATS_ADD_TOPHKPLAYERS,
  ADD_UNSTUCK_LOCATIONS,
  USER_ADD_CHARACTERS
} from "./mutation-types";

export const mainActions = {
  async GetUnstuckLocations({ commit }) {
    let result;

    try {
      result = await axios.get(`${API_CHAR}/GetAllUnstuckLocations`);
    } catch (e) {
      return e;
    }

    commit(ADD_UNSTUCK_LOCATIONS, result.data);
    return "success";
  }
};

export const voteActions = {
  async GetVoteSites({ commit }) {
    commit(VOTE_REQUEST_BEGIN);
    try {
      const result = await axios.get(`${API_VOTE}/GetVoteSites`);
      commit(VOTE_REQUEST_SUCCESS, result.data);
      return "success";
    } catch (err) {
      commit(VOTE_REQUEST_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async GetVoteTimers({ commit }) {
    commit(VOTE_TIMERS_REQUEST);
    try {
      const result = await axios.get(`${API_VOTE}/GetVoteTimers`);
      commit(VOTE_TIMERS_SUCCESS, result.data);
      return "success";
    } catch (err) {
      commit(VOTE_TIMERS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async Vote({ commit }, site) {
    commit(VOTE_BEGIN);
    let result;
    const id = site.id;
    try {
      result = await axios.post(`${API_VOTE}/vote/${id}`);
    } catch (err) {
      commit(VOTE_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }

    const { unsetTime, vp } = result.data;
    commit(VOTE_SUCCESS, { id, unsetTime });
    commit("user/UpdateUser", { index: "vp", value: vp });
    return "success";
  }
};

export const changelogActions = {};

export const pvpStatsActions = {
  async GetTopArenaTeams({ commit }, payload) {
    let result;

    const { RealmType, Limit } = payload;

    try {
      result = await axios.post(`${API_PVPSTATS}/GetTopArenaTeams`, {
        RealmType,
        Limit
      });
    } catch (e) {
      return e;
    }

    commit(PVPSTATS_ADD_TOPARENATEAMS, {
      RealmType,
      Data: result.data
    });
    return "success";
  },
  async GetTopTeamMembers({ commit }, payload) {
    let result;

    const { RealmType, Teams } = payload;

    try {
      result = await axios.post(`${API_PVPSTATS}/GetTopArenaTeamMembers`, {
        RealmType,
        Teams
      });
    } catch (e) {
      return e;
    }

    commit(PVPSTATS_ADD_TOPARENATEAMMEMBERS, {
      RealmType,
      Data: result.data
    });
    return "success";
  },
  async GetTopHKPlayers({ commit }, payload) {
    let result;

    const { RealmType, Limit } = payload;

    try {
      result = await axios.post(`${API_PVPSTATS}/GetTopHKPlayers`, {
        RealmType,
        Limit
      });
    } catch (e) {
      return e;
    }

    commit(PVPSTATS_ADD_TOPHKPLAYERS, {
      RealmType,
      Data: result.data
    });
    return "success";
  }
};
