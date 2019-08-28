import Vue from "vue";
import App from "./App";
import router from "./router";
import VeeValidate from "vee-validate";
import BootstrapVue from "bootstrap-vue";
import store from "./store";
import Gravatar from "vue-gravatar";
import CKEditor from "@ckeditor/ckeditor5-vue";
import signalR from "./signalR/signalr";
import axios from "./helpers/axiosInterceptor";

Vue.config.productionTip = false;

Vue.use(axios);
Vue.use(signalR);
Vue.use(CKEditor);
Vue.use(Gravatar);
Vue.use(VeeValidate, { fieldsBagName: "veeFields" });
Vue.use(BootstrapVue);

store.dispatch("realms/FetchRealms").finally(() => {
  /* eslint-disable no-new */
  new Vue({
    el: "#app",
    store,
    router,
    components: { App },
    template: "<App/>"
  });
});
