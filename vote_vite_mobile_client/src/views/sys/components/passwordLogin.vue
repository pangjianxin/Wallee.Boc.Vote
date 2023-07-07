<script setup lang="ts">
import { useRouter } from 'vue-router'
import { useLogin } from '../hooks/useLogin'
import useOidcStore from '/@/store/modules/useOidcStore'
import useAppConfigStore from '/@/store/modules/useApplicationConfigStore'

const { storeTokenInfo, storeUserInfo } = useOidcStore()
const appCofigStore = useAppConfigStore()
const router = useRouter()
const passwordVisible = ref(false)

const {
  formRef,
  loading,
  form,
  formRules,
  passwordLogin,
  getUserInfo,
} = useLogin()

async function passwordLoginF() {
  const tokenRes = await passwordLogin()
  if (tokenRes) {
    storeTokenInfo(tokenRes)
    const userRes = await getUserInfo()
    storeUserInfo(userRes)
    await appCofigStore.initConfig()
    await router.push({
      name: "index"
    })
  }
}

function togglePasswordVisible() {
  passwordVisible.value = !passwordVisible.value
}
</script>

<template>
  <van-form ref="formRef" @submit="passwordLoginF">
    <van-cell-group inset>
      <van-field v-model="form.username" name="用户名" left-icon="user-o" placeholder="用户名" :rules="formRules.username" />
      <van-field v-model="form.password" :type="passwordVisible ? 'text' : 'password'" name="密码" left-icon="shield-o"
        :right-icon="passwordVisible ? 'eye-o' : 'closed-eye'" placeholder="密码" :rules="formRules.password"
        @click-right-icon="togglePasswordVisible" />
    </van-cell-group>
    <div style="margin: 16px;">
      <van-button round block type="primary" native-type="submit" :loading="loading">
        提交
      </van-button>
    </div>
  </van-form>
</template>

<style scoped lang="scss"></style>
