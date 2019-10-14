import Vue from "vue";
import Router from "vue-router";
import Store from "@/store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
import UserRoutes from "./user";
import ProfileRoutes from "./profile";
import ArmoryRoutes from "./armory";
import ChatRoutes from "./chat";

import UserHelper from "../helpers/UserHelper";
import Config from "@/assets/config/config";

Vue.use(Router);

const router = new Router({
  mode: "history",
  routes: [
    HomeRoutes,
    AdminRoutes,
    UserRoutes,
    ProfileRoutes,
    ArmoryRoutes,
    ChatRoutes
  ],
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    } else {
      return { x: 0, y: 0 };
    }
  }
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.meta.requiresAuth;
  const requiredRoles = to.meta.requiredRoles;

  document.title = `${Config.SERVER_TITLE} - ${to.meta.title}`;

  Store.commit("UpdatePageTitle", to.meta.title);

  if (requiresAuth) {
    if (!UserHelper.IsLoggedIn()) {
      Store.commit("user/Logout");
      Store.commit("chat/Clear");
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
