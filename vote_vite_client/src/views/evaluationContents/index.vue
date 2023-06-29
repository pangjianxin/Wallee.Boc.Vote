<template>
  <div class="m-5px">
    <peageHeader>
      <template #title>
        评测内容列表
      </template>
      <template #sub-title>
        创建或者更新评估内容请点击相关按钮继续
      </template>
      <template #action>
        <van-button type="primary" @click="gotoCreate" icon="plus" plain size="mini">创建内容</van-button>
      </template>
    </peageHeader>
    <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" class="h-100%"
      @load="onLoad">
      <div v-for="item in cachedList" :key="item.id" class="flex flex-col justify-center items-center mt-5px p-10px shadow-sm shadow-warmgray b-rd-5px  bg-gradient-linear shape-[100deg] bg-gradient-from-red bg-gradient-via-orange bg-gradient-to-rose
        dark:bg-gradient-from-gray dark:bg-gradient-via-red dark:bg-gradient-to-black">
        <div class="flex flex-row justify-start items-center w-100%">
          <div class="flex flex-col justify-center items-start ml-3px">
            <div class="flex flex-row items-center">
              <span class="i-mdi-file-cog-outline text-20px mr-5px fw-600"></span>
              <span class="text-16px fw-600">{{ item.name }}</span>
            </div>
            <div class="text-12px c-gray-400 mt-5px">
              <van-tag type="success">
                {{ EvaluationCategory[item.category!] }}
              </van-tag>
              <van-tag class="ml-5px">{{ dayjs(item.creationTime).format('YYYY-MM-DD') }}</van-tag>
            </div>
          </div>
          <div class="flex-1"></div>
          <div class="self-end">
            <van-button type="danger" plain size="mini" @click="(_$event: any) => deleteEvaluation(item)">
              删除
            </van-button>
            <van-button type="primary" plain size="mini" @click="(_$event: any) => gotoEdit(item.id!)">
              修改
            </van-button>
          </div>
        </div>
        <van-text-ellipsis :rows="2" expand-text="展开" collapse-text="收起" :content="item.description!"
          class="mt-5px text-12px c-gray-500 w-100%"></van-text-ellipsis>
      </div>
    </van-list>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useEvaluationContentList } from './hooks/useEvaluationContentList';
const { loading, finished, cachedList, getList, pageable } = useEvaluationContentList();
import dayjs from 'dayjs';
import { EvaluationCategory, EvaluationContentDto, EvaluationContentService } from '/@/openapi';
import peageHeader from '/@/components/PageHeader/index.vue';
import { confirmDialog } from '/@/utils/app';
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
</script>

<style scoped lang="scss"></style>
<route lang="yaml">
name: evaluationContent.index
meta: 
  title: 评估内容
  icon: column
  visible: true
  requiredAuth: true
  keepAlive: false
  order: 4
</route>