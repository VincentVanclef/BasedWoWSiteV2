export default {
  path: "/armory",
  name: "Armory",
  component: () => import("@/pages/Armory/Index"),
  meta: {
    title: "Armory",
    requiresAuth: false,
    requiredRoles: []
  },
  children: [
    {
      path: "characters/search",
      name: "ArmoryCharacterSearch",
      component: () => import("@/pages/Armory/Characters/Search"),
      meta: {
        title: "Search Character Armory",
        hideAvatar: false,
        requiredRoles: []
      }
    },
    {
      path: "guilds/search",
      name: "ArmoryGuildSearch",
      component: () => import("@/pages/Armory/Guilds/Search"),
      meta: {
        title: "Search Guild Armory",
        hideAvatar: false,
        requiredRoles: []
      }
    }
  ]
};
