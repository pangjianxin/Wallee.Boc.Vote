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
    <van-form ref="formRef" @submit="createCandidateOrgUnit" class="mt-10px">
      <van-cell-group inset>

        <van-field label-align="top" label="部门名称" left-icon="description" readonly v-model="selectedOrgUnit"
          placeholder="点击选择组织机构" name="organizationUnitId" :rules="formRules.organizationUnitId"
          @click="showOrgUnitLookupPopup = true">
        </van-field>
        <organizationUnitLookup :show-popup="showOrgUnitLookupPopup" @update:organization-unit="onOrgUnitLookupConfirmed">
        </organizationUnitLookup>

        <van-field label-align="top" label="部门描述" left-icon="description" type="textarea"
          v-model="(form.description as string)" placeholder="请添加部门描述" name="description" :rules="formRules.description">
        </van-field>


        <van-field label-align="top" label="分管领导" left-icon="records" v-model="selectedUser" placeholder="点击选择用户"
          name="superiorId" :rules="formRules.superiorId" @click="showUserLookupPopup = true">
        </van-field>
        <userLookup :show-popup="showUserLookupPopup" @update:user="onUserLookupConfirmed"></userLookup>

        <van-field label-align="top" label="部门类别" left-icon="records">
          <template #input>
            <van-radio-group icon-size="16" v-model="form.category" direction="horizontal">
              <van-radio v-for="item in enum2arr(CandidateOrgUnitCategory)" label-position="right" :name="item">
                {{ CandidateOrgUnitCategory[item] }}
              </van-radio>
            </van-radio-group>
          </template>
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
import { useCandidateOrgUnitCreateForm } from '../hooks/useCandidateOrgUnitCreateForm'
import userLookup from '../components/userLookup.vue';
import organizationUnitLookup from '../components/orgUnitLookup.vue';
import { enum2arr } from '/@/utils/app'
import { CandidateOrgUnitCategory } from '/@/openapi'

const router = useRouter();
let showUserLookupPopup = ref(false);
let showOrgUnitLookupPopup = ref(false);
let selectedOrgUnit = ref("");
let selectedUser = ref("");
const { loading, form, formRef, formRules, createCandidateOrgUnit } = useCandidateOrgUnitCreateForm();

async function gotoIndex() {
  router.push({
    name: 'candidateOrgUnit.index',
  })
}

const onUserLookupConfirmed = (params: { text: string | undefined, value: string | undefined }) => {
  selectedUser.value = params?.text!;
  form.superiorId = params?.value;
  showUserLookupPopup.value = false;
}

const onOrgUnitLookupConfirmed = (params: { text: string | undefined, value: string | undefined }) => {
  selectedOrgUnit.value = params?.text!;
  form.organizationUnitId = params?.value;
  showOrgUnitLookupPopup.value = false;
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