import type { FormInstance, FieldRule } from "vant";
import { notify } from "/@/utils/app";
import {
  ProfileService,
  UpdateProfileDto,
} from "/@/openapi";

export const useUpdateProfileForm = () => {
  let loading = ref(false);
  let formRef = ref<FormInstance>();
  let form = reactive<UpdateProfileDto>({
    userName: null,
    email: null,
    name: null,
    surname: null,
    phoneNumber: null,
    concurrencyStamp: null,
  });
  let formRules = reactive<Record<string, FieldRule[]>>({
    userName: [
      {
        required: true,
        message: "用户名必须填写",
        trigger: "onBlur",
      },
    ],
    email: [
      {
        required: true,
        message: "邮箱必须填写",
        trigger: "onBlur",
      },
      //   {
      //     validator: (value, _rule) => {
      //       if (value.indexOf("@") === -1) {
      //         return false;
      //       }
      //       return true;
      //     },
      //     message: "邮箱格式不正确",
      //   },
    ],
    name: [
      {
        required: true,
        message: "用户名称必须填写",
        trigger: "onBlur",
      },
    ],
    phoneNumber: [
      {
        required: true,
        message: "手机号必须填写",
        trigger: "onBlur",
      },
    ],
  });
  const updateProfile = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await ProfileService.profileUpdate({
        requestBody: form,
      });
      notify("更新成功");
      return res;
    } catch (err: any) {
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return { loading, form, formRef, formRules, updateProfile };
};
