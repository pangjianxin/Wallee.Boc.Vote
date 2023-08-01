<template>
    <div>
        <van-uploader v-model="fileList" :before-read="asyncBeforeRead" :after-read="asyncAfterRead" :max-count="1">
            <template #preview-cover="{ file }">
                <div class="preview-cover van-ellipsis">{{ file.name }}</div>
            </template>
        </van-uploader>
        <van-button @click="console.log(fileList)">1</van-button>
        <van-button @click="downloadQrcodeAsync">2</van-button>
    </div>
</template>

<script setup lang="ts">
import { UploaderFileListItem } from 'vant';
import { toast } from '/@/utils/app';
import { AppraisementService } from '/@/openapi'
let fileList = ref<UploaderFileListItem[]>([
]);

const asyncBeforeRead = (file: File | File[], _detail: { name: string | number; index: number; }): Promise<File | File[] | undefined> =>
    new Promise((resolve, reject) => {
        if (file instanceof File) {
            let canloadList = ["image/jpeg", "image/png"];
            if (canloadList.indexOf(file.type) == -1) {
                toast('请上传 jpg或png 格式图片');
                reject();
            } else {
                resolve(file);
            }
        }
    });

const asyncAfterRead = async (file: any) => {
    console.log(file);
    let formData = new FormData();
    formData.append('file', file.file);
    await AppraisementService.appraisementUploadQrcodeBackgroundImage({ formData: { File: file.file } });
}

const downloadQrcodeAsync = async () => {
    let blob = await AppraisementService.appraisementGetDownloadAppraisementQrcode({ ruleName: 'test' });
    console.log(blob);
    const link = document.createElement('a')
    link.style.display = 'none'
    link.href = URL.createObjectURL(blob)
    link.download="1.png"
    document.body.appendChild(link);
    link.click()
    document.body.removeChild(link);
}

</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.qrcode.upload
meta: 
  title: 评价活动二维码背景
  visible: false
  requiredAuth: true
</route>