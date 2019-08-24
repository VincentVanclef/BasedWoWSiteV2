import Vue from "vue";
import Router from "vue-router";
import Store from "../store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
import UserRoutes from "./user";
import ProfileRoutes from "./profile";

import UserHelper from "../helpers/UserHelper";
import WebsiteRoles from "@/data/models/Ranks";

Vue.use(Router);

const router = new Router({
  mode: "history",
  routes: [HomeRoutes, AdminRoutes, UserRoutes, ProfileRoutes]
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.meta.requiresAuth;
  const requiredRoles = to.meta.requiredRoles;

  document.title = to.meta.title;

  Store.commit("UPDATE_PAGE_TITLE", to.meta.title);

  if (requiresAuth) {
    if (!UserHelper.IsLoggedIn()) {
      Store.commit("user/Logout");
      next("/user/login");
      return;
    }
  }

  if (requiredRoles.length > 0) {
    if (!UserHelper.HasRole(requiredRoles)) {
      next("/error");
      return;
    }
  }

  next();
});

export default router;
