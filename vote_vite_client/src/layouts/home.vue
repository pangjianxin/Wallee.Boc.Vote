<template>
    <div class="app-wrapper">
        <van-config-provider :theme="darkMode ? 'dark' : 'light'">
            <nav-bar />
            <router-view v-slot="{ Component }">
                <keep-alive :include="cachedViews">
                    <component :is="Component" />
                </keep-alive>
            </router-view>
            <tabbar />
        </van-config-provider>
    </div>
</template>

<script setup lang="ts">
import Tabbar from "/@/components/Tabbar/index.vue";
import NavBar from "/@/components/NavBar/index.vue";
import useCachedViewStore from "/@/store/modules/cachedView";
import useDarkModeStore from '/@/store/modules/useDarkModeStore';
import { storeToRefs } from "pinia";
const { darkMode } = storeToRefs(useDarkModeStore());
const cachedViews = computed(() => {
    return useCachedViewStore().cachedViewList;
});
</script>

<style lang="scss" scoped>
@import "/@/styles/mixin.scss";

.app-wrapper {
    @include clearfix;
    position: relative;
    height: 100%;
    width: 100%;
}
</style>