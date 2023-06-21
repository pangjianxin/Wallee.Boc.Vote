<template>
  <van-form ref="formRef" @submit="passwordLoginF">
    <van-cell-group inset>
      <van-field v-model="form.username" name="用户名" left-icon="user-o" placeholder="用户名" :rules="formRules.username" />
      <van-field v-model="form.password" :type="passwordVisible ? 'text' : 'password'" name="密码" left-icon="shield-o"
        :right-icon="passwordVisible ? 'eye-o' : 'closed-eye'" @click-right-icon="togglePasswordVisible" placeholder="密码"
        :rules="formRules.password" />
    </van-cell-group>
    <div style="margin: 16px;">
      <van-button round block type="primary" native-type="submit" :loading="loading">
        提交
      </van-button>
    </div>
  </van-form>
</template>

<script setup lang="ts">
import { useLogin } from "../hooks/useLogin";
import useOidcStore from "/@/store/modules/useOidcStore";
import useAppConfigStore from "/@/store/modules/useApplicationConfigStore";
import { useRouter } from "vue-router";
let props = defineProps({
  returnUrl: {
    type: String,
    required: false
  }
})

const { storeTokenInfo, storeUserInfo } = useOidcStore();
const appCofigStore = useAppConfigStore();
const router = useRouter();
const passwordVisible = ref(false);

const {
  formRef,
  loading,
  form,
  formRules,
  passwordLogin,
  getUserInfo,
} = useLogin();

const passwordLoginF = async () => {
  let tokenRes = await passwordLogin();
  if (tokenRes) {
    storeTokenInfo(tokenRes);
    let userRes = await getUserInfo();
    storeUserInfo(userRes);
    await appCofigStore.initConfig();
    if (props.returnUrl) {
      await router.push({
        path: props.returnUrl
      });
    }
  }
}

const togglePasswordVisible = () => {
  passwordVisible.value = !passwordVisible.value;
}
</script>

<style scoped lang="scss"></style>

