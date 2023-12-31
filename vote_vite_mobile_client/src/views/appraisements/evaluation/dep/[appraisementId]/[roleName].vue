<template>
    <div v-if="appraisementConfirmed" class="m-5px">
        <div class="w-100%">
            <appraisementVue v-if="appraisement" :appraisement="appraisement!">
                <template #tags>
                    <div class="flex flex-row items-center">
                        <span>
                            当前角色：
                        </span>
                        <van-tag type="primary">
                            {{ roleName }}
                        </van-tag>
                    </div>
                </template>
            </appraisementVue>
            <van-form ref="formRef" @submit="createAppraisementResult" class="mt-10px">
                <van-collapse v-for="(item, index) in form.details" v-model="currCollapseName">
                    <van-collapse-item :name=index>
                        <template #title>
                            <div class="flex flex-row items-center">
                                <span class="text-15px fw-700 c-black">
                                    {{ orgUnitCandidateList?.find(it => it.id === item.candidateId)!.organName }}
                                </span>
                            </div>
                        </template>
                        <template #value>
                            <van-tag type="success">
                                {{ CandidateOrgUnitCategory[orgUnitCandidateList?.find(it => it.id ===
                                    item.candidateId)!.category!] }}
                            </van-tag>
                        </template>
                        <van-text-ellipsis :rows="4" expand-text="展开" collapse-text="收起"
                            :content="(orgUnitCandidateList?.find(it => it.id === item.candidateId)!.description!)"
                            class="mt-5px text-13px w-100% c-black fw-600">
                        </van-text-ellipsis>
                        <van-divider />
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
                    <van-button block type="primary" native-type="submit" :loading="loading" class="mb-5px">
                        提交
                    </van-button>
                </van-row>
            </van-form>
            <van-back-top right="0" bottom="13vh" />
        </div>
    </div>
    <div v-else>
        <div class="m-5px h-100% flex flex-col">
            <van-image :src="appraisement_img" class="relative mb--30px"></van-image>
            <appraisementVue v-if="appraisement" :appraisement="appraisement!">
                <template #tags>
                    <div class="flex flex-row">
                        <span class="text-13px">当前角色:</span>
                        <span>
                            <van-tag type="primary">
                                {{ roleName }}
                            </van-tag>
                        </span>
                    </div>
                </template>
            </appraisementVue>
            <van-button type="primary" block class="mt-10px" @click="appraisementConfirmed = true"
                :loading="evaluationInfoLoading">
                开始评价
            </van-button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { useCandidateOrgUnitList } from '/@/views/appraisements/hooks/useCandidateOrgUnitList';
import { useEvaluationContentList } from '/@/views/appraisements/hooks/useEvaluationContentList';
import { useAppraisementResultForm } from '/@/views/appraisements/hooks/useAppraisementResultForm';
import { AppraisementDto, AppraisementService, CandidateOrgUnitCategory } from '/@/openapi';
import appraisementVue from '/@/views/appraisements/components/appraisement.vue';
import appraisement_img from '/@/assets/images/appraisement.png';
import { toast } from '/@/utils/app';
import { RouteLocationNormalized } from 'vue-router';
import { showConfirmDialog } from 'vant';


const route = useRoute();
let currCollapseName = ref([0]);
let appraisementId = ref("");
let roleName = ref("");
let appraisement = ref<AppraisementDto>();
let appraisementConfirmed = ref(false);
let evaluationInfoLoading = ref(false);

const { orgUnitCandidateList, getOrgUnitCandidateList } = useCandidateOrgUnitList();
const { evaContentList, getEvaContentList } = useEvaluationContentList();
const { loading, formSubmited, form, formRef, formRules, createAppraisementResult } = useAppraisementResultForm();

const getAppraisementInfo = async () => {
    appraisement.value = await AppraisementService.appraisementGet({ id: appraisementId.value })
}

onMounted(async () => {
    try {
        evaluationInfoLoading.value = true;
        appraisementId.value = route.params.appraisementId as string;
        roleName.value = route.params.roleName as string;
        form.appraisementId = appraisementId.value;
        form.roleName = roleName.value;
        await getAppraisementInfo();
        await getOrgUnitCandidateList();
        await getEvaContentList(appraisement.value?.category!);
    } catch (err) {
        toast(err as string);
    } finally {
        evaluationInfoLoading.value = false;
    }
});

watch(
    [orgUnitCandidateList, evaContentList],
    ([newOrgUnits, newEvaContents], [_oldVal1, _oldVal2]) => {
        if (newOrgUnits && newEvaContents) {
            form.details = newOrgUnits.map(it => {
                return {
                    candidateId: it.id,
                    scoreDetails: newEvaContents.map(eva => {
                        return {
                            content: eva.name,
                            evaluationContentId: eva.id,
                            score: 99,
                            comment: ""
                        }
                    })
                }
            })
        }
    },
    {
        deep: true
    });

onBeforeRouteLeave(async (_to: RouteLocationNormalized, _from: RouteLocationNormalized) => {
    if (formSubmited.value === true) {
        return true;
    } else {
        try {
            await showConfirmDialog({ title: "提示", message: "您的表单还未提交,继续退出吗?" });
            return true;
        }
        catch {
            return false
        }
    }
});
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.eva
meta: 
  title: 评价详情
  requiredAuth: false
  layout: no-tabbar
  visible: false
</route>