import { FormInstance, FieldRule } from "vant";
import { toast, notify } from "/@/utils/app";
import {
  AppraisementResultService,
  AppraisementResultCreateDto,
  EvaluationCategory,
} from "/@/openapi";

export const useAppraisementResultForm = () => {
  let loading = ref(false);

  let form = reactive<AppraisementResultCreateDto>({
    appraisementId: undefined,
    roleName: null,
    category: EvaluationCategory.部门评价,
    details: [],
  });

  let formRules = reactive<Record<string, FieldRule[]>>({
    appraisementId: [
      { required: true, message: "请输入评价id", trigger: "onBlur" },
    ],
    roleName: [
      { required: true, message: "请输入评价者角色", trigger: "onBlur" },
    ],
    category: [
      {
        required: true,
        message: "请输入评价类别",
        trigger: "onBlur",
      },
    ],
  });

  let formRef = ref<FormInstance>();
  const clearForm = () => {};
  const createAppraisementResult = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      const res = await AppraisementResultService.appraisementResultCreate({
        requestBody: form,
      });
      notify("更新成功");
      clearForm();
      return res;
    } catch (err: any) {
      if (err) toast(err);
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return { loading, form, formRef, formRules, createAppraisementResult };
};
