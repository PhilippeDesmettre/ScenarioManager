<template>
  <v-app>
    <v-app-bar v-if="isAuthenticated" app color="primary" dark>
      <v-toolbar-title>Mes Scénarios</v-toolbar-title>

      <v-spacer />

      <v-btn icon @click="logout" title="Déconnexion">
        <v-icon>mdi-logout</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { ref, onMounted, watch } from 'vue'
import { useRouter, useRoute } from 'vue-router'

export default {
  name: 'App',
  setup() {
    const router = useRouter()
    const route = useRoute()

    const isAuthenticated = ref(!!localStorage.getItem('token'))

    const logout = () => {
      localStorage.removeItem('token')
      isAuthenticated.value = false
      router.push('/')
    }

    // Mets à jour isAuthenticated à chaque changement de page
    watch(route, () => {
      isAuthenticated.value = !!localStorage.getItem('token')
    })

    return {
      logout,
      isAuthenticated
    }
  }
}
</script>
