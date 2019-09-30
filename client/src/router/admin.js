import Ranks from "@/data/models/Ranks";

export default {
  path: "/admin",
  component: () => import("@/pages/Admin/Index"),
  meta: {
    title: "Admin Panel",
    requiresAuth: true,
    requiredRoles: [Ranks.WebsiteRoles.ADMIN, Ranks.WebsiteRoles.MODERATOR]
  },
  children: [
    // ----------------------------------------------------------------------------------
    {
      path: "members",
      name: "Admin Members",
      component: () => import("@/pages/Admin/Members/Index"),
      meta: {
        title: "Admin - Members",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN, Ranks.WebsiteRoles.MODERATOR]
      },
      children: [
        {
          path: "admins",
          name: "Administrators",
          component: () => import("@/pages/Admin/Members/Admins"),
          meta: {
            title: "Administrators",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        },
        {
          path: "moderators",
          name: "Moderators",
          component: () => import("@/pages/Admin/Members/Moderators"),
          meta: {
            title: "Moderators",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        },
        {
          path: "search",
          name: "MembersSearch",
          component: () => import("@/pages/Admin/Members/Search"),
          meta: {
            title: "Search Members",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        }
      ]
    },
    // ----------------------------------------------------------------------------------
    {
      path: "accounts",
      name: "Admin Accounts",
      component: () => import("@/pages/Admin/Accounts/Index"),
      meta: {
        title: "Admin - Accounts",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN, Ranks.WebsiteRoles.MODERATOR]
      },
      children: [
        {
          path: "trials",
          name: "Trial GameMasters",
          component: () => import("@/pages/Admin/Accounts/Trials"),
          meta: {
            title: "Ingame Trials",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        },
        {
          path: "gamemasters",
          name: "Ingame GameMasters",
          component: () => import("@/pages/Admin/Accounts/GameMasters"),
          meta: {
            title: "Ingame GameMasters",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        },
        {
          path: "admins",
          name: "Ingame Admins",
          component: () => import("@/pages/Admin/Accounts/Admins"),
          meta: {
            title: "Ingame Admins",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        },
        {
          path: "search",
          name: "Search Accounts",
          component: () => import("@/pages/Admin/Accounts/Search"),
          meta: {
            title: "Search Accounts",
            requiresAuth: true,
            requiredRoles: [
              Ranks.WebsiteRoles.ADMIN,
              Ranks.WebsiteRoles.MODERATOR
            ]
          }
        }
      ]
    },
    // ----------------------------------------------------------------------------------
    {
      path: "news",
      name: "Admin News",
      component: () => import("@/pages/Admin/News/Index"),
      meta: {
        title: "Admin - News",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN]
      },
      children: [
        {
          path: "edit",
          name: "Edit News",
          component: () => import("@/pages/Admin/News/Edit"),
          meta: {
            title: "Edit News",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "create",
          name: "Create News",
          component: () => import("@/pages/Admin/News/Create"),
          meta: {
            title: "Create News",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "delete",
          name: "Delete News",
          component: () => import("@/pages/Admin/News/Delete"),
          meta: {
            title: "Delete News",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        }
      ]
    }
  ]
};
