<template>
  <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" :offset="0" @load="onLoad">
    <!-- <van-cell v-for="item in cachedList" :key="item.id" :title="item.name!" :label="item.name!">

    </van-cell> -->

    <div v-for="item in cachedList" :key="item.id" class="flex flex-col justify-center items-center">
      <div>
        {{ item.name }}
      </div>
      <div>
        {{ item.description }}
      </div>
      <div>
        {{ item.concurrencyStamp }}
      </div>
    </div>
  </van-list>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useEvaluationContentList } from './hooks/useEvaluationContentList';
const { loading, finished, cachedList, getList, pageable } = useEvaluationContentList();
const router = useRouter();

const gotoCreate = () => {
  router.push({
    name: "evaluationContent.create"
  })
};

const onLoad = async () => {
  await getList();
  pageable.pageNum++;
};
</script>

<style scoped lang="scss"></style>
<route lang="yaml">
name: evaluationContent.index
meta: 
  title: 评估内容
  icon: column
  visible: true
  requiredAuth: false
  keepAlive: true
  order: 4
</route>