import axios from "axios";
import store from "@/store";

export default {
  install(Vue) {
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
      response => response,
      async error => {
        const vm = new Vue();
        if (error.response) {
          switch (error.response.status) {
            case 401:
            case 403:
              vm.$bvToast.toast(
                `You are not authorized to perform this action.`,
                {
                  title: "Unauthorized",
                  variant: "danger",
                  solid: true
                }
              );
              await store.dispatch("user/Logout");
              break;
            default:
              vm.$bvToast.toast(error.response.data.message, {
                title: `Error (${error.response.status})`,
                variant: "danger",
                solid: true
              });
              break;
          }
        } else {
          vm.$bvToast.toast(error.message, {
            title: `Network Error`,
            variant: "danger",
            solid: true
          });
        }

        return Promise.reject(error);
      }
    );

    Vue.prototype.$http = axios;
  }
};
