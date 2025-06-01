<template>
  <v-container>
    <v-row justify="space-between" align="center" class="mb-4">
      <h2>Liste des scénarios</h2>
<v-btn color="primary" @click="onAjouter" prepend-icon="mdi-plus">
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
           Modifié le : {{ formatDate(scenario.dateModification) }}

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
    <!-- Titre dynamique -->
    <v-card-title>{{ isEditing ? 'Modifier le scénario' : 'Créer un scénario' }}</v-card-title>


    <v-card-text>
      <v-text-field
        label="Titre"
        v-model="newScenario.titre"
        :rules="[v => !!v || 'Titre requis']"
        required
      />
      <v-text-field
        label="Genre"
        v-model="newScenario.genre"
        :rules="[v => !!v || 'Genre requis']"
        required
      />
      <v-text-field
        label="Auteur"
        v-model="newScenario.auteur"
        readonly
      />
    </v-card-text>

    <v-card-actions>
      <v-spacer />
      <v-switch
        label="Public ?"
        v-model="newScenario.estPublic"
        color="success"
      />
      <v-btn text @click="dialog = false">Annuler</v-btn>
      <v-btn color="primary" @click="onSubmit">
        {{ isEditing ? 'Sauvegarder' : 'Créer' }}
      </v-btn>
    </v-card-actions>
  </v-card>
</v-dialog>

  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'
import api from '@/api'

interface Scenario {
  id?: number
  titre: string
  genre: string
  auteur: string
  dateCreation?: string
  dateModification?: string
  estPublic: boolean
}

export default defineComponent({
  name: 'ScenarioList',
  setup() {
    const scenarios = ref<Scenario[]>([])
    const dialog = ref(false)
    const isEditing = ref(false)


    const newScenario = ref<Scenario>({
  titre: '',
  genre: '',
  auteur: '',
  estPublic: false
})

const onAjouter = () => {
  isEditing.value = false
  dialog.value = true
  newScenario.value = {
    titre: '',
    genre: '',
    auteur: localStorage.getItem('email') || '',
    estPublic: false
  }
}



    const fetchScenarios = async () => {
      try {
        const response = await api.get(`/scenarios`)
        scenarios.value = response.data
      } catch (error) {
        console.error('Erreur lors du chargement des scénarios :', error)
      }
    }

    const onSubmit = async () => {
  try {
    if (isEditing.value && newScenario.value.id) {
  await api.put(`/scenarios/${newScenario.value.id}`, newScenario.value)
} else {
  await api.post(`/scenarios`, newScenario.value,newScenario.value.auteur = localStorage.getItem('email') || 'Inconnu'
)
}


    dialog.value = false
    isEditing.value = false
    newScenario.value = {
  titre: '',
  genre: '',
  auteur: '',
  estPublic: false
}

    await fetchScenarios()
  } catch (error) {
    console.error('Erreur lors de la soumission :', error)
  }
}


    const onModifier = (scenario: Scenario) => {
  newScenario.value = { ...scenario }
  isEditing.value = true
  dialog.value = true
}





    const onSupprimer = async (id: number) => {
      if (confirm('Confirmer la suppression ?')) {
        await api.delete(`/scenarios/${id}`)
        await fetchScenarios()
      }
    }

    const formatDate = (iso: string) =>
      new Date(iso).toLocaleDateString('fr-FR')

    onMounted(() => {
  fetchScenarios();

  // Si on est en création, on définit l'auteur
  const email = localStorage.getItem('email');
  if (email) {
    newScenario.value.auteur = email;
  }
});


    return {
      scenarios,
      dialog,
      newScenario,
      isEditing,
      formatDate,
      onSupprimer,
      onModifier,
      onSubmit,
      onAjouter,
    }
  },
})
</script>
