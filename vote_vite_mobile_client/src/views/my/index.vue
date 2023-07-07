<template>
    <van-image :src="my_info" class="relative mb--30px"></van-image>
    <van-row justify="space-around" class="relative p-10px m-5px bg-transparent b-white b-rd-5px">
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
            <div class="flex flex-col items-center">
                <van-icon size="30" name="friends-o"></van-icon>
                <span class="text-13px c-gray fw-600">
                    待评人员
                </span>
            </div>
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
        <van-cell title="单元格" value="内容" />
        <van-cell title="单元格" value="内容" label="描述信息" />
    </van-cell-group>
</template>
<script setup lang="ts">
import my_info from '/@/assets/images/my_info.png';
</script>

<style scoped></style>

<route lang="yaml">
name: my.index
meta: 
  title: 我的
  icon: setting-o
  visible: true 
  keepAlive: true
  order: 5
  requiredAuth: true
</route>
