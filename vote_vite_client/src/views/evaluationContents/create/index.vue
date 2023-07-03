<template>
  <div class="m-5px">
    <pageHeader>
      <template #title> 创建评测内容 </template>
      <template #sub-title> 创建评估内容请填写相关信息 </template>
      <template #action>
        <van-button plain type="primary" icon="arrow-left" size="mini" @click="backToIndex">
          返回索引
        </van-button>
      </template>
    </pageHeader>
    <van-form ref="formRef" @submit="createEvaluationContent" class="mt-10px">
      <van-cell-group>
        <van-field label-align="top" label="内容名称" v-model="(form.name as string)" name="name" left-icon="records"
          placeholder="填写评估内容名称" :rules="formRules.name" />

        <van-field label-align="top" label="内容类型" left-icon="description" name="category">
          <template #input>
            <van-radio-group icon-size="16" v-model="form.category" direction="horizontal">
              <van-radio v-for="item in enum2arr(EvaluationCategory)" label-position="right" :name="item">
                {{ EvaluationCategory[item] }}
              </van-radio>
            </van-radio-group>
          </template>
        </van-field>

        <van-field label-align="top" label="内容描述" left-icon="description" v-model="(form.description as string)"
          type="textarea" autosize name="description" placeholder="评估内容描述" :rules="formRules.description" />
      </van-cell-group>
      <van-row class="mt-10px">
        <van-button block type="primary" native-type="submit" :loading="loading"
          v-permission="'Vote.EvaluationContents.Create'">
          提交
        </van-button>
      </van-row>
    </van-form>
  </div>
</template>

<script setup lang="ts">
import { useEvlauationContentCreateForm } from "../hooks/useEvaluationContentCreateForm";
import { EvaluationCategory } from "/@/openapi";
import { enum2arr } from "/@/utils/app";
import pageHeader from "/@/components/PageHeader/index.vue";

const { loading, formRef, formRules, form, createEvaluationContent } =
  useEvlauationContentCreateForm();
const router = useRouter();

function backToIndex() {
  router.push({ name: "evaluationContent.index" });
}
</script>

<script lang="ts">
export default defineComponent({
  name: "evaluationContent.create",
});
</script>

<style scoped></style>

<route lang="yaml">
name: evaluationContent.create
meta:
  title: 新增评估内容
  icon: column
  visible: false
  keepAlive: true
  requiredAuth: true
  permission: Vote.EvaluationContents.Create
</route>
