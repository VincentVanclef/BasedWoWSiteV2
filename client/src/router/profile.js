export default {
  path: "/profile/:username",
  component: () => import("@/pages/Profile/Index"),
  children: [
    {
      path: "/",
      name: "ViewProfile",
      component: () => import("@/pages/Profile/Profile"),
      meta: {
        title: "View User Profile",
        requiresAuth: false,
        requiredRoles: []
      }
    }
  ]
};
