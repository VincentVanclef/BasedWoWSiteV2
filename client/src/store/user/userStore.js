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
    Token: null,
    User: null,
    Roles: [],
    TokenLifespan: 0
  },
  // ----------------------------------------------------------------------------------
  getters: {
    GetToken: state => state.Token,
    GetUser: state => state.User,
    GetUserRoles: state => state.Roles,
    GetTokenLifespan: state => state.TokenLifespan,
    IsUserLoggedIn: state => {
      const exp = state.TokenLifespan;
      const now = new Date();
      return now < exp;
    }
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
      state.Roles = [];
      state.TokenLifespan = 0;
    },
    UpdateUser: (state, payload) => {
      const { index, value } = payload;
      Vue.set(state.User, index, value);
      const userJSON = JSON.stringify(state.User);
      localStorage.setItem("user", userJSON);
    },
    SetToken: state => {
      const token = localStorage.getItem("token") || null;
      Vue.set(state, "Token", token);
    },
    SetUser: state => {
      const user = localStorage.getItem("user") || null;
      if (user) {
        try {
          Vue.set(state, "User", JSON.parse(user));
        } catch (e) {
          console.log(e);
        }
      }
    },
    SetUserRoles: state => {
      const token = state.Token;
      if (!token) return;
      try {
        const data = JSON.parse(atob(token.split(".")[1]));
        Vue.set(state, "Roles", data.role);
      } catch (e) {
        console.log(e);
      }
    },
    SetupTokenLifespan: state => {
      const token = state.Token;
      if (!token) return;
      try {
        const data = JSON.parse(atob(token.split(".")[1]));
        Vue.set(state, "TokenLifespan", data.exp * 1000); // JS deals with dates in milliseconds since epoch
      } catch (e) {
        console.log(e);
      }
    }
  },
  // ----------------------------------------------------------------------------------
  actions: {
    Login: async (context, loginModel) => {
      try {
        const data = await axios.post(`${API_AUTH}/Login`, loginModel);
        const { token, userDto } = data.data;
        const userJSON = JSON.stringify(userDto);

        localStorage.setItem("token", token);
        localStorage.setItem("user", userJSON);

        context.commit("Login", { token, userDto });
        context.commit("SetUserRoles");
        context.commit("SetupTokenLifespan");

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

        localStorage.setItem("token", token);
        localStorage.setItem("user", userJSON);

        context.commit("Login", { token, userDto });
        context.commit("SetUserRoles");
        context.commit("SetupTokenLifespan");

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
