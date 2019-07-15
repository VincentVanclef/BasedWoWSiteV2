import Index from "@/pages/User/Index";
import Login from "@/pages/User/Login";
import Register from "@/pages/User/Register";
//import CreateAccount from "@/pages/User/CreateAccount";

import Vote from "@/pages/User/Vote";
import Donate from "@/pages/User/Donate";
import DonateSuccess from "@/pages/User/DonateSuccess";

import ProfileIndex from "@/pages/User/Profile/Index";
import ProfileAccount from "@/pages/User/Profile/Account";
import ProfileWebsite from "@/pages/User/Profile/Profile";
import ProfileChangePassword from "@/pages/User/Profile/Password";
import ProfileGravatar from "@/pages/User/Profile/Gravatar";
import ProfileEdit from "@/pages/User/Profile/Edit";
import ProfileChars from "@/pages/User/Profile/Characters"

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
          path: "account",
          name: "Ingame Account",
          component: ProfileAccount,
          meta: {
            title: "Ingame Account",
            requiresAuth: true
          }
        },
        {
          path: "characters",
          name: "Ingame Characters",
          component: ProfileChars,
          meta: {
            title: "Character Tools",
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
          path: "profile/gravatar",
          name: "Gravatar Settings",
          component: ProfileGravatar,
          meta: {
            title: "Gravatar Settings",
            requiresAuth: true
          }
        },
        {
          path: "profile/edit",
          name: "Edit Profile",
          component: ProfileEdit,
          meta: {
            title: "Edit Profile",
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
    /*{
      path: "create/account",
      name: "Create Account",
      component: CreateAccount,
      meta: {
        title: "Create Ingame Account",
        requiresAuth: true
      }
    },*/
    {
      path: "vote",
      name: "Vote",
      component: Vote,
      meta: {
        title: "Vote",
        requiresAuth: true
      }
    },
    {
      path: "donate",
      name: "Donate",
      component: Donate,
      meta: {
        title: "Donate",
        requiresAuth: true
      },
      children: []
    },
    {
      path: "donate/success",
      name: "Donate Success",
      component: DonateSuccess,
      meta: {
        title: "Donate Success",
        requiresAuth: true
      }
    }
  ]
};
