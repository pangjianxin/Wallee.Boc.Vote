<template>
    <div v-if="appraisementConfirmed" class="h-100%">
        <div class="w-100%">
            <pageHeader>
                <template #title>{{ appraisement?.name }}</template>
                <template #sub-title>
                    <van-text-ellipsis :content="appraisement?.description!" :row="1" expand-text="展开" collapse-text="收起"
                        style="width:100%;">
                    </van-text-ellipsis>
                </template>
            </pageHeader>
            <van-form ref="formRef" @submit="createAppraisementResult" class="mt-10px">
                <van-collapse v-for="(item, index) in form.details" v-model="currCollapseName">
                    <van-collapse-item :name=index>
                        <template #title>
                            <div>
                                <span>
                                    {{ orgUnitCandidateList?.find(it => it.id === item.candidateId)!.organName }}
                                </span>
                                &nbsp;
                                <van-tag type="success">
                                    {{ CandidateOrgUnitCategory[orgUnitCandidateList?.find(it => it.id ===
                                        item.candidateId)!.category!] }}
                                </van-tag>
                            </div>
                        </template>

                        <template v-for="(detail, detailIndex) in item.scoreDetails" :key="detailIndex">
                            <div class="flex flex-col">
                                <span class="text-13px c-black fw-600">{{ detail.content }}</span>
                                <van-text-ellipsis :rows="2" expand-text="展开" collapse-text="收起"
                                    :content="evaContentList.find(it => it.id === detail.evaluationContentId)?.description!"
                                    class="mt-5px text-12px c-gray-500 w-100%">
                                </van-text-ellipsis>
                            </div>
                            <van-row class="mt-10px w-100%" :gutter="5" align="center">
                                <van-col :span="14" class="flex flex-row justify-start">
                                    <van-field :rules="formRules.contentScores" input-align="left">
                                        <template #input>
                                            <van-slider v-model="form.details![index].scoreDetails![detailIndex].score"
                                                :min="60" :max="99">
                                            </van-slider>
                                        </template>
                                    </van-field>
                                </van-col>
                                <van-col :span="10">
                                    <van-field input-align="right">
                                        <template #input>
                                            <van-stepper
                                                v-model="form.details![index].scoreDetails![detailIndex].score"></van-stepper>
                                        </template>
                                    </van-field>
                                </van-col>
                            </van-row>
                            <van-field v-if="form.details![index].scoreDetails![detailIndex].score! <= 98" type="textarea"
                                autosize left-icon="records" label="请输入整改建议" placeholder="98分及以下需要您输入建议" label-align="top"
                                v-model="(form.details![index].scoreDetails![detailIndex].comment as string)">
                            </van-field>
                        </template>
                    </van-collapse-item>
                </van-collapse>
                <van-row class="my-10px">
                    <van-button block type="primary" native-type="submit" :loading="loading">
                        提交
                    </van-button>
                </van-row>
            </van-form>
        </div>
    </div>
    <div v-else>
        <div>
            <van-button type="primary" @click="appraisementConfirmed = true">
                开始评测
            </van-button>
        </div>
    </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import { useCandidateOrgUnitList } from '/@/views/appraisements/hooks/useCandidateOrgUnitList';
import { useEvaluationContentList } from '/@/views/appraisements/hooks/useEvaluationContentList';
import { useAppraisementResultForm } from '/@/views/appraisements/hooks/useAppraisementResultForm';
import { EvaluationCategory, AppraisementDto, AppraisementService, CandidateOrgUnitCategory } from '/@/openapi';
const route = useRoute();
const router = useRouter();
let currCollapseName = ref([0]);
let appraisementId = ref("");
let ruleName = ref("");
let appraisement = ref<AppraisementDto>();
let appraisementConfirmed = ref(false);

const { orgUnitCandidateList, getOrgUnitCandidateList } = useCandidateOrgUnitList();
const { evaContentList, getEvaContentList } = useEvaluationContentList();
const { loading, form, formRef, formRules, createAppraisementResult } = useAppraisementResultForm();

const getAppraisementInfo = async () => {
    appraisement.value = await AppraisementService.appraisementGet({ id: appraisementId.value })
}

onMounted(async () => {
    appraisementId.value = route.params.appraisementId as string;
    ruleName.value = route.params.ruleName as string;
    await getAppraisementInfo();
    await getOrgUnitCandidateList();
    await getEvaContentList(appraisement.value?.category!);
});

watch([orgUnitCandidateList, evaContentList], ([newOrgUnits, newEvaContents], [_oldVal1, _oldVal2]) => {

    if (newOrgUnits && newEvaContents) {
        form.details = newOrgUnits.map(it => {
            return {
                candidateId: it.id,
                scoreDetails: newEvaContents.map(eva => {
                    return {
                        content: eva.name,
                        evaluationContentId: eva.id,
                        score: 60,
                        comment: ""
                    }
                })
            }
        })
    }
}, {
    deep: true
})
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.eva
meta: 
  title: 评价详情
  requiredAuth: false
  visible: false
</route>