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
import ProfileChars from "@/pages/User/Profile/Characters";

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
        requiresAuth: true,
        requiredRoles: []
      },
      children: [
        {
          path: "profile",
          name: "Website Profile",
          component: ProfileWebsite,
          meta: {
            title: "User Profile",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "account",
          name: "Ingame Account",
          component: ProfileAccount,
          meta: {
            title: "Ingame Account",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "characters",
          name: "Ingame Characters",
          component: ProfileChars,
          meta: {
            title: "Character Tools",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/password",
          name: "Change Password",
          component: ProfileChangePassword,
          meta: {
            title: "Change Website Password",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/gravatar",
          name: "Gravatar Settings",
          component: ProfileGravatar,
          meta: {
            title: "Gravatar Settings",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/edit",
          name: "Edit Profile",
          component: ProfileEdit,
          meta: {
            title: "Edit Profile",
            requiresAuth: true,
            requiredRoles: []
          }
        }
      ]
    },
    {
      path: "login",
      name: "Login",
      component: Login,
      meta: {
        title: "Login",
        requiredRoles: []
      }
    },
    {
      path: "register",
      name: "Register",
      component: Register,
      meta: {
        title: "Register",
        requiredRoles: []
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
        requiresAuth: true,
        requiredRoles: []
      }
    },
    {
      path: "donate",
      name: "Donate",
      component: Donate,
      meta: {
        title: "Donate",
        requiresAuth: true,
        requiredRoles: []
      },
      children: []
    },
    {
      path: "donate/success",
      name: "Donate Success",
      component: DonateSuccess,
      meta: {
        title: "Donate Success",
        requiresAuth: true,
        requiredRoles: []
      }
    }
  ]
};
