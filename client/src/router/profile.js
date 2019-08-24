/* View other peoples profiles */
import Index from "@/pages/Profile/Index";
import Profile from "@/pages/Profile/Profile";

export default {
  path: "/profile/:username",
  component: Index,
  children: [
    {
      path: "/",
      name: "ViewProfile",
      component: Profile,
      meta: {
        title: "View User Profile",
        requiresAuth: false,
        requiredRoles: []
      }
    }
  ]
};
