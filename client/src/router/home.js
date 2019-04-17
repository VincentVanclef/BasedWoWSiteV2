import Index from "@/pages/Home/Index";
import News from "@/pages/Home/News";
import Connect from "@/pages/Home/Connect";

export default {
  path: "/",
  redirect: '/news',
  name: "Home",
  component: Index,
  children: [
    {
      path: "/news",
      name: "News",
      component: News,
      meta: {
        title: "Titans League - WoW Server"
      }
    },
    {
      path: "/connect",
      name: "Connect",
      component: Connect,
      meta: {
        title: "How to connect",
        requiresAuth: true
      }
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
