<template>
    <div>
        <van-uploader v-model="fileList" :before-read="asyncBeforeRead" :after-read="asyncAfterRead" :max-count="1">
            <template #preview-cover="{ file }">
                <div class="preview-cover van-ellipsis">{{ file.name }}</div>
            </template>
        </van-uploader>
        <van-button @click="console.log(fileList)">1</van-button>
    </div>
</template>

<script setup lang="ts">
import { UploaderFileListItem } from 'vant';
import { toast } from '/@/utils/app';
import { useUploadQrcodeBackgroundImageForm } from '/@/views/appraisements/hooks/useUploadQrcodeBackgroundImageForm';
let fileList = ref<UploaderFileListItem[]>([
]);

const { form, formRef, formRules, uploadQrcodeBackgroundImage } = useUploadQrcodeBackgroundImageForm();

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

const asyncAfterRead = (file: UploaderFileListItem | UploaderFileListItem[], _detail: {
    name: string | number;
    index: number;
}) => {
    //处理为字节流参数
    if(file instanceof UploaderFileListItem){
        
    }
    var imgUrl = file.content;
    var img = file.file;
    var reader = new FileReader();
    reader.readAsDataURL(img);
    reader.onloadend = function (e) {
        var file = img;
        var param = new FormData();
        param.append("file", file, file.name);
        //此处写ajax请求上传到服务器方法

    };
}
watch(() => fileList.value, (newVal) => {
    form.File = newVal[0];
})
</script>

<style scoped></style>
<route lang="yaml">
name: appraisement.qrcode.upload
meta: 
  title: 评价活动二维码背景
  visible: false
  requiredAuth: true
</route>