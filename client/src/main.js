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
import CKEditor from '@ckeditor/ckeditor5-vue';

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

/*const token = localStorage.getItem("token");
if (token) {
  Vue.prototype.$http.defaults.headers.common.Authorization = "Bearer " + token;
}*/

Vue.use(CKEditor);
Vue.use(Gravatar);
Vue.use(VuejsDialog);
Vue.use(VeeValidate);
Vue.use(BootstrapVue);
Vue.use(Toasted, {
  duration: 5000,
  position: "top-center",
  fullWidth: true,
  fitToScreen: true,
  singleton: true,
  closeOnSwipe: true
});

/* eslint-disable no-new */
new Vue({
  el: "#app",
  store,
  router,
  components: { App },
  template: "<App/>"
});
