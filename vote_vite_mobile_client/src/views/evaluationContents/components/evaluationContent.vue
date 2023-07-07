<template>
    <!-- <div class="flex flex-col justify-center items-center mt-5px p-10px shadow-sm shadow-warmgray b-rd-5px  bg-gradient-linear shape-[100deg] bg-gradient-from-red bg-gradient-via-orange bg-gradient-to-rose
        dark:bg-gradient-from-gray dark:bg-gradient-via-red dark:bg-gradient-to-black">
        <div class="flex flex-col ml-3px w-100%">
            <div class="flex flex-row items-center">
                <span class="i-mdi-file-cog-outline text-20px mr-5px fw-600"></span>
                <span class="text-16px fw-600">{{ content.name }}</span>
            </div>
            <div class="text-12px c-gray-400 mt-5px">
                <van-tag type="success">

                </van-tag>
                <van-tag class="ml-5px">{{ dayjs(content.creationTime).format('YYYY-MM-DD') }}</van-tag>
            </div>
        </div>

        <div class="self-end">
            <slot name="action"></slot>
        </div>
    </div> -->
    <van-card>
        <template #title>
            <div class="flex flex-row justify-start items-center w-100%">
                <span class="text-15px fw-1000">{{ content.name }}</span>
                <span class="w-5px"></span>
            </div>
        </template>
        <template #desc>
            <div class="flex flex-row justify-between my-10px w-90vw">
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-green-700">
                        有效
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        当前状态
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ EvaluationCategory[content.category!] }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        内容类别
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ dayjs(content.creationTime).format("YYYY-MM-DD") }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        添加时间
                    </div>
                </div>
            </div>
        </template>
        <template #tags>
            <van-text-ellipsis :rows="2" expand-text="展开" collapse-text="收起" :content="`内容描述：${content.description}`"
                class="mt-5px text-12px c-gray-500 w-100%">
            </van-text-ellipsis>
        </template>
        <template #footer>
            <div class="mt-10px">
                <slot name="action"></slot>
            </div>
        </template>
    </van-card>
</template>

<script setup lang="ts">
import { EvaluationContentDto, EvaluationCategory } from '/@/openapi';
import dayjs from 'dayjs';

defineProps({
    content: {
        type: Object as PropType<EvaluationContentDto>,
        required: true
    }
})
</script>

<style scoped></style>