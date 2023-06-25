<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>
        修改待评价部门
      </template>
      <template #sub-title>
        修改待评价部门请填写相关信息后点击提交
      </template>
      <template #action>
        <van-button plain size="mini" icon="plus" type="success" @click="gotoIndex">
          返回索引
        </van-button>
      </template>
    </pageHeader>
    <van-form ref="formRef" @submit="updateCandidateOrgUnit">
      <van-cell-group>
        <van-cell title="待评价部门名称" />
        <van-field readonly v-model="selectedOrgUnit" left-icon="description" placeholder="待评价部门名称"
          :rules="formRules.organizationUnitId" @click="showOrgUnitLookupPopup = true">
        </van-field>
        <organizationUnitLookup :show-popup="showOrgUnitLookupPopup" @update:organization-unit="onOrgUnitLookupConfirmed">
        </organizationUnitLookup>

        <van-cell title="分管行领导" />
        <van-field v-model="selectedUser" name="superiorId" left-icon="records" placeholder="分管行领导"
          :rules="formRules.superiorId" @click="showUserLookupPopup = true">
        </van-field>
        <userLookup :show-popup="showUserLookupPopup" @update:user="onUserLookupConfirmed"></userLookup>

        <van-cell title="待评价部门类别" />
        <van-radio-group v-model="form.category" direction="horizontal" class="van-cell van-field">
          <van-radio v-for="item in enum2arr(CandidateOrgUnitCategory)" label-position="right" :name="item">
            {{ CandidateOrgUnitCategory[item] }}
          </van-radio>
        </van-radio-group>

        <van-cell title="是否有效" />
        <van-radio-group v-model="form.isActive" direction="horizontal" class="van-cell van-field">
          <van-radio label-position="right" :name="true">
            有效
          </van-radio>
          <van-radio label-position="right" :name="false">
            无效
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
import { useCandidateOrgUnitUpdateForm } from './hooks/useCandidateOrgUnitUpdateForm'
import userLookup from './components/userLookup.vue';
import organizationUnitLookup from './components/orgUnitLookup.vue';
import { enum2arr } from '/@/utils/app'
import { CandidateOrgUnitCategory, CandidateOrgUnitService } from '/@/openapi'
const route = useRoute();
const router = useRouter();
let showUserLookupPopup = ref(false);
let showOrgUnitLookupPopup = ref(false);
let selectedOrgUnit = ref("");
let selectedUser = ref("");

const { id, loading, form, formRef, formRules, updateCandidateOrgUnit } = useCandidateOrgUnitUpdateForm();

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

const getCandidateOrgUnit = async () => {
  let res = await CandidateOrgUnitService.candidateOrgUnitGet({ id: id.value });
  form.organizationUnitId = res.organizationUnitId;
  form.superiorId = res.superior;
  form.isActive = res.isActive;
  form.concurrencyStamp = res.concurrencyStamp;
  selectedOrgUnit.value = res.organName!;
  selectedUser.value = res.superiorName!;
}

onMounted(async () => {
  id.value = route.params.candidateOrgUnitId as string;
  await getCandidateOrgUnit();
});

</script>

<style scoped></style>

<route lang="yaml">
name: candidateOrgUnit.edit
meta:
  title: 待评部门修改
  visible: false
  keepAlive: true
  requiredAuth: true
</route>