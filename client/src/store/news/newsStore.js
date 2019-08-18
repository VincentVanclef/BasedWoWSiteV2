import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.NEWS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {
    News: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetNews: state => state.News,
    GetNewsById: state => id => {
      return state.News.find(x => x.id == id);
    },
    GetCommentsForNews: state => newsId => {}
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    SetNews: (state, data) => {
      Vue.set(state, "News", data);
    },
    SetComments: (state, payload) => {
      const { newsId, comments } = payload;
      const news = state.News.find(x => x.id == newsId);
      Vue.set(news, "comments", comments);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchNews: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetNews`);
        context.commit("SetNews", response.data);
        return Promise.resolve(context.state.News);
      } catch (error) {
        context.commit("SetNews", []);
        return Promise.reject(error);
      }
    },
    FetchCommentsForNews: async (context, newsId) => {
      try {
        const response = await axios.get(
          `${API_URL}/GetCommentsForNews/${newsId}`
        );
        context.commit("SetComments", response.data);
        return Promise.resolve(context.state.Comments);
      } catch (error) {
        context.commit("SetComments", []);
        return Promise.reject(error);
      }
    },
    AddComment: async (context, payload) => {
      const { newsId, comment } = payload;
      try {
        const response = await axios.post(`${API_URL}/AddComment`, {
          newsId,
          comment
        });
        context.commit("SetComments", { newsId, comments: response.data });
        return Promise.resolve(context.state.Comments);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    DeleteComment: async (context, payload) => {
      const { newsId, commentId } = payload;
      try {
        const response = await axios.post(`${API_URL}/DeleteComment`, {
          id: commentId
        });
        context.commit("SetComments", { newsId, comments: response.data });
        return Promise.resolve(context.state.Comments);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
