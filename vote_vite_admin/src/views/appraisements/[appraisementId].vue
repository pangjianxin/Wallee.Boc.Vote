<template>
    <div class="m-5px">
        <pageHeader>
            <template #title>
                创建待评价活动
            </template>
            <template #sub-title>
                创建待评价活动请填写相关信息后点击提交
            </template>
            <template #action>
                <van-button plain size="mini" icon="plus" type="success"
                    @click="router.push({ name: 'appraisement.index' })">
                    返回索引
                </van-button>
            </template>
        </pageHeader>
        <van-form ref="formRef" @submit="updateAppraisement">
            <van-cell-group inset>

                <van-field label="活动名称" left-icon="description" v-model="(form.name as string)" placeholder="请输入评价活动名称"
                    name="name" :rules="formRules.name">
                </van-field>

                <van-field name="category" left-icon="description" label="活动类别">
                    <template #input>
                        <van-radio-group v-model="form.category" direction="horizontal">
                            <van-radio v-for="item in enum2arr(AppraisementCategory)" label-position="right" :name="item">
                                {{ AppraisementCategory[item] }}
                            </van-radio>
                        </van-radio-group>
                    </template>
                </van-field>

                <van-cell icon="calendar-o" title="活动效期" @click="showCalendar = true">
                    <template #value>
                        <template v-if="form.start && form.end">
                            <van-tag plain type="primary">{{ dayjs(form.start).format("YY/MM/DD") }}</van-tag>
                            -
                            <van-tag plain type="danger">{{ dayjs(form.end).format("YY/MM/DD") }}</van-tag>
                        </template>
                        <template v-else>
                            <span class="text-10px c-gray-300">请选择日期范围</span>
                        </template>
                    </template>
                </van-cell>
                <van-calendar v-model:show="showCalendar" type="range" @confirm="onCalendarConfirm">
                </van-calendar>

                <van-field label="活动描述" left-icon="description" type="textarea" v-model="(form.description as string)"
                    placeholder="请输入评价活动描述" autosize name="description" :rules="formRules.description">
                </van-field>

            </van-cell-group>
            <van-row class="mt-10px">
                <van-button block type="primary" native-type="submit" :loading="loading">
                    提交
                </van-button>
            </van-row>
        </van-form>
    </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import { useAppraisementUpdateForm } from './hooks/useAppraisementUpdateForm';
import { enum2arr, toast } from '/@/utils/app';
import dayjs from 'dayjs';
import { AppraisementCategory, AppraisementService } from '/@/openapi';

let showCalendar = ref(false);
const { id, loading, form, formRef, formRules, updateAppraisement } = useAppraisementUpdateForm();
const route = useRoute();
const router = useRouter();

const getAppraisement = async () => {
    let res = await AppraisementService.appraisementGet({
        id: id.value
    });
    form.category = res.category;
    form.concurrencyStamp = res.concurrencyStamp;
    form.name = res.name;
    form.description = res.description;
    form.start = res.start;
    form.end = res.end;
}

const onCalendarConfirm = (values: Date | Date[]) => {
    if (values instanceof Date) {
        toast("请选择日期范围");
        return;
    }
    const [start, end] = values;
    showCalendar.value = false;
    form.start = dayjs(start).format("YYYY-MM-DD");
    form.end = dayjs(end).format("YYYY-MM-DD");
}

onMounted(async () => {
    id.value = route.params.appraisementId as string;
    await getAppraisement();
});
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.edit
meta: 
  title: 编辑活动
  visible: false
  requiredAuth: false
  keepAlive: false
</route>