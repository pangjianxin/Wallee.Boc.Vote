import type { FieldRule, FormInstance } from "vant";
import type { CandidateOrgUnitUpdateDto } from "/@/openapi";
import { CandidateOrgUnitCategory, CandidateOrgUnitService } from "/@/openapi";
import { notify, toast } from "/@/utils/app";

export function useCandidateOrgUnitUpdateForm() {
  const loading = ref(false);
  const id = ref("");
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

  const form = reactive<CandidateOrgUnitUpdateDto>({
    category: CandidateOrgUnitCategory.前台部门,
  });

  const clearForm = () => {
    form.organizationUnitId = undefined;
    form.superiorId = undefined;
    form.category = CandidateOrgUnitCategory.前台部门;
  };

  const updateCandidateOrgUnit = async () => {
    try {
      await formRef.value?.validate();
      loading.value = true;
      const res = await CandidateOrgUnitService.candidateOrgUnitUpdate({
        id: id.value,
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
  return { id, loading, formRef, formRules, form, updateCandidateOrgUnit };
}
