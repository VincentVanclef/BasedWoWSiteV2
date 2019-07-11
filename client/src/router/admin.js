import Index from "@/pages/Admin/Index";

import MembersIndex from "@/pages/Admin/Members/Index";

import NewsIndex from "@/pages/Admin/News/Index";
import NewsCreate from "@/pages/Admin/News/Create";
import NewsEdit from "@/pages/Admin/News/Edit";
import NewsDelete from "@/pages/Admin/News/Delete";

import Error from "@/pages/Admin/Error";

import GMRanks from "@/data/models/Ranks";

export default {
  path: "/admin",
  component: Index,
  meta: {
    title: "Admin Panel",
    requiresAuth: true,
    requiredRank: GMRanks.GAMEMASTER
  },
  children: [
    {
      path: "members",
      name: "Admin Members",
      component: MembersIndex,
      meta: {
        title: "Admin - Members",
        requiresAuth: true,
        requiredRank: GMRanks.ADMIN
      }
    },
    {
      path: "news",
      name: "Admin News",
      component: NewsIndex,
      meta: {
        title: "Admin - News",
        requiresAuth: true,
        requiredRank: GMRanks.ADMIN
      },
      children: [
        {
          path: "edit",
          name: "Edit News",
          component: NewsEdit,
          meta: {
            title: "Admin - News - Edit",
            requiresAuth: true,
            requiredRank: GMRanks.ADMIN
          }
        },
        {
          path: "create",
          name: "Create News",
          component: NewsCreate,
          meta: {
            title: "Admin - News - Create",
            requiresAuth: true,
            requiredRank: GMRanks.ADMIN
          }
        },
        {
          path: "delete",
          name: "Delete News",
          component: NewsDelete,
          meta: {
            title: "Admin - News - Delete",
            requiresAuth: true,
            requiredRank: GMRanks.ADMIN
          }
        }
      ]
    },
    {
      path: "error",
      name: "Admin Error",
      component: Error,
      meta: {
        requiresAuth: true,
        title: "Permission Denied"
      }
    }
  ]
};
