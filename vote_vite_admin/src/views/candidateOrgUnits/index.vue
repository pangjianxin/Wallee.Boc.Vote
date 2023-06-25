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
        <van-button type="primary" size="mini" plain @click="gotoCreate">
          创建待评部门
        </van-button>
      </template>
    </pageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <div v-for="item in cachedList" :key="item.id"
        class="flex flex-col justify-center items-center mt-5px px-5px py-10px shadow-sm shadow-warmgray b-rd-5px bg-gradient-linear shape-[100deg] bg-gradient-from-red bg-gradient-via-orange bg-gradient-to-rose">
        <div class="flex flex-row justify-start items-center w-100%">
          <div class="flex flex-col justify-center items-start ml-3px">
            <div class="flex flex-row items-center">
              <span class="i-mdi-folder-home-outline text-20px text-sky-300 mr-5px fw-600"></span>
              <span class="text-16px fw-600">{{ item.organName }}</span>
            </div>
            <div class="text-12px fw-100 c-gray-700">
              机构编号:{{ item.organCode }},分管行领导:{{ item.superiorName }}
            </div>
            <div class="text-12px c-gray-400 mt-5px">
              <van-tag type="success">
                {{ CandidateOrgUnitCategory[item.category!] }}
              </van-tag>
              <van-tag :type="item.isActive === true ? 'primary' : 'danger'" class="ml-5px">
                {{ item.isActive ? "有效" : "无效" }}
              </van-tag>
            </div>
          </div>
          <div class="flex-1"></div>
          <div class="self-end">
            <van-button type="danger" plain size="mini" @click="(_$event: any) => deleteCandidateOrgUnit(item)">
              删除
            </van-button>
            <van-button type="primary" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)">修改</van-button>
          </div>
        </div>
      </div>
    </van-list>
  </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue'
import { useCandidateOrgUnitList } from './hooks/useCandidateOrgUnitList';
import { CandidateOrgUnitCategory, CandidateOrgUnitDto, CandidateOrgUnitService } from '/@/openapi';
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
  requiredAuth: true
  keepAlive: false
  order: 1
</route>
