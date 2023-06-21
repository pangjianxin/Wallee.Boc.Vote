import { FormInstance, FieldRule } from "vant";

import {
  EvaluationContentCreateDto,
  EvaluationContentDto,
  EvaluationContentService,
} from "/@/openapi";

import { toastError } from "/@/utils/app";

export const useEvlauationContentForm = () => {
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
        message: "请选择类型",
        trigger: "onBlur",
      },
    ],
  });
  let form = reactive<EvaluationContentCreateDto>({});

  const createEvaluationContent = async (): Promise<
    EvaluationContentDto | undefined
  > => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await EvaluationContentService.evaluationContentCreate({
        requestBody: form,
      });
      return res;
    } catch (error: any) {
      toastError(error);
      return undefined;
    } finally {
      loading.value = false;
    }
  };
  return { loading, formRef, formRules, form, createEvaluationContent };
};
