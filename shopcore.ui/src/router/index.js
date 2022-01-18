import Vue from 'vue'
import Router from 'vue-router'
import view from '../page/view'
import list from '../page/list'
import login from '../page/login'
import cart from '../page/cart'
import order from '../page/order'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'list',
      component: list
    },{
      path: '/login',
      name: 'login',
      component: login
    },
    {
      path: '/view',
      name: 'view',
      component: view
    },
    {
      path: '/cart',
      name: 'cart',
      component: cart
    },
    {
      path: '/order',
      name: 'order',
      component: order
    }
  ]
})
