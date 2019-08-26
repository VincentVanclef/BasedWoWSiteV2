// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import App from "./App";
import router from "./router";
import axios from "axios";
import VeeValidate from "vee-validate";
import BootstrapVue from "bootstrap-vue";
import store from "./store";
import Toasted from "vue-toasted";
import VuejsDialog from "vuejs-dialog";
import Gravatar from "vue-gravatar";
import CKEditor from "@ckeditor/ckeditor5-vue";
import signalR from "./signalR/signalr";
import UtilMixin from "./helpers/Utils";

Vue.config.productionTip = false;

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

Vue.prototype.$http = axios;

Vue.use(signalR);
Vue.use(CKEditor);
Vue.use(Gravatar);
Vue.use(VuejsDialog);
Vue.use(VeeValidate, { fieldsBagName: "veeFields" });
Vue.use(BootstrapVue);
Vue.use(Toasted, {
  duration: 8000,
  position: "top-center",
  fullWidth: true,
  fitToScreen: true,
  singleton: false,
  closeOnSwipe: true
});

store.dispatch("realms/FetchRealms").finally(() => {
  /* eslint-disable no-new */
  new Vue({
    mixins: [UtilMixin],
    el: "#app",
    store,
    router,
    components: { App },
    template: "<App/>"
  });
});
