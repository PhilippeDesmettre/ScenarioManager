import { createApp } from 'vue'
import App from './App.vue'
import router from './router'


import 'vuetify/styles'
import '@mdi/font/css/materialdesignicons.css'
import vuetify from './vuetify'

const app = createApp(App)
app.use(router)
app.use(vuetify)
app.mount('#app')
