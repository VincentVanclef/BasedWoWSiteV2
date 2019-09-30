import Vue from "vue";
import App from "./App";
import router from "./router";
import VeeValidate from "vee-validate";
import BootstrapVue from "bootstrap-vue";
import store from "./store";
import Gravatar from "vue-gravatar";
import signalR from "./signalR/signalr";
import axios from "./helpers/axiosInterceptor";
import TextHighlight from "vue-text-highlight";

import ItemTooltipDirective from "@/components/Armory/Items/ItemTooltipDirective";

Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(Gravatar);
Vue.use(VeeValidate, { fieldsBagName: "veeFields" });
Vue.use(ItemTooltipDirective);
Vue.use(signalR);
Vue.use(axios);

Vue.component("text-highlight", TextHighlight);

store.dispatch("realms/FetchRealms").finally(() => {
  /* eslint-disable no-new */
  new Vue({
    el: "#app",
    store,
    router,
    components: { App },
    template: "<App/>",
    methods: {
      ToastSuccess(msg, title) {
        this.$bvToast.toast(msg, {
          title: title || "Success",
          variant: "success",
          solid: true
        });
      },
      ToastWarning(msg, title) {
        this.$bvToast.toast(msg, {
          title: title || "Warning",
          variant: "warning",
          solid: true
        });
      },
      ToastError(msg, title) {
        this.$bvToast.toast(msg, {
          title: title || "Error",
          variant: "danger",
          solid: true
        });
      }
    },
    created() {}
  });
});
