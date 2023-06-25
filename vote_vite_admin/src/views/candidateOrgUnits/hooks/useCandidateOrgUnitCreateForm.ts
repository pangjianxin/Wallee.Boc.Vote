import type { FieldRule, FormInstance } from "vant";
import type { CandidateOrgUnitCreateDto } from "/@/openapi";
import { CandidateOrgUnitCategory, CandidateOrgUnitService } from "/@/openapi";
import { notify, toast } from "/@/utils/app";

export function useCandidateOrgUnitCreateForm() {
  const loading = ref(false);

  const formRef = ref<FormInstance>();

  const formRules = reactive<Record<string, FieldRule[]>>({
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

  const form = reactive<CandidateOrgUnitCreateDto>({
    category: CandidateOrgUnitCategory.前台部门,
  });

  const clearForm = () => {
    form.organizationUnitId = undefined;
    form.superiorId = undefined;
    form.category = CandidateOrgUnitCategory.前台部门;
  };

  const createCandidateOrgUnit = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      const res = await CandidateOrgUnitService.candidateOrgUnitCreate({
        requestBody: form,
      });
      notify("创建成功");
      clearForm();
      return res;
    } catch (err: any) {
      toast(err);
      return undefined;
    } finally {
      loading.value = false;
    }
  };
  return { loading, formRef, formRules, form, createCandidateOrgUnit };
}
