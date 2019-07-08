import Index from "@/pages/Home/Index";
import News from "@/pages/Home/News";
import Connect from "@/pages/Home/Connect";
import Online from "@/pages/Home/Online";
import Tos from "@/pages/Home/Tos";
import Changelog from "@/pages/Home/Changelog"

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
        hideAvatar: true
      }
    },
    {
      path: "/connect",
      name: "Connect",
      component: Connect,
      meta: {
        title: "How to connect"
      }
    },
    {
      path: "/online",
      name: "Online Players",
      component: Online,
      meta: {
        title: "Online Players",
        hideAvatar: true
      }
    },
    {
      path: "/changelog",
      name: "Changelog",
      component: Changelog,
      meta: {
        title: "Changelog",
        hideAvatar: true
      }
    },
    {
      path: "/tos",
      name: "Terms of Service",
      component: Tos,
      meta: {
        title: "Terms of Service",
        hideAvatar: true
      }
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
