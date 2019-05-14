import axios from "axios";

const API_STORE = process.env.API.STORE;
const API_AUTH = process.env.API.AUTH;
const API_VOTE = process.env.API.VOTE;
const API_NEWS = process.env.API.NEWS;

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
  NEWS_REQUEST,
  NEWS_SUCCESS,
  NEWS_ERROR,
  NEWS_UPDATE,
  NEWS_COMMENTS_REQUEST,
  NEWS_COMMENTS_SUCCESS,
  NEWS_COMMENTS_ERROR,
  NEWS_COMMENTS_INSERT
} from "./mutation-types";

export const mainActions = {};

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

async function GetUsernameById(userId) {
  let result;
  try {
    result = await axios.post(`${process.env.API.AUTH}/getusername`, {
      UserId: userId
    });
  } catch (error) {
    console.log(error);
    return "null";
  }

  return result.data.username;
}

export const newsActions = {
  async GetNews({ commit }) {
    commit(NEWS_REQUEST);
    let result;
    try {
      result = await axios.get(API_NEWS);

      // Load Total Comments & Author
      for (const news of result.data) {
        const author = await GetUsernameById(news.author);
        news.author = author;

        const commentsData = await axios.get(
          `${process.env.API.NEWS}/comments/${news.id}/total`
        );

        const { total } = commentsData.data;
        news.totalComments = total;

        commit(NEWS_COMMENTS_INSERT, news.id);
      }
    } catch (err) {
      commit(NEWS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }
    commit(NEWS_SUCCESS, result.data);
    return "success";
  },
  async GetNewsComments({ commit }, newsId) {
    commit(NEWS_COMMENTS_REQUEST, newsId);
    let result;
    try {
      result = await axios.get(`${process.env.API.NEWS}/comments/${newsId}`);
    } catch (err) {
      commit(NEWS_COMMENTS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }

    // Load commentator names
    for (const data of result.data) {
      const username = await GetUsernameById(data.UserId);
      data.username = username;
    }

    commit(NEWS_COMMENTS_SUCCESS, { newsId, commentData: result.data });
    return "success";
  },
  async PostNewComment({ commit }, payload) {
    const { newsId, userId, comment } = payload;

    commit(NEWS_COMMENTS_REQUEST, newsId);
    let result;

    try {
      result = await axios.post(`${process.env.API.NEWS}/comments/new`, {
        newsid: newsId,
        userid: userId,
        comment: comment
      });
    } catch (err) {
      commit(NEWS_COMMENTS_ERROR);
      if (err.response) {
        return err.response.data.message;
      } else {
        return err.message;
      }
    }

    commit(NEWS_UPDATE, {
      newsid: newsId,
      index: "totalComments",
      value: result.data.length
    });

    // Load commentator names
    for (const data of result.data) {
      const username = await GetUsernameById(data.UserId);
      data.username = username;
    }

    commit(NEWS_COMMENTS_SUCCESS, { newsId, commentData: result.data });
    return "success";
  }
};
