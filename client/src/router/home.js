import Index from "@/pages/Home/Index";
import News from "@/pages/Home/News";
import Connect from "@/pages/Home/Connect";
import Online from "@/pages/Home/Online";
import Tos from "@/pages/Home/Tos";
import Changelog from "@/pages/Home/Changelog";
import PvPStats from "@/pages/Home/PvPStats";

export default {
  path: "/",
  redirect: "/news",
  name: "Home",
  component: Index,
  children: [
    {
      path: "/news",
      name: "News",
      component: News,
      meta: {
        title: "Titans League - WoW Server",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/connect",
      name: "Connect",
      component: Connect,
      meta: {
        title: "How To Connect",
        requiredRoles: []
      }
    },
    {
      path: "/online",
      name: "Online Players",
      component: Online,
      meta: {
        title: "Online Players",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/changelog",
      name: "Changelog",
      component: Changelog,
      meta: {
        title: "Changelog",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/pvpstats",
      name: "PvP Statistics",
      component: PvPStats,
      meta: {
        title: "PvP Statistics",
        hideAvatar: true,
        requiredRoles: []
      }
    },
    {
      path: "/tos",
      name: "Terms of Service",
      component: Tos,
      meta: {
        title: "Terms of Service",
        hideAvatar: true,
        requiredRoles: []
      }
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
