import Index from "@/pages/Store/Index";


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
        title: "How to connect"
      }
    }
  ],
  meta: {
    title: "Welcome to the Titans League Website"
  }
};
