<template>
    <van-form ref="formRef" @submit="changePassword" class="mt-10px">
        <van-cell-group inset>
            <van-field autocomplete="on" label-align="top" label="当前密码" :type="passwordVisible ? 'text' : 'password'" left-icon="shield-o"
                :right-icon="passwordVisible ? 'eye-o' : 'closed-eye'" placeholder="请输入当前密码" name="currentPassword"
                :rules="formRules.currentPassword" @click-right-icon="passwordVisible = !passwordVisible"
                v-model="(form.currentPassword as string)">
            </van-field>

            <van-field autocomplete="on" label-align="top" label="新密码" :type="passwordVisible ? 'text' : 'password'" left-icon="shield-o"
                :right-icon="passwordVisible ? 'eye-o' : 'closed-eye'" placeholder="请输入新密码" name="newPassword"
                :rules="formRules.newPassword" @click-right-icon="passwordVisible = !passwordVisible"
                v-model="(form.newPassword as string)">
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
import { useChangePasswordForm } from '../hooks/useChangePasswordForm';
let passwordVisible = ref(false);
const { loading, form, formRef, formRules, changePassword } = useChangePasswordForm();
</script>

<style scoped></style>