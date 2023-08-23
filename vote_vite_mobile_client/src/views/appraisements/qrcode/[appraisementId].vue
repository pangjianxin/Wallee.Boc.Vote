<template>
    <pageHeader>
        <template #title>评价活动详情</template>
        <template #sub-title>评价活动详情,点击下载二维码</template>
    </pageHeader>

    <van-card>
        <template #title>
            <div class="flex flex-row justify-start items-center w-100%">
                <span class="text-15px fw-1000">{{ appraisement?.name }}</span>
                <span class="w-5px"></span>
                <van-tag type="primary">
                    {{ EvaluationCategory[appraisement?.category!] }}
                </van-tag>
            </div>
        </template>
        <template #thumb>
            <van-image :src="bgImg" :fit="'cover'"></van-image>
        </template>
        <template #desc>
            <div class="text-10px fw-600 c-gray w-100%">
                <van-text-ellipsis :content="appraisement?.description!" :rows="1" expand-text="展开" collapse-text="收起" />
            </div>
        </template>
        <template #tags>
            <div class="flex flex-row justify-between my-10px w-auto">
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ dayjs(appraisement?.start).format("YYYY-MM-DD") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        开始日期
                    </div>
                </div>
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ dayjs(appraisement?.end).format("YYYY-MM-DD") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        结束日期
                    </div>
                </div>
            </div>
        </template>
        <template #footer>
        </template>
    </van-card>
    <van-divider content-position="left">二维码信息生成</van-divider>
    <van-radio-group v-model="selectedRadioValue">
        <van-cell-group inset>
            <van-cell v-for="ruleName in ruleNames" :title="ruleName" clickable @click="selectedRadioValue = ruleName"
                :key="ruleName">
                <template #right-icon>
                    <van-radio :name="ruleName" />
                </template>
            </van-cell>
        </van-cell-group>
    </van-radio-group>
    <van-row justify="end" class="m-10px">
        <van-button type="primary" size="small" icon="qr" block @click="downloadQrcodeAsync"
            :disabled="!selectedRadioValue">生成二维码
        </van-button>
    </van-row>
</template>

<script setup lang="ts">
import { AppraisementDto, AppraisementService, EvaluationCategory } from '/@/openapi';
import bgImg from '/@/assets/images/appraisement.png';
import pageHeader from '/@/components/PageHeader/index.vue';
import dayjs from 'dayjs';
const route = useRoute();

let appraisementId = ref("");
let appraisement = ref<AppraisementDto>();
let selectedRadioValue = ref("");
let ruleNames = ref<string[]>([]);
onMounted(async () => {
    appraisementId.value = route.params.appraisementId as string;
    appraisement.value = await AppraisementService.appraisementGet({ id: appraisementId.value });
    await getQrcodeRuleNames();
})

const downloadQrcodeAsync = async () => {
    let blob = await AppraisementService.appraisementGetDownloadAppraisementQrcode({ appraisementId: appraisementId.value, ruleName: selectedRadioValue.value });
    console.log(blob);
    const link = document.createElement('a')
    link.style.display = 'none'
    link.href = URL.createObjectURL(blob)
    link.download = `${appraisement.value?.name}-${selectedRadioValue.value}.png`;
    document.body.appendChild(link);
    link.click()
    document.body.removeChild(link);
}

const getQrcodeRuleNames = async () => {
    ruleNames.value = await AppraisementService.appraisementGetRuleNames();

}
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.detail
meta: 
  title: 评价详情
  requiredAuth: false
  visible: false
</route>