export default {
  path: "/",
  redirect: "/news",
  name: "Home",
  component: () => import("@/pages/Home/Index"),
  children: [
    {
      path: "/news",
      name: "News",
      component: () => import("@/pages/Home/News"),
      meta: {
        title: "Titans League - WoW Server",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/connect",
      name: "Connect",
      component: () => import("@/pages/Home/Connect"),
      meta: {
        title: "How To Connect",
        requiredRoles: []
      }
    },
    {
      path: "/online",
      name: "Online Players",
      component: () => import("@/pages/Home/Online"),
      meta: {
        title: "Online Players",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/changelog",
      name: "Changelog",
      component: () => import("@/pages/Home/Changelog"),
      meta: {
        title: "Changelog",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/pvpstats",
      name: "PvP Statistics",
      component: () => import("@/pages/Home/PvPStats"),
      meta: {
        title: "PvP Statistics",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/tos",
      name: "Terms of Service",
      component: () => import("@/pages/Home/Tos"),
      meta: {
        title: "Terms of Service",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/error",
      name: "Permission Denied",
      component: () => import("@/pages/Home/Error"),
      meta: {
        title: "Permission Denied",
        hideAvatar: false,
        requiredRoles: []
      }
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
