import Index from "@/pages/Armory/Index";
import CharacterSearch from "@/pages/Armory/Characters/Search";

export default {
  path: "/armory",
  name: "Armory",
  component: Index,
  meta: {
    title: "Armory",
    requiresAuth: false,
    requiredRoles: []
  },
  children: [
    {
      path: "characters/search",
      name: "ArmoryCharacterSearch",
      component: CharacterSearch,
      meta: {
        title: "Search Character Armory",
        hideAvatar: false,
        requiredRoles: []
      }
    }
  ]
};
