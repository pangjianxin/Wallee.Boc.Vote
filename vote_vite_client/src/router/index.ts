import type { App } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import { setupLayouts } from "virtual:generated-layouts";
import generatedRoutes from "~pages";
import useOidcStore from "/@/store/modules/useOidcStore";
import useApplicationConfigStore from "/@/store/modules/useApplicationConfigStore";
import { toast } from "../utils/app";
import useCachedViewStore from "/@/store/modules/cachedView";

export const routes = setupLayouts(generatedRoutes);
export const router = createRouter({
  routes,
  history: createWebHistory(),
});

router.beforeEach((to, _from, next) => {
  const { isTokenValid } = useOidcStore();
  const { isPermited } = useApplicationConfigStore();
  if (
    !isTokenValid &&
    to.name != "sys.login" &&
    to.meta?.requiredAuth === true
  ) {
    toast("您访问的页面需要授权，现已转到登录页面");
    next({
      name: "sys.login",
      query: {
        returnUrl: to.name?.toString(),
      },
    });
  } else {
    if (to.meta?.permission && !isPermited(to.meta.permission)) {
      toast("你没有权限访问该页面");
      return;
    }
    // 路由缓存
    useCachedViewStore().addCachedView(to);
    next();
  }
});

export function setupRouter(app: App) {
  app.use(router);
}

export default router;
