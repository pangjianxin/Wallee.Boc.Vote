<template>
    <van-image :src="my_info" class="relative mb--30px"></van-image>
    <van-row justify="space-between" class="relative p-10px m-5px bg-transparent b-white b-rd-5px">
        <van-col>
            <router-link :to="{ name: 'candidateOrgUnit.index' }">
                <div class="flex flex-col items-center">
                    <van-icon size="30" name="orders-o"></van-icon>
                    <span class="text-13px c-gray fw-600">
                        待评部门
                    </span>
                </div>
            </router-link>
        </van-col>
        <van-col>
            <router-link :to="{ name: 'evaluationContent.index' }">
                <div class="flex flex-col items-center">
                    <van-icon size="30" name="records"></van-icon>
                    <span class="text-13px c-gray fw-600">
                        评价内容
                    </span>
                </div>
            </router-link>
        </van-col>
        <van-col>
            <router-link :to="{ name: 'appraisement.index' }">
                <div class="flex flex-col items-center">
                    <van-icon size="30" name="todo-list-o"></van-icon>
                    <span class="text-13px c-gray fw-600">
                        评价活动
                    </span>
                </div>
            </router-link>
        </van-col>
    </van-row>
    <van-cell-group inset>
        <van-cell title="评价活动" is-link value="设置二维码背景" icon="shop-o" @click="redirectTo('appraisement.qrcode.upload')">
        </van-cell>
        <van-cell title="评价活动" is-link value="设置二维码字体" icon="shop-o" @click="redirectTo('appraisement.qrcode.upload')">
        </van-cell>
        <van-cell title="账户管理" is-link value="更新账户资料" icon="user-o" @click="redirectTo('account')">
        </van-cell>
    </van-cell-group>
</template>
<script setup lang="ts">
import my_info from '/@/assets/images/my_info.png';
const router = useRouter();

const redirectTo = (routeName: string) => {
    router.push({ name: routeName });
};
</script>

<style scoped></style>

<route lang="yaml">
name: my.index
meta: 
  title: 管理中心
  icon: setting-o
  visible: true 
  keepAlive: true
  order: 5
  requiredAuth: true
</route>
