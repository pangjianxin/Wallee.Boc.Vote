<script setup lang="ts">

</script>

<template>
  <div class="flex flex-row justify-start py-10px px-5px b-rd-5px">
    <div class="i-mdi-home text-36px c-red-400" />
    <div class="flex flex-col w-100%">
      <div class="flex flex-row justify-between w-100%">
        <span class="text-16px fw-600">
          <slot name="title"></slot>
        </span>
        <slot name="action"></slot>
      </div>
      <div class="text-12px fw-100 c-gray-400 mt-5px">
        <slot name="sub-title"></slot>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
