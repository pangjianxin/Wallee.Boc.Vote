<template>
  <div class="m-10px">
    <van-form ref="formRef" @submit="createEvaluationContent">
      <van-field v-model="form.category" is-link readonly left-icon="todo-list-o" placeholder="选择类别"
        @click="showPicker = true" :rules="formRules.category">
      </van-field>
      <van-field v-model="(form.name as string)" name="name" left-icon="records" placeholder="评估内容名称"
        :rules="formRules.name">
      </van-field>
      <van-field v-model="(form.description as string)" :type="'textarea'" autosize name="description"
        left-icon="description" placeholder="评估内容描述" :rules="formRules.description">
      </van-field>
      <van-popup v-model:show="showPicker" round position="bottom">
        <van-picker :columns="categoryOptions" @cancel="showPicker = false" @confirm="onPickerConfirm" />
      </van-popup>
      <van-row class="mt-10px">
        <van-button block type="primary" native-type="submit" :loading="loading">
          提交
        </van-button>
      </van-row>
    </van-form>
  </div>
</template>

<script setup lang="ts">
import { PickerColumn } from 'vant';
import { useEvlauationContentForm } from './hooks/useEvaluationContentForm';
import { EvaluationCategory } from '/@/openapi';
import { enum2arr } from '/@/utils/app';

const { loading, formRef, formRules, form, createEvaluationContent } = useEvlauationContentForm();

let showPicker = ref(false);

const categoryOptions = computed(() => {
  const arr = enum2arr(EvaluationCategory);
  const res: PickerColumn = [];
  arr.forEach(item => {
    res.push({
      text: EvaluationCategory[item],
      value: EvaluationCategory[item]
    });
  });
  return res;
});

const onPickerConfirm = ({ selectedOptions }: { selectedOptions: any[] }) => {
  showPicker.value = false;
  form.category = selectedOptions[0].value;
};
</script>

<style scoped></style>
<route lang="yaml">
name: evaluationContent.create
meta: 
  title: 新增评估内容
  icon: column
  visible: false
  requiredAuth: false
  keepAlive: true
</route>