<template>
    <div>
        <p v-for="item in list">{{ item.organName }}</p>
    </div>
</template>

<script setup lang="ts">
import { useCandidateOrgUnitList } from '/@/views/appraisements/hooks/useCandidateOrgUnitList';
const route = useRoute();
let appraisementId = route.params.appraisementId;
const { list, getList } = useCandidateOrgUnitList();

onMounted(async () => {
    await getList();
    console.log(appraisementId);
});

</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.xxx
meta: 
  title: 评价详情
  requiredAuth: false
  visible: false
</route>