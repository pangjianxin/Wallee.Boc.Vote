<template>
  <div class="m-5px">
    <peageHeader>
      <template #title>
        评测内容列表
      </template>
      <template #sub-title>
        评测内容增、删、改、查的管理
      </template>
      <template #action>
        <div>
          <van-button type="primary" @click="gotoCreate" icon="plus" plain size="mini"
            v-permission="'Vote.EvaluationContents.Create'">
            添加
          </van-button>
          <van-button type="warning" @click="refresh" icon="replay" plain size="mini"
            v-permission="'Vote.EvaluationContents'">
            刷新
          </van-button>
        </div>
      </template>
    </peageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <evaluationContentVue v-for="item in cachedList" :key="item.id" :content="item">
        <template #action>
          <van-button type="danger" plain size="mini" @click="(_$event: any) => deleteEvaluation(item)"
            v-permission="'Vote.EvaluationContents.Delete'">
            删除
          </van-button>
          <van-button type="primary" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)"
            v-permission="'Vote.EvaluationContents.Update'">
            修改
          </van-button>
        </template>
      </evaluationContentVue>
    </van-list>

  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useEvaluationContentList } from './hooks/useEvaluationContentList';
import { EvaluationContentDto, EvaluationContentService } from '/@/openapi';
import peageHeader from '/@/components/PageHeader/index.vue';
import { confirmDialog } from '/@/utils/app';
import evaluationContentVue from './components/evaluationContent.vue';
const { loading, finished, cachedList, getList, pageable,clear } = useEvaluationContentList();
const router = useRouter();


const onLoad = async () => {
  await getList();
  pageable.pageNum++;
};

const gotoEdit = async (id: string) => {
  await router.push({
    name: "evaluationContent.edit",
    params: {
      evaluationContentId: id
    }
  })
};

const gotoCreate = () => {
  router.push({
    name: "evaluationContent.create"
  })
};

const deleteEvaluation = async (content: EvaluationContentDto) => {
  let res = await confirmDialog("提示", "确认删除该评估内容吗");
  if (res === true) {
    await EvaluationContentService.evaluationContentDelete({ id: content.id! });
    let index = cachedList.value.indexOf(content);
    cachedList.value.splice(index, 1);
  }
}

const refresh=async()=>{
  clear();
  await getList();  
}
</script>

<style scoped lang="scss"></style>

<route lang="yaml">
name: evaluationContent.index 
meta: 
  title: 评估内容 
  icon: column 
  visible: false 
  keepAlive: true 
  order: 4 
  requiredAuth: true 
  permission: Vote.EvaluationContents 
</route> 