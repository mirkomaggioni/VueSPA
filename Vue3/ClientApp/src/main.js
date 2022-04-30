import { createApp } from 'vue'
import { createRouter, createWebHashHistory } from 'vue-router'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'

import ElencoCitta from './components/ElencoCitta.vue'
import ModuloRicerca from './components/ModuloRicerca.vue'
import ElencoUtenti from './components/ElencoUtenti.vue'
import DettaglioCitta from './components/DettaglioCitta.vue'
import DettaglioUtenti from './components/DettaglioUtenti.vue'

const routes = [
    { path: '/citta', component: ElencoCitta, children: [{ path: 'dettaglio', component: DettaglioCitta }] },
    { path: '/ricerca', component: ModuloRicerca },
    { path: '/utenti', component: ElencoUtenti, children: [{ path: 'dettaglio/:id?', component: DettaglioUtenti }] }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

createApp(App).use(router).mount('#app')

