import Index from '@/pages/User/Index';
import Login from '@/pages/User/Login';
import Register from '@/pages/User/Register';

export default {
  path: '/user',
  name: 'User',
  component: Index,
  children: [
    {
      path: 'login',
      name: 'Login',
      component: Login,
      meta: { 
        title: 'Login'
      }, 
    },
    {
      path: 'register',
      name: 'Register',
      component: Register,
      meta: { 
        title: 'Register'
      }, 
    },
  ],
  meta: { 
    title:'User Page'
  },
  beforeEnter: (to, from, next) => {
    if (to.name === 'User') {
      next('/user/register')
    }
    else {
      next();
    }
  }
};