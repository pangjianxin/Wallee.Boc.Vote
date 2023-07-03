<template>
    <div class="m-5px">
        <pageHeader>
            <template #title>
                {{ appraisementInfo?.name }}
            </template>
            <template #sub-title>
                点击"评价"按钮对该部门进行评价
            </template>
            <template #action>
                <van-button type="warning" plain size="mini" icon="arrow-left" @click="router.back()">返回</van-button>
            </template>
        </pageHeader>
        <template v-if="list && list.length > 0">
            <candidateOrgUnitVue v-for="item in unAppraisedList" :org-unit="item" :key="item.id">
                <template #action>
                    <van-button type="primary" size="mini" round icon="setting-o">
                        评价
                    </van-button>
                </template>
            </candidateOrgUnitVue>
        </template>
        <van-empty v-else image="error" description="没有查询到可用的待评价部门">
        </van-empty>
    </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import { AppraisementDto, AppraisementService, CandidateOrgUnitDto, CandidateOrgUnitService } from '/@/openapi';
import candidateOrgUnitVue from '../components/candidateOrgUnit.vue';
import useOrgUnitAppraisementStore from '../store/useOrgUnitAppraisementStore';
import { storeToRefs } from 'pinia';
const orgUnitApprasisementStore = useOrgUnitAppraisementStore();
const { state } = storeToRefs(orgUnitApprasisementStore);
const route = useRoute();
const router = useRouter();
let appraisementInfo = ref<AppraisementDto>();
let list = ref<CandidateOrgUnitDto[]>([]);

const unAppraisedList = computed(() => {
    return list.value.filter(it => state.value[route.params.appraisementId as string]?.indexOf(it.id!) === -1);
});

const getCandidateOrgUnits = async () => {
    let res = await CandidateOrgUnitService.candidateOrgUnitGetCandidateOrgUnitEvaList();
    list.value = res;
};

const getAppraisementInfo = async (appraisementId: string) => {
    appraisementInfo.value = await AppraisementService.appraisementGet({ id: appraisementId });
};

onMounted(async () => {
    let appraisementId = route.params.appraisementId as string;
    if (state.value[appraisementId] == undefined) {
        state.value[appraisementId] = [];
    }
    getAppraisementInfo(appraisementId);
    getCandidateOrgUnits();
});
</script>

<style scoped></style>
<route lang="yaml">
name: candidateOrgUnit.appraisement
meta: 
  title: 部门评测
  visible: false
  keepAlive: true
  requiredAuth: true
  permission: Vote.CandidateOrgUnits
</route>