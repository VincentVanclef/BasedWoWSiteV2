import Index from "@/pages/Admin/Index";

import MembersIndex from "@/pages/Admin/Members/Index";
import MembersAdmins from "@/pages/Admin/Members/Admins";
import MembersModerators from "@/pages/Admin/Members/Moderators";
import MembersSearch from "@/pages/Admin/Members/Search";

import AccountIndex from "@/pages/Admin/Accounts/Index";
import AccountTrials from "@/pages/Admin/Accounts/Trials"
import AccountGameMasters from "@/pages/Admin/Accounts/GameMasters"
import AccountAdmins from "@/pages/Admin/Accounts/Admins"
import AccountSearch from "@/pages/Admin/Accounts/Search";

import NewsIndex from "@/pages/Admin/News/Index";
import NewsCreate from "@/pages/Admin/News/Create";
import NewsEdit from "@/pages/Admin/News/Edit";
import NewsDelete from "@/pages/Admin/News/Delete";

import Ranks from "@/data/models/Ranks";

export default {
  path: "/admin",
  component: Index,
  meta: {
    title: "Admin Panel",
    requiresAuth: true,
    requiredRoles: [Ranks.WebsiteRoles.ADMIN]
  },
  children: [
    // ----------------------------------------------------------------------------------
    {
      path: "members",
      name: "Admin Members",
      component: MembersIndex,
      meta: {
        title: "Admin - Members",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN]
      },
      children: [
        {
          path: "admins",
          name: "Administrators",
          component: MembersAdmins,
          meta: {
            title: "Administrators",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "moderators",
          name: "Moderators",
          component: MembersModerators,
          meta: {
            title: "Moderators",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "search",
          name: "MembersSearch",
          component: MembersSearch,
          meta: {
            title: "Search Members",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        }
      ]
    },
    // ----------------------------------------------------------------------------------
    {
      path: "accounts",
      name: "Admin Accounts",
      component: AccountIndex,
      meta: {
        title: "Admin - Accounts",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN]
      },
      children: [
        {
          path: "trials",
          name: "Trial GameMasters",
          component: AccountTrials,
          meta: {
            title: "Ingame Trial GameMasters",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "gamemasters",
          name: "Ingame GameMasters",
          component: AccountGameMasters,
          meta: {
            title: "Ingame Gamemasters",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "admins",
          name: "Ingame Admins",
          component: AccountAdmins,
          meta: {
            title: "Ingame Admins",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "search",
          name: "Search Accounts",
          component: AccountSearch,
          meta: {
            title: "Search Accounts",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        }
      ]
    },
    // ----------------------------------------------------------------------------------
    {
      path: "news",
      name: "Admin News",
      component: NewsIndex,
      meta: {
        title: "Admin - News",
        requiresAuth: true,
        requiredRoles: [Ranks.WebsiteRoles.ADMIN]
      },
      children: [
        {
          path: "edit",
          name: "Edit News",
          component: NewsEdit,
          meta: {
            title: "Edit News",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "create",
          name: "Create News",
          component: NewsCreate,
          meta: {
            title: "Create News",
            requiresAuth: true,
            requiredRoles: [Ranks.WebsiteRoles.ADMIN]
          }
        },
        {
          path: "delete",
          name: "Delete News",
          component: NewsDelete,
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
