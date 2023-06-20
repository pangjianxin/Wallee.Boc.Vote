import { defineConfig, loadEnv } from "vite";
import vue from "@vitejs/plugin-vue";
import AutoImport from "unplugin-auto-import/vite";
import Components from "unplugin-vue-components/vite";
import Layouts from "vite-plugin-vue-layouts";
import Pages, { PageResolver } from "vite-plugin-pages";
import { VantResolver } from "unplugin-vue-components/resolvers";
import { resolve } from "path";
import UnoCSS from "unocss/vite";

function pathResolve(dir: string) {
  return resolve(process.cwd(), ".", dir);
}
// https://vitejs.dev/config/
export default defineConfig(({ mode }) => {
  let env = loadEnv(mode, process.cwd());
  return {
    plugins: [
      vue(),
      UnoCSS(),
      AutoImport({
        // targets to transform
        include: [
          /\.[tj]sx?$/, // .ts, .tsx, .js, .jsx
          /\.vue$/,
          /\.vue\?vue/, // .vue
          /\.md$/, // .md
        ],
        imports: ["vue", "vue-router", "@vueuse/core"],
      }),
      Components({
        resolvers: [VantResolver()],
      }),
      Pages({
        dirs: [
          {
            dir: "src/views",
            baseRoute: "",
          },
          {
            dir: "src/views/sys",
            baseRoute: "",
          },
        ],
        extensions: ["vue", "ts", "js"], //this is the default value
        moduleId: "~pages",
        extendRoute: (route, parent) => {
          return route;
        },
        onRoutesGenerated: (routes) => {
          return routes;
        },
        exclude: ["**/components/*"],
      }),
      Layouts({
        defaultLayout: "home",
        layoutsDirs: ["src/layouts"],
        exclude: ["src/views/sys/oidc*.vue"],
      }),
    ],
    // css: {
    //   preprocessorOptions: {
    //     scss: {
    //       additionalData: `@import "/@/styles/var.scss";`,
    //     },
    //   },
    // },
    resolve: {
      alias: [
        {
          find: /\/@\//,
          replacement: pathResolve("src") + "/",
        },
        {
          find: /\/#\//,
          replacement: pathResolve("types") + "/",
        },
      ],
    },
    server: {
      host: true,
      https: false,
      port: Number(env["VITE_PORT"]),
    },
  };
});
