import { createRouter, createWebHistory } from 'vue-router'
import ScenarioList from '../views/ScenarioList.vue'

const routes = [
  {
    path: '/',
    redirect: '/scenarios',
  },
  {
    path: '/scenarios',
    name: 'Scenarios',
    component: ScenarioList,
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
