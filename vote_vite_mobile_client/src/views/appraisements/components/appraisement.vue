<template>
    <van-card>
        <template #title>
            <div class="flex flex-row justify-between items-center w-100%">
                <span class="text-15px fw-1000">{{ appraisement.name }}</span>
                <span class="text-10px fw-1000" :class="{
                    'c-red-700': !isNotExpired(appraisement.end!),
                    'c-green-700': isNotExpired(appraisement.end!)
                }">
                    {{ isNotExpired(appraisement.end!) ? "进行中" : "已过期" }}
                </span>
            </div>
        </template>
        <template #desc>
            <div class="flex flex-row justify-between my-10px w-90vw">
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-700 c-red-700">
                        {{ EvaluationCategory[appraisement.category!] }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        活动类别
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-700 c-green-700">
                        {{ dayjs(appraisement.start).format("YYYY-MM-DD") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        开始时间
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-700 c-red-700">
                        {{ dayjs(appraisement.end).format("YYYY-MM-DD") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        结束时间
                    </div>
                </div>
            </div>
            <van-text-ellipsis :rows="1" expand-text="展开" collapse-text="收起" :content="`活动描述：${appraisement.description!}`"
                class="my-5px text-12px c-gray-500 w-100%">
            </van-text-ellipsis>
        </template>
        <template #tags>
            <slot name="tags"></slot>
        </template>
        <template #footer>
            <slot name="action"></slot>
        </template>
    </van-card>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { EvaluationCategory, AppraisementDto } from '/@/openapi';
import dayjs from 'dayjs';

defineProps({
    appraisement: {
        type: Object as PropType<AppraisementDto>,
        required: true
    }
});
const isNotExpired = (end: string) => {
    return dayjs(end).isAfter(dayjs());
};
</script>

<style scoped></style>