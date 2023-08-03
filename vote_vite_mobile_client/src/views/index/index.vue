
<template>
  <div class="m-5px">
    <template v-if="loading">
      <van-loading></van-loading>
    </template>
    <template v-else>
      <template v-if="list && list.length > 0">
        <appraisementVue v-for="item in list" :appraisement="item" :key="item.id!">
          <template #footer>
            <van-button type="primary" round size="small" @click="_$event => gotoAppraisement(item.category!, item.id!)">
              开始评价
            </van-button>
          </template>
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
import { EvaluationCategory } from '/@/openapi';
const router = useRouter();
const { loading, list, getAvailableAppraisements } = useAvailableAppraisementList();

const gotoAppraisement = async (category: EvaluationCategory, appraisementId: string) => {
  switch (category) {
    case EvaluationCategory.部门评价:
      await router.push({
        name: "appraisement.eva",
        params: {
          appraisementId: appraisementId,
          ruleName: "分行正职"
        }
      })
  }
}

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
