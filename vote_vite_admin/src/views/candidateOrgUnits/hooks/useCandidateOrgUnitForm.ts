import { FormInstance, FieldRule } from "vant";
import { CandidateOrgUnitCreateDto, CandidateOrgUnitService } from "/@/openapi";
import { toastError } from "/@/utils/app";
export const useCandidateOrgUnitForm = () => {
  let loading = ref(false);
  let formRef = ref<FormInstance>();
  let formRules = reactive<Record<string, FieldRule[]>>({
    organName: [
      {
        required: true,
        message: "请输入机构名称",
        trigger: "onBlur",
      },
    ],
    organCode: [
      {
        required: true,
        message: "请输入机构号",
        trigger: "onBlur",
      },
    ],
    organizationUnitId: [
      {
        required: true,
        message: "请选择机构信息",
        trigger: "onBlur",
      },
    ],
    category: [
      {
        required: true,
        message: "请选择机构类型",
        trigger: "onBlur",
      },
    ],
    superiorId: [
      {
        required: true,
        message: "请选择分管行领导",
        trigger: "onBlur",
      },
    ],
  });
  let form = reactive<CandidateOrgUnitCreateDto>({});
  const createCandidateOrgUnit = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      let res = await CandidateOrgUnitService.candidateOrgUnitCreate({
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
  return { loading, formRef, formRules, form, createCandidateOrgUnit };
};
