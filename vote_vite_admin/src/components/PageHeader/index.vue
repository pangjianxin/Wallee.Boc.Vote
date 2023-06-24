<script setup lang="ts">

</script>

<template>
  <div class="flex flex-row justify-between bg-sky-100 b-rd-5px py-10px px-5px">
    <div class="flex flex-row items-center">
      <div class="i-mdi-home text-36px c-red-400" />
      <div class="flex flex-col justify-center items-start">
        <div class="text-16px fw-600">
          <slot name="title" />
        </div>
        <div class="text-12px fw-100 c-gray-400">
          <slot name="sub-title" />
        </div>
      </div>
    </div>
    <div class="flex flex-col justify-center">
      <slot name="action" />
    </div>
  </div>
</template>

<style scoped></style>
