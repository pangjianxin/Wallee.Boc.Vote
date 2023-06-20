<template>
    <div class="flex flex-col items-center justify-center">
        <div class="my-35px">
            <van-icon size="98" :name="logo"></van-icon>
        </div>
        <div class="text-3xl fw100 my-35px  c-sky-700">
            {{ app }}
        </div>
    </div>
</template>

<script setup lang="ts">
import logo from '/@/assets/logo.svg';
let app = import.meta.env['VITE_APP_LITE_NAME'];
</script>

<style scoped></style>