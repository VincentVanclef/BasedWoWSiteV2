import axios from "axios";

const API_AUTH = process.env.API.AUTH;
const API_VOTE = process.env.API.VOTE;
const API_PVPSTATS = process.env.API.STATISTICS;
const API_CHAR = process.env.API.CHARACTERS;

import {
  UPDATE_PAGE_TITLE,
  AUTH_REQUEST,
  AUTH_SUCCESS,
  AUTH_ERROR,
  AUTH_LOGOUT,
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

export const authActions = {
  async Login({ commit }, loginModel) {
    commit(AUTH_REQUEST);
    try {
      const data = await axios.post(`${API_AUTH}/login`, loginModel);
      const { token, userDTO } = data.data;
      const userJSON = JSON.stringify(userDTO);

      commit(AUTH_SUCCESS, { token, userDTO });

      localStorage.setItem("token", token);
      localStorage.setItem("user", userJSON);

      axios.defaults.headers.common.Authorization = token;

      return "success";
    } catch (err) {
      commit(AUTH_ERROR);
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  async Register({ commit }, registerModel) {
    commit(AUTH_REQUEST);
    try {
      const data = await axios.post(`${API_AUTH}/register`, registerModel);
      const { token, userDTO } = data.data;
      const userJSON = JSON.stringify(userDTO);

      commit(AUTH_SUCCESS, { token, userDTO });

      localStorage.setItem("token", token);
      localStorage.setItem("user", userJSON);

      axios.defaults.headers.common.Authorization = token;

      return "success";
    } catch (err) {
      commit(AUTH_ERROR);
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      if (err.response) {
        console.log(err.response);
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
  },
  Logout({ commit }) {
    commit(AUTH_LOGOUT);
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    delete axios.defaults.headers.common.Authorization;
  },
  async GetCharacters({ commit }, payload) {
    const { RealmType, AccountId } = payload;

    let result;

    try {
      result = await axios.post(`${API_CHAR}/GetAllCharactersByAccountId`, {
        RealmType,
        AccountId
      });
    } catch (e) {
      return e;
    }

    const data = { realmid: RealmType, data: result.data };
    commit(USER_ADD_CHARACTERS, data);
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
    commit(UPDATE_USER, { index: "vp", value: vp });
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
