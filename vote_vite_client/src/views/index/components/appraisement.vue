<template>
    <div class="flex flex-col shadow-sm shadow-blueGray p-10px mt-10px b-rd-5px">
        <div class="flex flex-row justify-start items-center">
            <span class="i-mdi-library-books text-16px c-red mr-5px">
            </span>
            <span class="fw-600">
                {{ item.name }}
            </span>
        </div>
        <div>
            <van-tag type="primary">{{ AppraisementCategory[item.category!] }}</van-tag>
            <van-tag type="danger" plain class="ml-5px mt-5px">
                {{ dayjs(item.start).format("MM月DD日") }}至{{ dayjs(item.end).format("MM月DD日") }}
            </van-tag>
        </div>
        <van-text-ellipsis expand-text="展开" collapse-text="收起" :content="(item.description as string)" :rows="1"
            class="text-13px c-gray-400 my-5px w-100%">
        </van-text-ellipsis>
        <div class="flex flex-row justify-end">
            <van-button round type="primary" size="mini" @click="_$event => gotoAppraisement(item.category!, item.id!)">
                开始评价
            </van-button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { AppraisementDto, AppraisementCategory } from '/@/openapi';
import dayjs from 'dayjs';
const router = useRouter();

defineProps({
    item: {
        type: Object as PropType<AppraisementDto>,
        required: true
    }
});

const gotoAppraisement = async (category: AppraisementCategory, appraisementId: string) => {
    switch (category) {
        case AppraisementCategory.部门评价:
            await router.push({
                name: "candidateOrgUnit.appraisement.index",
                params: {
                    appraisementId: appraisementId
                }
            })
    }
}
</script>

<style scoped></style>