import Index from "@/pages/Admin/Index";
import Users from "@/pages/Admin/Users";
import News from "@/pages/Admin/News";
import Edit from "@/pages/Admin/Edit";
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
      path: "users",
      name: "Admin Users",
      component: Users,
      meta: {
        title: "Edit Users",
        requiresAuth: true,
        requiredRank: GMRanks.ADMIN
      }
    },
    {
      path: "news",
      name: "Edit News",
      component: News,
      meta: {
        title: "Edit News",
        requiresAuth: true,
        requiredRank: GMRanks.ADMIN
      }
    },
    {
      path: "edit/:id",
      name: "Edit",
      component: Edit
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
