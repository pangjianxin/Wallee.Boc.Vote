<template>
    <div class="w-100%">
        <pageHeader>
            <template #title>{{ appraisement?.name }}</template>
            <template #sub-title>
                <van-tag type="primary" plain>{{ orgUnit?.organName }}</van-tag>
                -部门评价
            </template>
            <template #action>
                <van-button type="primary" size="mini" plain icon="arrow-left" @click="goBack">返回</van-button>
            </template>
        </pageHeader>
        <van-form ref="formRef" @submit="createAppraisementResult" class="mt-10px">
            <template v-for="(item, index) in form.contentScores">
                <div class="flex flex-col justify-center items-center mt-5px p-10px shadow-sm shadow-warmgray b-rd-5px">
                    <div class="flex flex-col ml-3px w-100%">
                        <div class="flex flex-row items-center">
                            <span class="i-mdi-file-cog-outline text-20px mr-5px fw-600"></span>
                            <span class="text-16px fw-600">
                                {{ evaluationContents?.find(it => it.id === item.evaluationContentId)!.name }}
                            </span>
                        </div>
                        <div class="text-12px c-gray-400 mt-5px">
                            <van-tag type="success">
                                {{ EvaluationCategory[evaluationContents?.find(it => it.id
                                    === item.evaluationContentId)!.category!] }}
                            </van-tag>
                        </div>
                    </div>
                    <van-text-ellipsis :rows="2" expand-text="展开" collapse-text="收起"
                        :content="evaluationContents.find(it => it.id === item.evaluationContentId)?.description!"
                        class="mt-5px text-12px c-gray-500 w-100%">
                    </van-text-ellipsis>
                    <van-row class="mt-10px w-100%" :gutter="5" align="center">
                        <van-col :span="14" class="flex flex-row justify-start">
                            <van-field :rules="formRules.contentScores" input-align="left">
                                <template #input>
                                    <van-slider v-model="form.contentScores![index].score" :min="60" :max="99">
                                    </van-slider>
                                </template>
                            </van-field>
                        </van-col>
                        <van-col :span="10">
                            <van-field input-align="right">
                                <template #input>
                                    <van-stepper v-model="form.contentScores![index].score"></van-stepper>
                                </template>
                            </van-field>
                        </van-col>
                    </van-row>
                    <van-field v-if="form.contentScores![index].score! <= 98" type="textarea" autosize left-icon="records"
                        label="请输入整改建议" placeholder="98分及以下需要您输入建议" label-align="top"
                        v-model="(form.contentScores![index].comment as string)">
                    </van-field>
                </div>

            </template>

            <van-row class="my-10px">
                <van-button block type="primary" native-type="submit" :loading="loading">
                    提交
                </van-button>
            </van-row>
        </van-form>
    </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import {
    AppraisementDto, CandidateOrgUnitDto, CandidateOrgUnitService,
    AppraisementService, EvaluationContentDto, EvaluationContentService, EvaluationCategory
} from '/@/openapi';
import { useOrgUnitAppraisementForm } from '../hooks/useOrgUnitAppraisementForm';


const router = useRouter();
const route = useRoute();

let orgUnit = ref<CandidateOrgUnitDto>();
let appraisement = ref<AppraisementDto>();
let evaluationContents = ref<EvaluationContentDto[]>([]);

const { loading, form, formRef, formRules, createAppraisementResult } = useOrgUnitAppraisementForm();

const goBack = () => {
    router.go(-1);
};

const getCandidateOrgUnits = async () => {
    let candidateId = route.params.candidateOrgUnitId as string;
    orgUnit.value = await CandidateOrgUnitService.candidateOrgUnitGet({
        id: candidateId
    });
    form.candidateId = candidateId;
};

const getAppraisement = async () => {
    let appraisementId = route.params.appraisementId as string;
    appraisement.value = await AppraisementService.appraisementGet({
        id: appraisementId
    });
    form.appraisementId = appraisementId;
}

const getEvaluationContents = async () => {
    evaluationContents.value = await EvaluationContentService.evaluationContentGetListByCategory({
        category: EvaluationCategory.部门评价
    });
    form.contentScores = [];
    evaluationContents.value.forEach(item => {
        form.contentScores?.push({
            evaluationContentId: item.id,
            content: item.name,
            score: 99
        });
    });
}

onMounted(async () => {
    form.category = EvaluationCategory.部门评价;
    await getCandidateOrgUnits();
    await getAppraisement();
    await getEvaluationContents();
});
</script>

<style scoped></style>
<route lang="yaml">
name: candidateOrgUnit.appraisement.create 
meta:  
  title: 部门评测 
  visible: false 
  keepAlive: false  
  requiredAuth: true 
  permission: Vote.CandidateOrgUnits.Appraisement 
</route>