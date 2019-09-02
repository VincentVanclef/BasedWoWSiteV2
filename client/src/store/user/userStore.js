import Vue from "vue";
import axios from "axios";
import router from "@/router";
import accountStore from "./account/accountStore";
import donateStore from "./donate/donateStore";

const API_AUTH = process.env.API.AUTH;
const API_CHAR = process.env.API.CHARACTERS;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  modules: {
    account: accountStore,
    donate: donateStore
  },
  // ----------------------------------------------------------------------------------
  state: {
    Token: localStorage.getItem("token") || "",
    User: JSON.parse(localStorage.getItem("user")) || null,
    Characters: []
  },
  // ----------------------------------------------------------------------------------
  getters: {
    isLoggedIn: state => {
      const token = state.Token;
      if (!token) {
        return false;
      }

      const data = JSON.parse(atob(token.split(".")[1]));
      const exp = new Date(data.exp * 1000);
      const now = new Date();
      return now < exp;
    },
    GetToken: state => state.Token,
    GetUser: state => state.User,
    GetCharacters: state => state.Characters
  },
  // ----------------------------------------------------------------------------------
  mutations: {
    Login: (state, payload) => {
      const { token, userDto } = payload;
      Vue.set(state, "Token", token);
      Vue.set(state, "User", userDto);
    },
    Logout: state => {
      state.Token = "";
      state.User = null;
      localStorage.removeItem("token");
      localStorage.removeItem("user");
    },
    UpdateUser: (state, payload) => {
      const { index, value } = payload;
      Vue.set(state.User, index, value);
      const userJSON = JSON.stringify(state.User);
      localStorage.setItem("user", userJSON);
    },
    AddCharacters: (state, data) => {
      state.Characters.push(data);
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

        axios.defaults.headers.common.Authorization = token;

        router.push("/user/profile");

        // Reconnect to signal-r with new token providers
        Vue.prototype.$signalR.connection.stop();
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

        axios.defaults.headers.common.Authorization = token;

        router.push("/user/profile");

        // Reconnect to signal-r with new token providers
        Vue.prototype.$signalR.connection.stop();
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

      router.push("/news");

      // Reconnect to signal-r without token providers
      Vue.prototype.$signalR.connection.stop();
      delete axios.defaults.headers.common.Authorization;
      return Promise.resolve();
    },
    GetCharacters: async (context, payload) => {
      const { RealmType, AccountId } = payload;
      try {
        const result = await axios.post(
          `${API_CHAR}/GetAllCharactersByAccountId`,
          {
            RealmType,
            AccountId
          }
        );
        const data = {
          realmid: RealmType,
          data: result.data
        };
        context.commit("AddCharacters", data);
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
