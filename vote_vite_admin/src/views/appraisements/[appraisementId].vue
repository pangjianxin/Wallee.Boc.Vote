<template>
    <div>
        edit appraisement
    </div>
</template>

<script setup lang="ts">

const route = useRoute();

onMounted(() => {
    console.log(route.params.appraisementId)
});
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.edit
meta: 
  title: 编辑活动
  visible: false
  requiredAuth: false
  keepAlive: false
</route>