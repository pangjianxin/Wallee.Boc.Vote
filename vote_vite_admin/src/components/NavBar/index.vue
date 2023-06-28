<template>
  <van-nav-bar fixed placeholder left-text="返回" left-arrow @click-left="onClickLeft">
    <template #title>
      {{ route.meta.title }}
    </template>
    <template #right>
      <van-icon size="20" name="setting-o" @click="onAccountClick"></van-icon>
      <van-icon size="24" :name="darkMode ? 'closed-eye' : 'eye-o'" class="ml-10px" @click="onToggleDarkMode" />
    </template>
  </van-nav-bar>
</template>
<script setup lang="ts">
import { storeToRefs } from 'pinia'
import useDarkModeStore from '/@/store/modules/useDarkModeStore'
import dark_mode from '/@/assets/images/dark_mode.svg'
import light_mode from '/@/assets/images/light_mode.svg'
import { useRoute, useRouter } from 'vue-router'

const route = useRoute()
const router = useRouter()
const darkModeStore = useDarkModeStore()
const { darkMode } = storeToRefs(darkModeStore)


const onAccountClick = () => {
  console.log("account ci");
}

function onToggleDarkMode() {
  darkModeStore.toggleDarkMode()
}
function onClickLeft() {
  router.go(-1)
}
</script>

<style scoped></style>
