import {
  UPDATE_PAGE_TITLE,
  ADMIN_REQUEST,
  ADMIN_SUCCESS,
  ADMIN_ERROR,
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
  USER_ADD_CHARACTERS,
  NEWS_REQUEST,
  NEWS_SUCCESS,
  NEWS_ERROR,
  NEWS_UPDATE,
  NEWS_UPDATE_ARRAY,
  NEWS_INSERT,
  NEWS_DELETE,
  NEWS_COMMENTS_REQUEST,
  NEWS_COMMENTS_SUCCESS,
  NEWS_COMMENTS_ERROR,
  NEWS_COMMENTS_INSERT,
  NEWS_COMMENTS_DELETE,
  CHANGELOG_SET_DATA,
  CHANGELOG_REQUEST,
  CHANGELOG_SUCCESS,
  CHANGELOG_ERROR,
  CHANGELOG_INSERT,
  CHANGELOG_UPDATE,
  CHANGELOG_DELETE,
  PVPSTATS_ADD_TOPARENATEAMS,
  PVPSTATS_ADD_TOPARENATEAMMEMBERS,
  PVPSTATS_ADD_TOPHKPLAYERS,
  PVPSTATS_SET_DATA,
  ADD_UNSTUCK_LOCATIONS,
  UPDATE_ALT_USER
} from "./mutation-types";
import Vue from "vue";

export const mainMutations = {
  [UPDATE_PAGE_TITLE](state, title) {
    state.PageTitle = title;
  },
  [ADD_UNSTUCK_LOCATIONS](state, payload) {
    state.UnstuckLocations = payload;
  }
};

export const adminMutations = {
  [ADMIN_REQUEST](state) {
    state.Admin.Loading = true;
  },
  [ADMIN_SUCCESS](state, payload) {
    state.Admin.Data = payload;
    state.Admin.Loading = false;
  },
  [ADMIN_ERROR](state) {
    state.Admin.Loading = false;
  }
};

export const voteMutations = {
  [VOTE_REQUEST_BEGIN](state) {
    state.Vote.Sites.Loading = true;
  },
  [VOTE_REQUEST_SUCCESS](state, payload) {
    Vue.set(state.Vote.Sites, "Data", payload);
    state.Vote.Sites.Loading = false;
  },
  [VOTE_REQUEST_ERROR](state) {
    state.Vote.Sites.Loading = false;
  },
  [VOTE_TIMERS_REQUEST](state) {
    state.Vote.Timers.Loading = true;
  },
  [VOTE_TIMERS_SUCCESS](state, payload) {
    Vue.set(state.Vote.Timers, "Data", payload);
    state.Vote.Timers.Loading = false;
  },
  [VOTE_TIMERS_ERROR](state) {
    state.Vote.Timers.Loading = false;
  },
  [VOTE_BEGIN](state) {
    state.Vote.Status = true;
  },
  [VOTE_SUCCESS](state, payload) {
    const { id, unsetTime } = payload;
    const site = state.Vote.Timers.Data.find(timer => timer.site == id);
    if (site != null) {
      site.unsetTimer = unsetTime;
    } else {
      state.Vote.Timers.Data.push({ site: id, unsetTimer: unsetTime });
    }

    state.Vote.Status = true;
  },
  [VOTE_ERROR](state) {
    state.Vote.Status = false;
  }
};

export const changelogMutations = {
  [CHANGELOG_SET_DATA](state, payload) {
    const { type, data } = payload;
    Vue.set(state.Changelog, type, data);
  }
};

export const pvpStatsMutations = {
  [PVPSTATS_SET_DATA](state, payload) {
    const { type, data } = payload;
    Vue.set(state.PvPStats, type, data);
  },
  [PVPSTATS_ADD_TOPARENATEAMS](state, payload) {
    state.PvPStats.TopArenaTeams.push(payload);
  },
  [PVPSTATS_ADD_TOPARENATEAMMEMBERS](state, payload) {
    state.PvPStats.TopTeamMembers.push(payload);
  },
  [PVPSTATS_ADD_TOPHKPLAYERS](state, payload) {
    state.PvPStats.TopHKPlayers.push(payload);
  }
};
