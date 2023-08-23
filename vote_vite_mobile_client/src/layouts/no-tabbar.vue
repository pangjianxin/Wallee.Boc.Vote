<script setup lang="ts">
import useCachedViewStore from '/@/store/modules/useCachedView'
import useDarkModeStore from '/@/store/modules/useDarkModeStore'
import { storeToRefs } from 'pinia';
import NavBar from '/@/components/NavBar/index.vue'
import { ConfigProviderThemeVars } from 'vant';

const { darkMode } = storeToRefs(useDarkModeStore());
const cachedViews = computed(() => {
  return useCachedViewStore().cachedViewList
});
const themeVars = reactive<ConfigProviderThemeVars>({});
</script>

<template>
  <div class="app-wrapper">
    <van-config-provider :theme="darkMode ? 'dark' : 'light'" :theme-vars="themeVars">
      <NavBar />
      <router-view v-slot="{ Component }">
        <keep-alive :include="cachedViews">
          <component :is="Component" />
        </keep-alive>
      </router-view>
    </van-config-provider>
  </div>
</template>

<style lang="scss" scoped>
@import "/@/styles/mixin.scss";

.app-wrapper {
    @include clearfix;
    position: relative;
    height: 100%;
    width: 100%;
}
</style>
