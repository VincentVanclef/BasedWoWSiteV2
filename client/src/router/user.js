import Index from "@/pages/User/Index";
import Login from "@/pages/User/Login";
import Register from "@/pages/User/Register";
import Profile from "@/pages/User/Profile";

export default {
  path: "/user",
  component: Index,
  children: [
    {
      path: "/",
      name: "Profile",
      component: Profile,
      meta: {
        title: "User Profile",
        requiresAuth: true
      }
    },
    {
      path: "login",
      name: "Login",
      component: Login,
      meta: {
        title: "Login"
      }
    },
    {
      path: "register",
      name: "Register",
      component: Register,
      meta: {
        title: "Register"
      }
    }
  ]
};
