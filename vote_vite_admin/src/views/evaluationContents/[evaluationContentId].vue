<template>
  <div class="m-10px">
    <pageHeader>
      <template #title>
        修改评测内容
      </template>
      <template #sub-title>
        修改评估内容请填写相关信息
      </template>
      <template #action>
        <van-button plain size="mini" icon="plus" type="success" @click="gotoCreate">
          创建新项
        </van-button>
      </template>
    </pageHeader>
    <van-form ref="formRef" @submit="submit">
      <van-cell-group>
        <van-cell title="评估内容名称" />
        <van-field v-model="(form.name as string)" name="name" left-icon="records" placeholder="评估内容名称"
          :rules="formRules.name" />

        <van-cell title="评估内容类别" />
        <van-radio-group v-model="form.category" direction="horizontal" class="van-cell van-field">
          <van-radio v-for="item in enum2arr(EvaluationCategory)" label-position="right" :name="item">
            {{
              EvaluationCategory[item] }}
          </van-radio>
        </van-radio-group>

        <van-cell title="评估内容描述" />
        <van-field v-model="(form.description as string)" type="textarea" autosize name="description"
          left-icon="description" placeholder="评估内容描述" :rules="formRules.description" />
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
import { useEvlauationContentUpdateForm } from './hooks/useEvaluationContentUpdateForm';
import { EvaluationCategory, EvaluationContentService } from '/@/openapi';
import { enum2arr } from '/@/utils/app';
import pageHeader from '/@/components/PageHeader/index.vue';

const id = ref('');
const route = useRoute();
const router = useRouter();
const { loading, form, formRef, formRules, updateEvaluationContent } = useEvlauationContentUpdateForm();

async function getEvaluationContent() {
  const res = await EvaluationContentService.evaluationContentGet({ id: id.value })
  form.category = res.category
  form.name = res.name
  form.description = res.description
  form.concurrencyStamp = res.concurrencyStamp
}

onMounted(async () => {
  id.value = route.params.evaluationContentId as string
  await getEvaluationContent()
})

async function submit() {
  await updateEvaluationContent(id.value)
}

async function gotoCreate() {
  router.push({ name: 'evaluationContent.create' })
}
</script>


<style scoped></style>

<route lang="yaml">
name: evaluationContent.edit
meta:
  title: 评估内容编辑
  visible: false
  keepAlive: false
  requiredAuth: true
</route>
