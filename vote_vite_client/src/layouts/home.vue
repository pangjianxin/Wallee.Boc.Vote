<script setup lang="ts">
import Tabbar from "/@/components/Tabbar/index.vue";
import NavBar from "/@/components/NavBar/index.vue";
import useCachedViewStore from "/@/store/modules/cachedView";
import { useDarkMode } from "/@/hooks/useToggleDarkMode";
import { computed } from "vue";

const cachedViews = computed(() => {
    return useCachedViewStore().cachedViewList;
});
</script>

<template>
    <div class="app-wrapper">
        <van-config-provider :theme="useDarkMode() ? 'dark' : 'light'">
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

<style lang="scss" scoped>
@import "/@/styles/mixin.scss";

.app-wrapper {
    @include clearfix;
    position: relative;
    height: 100%;
    width: 100%;
}
</style>