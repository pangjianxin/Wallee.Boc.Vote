
<template>
  <div class="m-5px">
    <van-image :src="index_png"></van-image>
    <van-notice-bar left-icon="volume-o" :text="message" />
    <template v-if="loading">
      <van-loading></van-loading>
    </template>
    <template v-else>
      <template v-if="list && list.length > 0">
        <appraisementVue v-for="item in list" :appraisement="item" :key="item.id!">
        </appraisementVue>
      </template>
      <van-empty v-else image="error" description="没有查询到可用的评价活动">
      </van-empty>
    </template>
  </div>
</template>

<script setup lang="ts">
import appraisementVue from './components/appraisement.vue';
import useAvailableAppraisementList from './hooks/useAvailableAppraisementList';
import index_png from '/@/assets/images/index.png';

const { loading, list, getAvailableAppraisements } = useAvailableAppraisementList();
let message = computed(() => {
  if (list.value) {
    return `当前有${list.value.length}个评价活动可用,请扫描管理员提供的二维码进入评价。`
  } else {
    return `正在从后台获取数据，请稍等。`
  }
})
onMounted(async () => {
  await getAvailableAppraisements();
});
</script>

<style scoped></style>

<route lang="yaml">
name: index
meta:
  title: 首页
  icon: wap-home-o
  visible: true
  keepAlive: true
  order: 3
  requiredAuth: false
</route>
