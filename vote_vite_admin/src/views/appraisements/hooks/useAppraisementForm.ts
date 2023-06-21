import { FormInstance, FieldRule } from "vant";
import { AppraisementCreateDto, AppraisementService } from "/@/openapi";
import { toastError } from "/@/utils/app";
export const useCandidateOrgUnitForm = () => {
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

  let form = reactive<AppraisementCreateDto>({});

  const createAppraisement = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await AppraisementService.appraisementCreate({
        requestBody: form,
      });
      return res;
    } catch (err: any) {
      toastError(err.message);
      return undefined;
    } finally {
      loading.value = false;
    }
  };

  return { loading, formRef, formRules, form, createAppraisement };
};
