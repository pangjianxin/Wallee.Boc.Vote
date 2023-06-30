
<template>
  <div>
    <template v-if="loading">
      <van-loading></van-loading>
    </template>
    <template v-else>
      <appraisementList :list="list"></appraisementList>
    </template>
  </div>
</template>

<script setup lang="ts">
import appraisementList from './components/appraisementList.vue';
import useAvailableAppraisementList from './hooks/useAvailableAppraisementList';
const { loading, list, getAvailableAppraisements } = useAvailableAppraisementList();

onMounted(async () => {
  await getAvailableAppraisements();
});
</script>

<style scoped></style>

<route lang="yaml">
name: index
meta:
  title: 首页
  icon: wap-home
  visible: true
  keepAlive: true
  order: 3
  requiredAuth: false
</route>
