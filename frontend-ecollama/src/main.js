import { createApp } from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import {createRouter, createWebHashHistory} from 'vue-router'
import ProductosListadoCompVue from './components/ProductosListadoComp.vue'
import CargaVentaCompVue from './components/CargaVentaComp.vue'
import HomeCompVue from './components/HomeComp.vue'
import VentasListadoCompVue from './components/VentasListadoComp.vue'
loadFonts()

// Definir objeto ruta
const routes = [
  {path:'/', component: HomeCompVue},
  {path:'/productoslistado', component: ProductosListadoCompVue},
  {path:'/cargarventas', component: CargaVentaCompVue},
  {path:'/ventaslistado', component: VentasListadoCompVue},
  ]

// crear objeto rutas de vue router -- objeto VR
const router = createRouter({
  history: createWebHashHistory(),
  routes
})

// Instancia de VUE
const app = createApp(App)
  
app.use(vuetify)
app.use(router)
app.mount('#app')
