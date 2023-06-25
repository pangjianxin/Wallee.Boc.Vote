<template>
    <van-popup :show="showPopup" round position="bottom">
        <van-cascader v-model="cascaderValue.value" title="请选择机构" :options="casCaderOptions" @close=onCascaderClose
            @change="getChildren" @finish="onCascaderFinish">
        </van-cascader>
    </van-popup>
</template>

<script setup lang="ts">
import { CascaderOption } from 'vant';
import { OrganizationUnitService, OrganizationUnitDto } from '/@/openapi'

type CascaderValue = {
    text: string,
    value: string
}
let cascaderValue = reactive<CascaderValue>({
    text: '',
    value: ''
});
let casCaderOptions = ref<CascaderOption[]>([]);

defineProps({
    showPopup: {
        type: Boolean,
        required: false
    },
});

let emits = defineEmits(["update:organizationUnit"]);

const getChildren = async (selected: { value: string | number, tabIndex: number, selectedOptions: CascaderOption[] }) => {
    if (selected.tabIndex === 0) {
        let list = (await OrganizationUnitService.organizationUnitFindChildren({ id: selected.value as string, recursive: true })).items!;
        let tree = generateTree(list, selected.value as string);
        tree.forEach((el: any) => {
            if (selected.selectedOptions.at(-1)?.children?.findIndex(it => it.value === el.value) === -1) {
                selected.selectedOptions.at(-1)?.children?.push(el);
            }
        });
    }
}

const getRoot = async () => {
    let list: OrganizationUnitDto[] = [];
    list = (await OrganizationUnitService.organizationUnitGetRoot()).items!;
    list.forEach((el: OrganizationUnitDto) => {
        casCaderOptions.value.push({
            text: el.displayName as string,
            value: el.id,
            code: el.code,
            children: [] as CascaderOption[]
        });
    });
}

const onCascaderFinish = ({ selectedOptions }: { selectedOptions: CascaderOption[] }) => {
    cascaderValue.text = selectedOptions.map(it => it.text).join("/");
    emits("update:organizationUnit", cascaderValue);
};

const onCascaderClose = () => {
    emits("update:organizationUnit", undefined);
}

onMounted(async () => {
    await getRoot();
});

const generateTree = (items: OrganizationUnitDto[], parentId: string): Array<CascaderOption> => {
    return items
        .filter(item => item.parentId === parentId)
        .map(item => {
            const children = generateTree(items, item.id!);
            return {
                text: item.displayName as string,
                value: item.id,
                code: item.code,
                children: children.length > 0 ? children : undefined
            };
        });
};
</script>

<style scoped></style>