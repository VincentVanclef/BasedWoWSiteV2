import Index from "@/pages/Home/Index";
import News from "@/pages/Home/News";
import Connect from "@/pages/Home/Connect";
import Online from "@/pages/Home/Online";

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
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
