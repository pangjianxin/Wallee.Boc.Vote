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
                        <van-tag type="danger">{{ AppraisementCategory[appraisement.category!] }}</van-tag>
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
    <!-- <div class="flex flex-col shadow-sm shadow-blueGray p-10px mt-10px b-rd-5px">
        <div class="flex flex-row justify-start items-center">
            <span class="i-mdi-library-books text-16px c-red mr-5px">
            </span>
            <span class="fw-600">
                {{ appraisement.name }}
            </span>
        </div>
        <div>
            <van-tag type="primary">{{ AppraisementCategory[appraisement.category!] }}</van-tag>
            <van-tag type="danger" plain class="ml-5px mt-5px">
                {{ dayjs(appraisement.start).format("MM月DD日") }}至{{ dayjs(appraisement.end).format("MM月DD日") }}
            </van-tag>
        </div>
        <van-text-ellipsis expand-text="展开" collapse-text="收起" :content="(appraisement.description as string)" :rows="1"
            class="text-13px c-gray-400 my-5px w-100%">
        </van-text-ellipsis>
        <div class="flex flex-row justify-end">
            <van-button round type="primary" size="mini"
                @click="_$event => gotoAppraisement(appraisement.category!, item.id!)">
                开始评价
            </van-button>
        </div>
    </div> -->
</template>

<script setup lang="ts">
import { AppraisementDto, AppraisementCategory } from '/@/openapi';
import dayjs from 'dayjs';

defineProps({
    appraisement: {
        type: Object as PropType<AppraisementDto>,
        required: true
    }
});

</script>

<style scoped></style>