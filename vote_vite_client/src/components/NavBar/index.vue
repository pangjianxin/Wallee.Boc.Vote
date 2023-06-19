<template>
  <van-nav-bar fixed placeholder @click-right="onClickRight">
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
const darkModeStore = useDarkModeStore();
let { darkMode } = storeToRefs(darkModeStore);

const onClickRight = () => {
  darkModeStore.toggleDarkMode();
};

</script>


<style scoped></style>
