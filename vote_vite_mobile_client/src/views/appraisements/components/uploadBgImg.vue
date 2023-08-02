<template>
    <van-row justify="center" class="mt-10px">
        <van-uploader v-model="fileList" :before-read="asyncBeforeRead" :after-read="asyncAfterRead" :max-count="1"
            preview-size="240">
            <template #preview-cover="{ file }">
                <div class="preview-cover van-ellipsis">{{ file.name }}</div>
            </template>
        </van-uploader>
    </van-row>
</template>

<script setup lang="ts">
import { UploaderFileListItem } from 'vant';
import { toast, notify } from '/@/utils/app';
import { AppraisementService } from '/@/openapi';
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
    let formData = new FormData();
    formData.append('file', file.file);
    await AppraisementService.appraisementUploadQrcodeBgImg({ formData: { File: file.file } });
    notify("上传成功");
}

</script>

<style scoped lang="scss">
.preview-cover {
    position: absolute;
    bottom: 0;
    box-sizing: border-box;
    width: 100%;
    padding: 4px;
    color: #fff;
    font-size: 12px;
    text-align: center;
    background: rgba(0, 0, 0, 0.3);
}
</style>