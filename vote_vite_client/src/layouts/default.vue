<script setup lang="ts">
import useCachedViewStore from '/@/store/modules/useCachedView'
import useDarkModeStore from '/@/store/modules/useDarkModeStore'
import { storeToRefs } from 'pinia'

const { darkMode } = storeToRefs(useDarkModeStore())
const cachedViews = computed(() => {
  return useCachedViewStore().cachedViewList
})
</script>

<template>
  <div class="app-wrapper">
    <van-config-provider :theme="darkMode ? 'dark' : 'light'">
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
