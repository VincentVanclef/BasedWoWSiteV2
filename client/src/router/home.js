import Index from "@/pages/Home/Index";
import News from "@/pages/Home/News";

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
        title: "News"
      }
    }
  ],
  meta: {
    title: "Welcome to Based WoW Site"
  }
};
