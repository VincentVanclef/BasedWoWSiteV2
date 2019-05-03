import Vue from "vue";
import Router from "vue-router";
import Store from "../store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
//import DetailsRoutes from './details';
import CartRoutes from "./cart";
import UserRoutes from "./user";
import UserHelper from "../helpers/UserHelper";

Vue.use(Router);

const router = new Router({
  mode: "history",
  routes: [
    HomeRoutes,
    AdminRoutes,
    //    DetailsRoutes,
    CartRoutes,
    UserRoutes
  ]
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.meta.requiresAuth;

  document.title = to.meta.title;

  if (requiresAuth && !UserHelper.IsLoggedIn()) {
    Store.dispatch("Logout");
    next("/user/login");
  } else {
    next();
  }
});

export default router;
