import Vue from "vue";
import axios from "axios";
import router from "@/router";
import accountStore from "./account/accountStore";
import donateStore from "./donate/donateStore";
import characterStore from "./characters/characterStore";
import guildStore from "./guilds/guildStore";

const API_AUTH = process.env.API.AUTH;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  modules: {
    account: accountStore,
    donate: donateStore,
    characters: characterStore,
    guild: guildStore
  },
  // ----------------------------------------------------------------------------------
  state: {
    Token: localStorage.getItem("token") || "",
    User: JSON.parse(localStorage.getItem("user")) || null
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetToken: state => state.Token,
    GetUser: state => state.User
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    Login: (state, payload) => {
      const { token, userDto } = payload;
      Vue.set(state, "Token", token);
      Vue.set(state, "User", userDto);
    },
    Logout: state => {
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      state.Token = "";
      state.User = null;
    },
    UpdateUser: (state, payload) => {
      const { index, value } = payload;
      Vue.set(state.User, index, value);
      const userJSON = JSON.stringify(state.User);
      localStorage.setItem("user", userJSON);
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    Login: async (context, loginModel) => {
      try {
        const data = await axios.post(`${API_AUTH}/Login`, loginModel);
        const { token, userDto } = data.data;
        const userJSON = JSON.stringify(userDto);

        context.commit("Login", { token, userDto });

        localStorage.setItem("token", token);
        localStorage.setItem("user", userJSON);

        router.push("/user/profile");

        // Reconnect to signal-r with new token providers
        Vue.prototype.$signalR.connection.stop();
        axios.defaults.headers.common.Authorization = token;
        return Promise.resolve(userDto);
      } catch (error) {
        return Promise.reject(error);
      }
    },
    Register: async (context, registerModel) => {
      try {
        const data = await axios.post(`${API_AUTH}/Register`, registerModel);
        const { token, userDto } = data.data;
        const userJSON = JSON.stringify(userDto);

        context.commit("Login", { token, userDto });

        localStorage.setItem("token", token);
        localStorage.setItem("user", userJSON);

        router.push("/user/profile");

        // Reconnect to signal-r with new token providers
        Vue.prototype.$signalR.connection.stop();
        axios.defaults.headers.common.Authorization = token;
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    Logout: async context => {
      try {
        await axios.post(`${API_AUTH}/Logout`);
      } catch (error) {
        return Promise.reject(error);
      }

      context.commit("Logout");

      router.push("/news").catch(err => {});

      // Reconnect to signal-r without token providers
      Vue.prototype.$signalR.connection.stop();
      delete axios.defaults.headers.common.Authorization;
      return Promise.resolve();
    }
  }
};
