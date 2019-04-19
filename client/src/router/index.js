import Vue from "vue";
import Router from "vue-router";
import store from "../store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
//import DetailsRoutes from './details';
import CartRoutes from "./cart";
import UserRoutes from "./user";
import UserHelper from "../helpers/UserHelper"

Vue.use(Router);

const router = new Router({
  routes: [
    HomeRoutes,
    AdminRoutes,
    //    DetailsRoutes,
    CartRoutes,
    UserRoutes
  ]
});

router.beforeEach((to, from, next) => {
  const requiresAuth = to.meta.requiresAuth

  document.title = to.meta.title

  if (requiresAuth && !UserHelper.IsLoggedIn()) {
    store.dispatch("Logout")
    next("/user/login")
  } else {
    next()
  }
});

export default router;
