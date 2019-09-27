import Index from "@/pages/Armory/Index";
import CharacterSearch from "@/pages/Armory/Characters/Search";
import GuildSearch from "@/pages/Armory/Guilds/Search";

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
    },
    {
      path: "guilds/search",
      name: "ArmoryGuildSearch",
      component: GuildSearch,
      meta: {
        title: "Search Guild Armory",
        hideAvatar: false,
        requiredRoles: []
      }
    }
  ]
};
