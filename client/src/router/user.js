export default {
  path: "/user",
  component: () => import("@/pages/User/Index"),
  children: [
    {
      path: "/",
      name: "ProfileIndex",
      component: () => import("@/pages/User/Profile/Index"),
      meta: {
        title: "User Profile",
        requiresAuth: true,
        requiredRoles: []
      },
      children: [
        {
          path: "profile",
          name: "Website Profile",
          component: () => import("@/pages/User/Profile/Profile"),
          meta: {
            title: "User Profile",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "account",
          name: "Ingame Account",
          component: () => import("@/pages/User/Profile/Account"),
          meta: {
            title: "Ingame Account",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "characters",
          name: "Character Services",
          component: () => import("@/pages/User/Profile/Characters"),
          meta: {
            title: "Character Services",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/password",
          name: "Change Password",
          component: () => import("@/pages/User/Profile/Password"),
          meta: {
            title: "Change Website Password",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/gravatar",
          name: "Gravatar Settings",
          component: () => import("@/pages/User/Profile/Gravatar"),
          meta: {
            title: "Gravatar Settings",
            requiresAuth: true,
            requiredRoles: []
          }
        },
        {
          path: "profile/edit",
          name: "Edit Profile",
          component: () => import("@/pages/User/Profile/Edit"),
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
      component: () => import("@/pages/User/Login"),
      meta: {
        title: "Login",
        requiredRoles: []
      }
    },
    {
      path: "register",
      name: "Register",
      component: () => import("@/pages/User/Register"),
      meta: {
        title: "Register",
        requiredRoles: []
      }
    },
    {
      path: "vote",
      name: "Vote",
      component: () => import("@/pages/User/Vote"),
      meta: {
        title: "Vote",
        requiresAuth: true,
        requiredRoles: []
      }
    },
    {
      path: "donate",
      name: "Donate",
      component: () => import("@/pages/User/Donate"),
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
      component: () => import("@/pages/User/DonateSuccess"),
      meta: {
        title: "Donate Success",
        requiresAuth: true,
        requiredRoles: []
      }
    }
  ]
};
