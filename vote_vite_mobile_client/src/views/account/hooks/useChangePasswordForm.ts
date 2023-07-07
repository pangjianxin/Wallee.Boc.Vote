import type { FormInstance, FieldRule } from "vant";
import { notify } from "/@/utils/app";
import { ProfileService, ChangePasswordInput } from "/@/openapi";

export const useChangePasswordForm = () => {
  let loading = ref(false);
  
  let form = reactive<ChangePasswordInput>({
    currentPassword: null,
    newPassword: "",
  });

  let formRef = ref<FormInstance>();

  let formRules = reactive<Record<string, FieldRule[]>>({
    currentPassword: [
      {
        required: true,
        message: "当前密码不能为空",
        trigger: "onBlur",
      },
    ],
    newPassword: [
      {
        required: true,
        message: "新密码不能为空",
        trigger: "onBlur",
      },
    ],
  });

  const clearForm = () => {
    form.currentPassword = undefined;
    form.newPassword = "";
  };

  const changePassword = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await ProfileService.profileChangePassword({
        requestBody: form,
      });
      clearForm();
      notify("更新成功");
      return res;
    } catch (err: any) {
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return { loading, form, formRef, formRules, changePassword };
};
