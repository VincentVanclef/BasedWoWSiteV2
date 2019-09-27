import Vue from "vue";
import Toasted from "vue-toasted";
import axios from "axios";
import store from "@/store";

export default {
  install(Vue) {
    Vue.use(Toasted, {
      duration: 7000,
      position: "top-center",
      fullWidth: true,
      fitToScreen: true,
      singleton: false,
      closeOnSwipe: true
    });

    axios.interceptors.request.use(
      config => {
        const token = localStorage.getItem("token");

        if (token) {
          config.headers["Authorization"] = `Bearer ${token}`;
        }

        return config;
      },

      error => {
        return Promise.reject(error);
      }
    );

    axios.interceptors.response.use(
      response => {
        return response;
      },
      async error => {
        if (error.response) {
          switch (error.response.status) {
            case 401:
            case 403:
              Vue.prototype.$toasted.error(
                "You are not authorized to perform this action."
              );
              await store.dispatch("user/Logout");
              break;
            case 429:
              Vue.prototype.$toasted.error(error.response.data);
              break;
            default:
              Vue.prototype.$toasted.error(error.response.data.message);
              break;
          }
        } else {
          Vue.prototype.$toasted.error(error);
        }

        return Promise.reject(error);
      }
    );

    Vue.prototype.$http = axios;
  }
};
