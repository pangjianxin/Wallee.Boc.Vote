import { App } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import { setupLayouts } from "virtual:generated-layouts";
import generatedRoutes from "~pages";
import useOidcStore from "/@/store/modules/useOidcStore";
import { toastError } from "../utils/app";
import useCachedViewStore from "/@/store/modules/cachedView";

export const routes = setupLayouts(generatedRoutes);
export const router = createRouter({
  routes,
  history: createWebHistory(),
});

router.beforeEach((to, _from, next) => {
  const { isTokenValid } = useOidcStore();
  if (!isTokenValid && to.path != "/login" && to.meta?.requiredAuth === true) {
    toastError("您访问的页面需要授权，现已转到登录页面");
    next({ name: "sys.login" });
  } else {
    // 路由缓存
    useCachedViewStore().addCachedView(to);
    next();
  }
});

export function setupRouter(app: App) {
  app.use(router);
}
