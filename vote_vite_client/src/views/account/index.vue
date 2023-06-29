<template>
  <div class="m-5px">
    <pageHeader>
      <template #title>账户管理</template>
      <template #sub-title>通过点击TAB来切换不同的窗口</template>
      <template #action></template>
    </pageHeader>
    <div class="mt-10px">
      <van-tabs type="card">
        <van-tab title="用户信息">
          <updateProfile :profile="currentProfile!"></updateProfile>
        </van-tab>
        <van-tab title="修改密码">
          <changePassword></changePassword>
        </van-tab>
      </van-tabs>
    </div>
  </div>
</template>

<script setup lang="ts">
import pageHeader from '/@/components/PageHeader/index.vue';
import updateProfile from './components/updateProfile.vue';
import changePassword from './components/changePassword.vue';
import { ProfileDto, ProfileService } from '/@/openapi';

let currentProfile = ref<ProfileDto>();

async function fetchProfile() {
  var profile = await ProfileService.profileGet();
  currentProfile.value = profile;
}

onMounted(async () => {
  await fetchProfile();
});
</script>

<style scoped lang="scss"></style>

<route lang="yaml">
name: account
meta:
  title: 账户
  icon: setting
  order: 1
  keepAlive: false
  visible: false
  requiredAuth: true
</route>
