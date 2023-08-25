<template>
    <van-card>
        <template #title>
            <div class="flex flex-row justify-between items-center w-100%">
                <span class="text-15px fw-1000">{{ orgUnit.organName }}</span>
                
                <van-tag type="primary">
                    {{ CandidateOrgUnitCategory[orgUnit.category!] }}
                </van-tag>
            </div>
        </template>
        <template #desc>
            <div class="flex flex-row justify-between my-10px w-90vw">
                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ orgUnit.superiorName }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        分管行领导
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ orgUnit.organCode }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        机构编号
                    </div>
                </div>

                <div class="flex flex-col items-center">
                    <div class="text-13px fw-1000 c-red-700">
                        {{ orgUnit.isActive ? "有效" : "无效" }}
                    </div>
                    <div class="text-12px c-gray-400 mt-5px">
                        当前状态
                    </div>
                </div>
            </div>
        </template>
        <template #footer>
            <div class="mt-10px">
                <slot name="action"></slot>
            </div>
        </template>
    </van-card>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { CandidateOrgUnitDto, CandidateOrgUnitCategory } from '/@/openapi';

defineProps({
    orgUnit: {
        type: Object as PropType<CandidateOrgUnitDto>,
        required: true
    }
})
</script>

<style scoped></style>