<script setup lang="ts">
import logo from '/@/assets/logo.svg'

const app = import.meta.env.VITE_APP_LITE_NAME
</script>

<template>
  <div class="flex flex-col items-center justify-center">
    <div class="my-35px">
      <van-icon size="98" :name="logo" />
    </div>
    <div class="text-3xl fw100 my-35px  c-sky-700">
      {{ app }}
    </div>
  </div>
</template>

<style scoped></style>
