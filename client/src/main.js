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
import TextHighlight from "vue-text-highlight";
import datePicker from "vue-bootstrap-datetimepicker";

import CharacterComponent from "@/components/Admin/Characters/Views/CharacterComponent";
import ItemTooltipDirective from "@/components/Armory/Items/ItemTooltipDirective";
import ItemComponent from "@/components/Armory/Items/ItemComponent";

Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(CKEditor);
Vue.use(Gravatar);
Vue.use(VeeValidate, { fieldsBagName: "veeFields" });
Vue.use(datePicker);
Vue.use(ItemTooltipDirective);
Vue.use(signalR);
Vue.use(axios);

Vue.component("text-highlight", TextHighlight);
Vue.component("character-component", CharacterComponent);
Vue.component("item", ItemComponent);

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
