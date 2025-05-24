<template>
  <v-container class="fill-height" fluid>
    <v-row justify="center" align="center">
      <v-col cols="12" md="6" lg="4">
        <v-card elevation="3" rounded="xl">
          <v-card-title class="text-center">
            <v-tabs v-model="tab" align-tabs="center">
              <v-tab value="login">Connexion</v-tab>
              <v-tab value="register">Inscription</v-tab>
            </v-tabs>
          </v-card-title>

          <v-card-text>
            <v-window v-model="tab">
              <!-- Login Form -->
              <v-window-item value="login">
                <v-text-field v-model="email" label="Email" type="email" />
                <v-text-field v-model="motDePasse" label="Mot de passe" type="password" />
                <v-btn color="primary" block @click="login">Se connecter</v-btn>
              </v-window-item>

              <!-- Register Form -->
              <v-window-item value="register">
                <v-text-field v-model="email" label="Email" type="email" />
                <v-text-field v-model="motDePasse" label="Mot de passe" type="password" />
                <v-btn color="secondary" block @click="register">S’inscrire</v-btn>
              </v-window-item>
            </v-window>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import axios from 'axios'
import { useRouter } from 'vue-router'

export default defineComponent({
  name: 'AuthPage',
  setup() {
    const tab = ref('login')
    const email = ref('')
    const motDePasse = ref('')
    const router = useRouter()

    const login = async () => {
      try {
        const response = await axios.post(
          `${import.meta.env.VITE_API_BASE_URL}/auth/login`,
          { email: email.value, motDePasse: motDePasse.value }
        )
        localStorage.setItem('token', response.data.token)
        router.push('/scenarios')
      } catch (err) {
        alert("Échec de la connexion")
      }
    }

    const register = async () => {
      try {
        await axios.post(
          `${import.meta.env.VITE_API_BASE_URL}/auth/register`,
          { email: email.value, motDePasse: motDePasse.value }
        )
        tab.value = 'login'
        alert("Inscription réussie, vous pouvez vous connecter.")
      } catch (err) {
        alert("Erreur lors de l'inscription")
      }
    }

    return { tab, email, motDePasse, login, register }
  },
})
</script>
