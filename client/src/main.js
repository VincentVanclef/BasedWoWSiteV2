import Vue from "vue";
import App from "./App";
import router from "./router";
import VeeValidate from "vee-validate";
import BootstrapVue from "bootstrap-vue";
import store from "./store";
import Gravatar from "vue-gravatar";
import signalR from "./signalR/main/signalR";
import axios from "./helpers/axiosInterceptor";
import TextHighlight from "vue-text-highlight";
import vClickOutside from "v-click-outside";
import ItemTooltipDirective from "@/components/Armory/Items/ItemTooltipDirective";
import ContextMenuDirective from "@/components/ContextMenu/ContextMenuDirective";
import EmojiDirective from "@/components/Emoji/EmojiDirective";

import { EmojiPickerPlugin } from "vue-emoji-picker";

Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(EmojiPickerPlugin);
Vue.use(VeeValidate, { fieldsBagName: "veeFields" });
Vue.use(ItemTooltipDirective);
Vue.use(ContextMenuDirective);
Vue.use(EmojiDirective);
Vue.use(signalR);
Vue.use(axios);
Vue.use(vClickOutside);

Vue.component("vue-gravatar", Gravatar);
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
