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
          <van-button type="primary" plain size="mini" icon="plus" @click="gotoCreate"
            v-permission="'Vote.Appraisements.Create'">
            创建</van-button>
          <van-button type="primary" plain size="mini" icon="replay" @click="refresh">
            刷新
          </van-button>
        </van-row>
      </template>
    </pageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <appraisementVue v-for="item in cachedList" :key="item.id" :appraisement="item">
        <template #action>
          <van-button type="danger" icon="delete" plain size="mini" @click="(_$event: any) => deleteAppraisement(item)"
            v-permission="'Vote.Appraisements.Delete'">
            删除
          </van-button>
          <van-button type="warning" icon="setting" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)"
            v-permission="'Vote.Appraisements.Update'">
            修改
          </van-button>
          <van-button type="primary" icon="tv-o" plain size="mini" @click="(_$event: any) => gotoView(item.id!)"
            v-permission="'Vote.Appraisements.Update'">
            查看
          </van-button>
        </template>
      </appraisementVue>
    </van-list>
  </div>
</template>
<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import appraisementVue from './components/appraisement.vue';
import { useAppraisementList } from './hooks/useAppraisementList';
import { AppraisementDto, AppraisementService } from '/@/openapi';
import { confirmDialog } from '/@/utils/app';

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
const gotoView = async (id: string) => {
  await router.push({
    name: "appraisement.detail",
    params: {
      appraisementId: id
    }
  })
}

</script>
<style scoped></style>

<route lang="yaml">
name: appraisement.index
meta: 
  title: 评价活动
  icon: balance-list
  visible: false
  keepAlive: true
  order: 2
  requiredAuth: true
  permission: Vote.Appraisements
</route>
