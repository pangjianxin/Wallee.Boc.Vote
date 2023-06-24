<template>
    <van-popup :show="showPopup" round position="bottom">
        <van-search v-model="searchValue" @search="userLookup"></van-search>
        <van-picker :columns="columns" @cancel="onCancel" @confirm="onConfirm" />
    </van-popup>
</template>

<script setup lang="ts">
import { PickerColumn } from 'vant';
import { UserData, UserLookupService } from '/@/openapi'

let searchValue = ref("");
let columns = ref<PickerColumn>([]);

defineProps({
    showPopup: {
        type: Boolean,
        required: false
    },
});

let emits = defineEmits(["update:userid"]);


const userLookup = async () => {
    let list = await UserLookupService.userLookupSearch({ filter: searchValue.value });
    columns.value = [];
    list.items?.forEach((element: UserData) => {
        console.log(element);
        columns.value.push({
            text: element.name as string,
            value: element.id,
            name: element.name
        });
    });
}
const onConfirm = ({ selectedOptions }: { selectedOptions: PickerColumn }) => {
    emits("update:userid", { name: selectedOptions[0].name, id: selectedOptions[0].value });
}

const onCancel = () => {
    emits("update:userid", {});
}
</script>

<style scoped></style>