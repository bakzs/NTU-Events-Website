import Vue from 'vue'
import router from 'vue-router'
import Main from './components/main.vue'
import Event from './components/events.vue'
import Login from './components/login.vue'
import Register from './components/register.vue'
import User from './components/user.vue'

Vue.use(router)

export default new router({
  routes: [{
      name: 'default',
      path: '',
      component: Login
    }, {
      name: 'main',
      path: '/main',
      component: Main
    },
    {
      name: 'events',
      path: '/events/:userId',
      component: Event
    },
    {
      name: 'user',
      path: '/user/:userId',
      component: User,
      props:true
    },
    {
      name: 'login',
      path: '/login',
      component: Login
    },
    {
      name: 'register',
      path: '/register',
      component: Register
    }
  ],
  mode: 'history'
})