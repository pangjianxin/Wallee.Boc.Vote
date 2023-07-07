<template>
    <div>
        <van-field type="textarea" v-model="val" autosize>
        </van-field>
    </div>
</template>

<script setup lang="ts">

let val = ref("{key:'value'}");

let props = defineProps({
    data: {
        type: String,
        required: true,
    },
});

watch(() => props.data,
    (newVal, _oldVal) => {
        if (newVal && newVal !== _oldVal) {
            val.value = JSON.stringify(JSON.parse(newVal), null, "\t");
        }
    },
    {
        immediate: true
    });
</script>

<style scoped></style>