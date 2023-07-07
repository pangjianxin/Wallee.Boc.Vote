<template>
  <van-nav-bar fixed placeholder left-text="返回" left-arrow @click-left="onClickLeft">
    <template #title>
      {{ route.meta.title }}
    </template>
    <template #right>
      <van-icon size="24" class="i-mdi-logout-variant ml-10px" @click="logout" v-if="isTokenValid">
      </van-icon>
      <van-icon size="24" class="i-mdi-login-variant ml-10px" @click="logout" v-else>
      </van-icon>
      <van-icon size="24" :class="{
        'i-mdi-weather-sunny': darkMode,
        'i-mdi-weather-night': !darkMode,
        'ml-10px': true
      }" @click="onToggleDarkMode">
      </van-icon>
    </template>
  </van-nav-bar>
</template>
<script setup lang="ts">
import { storeToRefs } from 'pinia'
import useDarkModeStore from '/@/store/modules/useDarkModeStore';
import { useRoute, useRouter } from 'vue-router';
import useOidcStore from '/@/store/modules/useOidcStore';

const route = useRoute()
const router = useRouter()
const darkModeStore = useDarkModeStore()
const { darkMode } = storeToRefs(darkModeStore);
const oidcStore = useOidcStore();
const { isTokenValid } = storeToRefs(oidcStore);

const logout = async () => {
  oidcStore.clearState();
  await router.push({
    name: "sys.login"
  });
}

function onToggleDarkMode() {
  darkModeStore.toggleDarkMode()
}
function onClickLeft() {
  router.go(-1)
}
</script>

<style scoped></style>
