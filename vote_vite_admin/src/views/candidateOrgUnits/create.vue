<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>
        创建待评价部门
      </template>
      <template #sub-title>
        创建待评价部门请填写相关信息后点击提交
      </template>
      <template #action>
        <van-button plain size="mini" icon="plus" type="success" @click="gotoIndex">
          返回索引
        </van-button>
      </template>
    </pageHeader>
    <van-form ref="formRef" @submit="createCandidateOrgUnit">
      <van-cell-group>
        <van-cell title="待评价部门名称" />
        <van-field v-model="(form.organName as string)" name="organName" left-icon="description" placeholder="待评价部门名称"
          :rules="formRules.organName">
        </van-field>

        <van-cell title="待评价部门编码" />
        <van-field v-model="(form.organCode as string)" name="organCode" left-icon="records" placeholder="待评价部门编码"
          :rules="formRules.name">
        </van-field>

        <van-cell title="待评价部门类别" />
        <van-radio-group v-model="form.category" direction="horizontal" class="van-cell van-field">
          <van-radio v-for="item in enum2arr(CandidateOrgUnitCategory)" label-position="right" :name="item">
            {{ CandidateOrgUnitCategory[item] }}
          </van-radio>
        </van-radio-group>

        <van-cell title="分管行领导" />
        <van-field v-model="form.superiorId" name="superiorId" left-icon="records" placeholder="分管行领导"
          :rules="formRules.superiorId" @click="showPopup = true">
        </van-field>
        <userLookup :show-popup="showPopup" @update:userid="onUserLookupConfirmed"></userLookup>
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
import { useCandidateOrgUnitCreateForm } from './hooks/useCandidateOrgUnitCreateForm'
import userLookup from './components/userLookup.vue';
import { enum2arr } from '/@/utils/app'
import { CandidateOrgUnitCategory } from '/@/openapi'

const router = useRouter();
let showPopup = ref(false);
const { loading, form, formRef, formRules, createCandidateOrgUnit } = useCandidateOrgUnitCreateForm();

async function gotoIndex() {
  router.push({
    name: 'candidateOrgUnit.index',
  })
}

const onUserLookupConfirmed = (params: { name: string | undefined, id: string | undefined }) => {
  console.log(params);
  form.superiorId = params.id;
  showPopup.value = false;
}

</script>

<script lang="ts">
export default defineComponent({
  name: 'candidateOrgUnit.create',
})
</script>
<style scoped></style>

<route lang="yaml">
name: candidateOrgUnit.create
meta:
  title: 待评部门创建
  visible: false
  keepAlive: true
  requiredAuth: true
</route>
