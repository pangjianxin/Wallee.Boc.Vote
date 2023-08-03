<template>
    <van-card>
        <template #title>
            <div class="flex flex-row justify-start items-center w-100%">
                <span class="text-15px fw-1000">{{ appraisement.name }}</span>
                <span class="w-5px"></span>
            </div>
        </template>
        <template #desc>
            <div class="flex flex-row justify-between my-10px w-90vw">
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ dayjs(appraisement.start).format("MM月-DD日") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        评价期限自
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ dayjs(appraisement.end).format("MM月-DD日") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        评价期限止
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div>
                        <van-tag type="danger">{{ EvaluationCategory[appraisement.category!] }}</van-tag>
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        评价类别
                    </div>
                </div>
            </div>
            <van-text-ellipsis :content="(appraisement.description as string)" :rows="1" expand-text="展开" collapse-text="收起"
                class="c-gray mt-5px">
            </van-text-ellipsis>
        </template>
        <template #footer>
            <div class="mt-10px">
                <slot name="footer"></slot>
            </div>
        </template>
    </van-card>
</template>

<script setup lang="ts">
import { AppraisementDto, EvaluationCategory } from '/@/openapi';
import dayjs from 'dayjs';

defineProps({
    appraisement: {
        type: Object as PropType<AppraisementDto>,
        required: true
    }
});

</script>

<style scoped></style>