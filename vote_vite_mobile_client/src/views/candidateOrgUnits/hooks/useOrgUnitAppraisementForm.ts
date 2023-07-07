import { FormInstance, FieldRule } from "vant";
import { toast, notify } from "/@/utils/app";
import {
  AppraisementResultService,
  AppraisementResultCreateDto,
} from "/@/openapi";

export const useOrgUnitAppraisementForm = () => {
  let loading = ref(false);

  let form = reactive<AppraisementResultCreateDto>({
    appraisementId: undefined,
    candidateId: undefined,
    contentScores: null,
    category: undefined,
  });

  let formRules = reactive<Record<string, FieldRule[]>>({
    appraisementId: [
      { required: true, message: "请输入评价id", trigger: "onBlur" },
    ],
    candidateId: [
      {
        required: true,
        message: "请输入候选人id",
        trigger: "onBlur",
      },
    ],
    contentScores: [
      {
        required: true,
        message: "请输入内容分数",
        trigger: "onBlur",
      },
      {
        validator: async (value, _rule) => {
          if (value < 60 || value > 99) {
            return false;
          }
          return true;
        },
        message: "内容分数区间为[60,99]",
        trigger: "onChange",
      },
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
