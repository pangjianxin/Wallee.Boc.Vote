<template>
    <div>
        <jsonViewerVue :data="json"></jsonViewerVue>
    </div>
</template>

<script setup lang="ts">
import { CandidateOrgUnitService } from '/@/openapi';
import jsonViewerVue from '/@/components/JsonViewer/index.vue';
let json = ref();

const getRulesEngine = async () => {
    json.value = await CandidateOrgUnitService.candidateOrgUnitGetRulesEngine();
}

onMounted(async () => {
    await getRulesEngine();
});
</script>

<script lang="ts">
export default defineComponent({
    name: "candidateOrgUnits.rulesEngine"
});
</script>

<style scoped></style>
<route lang="yaml">
name: candidateOrgUnits.rulesEngine
meta: 
  title: 待评价部门规则引擎
  visible: false
  requiredAuth: false
  keepAlive: true
  permission: Vote.CandidateOrgUnits 
</route>