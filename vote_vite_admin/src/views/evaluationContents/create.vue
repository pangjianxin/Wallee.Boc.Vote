<script setup lang="ts">
import { useEvlauationContentCreateForm } from './hooks/useEvaluationContentCreateForm'
import { EvaluationCategory } from '/@/openapi'
import { enum2arr } from '/@/utils/app'
import pageHeader from '/@/components/PageHeader/index.vue'

const { loading, formRef, formRules, form, createEvaluationContent } = useEvlauationContentCreateForm()
const router = useRouter()

function backToIndex() {
  router.push({ name: 'evaluationContent.index' })
}
</script>

<script lang="ts">
export default defineComponent({
  name: 'evaluationContent.create',
})
</script>

<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>
        创建评测内容
      </template>
      <template #sub-title>
        创建评估内容请填写相关信息
      </template>
      <template #action>
        <van-button plain type="primary" icon="arrow-left" size="mini" @click="backToIndex">
          返回索引
        </van-button>
      </template>
    </pageHeader>
    <van-form ref="formRef" @submit="createEvaluationContent">
      <van-cell-group>
        <van-cell title="评估内容名称" />
        <van-field
          v-model="(form.name as string)" name="name" left-icon="records" placeholder="评估内容名称"
          :rules="formRules.name"
        />

        <van-cell title="评估内容类别" />
        <van-radio-group v-model="form.category" direction="horizontal" class="van-cell van-field">
          <van-radio v-for="item in enum2arr(EvaluationCategory)" label-position="right" :name="item">
            {{
              EvaluationCategory[item] }}
          </van-radio>
        </van-radio-group>

        <van-cell title="评估内容描述" />
        <van-field
          v-model="(form.description as string)" type="textarea" autosize name="description"
          left-icon="description" placeholder="评估内容描述" :rules="formRules.description"
        />
      </van-cell-group>
      <van-row class="mt-10px">
        <van-button block type="primary" native-type="submit" :loading="loading">
          提交
        </van-button>
      </van-row>
    </van-form>
  </div>
</template>

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
