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
                <van-button plain size="mini" icon="plus" type="success" @click="gotoIndex">
                    返回索引
                </van-button>
            </template>
        </pageHeader>
        <van-form ref="formRef" @submit="createAppraisement">
            <van-cell-group>
                <van-cell title="评价活动名称"></van-cell>
                <van-field v-model="(form.name as string)" left-icon="description" placeholder="请输入评价活动名称" name="name"
                    :rules="formRules.name">
                </van-field>


                <van-cell title="评价活动描述"></van-cell>
                <van-field type="textarea" v-model="(form.description as string)" left-icon="description"
                    placeholder="请输入评价活动描述" name="description" :rules="formRules.description">
                </van-field>

                <van-cell icon="calendar-o" title="活动时间效期" @click="showCalendar = true">
                    <template #value>
                        <template v-if="form.start && form.end">
                            <van-tag plain type="primary">{{ form.start }}</van-tag>
                            -
                            <van-tag plain type="danger">{{ form.end }}</van-tag>
                        </template>
                        <template v-else>
                            <span class="text-10px c-gray-300">请选择日期范围</span>
                        </template>
                    </template>
                </van-cell>
                <van-calendar v-model:show="showCalendar" type="range" @confirm="onCalendarConfirm"></van-calendar>

                <van-cell title="评价活动类别"></van-cell>
                <van-radio-group v-model="form.category" direction="horizontal" class="van-cell van-field">
                    <van-radio v-for="item in enum2arr(AppraisementCategory)" label-position="right" :name="item">
                        {{ AppraisementCategory[item] }}
                    </van-radio>
                </van-radio-group>

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
import { useAppraisementCreateForm } from './hooks/useAppraisementCreateForm';
import { AppraisementCategory } from '/@/openapi';
import { enum2arr, toast } from '/@/utils/app';
import dayjs from 'dayjs';
const router = useRouter();
let showCalendar = ref(false);
const { loading, form, formRef, formRules, createAppraisement } = useAppraisementCreateForm();

const gotoIndex = async () => {
    await router.push({
        name: "appraisement.index"
    })
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
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.create
meta: 
  title: 创建评价活动
  visible: false
  requiredAuth: true
  keepAlive: false
</route>