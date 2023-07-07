import type { FormInstance, FieldRule } from "vant";
import {
  AppraisementCategory,
  AppraisementUpdateDto,
  AppraisementService,
} from "/@/openapi";
import { notify, toast } from "/@/utils/app";
export const useAppraisementUpdateForm = () => {
  let loading = ref(false);
  let id = ref("");
  let formRef = ref<FormInstance>();
  let formRules = reactive<Record<string, FieldRule[]>>({
    name: [
      {
        required: true,
        message: "请输入名称",
        trigger: "onBlur",
      },
    ],
    description: [
      {
        required: true,
        message: "请输入描述",
        trigger: "onBlur",
      },
    ],
    category: [
      {
        required: true,
        message: "请选择类别",
        trigger: "onBlur",
      },
    ],
    start: [
      {
        required: true,
        message: "请输入起始日期",
        trigger: "onBlur",
      },
    ],
    end: [
      {
        required: true,
        message: "请输入结束日期",
        trigger: "onBlur",
      },
    ],
  });
  const clearForm = () => {
    form.category = AppraisementCategory.部门评价;
    form.name = undefined;
    form.description = undefined;
    form.start = undefined;
    form.end = undefined;
  };
  let form = reactive<AppraisementUpdateDto>({});

  const updateAppraisement = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await AppraisementService.appraisementUpdate({
        id: id.value,
        requestBody: form,
      });
      clearForm();
      notify("更新成功");
      return res;
    } catch (err: any) {
      if (err) toast(err.message);
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return {
    id,
    loading,
    formRef,
    formRules,
    form,
    updateAppraisement,
  };
};
