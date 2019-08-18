import Vue from "vue";
import axios from "axios";

const API_URL = process.env.API.NEWS;

import { NewsData } from "../../data/models/News";

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
    GetCommentsForNews: state => id => {
      const news = state.News.find(x => x.id == id);
      return news ? news.comments : null;
    }
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
    },
    EditComment: (state, newComment) => {
      const news = state.News.find(x => x.id == newComment.newsId);
      if (news == null) return;
      const oldComment = news.comments.find(x => x.id == newComment.id);
      if (oldComment == null) return;
      Object.assign(oldComment, newComment);
    },
    AddNews: (state, data) => {
      state.News.unshift(data);
    },
    DeleteNews: (state, id) => {
      const index = state.News.findIndex(x => x.id == id);
      state.News.splice(index, 1);
    },
    EditNews: (state, payload) => {
      const { id, data } = payload;
      const news = state.News.find(x => x.id == id);
      Object.assign(news, data);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    FetchNews: async context => {
      try {
        const response = await axios.get(`${API_URL}/GetNews`);
        context.commit("SetNews", response.data);
        return Promise.resolve();
      } catch (error) {
        context.commit("SetNews", [NewsData]);
        return Promise.reject(error);
      }
    },
    FetchCommentsForNews: async (context, newsId) => {
      try {
        const response = await axios.get(
          `${API_URL}/GetCommentsForNews/${newsId}`
        );
        context.commit("SetComments", response.data);
        return Promise.resolve();
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
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    EditComment: async (context, comment) => {
      try {
        const response = await axios.post(`${API_URL}/EditComment`, comment);
        context.commit("EditComment", response.data);
        return Promise.resolve();
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
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    CreateNews: async (context, payload) => {
      const { title, author, content, image } = payload;
      try {
        const response = await axios.post(`${API_URL}/CreateNews`, {
          title,
          author,
          content,
          image
        });
        context.commit("AddNews", response.data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    DeleteNews: async (context, id) => {
      try {
        await axios.post(`${API_URL}/DeleteNews`, {
          id
        });
        context.commit("DeleteNews", id);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    EditNews: async (context, payload) => {
      const { id, title, content, author, image } = payload;
      try {
        const result = await axios.post(`${API_URL}/EditNews`, {
          id,
          title,
          content,
          author,
          image
        });
        context.commit("EditNews", { id, data: result.data });
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
