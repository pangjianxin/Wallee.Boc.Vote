<template>
    <van-row justify="center" class="mt-10px">
        <van-uploader accept="application/x-font-ttf" v-model="fileList" :before-read="asyncBeforeRead"
            :after-read="asyncAfterRead" :max-count="1" preview-size="240">

        </van-uploader>
    </van-row>
</template>

<script setup lang="ts">
import { UploaderFileListItem } from 'vant';
import { toast, notify } from '/@/utils/app';
import { AppraisementService } from '/@/openapi';
let fileList = ref<UploaderFileListItem[]>([
]);

const asyncBeforeRead = (file: any): Promise<File | File[] | undefined> =>
    new Promise((resolve, reject) => {

        let canloadList = [".ttc", ".ttf"];
        if (canloadList.indexOf(file.name.substring(file.name.lastIndexOf("."))) == -1) {
            toast('请上传字体文件');
            reject();
        } else {
            resolve(file as File);
        }
    });

const asyncAfterRead = async (file: any) => {
    file.status = "uploading";
    file.message = "上传中";
    try {
        let formData = new FormData();
        formData.append('file', file.file);
        await AppraisementService.appraisementUploadQrcdoeBgImgFont({ formData: { File: file.file } });
        notify("上传成功");
        file.status = "done";
        file.message = "上传成功";
    } catch (err) {
        toast(err as string);
        file.status = "fail";
        file.message = "上传失败";
    }

}

</script>

<style scoped></style>