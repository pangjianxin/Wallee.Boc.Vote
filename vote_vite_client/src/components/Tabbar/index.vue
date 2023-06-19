<template>
  <van-tabbar v-model="active" :placeholder="true" :route="true" fixed>
    <van-tabbar-item v-for="(item, index) in menus" :key="index" :icon="item.icon" :to="item.path">
      {{ item.title }}
    </van-tabbar-item>
  </van-tabbar>
</template>

<script setup lang="ts">
import generatedRoutes from "~pages";
import { MenuItem } from '/#/menu';
const active = ref(0);
const menus: MenuItem[] = reactive<MenuItem[]>([]);

watchEffect(() => {
  generatedRoutes
    .filter((it) => it.meta?.visible === true)
    .sort(
      (prev, next) =>
        (prev.meta?.order as number) - (next.meta?.order as number)
    )
    .forEach((item, _index) => {
      menus.push({
        icon: item.meta?.icon as string,
        path: item.path,
        title: item.meta?.title as string,
      });
    });
});
</script>
