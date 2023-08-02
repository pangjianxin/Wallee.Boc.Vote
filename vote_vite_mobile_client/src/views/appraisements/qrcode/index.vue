<template>
    <div class="m-5px">
        <pageHeader>
            <template #title>
                上传二维码背景图
            </template>
            <template #sub-title>
                根据文本提示上传相应的文件
            </template>
        </pageHeader>
        <van-divider content-position="left">上传二维码背景图片</van-divider>
        <uploadBgImg>
        </uploadBgImg>
        <van-divider content-position="left">上传二维码字体文件</van-divider>
        <uploadBgImgFont>
        </uploadBgImgFont>
    </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import uploadBgImg from '/@/views/appraisements/components/uploadBgImg.vue';
import uploadBgImgFont from '/@/views/appraisements/components/uploadBgImgFont.vue';
</script>

<style scoped lang="scss"></style>
<route lang="yaml">
name: appraisement.qrcode.upload
meta: 
  title: 评价活动二维码背景
  visible: false
  requiredAuth: true
</route>