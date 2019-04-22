import Index from "@/pages/User/Index";
import Login from "@/pages/User/Login";
import Register from "@/pages/User/Register";
import CreateAccount from "@/pages/User/CreateAccount";

import ProfileIndex from "@/pages/User/Profile/Index";
import ProfileAccount from "@/pages/User/Profile/Accounts";
import ProfileLinkAccount from "@/pages/User/Profile/LinkAccount";
import ProfileWebsite from "@/pages/User/Profile/Profile";
import ProfileChangePassword from "@/pages/User/Profile/Password";
import ProfileVote from "@/pages/User/Profile/Vote";
import ProfileDonate from "@/pages/User/Profile/Donate";


export default {
  path: "/user",
  component: Index,
  children: [
    {
      path: "/",
      name: "ProfileIndex",
      component: ProfileIndex,
      meta: {
        title: "User Profile",
        requiresAuth: true
      },
      children: [
        {
          path: "profile",
          name: "Website Profile",
          component: ProfileWebsite,
          meta: {
            title: "User Profile",
            requiresAuth: true
          }
        },
        {
          path: "accounts",
          name: "Ingame Accounts",
          component: ProfileAccount,
          meta: {
            title: "Ingame Accounts",
            requiresAuth: true
          }
        },
        {
          path: "accounts/link",
          name: "Link Ingame Account",
          component: ProfileLinkAccount,
          meta: {
            title: "Link Ingame Account",
            requiresAuth: true
          }
        },
        {
          path: "profile/password",
          name: "Change Password",
          component: ProfileChangePassword,
          meta: {
            title: "Change Website Password",
            requiresAuth: true
          }
        },
        {
          path: "vote",
          name: "Vote",
          component: ProfileVote,
          meta: {
            title: "Vote",
            requiresAuth: true
          }
        },
        {
          path: "donate",
          name: "Donate",
          component: ProfileDonate,
          meta: {
            title: "Donate",
            requiresAuth: true
          }
        }
      ]
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
    },
    {
      path: "create/account",
      name: "Create Account",
      component: CreateAccount,
      meta: {
        title: "Create Ingame Account",
        requiresAuth: true
      }
    }
  ]
};
