import { createRouter, createWebHistory } from 'vue-router'
import ScenarioList from '../views/ScenarioList.vue'

function isAuthenticated(): boolean {
  return !!localStorage.getItem('token')
}

const routes = [
  {
    path: '/',
    name: 'Auth',
    component: () => import('@/views/AuthPage.vue')
  },
  {
    path: '/scenarios',
    name: 'Scenarios',
    component: ScenarioList,
    meta: { requiresAuth: true }
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth && !isAuthenticated()) {
    next({ path: '/' })
  } else {
    next()
  }
})

export default router
