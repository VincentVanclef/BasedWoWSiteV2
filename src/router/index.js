import Vue from 'vue';
import Router from 'vue-router';

/* Pages */
import HomeRoutes from './home';
import AdminRoutes from './admin';
//import DetailsRoutes from './details';
import CartRoutes from './cart';
import UserRoutes from './user';

Vue.use(Router);

const router = new Router({
  routes: [
    HomeRoutes,
    AdminRoutes,
//    DetailsRoutes,
    CartRoutes,
    UserRoutes,
  ],
});

// Set Document Title
router.afterEach((to, from) => {
  document.title = to.meta.title;
});

export default router;