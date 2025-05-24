<template>
  <div>
    <h2>Liste des tâches</h2>
    <ul>
      <li v-for="(task, index) in tasks" :key="index">
        {{ task }}
      </li>
    </ul>
    <v-container>
        <h1>Bienvenue dans mon app Vuetify</h1>
        <v-btn color="primary">Bouton Vuetify</v-btn>
      </v-container>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'
import axios from 'axios'

export default defineComponent({
  name: 'TaskList',
  setup() {
    const tasks = ref<string[]>([])

    const fetchTasks = async () => {
      try {
        const response = await axios.get('https://localhost:44318/api/tasks')
        tasks.value = response.data
      } catch (error) {
        console.error('Erreur lors du chargement des tâches :', error)
      }
    }

    onMounted(fetchTasks)

    return { tasks }
  },
})
</script>
