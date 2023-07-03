<template>
    <div class="flex flex-col justify-center items-center mt-5px px-5px py-10px shadow-sm shadow-warmgray b-rd-5px bg-gradient-linear shape-[100deg] bg-gradient-from-sky bg-gradient-via-orange bg-gradient-to-yellow
        dark:bg-gradient-from-gray dark:bg-gradient-via-red dark:bg-gradient-to-black">
        <div class="flex flex-row justify-start items-center w-100%">
            <div class="flex flex-col justify-center items-start ml-3px">
                <div class="flex flex-row items-center">
                    <span class="i-mdi-folder-home-outline text-20px text-sky-300 mr-5px fw-600"></span>
                    <span class="text-16px fw-600">{{ orgUnit.organName }}</span>
                </div>
                <div class="text-12px fw-100 c-gray-700">
                    机构编号:{{ orgUnit.organCode }},分管行领导:{{ orgUnit.superiorName }}
                </div>
                <div class="text-12px c-gray-400 mt-5px">
                    <van-tag type="success">
                        {{ CandidateOrgUnitCategory[orgUnit.category!] }}
                    </van-tag>
                    <van-tag :type="orgUnit.isActive === true ? 'primary' : 'danger'" class="ml-5px">
                        {{ orgUnit.isActive ? "有效" : "无效" }}
                    </van-tag>
                </div>
            </div>
            <div class="flex-1"></div>
            <div class="self-end">
                <slot name="action"></slot>
            </div>
        </div>
    </div>
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