<template>
    <van-form ref="formRef" @submit="updateProfile" class="mt-10px">
        <van-cell-group inset>
            <van-field label-align="top" label="登录名" left-icon="description" v-model="(form.userName as string)"
                placeholder="请输入登录名" name="userName" :rules="formRules.userName">
            </van-field>

            <van-field label-align="top" label="用户名称" left-icon="envelop-o" v-model="(form.name as string)"
                placeholder="请输入用户名称" name="name" :rules="formRules.name">
            </van-field>

            <van-field label-align="top" label="邮箱" type="email" left-icon="envelop-o" v-model="(form.email as string)"
                placeholder="请输入邮箱" name="email" :rules="formRules.email">
            </van-field>

            <van-field label-align="top" label="手机号" type="tel" left-icon="phone-o" v-model="(form.phoneNumber as string)"
                placeholder="请输入手机号" name="phoneNumber" :rules="formRules.phoneNumber">
            </van-field>

        </van-cell-group>
        <van-row class="mt-10px">
            <van-button block type="primary" native-type="submit" :loading="loading">
                提交
            </van-button>
        </van-row>
    </van-form>
</template>

<script setup lang="ts">
import { useUpdateProfileForm } from '../hooks/useUpdateProfileForm';
import { ProfileDto } from '/@/openapi';
const { loading, form, formRef, formRules, updateProfile } = useUpdateProfileForm();
let props = defineProps({
    profile: {
        type: Object as PropType<ProfileDto>,
        required: true
    }
});

watch(
    () => props.profile,
    (newVal, _oldVal) => {
        if (newVal && newVal !== _oldVal) {
            form.userName = newVal.userName;
            form.name = newVal.name;
            form.email = newVal.email;
            form.phoneNumber = newVal.phoneNumber;
        }
    }, {
    deep: true,
    immediate: true
});

</script>

<style scoped></style>