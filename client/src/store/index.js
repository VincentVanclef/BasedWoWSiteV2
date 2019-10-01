import Vue from "vue";
import Vuex from "vuex";

import newsStore from "./news/newsStore";
import adminStore from "./admin/adminStore";
import statisticsStore from "./statistics/statisticsStore";
import userStore from "./user/userStore";
import voteStore from "./user/vote/voteStore";
import shoutBoxStore from "./shoutbox/shoutBoxStore";
import realmStore from "./realms/realmStore";
import armoryStore from "./armory/armoryStore";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  modules: {
    news: newsStore,
    admin: adminStore,
    stats: statisticsStore,
    user: userStore,
    vote: voteStore,
    shoutbox: shoutBoxStore,
    realms: realmStore,
    armory: armoryStore
  },
  state: {
    PageTitle: "",
    WebsiteVersion: ""
  },
  mutations: {
    UpdatePageTitle: (state, title) => {
      state.PageTitle = title;
    },
    UpdateWebsiteVersion: (state, version) => {
      state.WebsiteVersion = version;
    }
  },
  getters: {
    GetPageTitle: state => state.PageTitle,
    GetWebsiteVersion: state => state.WebsiteVersion
  },
  actions: {}
});
