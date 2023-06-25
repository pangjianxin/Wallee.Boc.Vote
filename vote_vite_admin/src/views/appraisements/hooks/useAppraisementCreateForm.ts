import type { FormInstance, FieldRule } from "vant";
import {
  AppraisementCategory,
  AppraisementCreateDto,
  AppraisementService,
} from "/@/openapi";
import { notify, toast } from "/@/utils/app";
export const useAppraisementCreateForm = () => {
  let loading = ref(false);
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
  let form = reactive<AppraisementCreateDto>({
    category: AppraisementCategory.部门评价,
  });

  const createAppraisement = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await AppraisementService.appraisementCreate({
        requestBody: form,
      });
      clearForm();
      notify("创建成功");
      return res;
    } catch (err: any) {
      if (err) toast(err.message);
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return { loading, formRef, formRules, form, createAppraisement };
};
