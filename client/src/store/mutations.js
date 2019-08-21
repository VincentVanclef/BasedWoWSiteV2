import {
  UPDATE_PAGE_TITLE,
  CHANGELOG_SET_DATA,
  ADD_UNSTUCK_LOCATIONS
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

export const changelogMutations = {
  [CHANGELOG_SET_DATA](state, payload) {
    const { type, data } = payload;
    Vue.set(state.Changelog, type, data);
  }
};
