import Vue from "vue";
import Router from "vue-router";
import store from "../store";

/* Pages */
import HomeRoutes from "./home";
import AdminRoutes from "./admin";
//import DetailsRoutes from './details';
import CartRoutes from "./cart";
import UserRoutes from "./user";

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
  const requiresAuth = to.meta.requiresAuth;

  let isLoggedIn = false
  const token = store.getters.token;
  if (token) {
     const data = JSON.parse(atob(token.split('.')[1]))
     const exp = new Date(data.exp * 1000) // JS deals with dates in milliseconds since epoch
     const now = new Date()
     isLoggedIn = now < exp
  }

  document.title = to.meta.title;

  if (requiresAuth && !isLoggedIn) {
    store.dispatch("Logout");
    next("/user/login");
  } else {
    next();
  }
});

export default router;
