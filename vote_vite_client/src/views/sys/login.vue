<template>
  <div>
    <loginTitle></loginTitle>
    <passwordLogin></passwordLogin>
    <loginWave></loginWave>
  </div>
</template>

<script setup lang="ts">
import loginTitle from './components/loginTitle.vue';
import loginWave from './components/loginWave.vue';
import passwordLogin from './components/passwordLogin.vue';
</script>

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