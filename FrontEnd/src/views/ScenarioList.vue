<template>
  <v-container>
    <v-row justify="space-between" align="center" class="mb-4">
      <h2>Liste des scénarios</h2>
      <v-btn color="primary" @click="dialog = true" prepend-icon="mdi-plus">
        Ajouter
      </v-btn>
    </v-row>

    <v-list lines="three">
      <v-list-item
        v-for="scenario in scenarios"
        :key="scenario.id"
        class="mb-2"
        rounded="lg"
        elevation="2"
      >
        <v-list-item-title>{{ scenario.titre }}</v-list-item-title>
        <v-list-item-subtitle>{{ scenario.genre }}</v-list-item-subtitle>
        <v-list-item-subtitle>
          Auteur : {{ scenario.auteur }}<br />
          Créé le : {{ formatDate(scenario.dateCreation) }}
        </v-list-item-subtitle>

        <template #append>
          <v-btn icon="mdi-pencil" @click="onModifier(scenario)" />
          <v-btn icon="mdi-delete" color="error" @click="onSupprimer(scenario.id)" />
        </template>
      </v-list-item>
    </v-list>

    <!-- DIALOGUE CRÉATION -->
    <v-dialog v-model="dialog" max-width="500">
      <v-card>
        <v-card-title>Créer un scénario</v-card-title>
        <v-card-text>
          <v-text-field label="Titre" v-model="newScenario.titre" />
          <v-text-field label="Genre" v-model="newScenario.genre" />
          <v-text-field label="Auteur" v-model="newScenario.auteur" />
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn text @click="dialog = false">Annuler</v-btn>
          <v-btn color="primary" @click="onCreate">Créer</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'
import axios from 'axios'

interface Scenario {
  id?: number
  titre: string
  genre: string
  auteur: string
  dateCreation?: string
}

export default defineComponent({
  name: 'ScenarioList',
  setup() {
    const scenarios = ref<Scenario[]>([])
    const dialog = ref(false)

    const newScenario = ref<Scenario>({
      titre: '',
      genre: '',
      auteur: ''
    })

    const fetchScenarios = async () => {
      try {
        const api = import.meta.env.VITE_API_BASE_URL
        const response = await axios.get(`${api}/scenarios`)
        scenarios.value = response.data
      } catch (error) {
        console.error('Erreur lors du chargement des scénarios :', error)
      }
    }

    const onCreate = async () => {
      const api = import.meta.env.VITE_API_BASE_URL
      try {
        await axios.post(`${api}/scenarios`, newScenario.value)
        dialog.value = false
        newScenario.value = { titre: '', genre: '', auteur: '' }
        await fetchScenarios()
      } catch (error) {
        console.error('Erreur lors de la création :', error)
      }
    }

    const onModifier = (scenario: Scenario) => {
      console.log('Modifier', scenario)
    }

    const onSupprimer = async (id: number) => {
      const api = import.meta.env.VITE_API_BASE_URL
      if (confirm('Confirmer la suppression ?')) {
        await axios.delete(`${api}/scenarios/${id}`)
        await fetchScenarios()
      }
    }

    const formatDate = (iso: string) =>
      new Date(iso).toLocaleDateString('fr-FR')

    onMounted(fetchScenarios)

    return {
      scenarios,
      dialog,
      newScenario,
      formatDate,
      onSupprimer,
      onModifier,
      onCreate
    }
  },
})
</script>
