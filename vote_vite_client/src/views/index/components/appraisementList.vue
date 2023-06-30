<template>
    <div class="m-5px">
        <appraisement v-for="item in list" :item="item" :key="item.id"></appraisement>
    </div>
</template>

<script setup lang="ts">
import appraisement from './appraisement.vue';
import { AppraisementDto } from '/@/openapi';
defineProps({
    list: {
        type: Array as PropType<AppraisementDto[]>,
        required: true
    }
});

</script>

<style scoped lang="scss"></style>