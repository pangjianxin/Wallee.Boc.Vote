import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { setupRouter } from "./router";
import { setupStore } from "./store";
import "/@/styles/index.scss";
import 'vant/es/toast/style'
import 'vant/es/notify/style'
import 'vant/es/dialog/style'
import "virtual:uno.css";
import { setupPermissionDirective } from "/@/directives/permission.ts";

const app = createApp(App);

setupStore(app);
setupRouter(app);
setupPermissionDirective(app);

app.mount("#app");
