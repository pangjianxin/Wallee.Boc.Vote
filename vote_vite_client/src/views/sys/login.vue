<script setup lang="ts">
import { useRoute } from 'vue-router'
import loginTitle from './components/loginTitle.vue'
import loginWave from './components/loginWave.vue'
import passwordLogin from './components/passwordLogin.vue'

const route = useRoute()
</script>

<template>
  <div>
    <loginTitle />
    <passwordLogin :return-url="route.query.returnUrl as string" />
    <loginWave />
  </div>
</template>

<style scoped></style>

<route lang="yaml">
name: sys.login
meta:
  title: 登录
  visible: false
  requiredAuth: false
  keepAlive: false
  layout: default
</route>
