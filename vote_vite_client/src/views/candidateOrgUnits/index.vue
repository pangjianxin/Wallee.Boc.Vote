<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>
        待评价部门列表
      </template>
      <template #sub-title>
        该页面可通向编辑、新增和删除等功能页面
      </template>
      <template #action>
        <van-button type="primary" size="mini" plain @click="gotoCreate" icon="plus"
          v-permission="'Vote.CandidateOrgUnits.Create'">
          创建部门
        </van-button>
      </template>
    </pageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <candidateOrgUnitVue v-for="item in cachedList" :key="item.id!" :org-unit="item">
        <template #action>
          <van-button type="danger" icon="delete" plain size="mini"
            @click="(_$event: any) => deleteCandidateOrgUnit(item)" v-permission="'Vote.CandidateOrgUnits.Delete'">
            删除
          </van-button>
          <van-button type="primary" icon="setting" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)"
            v-permission="'Vote.CandidateOrgUnits.Update'">
            修改
          </van-button>
        </template>
      </candidateOrgUnitVue>
    </van-list>
  </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue'
import candidateOrgUnitVue from './components/candidateOrgUnit.vue';
import { useCandidateOrgUnitList } from './hooks/useCandidateOrgUnitList';
import { CandidateOrgUnitDto, CandidateOrgUnitService } from '/@/openapi';
import { confirmDialog } from '/@/utils/app';
const { loading, finished, cachedList, getList, pageable } = useCandidateOrgUnitList();
const router = useRouter()

const onLoad = async () => {
  await getList();
  pageable.pageNum++;
};

const deleteCandidateOrgUnit = async (item: CandidateOrgUnitDto) => {
  let res = await confirmDialog("删除待评部门", "确认删除该待评部门吗？");
  if (res === true) {
    await CandidateOrgUnitService.candidateOrgUnitDelete({ id: item.id! });
    const index = cachedList.value.indexOf(item);
    if (index > -1) {
      cachedList.value.splice(index, 1);
    }
  }
}

const gotoEdit = async (orgId: string) => {
  router.push({
    name: "candidateOrgUnit.edit",
    params: {
      candidateOrgUnitId: orgId
    }
  })
}

const gotoCreate = async () => {
  await router.push({
    name: 'candidateOrgUnit.create',
  })
}
</script>

<style scoped></style>

<route lang="yaml"> 
name: candidateOrgUnit.index 
meta: 
  title: 待评部门 
  icon: manager 
  visible: true 
  keepAlive: false 
  order: 1 
  requiredAuth: true 
  permission: Vote.CandidateOrgUnits 
</route> 
