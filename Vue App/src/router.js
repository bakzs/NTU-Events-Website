import Vue from 'vue'
import Router from 'vue-router'
import Main from './components/main.vue'
import Event from './components/events.vue'
import Login from './components/login.vue'
import Register from './components/register.vue'
import User from './components/user.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/' && '/main',
      name: 'main',
      component: Main
    },
    {
      path: '/events',
      name: 'events',
      component: Event
    },
    {
      path: '/user',
      name: 'user',
      component: User        
    },
    {
      path: '/login',
      name: 'login',
      component: Login        
    },
    {
      path: '/register',
      name: 'register',
      component: Register        
    }
  ]
})