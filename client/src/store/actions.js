import axios from "axios";

const API_CHAR = process.env.API.CHARACTERS;

import { ADD_UNSTUCK_LOCATIONS } from "./mutation-types";

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

export const changelogActions = {};
