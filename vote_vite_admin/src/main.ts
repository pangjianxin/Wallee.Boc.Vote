import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { setupRouter } from './router'
import { setupStore } from './store'
import '/@/styles/index.scss'
import 'virtual:uno.css'

const app = createApp(App)

setupStore(app)
setupRouter(app)

app.mount('#app')
