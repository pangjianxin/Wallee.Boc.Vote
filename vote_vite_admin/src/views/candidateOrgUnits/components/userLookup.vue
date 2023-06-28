<template>
    <van-popup :show="showPopup" round position="bottom">
        <van-search v-model="searchValue" @search="userLookup" placeholder="请输入用户名进行检索"></van-search>
        <van-picker :columns="columns" @cancel="onCancel" @confirm="onConfirm" />
    </van-popup>
</template>

<script setup lang="ts">
import { PickerColumn } from 'vant';
import { UserData, UserLookupService } from '/@/openapi'
type PickerValue = {
    text: string | undefined,
    value: string | undefined
}
let searchValue = ref("");
let columns = ref<PickerColumn>([]);
let pickerValue = reactive<PickerValue>({
    text: undefined,
    value: undefined
});

defineProps({
    showPopup: {
        type: Boolean,
        required: false
    },
});

let emits = defineEmits(["update:user"]);


const userLookup = async () => {
    let list = await UserLookupService.userLookupSearch({ filter: searchValue.value });
    columns.value = [];
    list.items?.forEach((element: UserData) => {
        columns.value.push({
            text: `${element.name as string}(${element.userName as string})`,
            value: element.id,
            name: element.name
        });
    });
}
const onConfirm = ({ selectedOptions }: { selectedOptions: PickerColumn }) => {
    pickerValue.text = selectedOptions[0].text as string;
    pickerValue.value = selectedOptions[0].value as string;
    emits("update:user", pickerValue);
}

const onCancel = () => {
    emits("update:user", undefined);
}
</script>

<style scoped></style>