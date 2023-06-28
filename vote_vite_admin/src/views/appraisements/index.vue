<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>
        评价活动列表
      </template>
      <template #sub-title?>
        点击新增按钮进入创建评价活动页面
      </template>
      <template #action>
        <van-row justify="end">
          <van-button type="primary" plain size="mini" icon="plus" @click="gotoCreate">创建</van-button>
          <van-button type="primary" plain size="mini" icon="replay" @click="refresh">刷新</van-button>
        </van-row>
      </template>
    </pageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <div v-for="item in cachedList" :key="item.id"
        class="flex flex-col mt-5px px-5px py-10px shadow-sm shadow-warmgray b-rd-5px bg-gradient-linear shape-[100deg] bg-gradient-from-purple bg-gradient-via-orange bg-gradient-to-rose">
        <div class="flex flex-row justify-between items-center w-100%">
          <span class="flex items-center text-16px fw-600">
            <i class="i-mdi-note-multiple-outline text-16px"></i>
            {{ item.name }}
          </span>
          <span>
            <van-button type="danger" icon="delete" plain size="mini" @click="(_$event: any) => deleteAppraisement(item)">
              删除
            </van-button>
            <van-button type="primary" icon="setting" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)">
              修改
            </van-button>
          </span>
        </div>
        <div class="text-12px c-gray-400 mt-5px">
          <van-tag type="success">
            {{ AppraisementCategory[item.category!] }}
          </van-tag>
          <van-tag :type="isNotExpired(item.end!) ? 'primary' : 'danger'" class="ml-5px">
            {{ isNotExpired(item.end!) ? "进行中" : "已过期" }}
          </van-tag>
        </div>
        <van-text-ellipsis :rows="2" expand-text="展开" collapse-text="收起" :content="item.description!"
          class="my-5px text-12px c-gray-500 w-100%">
        </van-text-ellipsis>
      </div>
    </van-list>
  </div>
</template>
<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import { useAppraisementList } from './hooks/useAppraisementList';
import { AppraisementDto, AppraisementCategory, AppraisementService } from '/@/openapi';
import { confirmDialog } from '/@/utils/app';
import dayjs from 'dayjs';
const router = useRouter();
const {
  loading,
  cachedList,
  finished,
  pageable,
  getList } = useAppraisementList();

const onLoad = async () => {
  await getList();
  pageable.pageNum++;
};

const refresh = async () => {
  pageable.pageNum = 1;
  cachedList.value = [];
  await onLoad();
}

const deleteAppraisement = async (item: AppraisementDto) => {
  let res = await confirmDialog("删除该活动", `确认删除${item.name}吗?`);
  if (res === true) {
    await AppraisementService.appraisementDelete({ id: item.id! });
    const index = cachedList.value.indexOf(item);
    if (index > -1) {
      cachedList.value.splice(index, 1);
    }
  }
}

const gotoCreate = async () => {
  router.push({
    name: "appraisement.create"
  })
};

const gotoEdit = async (id: string) => {
  await router.push({
    name: "appraisement.edit",
    params: {
      appraisementId: id
    }
  })
}

const isNotExpired = (end: string) => {
  return dayjs(end).isAfter(dayjs());
}
</script>
<style scoped></style>

<route lang="yaml">
name: appraisement.index
meta:
  title: 评价活动
  icon: balance-list
  visible: true
  requiredAuth: true
  keepAlive: true
  order: 2
</route>
