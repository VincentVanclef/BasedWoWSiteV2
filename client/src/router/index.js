import Vue from "vue";
import Router from "vue-router";
import Store from "../store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
import CartRoutes from "./cart";
import UserRoutes from "./user";
import ProfileRoutes from "./profile";

import UserHelper from "../helpers/UserHelper";
import GMRanks from "@/data/models/Ranks";

Vue.use(Router);

const router = new Router({
  mode: "history",
  routes: [HomeRoutes, AdminRoutes, CartRoutes, UserRoutes, ProfileRoutes]
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.meta.requiresAuth;
  const requiredRank = to.meta.requiredRank;

  document.title = to.meta.title;

  Store.commit("UPDATE_PAGE_TITLE", to.meta.title);

  if (requiresAuth) {
    if (!UserHelper.IsLoggedIn()) {
      Store.dispatch("Logout");
      next("/user/login");
      return;
    }
  }

  if (requiredRank > 0) {
    if (UserHelper.GetUserRank() < requiredRank) {
      next("/admin/error");
      return;
    }
  }

  next();
});

export default router;
