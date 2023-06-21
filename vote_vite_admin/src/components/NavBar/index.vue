<template>
  <van-nav-bar fixed placeholder @click-right="onClickRight" left-text="返回" left-arrow @click-left="onClickLeft">
    <template #title>{{ route.meta.title }}</template>
    <template #right>
      <van-icon size="32" :name="darkMode ? light_mode : dark_mode"></van-icon>
    </template>
  </van-nav-bar>
</template>

<script setup lang="ts">
import { storeToRefs } from "pinia";
import useDarkModeStore from "/@/store/modules/useDarkModeStore";
import dark_mode from '/@/assets/images/dark_mode.svg'
import light_mode from '/@/assets/images/light_mode.svg';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();
const darkModeStore = useDarkModeStore();
let { darkMode } = storeToRefs(darkModeStore);

const onClickRight = () => {
  darkModeStore.toggleDarkMode();
};
const onClickLeft = () => {
  router.go(-1);
}
</script>


<style scoped></style>
